using System.Collections.Generic;
using LightJson;
using Unisave.Facades;
using Unisave.Facets;
using UnisaveHeapstore.Backend.Queries;
using UnityEngine;

namespace UnisaveHeapstore.Backend
{
    public class HeapstoreFacet : Facet
    {
        public List<QueryResponse> RunQueries(List<QueryRequest> queries)
        {
            List<QueryResponse> responses = new List<QueryResponse>(queries.Count);

            for (int i = 0; i < queries.Count; i++)
            {
                responses[i] = RunQuery(queries[i]);
            }
            
            return responses;
        }

        public QueryResponse RunQuery(QueryRequest query)
        {
            // TODO: implement security rules
            
            return new QueryResponse() {
                items = AqlBuilder.Build(query).GetAs<JsonValue>()
            };
        }
    }
}
