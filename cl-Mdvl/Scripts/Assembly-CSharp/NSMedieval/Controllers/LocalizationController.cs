using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using I2.Loc;
using NSEipix.Base;
using NSMedieval.Enums;
using NSMedieval.Modding;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.WorldMap;

namespace NSMedieval.Controllers
{
	public class LocalizationController : MonoSingleton<LocalizationController>
	{
		public const string DefaultLanguage = "English";

		private readonly Dictionary<TemperatureUnitsType, string> temperatureUnitsCache = new Dictionary<TemperatureUnitsType, string>();

		private FontFallbackSwitcher fallbackSwitcher;

		private LocalizationController()
		{
		}

		public void Initialize()
		{
			fallbackSwitcher = new FontFallbackSwitcher();
			ChangeLanguage(MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.LanguageName);
		}

		public string GetText(string key)
		{
			string translation = LocalizationManager.GetTranslation(key);
			if (translation != null)
			{
				return TextFormatting.ParsedTerm(translation);
			}
			return key;
		}

		public string GetText(string key, CharacterInfoBase characterInfo)
		{
			return TextFormatting.FormatText(GetText(key), characterInfo);
		}

		public string GetText(string key, BodyType bodyType)
		{
			if (bodyType == BodyType.None)
			{
				bodyType = BodyType.Male;
			}
			return TextFormatting.FormatText(GetText(key), bodyType);
		}

		public string GetText(string key, WorldMapPlace place)
		{
			return TextFormatting.FormatText(GetText(key), place);
		}

		public string GetFormattedText(string key)
		{
			return TextFormatting.FormatText(GetText(key));
		}

		public string GetText(string key, HumanoidInstance humanoid)
		{
			string text = key;
			string text2 = ((humanoid == null) ? TextFormatting.FormatRandomWorkerText(GetText(text)) : TextFormatting.FormatText(GetText(text), humanoid));
			if (text2 == null)
			{
				text = $"{key}_{humanoid.Info.BodyType}";
			}
			if (text2 != null && text2.Equals(text))
			{
				text2 = ((humanoid == null) ? TextFormatting.FormatRandomWorkerText(GetText(key)) : TextFormatting.FormatText(GetText(key), humanoid));
			}
			if (humanoid != null)
			{
				return string.Format(text2 ?? string.Empty, humanoid.Info.FirstName, humanoid.Info.LastName, humanoid.Info.OriginTown);
			}
			return text2;
		}

		public string GetText(string key, bool formatVariables)
		{
			if (formatVariables)
			{
				return TextFormatting.FormatTextVariables(GetText(key));
			}
			return GetText(key);
		}

		public string Append(List<string> list)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string item in list)
			{
				stringBuilder.Append(GetText(item));
				stringBuilder.Append(" ");
			}
			return stringBuilder.ToString().Trim();
		}

		public string JoinLocalized(List<string> list, char delimiter = ',')
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < list.Count; i++)
			{
				stringBuilder.Append(GetText(list[i]));
				if (i < list.Count - 1)
				{
					stringBuilder.Append(delimiter);
				}
			}
			return stringBuilder.ToString();
		}

		public int GetKeyGroupCount(string keyConstructor)
		{
			int num = 1;
			using List<LanguageSourceData>.Enumerator enumerator = LocalizationManager.Sources.GetEnumerator();
			if (enumerator.MoveNext())
			{
				LanguageSourceData current = enumerator.Current;
				while (true)
				{
					string key = $"{keyConstructor}{num}";
					if (!current.mDictionary.TryGetValue(key, out var _))
					{
						break;
					}
					num++;
				}
				return num;
			}
			return num;
		}

		public Language GetCurrentLanguageEnum()
		{
			if (!Enum.TryParse<Language>(GetCurrentLanguageName(), out var result))
			{
				return Language.English;
			}
			return result;
		}

		public string GetCurrentLanguageName()
		{
			return MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.LanguageName;
		}

		public void ChangeLanguage(string language)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(26, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\LocalizationController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Language ");
				messageBuilder.AppendFormatted(language);
				messageBuilder.AppendLiteral(" change requested");
			}
			Log.Info(messageBuilder);
			if (IsOfficialLanguage(language))
			{
				MonoSingleton<LocalizationModManager>.Instance.LoadDefaultSourceCache();
				LocalizationManager.CurrentLanguage = language;
				OnLanguageChanged(language);
				return;
			}
			if (MonoSingleton<LocalizationModManager>.Instance.IsModdedLanguage(language))
			{
				MonoSingleton<LocalizationModManager>.Instance.LoadModSource(language);
				LocalizationManager.CurrentLanguage = language;
				OnLanguageChanged(language);
				return;
			}
			FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(45, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\LocalizationController.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Language ");
				messageBuilder2.AppendFormatted(language);
				messageBuilder2.AppendLiteral(" not found. Loading default language");
			}
			Log.Warning(messageBuilder2);
			LocalizationManager.CurrentLanguage = "English";
			OnLanguageChanged("English");
			MonoSingleton<GlobalSaveController>.Instance.Serialize();
		}

		public string GetTemperatureUnitsSymbol(TemperatureUnitsType unitsType)
		{
			if (temperatureUnitsCache.TryGetValue(unitsType, out var value))
			{
				return value;
			}
			string text = MonoSingleton<LocalizationController>.Instance.GetText("general_symbol_" + unitsType);
			temperatureUnitsCache.Add(unitsType, text);
			return temperatureUnitsCache[unitsType];
		}

		private void UpdateCulture()
		{
			string languageCode = LocalizationManager.GetLanguageCode(GetCurrentLanguageName());
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\LocalizationController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Culture changed to: ");
				messageBuilder.AppendFormatted(languageCode);
			}
			Log.Debug(messageBuilder);
			CultureInfo cultureInfo = new CultureInfo(languageCode);
			Thread.CurrentThread.CurrentCulture = cultureInfo;
			Thread.CurrentThread.CurrentUICulture = cultureInfo;
		}

		private void OnLanguageChanged(string language)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(37, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\LocalizationController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Language ");
				messageBuilder.AppendFormatted(language);
				messageBuilder.AppendLiteral(" changed. Current language: ");
				messageBuilder.AppendFormatted(LocalizationManager.CurrentLanguage);
			}
			Log.Info(messageBuilder);
			temperatureUnitsCache.Clear();
			MonoSingleton<OptionsController>.Instance.SaveCurrentLanguage(language);
			UpdateCulture();
			fallbackSwitcher.OnLanguageChange(language);
		}

		private bool IsOfficialLanguage(string languageName)
		{
			Language result;
			return Enum.TryParse<Language>(languageName, out result);
		}
	}
}
