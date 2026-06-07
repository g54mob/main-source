using UnityEngine;

namespace SettingScripts
{
	public class ColorUserSetting : ColorSetting
	{
		public string key;

		public override Color val
		{
			get
			{
				float r = PlayerPrefs.GetFloat(key + "R", DefaultValue.r);
				float g = PlayerPrefs.GetFloat(key + "G", DefaultValue.g);
				float b = PlayerPrefs.GetFloat(key + "B", DefaultValue.b);
				float a = PlayerPrefs.GetFloat(key + "A", DefaultValue.a);
				return new Color(r, g, b, a);
			}
			set
			{
				PlayerPrefs.SetFloat(key + "R", value.r);
				PlayerPrefs.SetFloat(key + "G", value.g);
				PlayerPrefs.SetFloat(key + "B", value.b);
				PlayerPrefs.SetFloat(key + "A", value.a);
			}
		}
	}
}
