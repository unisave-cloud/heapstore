using System;
using Unisave.Facades;
using Unisave.Serialization;
using Unisave.Serialization.Context;
using UnisaveHeapstore.Backend;
using UnisaveHeapstore.Backend.Queries;
using UnityEngine;

namespace UnisaveHeapstore
{
    public class DocumentReference
    {
        private readonly string collectionName;
        private readonly string documentKey;

        public DocumentReference(string collectionName, string documentKey)
        {
            this.collectionName = collectionName;
            this.documentKey = documentKey;
        }

        public void Get<T>(Action<T> callback, Action<Exception> exceptionCallback = null)
        {
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));
            
            // default exception handler
            if (exceptionCallback == null)
                exceptionCallback = Debug.LogException; // TODO: make more advanced!
            
            // construct the query
            QueryRequest query = new QueryRequest();
            query.collection = collectionName;
            query.filterClauses.Add(new FilterClause() {
                fieldName = "_key",
                op = FilterOperator.EqualTo,
                immediateValue = documentKey
            });
            query.limit = 1;
            
            // send the request
            OnFacet<HeapstoreFacet>
                .Call<QueryResponse>(nameof(HeapstoreFacet.RunQuery), query)
                .Then((QueryResponse response) => {
                    
                    // document does not exist
                    if ((response.items?.Count ?? 0) == 0)
                    {
                        callback.Invoke(default(T));
                        return;
                    }
                    
                    // document fetched
                    T document = Serializer.FromJson<T>(
                        response.items[0],
                        DeserializationContext.ServerToClient
                    );
                    callback.Invoke(document);
                    
                })
                .Catch(exceptionCallback);
        }
    }
}