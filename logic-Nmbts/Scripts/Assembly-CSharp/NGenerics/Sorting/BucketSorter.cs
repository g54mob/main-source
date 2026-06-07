using System;
using System.Collections.Generic;
using NGenerics.Util;

namespace NGenerics.Sorting
{
	public sealed class BucketSorter : Sorter<int>
	{
		[Obsolete]
		public BucketSorter(int maximumUniverse)
		{
		}

		public BucketSorter()
		{
		}

		public override void Sort(IList<int> list, SortOrder order)
		{
			Guard.ArgumentNotNull(list, "list");
			if (list.Count <= 1)
			{
				return;
			}
			int num = list[0];
			int num2 = list[0];
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] > num)
				{
					num = list[i];
				}
				else if (list[i] < num2)
				{
					num2 = list[i];
				}
			}
			int num3 = num - num2 + 1;
			int[] array = new int[num3];
			for (int j = 0; j < list.Count; j++)
			{
				array[list[j] - num2]++;
			}
			if (order == SortOrder.Ascending)
			{
				int num4 = 0;
				for (int k = 0; k < num3; k++)
				{
					for (int l = 0; l < array[k]; l++)
					{
						list[num4] = k + num2;
						num4++;
					}
				}
				return;
			}
			int num5 = list.Count - 1;
			for (int m = 0; m < num3; m++)
			{
				for (int n = 0; n < array[m]; n++)
				{
					list[num5] = m + num2;
					num5--;
				}
			}
		}
	}
}
