using System;
using System.Collections.Generic;

namespace MessagePipe.Internal
{
	internal static class ArrayUtil
	{
		public static T[] ImmutableAdd<T>(T[] source, T item)
		{
			T[] array = new T[source.Length + 1];
			Array.Copy(source, 0, array, 0, source.Length);
			array[^1] = item;
			return array;
		}

		public static T[] ImmutableRemove<T, TState>(T[] source, Func<T, TState, bool> match, TState state)
		{
			if (source.Length == 0)
			{
				return source;
			}
			int num = -1;
			for (int i = 0; i < source.Length; i++)
			{
				if (match(source[i], state))
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return source;
			}
			if (source.Length == 1)
			{
				return Array.Empty<T>();
			}
			T[] array = new T[source.Length - 1];
			if (num == 0)
			{
				Array.Copy(source, 1, array, 0, array.Length);
			}
			else if (num == source.Length - 1)
			{
				Array.Copy(source, 0, array, 0, array.Length);
			}
			else
			{
				Array.Copy(source, 0, array, 0, num);
				Array.Copy(source, num + 1, array, num, source.Length - num - 1);
			}
			return array;
		}

		public static IEnumerable<T> Concat<T>(T[] source1, T[] source2)
		{
			if (source1.Length != 0)
			{
				T[] array = source1;
				for (int i = 0; i < array.Length; i++)
				{
					yield return array[i];
				}
			}
			if (source2.Length != 0)
			{
				T[] array = source2;
				for (int i = 0; i < array.Length; i++)
				{
					yield return array[i];
				}
			}
		}

		public static IEnumerable<T> Concat<T>(T[] source1, T[] source2, T[] source3)
		{
			if (source1.Length != 0)
			{
				T[] array = source1;
				for (int i = 0; i < array.Length; i++)
				{
					yield return array[i];
				}
			}
			if (source2.Length != 0)
			{
				T[] array = source2;
				for (int i = 0; i < array.Length; i++)
				{
					yield return array[i];
				}
			}
			if (source3.Length != 0)
			{
				T[] array = source3;
				for (int i = 0; i < array.Length; i++)
				{
					yield return array[i];
				}
			}
		}
	}
}
