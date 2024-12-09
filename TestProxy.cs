using UnityEngine;
using UnityEngine.Networking;

public class TestProxy : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(MakeRequest());
    }

    private IEnumerator MakeRequest()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("http://localhost:8080/"))
        {
            // Send the request and wait for a response
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                Debug.Log("Response: " + webRequest.downloadHandler.text);
            }
        }
    }
}
