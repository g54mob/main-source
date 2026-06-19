using System;
using System.Collections.Generic;
using UnityEngine;

namespace Loxodon.Framework.Localizations
{
	[Serializable]
	public class MonolingualSource : LocalizationSource
	{
		[SerializeField]
		private List<MonolingualEntry> entries = new List<MonolingualEntry>();

		public List<MonolingualEntry> Entries => entries;

		public Dictionary<string, object> GetData()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (entries == null || entries.Count <= 0)
			{
				return dictionary;
			}
			foreach (MonolingualEntry entry in entries)
			{
				string key = entry.Key;
				object value = entry.GetValue();
				if (!string.IsNullOrEmpty(key))
				{
					dictionary[key] = value;
				}
			}
			return dictionary;
		}
	}
}
