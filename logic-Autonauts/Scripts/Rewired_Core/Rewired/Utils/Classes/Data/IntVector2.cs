using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	public class IntVector2
	{
		public int x;

		public int y;

		public IntVector2()
		{
			while (true)
			{
				int num = -425032674;
				while (true)
				{
					switch (num ^ -425032673)
					{
					case 2:
						break;
					case 1:
						goto IL_0024;
					default:
						y = 0;
						return;
					}
					break;
					IL_0024:
					x = 0;
					num = -425032673;
				}
			}
		}

		public IntVector2(int inX, int inY)
		{
			x = inX;
			y = inY;
		}

		public IntVector2 Clone()
		{
			return new IntVector2(x, y);
		}

		public static IntVector2 Clone(IntVector2 intVector2)
		{
			if (intVector2 == null)
			{
				return null;
			}
			return intVector2.Clone();
		}

		public static IntVector2 operator +(IntVector2 value1, IntVector2 value2)
		{
			return new IntVector2(value1.x + value2.x, value1.y + value2.y);
		}

		public static IntVector2 operator -(IntVector2 value1, IntVector2 value2)
		{
			return new IntVector2(value1.x - value2.x, value1.y - value2.y);
		}

		public static IntVector2 operator *(IntVector2 value1, IntVector2 value2)
		{
			return new IntVector2(value1.x * value2.x, value1.y * value2.y);
		}

		public static IntVector2 operator /(IntVector2 value1, IntVector2 value2)
		{
			return new IntVector2(value1.x / value2.x, value1.y / value2.y);
		}

		public static IntVector2 operator +(IntVector2 value1, int value2)
		{
			return new IntVector2(value1.x + value2, value1.y + value2);
		}

		public static IntVector2 operator -(IntVector2 value1, int value2)
		{
			return new IntVector2(value1.x - value2, value1.y - value2);
		}

		public static IntVector2 operator *(IntVector2 value1, int value2)
		{
			return new IntVector2(value1.x * value2, value1.y * value2);
		}

		public static IntVector2 operator /(IntVector2 value1, int value2)
		{
			return new IntVector2(value1.x / value2, value1.y / value2);
		}

		public static Vector2 operator +(IntVector2 value1, float value2)
		{
			return new Vector2((float)value1.x + value2, (float)value1.y + value2);
		}

		public static Vector2 operator -(IntVector2 value1, float value2)
		{
			return new Vector2((float)value1.x - value2, (float)value1.y - value2);
		}

		public static Vector2 operator *(IntVector2 value1, float value2)
		{
			return new Vector2((float)value1.x * value2, (float)value1.y * value2);
		}

		public static Vector2 operator /(IntVector2 value1, float value2)
		{
			return new Vector2((float)value1.x / value2, (float)value1.y / value2);
		}
	}
}
