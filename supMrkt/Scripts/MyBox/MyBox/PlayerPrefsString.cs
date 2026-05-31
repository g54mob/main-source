using System;
using MyBox.Internal;

namespace MyBox
{
	[Serializable]
	public class PlayerPrefsString : PlayerPrefsType
	{
		public string DefaultString;

		public string Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static PlayerPrefsString WithKey(string key, string defaultString = "")
		{
			return null;
		}

		public PlayerPrefsString(string key, string defaultString = "")
		{
		}
	}
}
