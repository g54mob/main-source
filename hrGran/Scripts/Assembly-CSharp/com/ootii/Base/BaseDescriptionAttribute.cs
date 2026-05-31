using System;

namespace com.ootii.Base
{
	public class BaseDescriptionAttribute : Attribute
	{
		protected string mValue;

		public string Value => null;

		public BaseDescriptionAttribute(string rValue)
		{
		}

		public static string GetDescription(Type rType)
		{
			return null;
		}
	}
}
