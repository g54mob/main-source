using System.Collections.Generic;

namespace NSMedieval.Extensions
{
	public static class ArrayExtensions
	{
		public static void FillArray<T>(ref T[,] arrayToFill, T value)
		{
			int length = arrayToFill.GetLength(0);
			int length2 = arrayToFill.GetLength(1);
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length2; j++)
				{
					arrayToFill[i, j] = value;
				}
			}
		}

		public static T[,] InitializeArray<T>(T[,] array, int newRowCount, int newColumnCount, T defaultValue = default(T))
		{
			if (array == null)
			{
				T[,] arrayToFill = new T[newRowCount, newColumnCount];
				if (!object.Equals(defaultValue, null))
				{
					FillArray(ref arrayToFill, defaultValue);
				}
				return arrayToFill;
			}
			int length = array.GetLength(0);
			int length2 = array.GetLength(1);
			if (length != newRowCount || length2 != newColumnCount)
			{
				array = new T[newRowCount, newColumnCount];
			}
			if (!object.Equals(defaultValue, null))
			{
				FillArray(ref array, defaultValue);
			}
			return array;
		}

		public static T[,] VerticalFlip<T>(this T[,] input)
		{
			int length = input.GetLength(0);
			int length2 = input.GetLength(1);
			for (int i = 0; i <= length2 - 1; i++)
			{
				int num = 0;
				int num2 = length - 1;
				while (num < num2)
				{
					T val = input[num, i];
					input[num, i] = input[num2, i];
					input[num2, i] = val;
					num++;
					num2--;
				}
			}
			return input;
		}

		public static T[,] RotateCounterClockwise<T>(this T[,] input)
		{
			T[,] array = new T[input.GetLength(1), input.GetLength(0)];
			int num = 0;
			for (int num2 = input.GetLength(1) - 1; num2 >= 0; num2--)
			{
				int num3 = 0;
				for (int i = 0; i < input.GetLength(0); i++)
				{
					array[num, num3] = input[i, num2];
					num3++;
				}
				num++;
			}
			return array;
		}

		public static T[,] Rotate180<T>(this T[,] input)
		{
			return input.RotateCounterClockwise().RotateCounterClockwise();
		}

		public static List<T> ConvertToList<T>(this T[,] input)
		{
			List<T> list = new List<T>();
			int length = input.GetLength(0);
			int length2 = input.GetLength(1);
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length2; j++)
				{
					list.Add(input[i, j]);
				}
			}
			return list;
		}

		public static bool InsideBounds<T>(this T[,] input, int i, int j)
		{
			if (i >= 0 && i < input.GetLength(0) && j >= 0)
			{
				return j < input.GetLength(1);
			}
			return false;
		}

		public static bool OutsideBounds<T>(this T[][][] input, int x, int y, int z)
		{
			if (x >= 0 && x < input.Length && y >= 0 && y < input[0].Length && z >= 0)
			{
				return z >= input[0][0].Length;
			}
			return true;
		}

		public static bool OutsideBounds<T>(this T[][][] input, Vec3Int position)
		{
			return input.OutsideBounds(position.x, position.y, position.z);
		}

		public static bool AllEquals<T>(this T[,] input, T equalTo)
		{
			for (int i = 0; i < input.GetLength(0); i++)
			{
				for (int j = 0; j < input.GetLength(1); j++)
				{
					if (!input[i, j].Equals(equalTo))
					{
						return false;
					}
				}
			}
			return true;
		}

		public static T[][] ConvertToJagged<T>(this T[,] input)
		{
			T[][] array = new T[input.GetLength(0)][];
			for (int i = 0; i < input.GetLength(0); i++)
			{
				array[i] = new T[input.GetLength(1)];
				for (int j = 0; j < input.GetLength(1); j++)
				{
					array[i][j] = input[i, j];
				}
			}
			return array;
		}

		public static T[,] ConvertTo2D<T>(this T[][] input)
		{
			T[,] array = new T[input.Length, input[0].Length];
			for (int i = 0; i < input.Length; i++)
			{
				for (int j = 0; j < input[0].Length; j++)
				{
					array[i, j] = input[i][j];
				}
			}
			return array;
		}
	}
}
