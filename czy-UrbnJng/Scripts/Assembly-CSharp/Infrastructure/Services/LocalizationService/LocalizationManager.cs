using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Assets.SimpleLocalization.Scripts;
using UnityEngine;

namespace Infrastructure.Services.LocalizationService
{
	public static class LocalizationManager
	{
		public static Dictionary<string, Dictionary<string, string>> Dictionary;

		private static string _language;

		public static string Language
		{
			get
			{
				return _language;
			}
			set
			{
				_language = value;
				LocalizationManager.OnLocalizationChanged();
			}
		}

		public static event Action OnLocalizationChanged;

		public static void AutoLanguage()
		{
			Language = "English";
		}

		public static void Read()
		{
			if (Dictionary.Count > 0)
			{
				return;
			}
			List<string> list = new List<string>();
			foreach (Sheet sheet in LocalizationSettings.Instance.Sheets)
			{
				List<string> lines = GetLines(sheet.TextAsset.text);
				List<string> list2 = (from i in lines[0].Split(',')
					select i.Trim()).ToList();
				if (list2.Count != list2.Distinct().Count())
				{
					Debug.LogError("Duplicated languages found in `" + sheet.Name + "`. This sheet is not loaded.");
					continue;
				}
				for (int num = 1; num < list2.Count; num++)
				{
					if (!Dictionary.ContainsKey(list2[num]))
					{
						Dictionary.Add(list2[num], new Dictionary<string, string>());
					}
				}
				for (int num2 = 1; num2 < lines.Count; num2++)
				{
					List<string> columns = GetColumns(lines[num2]);
					string text = columns[0];
					if (text == "")
					{
						continue;
					}
					if (list.Contains(text))
					{
						Debug.LogError("Duplicated key `" + text + "` found in `" + sheet.Name + "`. This key is not loaded.");
						continue;
					}
					list.Add(text);
					for (int num3 = 1; num3 < list2.Count; num3++)
					{
						if (Dictionary[list2[num3]].ContainsKey(text))
						{
							Debug.LogError("Duplicated key `" + text + "` in `" + sheet.Name + "`.");
						}
						else
						{
							Dictionary[list2[num3]].Add(text, columns[num3]);
						}
					}
				}
			}
			AutoLanguage();
		}

		public static bool HasKey(string localizationKey)
		{
			if (Dictionary.ContainsKey(Language))
			{
				return Dictionary[Language].ContainsKey(localizationKey);
			}
			return false;
		}

		public static string Localize(string localizationKey)
		{
			if (Dictionary.Count == 0)
			{
				Read();
			}
			if (!Dictionary.ContainsKey(Language))
			{
				throw new KeyNotFoundException("Language not found: " + Language);
			}
			if (!Dictionary[Language].ContainsKey(localizationKey) || Dictionary[Language][localizationKey] == "")
			{
				Debug.LogWarning("Translation not found: " + localizationKey + " (" + Language + ").");
				if (!Dictionary["English"].ContainsKey(localizationKey))
				{
					return localizationKey;
				}
				return Dictionary["English"][localizationKey];
			}
			return Dictionary[Language][localizationKey];
		}

		public static string Localize(string localizationKey, params object[] args)
		{
			return string.Format(Localize(localizationKey), args);
		}

		public static List<string> GetLines(string text)
		{
			text = text.Replace("\r\n", "\n").Replace("\"\"", "[_quote_]");
			foreach (Match item in Regex.Matches(text, "\"[\\s\\S]+?\""))
			{
				text = text.Replace(item.Value, item.Value.Replace("\"", null).Replace(",", "[_comma_]").Replace("\n", "[_newline_]"));
			}
			text = text.Replace("。", "。 ").Replace("、", "、 ").Replace("：", "： ")
				.Replace("！", "！ ")
				.Replace("（", " （")
				.Replace("）", "） ")
				.Trim();
			return (from i in text.Split('\n')
				where i != ""
				select i).ToList();
		}

		public static List<string> GetColumns(string line)
		{
			return (from j in line.Split(',')
				select j.Trim() into j
				select j.Replace("[_quote_]", "\"").Replace("[_comma_]", ",").Replace("[_newline_]", "\n")).ToList();
		}

		static LocalizationManager()
		{
			LocalizationManager.OnLocalizationChanged = delegate
			{
			};
			Dictionary = new Dictionary<string, Dictionary<string, string>>();
			_language = "English";
		}
	}
}
