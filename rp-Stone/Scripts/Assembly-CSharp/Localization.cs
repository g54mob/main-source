using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Localization : MonoBehaviour
{
	public class File
	{
		public string id;

		public string sheet;

		public string displayName;

		public string[] texts;

		public static File FromString(string sjson)
		{
			return new File
			{
				id = SlimJson.Parse(sjson, "id"),
				sheet = SlimJson.Parse(sjson, "sheet"),
				displayName = SlimJson.Parse(sjson, "display_name"),
				texts = SlimJson.ParseArray(sjson, "texts")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("id", id);
			SlimJson.AddProperty("sheet", sheet);
			SlimJson.AddProperty("display_name", displayName);
			SlimJson.AddProperty("texts", texts);
			return SlimJson.EndSerialization();
		}
	}

	public static List<string> VALID_LANGUAGES = new List<string>
	{
		"EN", "PT-BR", "ZH-CN", "ZH-TW", "FR", "DE", "RU", "ES-LA", "ES-EU", "JP",
		"KR", "TK"
	};

	public static string[] LANGUAGE_DISPLAY_NAMES = new string[12]
	{
		"English", "Português", "简体中文", "繁體中文", "Français", "Deutsch", "Русский", "Español (LA)", "Español (EU)", "日本語",
		"한국어", "Türkçe"
	};

	public static bool COUNT_WORDS = false;

	public static bool CREATE_GIBBERISH = false;

	public string[] fileNames;

	private int asyncLoadCount;

	public static Localization singleton { get; private set; }

	private void Awake()
	{
		singleton = this;
		Te.totalWords = 0;
		LoadLanguageFilesAsync("EN", delegate(File file)
		{
			Te.InitEnglish(file);
		});
		if (COUNT_WORDS)
		{
			Utils.Log("TOTAL WORD COUNT: " + Te.totalWords);
		}
	}

	public void SetLanguage(string languageId)
	{
		if (languageId == Te.id)
		{
			Utils.LogWarning("Language is already " + languageId);
			return;
		}
		Utils.Log("Loading language: " + languageId);
		Te.Clear();
		LoadLanguageFilesAsync(languageId, delegate(File file)
		{
			Te.Load(file);
		});
	}

	public bool IsBusy()
	{
		return asyncLoadCount > 0;
	}

	private void LoadLanguageFilesAsync(string languageId, Action<File> fileLoadedCallback)
	{
		for (int i = 0; i < fileNames.Length; i++)
		{
			string assetKey = languageId + "_" + fileNames[i];
			_LoadOneLanguageFile(assetKey, fileLoadedCallback);
		}
	}

	private void _LoadOneLanguageFile(string assetKey, Action<File> fileLoadedCallback, int attemptCount = 0)
	{
		asyncLoadCount++;
		AsyncOperationHandle<TextAsset> loadHandler = Addressables.LoadAssetAsync<TextAsset>(assetKey);
		loadHandler.Completed += delegate
		{
			if (loadHandler.Status == AsyncOperationStatus.Succeeded)
			{
				File obj = File.FromString(loadHandler.Result.text);
				fileLoadedCallback(obj);
			}
			else if (attemptCount < 5)
			{
				attemptCount++;
				_LoadOneLanguageFile(assetKey, fileLoadedCallback, attemptCount);
			}
			else
			{
				GameplayActionMessages.SetMessage("Failed to load texts file " + assetKey, ColorConstants.red);
			}
			asyncLoadCount--;
			Addressables.Release(loadHandler);
		};
	}

	public bool HasLanguage(string languageId)
	{
		return IsValidLanguage(languageId);
	}

	public static bool IsValidLanguage(string languageId)
	{
		return VALID_LANGUAGES.Contains(languageId);
	}

	public static string GetLanguageDisplayName(string languageId)
	{
		int num = VALID_LANGUAGES.IndexOf(languageId);
		if (num >= 0)
		{
			return LANGUAGE_DISPLAY_NAMES[num];
		}
		return null;
	}
}
