using System;
using System.Collections.Generic;

namespace Humanizer
{
	public static class CollectionHumanizeExtensions
	{
		public static string Humanize<T>(this IEnumerable<T> collection)
		{
			return null;
		}

		public static string Humanize<T>(this IEnumerable<T> collection, Func<T, string> displayFormatter)
		{
			return null;
		}

		public static string Humanize<T>(this IEnumerable<T> collection, Func<T, object> displayFormatter)
		{
			return null;
		}

		public static string Humanize<T>(this IEnumerable<T> collection, string separator)
		{
			return null;
		}

		public static string Humanize<T>(this IEnumerable<T> collection, Func<T, string> displayFormatter, string separator)
		{
			return null;
		}

		public static string Humanize<T>(this IEnumerable<T> collection, Func<T, object> displayFormatter, string separator)
		{
			return null;
		}
	}
}
