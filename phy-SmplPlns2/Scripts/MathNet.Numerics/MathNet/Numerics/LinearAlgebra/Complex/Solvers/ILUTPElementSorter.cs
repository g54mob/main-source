using System.Numerics;

namespace MathNet.Numerics.LinearAlgebra.Complex.Solvers
{
	internal static class ILUTPElementSorter
	{
		public static void SortDoubleIndicesDecreasing(int lowerBound, int upperBound, int[] sortedIndices, Vector<System.Numerics.Complex> values)
		{
			if (lowerBound > 0)
			{
				for (int i = 0; i < upperBound - lowerBound + 1; i++)
				{
					Exchange(sortedIndices, i, i + lowerBound);
				}
				upperBound -= lowerBound;
				lowerBound = 0;
			}
			HeapSortDoublesIndices(lowerBound, upperBound, sortedIndices, values);
		}

		private static void HeapSortDoublesIndices(int lowerBound, int upperBound, int[] sortedIndices, Vector<System.Numerics.Complex> values)
		{
			int start = (upperBound - lowerBound + 1) / 2 - 1 + lowerBound;
			int num = upperBound - lowerBound + 1 - 1 + lowerBound;
			BuildDoubleIndexHeap(start, upperBound - lowerBound + 1, sortedIndices, values);
			while (num >= lowerBound)
			{
				Exchange(sortedIndices, num, lowerBound);
				SiftDoubleIndices(sortedIndices, values, lowerBound, num);
				num--;
			}
		}

		private static void BuildDoubleIndexHeap(int start, int count, int[] sortedIndices, Vector<System.Numerics.Complex> values)
		{
			while (start >= 0)
			{
				SiftDoubleIndices(sortedIndices, values, start, count);
				start--;
			}
		}

		private static void SiftDoubleIndices(int[] sortedIndices, Vector<System.Numerics.Complex> values, int begin, int count)
		{
			int num = begin;
			while (num * 2 < count)
			{
				int num2 = num * 2;
				if (num2 < count - 1 && values[sortedIndices[num2]].Magnitude > values[sortedIndices[num2 + 1]].Magnitude)
				{
					num2++;
				}
				if (values[sortedIndices[num]].Magnitude <= values[sortedIndices[num2]].Magnitude)
				{
					break;
				}
				Exchange(sortedIndices, num, num2);
				num = num2;
			}
		}

		public static void SortIntegersDecreasing(int[] values)
		{
			HeapSortIntegers(values, values.Length);
		}

		private static void HeapSortIntegers(int[] values, int count)
		{
			int start = count / 2 - 1;
			int num = count - 1;
			BuildHeap(values, start, count);
			while (num >= 0)
			{
				Exchange(values, num, 0);
				Sift(values, 0, num);
				num--;
			}
		}

		private static void BuildHeap(int[] values, int start, int count)
		{
			while (start >= 0)
			{
				Sift(values, start, count);
				start--;
			}
		}

		private static void Sift(int[] values, int start, int count)
		{
			int num = start;
			while (num * 2 < count)
			{
				int num2 = num * 2;
				if (num2 < count - 1 && values[num2] > values[num2 + 1])
				{
					num2++;
				}
				if (values[num] > values[num2])
				{
					Exchange(values, num, num2);
					num = num2;
					continue;
				}
				break;
			}
		}

		private static void Exchange(int[] values, int first, int second)
		{
			ref int reference = ref values[first];
			ref int reference2 = ref values[second];
			int num = values[second];
			int num2 = values[first];
			reference = num;
			reference2 = num2;
		}
	}
}
