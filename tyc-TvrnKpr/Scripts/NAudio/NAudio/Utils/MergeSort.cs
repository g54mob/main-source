using System;
using System.Collections.Generic;

namespace NAudio.Utils
{
	internal class MergeSort
	{
		private static void Sort<T>(IList<T> list, int lowIndex, int highIndex, IComparer<T> comparer)
		{
		}

		public static void Sort<T>(IList<T> list) where T : IComparable<T>
		{
		}

		public static void Sort<T>(IList<T> list, IComparer<T> comparer)
		{
		}
	}
}
