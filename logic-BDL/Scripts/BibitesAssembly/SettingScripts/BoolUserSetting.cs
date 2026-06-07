using UnityEngine;

namespace SettingScripts
{
	public class BoolUserSetting : UserSetting<bool>
	{
		public override bool val
		{
			get
			{
				return PlayerPrefs.GetInt(key, DefaultValue ? 1 : 0) == 1;
			}
			set
			{
				PlayerPrefs.SetInt(key, value ? 1 : 0);
			}
		}
	}
}
