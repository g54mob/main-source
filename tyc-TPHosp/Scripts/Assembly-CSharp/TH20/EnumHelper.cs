using System;
using System.Collections.Generic;

namespace TH20
{
	public static class EnumHelper<T>
	{
		private static Dictionary<string, T> _stringToEnum = new Dictionary<string, T>();

		private static Dictionary<T, string> _enumToString = new Dictionary<T, string>();

		public static T ToEnum(string typeStr)
		{
			if (!_stringToEnum.ContainsKey(typeStr))
			{
				_stringToEnum.Add(typeStr, (T)Enum.Parse(typeof(T), typeStr, ignoreCase: true));
			}
			return _stringToEnum[typeStr];
		}

		public static string ToString(T type)
		{
			if (!_enumToString.ContainsKey(type))
			{
				_enumToString.Add(type, type.ToString());
			}
			return _enumToString[type];
		}
	}
}
