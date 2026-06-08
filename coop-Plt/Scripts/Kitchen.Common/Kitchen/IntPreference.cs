using System;
using UnityEngine;

namespace Kitchen
{
	public class IntPreference : Preference<int>
	{
		public IntPreference(Pref key, int default_value, Action<int> action = null)
			: base(key, default_value, action)
		{
		}

		public override void Save()
		{
			PlayerPrefs.SetInt(base.Key, base.Value);
		}

		public override void Load()
		{
			if (PlayerPrefs.HasKey(base.Key))
			{
				base.Value = PlayerPrefs.GetInt(base.Key);
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
			if (!int.TryParse(value, out var result))
			{
				base.Value = 0;
			}
			else
			{
				base.Value = result;
			}
		}
	}
}
