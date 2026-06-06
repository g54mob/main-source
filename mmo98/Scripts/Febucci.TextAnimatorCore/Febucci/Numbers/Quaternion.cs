using System;
using UnityEngine;

namespace Febucci.Numbers
{
	public struct Quaternion : IEquatable<Quaternion>
	{
		private const float TOLERANCE = 1E-06f;

		public static readonly Quaternion Identity = new Quaternion(0f, 0f, 0f, 1f);

		private UnityEngine.Quaternion _native;

		public float magnitude => (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W);

		public Quaternion normalized
		{
			get
			{
				float num = magnitude;
				if (num < 1E-06f)
				{
					return Identity;
				}
				return new Quaternion(X / num, Y / num, Z / num, W / num);
			}
		}

		public Vector3 eulerAngles
		{
			get
			{
				Vector3 result = default(Vector3);
				float num = 2f * (W * X + Y * Z);
				float num2 = 1f - 2f * (X * X + Y * Y);
				result.X = (float)Math.Atan2(num, num2) * (180f / MathF.PI);
				float num3 = 2f * (W * Y - Z * X);
				if (Math.Abs(num3) >= 1f)
				{
					result.Y = (float)(Math.PI / 2.0 * (double)Math.Sign(num3)) * (180f / MathF.PI);
				}
				else
				{
					result.Y = (float)Math.Asin(num3) * (180f / MathF.PI);
				}
				float num4 = 2f * (W * Z + X * Y);
				float num5 = 1f - 2f * (Y * Y + Z * Z);
				result.Z = (float)Math.Atan2(num4, num5) * (180f / MathF.PI);
				return result;
			}
		}

		public float X
		{
			get
			{
				return _native.x;
			}
			set
			{
				_native.x = value;
			}
		}

		public float Y
		{
			get
			{
				return _native.y;
			}
			set
			{
				_native.y = value;
			}
		}

		public float Z
		{
			get
			{
				return _native.z;
			}
			set
			{
				_native.z = value;
			}
		}

		public float W
		{
			get
			{
				return _native.w;
			}
			set
			{
				_native.w = value;
			}
		}

		public static Quaternion operator *(in Quaternion q1, in Quaternion q2)
		{
			return new Quaternion(q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y, q1.W * q2.Y + q1.Y * q2.W + q1.Z * q2.X - q1.X * q2.Z, q1.W * q2.Z + q1.Z * q2.W + q1.X * q2.Y - q1.Y * q2.X, q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z);
		}

		public override bool Equals(object obj)
		{
			if (obj is Quaternion b)
			{
				return this == b;
			}
			return false;
		}

		public bool Equals(Quaternion other)
		{
			if (Math.Abs(X - other.X) < 1E-06f && Math.Abs(Y - other.Y) < 1E-06f && Math.Abs(Z - other.Z) < 1E-06f)
			{
				return Math.Abs(W - other.W) < 1E-06f;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (X, Y, Z, W).GetHashCode();
		}

		public override string ToString()
		{
			return $"({X}, {Y}, {Z}, {W})";
		}

		public static Quaternion Euler(float x, float y, float z)
		{
			float num = x * (MathF.PI / 180f);
			float num2 = y * (MathF.PI / 180f);
			float num3 = z * (MathF.PI / 180f);
			float num4 = (float)Math.Cos(num * 0.5f);
			float num5 = (float)Math.Sin(num * 0.5f);
			float num6 = (float)Math.Cos(num2 * 0.5f);
			float num7 = (float)Math.Sin(num2 * 0.5f);
			float num8 = (float)Math.Cos(num3 * 0.5f);
			float num9 = (float)Math.Sin(num3 * 0.5f);
			return new Quaternion(num5 * num6 * num8 - num4 * num7 * num9, num4 * num7 * num8 + num5 * num6 * num9, num4 * num6 * num9 - num5 * num7 * num8, num4 * num6 * num8 + num5 * num7 * num9);
		}

		public static Quaternion Euler(Vector3 eulerAngles)
		{
			return Euler(eulerAngles.X, eulerAngles.Y, eulerAngles.Z);
		}

		public Quaternion(float x, float y, float z, float w)
		{
			_native = new UnityEngine.Quaternion(x, y, z, w);
		}

		public Quaternion(UnityEngine.Quaternion nativeQuaternion)
		{
			_native = nativeQuaternion;
		}

		public static implicit operator UnityEngine.Quaternion(Quaternion q)
		{
			return q._native;
		}

		public static implicit operator Quaternion(UnityEngine.Quaternion q)
		{
			return new Quaternion(q);
		}

		public static Quaternion operator *(in Quaternion a, float d)
		{
			return new Quaternion(a._native.x * d, a._native.y * d, a._native.z * d, a._native.w * d);
		}

		public static Quaternion operator *(float d, in Quaternion a)
		{
			return new Quaternion(d * a._native.x, d * a._native.y, d * a._native.z, d * a._native.w);
		}

		public static Quaternion operator *(in Quaternion a, int d)
		{
			return new Quaternion(a._native.x * (float)d, a._native.y * (float)d, a._native.z * (float)d, a._native.w * (float)d);
		}

		public static Quaternion operator *(int d, in Quaternion a)
		{
			return new Quaternion((float)d * a._native.x, (float)d * a._native.y, (float)d * a._native.z, (float)d * a._native.w);
		}

		public static Quaternion operator /(in Quaternion a, float d)
		{
			return new Quaternion(a._native.x / d, a._native.y / d, a._native.z / d, a._native.w / d);
		}

		public static Quaternion operator /(in Quaternion a, int d)
		{
			return new Quaternion(a._native.x / (float)d, a._native.y / (float)d, a._native.z / (float)d, a._native.w / (float)d);
		}

		public static bool operator ==(in Quaternion a, in Quaternion b)
		{
			if (a._native.x == b._native.x && a._native.y == b._native.y && a._native.z == b._native.z)
			{
				return a._native.w == b._native.w;
			}
			return false;
		}

		public static bool operator !=(in Quaternion a, in Quaternion b)
		{
			return !(a == b);
		}

		public static Quaternion operator *(in Quaternion a, in UnityEngine.Quaternion b)
		{
			return a * (Quaternion)b;
		}

		public static Quaternion operator *(in UnityEngine.Quaternion a, in Quaternion b)
		{
			return (Quaternion)a * b;
		}

		public static bool operator ==(in Quaternion a, in UnityEngine.Quaternion b)
		{
			return a == (Quaternion)b;
		}

		public static bool operator ==(in UnityEngine.Quaternion a, in Quaternion b)
		{
			return (Quaternion)a == b;
		}

		public static bool operator !=(in Quaternion a, in UnityEngine.Quaternion b)
		{
			return a != (Quaternion)b;
		}

		public static bool operator !=(in UnityEngine.Quaternion a, in Quaternion b)
		{
			return (Quaternion)a != b;
		}
	}
}
