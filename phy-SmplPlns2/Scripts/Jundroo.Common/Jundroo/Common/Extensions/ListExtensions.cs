using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Jundroo.Common.Extensions
{
	public static class ListExtensions
	{
		private static Random _random = new Random();

		public static void AddRange<T>(this IList<T> list, IEnumerable<T> items)
		{
			if (list is List<T> list2)
			{
				list2.AddRange(items);
				return;
			}
			if (items is IList<T> list3)
			{
				for (int i = 0; i < list3.Count; i++)
				{
					list.Add(list3[i]);
				}
				return;
			}
			foreach (T item in items)
			{
				list.Add(item);
			}
		}

		public static bool Any<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
		{
			for (int i = 0; i < source.Count; i++)
			{
				if (predicate(source[i]))
				{
					return true;
				}
			}
			return false;
		}

		public static Span<T> AsSpan<T>(this List<T> list)
		{
			if (list == null)
			{
				return default(Span<T>);
			}
			return new Span<T>(Unsafe.As<StrongBox<T[]>>(list).Value, 0, list.Count);
		}

		public static Span<T> AsSpan<T>(this List<T> list, int startIndex, int count)
		{
			if (list == null)
			{
				return default(Span<T>);
			}
			return new Span<T>(Unsafe.As<StrongBox<T[]>>(list).Value, startIndex, count);
		}

		public static List<T> EnsureCapacity<T>(this List<T> list, int capacity)
		{
			if (list.Capacity < capacity)
			{
				list.Capacity = capacity;
			}
			return list;
		}

		public static List<T> Fill<T>(this List<T> list) where T : new()
		{
			int i;
			for (i = 0; i < list.Count; i++)
			{
				list[i] = new T();
			}
			for (; i < list.Capacity; i++)
			{
				list.Add(new T());
			}
			return list;
		}

		public static List<T> Fill<T>(this List<T> list, T value)
		{
			int i;
			for (i = 0; i < list.Count; i++)
			{
				list[i] = value;
			}
			for (; i < list.Capacity; i++)
			{
				list.Add(value);
			}
			return list;
		}

		public static List<T> Fill<T>(this List<T> list, Func<T> value)
		{
			int i;
			for (i = 0; i < list.Count; i++)
			{
				list[i] = value();
			}
			for (; i < list.Capacity; i++)
			{
				list.Add(value());
			}
			return list;
		}

		public static List<T> Fill<T>(this List<T> list, Func<int, T> value)
		{
			int i;
			for (i = 0; i < list.Count; i++)
			{
				list[i] = value(i);
			}
			for (; i < list.Capacity; i++)
			{
				list.Add(value(i));
			}
			return list;
		}

		public static void Fill<T>(this IList<T> list, T value, int count, int? startIndex = null)
		{
			if (startIndex.HasValue)
			{
				int num = System.Math.Min(startIndex.Value + count, list.Count);
				count -= System.Math.Max(num - startIndex.Value, 0);
				for (int i = startIndex.Value; i < num; i++)
				{
					list[i] = value;
				}
			}
			for (int j = 0; j < count; j++)
			{
				list.Add(value);
			}
		}

		public static void Fill<T>(this IList<T> list, Func<T> value, int count, int? startIndex = null)
		{
			if (startIndex.HasValue)
			{
				int num = System.Math.Min(startIndex.Value + count, list.Count);
				count -= System.Math.Max(num - startIndex.Value, 0);
				for (int i = startIndex.Value; i < num; i++)
				{
					list[i] = value();
				}
			}
			for (int j = 0; j < count; j++)
			{
				list.Add(value());
			}
		}

		public static void Fill<T>(this IList<T> list, Func<int, T> value, int count, int? startIndex = null)
		{
			if (startIndex.HasValue)
			{
				int num = System.Math.Min(startIndex.Value + count, list.Count);
				count -= System.Math.Max(num - startIndex.Value, 0);
				for (int i = startIndex.Value; i < num; i++)
				{
					list[i] = value(i);
				}
			}
			for (int j = 0; j < count; j++)
			{
				list.Add(value(list.Count));
			}
		}

		public static T[] GetInternalArray<T>(this List<T> list)
		{
			if (list == null)
			{
				return null;
			}
			return Unsafe.As<StrongBox<T[]>>(list).Value;
		}

		public static int IndexOf<T>(this IReadOnlyList<T> list, T item)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (object.Equals(list[i], item))
				{
					return i;
				}
			}
			return -1;
		}

		public static void Resize<T>(this List<T> list, int size, T element = default(T))
		{
			int count = list.Count;
			if (size < count)
			{
				list.RemoveRange(size, count - size);
			}
			else if (size > count)
			{
				if (size > list.Capacity)
				{
					list.Capacity = size;
				}
				list.AddRange(Enumerable.Repeat(element, size - count));
			}
		}

		public static void Shuffle<T>(this IList<T> list)
		{
			int num = list.Count;
			while (num > 1)
			{
				num--;
				int index = _random.Next(num + 1);
				T value = list[index];
				list[index] = list[num];
				list[num] = value;
			}
		}
	}
}
