using LightJson;

namespace UnisaveHeapstore.Backend.Queries
{
    public class FilterClause
    {
        public string fieldName;
        public FilterOperator op;
        public JsonValue immediateValue;
    }
}