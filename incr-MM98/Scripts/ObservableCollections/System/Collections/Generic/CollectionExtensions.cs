using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Collections.Generic
{
	internal static class CollectionExtensions
	{
		private const int ArrayMaxLength = 2147483591;

		public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> kvp, out TKey key, out TValue value)
		{
			key = kvp.Key;
			value = kvp.Value;
		}

		public static bool Remove<TKey, TValue>(this SortedDictionary<TKey, TValue> dict, TKey key, out TValue value)
		{
			if (dict.TryGetValue(key, out value))
			{
				return dict.Remove(key);
			}
			return false;
		}

		public static bool Remove<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, out TValue value)
		{
			if (dict.TryGetValue(key, out value))
			{
				return dict.Remove(key);
			}
			return false;
		}

		public static void AddRange<T>(this List<T> list, ReadOnlySpan<T> source)
		{
			if (!source.IsEmpty)
			{
				ref CollectionsMarshal.ListView<T> reference = ref Unsafe.As<List<T>, CollectionsMarshal.ListView<T>>(ref list);
				if (reference._items.Length - reference._size < source.Length)
				{
					Grow(ref reference, checked(reference._size + source.Length));
				}
				source.CopyTo(reference._items.AsSpan(reference._size));
				reference._size += source.Length;
				reference._version++;
			}
		}

		public static void InsertRange<T>(this List<T> list, int index, ReadOnlySpan<T> source)
		{
			if (!source.IsEmpty)
			{
				ref CollectionsMarshal.ListView<T> reference = ref Unsafe.As<List<T>, CollectionsMarshal.ListView<T>>(ref list);
				if (reference._items.Length - reference._size < source.Length)
				{
					Grow(ref reference, checked(reference._size + source.Length));
				}
				if (index < reference._size)
				{
					Array.Copy(reference._items, index, reference._items, index + source.Length, reference._size - index);
				}
				source.CopyTo(reference._items.AsSpan(index));
				reference._size += source.Length;
				reference._version++;
			}
		}

		private static void Grow<T>(ref CollectionsMarshal.ListView<T> list, int capacity)
		{
			SetCapacity(ref list, GetNewCapacity(ref list, capacity));
		}

		private static void SetCapacity<T>(ref CollectionsMarshal.ListView<T> list, int value)
		{
			if (value == list._items.Length)
			{
				return;
			}
			if (value > 0)
			{
				T[] array = new T[value];
				if (list._size > 0)
				{
					Array.Copy(list._items, array, list._size);
				}
				list._items = array;
			}
			else
			{
				list._items = Array.Empty<T>();
			}
		}

		private static int GetNewCapacity<T>(ref CollectionsMarshal.ListView<T> list, int capacity)
		{
			int num = ((list._items.Length == 0) ? 4 : (2 * list._items.Length));
			if ((uint)num > 2147483591u)
			{
				num = 2147483591;
			}
			if (num < capacity)
			{
				num = capacity;
			}
			return num;
		}

		public static bool TryGetNonEnumeratedCount<T>(this IEnumerable<T> source, out int count)
		{
			if (source is ICollection<T> collection)
			{
				count = collection.Count;
				return true;
			}
			if (source is IReadOnlyCollection<T> readOnlyCollection)
			{
				count = readOnlyCollection.Count;
				return true;
			}
			count = 0;
			return false;
		}
	}
}
