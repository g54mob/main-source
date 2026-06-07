using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using I2.Loc;
using UnityEngine;

namespace DV.Localization
{
	public class LocalizationLoader : MonoBehaviour
	{
		private static List<string> _localizationDirs;

		private static LanguageSourceAsset _langSourceAsset;

		public static int numCSVsLoaded;

		public static string BuiltInLocalizationDirPath
		{
			get
			{
				if (!Application.isEditor)
				{
					return Path.GetFullPath(Path.Combine(Application.dataPath, "..", "localization"));
				}
				return Path.GetFullPath(Path.Combine(Application.dataPath, "localization"));
			}
		}

		public static List<string> LocalizationDirs
		{
			get
			{
				if (_localizationDirs == null)
				{
					_localizationDirs = new List<string>();
					_localizationDirs.Add(BuiltInLocalizationDirPath);
					Debug.Log(_localizationDirs[0]);
				}
				return _localizationDirs;
			}
		}

		public static LanguageSourceAsset LangSourceAsset
		{
			get
			{
				if (_langSourceAsset == null)
				{
					Debug.Log("[LocalizationLoader] Loading default LanguageSourceAsset from Resources");
					_langSourceAsset = Resources.Load<LanguageSourceAsset>(LocalizationManager.GlobalSources[0]);
				}
				if (_langSourceAsset == null)
				{
					Debug.LogWarning("[LocalizationLoader] Couldn't load default LanguageSourceAsset from Resources");
				}
				return _langSourceAsset;
			}
		}

		private IEnumerator Start()
		{
			yield return null;
			yield return null;
			numCSVsLoaded = 0;
			foreach (string localizationDir in LocalizationDirs)
			{
				IngestLocalization(localizationDir);
			}
		}

		public static void IngestLocalization(string path)
		{
			Debug.Log("[LocalizationLoader] Ingesting localization from " + path);
			if (!Directory.Exists(path))
			{
				Debug.Log("[LocalizationLoader] didn't find dir '" + path + "', will not ingest new localizations");
				return;
			}
			string[] files = Directory.GetFiles(path, "*.csv", SearchOption.TopDirectoryOnly);
			if (files.Length == 0)
			{
				Debug.Log("[LocalizationLoader] didn't find any .CSV files in '" + path + "', will not ingest new localizations");
				return;
			}
			LanguageSourceAsset langSourceAsset = LangSourceAsset;
			foreach (string item in files.Select((string p) => p.Replace("/", "\\")).ToList())
			{
				Debug.Log("[LocalizationLoader] Loading '" + item + "'");
				UpdateI2LangSourceAsset(langSourceAsset, item, eSpreadsheetUpdateMode.Merge);
				numCSVsLoaded++;
			}
		}

		public static void UpdateI2LangSourceAsset(LanguageSourceAsset langAsset, string csvPath, eSpreadsheetUpdateMode updateMode)
		{
			string cSVstring = LocalizationReader.ReadCSVfile(csvPath, Encoding.UTF8);
			string text = langAsset.SourceData.Import_CSV(string.Empty, cSVstring, updateMode);
			if (!string.IsNullOrEmpty(text))
			{
				Debug.LogError(text);
			}
		}
	}
}
