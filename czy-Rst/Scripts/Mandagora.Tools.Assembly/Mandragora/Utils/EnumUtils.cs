using System;
using System.Collections.Generic;

namespace Mandragora.Utils
{
	public class EnumUtils
	{
		public static T parseEnum<T>(string itemName)
		{
			if (string.IsNullOrEmpty(itemName))
			{
				return default(T);
			}
			return (T)Enum.Parse(typeof(T), itemName);
		}

		public static List<T> parseEnumFromArrString<T>(string arrayString)
		{
			if (string.IsNullOrEmpty(arrayString))
			{
				return null;
			}
			string[] array = arrayString.Split(',');
			if (array == null || array.Length < 1)
			{
				return null;
			}
			List<T> list = new List<T>();
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(parseEnum<T>(array[i]));
			}
			return list;
		}
	}
}
