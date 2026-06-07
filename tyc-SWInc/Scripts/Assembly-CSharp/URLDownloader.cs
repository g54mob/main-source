using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class URLDownloader : MonoBehaviour
{
	private string _URL;

	private Action<string, string> _onFinished;

	public static void Launch(string url, Action<string, string> onFinished)
	{
		URLDownloader uRLDownloader = new GameObject("URLDownloader").AddComponent<URLDownloader>();
		uRLDownloader._URL = url;
		uRLDownloader._onFinished = onFinished;
	}

	private IEnumerator Start()
	{
		UnityWebRequest web = UnityWebRequest.Get(_URL);
		yield return web.SendWebRequest();
		_onFinished(web.downloadHandler.text, web.error);
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
