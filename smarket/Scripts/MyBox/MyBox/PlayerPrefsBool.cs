using MyBox.Internal;

namespace MyBox
{
	public class PlayerPrefsBool : PlayerPrefsType
	{
		public bool DefaultValue;

		public bool Value
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static PlayerPrefsBool WithKey(string key, bool defaultValue = false)
		{
			return null;
		}

		public PlayerPrefsBool(string key, bool defaultValue = false)
		{
		}
	}
}
