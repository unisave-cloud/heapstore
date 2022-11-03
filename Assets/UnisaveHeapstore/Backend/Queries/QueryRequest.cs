using System.Collections.Generic;

namespace UnisaveHeapstore.Backend.Queries
{
    public class QueryRequest
    {
        /// <summary>
        /// Name of the collection to query
        /// </summary>
        public string collection;
        
        /// <summary>
        /// Filter clauses in conjunction
        /// </summary>
        public List<FilterClause> filterClauses = new List<FilterClause>();
        
        // TODO: order by

        /// <summary>
        /// Limit the number of returned documents
        /// </summary>
        public int limit = 0;
    }
}