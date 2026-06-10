using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using I2.Loc;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval.Modding
{
	public static class DefaultLocToCsv
	{
		private static List<LanguageData> languages;

		private static List<TermData> terms;

		public const string DefaultLocModName = "English Localization Mod";

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			languages = null;
			terms = null;
		}

		public static void Export()
		{
			languages = LocalizationManager.Sources[0].mLanguages;
			terms = LocalizationManager.Sources[0].mTerms;
			string cSV = GetCSV();
			string path = "English.csv";
			ModdingUtils.CreateDefaultLocalizationMod("English Localization Mod");
			string path2 = Path.Combine(ModdingUtils.GetLocalizationModPath("English Localization Mod"), path);
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(14, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\DefaultLocToCsv.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Exporting ");
				messageBuilder.AppendFormatted("English Localization Mod");
				messageBuilder.AppendLiteral(" to ");
				messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(path2));
			}
			Log.Debug(messageBuilder);
			FileUtils.SafeWriteAllText(path2, cSV);
		}

		private static string GetCSV(char separator = ',', bool forModding = true)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int nLanguages = (forModding ? 1 : languages.Count);
			stringBuilder.AppendFormat("Key{0}Type{0}Desc", separator);
			foreach (LanguageData language in languages)
			{
				if (!forModding || !(language.Code != "en"))
				{
					stringBuilder.Append(separator);
					AppendString(stringBuilder, GoogleLanguages.GetCodedLanguage(language.Name, language.Code), separator);
				}
			}
			stringBuilder.Append("\n");
			terms.Sort((TermData a, TermData b) => string.CompareOrdinal(a.Term, b.Term));
			foreach (TermData term in terms)
			{
				if (term.Languages.Length != 0 && term.Languages[0] != null && term.Languages[0].Length != 0)
				{
					AppendTerm(stringBuilder, nLanguages, term, separator);
				}
			}
			return stringBuilder.ToString();
		}

		private static void AppendTerm(StringBuilder builder, int nLanguages, TermData termData, char separator)
		{
			AppendString(builder, termData.Term, separator);
			builder.Append(separator);
			builder.Append(termData.TermType.ToString());
			builder.Append(separator);
			AppendString(builder, termData.Description, separator);
			for (int i = 0; i < Math.Min(nLanguages, termData.Languages.Length); i++)
			{
				builder.Append(separator);
				AppendTranslation(builder, termData.Languages[i], separator);
			}
			builder.Append("\n");
		}

		private static void AppendString(StringBuilder builder, string text, char separator)
		{
			if (!string.IsNullOrEmpty(text))
			{
				text = text.Replace("\n", "\\n");
				if (text.IndexOfAny((separator + "\n\"").ToCharArray()) >= 0)
				{
					text = text.Replace("\"", "\"\"");
					builder.AppendFormat("\"{0}\"", text);
				}
				else
				{
					builder.Append(text);
				}
			}
		}

		private static void AppendTranslation(StringBuilder builder, string text, char separator)
		{
			if (!string.IsNullOrEmpty(text))
			{
				text = text.Replace("\n", "\\n");
				if (text.IndexOfAny((separator + "\n\"").ToCharArray()) >= 0)
				{
					text = text.Replace("\"", "\"\"");
				}
				builder.AppendFormat("\"{0}\"", text);
			}
		}
	}
}
