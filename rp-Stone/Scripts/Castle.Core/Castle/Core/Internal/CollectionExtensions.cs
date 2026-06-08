using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Castle.Core.Internal
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class CollectionExtensions
	{
		public static T Find<T>(this T[] items, Predicate<T> predicate)
		{
			return Array.Find(items, predicate);
		}

		public static T[] FindAll<T>(this T[] items, Predicate<T> predicate)
		{
			return Array.FindAll(items, predicate);
		}

		public static bool IsNullOrEmpty(this IEnumerable @this)
		{
			if (@this != null)
			{
				return !@this.GetEnumerator().MoveNext();
			}
			return true;
		}

		public static int GetContentsHashCode<T>(IList<T> list)
		{
			if (list == null)
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] != null)
				{
					num += list[i].GetHashCode();
				}
			}
			return num;
		}

		public static bool AreEquivalent<T>(IList<T> listA, IList<T> listB)
		{
			if (listA == null && listB == null)
			{
				return true;
			}
			if (listA == null || listB == null)
			{
				return false;
			}
			if (listA.Count != listB.Count)
			{
				return false;
			}
			List<T> list = listB.ToList();
			for (int i = 0; i < listA.Count; i++)
			{
				bool flag = false;
				for (int j = 0; j < list.Count; j++)
				{
					if (object.Equals(listA[i], list[j]))
					{
						flag = true;
						list.RemoveAt(j);
						break;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			return true;
		}
	}
}
