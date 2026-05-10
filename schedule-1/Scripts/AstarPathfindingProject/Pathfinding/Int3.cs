using System;
using UnityEngine;

namespace Pathfinding
{
	public struct Int3 : IEquatable<Int3>
	{
		public int x;

		public int y;

		public int z;

		public const int Precision = 1000;

		public const float FloatPrecision = 1000f;

		public const float PrecisionFactor = 0.001f;

		public static Int3 zero => default(Int3);

		public int this[int i]
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float magnitude => 0f;

		public int costMagnitude => 0;

		public float sqrMagnitude => 0f;

		public long sqrMagnitudeLong => 0L;

		public Int3(Vector3 position)
		{
			x = 0;
			y = 0;
			z = 0;
		}

		public Int3(int _x, int _y, int _z)
		{
			x = 0;
			y = 0;
			z = 0;
		}

		public static bool operator ==(Int3 lhs, Int3 rhs)
		{
			return false;
		}

		public static bool operator !=(Int3 lhs, Int3 rhs)
		{
			return false;
		}

		public static explicit operator Int3(Vector3 ob)
		{
			return default(Int3);
		}

		public static explicit operator Vector3(Int3 ob)
		{
			return default(Vector3);
		}

		public static Int3 operator -(Int3 lhs, Int3 rhs)
		{
			return default(Int3);
		}

		public static Int3 operator -(Int3 lhs)
		{
			return default(Int3);
		}

		public static Int3 operator +(Int3 lhs, Int3 rhs)
		{
			return default(Int3);
		}

		public static Int3 operator *(Int3 lhs, int rhs)
		{
			return default(Int3);
		}

		public static Int3 operator *(Int3 lhs, float rhs)
		{
			return default(Int3);
		}

		public static Int3 operator *(Int3 lhs, double rhs)
		{
			return default(Int3);
		}

		public static Int3 operator /(Int3 lhs, float rhs)
		{
			return default(Int3);
		}

		public static float Angle(Int3 lhs, Int3 rhs)
		{
			return 0f;
		}

		public static int Dot(Int3 lhs, Int3 rhs)
		{
			return 0;
		}

		public static long DotLong(Int3 lhs, Int3 rhs)
		{
			return 0L;
		}

		public Int3 Normal2D()
		{
			return default(Int3);
		}

		public static implicit operator string(Int3 obj)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Int3 other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
