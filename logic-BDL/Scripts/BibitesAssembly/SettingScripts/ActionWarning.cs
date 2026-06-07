using UnityEngine;

namespace SettingScripts
{
	public class ActionWarning : BoolUserSetting
	{
		public string title;

		public string warningText;

		public override bool val
		{
			get
			{
				return PlayerPrefs.GetInt(key, 0) == 1;
			}
			set
			{
				OnValueChangeWithPrecedent.Invoke(value, val);
				OnValueChange.Invoke(value);
				OnChange.Invoke();
				PlayerPrefs.SetInt(key, value ? 1 : 0);
			}
		}

		public bool doNotShowAgain
		{
			get
			{
				return val;
			}
			set
			{
				val = value;
			}
		}
	}
}
