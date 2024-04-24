using System.Collections;
using UnityEngine;
using UnityEngine.Networking;  // Required for UnityWebRequest
using UnityEngine.UI;         // Required for UI elements like Text
using System.IO;
using System;

public class pokemonAPI : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GetRequest("https://pokeapi.co/api/v2/ability/?offset=0&limit=2000"));
    }

    IEnumerator GetRequest(string uri)
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
                    using (StreamReader reader = new StreamReader("https://pokeapi.co/api/v2/ability/?offset=0&limit=2000"))
                    {
                        string line;
                        string[] itemParts = new string[2];

                        int pos = 0;
                        // Read and display lines from the file until the end of the file is reached
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(",");
                            for (int i = 0; i < parts.Length; i++)
                            {
                                print(parts[i]);
                                itemParts[pos % 2] = parts[i];
                                pos++;
                            }
                            Item theItem = new Item(itemParts[0], int.Parse(itemParts[1]));
                            theItem.display();
                        }
                    }
                    
                print(webRequest.downloadHandler.text);
                // Or retrieve results as binary data
                //byte[] results = webRequest.downloadHandler.data;
            }
        }
    }
}
