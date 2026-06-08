using System;
using UnityEngine;

namespace Kitchen
{
	public class BoolPreference : Preference<bool>
	{
		public BoolPreference(Pref key, bool default_value, Action<bool> action = null)
			: base(key, default_value, action)
		{
		}

		public override void Save()
		{
			PlayerPrefs.SetInt(base.Key, base.Value ? 1 : 0);
		}

		public override void Load()
		{
			if (PlayerPrefs.HasKey(base.Key))
			{
				base.Value = (float)PlayerPrefs.GetInt(base.Key) > 0.5f;
			}
			else
			{
				base.Value = Default;
			}
		}

		public override string SaveAsString()
		{
			if (!base.Value)
			{
				return "0";
			}
			return "1";
		}

		public override void LoadFromString(string value)
		{
			if (!int.TryParse(value, out var result))
			{
				base.Value = false;
			}
			else
			{
				base.Value = result != 0;
			}
		}
	}
}
