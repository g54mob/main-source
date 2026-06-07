using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MathNet.Numerics.Random;

namespace MathNet.Numerics
{
	public static class Combinatorics
	{
		public static double Variations(int n, int k)
		{
			if (k < 0 || n < 0 || k > n)
			{
				return 0.0;
			}
			return Math.Floor(0.5 + Math.Exp(SpecialFunctions.FactorialLn(n) - SpecialFunctions.FactorialLn(n - k)));
		}

		public static double VariationsWithRepetition(int n, int k)
		{
			if (k < 0 || n < 0)
			{
				return 0.0;
			}
			return Math.Pow(n, k);
		}

		public static double Combinations(int n, int k)
		{
			return SpecialFunctions.Binomial(n, k);
		}

		public static double CombinationsWithRepetition(int n, int k)
		{
			if (k < 0 || n < 0 || (n == 0 && k > 0))
			{
				return 0.0;
			}
			if (n == 0 && k == 0)
			{
				return 1.0;
			}
			return Math.Floor(0.5 + Math.Exp(SpecialFunctions.FactorialLn(n + k - 1) - SpecialFunctions.FactorialLn(k) - SpecialFunctions.FactorialLn(n - 1)));
		}

		public static double Permutations(int n)
		{
			return SpecialFunctions.Factorial(n);
		}

		public static int[] GeneratePermutation(int n, System.Random randomSource = null)
		{
			if (n < 0)
			{
				throw new ArgumentOutOfRangeException("n", "Value must not be negative (zero is ok).");
			}
			int[] array = new int[n];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = i;
			}
			SelectPermutationInplace(array, randomSource);
			return array;
		}

		public static void SelectPermutationInplace<T>(T[] data, System.Random randomSource = null)
		{
			System.Random random = randomSource ?? SystemRandomSource.Default;
			for (int num = data.Length - 1; num > 0; num--)
			{
				int num2 = random.Next(num + 1);
				int num3 = num;
				int num4 = num2;
				T val = data[num2];
				T val2 = data[num];
				data[num3] = val;
				data[num4] = val2;
			}
		}

		public static IEnumerable<T> SelectPermutation<T>(this IEnumerable<T> data, System.Random randomSource = null)
		{
			System.Random random = randomSource ?? SystemRandomSource.Default;
			T[] array = data.ToArray();
			for (int i = array.Length - 1; i >= 0; i--)
			{
				int k = random.Next(i + 1);
				yield return array[k];
				array[k] = array[i];
			}
		}

		public static bool[] GenerateCombination(int n, System.Random randomSource = null)
		{
			if (n < 0)
			{
				throw new ArgumentOutOfRangeException("n", "Value must not be negative (zero is ok).");
			}
			System.Random rnd = randomSource ?? SystemRandomSource.Default;
			bool[] array = new bool[n];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = rnd.NextBoolean();
			}
			return array;
		}

		public static bool[] GenerateCombination(int n, int k, System.Random randomSource = null)
		{
			if (n < 0)
			{
				throw new ArgumentOutOfRangeException("n", "Value must not be negative (zero is ok).");
			}
			if (k < 0)
			{
				throw new ArgumentOutOfRangeException("k", "Value must not be negative (zero is ok).");
			}
			if (k > n)
			{
				throw new ArgumentOutOfRangeException("k", "k must be smaller than or equal to n.");
			}
			System.Random random = randomSource ?? SystemRandomSource.Default;
			bool[] array = new bool[n];
			if (k * 3 < n)
			{
				int num = 0;
				while (num < k)
				{
					int num2 = random.Next(n);
					if (!array[num2])
					{
						array[num2] = true;
						num++;
					}
				}
				return array;
			}
			int[] array2 = GeneratePermutation(n, random);
			for (int i = 0; i < k; i++)
			{
				array[array2[i]] = true;
			}
			return array;
		}

		public static IEnumerable<T> SelectCombination<T>(this IEnumerable<T> data, int elementsToChoose, System.Random randomSource = null)
		{
			T[] array = (data as T[]) ?? data.ToArray();
			if (elementsToChoose < 0)
			{
				throw new ArgumentOutOfRangeException("elementsToChoose", "Value must not be negative (zero is ok).");
			}
			if (elementsToChoose > array.Length)
			{
				throw new ArgumentOutOfRangeException("elementsToChoose", "elementsToChoose must be smaller than or equal to data.Count.");
			}
			bool[] mask = GenerateCombination(array.Length, elementsToChoose, randomSource);
			for (int i = 0; i < mask.Length; i++)
			{
				if (mask[i])
				{
					yield return array[i];
				}
			}
		}

		public static int[] GenerateCombinationWithRepetition(int n, int k, System.Random randomSource = null)
		{
			if (n < 0)
			{
				throw new ArgumentOutOfRangeException("n", "Value must not be negative (zero is ok).");
			}
			if (k < 0)
			{
				throw new ArgumentOutOfRangeException("k", "Value must not be negative (zero is ok).");
			}
			System.Random random = randomSource ?? SystemRandomSource.Default;
			int[] array = new int[n];
			for (int i = 0; i < k; i++)
			{
				array[random.Next(n)]++;
			}
			return array;
		}

		public static IEnumerable<T> SelectCombinationWithRepetition<T>(this IEnumerable<T> data, int elementsToChoose, System.Random randomSource = null)
		{
			if (elementsToChoose < 0)
			{
				throw new ArgumentOutOfRangeException("elementsToChoose", "Value must not be negative (zero is ok).");
			}
			T[] array = (data as T[]) ?? data.ToArray();
			int[] mask = GenerateCombinationWithRepetition(array.Length, elementsToChoose, randomSource);
			for (int i = 0; i < mask.Length; i++)
			{
				for (int j = 0; j < mask[i]; j++)
				{
					yield return array[i];
				}
			}
		}

		public static int[] GenerateVariation(int n, int k, System.Random randomSource = null)
		{
			if (n < 0)
			{
				throw new ArgumentOutOfRangeException("n", "Value must not be negative (zero is ok).");
			}
			if (k < 0)
			{
				throw new ArgumentOutOfRangeException("k", "Value must not be negative (zero is ok).");
			}
			if (k > n)
			{
				throw new ArgumentOutOfRangeException("k", "k must be smaller than or equal to n.");
			}
			System.Random random = randomSource ?? SystemRandomSource.Default;
			int[] array = new int[n];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = i;
			}
			int[] array2 = new int[k];
			int num = 0;
			int num2 = array.Length - 1;
			while (num < array2.Length)
			{
				int num3 = random.Next(num2 + 1);
				array2[num] = array[num3];
				array[num3] = array[num2];
				num++;
				num2--;
			}
			return array2;
		}

		public static BigInteger[] GenerateVariation(BigInteger n, int k, System.Random randomSource = null)
		{
			if (n < 0L)
			{
				throw new ArgumentOutOfRangeException("n", "Value must not be negative (zero is ok).");
			}
			if (k < 0)
			{
				throw new ArgumentOutOfRangeException("k", "Value must not be negative (zero is ok).");
			}
			if (k > n)
			{
				throw new ArgumentOutOfRangeException("k", "k must be smaller than or equal to n.");
			}
			System.Random rnd = randomSource ?? SystemRandomSource.Default;
			BigInteger[] array = new BigInteger[k];
			if (n == 0L || k == 0)
			{
				return array;
			}
			array[0] = rnd.NextBigIntegerSequence(BigInteger.Zero, n).First();
			for (int i = 1; i < k; i++)
			{
				BigInteger bigInteger = rnd.NextBigIntegerSequence(BigInteger.Zero, n - i).First();
				bool[] array2 = Generate.Repeat(i, value: true);
				bool flag;
				do
				{
					flag = false;
					for (int j = 0; j < i; j++)
					{
						if (array2[j] && bigInteger >= array[j])
						{
							array2[j] = false;
							flag = true;
							++bigInteger;
						}
					}
				}
				while (flag);
				array[i] = bigInteger;
			}
			return array;
		}

		public static IEnumerable<T> SelectVariation<T>(this IEnumerable<T> data, int elementsToChoose, System.Random randomSource = null)
		{
			System.Random random = randomSource ?? SystemRandomSource.Default;
			T[] array = data.ToArray();
			if (elementsToChoose < 0)
			{
				throw new ArgumentOutOfRangeException("elementsToChoose", "Value must not be negative (zero is ok).");
			}
			if (elementsToChoose > array.Length)
			{
				throw new ArgumentOutOfRangeException("elementsToChoose", "elementsToChoose must be smaller than or equal to data.Count.");
			}
			for (int i = array.Length - 1; i >= array.Length - elementsToChoose; i--)
			{
				int swapIndex = random.Next(i + 1);
				yield return array[swapIndex];
				array[swapIndex] = array[i];
			}
		}

		public static int[] GenerateVariationWithRepetition(int n, int k, System.Random randomSource = null)
		{
			if (n < 0)
			{
				throw new ArgumentOutOfRangeException("n", "Value must not be negative (zero is ok).");
			}
			if (k < 0)
			{
				throw new ArgumentOutOfRangeException("k", "Value must not be negative (zero is ok).");
			}
			System.Random rnd = randomSource ?? SystemRandomSource.Default;
			int[] array = new int[k];
			rnd.NextInt32s(array, 0, n);
			return array;
		}

		public static IEnumerable<T> SelectVariationWithRepetition<T>(this IEnumerable<T> data, int elementsToChoose, System.Random randomSource = null)
		{
			if (elementsToChoose < 0)
			{
				throw new ArgumentOutOfRangeException("elementsToChoose", "Value must not be negative (zero is ok).");
			}
			T[] array = (data as T[]) ?? data.ToArray();
			int[] indices = GenerateVariationWithRepetition(array.Length, elementsToChoose, randomSource);
			for (int i = 0; i < indices.Length; i++)
			{
				yield return array[indices[i]];
			}
		}
	}
}
