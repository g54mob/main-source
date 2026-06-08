using System;
using System.Collections;
using CloudOnce;
using UnityEngine;
using UnityEngine.Networking;

public class RemoteSaveDataController : MonoBehaviour
{
	private const string BASE_URL = "https://stonestoryrpg.com/cs/";

	public string inputSalt;

	private bool hasCheatSaved;

	public static RemoteSaveDataController singleton { get; private set; }

	private void Update()
	{
		if (!hasCheatSaved && Input.touchCount >= 5 && GameStates.Singleton.CurrentState <= GameStates.State.MainMenu && !string.IsNullOrEmpty(CloudVariables.data))
		{
			hasCheatSaved = true;
			GameplayActionMessages.SetMessage("Uploading save data for debugging...", ColorConstants.green, 10f);
			SaveData(CloudVariables.data, delegate(string exchangeCode)
			{
				Utils.LogIfEditor("Exchange code: " + exchangeCode);
			});
		}
	}

	public void SaveData(string saveData, Action<string> callback)
	{
		string version = Features.VERSION.ToString();
		string heroName = GetHeroName();
		string saveFileId = GetSaveFileId();
		StartCoroutine(_SaveData(callback, saveData, version, heroName, saveFileId, SaveFiles.deviceId));
	}

	private string GetHeroName()
	{
		return HeroSettings.name;
	}

	private string GetSaveFileId()
	{
		if (GameSave.activeSaveFile == null)
		{
			return null;
		}
		return GameSave.activeSaveFile.uniqueId;
	}

	private IEnumerator _SaveData(Action<string> callback, string saveData, string version, string heroName, string saveFileId, string deviceId)
	{
		string text = "https://stonestoryrpg.com/cs/save.php";
		if (saveFileId == null)
		{
			int num = saveData.IndexOf("uId:");
			saveFileId = ((num <= 0) ? "?????1" : saveData.Substring(num + 4, 6));
		}
		if (heroName == "simple one")
		{
			int num2 = saveData.IndexOf("player_name:");
			if (num2 > 0)
			{
				int num3 = num2 + 12;
				int length = saveData.IndexOf(',', num3) - num3;
				heroName = saveData.Substring(num3, length);
			}
		}
		string value = Utils.MD5(heroName + saveFileId + inputSalt);
		Utils.LogIfEditor("Calling remote: " + text);
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("sd", saveData);
		wWWForm.AddField("v", version);
		wWWForm.AddField("name", heroName);
		wWWForm.AddField("save_id", saveFileId);
		wWWForm.AddField("device", deviceId);
		wWWForm.AddField("valid", value);
		using UnityWebRequest webRequest = UnityWebRequest.Post(text, wWWForm);
		yield return webRequest.SendWebRequest();
		if (webRequest.result != UnityWebRequest.Result.Success)
		{
			Utils.LogErrorIfEditor("Failed to upload save. " + webRequest.downloadHandler.text);
		}
		else if (hasCheatSaved)
		{
			GameplayActionMessages.SetMessage("Uploaded!", ColorConstants.green, 10f);
			string text2 = webRequest.downloadHandler.text;
			Utils.LogIfEditor(text2);
			string obj = SlimJson.Parse(text2, "exchangeCode");
			callback(obj);
		}
	}

	private void Awake()
	{
		singleton = this;
	}
}
