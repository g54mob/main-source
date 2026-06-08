using System;
using Unity.Mathematics;
using UnityEngine;

namespace Kitchen
{
	public struct IntVector3 : IEquatable<IntVector3>
	{
		public int x;

		public int y;

		public int z;

		public bool IsZero
		{
			get
			{
				if (x == 0 && y == 0)
				{
					return z == 0;
				}
				return false;
			}
		}

		public IntVector3(Vector3 vec)
		{
			x = Mathf.RoundToInt(vec.x);
			y = Mathf.RoundToInt(vec.y);
			z = Mathf.RoundToInt(vec.z);
		}

		public IntVector3(int a_x, int a_y, int a_z)
		{
			x = a_x;
			y = a_y;
			z = a_z;
		}

		public static implicit operator IntVector3(CPosition p)
		{
			return new IntVector3(p);
		}

		public static implicit operator IntVector3(Vector3 v)
		{
			return new IntVector3(v);
		}

		public static implicit operator IntVector3(float3 v)
		{
			return new IntVector3(v);
		}

		public static implicit operator Vector3(IntVector3 v)
		{
			return new Vector3(v.x, v.y, v.z);
		}

		public static IntVector3 operator +(IntVector3 a, IntVector3 b)
		{
			return new IntVector3(a.x + b.x, a.y + b.y, a.z + b.z);
		}

		public static IntVector3 operator -(IntVector3 a, IntVector3 b)
		{
			return new IntVector3(a.x - b.x, a.y - b.y, a.z - b.z);
		}

		public bool Equals(IntVector3 other)
		{
			if (x == other.x && y == other.y)
			{
				return z == other.z;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is IntVector3 other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (((x * 397) ^ y) * 397) ^ z;
		}

		public static bool operator ==(IntVector3 left, IntVector3 right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(IntVector3 left, IntVector3 right)
		{
			return !left.Equals(right);
		}
	}
}
