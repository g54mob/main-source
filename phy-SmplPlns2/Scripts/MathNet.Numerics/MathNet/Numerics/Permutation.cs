using System;

namespace MathNet.Numerics
{
	[Serializable]
	public class Permutation
	{
		private readonly int[] _indices;

		public int Dimension => _indices.Length;

		public int this[int idx] => _indices[idx];

		public Permutation(int[] indices)
		{
			if (!CheckForProperPermutation(indices))
			{
				throw new ArgumentException("The integer array does not represent a valid permutation.", "indices");
			}
			_indices = (int[])indices.Clone();
		}

		public Permutation Inverse()
		{
			int[] array = new int[Dimension];
			for (int i = 0; i < array.Length; i++)
			{
				array[_indices[i]] = i;
			}
			return new Permutation(array);
		}

		public static Permutation FromInversions(int[] inv)
		{
			int[] array = new int[inv.Length];
			for (int i = 0; i < inv.Length; i++)
			{
				array[i] = i;
			}
			for (int num = inv.Length - 1; num >= 0; num--)
			{
				if (array[num] != inv[num])
				{
					ref int reference = ref array[num];
					ref int reference2 = ref array[inv[num]];
					int num2 = array[inv[num]];
					int num3 = array[num];
					reference = num2;
					reference2 = num3;
				}
			}
			return new Permutation(array);
		}

		public int[] ToInversions()
		{
			int[] array = (int[])_indices.Clone();
			int i;
			for (i = 0; i < array.Length; i++)
			{
				if (array[i] != i)
				{
					int num = Array.FindIndex(array, i + 1, (int x) => x == i);
					int num2 = array[i];
					array[i] = num;
					array[num] = num2;
				}
			}
			return array;
		}

		private static bool CheckForProperPermutation(int[] indices)
		{
			bool[] array = new bool[indices.Length];
			for (int i = 0; i < indices.Length; i++)
			{
				if (indices[i] >= indices.Length || indices[i] < 0)
				{
					return false;
				}
				array[indices[i]] = true;
			}
			for (int j = 0; j < indices.Length; j++)
			{
				if (!array[j])
				{
					return false;
				}
			}
			return true;
		}
	}
}
