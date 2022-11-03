namespace UnisaveHeapstore
{
    public class CollectionReference
    {
        private string collectionName;

        public CollectionReference(string collectionName)
        {
            this.collectionName = collectionName;
        }

        public DocumentReference Document(string key)
        {
            return new DocumentReference(
                collectionName: collectionName,
                documentKey: key
            );
        }
    }
}