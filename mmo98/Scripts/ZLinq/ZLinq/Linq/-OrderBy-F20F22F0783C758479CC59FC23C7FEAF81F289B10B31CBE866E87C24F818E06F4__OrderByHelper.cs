using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ZLinq.Linq
{
	internal static class _003COrderBy_003EF20F22F0783C758479CC59FC23C7FEAF81F289B10B31CBE866E87C24F818E06F4__OrderByHelper
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool TypeIsImplicitlyStable<T>()
		{
			Type type = typeof(T);
			if (typeof(T).IsEnum)
			{
				type = typeof(T).GetEnumUnderlyingType();
			}
			if (!(type == typeof(sbyte)) && !(type == typeof(byte)) && !(type == typeof(bool)) && !(type == typeof(short)) && !(type == typeof(ushort)) && !(type == typeof(char)) && !(type == typeof(int)) && !(type == typeof(uint)) && !(type == typeof(long)) && !(type == typeof(ulong)) && !(type == typeof(IntPtr)))
			{
				return type == typeof(UIntPtr);
			}
			return true;
		}

		internal static int QuickSelect(int[] map, IComparer<int> comparer, int right, int idx)
		{
			int num = 0;
			do
			{
				int num2 = num;
				int num3 = right;
				int x = map[num2 + (num3 - num2 >> 1)];
				while (true)
				{
					if (num2 < map.Length && comparer.Compare(x, map[num2]) > 0)
					{
						num2++;
						continue;
					}
					while (num3 >= 0 && comparer.Compare(x, map[num3]) < 0)
					{
						num3--;
					}
					if (num2 > num3)
					{
						break;
					}
					if (num2 < num3)
					{
						int num4 = map[num2];
						map[num2] = map[num3];
						map[num3] = num4;
					}
					num2++;
					num3--;
					if (num2 > num3)
					{
						break;
					}
				}
				if (num2 <= idx)
				{
					num = num2 + 1;
				}
				else
				{
					right = num3 - 1;
				}
				if (num3 - num <= right - num2)
				{
					if (num < num3)
					{
						right = num3;
					}
					num = num2;
				}
				else
				{
					if (num2 < right)
					{
						num = num2;
					}
					right = num3;
				}
			}
			while (num < right);
			return map[idx];
		}

		internal static void PartialQuickSort(int[] map, IComparer<int> comparer, int left, int right, int minIdx, int maxIdx)
		{
			do
			{
				int num = left;
				int num2 = right;
				int x = map[num + (num2 - num >> 1)];
				while (true)
				{
					if (num < map.Length && comparer.Compare(x, map[num]) > 0)
					{
						num++;
						continue;
					}
					while (num2 >= 0 && comparer.Compare(x, map[num2]) < 0)
					{
						num2--;
					}
					if (num > num2)
					{
						break;
					}
					if (num < num2)
					{
						int num3 = map[num];
						map[num] = map[num2];
						map[num2] = num3;
					}
					num++;
					num2--;
					if (num > num2)
					{
						break;
					}
				}
				if (minIdx >= num)
				{
					left = num + 1;
				}
				else if (maxIdx <= num2)
				{
					right = num2 - 1;
				}
				if (num2 - left <= right - num)
				{
					if (left < num2)
					{
						PartialQuickSort(map, comparer, left, num2, minIdx, maxIdx);
					}
					left = num;
				}
				else
				{
					if (num < right)
					{
						PartialQuickSort(map, comparer, num, right, minIdx, maxIdx);
					}
					right = num2;
				}
			}
			while (left < right);
		}

		internal static int Min(int[] map, IComparer<int> comparer, int count)
		{
			int num = 0;
			for (int i = 1; i < count; i++)
			{
				if (comparer.Compare(map[i], map[num]) < 0)
				{
					num = i;
				}
			}
			return map[num];
		}

		internal static int Max(int[] map, IComparer<int> comparer, int count)
		{
			int num = 0;
			for (int i = 1; i < count; i++)
			{
				if (comparer.Compare(map[i], map[num]) >= 0)
				{
					num = i;
				}
			}
			return map[num];
		}
	}
}
