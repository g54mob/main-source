using System;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class LocalePreference : Preference<Locale>
	{
		public LocalePreference(Pref key, Action<Locale> action = null)
			: base(key, Locale.Default, action)
		{
		}

		public override void Save()
		{
			PlayerPrefs.SetString(base.Key, SaveAsString());
		}

		public override void Load()
		{
			if (PlayerPrefs.HasKey(base.Key))
			{
				string value = PlayerPrefs.GetString(base.Key);
				LoadFromString(value);
			}
			else
			{
				base.Value = Default;
			}
		}

		public override string SaveAsString()
		{
			return base.Value.ToString();
		}

		public override void LoadFromString(string value)
		{
			if (Enum.IsDefined(typeof(Locale), value))
			{
				base.Value = (Locale)Enum.Parse(typeof(Locale), value);
			}
			else
			{
				base.Value = Default;
			}
		}
	}
}
