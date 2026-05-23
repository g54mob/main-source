using System;
using System.Linq;
using UnityEngine;

namespace Barmetler.RoadSystem.Util
{
	[Serializable]
	public class TwoDimensionalArray<T>
	{
		[SerializeField]
		private int width;

		[SerializeField]
		private int height;

		[SerializeField]
		private T[] array;

		public int Width => width;

		public int Height => height;

		public int Length => array.Length;

		public T this[int i]
		{
			get
			{
				return array[i];
			}
			set
			{
				array[i] = value;
			}
		}

		public T this[int x, int y]
		{
			get
			{
				return array[y * Width + x];
			}
			set
			{
				array[y * Width + x] = value;
			}
		}

		public T this[Vector2Int v]
		{
			get
			{
				return this[v.x, v.y];
			}
			set
			{
				this[v.x, v.y] = value;
			}
		}

		public T[] DirectArray => array;

		public TwoDimensionalArray(int width, int height)
		{
			array = new T[width * height];
			this.width = width;
			this.height = height;
		}

		public TwoDimensionalArray(T[,] arr)
		{
			width = arr.GetLength(0);
			height = arr.GetLength(1);
			array = new T[width * height];
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					this[j, i] = arr[j, i];
				}
			}
		}

		public TwoDimensionalArray<T> Clone()
		{
			return new TwoDimensionalArray<T>(Width, height)
			{
				array = array.ToArray()
			};
		}

		public void CopyInto(TwoDimensionalArray<T> other, Vector2Int dst_position, Vector2Int src_position)
		{
			CopyInto(other, dst_position, src_position, new Vector2Int(Width, Height));
		}

		public void CopyInto(TwoDimensionalArray<T> other, Vector2Int dst_position, Vector2Int src_position, Vector2Int size)
		{
			if (dst_position.x < 0 || dst_position.y < 0 || src_position.x < 0 || src_position.y < 0 || size.x < 1 || size.y < 1)
			{
				throw new ArgumentException("positions can't be negative, size must be positive");
			}
			int num = src_position.y;
			int num2 = dst_position.y;
			while (num < height && num < src_position.y + size.y && num2 < other.Height)
			{
				int num3 = src_position.x;
				int num4 = dst_position.x;
				while (num3 < width && num3 < src_position.x + size.x && num4 < other.Width)
				{
					other[num4, num2] = this[num3, num];
					num3++;
					num4++;
				}
				num++;
				num2++;
			}
		}

		public void CopyInto(T defaultValue, TwoDimensionalArray<T> other, Vector2Int dst_position, Vector2Int src_position)
		{
			CopyInto(defaultValue, other, dst_position, src_position, new Vector2Int(Width, Height));
		}

		public void CopyInto(T defaultValue, TwoDimensionalArray<T> other, Vector2Int dst_position, Vector2Int src_position, Vector2Int size)
		{
			if (dst_position.x < 0 || dst_position.y < 0 || src_position.x < 0 || src_position.y < 0 || size.x < 0 || size.y < 0)
			{
				throw new ArgumentException("positions and size can't be negative");
			}
			for (int i = 0; i < other.Height; i++)
			{
				for (int j = 0; j < other.Width; j++)
				{
					Vector2Int v = new Vector2Int(j, i) - dst_position + src_position;
					if (j < dst_position.x || j >= dst_position.x + size.x || i < dst_position.y || i >= dst_position.y + size.y || v.x < 0 || v.x >= width || v.y < 0 || v.y >= height)
					{
						other[j, i] = defaultValue;
					}
					else
					{
						other[j, i] = this[v];
					}
				}
			}
		}

		public override string ToString()
		{
			string text = "";
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					text += $"{this[j, i]}, ";
				}
				text += "\n";
			}
			return text;
		}

		public T[] ToArray()
		{
			return array.ToArray();
		}

		public T[,] ToMultiArray()
		{
			T[,] array = new T[width, height];
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					array[j, i] = this[j, i];
				}
			}
			return array;
		}

		public static implicit operator TwoDimensionalArray<T>(T[,] a)
		{
			return new TwoDimensionalArray<T>(a);
		}

		public static implicit operator T[,](TwoDimensionalArray<T> t)
		{
			return t.ToMultiArray();
		}
	}
}
