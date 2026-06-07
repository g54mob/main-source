using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NGenerics.Util;

namespace NGenerics.Extensions
{
	public static class EnumerableExtensions
	{
		public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
		{
			Guard.ArgumentNotNull(enumerable, "enumerable");
			Guard.ArgumentNotNull(action, "action");
			foreach (T item in enumerable)
			{
				action(item);
			}
		}

		public static string ConcatToString<T>(this IEnumerable<T> enumerable, Func<T, string> func)
		{
			return enumerable.ConcatToString(func, ", ");
		}

		private static string ConcatToString<T>(this IEnumerable<T> enumerable, Func<T, string> func, string joinString)
		{
			StringBuilder stringBuilder = new StringBuilder();
			List<T> list = Enumerable.ToList(enumerable);
			for (int i = 0; i < list.Count; i++)
			{
				T arg = list[i];
				stringBuilder.Append(func(arg));
				if (i != list.Count - 1)
				{
					stringBuilder.Append(joinString);
				}
			}
			return stringBuilder.ToString();
		}
	}
}
