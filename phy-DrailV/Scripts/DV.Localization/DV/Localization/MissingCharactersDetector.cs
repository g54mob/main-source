using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;

namespace DV.Localization
{
	public class MissingCharactersDetector
	{
		public class MissingCharsReport
		{
			public int numSourcesChecked;

			public int numLocalizationKeysChecked;

			public readonly List<LangMissingCharsInfo> langInfos = new List<LangMissingCharsInfo>();
		}

		public class LangMissingCharsInfo
		{
			public string lang;

			public HashSet<int> chars = new HashSet<int>();

			public readonly List<(int unicode, int stringIndex, string text, TMP_FontAsset fontAsset, TMP_Text textComponent)> debug = new List<(int, int, string, TMP_FontAsset, TMP_Text)>();

			public readonly List<(int start, int end)> unicodeRanges = new List<(int, int)>();

			public void UpdateUnicodeRanges()
			{
				unicodeRanges.Clear();
				unicodeRanges.AddRange(ToRanges(chars));
			}

			public string GetFormattedRanges()
			{
				return GetFormattedRanges(unicodeRanges);
			}

			public static List<(int start, int end)> ToRanges(HashSet<int> numbers)
			{
				List<(int, int)> list = new List<(int, int)>();
				if (numbers.Count == 0)
				{
					return list;
				}
				List<int> list2 = new List<int>(numbers);
				list2.Sort();
				int num = list2[0];
				int num2 = num;
				for (int i = 1; i < list2.Count; i++)
				{
					int num3 = list2[i];
					if (num3 == num2 + 1)
					{
						num2 = num3;
						continue;
					}
					list.Add((num, num2));
					num = num3;
					num2 = num3;
				}
				list.Add((num, num2));
				return list;
			}

			public static string GetFormattedRanges(List<(int start, int end)> ranges)
			{
				string text = "";
				foreach (var (num, num2) in ranges)
				{
					if (text.Length > 0)
					{
						text += ",";
					}
					text = ((num != num2) ? (text + $"{num:X}-{num2:X}") : (text + $"{num:X}"));
				}
				return text;
			}
		}

		public static MissingCharsReport Check(TMP_Text tmPro)
		{
			MissingCharsReport report = new MissingCharsReport();
			TMP_Text.OnMissingCharacter += OnMissingCharacter;
			Debug.Log("[MissingCharactersDetector] Updating localization sources");
			LocalizationManager.UpdateSources();
			report.numSourcesChecked = LocalizationManager.Sources.Count;
			List<string> list = new List<string>();
			foreach (LanguageSourceData source in LocalizationManager.Sources)
			{
				foreach (KeyValuePair<string, TermData> item2 in source.mDictionary)
				{
					string key = item2.Key;
					_ = item2.Value;
					string item = key;
					list.Add(item);
				}
			}
			report.numLocalizationKeysChecked = list.Count;
			foreach (string allLanguage in LocalizationManager.GetAllLanguages())
			{
				LangMissingCharsInfo langMissingCharsInfo = new LangMissingCharsInfo
				{
					lang = allLanguage
				};
				report.langInfos.Add(langMissingCharsInfo);
				foreach (string item3 in list)
				{
					string translation = LocalizationManager.GetTranslation(item3, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters: false, null, allLanguage);
					tmPro.text = translation;
					tmPro.ForceMeshUpdate();
				}
				langMissingCharsInfo.UpdateUnicodeRanges();
			}
			TMP_Text.OnMissingCharacter -= OnMissingCharacter;
			return report;
			void OnMissingCharacter(int unicode, int stringIndex, string text, TMP_FontAsset fontAsset, TMP_Text textComponent)
			{
				LangMissingCharsInfo langMissingCharsInfo2 = report.langInfos[report.langInfos.Count - 1];
				if (!langMissingCharsInfo2.chars.Contains(unicode))
				{
					langMissingCharsInfo2.chars.Add(unicode);
					langMissingCharsInfo2.debug.Add((unicode, stringIndex, text, fontAsset, textComponent));
				}
			}
		}
	}
}
