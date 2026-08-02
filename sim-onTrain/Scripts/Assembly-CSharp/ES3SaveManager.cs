using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class ES3SaveManager : Singleton<ES3SaveManager>
{
	public UnityEvent OnGameSave = new UnityEvent();

	public UnityEvent OnGameLoad = new UnityEvent();

	public UnityEvent OnPreLoad = new UnityEvent();

	[SerializeField]
	private string saveName;

	private string currentSaveFilePath;

	private bool isDataPreloaded;

	private bool isBatching;

	private List<KeyValuePair<string, object>> batchBuffer;

	public Transform dontDestroyObject;

	private void Start()
	{
		if (!string.IsNullOrEmpty(CustomNetworkManager.loadedGameKey))
		{
			SetSaveName(CustomNetworkManager.loadedGameKey);
		}
		base.transform.SetParent(dontDestroyObject);
	}

	public void InitializeSave()
	{
		if (!string.IsNullOrEmpty(saveName))
		{
			currentSaveFilePath = Path.Combine(GetSavePath(), saveName + ".es3");
			Debug.Log("Save path initialized: " + currentSaveFilePath);
		}
	}

	public void SetSaveName(string newSaveName)
	{
		saveName = newSaveName;
		InitializeSave();
	}

	private string GetSavePath()
	{
		string text = Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Users", "DB");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		return text;
	}

	public void PreloadGameData()
	{
		if (!string.IsNullOrEmpty(currentSaveFilePath) && ES3.FileExists(currentSaveFilePath))
		{
			OnPreLoad.Invoke();
			isDataPreloaded = true;
		}
	}

	public void Save()
	{
		if (string.IsNullOrEmpty(saveName) && !string.IsNullOrEmpty(CustomNetworkManager.loadedGameKey))
		{
			SetSaveName(CustomNetworkManager.loadedGameKey);
		}
		if (!string.IsNullOrEmpty(currentSaveFilePath))
		{
			batchBuffer = new List<KeyValuePair<string, object>>();
			isBatching = true;
			OnGameSave.Invoke();
			using (ES3Writer eS3Writer = ES3Writer.Create(new ES3Settings(currentSaveFilePath)))
			{
				foreach (KeyValuePair<string, object> item in batchBuffer)
				{
					if (item.Value != null)
					{
						eS3Writer.Write(item.Value.GetType(), item.Key, item.Value);
					}
				}
				eS3Writer.Save();
			}
			isBatching = false;
			batchBuffer = null;
			UpdateLastAccessTime();
			Debug.Log("Game saved to: " + currentSaveFilePath);
			if (Singleton<SteamCloudManager>.Instance != null)
			{
				StartCoroutine(UploadToCloudDeferred(currentSaveFilePath));
			}
		}
		else
		{
			Debug.LogError("Save failed: No save name set");
		}
	}

	private IEnumerator UploadToCloudDeferred(string filePath)
	{
		yield return null;
		Singleton<SteamCloudManager>.Instance.UploadSaveToCloud(filePath);
	}

	public void LoadGame()
	{
		if (string.IsNullOrEmpty(saveName) && !string.IsNullOrEmpty(CustomNetworkManager.loadedGameKey))
		{
			SetSaveName(CustomNetworkManager.loadedGameKey);
		}
		if (!string.IsNullOrEmpty(currentSaveFilePath) && Singleton<SteamCloudManager>.Instance != null)
		{
			Singleton<SteamCloudManager>.Instance.DownloadSaveFromCloud(currentSaveFilePath);
		}
		if (!string.IsNullOrEmpty(currentSaveFilePath) && ES3.FileExists(currentSaveFilePath))
		{
			if (!isDataPreloaded)
			{
				OnPreLoad.Invoke();
			}
			OnGameLoad.Invoke();
			isDataPreloaded = false;
			Debug.Log("Game loaded from: " + currentSaveFilePath);
		}
		else
		{
			Debug.LogWarning("Save file not found: " + currentSaveFilePath);
		}
	}

	public void SaveData(string key, object value)
	{
		if (string.IsNullOrEmpty(currentSaveFilePath))
		{
			if (string.IsNullOrEmpty(CustomNetworkManager.loadedGameKey))
			{
				Debug.LogError("Cannot save data - no save name set. Key: " + key);
				return;
			}
			SetSaveName(CustomNetworkManager.loadedGameKey);
		}
		if (!string.IsNullOrEmpty(currentSaveFilePath))
		{
			if (isBatching)
			{
				batchBuffer.Add(new KeyValuePair<string, object>(key, value));
				return;
			}
			ES3.Save(key, value, currentSaveFilePath);
			UpdateLastAccessTime();
		}
	}

	public T LoadData<T>(string key, T defaultValue = default(T))
	{
		if (string.IsNullOrEmpty(currentSaveFilePath) && !string.IsNullOrEmpty(CustomNetworkManager.loadedGameKey))
		{
			SetSaveName(CustomNetworkManager.loadedGameKey);
		}
		if (!string.IsNullOrEmpty(currentSaveFilePath) && ES3.FileExists(currentSaveFilePath))
		{
			UpdateLastAccessTime();
			return ES3.Load(key, currentSaveFilePath, defaultValue);
		}
		return defaultValue;
	}

	public void UpdateLastAccessTime()
	{
		if (!string.IsNullOrEmpty(saveName))
		{
			string key = saveName + "_LastAccess";
			string value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			string text = Path.Combine(GetSavePath(), "Times");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string filePath = Path.Combine(text, "SaveTimes.es3");
			ES3.Save(key, value, filePath);
		}
	}

	public string GetSaveLastAccessTime(string saveFileName)
	{
		string key = saveFileName + "_LastAccess";
		string filePath = Path.Combine(Path.Combine(GetSavePath(), "Times"), "SaveTimes.es3");
		try
		{
			if (ES3.FileExists(filePath) && ES3.KeyExists(key, filePath))
			{
				return ES3.Load<string>(key, filePath);
			}
		}
		catch (Exception ex)
		{
			Debug.LogWarning("SaveTimes dosyası okunamadı: " + ex.Message);
		}
		return "";
	}

	public void SaveLobbyMode(string saveFileName, int lobbyMode)
	{
		string key = saveFileName + "_LobbyMode";
		string text = Path.Combine(GetSavePath(), "Times");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string filePath = Path.Combine(text, "SaveTimes.es3");
		ES3.Save(key, lobbyMode, filePath);
	}

	public int GetLobbyMode(string saveFileName, out bool exists)
	{
		string key = saveFileName + "_LobbyMode";
		string filePath = Path.Combine(Path.Combine(GetSavePath(), "Times"), "SaveTimes.es3");
		try
		{
			if (ES3.FileExists(filePath) && ES3.KeyExists(key, filePath))
			{
				exists = true;
				return ES3.Load<int>(key, filePath);
			}
		}
		catch (Exception ex)
		{
			Debug.LogWarning("SaveTimes dosyası okunamadı, yeniden oluşturulacak: " + ex.Message);
			ES3.DeleteFile(filePath);
		}
		exists = false;
		return 0;
	}

	public bool KeyExists(string key)
	{
		if (string.IsNullOrEmpty(currentSaveFilePath) && !string.IsNullOrEmpty(CustomNetworkManager.loadedGameKey))
		{
			SetSaveName(CustomNetworkManager.loadedGameKey);
		}
		if (!string.IsNullOrEmpty(currentSaveFilePath) && ES3.FileExists(currentSaveFilePath))
		{
			return ES3.KeyExists(key, currentSaveFilePath);
		}
		return false;
	}

	public void DeleteCurrentSave()
	{
		if (!string.IsNullOrEmpty(currentSaveFilePath) && ES3.FileExists(currentSaveFilePath))
		{
			ES3.DeleteFile(currentSaveFilePath);
			if (Singleton<SteamCloudManager>.Instance != null)
			{
				Singleton<SteamCloudManager>.Instance.DeleteCloudSave(currentSaveFilePath);
			}
		}
	}

	public string[] GetAllSaves()
	{
		string savePath = GetSavePath();
		if (!Directory.Exists(savePath))
		{
			Directory.CreateDirectory(savePath);
			return new string[0];
		}
		string[] files = Directory.GetFiles(savePath, "*.es3");
		for (int i = 0; i < files.Length; i++)
		{
			files[i] = Path.GetFileNameWithoutExtension(files[i]);
		}
		return files;
	}

	public string[] GetAllKeys()
	{
		if (string.IsNullOrEmpty(currentSaveFilePath) && !string.IsNullOrEmpty(CustomNetworkManager.loadedGameKey))
		{
			SetSaveName(CustomNetworkManager.loadedGameKey);
		}
		if (!string.IsNullOrEmpty(currentSaveFilePath) && ES3.FileExists(currentSaveFilePath))
		{
			return ES3.GetKeys(currentSaveFilePath);
		}
		return new string[0];
	}

	public void DeleteKey(string key)
	{
		if (!string.IsNullOrEmpty(currentSaveFilePath) && ES3.FileExists(currentSaveFilePath))
		{
			ES3.DeleteKey(key, currentSaveFilePath);
		}
	}
}
