using System;
using System.Collections.Generic;
using System.Globalization;
using CloudOnce;

public class CloudOneStorage : AStorage
{
	private readonly int DEBUG_PAD_DATA_AMOUNT = 1000000;

	private readonly string CREATED_TIME_KEY = "createdTime";

	private readonly string MODIFIED_TIME_KEY = "modifiedTime";

	private Dictionary<string, object> _dataDictionary = new Dictionary<string, object>();

	private PlayerPrefsStorage playerPrefsStorage;

	private bool isBusySaving;

	private string debugMessage = "";

	private int _workId;

	public CloudOneStorage()
	{
		currentState = State.Initializing;
		Cloud.OnSignInFailed += HandleSignInFailed;
		Cloud.OnSignedInChanged += HandleSignInSuccess;
		Cloud.OnCloudLoadComplete += HandleLoadComplete;
		Cloud.OnCloudSaveComplete += HandleSaveComplete;
		Cloud.Initialize();
	}

	public void RetrySignIn()
	{
		currentState = State.Initializing;
		Cloud.SignIn();
	}

	public void RetryLoad()
	{
		currentState = State.Initializing;
		Cloud.Storage.Load();
	}

	public void LoadFromPlayerPrefs()
	{
		if (playerPrefsStorage == null)
		{
			playerPrefsStorage = new PlayerPrefsStorage();
		}
	}

	public void ConcludeMerge()
	{
		currentState = State.Success;
	}

	public override bool IsBusySaving()
	{
		return isBusySaving;
	}

	public override void Load()
	{
	}

	public override void Clear()
	{
		if (playerPrefsStorage != null)
		{
			foreach (KeyValuePair<string, object> item in _dataDictionary)
			{
				playerPrefsStorage.DeleteKey(item.Key);
			}
		}
		_dataDictionary.Clear();
	}

	private void AddDebugMessage(string msg)
	{
	}

	private void HandleSignInFailed()
	{
		currentState = State.ConnectionError;
		AddDebugMessage("CloudOne sign in failed!");
	}

	private void HandleSignInSuccess(bool success)
	{
		AddDebugMessage("CloudOne signed in. Success: " + success);
	}

	private void HandleLoadComplete(bool success)
	{
		if (success)
		{
			currentState = State.Success;
			if (playerPrefsStorage == null)
			{
				playerPrefsStorage = new PlayerPrefsStorage();
			}
			if (!playerPrefsStorage.HasKey("save_file_last_id"))
			{
				playerPrefsStorage = null;
			}
			string data = CloudVariables.data;
			FromJson(data);
			AddDebugMessage("Loaded CloudOne storage. Success: " + success + ", len: " + data.Length);
			if (playerPrefsStorage == null)
			{
				return;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			int num = 0;
			int num2 = 0;
			int num3;
			if (_dataDictionary.ContainsKey("save_file_last_id"))
			{
				num3 = (int)_dataDictionary["save_file_last_id"];
				for (int i = 0; i <= num3; i++)
				{
					string text = "save_file_" + i;
					if (_dataDictionary.ContainsKey(text))
					{
						string saveFile = (string)_dataDictionary[text];
						if (_AddSaveFileToDictionary(dictionary, saveFile, text))
						{
							num++;
						}
					}
				}
			}
			num3 = playerPrefsStorage.GetInt("save_file_last_id");
			for (int j = 0; j <= num3; j++)
			{
				string text2 = "save_file_" + j;
				if (playerPrefsStorage.HasKey(text2))
				{
					string saveFile2 = playerPrefsStorage.GetString(text2);
					if (_AddSaveFileToDictionary(dictionary, saveFile2, text2))
					{
						num2++;
					}
					playerPrefsStorage.DeleteKey(text2);
				}
			}
			playerPrefsStorage.DeleteKey("save_file_last_id");
			if (num2 <= 0)
			{
				return;
			}
			if (num > 0)
			{
				currentState = State.StorageMerge;
				AddDebugMessage("Storage merge. Total save files: " + dictionary.Count);
			}
			else
			{
				AddDebugMessage("Upgrade from PlayerPrefs to Cloud. Total saves: " + dictionary.Count);
			}
			_dataDictionary.Clear();
			int num4 = 0;
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				string key = "save_file_" + num4;
				string value = item.Value;
				value = value.Replace("\\n", "");
				value = value.Replace("\\t", "");
				int num5 = value.IndexOf("{save_id:");
				int startIndex = value.IndexOf(",", num5);
				value = string.Concat(value.Substring(0, num5 + "{save_id:".Length), str2: value.Substring(startIndex), str1: num4.ToString());
				_dataDictionary[key] = value;
				num4++;
			}
			_dataDictionary["save_file_last_id"] = dictionary.Count - 1;
			data = ToJson();
			CloudVariables.data = data;
			Cloud.Storage.Save();
			isBusySaving = true;
		}
		else if (currentState != State.ConnectionError)
		{
			currentState = State.LoadingError;
		}
	}

	private bool _AddSaveFileToDictionary(Dictionary<string, string> saves, string saveFile, string saveId)
	{
		if (saveFile != null)
		{
			string text = SlimJson.Parse(saveFile, "uId");
			if (string.IsNullOrEmpty(text))
			{
				text = _workId.ToString();
				_workId++;
			}
			if (!saves.ContainsKey(text))
			{
				saves[text] = saveFile;
				return true;
			}
			DateTime dateTime = SlimJson.ParseDateTime(saves[text], "timestamp");
			if (SlimJson.ParseDateTime(saveFile, "timestamp") > dateTime)
			{
				saves[text] = saveFile;
				return true;
			}
		}
		return false;
	}

	public override void Save()
	{
		isBusySaving = true;
		ShowMessage_SaveStarted();
		string value = DateTime.Now.ToString(CultureInfo.InvariantCulture);
		bool flag = _dataDictionary.Count == 0;
		if (!flag)
		{
			if (!HasKey(CREATED_TIME_KEY))
			{
				SetString(CREATED_TIME_KEY, value);
			}
			SetString(MODIFIED_TIME_KEY, value);
		}
		if (GetState() == State.Success)
		{
			if (flag)
			{
				CloudVariables.data = "";
			}
			else
			{
				CloudVariables.data = ToJson();
			}
			Cloud.Storage.Save();
		}
		else if (playerPrefsStorage != null)
		{
			playerPrefsStorage.Save();
			ShowMessage_Saved();
		}
		else
		{
			ShowMessage_SaveFailed(1);
		}
	}

	private void HandleSaveComplete(bool success)
	{
		isBusySaving = false;
		if (success)
		{
			ShowMessage_Saved();
		}
		else
		{
			ShowMessage_SaveFailed(2);
		}
		int num = CloudVariables.data?.Length ?? 0;
		AddDebugMessage("Saved CloudOne storage. Success: " + success + ", len: " + num);
		if (success && playerPrefsStorage != null)
		{
			playerPrefsStorage.Save();
			if (GetState() == State.Success || GetState() == State.StorageMerge)
			{
				playerPrefsStorage = null;
			}
		}
	}

	private void ShowMessage_SaveStarted()
	{
		GameplayActionMessages.SetMessage(Te.xt("tid_ui_storage_saving"), ColorConstants.grey, 3f);
	}

	private void ShowMessage_Saved()
	{
		GameplayActionMessages.SetMessage(Te.xt("tid_ui_storage_saved"), ColorConstants.white, 2f);
	}

	private void ShowMessage_SaveFailed(int code)
	{
		GameplayActionMessages.SetMessage(Te.xt("tid_ui_storage_not_saved") + "[" + code + "]", ColorConstants.red, 10f);
	}

	private string ToJson()
	{
		bool identationEnabled = SlimJson.identationEnabled;
		SlimJson.identationEnabled = false;
		SlimJson.BeginSerialization();
		int count = _dataDictionary.Count;
		List<string> list = new List<string>(count);
		List<string> list2 = new List<string>(count);
		List<string> list3 = new List<string>(count);
		foreach (KeyValuePair<string, object> item in _dataDictionary)
		{
			if (item.Value is string)
			{
				SlimJson.AddProperty(item.Key, (string)item.Value);
				list.Add(item.Key);
			}
			else if (item.Value is int)
			{
				SlimJson.AddProperty(item.Key, (int)item.Value);
				list2.Add(item.Key);
			}
			else if (item.Value is bool)
			{
				SlimJson.AddProperty(item.Key, (bool)item.Value);
				list3.Add(item.Key);
			}
			else
			{
				Utils.LogError("Unsuported type when serializing in SteamCloudStorage.ToJson(): " + item.Value);
			}
		}
		SlimJson.AddProperty("STRING_KEYS", list.ToArray());
		SlimJson.AddProperty("INT_KEYS", list2.ToArray());
		SlimJson.AddProperty("BOOL_KEYS", list3.ToArray());
		string inValue = SlimJson.EndSerialization();
		SlimJson.identationEnabled = identationEnabled;
		return AStorage.ReplaceQuotes(inValue);
	}

	private void FromJson(string sjson)
	{
		_dataDictionary.Clear();
		sjson = AStorage.UnplaceQuotes(sjson);
		string[] array = SlimJson.ParseArray(sjson, "INT_KEYS");
		if (array != null)
		{
			foreach (string key in array)
			{
				int num = SlimJson.ParseInt(sjson, key);
				_dataDictionary.Add(key, num);
			}
		}
		bool flag = _dataDictionary.ContainsKey("save_file_last_id");
		int num2 = -1;
		array = SlimJson.ParseArray(sjson, "STRING_KEYS");
		if (array != null)
		{
			foreach (string text in array)
			{
				string value = SlimJson.Parse(sjson, text);
				_dataDictionary.Add(text, value);
				if (!flag && text.StartsWith("save_file_"))
				{
					int num3 = Utils.ParseInt(text.Substring(10));
					if (num2 < num3)
					{
						num2 = num3;
					}
				}
			}
		}
		if (!flag)
		{
			_dataDictionary.Add("save_file_last_id", num2);
		}
		array = SlimJson.ParseArray(sjson, "BOOL_KEYS");
		if (array != null)
		{
			foreach (string key2 in array)
			{
				bool flag2 = SlimJson.ParseBool(sjson, key2);
				_dataDictionary.Add(key2, flag2);
			}
		}
	}

	private void CopyToPlayerPrefs()
	{
		foreach (KeyValuePair<string, object> item in _dataDictionary)
		{
			if (item.Value is string)
			{
				playerPrefsStorage.SetString(item.Key, (string)item.Value);
			}
			else if (item.Value is int)
			{
				playerPrefsStorage.SetInt(item.Key, (int)item.Value);
			}
			else if (item.Value is bool)
			{
				playerPrefsStorage.SetBool(item.Key, (bool)item.Value);
			}
		}
	}

	private void CopyFromPlayerPrefs()
	{
		_dataDictionary.Clear();
		int num = playerPrefsStorage.GetInt("save_file_last_id");
		for (int i = 0; i <= num; i++)
		{
			string key = "save_file_" + i;
			if (playerPrefsStorage.HasKey(key))
			{
				string value = playerPrefsStorage.GetString(key);
				_dataDictionary[key] = value;
			}
		}
	}

	public override bool HasKey(string key)
	{
		if (playerPrefsStorage != null && playerPrefsStorage.HasKey("save_file_last_id"))
		{
			return playerPrefsStorage.HasKey(key);
		}
		return _dataDictionary.ContainsKey(key);
	}

	public override void DeleteKey(string key)
	{
		if (playerPrefsStorage != null)
		{
			playerPrefsStorage.DeleteKey(key);
		}
		if (_dataDictionary.ContainsKey(key))
		{
			_dataDictionary.Remove(key);
		}
	}

	public override string GetString(string key, string defaultValue = "")
	{
		if (playerPrefsStorage != null && playerPrefsStorage.HasKey("save_file_last_id"))
		{
			return playerPrefsStorage.GetString(key, defaultValue);
		}
		if (_dataDictionary.ContainsKey(key))
		{
			return (string)_dataDictionary[key];
		}
		return defaultValue;
	}

	public override void SetString(string key, string value)
	{
		if (playerPrefsStorage != null)
		{
			playerPrefsStorage.SetString(key, value);
		}
		_dataDictionary[key] = value;
	}

	public override int GetInt(string key, int defaultValue = 0)
	{
		if (playerPrefsStorage != null && playerPrefsStorage.HasKey("save_file_last_id"))
		{
			return playerPrefsStorage.GetInt(key, defaultValue);
		}
		if (_dataDictionary.ContainsKey(key))
		{
			return (int)_dataDictionary[key];
		}
		return defaultValue;
	}

	public override void SetInt(string key, int value)
	{
		if (playerPrefsStorage != null)
		{
			playerPrefsStorage.SetInt(key, value);
		}
		_dataDictionary[key] = value;
	}

	public override bool GetBool(string key, bool defaultValue = false)
	{
		if (playerPrefsStorage != null && playerPrefsStorage.HasKey("save_file_last_id"))
		{
			return playerPrefsStorage.GetBool(key, defaultValue);
		}
		if (_dataDictionary.ContainsKey(key))
		{
			return (bool)_dataDictionary[key];
		}
		return defaultValue;
	}

	public override void SetBool(string key, bool value)
	{
		if (playerPrefsStorage != null)
		{
			playerPrefsStorage.SetBool(key, value);
		}
		_dataDictionary[key] = value;
	}

	public override string ExportAsString()
	{
		if (GetState() == State.Success)
		{
			return ToJson();
		}
		if (playerPrefsStorage != null)
		{
			return playerPrefsStorage.ExportAsString();
		}
		return null;
	}

	public override void ImportFromString(string sjson)
	{
		FromJson(sjson);
	}

	public override string GetStoragePath()
	{
		return "";
	}

	public override List<string> ListDir(string relDir)
	{
		throw new NotImplementedException();
	}

	public override string LoadTextFile(string relFilename)
	{
		if (playerPrefsStorage != null)
		{
			return playerPrefsStorage.LoadTextFile(relFilename);
		}
		string key = GetStoragePath() + "/" + relFilename;
		if (!HasKey(key))
		{
			return null;
		}
		return GetString(key);
	}

	public override void SaveTextFile(string relFilename, string text)
	{
		string key = GetStoragePath() + "/" + relFilename;
		SetString(key, text);
	}

	public override void Delete(string relFilename)
	{
		string key = GetStoragePath() + "/" + relFilename;
		if (HasKey(key))
		{
			DeleteKey(key);
		}
	}

	public override bool Exists(string relFilename)
	{
		if (playerPrefsStorage != null)
		{
			return playerPrefsStorage.Exists(relFilename);
		}
		string key = GetStoragePath() + "/" + relFilename;
		return HasKey(key);
	}

	public override DateTime GetModifiedTime(string relFilename)
	{
		if (HasKey(MODIFIED_TIME_KEY))
		{
			return DateTime.Parse(GetString(MODIFIED_TIME_KEY), CultureInfo.InvariantCulture);
		}
		return new DateTime(0L);
	}

	public override DateTime GetCreatedTime(string relFilename)
	{
		if (HasKey(CREATED_TIME_KEY))
		{
			return DateTime.Parse(GetString(CREATED_TIME_KEY), CultureInfo.InvariantCulture);
		}
		return new DateTime(0L);
	}

	public override void StreamingCopy(string relSrc, string relDst, Utils.IncludeFilePredicate includePredicate = null)
	{
	}
}
