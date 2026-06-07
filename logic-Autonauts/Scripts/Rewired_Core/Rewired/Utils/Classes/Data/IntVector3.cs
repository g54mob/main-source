using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	public class IntVector3
	{
		public int x;

		public int y;

		public int z;

		public IntVector3()
		{
			while (true)
			{
				int num = 576253729;
				while (true)
				{
					switch (num ^ 0x2258EF20)
					{
					case 2:
						break;
					case 1:
						goto IL_0024;
					default:
						y = 0;
						z = 0;
						return;
					}
					break;
					IL_0024:
					x = 0;
					num = 576253728;
				}
			}
		}

		public IntVector3(int inX, int inY, int inZ)
		{
			while (true)
			{
				int num = 117960258;
				while (true)
				{
					switch (num ^ 0x707EE43)
					{
					case 2:
						break;
					case 1:
						goto IL_0024;
					default:
						y = inY;
						z = inZ;
						return;
					}
					break;
					IL_0024:
					x = inX;
					num = 117960259;
				}
			}
		}

		public IntVector3 Clone()
		{
			return new IntVector3(x, y, z);
		}

		public static IntVector3 operator +(IntVector3 value1, IntVector3 value2)
		{
			return new IntVector3(value1.x + value2.x, value1.y + value2.y, value1.z + value2.z);
		}

		public static IntVector3 operator -(IntVector3 value1, IntVector3 value2)
		{
			return new IntVector3(value1.x - value2.x, value1.y - value2.y, value1.z - value2.z);
		}

		public static IntVector3 operator *(IntVector3 value1, IntVector3 value2)
		{
			return new IntVector3(value1.x * value2.x, value1.y * value2.y, value1.z * value2.z);
		}

		public static IntVector3 operator /(IntVector3 value1, IntVector3 value2)
		{
			return new IntVector3(value1.x / value2.x, value1.y / value2.y, value1.z / value2.z);
		}

		public static IntVector3 operator +(IntVector3 value1, int value2)
		{
			return new IntVector3(value1.x + value2, value1.y + value2, value1.z + value2);
		}

		public static IntVector3 operator -(IntVector3 value1, int value2)
		{
			return new IntVector3(value1.x - value2, value1.y - value2, value1.z - value2);
		}

		public static IntVector3 operator *(IntVector3 value1, int value2)
		{
			return new IntVector3(value1.x * value2, value1.y * value2, value1.z * value2);
		}

		public static IntVector3 operator /(IntVector3 value1, int value2)
		{
			return new IntVector3(value1.x / value2, value1.y / value2, value1.z / value2);
		}

		public static Vector3 operator +(IntVector3 value1, float value2)
		{
			return new Vector3((float)value1.x + value2, (float)value1.y + value2, (float)value1.z + value2);
		}

		public static Vector3 operator -(IntVector3 value1, float value2)
		{
			return new Vector3((float)value1.x - value2, (float)value1.y - value2, (float)value1.z - value2);
		}

		public static Vector3 operator *(IntVector3 value1, float value2)
		{
			return new Vector3((float)value1.x * value2, (float)value1.y * value2, (float)value1.z * value2);
		}

		public static Vector3 operator /(IntVector3 value1, float value2)
		{
			return new Vector3((float)value1.x / value2, (float)value1.y / value2, (float)value1.z / value2);
		}
	}
}
