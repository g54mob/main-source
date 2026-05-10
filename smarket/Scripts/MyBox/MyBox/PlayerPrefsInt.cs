using System;
using MyBox.Internal;

namespace MyBox
{
	[Serializable]
	public class PlayerPrefsInt : PlayerPrefsType
	{
		public int DefaultValue;

		public int Value
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static PlayerPrefsInt WithKey(string key, int defaultValue = 0)
		{
			return null;
		}

		public PlayerPrefsInt(string key, int defaultValue = 0)
		{
		}
	}
}
