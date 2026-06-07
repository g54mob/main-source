using System;
using Unity.Mathematics;
using UnityEngine;

namespace Jundroo.Common.Math
{
	public struct Vector4m : IEquatable<Vector4m>
	{
		public decimal x;

		public decimal y;

		public decimal z;

		public decimal w;

		public unsafe decimal this[int i]
		{
			get
			{
				if (i < 0 || i > 3)
				{
					throw new IndexOutOfRangeException($"Index {i} is out of range of Vector4m");
				}
				fixed (decimal* ptr = &x)
				{
					return ptr[i];
				}
			}
			set
			{
				if (i < 0 || i > 3)
				{
					throw new IndexOutOfRangeException($"Index {i} is out of range of Vector4m");
				}
				fixed (decimal* ptr = &x)
				{
					ptr[i] = value;
				}
			}
		}

		public Vector4m(decimal x, decimal y, decimal z, decimal w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		public static explicit operator float4(Vector4m vector)
		{
			return new float4((float)vector.x, (float)vector.y, (float)vector.z, (float)vector.w);
		}

		public static explicit operator Vector4(Vector4m vector)
		{
			return new Vector4((float)vector.x, (float)vector.y, (float)vector.z, (float)vector.w);
		}

		public static explicit operator Vector4m(Vector4 vector)
		{
			return new Vector4m((decimal)vector.x, (decimal)vector.y, (decimal)vector.z, (decimal)vector.w);
		}

		public static bool operator ==(Vector4m lhs, Vector4m rhs)
		{
			if (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z)
			{
				return lhs.w == rhs.w;
			}
			return false;
		}

		public static bool operator !=(Vector4m lhs, Vector4m rhs)
		{
			if (!(lhs.x != rhs.x) && !(lhs.y != rhs.y) && !(lhs.z != rhs.z))
			{
				return lhs.w != rhs.w;
			}
			return true;
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector4m vector4m)
			{
				return this == vector4m;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (((17 * 23 + x.GetHashCode()) * 23 + y.GetHashCode()) * 23 + z.GetHashCode()) * 23 + w.GetHashCode();
		}

		public bool Equals(Vector4m other)
		{
			return this == other;
		}
	}
}
