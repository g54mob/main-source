using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NGenerics.Sorting;
using NGenerics.Util;

namespace NGenerics.Extensions
{
	public static class ListExtensions
	{
		public static IList<T> GetRange<T>(this IList<T> enumerable, int index, int count)
		{
			Guard.ArgumentNotNull(enumerable, "enumerable");
			if (count < 0)
			{
				throw new IndexOutOfRangeException("count is below zero");
			}
			if (index < 0)
			{
				throw new IndexOutOfRangeException("index is below zero");
			}
			if (enumerable.Count - index < count)
			{
				throw new ArgumentException("Count is too small", "count");
			}
			List<T> list = new List<T>(count);
			for (int i = index; i < index + count; i++)
			{
				list.Add(enumerable[i]);
			}
			return list;
		}

		public static void AddRange<T>(this IList<T> list, IEnumerable<T> collection)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(collection, "collection");
			collection.ForEach(list.Add);
		}

		public static int FindIndex<T>(this IList<T> list, Predicate<T> match)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(match, "match");
			return list.FindIndex(0, match);
		}

		public static int FindIndex<T>(this IList<T> list, int startIndex, Predicate<T> match)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(match, "match");
			return list.FindIndex(startIndex, list.Count - startIndex, match);
		}

		public static int FindIndex<T>(this IList<T> list, int startIndex, int count, Predicate<T> match)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(match, "match");
			if (startIndex > list.Count)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			if (count < 0 || startIndex > list.Count - count)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			int num = startIndex + count;
			for (int i = startIndex; i < num; i++)
			{
				if (match(list[i]))
				{
					return i;
				}
			}
			return -1;
		}

		public static int FindLastIndex<T>(this IList<T> list, Predicate<T> match)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(match, "match");
			return list.FindLastIndex(list.Count - 1, list.Count, match);
		}

		public static int FindLastIndex<T>(this IList<T> list, int startIndex, Predicate<T> match)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(match, "match");
			return list.FindLastIndex(startIndex, startIndex + 1, match);
		}

		public static int FindLastIndex<T>(this IList<T> list, int startIndex, int count, Predicate<T> match)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(match, "match");
			if (list.Count == 0)
			{
				if (startIndex != -1)
				{
					throw new ArgumentOutOfRangeException("startIndex");
				}
			}
			else if (startIndex >= list.Count)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			if (count < 0 || startIndex - count + 1 < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			int num = startIndex - count;
			for (int num2 = startIndex; num2 > num; num2--)
			{
				if (match(list[num2]))
				{
					return num2;
				}
			}
			return -1;
		}

		public static void ForEach<T>(this IList<T> list, Action<T> action)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(action, "action");
			foreach (T item in list)
			{
				action(item);
			}
		}

		public static void InsertRange<T>(this IList<T> list, int index, IEnumerable<T> collection)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(collection, "collection");
			if (index > list.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			foreach (T item in collection)
			{
				list.Insert(index++, item);
			}
		}

		public static int RemoveAll<T>(this IList<T> list, Predicate<T> match)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(match, "match");
			int num = 0;
			int num2 = 0;
			while (num < list.Count)
			{
				T obj = list[num];
				if (match(obj))
				{
					list.RemoveAt(num);
					num2++;
				}
				else
				{
					num++;
				}
			}
			return num2;
		}

		public static void Sort<T>(this IList<T> list)
		{
			Guard.ArgumentNotNull(list, "list");
			new QuickSorter<T>().Sort(list);
		}

		public static void Sort<T>(this IList<T> list, SortOrder sortOrder)
		{
			Guard.ArgumentNotNull(list, "list");
			new QuickSorter<T>().Sort(list, sortOrder);
		}

		public static void Sort<T>(this IList<T> list, IComparer<T> comparer)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(comparer, "comparer");
			new QuickSorter<T>().Sort(list, comparer);
		}

		public static void Sort<T>(this IList<T> list, Comparison<T> comparison)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(comparison, "comparison");
			new QuickSorter<T>().Sort(list, comparison);
		}

		public static void Sort<T>(this IList<T> list, Comparison<T> comparison, SortOrder sortOrder)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(comparison, "comparison");
			new QuickSorter<T>().Sort(list, comparison, sortOrder);
		}

		public static void Sort<T>(this IList<T> list, Expression<Func<T, IComparable>> property)
		{
			list.Sort(property, SortOrder.Ascending);
		}

		public static void Sort<T>(this IList<T> list, Expression<Func<T, IComparable>> property, SortOrder sortOrder)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(property, "property");
			QuickSorter<T> quickSorter = new QuickSorter<T>();
			Comparison<T> comparison = delegate(T x, T y)
			{
				Func<T, IComparable> func = property.Compile();
				return func(x).CompareTo(func(y));
			};
			quickSorter.Sort(list, comparison, sortOrder);
		}
	}
}
