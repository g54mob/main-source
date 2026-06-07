using System;
using System.IO;
using I2.Loc;
using UnityEngine;

namespace DV.UI.Manual
{
	public static class ManualDataLoader
	{
		private const string FALLBACK_LANG_CODE = "en";

		private static string MetadataPath => Path.Combine(Application.streamingAssetsPath, "manual", "manual_metadata.json");

		private static string GetJsonPath(string language)
		{
			if (language == "zh-cn")
			{
				language = "zh-hans";
			}
			if (language == "zh-tw")
			{
				language = "zh-hant";
			}
			return Path.Combine(Application.streamingAssetsPath, "manual", language) + ".json";
		}

		public static ManualDisplayData GetLocalizedData()
		{
			if (!File.Exists(MetadataPath))
			{
				Debug.LogError("ManualDataLoader: Manual metadata JSON file not found at '" + MetadataPath + "', manual will not work.");
				return null;
			}
			string text;
			if (string.IsNullOrWhiteSpace(LocalizationManager.CurrentLanguageCode))
			{
				Debug.LogError("ManualDataLoader: No language or invalid language selected. Falling back to English language.");
				text = "en";
			}
			else
			{
				text = LocalizationManager.CurrentLanguageCode.ToLowerInvariant();
			}
			string jsonPath = GetJsonPath(text);
			if (!File.Exists(jsonPath))
			{
				Debug.LogError("ManualDataLoader: Manual JSON file not found at '" + jsonPath + "', falling back to English language.");
				text = "en";
				jsonPath = GetJsonPath(text);
			}
			try
			{
				ManualMetadata metadata = ManualMetadata.FromJson(File.ReadAllText(MetadataPath));
				ManualStrings manualStrings = ManualStrings.FromJson(File.ReadAllText(GetJsonPath(text)));
				ManualStrings fallbackEnglishStrings = manualStrings;
				if (text != "en")
				{
					fallbackEnglishStrings = ManualStrings.FromJson(File.ReadAllText(GetJsonPath("en")));
				}
				ManualDisplayData result = new ManualDisplayData(metadata, manualStrings, fallbackEnglishStrings);
				Debug.Log("ManualDataLoader: Manual data loaded for language '" + text + "'");
				return result;
			}
			catch (Exception exception)
			{
				Debug.LogError("ManualDataLoader: Failed to load manual JSON file at '" + jsonPath + "'");
				Debug.LogException(exception);
				return null;
			}
		}
	}
}
