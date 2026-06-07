using System;
using System.Collections.Generic;

namespace MathNet.Numerics
{
	public static class Sorting
	{
		public static void Sort<T>(IList<T> keys, IComparer<T> comparer = null)
		{
			int count = keys.Count;
			if (count <= 1)
			{
				return;
			}
			if (comparer == null)
			{
				comparer = Comparer<T>.Default;
			}
			if (count == 2)
			{
				if (comparer.Compare(keys[0], keys[1]) > 0)
				{
					Swap(keys, 0, 1);
				}
			}
			else if (count <= 10)
			{
				for (int i = 1; i < count; i++)
				{
					T val = keys[i];
					int num = i - 1;
					while (num >= 0 && comparer.Compare(keys[num], val) > 0)
					{
						keys[num + 1] = keys[num];
						num--;
					}
					keys[num + 1] = val;
				}
			}
			else if (keys is T[] array)
			{
				Array.Sort(array, comparer);
			}
			else if (keys is List<T> list)
			{
				list.Sort(comparer);
			}
			else
			{
				QuickSort(keys, comparer, 0, count - 1);
			}
		}

		public static void Sort<TKey, TItem>(IList<TKey> keys, IList<TItem> items, IComparer<TKey> comparer = null)
		{
			int count = keys.Count;
			if (count <= 1)
			{
				return;
			}
			if (comparer == null)
			{
				comparer = Comparer<TKey>.Default;
			}
			if (count == 2)
			{
				if (comparer.Compare(keys[0], keys[1]) > 0)
				{
					Swap(keys, 0, 1);
					Swap(items, 0, 1);
				}
			}
			else if (count <= 10)
			{
				for (int i = 1; i < count; i++)
				{
					TKey val = keys[i];
					TItem value = items[i];
					int num = i - 1;
					while (num >= 0 && comparer.Compare(keys[num], val) > 0)
					{
						keys[num + 1] = keys[num];
						items[num + 1] = items[num];
						num--;
					}
					keys[num + 1] = val;
					items[num + 1] = value;
				}
			}
			else if (keys is TKey[] keys2 && items is TItem[] items2)
			{
				Array.Sort(keys2, items2, comparer);
			}
			else
			{
				QuickSort(keys, items, comparer, 0, count - 1);
			}
		}

		public static void Sort<TKey, TItem1, TItem2>(IList<TKey> keys, IList<TItem1> items1, IList<TItem2> items2, IComparer<TKey> comparer = null)
		{
			int count = keys.Count;
			if (count <= 1)
			{
				return;
			}
			if (comparer == null)
			{
				comparer = Comparer<TKey>.Default;
			}
			if (count == 2)
			{
				if (comparer.Compare(keys[0], keys[1]) > 0)
				{
					Swap(keys, 0, 1);
					Swap(items1, 0, 1);
					Swap(items2, 0, 1);
				}
			}
			else if (count <= 10)
			{
				for (int i = 1; i < count; i++)
				{
					TKey val = keys[i];
					TItem1 value = items1[i];
					TItem2 value2 = items2[i];
					int num = i - 1;
					while (num >= 0 && comparer.Compare(keys[num], val) > 0)
					{
						keys[num + 1] = keys[num];
						items1[num + 1] = items1[num];
						items2[num + 1] = items2[num];
						num--;
					}
					keys[num + 1] = val;
					items1[num + 1] = value;
					items2[num + 1] = value2;
				}
			}
			else
			{
				QuickSort(keys, items1, items2, comparer, 0, count - 1);
			}
		}

		public static void Sort<T>(IList<T> keys, int index, int count, IComparer<T> comparer = null)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (count < 0 || index + count > keys.Count)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (count <= 1)
			{
				return;
			}
			if (comparer == null)
			{
				comparer = Comparer<T>.Default;
			}
			if (count == 2)
			{
				if (comparer.Compare(keys[index], keys[index + 1]) > 0)
				{
					Swap(keys, index, index + 1);
				}
			}
			else if (count <= 10)
			{
				int num = index + count;
				for (int i = index + 1; i < num; i++)
				{
					T val = keys[i];
					int num2 = i - 1;
					while (num2 >= index && comparer.Compare(keys[num2], val) > 0)
					{
						keys[num2 + 1] = keys[num2];
						num2--;
					}
					keys[num2 + 1] = val;
				}
			}
			else if (keys is T[] array)
			{
				Array.Sort(array, index, count, comparer);
			}
			else if (keys is List<T> list)
			{
				list.Sort(index, count, comparer);
			}
			else
			{
				QuickSort(keys, comparer, index, count - 1);
			}
		}

		public static void Sort<TKey, TItem>(IList<TKey> keys, IList<TItem> items, int index, int count, IComparer<TKey> comparer = null)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (count < 0 || index + count > keys.Count)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (count <= 1)
			{
				return;
			}
			if (comparer == null)
			{
				comparer = Comparer<TKey>.Default;
			}
			if (count == 2)
			{
				if (comparer.Compare(keys[index], keys[index + 1]) > 0)
				{
					Swap(keys, index, index + 1);
					Swap(items, index, index + 1);
				}
			}
			else if (count <= 10)
			{
				int num = index + count;
				for (int i = index + 1; i < num; i++)
				{
					TKey val = keys[i];
					TItem value = items[i];
					int num2 = i - 1;
					while (num2 >= index && comparer.Compare(keys[num2], val) > 0)
					{
						keys[num2 + 1] = keys[num2];
						items[num2 + 1] = items[num2];
						num2--;
					}
					keys[num2 + 1] = val;
					items[num2 + 1] = value;
				}
			}
			else if (keys is TKey[] keys2 && items is TItem[] items2)
			{
				Array.Sort(keys2, items2, index, count, comparer);
			}
			else
			{
				QuickSort(keys, items, comparer, index, count - 1);
			}
		}

		public static void Sort<TKey, TItem1, TItem2>(IList<TKey> keys, IList<TItem1> items1, IList<TItem2> items2, int index, int count, IComparer<TKey> comparer = null)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (count < 0 || index + count > keys.Count)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (count <= 1)
			{
				return;
			}
			if (comparer == null)
			{
				comparer = Comparer<TKey>.Default;
			}
			if (count == 2)
			{
				if (comparer.Compare(keys[index], keys[index + 1]) > 0)
				{
					Swap(keys, index, index + 1);
					Swap(items1, index, index + 1);
					Swap(items2, index, index + 1);
				}
			}
			else if (count <= 10)
			{
				int num = index + count;
				for (int i = index + 1; i < num; i++)
				{
					TKey val = keys[i];
					TItem1 value = items1[i];
					TItem2 value2 = items2[i];
					int num2 = i - 1;
					while (num2 >= index && comparer.Compare(keys[num2], val) > 0)
					{
						keys[num2 + 1] = keys[num2];
						items1[num2 + 1] = items1[num2];
						items2[num2 + 1] = items2[num2];
						num2--;
					}
					keys[num2 + 1] = val;
					items1[num2 + 1] = value;
					items2[num2 + 1] = value2;
				}
			}
			else
			{
				QuickSort(keys, items1, items2, comparer, index, count - 1);
			}
		}

		public static void SortAll<T1, T2>(IList<T1> primary, IList<T2> secondary, IComparer<T1> primaryComparer = null, IComparer<T2> secondaryComparer = null)
		{
			if (primaryComparer == null)
			{
				primaryComparer = Comparer<T1>.Default;
			}
			if (secondaryComparer == null)
			{
				secondaryComparer = Comparer<T2>.Default;
			}
			QuickSortAll(primary, secondary, primaryComparer, secondaryComparer, 0, primary.Count - 1);
		}

		private static void QuickSort<T>(IList<T> keys, IComparer<T> comparer, int left, int right)
		{
			do
			{
				int num = left;
				int num2 = right;
				int num3 = num + (num2 - num >> 1);
				if (comparer.Compare(keys[num], keys[num3]) > 0)
				{
					Swap(keys, num, num3);
				}
				if (comparer.Compare(keys[num], keys[num2]) > 0)
				{
					Swap(keys, num, num2);
				}
				if (comparer.Compare(keys[num3], keys[num2]) > 0)
				{
					Swap(keys, num3, num2);
				}
				T val = keys[num3];
				while (true)
				{
					if (comparer.Compare(keys[num], val) < 0)
					{
						num++;
						continue;
					}
					while (comparer.Compare(val, keys[num2]) < 0)
					{
						num2--;
					}
					if (num > num2)
					{
						break;
					}
					if (num < num2)
					{
						Swap(keys, num, num2);
					}
					num++;
					num2--;
					if (num > num2)
					{
						break;
					}
				}
				if (num2 - left <= right - num)
				{
					if (left < num2)
					{
						QuickSort(keys, comparer, left, num2);
					}
					left = num;
				}
				else
				{
					if (num < right)
					{
						QuickSort(keys, comparer, num, right);
					}
					right = num2;
				}
			}
			while (left < right);
		}

		private static void QuickSort<T, TItems>(IList<T> keys, IList<TItems> items, IComparer<T> comparer, int left, int right)
		{
			do
			{
				int num = left;
				int num2 = right;
				int num3 = num + (num2 - num >> 1);
				if (comparer.Compare(keys[num], keys[num3]) > 0)
				{
					Swap(keys, num, num3);
					Swap(items, num, num3);
				}
				if (comparer.Compare(keys[num], keys[num2]) > 0)
				{
					Swap(keys, num, num2);
					Swap(items, num, num2);
				}
				if (comparer.Compare(keys[num3], keys[num2]) > 0)
				{
					Swap(keys, num3, num2);
					Swap(items, num3, num2);
				}
				T val = keys[num3];
				while (true)
				{
					if (comparer.Compare(keys[num], val) < 0)
					{
						num++;
						continue;
					}
					while (comparer.Compare(val, keys[num2]) < 0)
					{
						num2--;
					}
					if (num > num2)
					{
						break;
					}
					if (num < num2)
					{
						Swap(keys, num, num2);
						Swap(items, num, num2);
					}
					num++;
					num2--;
					if (num > num2)
					{
						break;
					}
				}
				if (num2 - left <= right - num)
				{
					if (left < num2)
					{
						QuickSort(keys, items, comparer, left, num2);
					}
					left = num;
				}
				else
				{
					if (num < right)
					{
						QuickSort(keys, items, comparer, num, right);
					}
					right = num2;
				}
			}
			while (left < right);
		}

		private static void QuickSort<T, TItems1, TItems2>(IList<T> keys, IList<TItems1> items1, IList<TItems2> items2, IComparer<T> comparer, int left, int right)
		{
			do
			{
				int num = left;
				int num2 = right;
				int num3 = num + (num2 - num >> 1);
				if (comparer.Compare(keys[num], keys[num3]) > 0)
				{
					Swap(keys, num, num3);
					Swap(items1, num, num3);
					Swap(items2, num, num3);
				}
				if (comparer.Compare(keys[num], keys[num2]) > 0)
				{
					Swap(keys, num, num2);
					Swap(items1, num, num2);
					Swap(items2, num, num2);
				}
				if (comparer.Compare(keys[num3], keys[num2]) > 0)
				{
					Swap(keys, num3, num2);
					Swap(items1, num3, num2);
					Swap(items2, num3, num2);
				}
				T val = keys[num3];
				while (true)
				{
					if (comparer.Compare(keys[num], val) < 0)
					{
						num++;
						continue;
					}
					while (comparer.Compare(val, keys[num2]) < 0)
					{
						num2--;
					}
					if (num > num2)
					{
						break;
					}
					if (num < num2)
					{
						Swap(keys, num, num2);
						Swap(items1, num, num2);
						Swap(items2, num, num2);
					}
					num++;
					num2--;
					if (num > num2)
					{
						break;
					}
				}
				if (num2 - left <= right - num)
				{
					if (left < num2)
					{
						QuickSort(keys, items1, items2, comparer, left, num2);
					}
					left = num;
				}
				else
				{
					if (num < right)
					{
						QuickSort(keys, items1, items2, comparer, num, right);
					}
					right = num2;
				}
			}
			while (left < right);
		}

		private static void QuickSortAll<T1, T2>(IList<T1> primary, IList<T2> secondary, IComparer<T1> primaryComparer, IComparer<T2> secondaryComparer, int left, int right)
		{
			do
			{
				int num = left;
				int num2 = right;
				int num3 = num + (num2 - num >> 1);
				int num4 = primaryComparer.Compare(primary[num], primary[num3]);
				if (num4 > 0 || (num4 == 0 && secondaryComparer.Compare(secondary[num], secondary[num3]) > 0))
				{
					Swap(primary, num, num3);
					Swap(secondary, num, num3);
				}
				int num5 = primaryComparer.Compare(primary[num], primary[num2]);
				if (num5 > 0 || (num5 == 0 && secondaryComparer.Compare(secondary[num], secondary[num2]) > 0))
				{
					Swap(primary, num, num2);
					Swap(secondary, num, num2);
				}
				int num6 = primaryComparer.Compare(primary[num3], primary[num2]);
				if (num6 > 0 || (num6 == 0 && secondaryComparer.Compare(secondary[num3], secondary[num2]) > 0))
				{
					Swap(primary, num3, num2);
					Swap(secondary, num3, num2);
				}
				T1 val = primary[num3];
				T2 val2 = secondary[num3];
				while (true)
				{
					int num7;
					if ((num7 = primaryComparer.Compare(primary[num], val)) < 0 || (num7 == 0 && secondaryComparer.Compare(secondary[num], val2) < 0))
					{
						num++;
						continue;
					}
					int num8;
					while ((num8 = primaryComparer.Compare(val, primary[num2])) < 0 || (num8 == 0 && secondaryComparer.Compare(val2, secondary[num2]) < 0))
					{
						num2--;
					}
					if (num > num2)
					{
						break;
					}
					if (num < num2)
					{
						Swap(primary, num, num2);
						Swap(secondary, num, num2);
					}
					num++;
					num2--;
					if (num > num2)
					{
						break;
					}
				}
				if (num2 - left <= right - num)
				{
					if (left < num2)
					{
						QuickSortAll(primary, secondary, primaryComparer, secondaryComparer, left, num2);
					}
					left = num;
				}
				else
				{
					if (num < right)
					{
						QuickSortAll(primary, secondary, primaryComparer, secondaryComparer, num, right);
					}
					right = num2;
				}
			}
			while (left < right);
		}

		private static void Swap<T>(IList<T> keys, int a, int b)
		{
			if (a != b)
			{
				T value = keys[b];
				T value2 = keys[a];
				keys[a] = value;
				keys[b] = value2;
			}
		}
	}
}
