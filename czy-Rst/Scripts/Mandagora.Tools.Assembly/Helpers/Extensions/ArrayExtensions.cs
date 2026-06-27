using UnityEngine;

namespace Helpers.Extensions
{
	public static class ArrayExtensions
	{
		public static bool[,] PrepareBuildMaskMatrix(this bool[,] mask)
		{
			bool[,] array = new bool[mask.GetLength(0), mask.GetLength(1)];
			int length = mask.GetLength(1);
			for (int i = 0; i < mask.GetLength(0); i++)
			{
				for (int j = 0; j < length; j++)
				{
					array[i, length - j - 1] = mask[i, j];
				}
			}
			return array.RotateMatrix(270f);
		}

		public static T[,] RotateMatrix<T>(this T[,] instance)
		{
			int length = instance.GetLength(1);
			int length2 = instance.GetLength(0);
			T[,] array = new T[length, length2];
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length2; j++)
				{
					array[i, j] = instance[length2 - j - 1, i];
				}
			}
			return array;
		}

		public static T[,] RotateMatrix<T>(this T[,] instance, float angle)
		{
			int num = Mathf.Abs((int)angle / 90);
			for (int i = 0; i < num; i++)
			{
				instance = instance.RotateMatrix();
			}
			return instance;
		}

		public static T[,,] RotateMatrix<T>(this T[,,] instance)
		{
			int length = instance.GetLength(2);
			int length2 = instance.GetLength(1);
			int length3 = instance.GetLength(0);
			T[,,] array = new T[length, length2, length3];
			T[,] array2 = new T[instance.GetLength(0), instance.GetLength(2)];
			for (int i = 0; i < length2; i++)
			{
				for (int j = 0; j < instance.GetLength(0); j++)
				{
					for (int k = 0; k < instance.GetLength(2); k++)
					{
						array2[j, k] = instance[j, i, k];
					}
				}
				T[,] array3 = array2.RotateMatrix();
				for (int l = 0; l < array.GetLength(0); l++)
				{
					for (int m = 0; m < array.GetLength(2); m++)
					{
						array[l, i, m] = array3[l, m];
					}
				}
			}
			return array;
		}

		public static T[,,] RotateMatrix<T>(this T[,,] instance, float angle)
		{
			int num = Mathf.Abs((int)angle / 90);
			for (int i = 0; i < num; i++)
			{
				instance = instance.RotateMatrix();
			}
			return instance;
		}

		public static bool ContainsAnyNullRef<T>(this T[] instance)
		{
			int length = instance.GetLength(0);
			for (int i = 0; i < length; i++)
			{
				if (instance[i] == null)
				{
					return true;
				}
			}
			return false;
		}

		public static bool ContainsAnyNullRef<T>(this T[,] instance)
		{
			int length = instance.GetLength(0);
			int length2 = instance.GetLength(1);
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length2; j++)
				{
					if (instance[i, j] == null)
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool ContainsAnyNullRef<T>(this T[,,] instance)
		{
			int length = instance.GetLength(0);
			int length2 = instance.GetLength(1);
			int length3 = instance.GetLength(2);
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length2; j++)
				{
					for (int k = 0; k < length3; k++)
					{
						if (instance[i, j, k] == null)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public static void CleanCollection<T>(this T[] collection) where T : class
		{
			if (collection != null)
			{
				for (int i = 0; i < collection.Length; i++)
				{
					collection[i] = null;
				}
			}
		}

		public static void SetAllDefault<T>(this T[] collection)
		{
			if (collection != null)
			{
				for (int i = 0; i < collection.Length; i++)
				{
					collection[i] = default(T);
				}
			}
		}

		public static void CleanCollection<T>(this T[,] collection) where T : class
		{
			if (collection == null)
			{
				return;
			}
			for (int i = 0; i < collection.GetLength(0); i++)
			{
				for (int j = 0; j < collection.GetLength(1); j++)
				{
					collection[i, j] = null;
				}
			}
		}

		public static void CleanCollection<T>(this T[,,] collection) where T : class
		{
			if (collection == null)
			{
				return;
			}
			for (int i = 0; i < collection.GetLength(0); i++)
			{
				for (int j = 0; j < collection.GetLength(1); j++)
				{
					for (int k = 0; k < collection.GetLength(2); k++)
					{
						collection[i, j, k] = null;
					}
				}
			}
		}

		public static bool IsInDimensions<T>(this T[] collection, int index) where T : class
		{
			if (index >= 0)
			{
				return index < collection.GetLength(0);
			}
			return false;
		}

		public static bool IsInDimensions<T>(this T[,] collection, Vector2Int indexes) where T : class
		{
			if (indexes.x >= 0 && indexes.x < collection.GetLength(0) && indexes.y >= 0)
			{
				return indexes.y < collection.GetLength(1);
			}
			return false;
		}

		public static bool IsInDimensions<T>(this T[,,] collection, Vector3Int indexes) where T : class
		{
			if (indexes.x >= 0 && indexes.x < collection.GetLength(0) && indexes.y >= 0 && indexes.y < collection.GetLength(1) && indexes.z >= 0)
			{
				return indexes.z < collection.GetLength(2);
			}
			return false;
		}
	}
}
