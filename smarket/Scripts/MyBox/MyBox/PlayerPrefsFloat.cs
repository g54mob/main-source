using System;
using MyBox.Internal;

namespace MyBox
{
	[Serializable]
	public class PlayerPrefsFloat : PlayerPrefsType
	{
		public float DefaultValue;

		public float Value
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static PlayerPrefsFloat WithKey(string key, float defaultValue = 0f)
		{
			return null;
		}

		public PlayerPrefsFloat(string key, float defaultValue = 0f)
		{
		}
	}
}
