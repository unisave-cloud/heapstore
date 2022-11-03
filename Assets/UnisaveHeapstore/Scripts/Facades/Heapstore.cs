namespace UnisaveHeapstore.Facades
{
    public static class Heapstore
    {
        public static CollectionReference Collection(string name)
        {
            return new CollectionReference(name);
        }
    }
}