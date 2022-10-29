using System;
using Heapstore.Backend;
using Unisave.Facades;
using UnityEngine;

namespace Heapstore.Examples.Foo
{
    public class FooClient : MonoBehaviour
    {
        /*
         * IDEA:
         * - leaderboard collection
         * - top 10 as query -> listen on that query
         * - insert / update my record action
         *
         * First data fetch must have delay, no way around it.
         */
        
        void Start()
        {
            Debug.Log("Calling server...");
            
            OnFacet<HeapstoreFacet>
                .Call<string>(nameof(HeapstoreFacet.GreetClient))
                .Then(response => {
                    Debug.Log("Server responded with: " + response);
                })
                .Done();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                
            }
        }
    }
}
