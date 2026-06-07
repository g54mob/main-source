using System.Collections.Generic;

namespace MiscUtil
{
	public static class PartialComparer
	{
		public static int? ReferenceCompare<T>(T first, T second) where T : class
		{
			if (first == second)
			{
				return 0;
			}
			if (first == null)
			{
				return -1;
			}
			if (second == null)
			{
				return 1;
			}
			return null;
		}

		public static int? Compare<T>(T first, T second)
		{
			return Compare(Comparer<T>.Default, first, second);
		}

		public static int? Compare<T>(IComparer<T> comparer, T first, T second)
		{
			int num = comparer.Compare(first, second);
			if (num == 0)
			{
				return null;
			}
			return num;
		}

		public static bool? Equals<T>(T first, T second) where T : class
		{
			if (first == second)
			{
				return true;
			}
			if (first == null || second == null)
			{
				return false;
			}
			return null;
		}
	}
}
