using System;
using System.Collections.Generic;
using System.Linq;

namespace UniJSON
{
	public static class TypeExtensions
	{
		public static bool GetIsGenericList(this Type t)
		{
			if (t == null)
			{
				return false;
			}
			if (t.IsGenericType)
			{
				return t.GetGenericTypeDefinition() == typeof(List<>);
			}
			return false;
		}

		public static bool GetIsGenericDictionary(this Type t)
		{
			if (t == null)
			{
				return false;
			}
			if (t.IsGenericType)
			{
				if (t.GetGenericTypeDefinition() == typeof(Dictionary<, >))
				{
					return t.GetGenericArguments().FirstOrDefault() == typeof(string);
				}
				return false;
			}
			return false;
		}
	}
}
