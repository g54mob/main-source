using System;
using UnityEngine;

namespace Os.Utils
{
	[Serializable]
	public struct ByteFloat3
	{
		public byte x;

		public byte y;

		public byte z;

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

		public byte Item
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

		public ByteFloat3(float fx, float fy, float fz)
		{
			x = 0;
			y = 0;
			z = 0;
		}

		public static explicit operator Vector3(ByteFloat3 b)
		{
			return default(Vector3);
		}

		public static explicit operator ByteFloat3(Vector3 f)
		{
			return default(ByteFloat3);
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public static bool operator ==(ByteFloat3 a, ByteFloat3 b)
		{
			return false;
		}

		public static bool operator !=(ByteFloat3 a, ByteFloat3 b)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
