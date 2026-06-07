using System;
using UnityEngine;

namespace FixMath
{
	public struct Vector2Fixed : IEquatable<Vector2Fixed>
	{
		public static readonly Fix64 kEpsilon = (Fix64)1E-05f;

		public Fix64 x;

		public Fix64 y;

		private static readonly Vector2Fixed zeroVector = new Vector2Fixed(Fix64.Zero, Fix64.Zero);

		private static readonly Vector2Fixed oneVector = new Vector2Fixed(Fix64.One, Fix64.One);

		private static readonly Vector2Fixed upVector = new Vector2Fixed(Fix64.Zero, Fix64.One);

		private static readonly Vector2Fixed downVector = new Vector2Fixed(Fix64.Zero, -Fix64.One);

		private static readonly Vector2Fixed leftVector = new Vector2Fixed(-Fix64.One, Fix64.Zero);

		private static readonly Vector2Fixed rightVector = new Vector2Fixed(Fix64.One, Fix64.Zero);

		public Fix64 this[int index]
		{
			get
			{
				return index switch
				{
					0 => x, 
					1 => y, 
					_ => throw new IndexOutOfRangeException("Invalid Vector2 index!"), 
				};
			}
			set
			{
				switch (index)
				{
				case 0:
					x = value;
					break;
				case 1:
					y = value;
					break;
				default:
					throw new IndexOutOfRangeException("Invalid Vector2 index!");
				}
			}
		}

		public Vector2Fixed normalized
		{
			get
			{
				Vector2Fixed result = new Vector2Fixed(x, y);
				result.Normalize();
				return result;
			}
		}

		public Vector2Fixed tangent => new Vector2Fixed(-y, x);

		public Fix64 magnitude => Fix64.Sqrt(x * x + y * y);

		public Fix64 sqrMagnitude => x * x + y * y;

		public static Vector2Fixed zero => zeroVector;

		public static Vector2Fixed one => oneVector;

		public static Vector2Fixed up => upVector;

		public static Vector2Fixed down => downVector;

		public static Vector2Fixed left => leftVector;

		public static Vector2Fixed right => rightVector;

		public Vector2Fixed(Fix64 x, Fix64 y)
		{
			this.x = x;
			this.y = y;
		}

		public Vector2Fixed(float xValue, float yValue)
		{
			x = (Fix64)xValue;
			y = (Fix64)yValue;
		}

		public Vector2Fixed(Vector2Fixed vector2Fixed)
			: this(vector2Fixed.x, vector2Fixed.y)
		{
		}

		public Vector2Fixed(Vector2 vector2Float)
			: this(vector2Float.x, vector2Float.y)
		{
		}

		public Vector2Fixed(Vector2Int vector2Int)
			: this((Fix64)vector2Int.x, (Fix64)vector2Int.y)
		{
		}

		public Vector2Fixed(Vector3Fixed vector3Fixed)
			: this(vector3Fixed.x, vector3Fixed.y)
		{
		}

		public Vector2Fixed(Vector3 vector3Float)
			: this(vector3Float.x, vector3Float.y)
		{
		}

		public static explicit operator Vector2Fixed(Vector2 value)
		{
			return new Vector2Fixed(value);
		}

		public static explicit operator Vector2Fixed(Vector3 value)
		{
			return new Vector2Fixed(value);
		}

		public static explicit operator Vector2(Vector2Fixed value)
		{
			return new Vector2((float)value.x, (float)value.y);
		}

		public static explicit operator Vector3Fixed(Vector2Fixed value)
		{
			return new Vector3Fixed(value.x, value.y, Fix64.Zero);
		}

		public static explicit operator Vector3(Vector2Fixed value)
		{
			return new Vector3((float)value.x, (float)value.y, 0f);
		}

		public static Vector2Fixed operator +(Vector2Fixed a, Vector2Fixed b)
		{
			return new Vector2Fixed(a.x + b.x, a.y + b.y);
		}

		public static Vector2Fixed operator -(Vector2Fixed a, Vector2Fixed b)
		{
			return new Vector2Fixed(a.x - b.x, a.y - b.y);
		}

		public static Vector2Fixed operator -(Vector2Fixed a)
		{
			return new Vector2Fixed(-a.x, -a.y);
		}

		public static Vector2Fixed operator *(Vector2Fixed a, Fix64 d)
		{
			return new Vector2Fixed(a.x * d, a.y * d);
		}

		public static Vector2Fixed operator *(Fix64 d, Vector2Fixed a)
		{
			return new Vector2Fixed(a.x * d, a.y * d);
		}

		public static Vector2Fixed operator /(Vector2Fixed a, Fix64 d)
		{
			return new Vector2Fixed(a.x / d, a.y / d);
		}

		public static bool operator ==(Vector2Fixed lhs, Vector2Fixed rhs)
		{
			if (lhs.x == rhs.x)
			{
				return lhs.y == rhs.y;
			}
			return false;
		}

		public static bool operator !=(Vector2Fixed lhs, Vector2Fixed rhs)
		{
			if (!(lhs.x != rhs.x))
			{
				return lhs.y != rhs.y;
			}
			return true;
		}

		public void Set(Fix64 new_x, Fix64 new_y)
		{
			x = new_x;
			y = new_y;
		}

		public static Vector2Fixed Lerp(Vector2Fixed a, Vector2Fixed b, Fix64 t)
		{
			t = Fix64.Clamp(t, Fix64.Zero, Fix64.One);
			return new Vector2Fixed(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t);
		}

		public static Vector2Fixed LerpUnclamped(Vector2Fixed a, Vector2Fixed b, Fix64 t)
		{
			return new Vector2Fixed(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t);
		}

		public static Vector2Fixed MoveTowards(Vector2Fixed current, Vector2Fixed target, Fix64 maxDistanceDelta)
		{
			Vector2Fixed vector2Fixed = target - current;
			Fix64 fix = vector2Fixed.magnitude;
			if (fix <= maxDistanceDelta || fix == Fix64.Zero)
			{
				return target;
			}
			return current + vector2Fixed / fix * maxDistanceDelta;
		}

		public static Vector2Fixed Scale(Vector2Fixed a, Vector2Fixed b)
		{
			return new Vector2Fixed(a.x * b.x, a.y * b.y);
		}

		public void Scale(Vector2Fixed scale)
		{
			x *= scale.x;
			y *= scale.y;
		}

		public void Normalize()
		{
			Fix64 fix = magnitude;
			if (fix > Fix64.Zero)
			{
				this /= fix;
			}
			else
			{
				this = zero;
			}
		}

		public override string ToString()
		{
			return ((Vector2)this).ToString();
		}

		public string ToString(string format)
		{
			return ((Vector2)this).ToString(format);
		}

		public override int GetHashCode()
		{
			return x.GetHashCode() ^ (y.GetHashCode() << 2);
		}

		public override bool Equals(object other)
		{
			if (!(other is Vector2Fixed))
			{
				return false;
			}
			return Equals((Vector2Fixed)other);
		}

		public bool Equals(Vector2Fixed other)
		{
			if (x == other.x)
			{
				return y == other.y;
			}
			return false;
		}

		public bool Approximately(Vector2Fixed other)
		{
			if (Fix64.Approximately(x, other.x))
			{
				return Fix64.Approximately(y, other.y);
			}
			return false;
		}

		public static Vector2Fixed Reflect(Vector2Fixed inDirection, Vector2Fixed inNormal)
		{
			return -Fix64Consts.Two * Dot(inNormal, inDirection) * inNormal + inDirection;
		}

		public static Fix64 Dot(Vector2Fixed lhs, Vector2Fixed rhs)
		{
			return lhs.x * rhs.x + lhs.y * rhs.y;
		}

		public static Fix64 Angle(Vector2Fixed from, Vector2Fixed to)
		{
			return Fix64.Acos(Fix64.Clamp(Dot(from.normalized, to.normalized), -Fix64.One, Fix64.One));
		}

		public static Fix64 Distance(Vector2Fixed a, Vector2Fixed b)
		{
			return (a - b).magnitude;
		}

		public static Vector2Fixed ClampMagnitude(Vector2Fixed vector, Fix64 maxLength)
		{
			if (vector.sqrMagnitude > maxLength * maxLength)
			{
				return vector.normalized * maxLength;
			}
			return vector;
		}

		public static Fix64 SqrMagnitude(Vector2Fixed a)
		{
			return a.x * a.x + a.y * a.y;
		}

		public Fix64 SqrMagnitude()
		{
			return x * x + y * y;
		}

		public static Vector2Fixed Min(Vector2Fixed lhs, Vector2Fixed rhs)
		{
			return new Vector2Fixed(Fix64.Min(lhs.x, rhs.x), Fix64.Min(lhs.y, rhs.y));
		}

		public static Vector2Fixed Max(Vector2Fixed lhs, Vector2Fixed rhs)
		{
			return new Vector2Fixed(Fix64.Max(lhs.x, rhs.x), Fix64.Max(lhs.y, rhs.y));
		}

		public Vector2Fixed Rotated(Fix64 angle)
		{
			Fix64 fix = Fix64.Sin(angle);
			Fix64 fix2 = Fix64.Cos(angle);
			return new Vector2Fixed(fix2 * x - fix * y, fix * x + fix2 * y);
		}
	}
}
