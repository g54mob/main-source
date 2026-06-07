using System;
using Unity.Mathematics;
using UnityEngine;

namespace Os.Utils
{
	[Serializable]
	public struct ByteFloat2
	{
		public byte x;

		public byte y;

		public float fx
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float fy
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public ByteFloat2(float fx, float fy)
		{
			x = 0;
			y = 0;
		}

		public static explicit operator Vector2(ByteFloat2 b)
		{
			return default(Vector2);
		}

		public static explicit operator int2(ByteFloat2 b)
		{
			return default(int2);
		}

		public static explicit operator ByteFloat2(Vector2 f)
		{
			return default(ByteFloat2);
		}

		public static explicit operator ByteFloat2(int2 f)
		{
			return default(ByteFloat2);
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public static bool operator ==(ByteFloat2 a, ByteFloat2 b)
		{
			return false;
		}

		public static bool operator !=(ByteFloat2 a, ByteFloat2 b)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
