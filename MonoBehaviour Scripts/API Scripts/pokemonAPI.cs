using System.Collections;
using UnityEngine;
using UnityEngine.Networking;  // Required for UnityWebRequest
using UnityEngine.UI;         // Required for UI elements like Text
using System.IO;
using System;

public class pokemonAPI : MonoBehaviour
{
    string api = "api.coincap.io/v2/assets";
    void Start()
    {
        StartCoroutine(GetCryptoRequest("api.coincap.io/v2/assets"));
        //StartCoroutine(GetRequest("https://pokeapi.co/api/v2/ability/?offset=0&limit=2000"));
    }

    /*IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
     
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                print("Error: " + webRequest.error);
            }
            else
            {
                // Show results as text
                string jsonString = webRequest.downloadHandler.text;

                // Parse the JSON string
                
                // Or retrieve results as binary data
                //byte[] results = webRequest.downloadHandler.data;
            }
        }
    }*/

    IEnumerator GetCryptoRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
     
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                print("Error: " + webRequest.error);
            }
            else
            {
                // Show results as text
                string jsonString = webRequest.downloadHandler.text;
                
                Debug.Log(jsonString);
                CollectionOfCrypto theCollectionOfCrypto = JsonUtility.FromJson<CollectionOfCrypto>(jsonString);
                theCollectionOfCrypto.display();
            }
        }
    }
}
