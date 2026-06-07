using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using DV.Utils;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace DV.Localization
{
	public class LocalizationCSVFetcher : SingletonBehaviour<LocalizationCSVFetcher>
	{
		public static string JSON_FILENAME => "sources.json";

		public new static string AllowAutoCreate()
		{
			return "[LocalizationCSVFetcher]";
		}

		public static void DownloadLocalizationCSVs()
		{
			if (!Application.isPlaying)
			{
				Debug.LogWarning("[LocalizationCSVFetcher] Must be called from play mode");
				return;
			}
			if (LocalizationLoader.LocalizationDirs.Count == 0)
			{
				Debug.LogWarning("[LocalizationCSVFetcher] Nothing to download, LocalizationLoader.LocalizationDirs is empty");
				return;
			}
			foreach (string localizationDir in LocalizationLoader.LocalizationDirs)
			{
				ReadSourceURLsFromDirAndDownloadCSVs(localizationDir);
			}
		}

		public static void ReadSourceURLsFromDirAndDownloadCSVs(string dir)
		{
			if (!Application.isPlaying)
			{
				Debug.LogWarning("[LocalizationCSVFetcher] Must be called from play mode");
				return;
			}
			if (!Directory.Exists(dir))
			{
				Debug.LogWarning("[LocalizationCSVFetcher] Dir '" + dir + "' doesn't exist");
				return;
			}
			string path = Path.Combine(dir, JSON_FILENAME);
			if (!File.Exists(path))
			{
				Debug.Log("[LocalizationCSVFetcher] Dir '" + dir + "' doesn't contain '" + JSON_FILENAME + "'");
				return;
			}
			Dictionary<string, string> dictionary;
			try
			{
				dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(path));
			}
			catch (Exception exception)
			{
				Debug.LogError("[LocalizationCSVFetcher] couldn't parse sources.csv:");
				Debug.LogException(exception);
				return;
			}
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				string saveToPath = Path.Combine(dir, item.Key);
				string value = item.Value;
				SingletonBehaviour<LocalizationCSVFetcher>.Instance.StartCoroutine(DownloadCSV(value, saveToPath));
			}
		}

		public static IEnumerator DownloadCSV(string url, string saveToPath)
		{
			Debug.Log("[LocalizationCSVFetcher] Downloading '" + saveToPath + "' from '" + url + "'");
			UnityWebRequest uwr = new UnityWebRequest(url, "GET")
			{
				downloadHandler = new DownloadHandlerFile(saveToPath)
			};
			yield return uwr.SendWebRequest();
			if (uwr.isNetworkError || uwr.isHttpError)
			{
				Debug.LogError(uwr.error);
				Debug.Log("[LocalizationCSVFetcher] Couldn't download '" + saveToPath + "'");
			}
			else
			{
				Debug.Log("[LocalizationCSVFetcher] Successfully downloaded '" + saveToPath + "'");
			}
		}
	}
}
