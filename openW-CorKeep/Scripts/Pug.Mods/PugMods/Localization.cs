using System;
using System.IO;
using System.Text;
using I2.Loc;
using UnityEngine;

namespace PugMods
{
	public static class Localization
	{
		public static readonly string CustomCsvFilePath = Application.dataPath + "/../localization/Localization.csv";

		private static char CsvSeparator = '\t';

		public static void ImportAndUpdateCustomCsv(LanguageSourceData languageSource, string csvFilePath)
		{
			if (File.Exists(csvFilePath))
			{
				Debug.Log("Loading localization from " + csvFilePath);
				try
				{
					languageSource.Import_CSV(null, File.ReadAllText(csvFilePath), eSpreadsheetUpdateMode.Replace, CsvSeparator);
				}
				catch (Exception exception)
				{
					Debug.LogError("Failed to update " + csvFilePath);
					Debug.LogException(exception);
				}
			}
		}

		public static void ImportAndUpdateExtraCustomCsv(LanguageSourceData languageSource, string csvFilePath)
		{
			if (File.Exists(csvFilePath))
			{
				Debug.Log("Loading extra localization from " + csvFilePath);
				try
				{
					languageSource.Import_CSV(null, File.ReadAllText(csvFilePath), eSpreadsheetUpdateMode.Merge, CsvSeparator);
				}
				catch (Exception exception)
				{
					Debug.LogError("Failed to update " + csvFilePath);
					Debug.LogException(exception);
				}
			}
		}

		public static bool PostInit(LanguageSourceData customLanguageSource, LanguageSourceData defaultLanguageSource)
		{
			if (customLanguageSource.mTerms.Count == 0)
			{
				return false;
			}
			int val = 0;
			foreach (LanguageData mLanguage in customLanguageSource.mLanguages)
			{
				if (mLanguage.Code.Length >= 2 && mLanguage.Code[0] == 'c' && int.TryParse(mLanguage.Code.Substring(1), out var result))
				{
					val = Math.Max(val, result + 1);
				}
			}
			foreach (LanguageData mLanguage2 in customLanguageSource.mLanguages)
			{
				if (string.IsNullOrEmpty(mLanguage2.Code))
				{
					LanguageData languageData = defaultLanguageSource.GetLanguageData(mLanguage2.Name);
					if (languageData != null && !string.IsNullOrEmpty(languageData.Code))
					{
						mLanguage2.Code = languageData.Code;
					}
					if (string.IsNullOrEmpty(mLanguage2.Code))
					{
						mLanguage2.Code = $"c{val++}";
					}
				}
			}
			foreach (TermData mTerm in defaultLanguageSource.mTerms)
			{
				if (customLanguageSource.ContainsTerm(mTerm.Term))
				{
					continue;
				}
				TermData termData = customLanguageSource.AddTerm(mTerm.Term, mTerm.TermType);
				if (termData == null)
				{
					continue;
				}
				termData.Description = mTerm.Description + " [new]";
				for (int i = 0; i < customLanguageSource.mLanguages.Count; i++)
				{
					for (int j = 0; j < defaultLanguageSource.mLanguages.Count; j++)
					{
						if (!string.IsNullOrEmpty(mTerm.Languages[j]) && customLanguageSource.mLanguages[i].Name.Equals(defaultLanguageSource.mLanguages[j].Name))
						{
							termData.SetTranslation(i, mTerm.GetTranslation(j));
							break;
						}
					}
				}
			}
			return true;
		}

		public static void CreateCsv(LanguageSourceData languageSource, string path)
		{
			FileInfo fileInfo = new FileInfo(path);
			DirectoryInfo directory = fileInfo.Directory;
			if (directory != null && !directory.Exists)
			{
				fileInfo.Directory.Create();
			}
			using FileStream fileStream = File.Open(path, FileMode.OpenOrCreate);
			fileStream.SetLength(0L);
			string s = languageSource.Export_CSV(null, CsvSeparator, specializationsAsRows: false, skipDisabled: true);
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			fileStream.Write(bytes, 0, bytes.Length);
		}
	}
}
