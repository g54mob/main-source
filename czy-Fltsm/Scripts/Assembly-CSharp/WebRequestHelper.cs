using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public static class WebRequestHelper
{
	public static string RequestData(string url)
	{
		Debug.Log($"Contacting {url}...");
		UnityWebRequest unityWebRequest = new UnityWebRequest();
		unityWebRequest.url = url;
		unityWebRequest.downloadHandler = new DownloadHandlerBuffer();
		unityWebRequest.SendWebRequest();
		while (!unityWebRequest.isDone)
		{
		}
		Debug.Log($"Finished downloading {url}");
		return Encoding.Default.GetString(unityWebRequest.downloadHandler.data);
	}
}
