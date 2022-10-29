using Unisave.Facets;
using UnityEngine;

namespace Heapstore.Backend
{
    public class HeapstoreFacet : Facet
    {
        public string GreetClient()
        {
            Debug.Log("Server has been reached!");
            
            return "Hello client! I'm the server!";
        }
    }
}
