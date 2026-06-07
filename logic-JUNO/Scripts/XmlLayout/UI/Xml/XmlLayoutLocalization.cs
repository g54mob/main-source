using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Xml
{
	[CreateAssetMenu(fileName = "New Localization File", menuName = "XmlLayout/Localization/New Localization File")]
	public class XmlLayoutLocalization : ScriptableObject
	{
		[Serializable]
		public class LocalizationDictionary : SerializableDictionary<string, string>
		{
			public LocalizationDictionary()
			{
				_Comparer = StringComparer.OrdinalIgnoreCase;
			}
		}

		[SerializeField]
		public LocalizationDictionary strings = new LocalizationDictionary();

		public string GetString(string key)
		{
			if (!strings.ContainsKey(key))
			{
				return "";
			}
			return strings[key];
		}

		public void SetString(string key, string value)
		{
			if (!strings.ContainsKey(key))
			{
				strings.Add(key, value);
			}
			else
			{
				strings[key] = value;
			}
		}

		public void SetStrings(IDictionary<string, string> newStrings, bool clearExisting = true)
		{
			if (clearExisting)
			{
				strings.Clear();
			}
			foreach (KeyValuePair<string, string> newString in newStrings)
			{
				SetString(newString.Key, newString.Value);
			}
		}
	}
}
