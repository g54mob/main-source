using System.Collections.Generic;
using System.IO;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using I2.Loc;
using NSEipix.Base;
using NSMedieval.Extensions;
using UnityEngine;

namespace NSMedieval.Modding
{
	public class LocalizationModManager : MonoSingleton<LocalizationModManager>
	{
		private LanguageSourceData sourceCache;

		private Dictionary<string, LanguageSourceData> moddedSources;

		public void CacheLocalizationMod(string language, string csvPath)
		{
			if (moddedSources.ContainsKey(language))
			{
				return;
			}
			if (sourceCache == null)
			{
				sourceCache = LocalizationManager.Sources[0];
			}
			using FileStream stream = new FileStream(csvPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			using StreamReader streamReader = new StreamReader(stream);
			List<string[]> list = LocalizationReader.ReadCSV(streamReader.ReadToEnd());
			foreach (string[] item in list)
			{
				for (int i = 0; i < item.Length; i++)
				{
					item[i] = item[i].Replace("\\n", "\n").Replace("\r", string.Empty);
				}
			}
			bool isEnabled;
			if (list.Count == 0 || list[0].Length <= 3)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(94, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\LocalizationModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Localization CSV at '");
					messageBuilder.AppendFormatted(csvPath);
					messageBuilder.AppendLiteral("' is malformed: first row must have at least 4 columns. Found ");
					messageBuilder.AppendFormatted((list.Count != 0) ? list[0].Length : 0);
					messageBuilder.AppendLiteral(" column(s).");
				}
				Log.Error(messageBuilder);
				return;
			}
			string text = list[0][3];
			if (string.IsNullOrEmpty(text))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(26, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\LocalizationModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Language ");
					messageBuilder.AppendFormatted(text);
					messageBuilder.AppendLiteral(" does not exist. ");
					messageBuilder.AppendFormatted(list[0].ToList().ToPrettyString());
				}
				Log.Error(messageBuilder);
				return;
			}
			FVLogDebugInterpolationHandler messageBuilder2;
			if (moddedSources.ContainsKey(text))
			{
				messageBuilder2 = new FVLogDebugInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\LocalizationModManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Language ");
					messageBuilder2.AppendFormatted(text);
					messageBuilder2.AppendLiteral(" already exists");
				}
				Log.Debug(messageBuilder2);
				return;
			}
			GameObject obj = new GameObject(text);
			obj.transform.SetParent(base.transform);
			LanguageSource languageSource = obj.AddComponent<LanguageSource>();
			languageSource.SourceData.Import_CSV(null, list);
			languageSource.CaseInsensitiveTerms = true;
			languageSource.SourceData.CaseInsensitiveTerms = true;
			languageSource.SourceData.UpdateDictionary(force: true);
			moddedSources.Add(text, languageSource.SourceData);
			messageBuilder2 = new FVLogDebugInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\LocalizationModManager.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Added ");
				messageBuilder2.AppendFormatted(text);
				messageBuilder2.AppendLiteral(" to modded sources");
			}
			Log.Debug(messageBuilder2);
		}

		public bool RemoveLocalizationMod(string language)
		{
			if (!moddedSources.TryGetValue(language, out var value))
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\LocalizationModManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Language ");
					messageBuilder.AppendFormatted(language);
					messageBuilder.AppendLiteral(" does not exist");
				}
				Log.Debug(messageBuilder);
				return false;
			}
			Object.Destroy(value.ownerObject);
			moddedSources.Remove(language);
			return true;
		}

		public bool LoadModSource(string language)
		{
			if (!moddedSources.TryGetValue(language, out var value))
			{
				return false;
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(13, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\LocalizationModManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Switching to ");
				messageBuilder.AppendFormatted(language);
			}
			Log.Debug(messageBuilder);
			LocalizationManager.Sources[0] = value;
			return true;
		}

		public bool IsModdedLanguage(string language)
		{
			return moddedSources.ContainsKey(language);
		}

		public void LoadDefaultSourceCache()
		{
			if (sourceCache != null)
			{
				LocalizationManager.Sources[0] = sourceCache;
			}
		}

		public void Initialize()
		{
			moddedSources = new Dictionary<string, LanguageSourceData>();
		}
	}
}
