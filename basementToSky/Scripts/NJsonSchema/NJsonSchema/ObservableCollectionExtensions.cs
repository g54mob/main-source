using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace NJsonSchema
{
	internal static class ObservableCollectionExtensions
	{
		public static int Count<T>(this ObservableCollection<T> collection, Func<T, bool> predicate)
		{
			int num = 0;
			for (int i = 0; i < collection.Count; i++)
			{
				if (predicate(collection[i]))
				{
					num++;
				}
			}
			return num;
		}

		public static T ElementAt<T>(this ObservableCollection<T> collection, int index)
		{
			return collection[index];
		}

		public static T First<T>(this ObservableCollection<T> collection)
		{
			if (collection.Count > 0)
			{
				return collection[0];
			}
			ThrowNoMatchingElement();
			return default(T);
		}

		public static T First<T>(this ObservableCollection<T> collection, Func<T, bool> predicate)
		{
			for (int i = 0; i < collection.Count; i++)
			{
				T val = collection[i];
				if (predicate(val))
				{
					return val;
				}
			}
			ThrowNoMatchingElement();
			return default(T);
		}

		public static T FirstOrDefault<T>(this ObservableCollection<T> collection, Func<T, bool> predicate) where T : class
		{
			for (int i = 0; i < collection.Count; i++)
			{
				T val = collection[i];
				if (predicate(val))
				{
					return val;
				}
			}
			return null;
		}

		public static T FirstOrDefault<T>(this ObservableCollection<T> collection) where T : class
		{
			if (collection.Count > 0)
			{
				return collection[0];
			}
			return null;
		}

		public static bool Any<T>(this ObservableCollection<T> collection)
		{
			return collection.Count > 0;
		}

		public static bool Any<T>(this ObservableCollection<T> collection, Func<T, bool> predicate)
		{
			for (int i = 0; i < collection.Count; i++)
			{
				if (predicate(collection[i]))
				{
					return true;
				}
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ThrowNoMatchingElement()
		{
			throw new InvalidOperationException("Collection contains no matching element");
		}
	}
}
