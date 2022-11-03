using LightJson;
using Unisave.Facades;
using Unisave.Serialization;
using UnisaveHeapstore.Backend;
using UnisaveHeapstore.Facades;
using UnityEngine;

namespace UnisaveHeapstore.Examples.Leaderboard
{
    public class LeaderboardClient : MonoBehaviour
    {
        /*
         * IDEA:
         * - leaderboard collection
         * - top 10 as query -> listen on that query
         * - insert / update my record action
         *
         * First data fetch must have delay, no way around it.
         */

        private void OnEnable()
        {
            Debug.Log("On Enable.");
            
            // TODO: start watching and stop on disable
            
            Heapstore
                .Collection("leaderboard")
                .Document("6708043842")
                .Get<JsonObject>(doc => {
                    Debug.Log("Document received: " + Serializer.ToJsonString(doc));
                });
        }

        private void OnDisable()
        {
            Debug.Log("On Disable.");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                
            }
        }
    }
}
