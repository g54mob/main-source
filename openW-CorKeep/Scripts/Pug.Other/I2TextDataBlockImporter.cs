using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using I2.Loc;
using Unity.Profiling;
using UnityEngine;

public static class I2TextDataBlockImporter
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct SortByFirstEntryComparer : IComparer<string[]>
	{
		public int Compare(string[] x, string[] y)
		{
			return string.Compare(x[0], y[0], StringComparison.InvariantCultureIgnoreCase);
		}
	}

	private const int HEADER_COLUMNS = 3;

	private static readonly ProfilerMarker ImportMarker = new ProfilerMarker("I2TextDataBlockImporter.TryImport");

	public static bool TryImport(LanguageSourceData i2LanguageData, IReadOnlyList<TextDataBlock> dataBlocks, IReadOnlyList<LanguageDataBlock> languages)
	{
		using (ImportMarker.Auto())
		{
			List<LanguageDataBlock> list = new List<LanguageDataBlock>();
			foreach (LanguageDataBlock language in languages)
			{
				if (language.enabled)
				{
					list.Add(language);
				}
			}
			list.Sort((LanguageDataBlock a, LanguageDataBlock b) => a.displayOrder.CompareTo(b.displayOrder));
			LanguageDataBlock languageDataBlock = list[0];
			List<string[]> list2 = new List<string[]>();
			list2.Add(FormatHeader(list));
			foreach (TextDataBlock dataBlock in dataBlocks)
			{
				if (!dataBlock.TryGetLocalized(languageDataBlock, out var value))
				{
					Debug.LogWarning("TextDataBlock " + dataBlock.name + " has no entry for primary language " + languageDataBlock.name);
					continue;
				}
				string text = dataBlock.header;
				if (string.IsNullOrEmpty(text))
				{
					text = "Default";
				}
				string text2 = text + "/" + dataBlock.name;
				if (!string.IsNullOrEmpty(value.title))
				{
					string[] array = SetupRow(text2, list.Count);
					for (int num = 0; num < list.Count; num++)
					{
						if (dataBlock.TryGetLocalized(list[num], out var value2))
						{
							array[3 + num] = value2.title;
						}
					}
					list2.Add(array);
				}
				if (string.IsNullOrEmpty(value.description))
				{
					continue;
				}
				string[] array2 = SetupRow(text2 + "Desc", list.Count);
				for (int num2 = 0; num2 < list.Count; num2++)
				{
					if (dataBlock.TryGetLocalized(list[num2], out var value3))
					{
						array2[3 + num2] = value3.description;
					}
				}
				list2.Add(array2);
			}
			list2.Sort(1, list2.Count - 1, default(SortByFirstEntryComparer));
			i2LanguageData.ClearAllData();
			foreach (LanguageDataBlock item in list)
			{
				i2LanguageData.AddLanguage(item.name, item.ISO6391);
			}
			string text3 = i2LanguageData.Import_CSV("", list2);
			if (!string.IsNullOrEmpty(text3))
			{
				Debug.LogError("I2 TextDataBlock Import Error: " + text3);
				return false;
			}
			return true;
		}
	}

	private static string[] FormatHeader(IReadOnlyList<LanguageDataBlock> languages)
	{
		string[] array = new string[3 + languages.Count];
		array[0] = "Key";
		array[1] = "Type";
		array[2] = "Desc";
		for (int i = 0; i < languages.Count; i++)
		{
			array[3 + i] = languages[i].name;
		}
		return array;
	}

	private static string[] SetupRow(string key, int languageCount)
	{
		string[] array = new string[3 + languageCount];
		array[0] = key;
		array[1] = "Text";
		array[2] = "";
		for (int i = 0; i < languageCount; i++)
		{
			array[3 + i] = string.Empty;
		}
		return array;
	}
}
