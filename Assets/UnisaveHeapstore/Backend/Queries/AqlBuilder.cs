using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using LightJson;
using Unisave.Contracts;
using Unisave.Facades;

namespace UnisaveHeapstore.Backend.Queries
{
    public static class AqlBuilder
    {
        public static IAqlQuery Build(QueryRequest request)
        {
            // accumulate terms
            var bindings = new Dictionary<string, JsonValue>();
            var sb = new StringBuilder();

            // translate collection selector
            sb.AppendLine("FOR doc IN @@collection");
            bindings["@collection"] = request.collection;
            
            // translate filter clauses
            for (int i = 0; i < request.filterClauses.Count; i++)
            {
                var clause = request.filterClauses[i];
                string aqlOperator = TranslateOperator(clause.op);
                sb.AppendLine($"FILTER doc[@f_fld_{i}] {aqlOperator} @f_imm_{i}");
                bindings["f_fld_" + i] = clause.fieldName;
                bindings["f_imm_" + i] = clause.immediateValue;
            }
            
            // TODO: translate order by
            
            // translate limit
            if (request.limit > 0)
            {
                sb.AppendLine("LIMIT @lim");
                bindings["lim"] = request.limit;
            }
            
            // translate projection (no projection)
            sb.AppendLine("RETURN doc");

            // build the query
            var aqlQuery = DB.Query(sb.ToString());
            foreach (var x in bindings)
                aqlQuery.Bind(x.Key, x.Value);
            return aqlQuery;
        }

        public static string TranslateOperator(FilterOperator op)
        {
            switch (op)
            {
                case FilterOperator.LessThan: return "<";
                case FilterOperator.LessThanOrEqualTo: return "<=";
                case FilterOperator.GreaterThan: return ">";
                case FilterOperator.GreaterThanOrEqualTo: return ">=";
                case FilterOperator.EqualTo: return "==";
                case FilterOperator.NotEqualTo: return "!=";
            }

            throw new InvalidEnumArgumentException($"Unknown operator {op}.");
        }
    }
}