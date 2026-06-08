using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RemoteVersionCheckController : MonoBehaviour
{
	private const string BASE_URL = "https://stonestoryrpg.com/cs/";

	public bool newVersionAvailable { get; private set; }

	public Version newVersionValue { get; private set; }

	public static RemoteVersionCheckController singleton { get; private set; }

	private void Awake()
	{
		singleton = this;
		CheckLatestVersion(delegate(bool isNewVersionAvailable, Version newVersion)
		{
			newVersionAvailable = isNewVersionAvailable;
			newVersionValue = newVersion;
		});
	}

	public void CheckLatestVersion(Action<bool, Version> callback)
	{
		StartCoroutine(_CheckLatestVersion(callback));
	}

	private IEnumerator _CheckLatestVersion(Action<bool, Version> callback)
	{
		string text = "https://stonestoryrpg.com/cs/version.php";
		Utils.LogIfEditor("Calling remote: " + text);
		WWWForm formData = new WWWForm();
		using UnityWebRequest webRequest = UnityWebRequest.Post(text, formData);
		yield return webRequest.SendWebRequest();
		if (webRequest.result != UnityWebRequest.Result.Success)
		{
			callback(arg1: false, Features.VERSION);
			yield break;
		}
		string text2 = webRequest.downloadHandler.text;
		try
		{
			Version version = Version.FromString(SlimJson.Parse(text2, "pc"));
			if (version > Features.VERSION)
			{
				callback(arg1: true, version);
			}
			else
			{
				callback(arg1: false, Features.VERSION);
			}
		}
		catch
		{
			callback(arg1: false, Features.VERSION);
		}
	}
}
