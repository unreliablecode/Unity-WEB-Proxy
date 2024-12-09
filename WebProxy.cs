using System;
using System.IO;
using System.Net;
using System.Threading;
using UnityEngine;

public class WebProxy : MonoBehaviour
{
    private HttpListener httpListener;
    private Thread listenerThread;

    private void Start()
    {
        // Start the HTTP listener on a separate thread
        listenerThread = new Thread(StartHttpListener);
        listenerThread.Start();
    }

    private void StartHttpListener()
    {
        httpListener = new HttpListener();
        httpListener.Prefixes.Add("http://localhost:8080/"); // Set the prefix for the listener
        httpListener.Start();
        Debug.Log("Listening for requests...");

        while (true)
        {
            // Wait for a request
            var context = httpListener.GetContext();
            ProcessRequest(context);
        }
    }

    private void ProcessRequest(HttpListenerContext context)
    {
        string requestedUrl = context.Request.Url.ToString();
        Debug.Log($"Request for: {requestedUrl}");

        // Check if the request is for google.com
        if (requestedUrl.Contains("google.com"))
        {
            // Respond with custom data
            string customResponse = "<html><body><h1>This is a custom response!</h1></body></html>";
            byte[] responseBuffer = System.Text.Encoding.UTF8.GetBytes(customResponse);

            context.Response.ContentType = "text/html";
            context.Response.ContentLength64 = responseBuffer.Length;
            context.Response.OutputStream.Write(responseBuffer, 0, responseBuffer.Length);
            context.Response.OutputStream.Close();
            Debug.Log("Custom response sent.");
        }
        else
        {
            // Handle other requests (optional)
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.Response.OutputStream.Close();
            Debug.Log("Request not handled.");
        }
    }

    private void OnApplicationQuit()
    {
        // Stop the listener when the application quits
        httpListener.Stop();
        listenerThread.Abort();
    }
}
