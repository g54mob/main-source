using System;
using UnityEngine;

namespace Kitchen
{
	public class FloatPreference : Preference<float>
	{
		public FloatPreference(Pref key, float default_value, Action<float> action = null)
			: base(key, default_value, action)
		{
		}

		public override void Save()
		{
			PlayerPrefs.SetFloat(base.Key, base.Value);
		}

		public override void Load()
		{
			if (PlayerPrefs.HasKey(base.Key))
			{
				base.Value = PlayerPrefs.GetFloat(base.Key);
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
			if (!float.TryParse(value, out var result))
			{
				base.Value = 0f;
			}
			else
			{
				base.Value = result;
			}
		}
	}
}
