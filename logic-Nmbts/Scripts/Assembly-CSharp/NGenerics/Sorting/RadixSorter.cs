using System;
using System.Collections.Generic;
using NGenerics.Util;

namespace NGenerics.Sorting
{
	public sealed class RadixSorter : Sorter<int>
	{
		private const int intSize = 32;

		private const int r = 8;

		private const int radix = 256;

		private const int mask = 255;

		private static readonly int passesNeeded = (int)Math.Ceiling(4.0);

		public override void Sort(IList<int> list, SortOrder order)
		{
			Guard.ArgumentNotNull(list, "list");
			int[] array = new int[list.Count];
			int num = 0;
			int[] array2 = new int[256];
			for (int i = 0; i < passesNeeded; i++)
			{
				int[] array3 = new int[256];
				for (int j = 0; j < list.Count; j++)
				{
					array3[(list[j] >> num) & 0xFF]++;
				}
				array2[0] = 0;
				for (int k = 1; k < 256; k++)
				{
					array2[k] = array2[k - 1] + array3[k - 1];
				}
				for (int l = 0; l < list.Count; l++)
				{
					array[array2[(list[l] >> num) & 0xFF]++] = list[l];
				}
				for (int m = 0; m < array.Length; m++)
				{
					list[m] = array[m];
				}
				num += 8;
			}
			if (order == SortOrder.Descending)
			{
				List<int> list2 = new List<int>(list.Count);
				list2.AddRange(list);
				int num2 = 0;
				for (int num3 = list.Count - 1; num3 >= 0; num3--)
				{
					list[num3] = list2[num2];
					num2++;
				}
			}
		}
	}
}
