using System;

namespace com.ootii.Base
{
	public class BaseNameAttribute : Attribute
	{
		protected string mValue;

		public string Value => null;

		public BaseNameAttribute(string rValue)
		{
		}

		public static string GetName(Type rType)
		{
			return null;
		}
	}
}
