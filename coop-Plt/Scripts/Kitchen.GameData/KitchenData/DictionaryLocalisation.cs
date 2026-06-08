using System;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Dictionary Localisation", menuName = "Kitchen/Localisation/Dictionary")]
	public class DictionaryLocalisation : LocalisationSet<DictionaryInfo>
	{
		[OdinSerialize]
		public LocalisationObject<DictionaryInfo> Info;

		[NonSerialized]
		[HideInInspector]
		public Dictionary<string, string> Text;

		public override LocalisationObject<DictionaryInfo> LocalisationInfo => Info;

		public virtual string this[string i]
		{
			get
			{
				if (Text.TryGetValue(i, out var value))
				{
					return value;
				}
				return i;
			}
		}

		public string this[string key, params object[] args] => string.Format(this[key], args);

		protected override void InitialiseDefaults()
		{
		}

		public override bool Localise(Locale locale, StringSubstitutor subs)
		{
			if (Info == null)
			{
				return false;
			}
			DictionaryInfo dictionaryInfo = Info.Get(locale);
			if (dictionaryInfo == null)
			{
				return false;
			}
			Text = new Dictionary<string, string>();
			foreach (KeyValuePair<string, string> item in dictionaryInfo.Text)
			{
				Text.Add(item.Key, subs.Parse(item.Value));
			}
			return true;
		}
	}
}
