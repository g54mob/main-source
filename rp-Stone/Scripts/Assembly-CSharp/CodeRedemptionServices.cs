using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class CodeRedemptionServices : MonoBehaviour
{
	private readonly string BASE_URL = "https://stonestoryrpg.com/cs/";

	public static CodeRedemptionServices singleton { get; private set; }

	public void SetCode(string code)
	{
		StartCoroutine(_SetCode(code));
	}

	private IEnumerator _SetCode(string code)
	{
		string text = BASE_URL + "code.php";
		Utils.LogIfEditor(text + ", code = " + code);
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("code", code);
		wWWForm.AddField("version", Features.VERSION.ToString());
		using UnityWebRequest webRequest = UnityWebRequest.Post(text, wWWForm);
		yield return webRequest.SendWebRequest();
		if (webRequest.result != UnityWebRequest.Result.Success)
		{
			Utils.LogErrorIfEditor(webRequest.error);
			yield break;
		}
		string text2 = webRequest.downloadHandler.text;
		if (text2 == "")
		{
			Utils.LogIfEditor("Request complete.");
		}
		else
		{
			Utils.LogIfEditor(text2);
		}
	}

	public void GetRedemptionToken(string code, Action<string> callback)
	{
		StartCoroutine(_GetRedemptionToken(code, callback));
	}

	private IEnumerator _GetRedemptionToken(string code, Action<string> callback)
	{
		string text = BASE_URL + "redeem.php";
		Utils.LogIfEditor(text + ", code = " + code);
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("code", code);
		wWWForm.AddField("version", Features.VERSION.ToString());
		using UnityWebRequest webRequest = UnityWebRequest.Post(text, wWWForm);
		yield return webRequest.SendWebRequest();
		if (webRequest.result != UnityWebRequest.Result.Success)
		{
			Utils.LogError(webRequest.error);
			callback("");
		}
		else
		{
			string text2 = webRequest.downloadHandler.text;
			Utils.LogIfEditor(text2);
			callback(text2);
		}
	}

	public void SetRedemptionToken(string code, string rToken)
	{
	}

	public void ClearDatabase()
	{
	}

	private void Awake()
	{
		singleton = this;
	}
}
