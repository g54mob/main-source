using System;
using System.Collections.Generic;

namespace Libs
{
	public class EnumUtil
	{
		public static (T, bool) ToEnum<T>(string str) where T : struct
		{
			return default((T, bool));
		}

		public static List<T> GetList<T>(bool removeNone = true) where T : Enum
		{
			return null;
		}

		public static int EnumToInt<T>(T target) where T : struct, IConvertible
		{
			return 0;
		}
	}
}
