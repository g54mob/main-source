using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class MiscMsg : MonoBehaviour
{
	public static MiscMsg Instance;

	[NonSerialized]
	private bool used;

	private void Start()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(Instance.gameObject);
		}
		Instance = this;
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public static void SendMsg(string title, string content)
	{
		if (!(Instance == null) && !Instance.used)
		{
			Instance.used = true;
			Instance.StartCoroutine(Instance.Upload(title, content));
		}
	}

	private IEnumerator Upload(string title, string msg)
	{
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("key", "Swinkydink");
		wWWForm.AddField("content", msg);
		wWWForm.AddField("title", title);
		UnityWebRequest unityWebRequest = UnityWebRequest.Post("https://SoftwareInc.Coredumping.com/miscmsg.php", wWWForm);
		unityWebRequest.SetRequestHeader("User-Agent", "Swinc User Agent");
		yield return unityWebRequest.SendWebRequest();
	}
}
