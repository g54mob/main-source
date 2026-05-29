using System;
using Unity.Mathematics;
using UnityEngine;

namespace Os.Utils
{
	[Serializable]
	public struct SbyteFloat3
	{
		public const int max = 254;

		public const float maxf = 254f;

		public sbyte x;

		public sbyte y;

		public sbyte z;

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

		public float fz
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public sbyte Item
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Vector3 normal => default(Vector3);

		public SbyteFloat3(float fx, float fy, float fz)
		{
			x = 0;
			y = 0;
			z = 0;
		}

		public SbyteFloat3(int x, int y, int z)
		{
			this.x = 0;
			this.y = 0;
			this.z = 0;
		}

		public static explicit operator Vector3(SbyteFloat3 b)
		{
			return default(Vector3);
		}

		public static explicit operator float3(SbyteFloat3 b)
		{
			return default(float3);
		}

		public static explicit operator int3(SbyteFloat3 b)
		{
			return default(int3);
		}

		public static explicit operator SbyteFloat3(Vector3 f)
		{
			return default(SbyteFloat3);
		}

		public static explicit operator SbyteFloat3(int3 f)
		{
			return default(SbyteFloat3);
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public static bool operator ==(SbyteFloat3 a, SbyteFloat3 b)
		{
			return false;
		}

		public static bool operator !=(SbyteFloat3 a, SbyteFloat3 b)
		{
			return false;
		}

		public static SbyteFloat3 operator *(int3x3 a, SbyteFloat3 b)
		{
			return default(SbyteFloat3);
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
