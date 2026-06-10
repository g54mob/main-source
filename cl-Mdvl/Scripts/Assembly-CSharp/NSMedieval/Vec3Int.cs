using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	[FVSerializableKey("Vec3Int", "")]
	public struct Vec3Int : IEquatable<Vec3Int>, IFVSerializable
	{
		private static readonly Vec3Int sZero = new Vec3Int(0, 0, 0);

		private static readonly Vec3Int sOne = new Vec3Int(1, 1, 1);

		private static readonly Vec3Int sUp = new Vec3Int(0, 1, 0);

		private static readonly Vec3Int sDown = new Vec3Int(0, -1, 0);

		private static readonly Vec3Int sLeft = new Vec3Int(-1, 0, 0);

		private static readonly Vec3Int sRight = new Vec3Int(1, 0, 0);

		private static readonly Vec3Int sForward = new Vec3Int(0, 0, 1);

		private static readonly Vec3Int sBack = new Vec3Int(0, 0, -1);

		[SerializeField]
		public int x;

		[SerializeField]
		public int y;

		[SerializeField]
		public int z;

		private static Type vec3IntType = typeof(Vec3Int);

		private static Type vector3IntType = typeof(Vector3Int);

		public float magnitude => Mathf.Sqrt(x * x + y * y + z * z);

		public int sqrMagnitude => x * x + y * y + z * z;

		public static Vec3Int zero => sZero;

		public static Vec3Int one => sOne;

		public static Vec3Int up => sUp;

		public static Vec3Int down => sDown;

		public static Vec3Int left => sLeft;

		public static Vec3Int right => sRight;

		public static Vec3Int forward => sForward;

		public static Vec3Int back => sBack;

		public Vec3Int(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return x ^ (y << 4) ^ (y >> 28) ^ (z >> 4) ^ (z << 28);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj.GetType() == vec3IntType)
			{
				return Equals((Vec3Int)obj);
			}
			if (obj.GetType() == vector3IntType)
			{
				return Equals((Vector3Int)obj);
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Vec3Int vec3Int)
		{
			if (vec3Int.x == x && vec3Int.y == y)
			{
				return vec3Int.z == z;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(in Vector3Int vec3Int)
		{
			if (vec3Int.x == x && vec3Int.y == y)
			{
				return vec3Int.z == z;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly float Distance(in Vec3Int other)
		{
			return Distance(in this, in other);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly float DistanceSquared(in Vec3Int other)
		{
			return DistanceSquared(in this, in other);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Distance(in Vec3Int a, in Vec3Int b)
		{
			return (a - b).magnitude;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int DistanceSquared(in Vec3Int a, in Vec3Int b)
		{
			int num = a.x - b.x;
			int num2 = a.y - b.y;
			int num3 = a.z - b.z;
			return num * num + num2 * num2 + num3 * num3;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int DistanceSquaredY3(in Vec3Int a, in Vec3Int b)
		{
			int num = a.x - b.x;
			int num2 = (a.y - b.y) * 3;
			int num3 = a.z - b.z;
			return num * num + num2 * num2 + num3 * num3;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Distance(in Vector3 a, in Vec3Int b)
		{
			return Distance(in b, in a);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Distance(in Vec3Int a, in Vector3 b)
		{
			float num = (float)a.x - b.x;
			float num2 = (float)a.y - b.y;
			float num3 = (float)a.z - b.z;
			return (float)Math.Sqrt((double)num * (double)num + (double)num2 * (double)num2 + (double)num3 * (double)num3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vec3Int FloorToInt(in Vector3 v)
		{
			return new Vec3Int(Mathf.FloorToInt(v.x), Mathf.FloorToInt(v.y), Mathf.FloorToInt(v.z));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vec3Int CeilToInt(in Vector3 v)
		{
			return new Vec3Int(Mathf.CeilToInt(v.x), Mathf.CeilToInt(v.y), Mathf.CeilToInt(v.z));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vec3Int RoundToInt(in Vector3 v)
		{
			return new Vec3Int(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y), Mathf.RoundToInt(v.z));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vec3Int operator +(in Vec3Int a, in Vec3Int b)
		{
			return new Vec3Int(a.x + b.x, a.y + b.y, a.z + b.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vec3Int operator +(in Vec3Int a, in Vector3 b)
		{
			return new Vec3Int(Mathf.RoundToInt((float)a.x + b.x), Mathf.RoundToInt((float)a.y + b.y), Mathf.RoundToInt((float)a.z + b.z));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vec3Int operator -(in Vec3Int a, in Vec3Int b)
		{
			return new Vec3Int(a.x - b.x, a.y - b.y, a.z - b.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vec3Int operator *(in Vec3Int a, in Vec3Int b)
		{
			return new Vec3Int(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vec3Int operator -(in Vec3Int a)
		{
			return new Vec3Int(-a.x, -a.y, -a.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vec3Int operator *(in Vec3Int a, int b)
		{
			return new Vec3Int(a.x * b, a.y * b, a.z * b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vec3Int operator *(int a, in Vec3Int b)
		{
			return new Vec3Int(a * b.x, a * b.y, a * b.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vec3Int operator *(in Vec3Int a, float b)
		{
			return new Vec3Int(Mathf.RoundToInt((float)a.x * b), Mathf.RoundToInt((float)a.y * b), Mathf.RoundToInt((float)a.z * b));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vec3Int operator *(float a, in Vec3Int b)
		{
			return new Vec3Int(Mathf.RoundToInt(a * (float)b.x), Mathf.RoundToInt(a * (float)b.y), Mathf.RoundToInt(a * (float)b.z));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vec3Int operator /(in Vec3Int a, int b)
		{
			return new Vec3Int(a.x / b, a.y / b, a.z / b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vec3Int operator /(in Vec3Int a, in Vec3Int b)
		{
			return new Vec3Int(a.x / b.x, a.y / b.y, a.z / b.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(in Vec3Int lhs, in Vec3Int rhs)
		{
			if (lhs.x == rhs.x && lhs.y == rhs.y)
			{
				return lhs.z == rhs.z;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(in Vec3Int lhs, in Vec3Int rhs)
		{
			return !(lhs == rhs);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vec3Int Scale(in Vec3Int a, in Vec3Int b)
		{
			return new Vec3Int(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vec3Int Min(in Vec3Int lhs, in Vec3Int rhs)
		{
			return new Vec3Int(Mathf.Min(lhs.x, rhs.x), Mathf.Min(lhs.y, rhs.y), Mathf.Min(lhs.z, rhs.z));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vec3Int Max(in Vec3Int lhs, in Vec3Int rhs)
		{
			return new Vec3Int(Mathf.Max(lhs.x, rhs.x), Mathf.Max(lhs.y, rhs.y), Mathf.Max(lhs.z, rhs.z));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Scale(in Vec3Int scale)
		{
			x *= scale.x;
			y *= scale.y;
			z *= scale.z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clamp(in Vec3Int min, in Vec3Int max)
		{
			x = Math.Max(min.x, x);
			x = Math.Min(max.x, x);
			y = Math.Max(min.y, y);
			y = Math.Min(max.y, y);
			z = Math.Max(min.z, z);
			z = Math.Min(max.z, z);
		}

		public static explicit operator Vector3(Vec3Int value)
		{
			return new Vector3(value.x, value.y, value.z);
		}

		public static explicit operator Vec3Int(Vector3 value)
		{
			return new Vec3Int(Mathf.RoundToInt(value.x), Mathf.RoundToInt(value.y), Mathf.RoundToInt(value.z));
		}

		public bool IsZero()
		{
			if (x == 0 && y == 0)
			{
				return z == 0;
			}
			return false;
		}

		public override string ToString()
		{
			return $"[X:{x}, Y:{y}, Z:{z}]";
		}

		public string ToStringWithLink()
		{
			return ToString();
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("x", x);
			serializer.Write("y", y);
			serializer.Write("z", z);
		}

		public Vec3Int(FVDeserializer deserializer)
		{
			x = deserializer.ReadInt("x");
			y = deserializer.ReadInt("y");
			z = deserializer.ReadInt("z");
		}

		public static void GetBounds(List<Vec3Int> positions, out Vec3Int min, out Vec3Int max)
		{
			if (positions == null || positions.Count == 0)
			{
				min = zero;
				max = zero;
				return;
			}
			min = positions[0];
			max = positions[0];
			if (positions.Count > 0)
			{
				for (int i = 1; i < positions.Count; i++)
				{
					min = Min(positions[i], in min);
					max = Max(positions[i], in max);
				}
			}
		}
	}
}
