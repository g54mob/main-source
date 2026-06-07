using System;
using UnityEngine;

namespace SettingScripts
{
	public class ChoiceUserSetting<TEnum> : EnumSetting<TEnum> where TEnum : struct, Enum, IConvertible
	{
		public string key;

		public override TEnum val
		{
			get
			{
				return (TEnum)(object)PlayerPrefs.GetInt(key, (int)(object)DefaultValue);
			}
			set
			{
				OnValueChangeWithPrecedent.Invoke(value, val);
				PlayerPrefs.SetInt(key, (int)(object)value);
			}
		}

		public virtual void OnUpdate()
		{
		}
	}
}
