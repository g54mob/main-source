using System;
using System.Collections.Generic;
using UnityEngine;

namespace Loxodon.Framework.Localizations
{
	[Serializable]
	public class MultilingualSource : LocalizationSource
	{
		[SerializeField]
		private List<string> languages = new List<string>();

		[SerializeField]
		private List<MultilingualEntry> entries = new List<MultilingualEntry>();

		public List<string> Languages => languages;

		public List<MultilingualEntry> Entries => entries;

		public Dictionary<string, object> GetData(string language)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (entries == null || entries.Count <= 0)
			{
				return dictionary;
			}
			int num = languages.IndexOf(language);
			if (num < 0)
			{
				return dictionary;
			}
			foreach (MultilingualEntry entry in entries)
			{
				string key = entry.Key;
				object value = entry.GetValue(num);
				if (!string.IsNullOrEmpty(key))
				{
					dictionary[key] = value;
				}
			}
			return dictionary;
		}

		public bool AddLanguage(string language)
		{
			if (languages.Contains(language))
			{
				return false;
			}
			languages.Add(language);
			int index = languages.Count - 1;
			foreach (MultilingualEntry entry in entries)
			{
				entry.SetValue(index, null);
			}
			return true;
		}

		public bool RemoveLanguage(string language)
		{
			int num = languages.IndexOf(language);
			if (num < 0)
			{
				return false;
			}
			languages.RemoveAt(num);
			foreach (MultilingualEntry entry in entries)
			{
				entry.RemoveValue(num);
			}
			return true;
		}
	}
}
