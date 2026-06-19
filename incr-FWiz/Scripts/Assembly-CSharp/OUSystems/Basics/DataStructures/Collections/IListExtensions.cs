using System.Collections.Generic;

namespace OUSystems.Basics.DataStructures.Collections
{
	public static class IListExtensions
	{
		public static void Swap<E>(this IList<E> list, int indexA, int indexB)
		{
		}

		public static E PeekLast<E>(this List<E> list)
		{
			return default(E);
		}

		public static E RemoveLast<E>(this List<E> list)
		{
			return default(E);
		}

		public static bool IsEmpty<E>(this List<E> list)
		{
			return false;
		}

		public static bool HasIndex<E>(this List<E> list, int i)
		{
			return false;
		}
	}
}
