using System.Collections.Generic;

namespace System.Linq
{
	public static class LinqExtension
	{
		public static List<E> ShuffleList<E>(this List<E> inputList)
		{
			return null;
		}

		public static IEnumerable<T> Traverse<T>(this T item, Func<T, T> childSelector)
		{
			return null;
		}

		public static IEnumerable<T> Traverse<T>(this T item, Func<T, IEnumerable<T>> childSelector)
		{
			return null;
		}

		public static IEnumerable<T> Traverse<T>(this IEnumerable<T> items, Func<T, IEnumerable<T>> childSelector)
		{
			return null;
		}

		public static IEnumerable<IEnumerable<T>> Traverse<T>(this IEnumerable<T> items, Func<IEnumerable<T>, T, IEnumerable<T>> childSelector)
		{
			return null;
		}

		public static TSource RandomOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return default(TSource);
		}

		public static TSource RandomOrDefault<TSource>(this IEnumerable<TSource> source)
		{
			return default(TSource);
		}
	}
}
