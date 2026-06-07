using System;
using System.ComponentModel;
using UnityEngine;

namespace FixMath
{
	[Serializable]
	public struct Vector3Fixed : IEquatable<Vector3Fixed>
	{
		public static readonly Fix64 kEpsilon = (Fix64)1E-05f;

		public static readonly Fix64 kEpsilonNormalSqrt = (Fix64)1E-15f;

		public Fix64 x;

		public Fix64 y;

		public Fix64 z;

		private static readonly Vector3Fixed zeroVector = new Vector3Fixed(0f, 0f, 0f);

		private static readonly Vector3Fixed oneVector = new Vector3Fixed(1f, 1f, 1f);

		private static readonly Vector3Fixed upVector = new Vector3Fixed(0f, 1f, 0f);

		private static readonly Vector3Fixed downVector = new Vector3Fixed(0f, -1f, 0f);

		private static readonly Vector3Fixed leftVector = new Vector3Fixed(-1f, 0f, 0f);

		private static readonly Vector3Fixed rightVector = new Vector3Fixed(1f, 0f, 0f);

		private static readonly Vector3Fixed forwardVector = new Vector3Fixed(0f, 0f, 1f);

		private static readonly Vector3Fixed backVector = new Vector3Fixed(0f, 0f, -1f);

		public Fix64 this[int index]
		{
			get
			{
				return index switch
				{
					0 => x, 
					1 => y, 
					2 => z, 
					_ => Fix64.Zero, 
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
				case 2:
					z = value;
					break;
				}
			}
		}

		public Vector3Fixed normalized => Normalize(this);

		public Fix64 magnitude => Fix64.Sqrt(x * x + y * y + z * z);

		public Fix64 sqrMagnitude => x * x + y * y + z * z;

		public static Vector3Fixed zero => zeroVector;

		public static Vector3Fixed one => oneVector;

		public static Vector3Fixed forward => forwardVector;

		public static Vector3Fixed back => backVector;

		public static Vector3Fixed up => upVector;

		public static Vector3Fixed down => downVector;

		public static Vector3Fixed left => leftVector;

		public static Vector3Fixed right => rightVector;

		public Vector3Fixed(Vector3Fixed vector3Fixed)
			: this(vector3Fixed.x, vector3Fixed.y, vector3Fixed.z)
		{
		}

		public Vector3Fixed(Vector3 vector3Float)
			: this(vector3Float.x, vector3Float.y, vector3Float.z)
		{
		}

		public Vector3Fixed(Vector2 vector2Float)
			: this(vector2Float.x, vector2Float.y, 0f)
		{
		}

		public Vector3Fixed(Vector2Int vector2Int)
			: this((Fix64)vector2Int.x, (Fix64)vector2Int.y, Fix64Consts.Zero)
		{
		}

		public Vector3Fixed(Vector2Fixed vector2Fixed)
			: this(vector2Fixed.x, vector2Fixed.y, Fix64Consts.Zero)
		{
		}

		public Vector3Fixed(Fix64 xValue, Fix64 yValue, Fix64 zValue)
		{
			x = xValue;
			y = yValue;
			z = zValue;
		}

		public Vector3Fixed(float xValue, float yValue, float zValue)
		{
			x = (Fix64)xValue;
			y = (Fix64)yValue;
			z = (Fix64)zValue;
		}

		public Vector3Fixed(Fix64 x, Fix64 y)
			: this(x, y, Fix64.Zero)
		{
		}

		public Vector3Fixed(float x, float y)
			: this(x, y, 0f)
		{
		}

		public static Vector3Fixed Slerp(Vector3Fixed a, Vector3Fixed b, Fix64 t)
		{
			return SlerpUnclamped(a, b, Fix64.Clamp01(t));
		}

		public static Vector3Fixed SlerpUnclamped(Vector3Fixed a, Vector3Fixed b, Fix64 t)
		{
			throw new NotImplementedException();
		}

		public static void OrthoNormalize(ref Vector3Fixed normal, ref Vector3Fixed tangent)
		{
			throw new NotImplementedException();
		}

		public static void OrthoNormalize(ref Vector3Fixed normal, ref Vector3Fixed tangent, ref Vector3Fixed binormal)
		{
			throw new NotImplementedException();
		}

		public static Vector3Fixed RotateTowards(Vector3Fixed current, Vector3Fixed target, Fix64 maxRadiansDelta, Fix64 maxMagnitudeDelta)
		{
			throw new NotImplementedException();
		}

		public static Vector3Fixed Lerp(Vector3Fixed a, Vector3Fixed b, Fix64 t)
		{
			return LerpUnclamped(a, b, Fix64.Clamp01(t));
		}

		public static Vector3Fixed LerpUnclamped(Vector3Fixed a, Vector3Fixed b, Fix64 t)
		{
			return new Vector3Fixed(Fix64.Lerp(a.x, b.x, t), Fix64.Lerp(a.y, b.y, t), Fix64.Lerp(a.z, b.z, t));
		}

		public static Vector3Fixed MoveTowards(Vector3Fixed current, Vector3Fixed target, Fix64 maxDistanceDelta)
		{
			throw new NotImplementedException();
		}

		public static Vector3Fixed SmoothDamp(Vector3Fixed current, Vector3Fixed target, ref Vector3Fixed currentVelocity, Fix64 smoothTime, Fix64 maxSpeed)
		{
			throw new NotImplementedException();
		}

		public static Vector3Fixed SmoothDamp(Vector3Fixed current, Vector3Fixed target, ref Vector3Fixed currentVelocity, Fix64 smoothTime)
		{
			throw new NotImplementedException();
		}

		public static Vector3Fixed SmoothDamp(Vector3Fixed current, Vector3Fixed target, ref Vector3Fixed currentVelocity, Fix64 smoothTime, [DefaultValue("Mathf.Infinity")] Fix64 maxSpeed, [DefaultValue("Time.deltaTime")] Fix64 deltaTime)
		{
			throw new NotImplementedException();
		}

		public void Set(Fix64 newX, Fix64 newY, Fix64 newZ)
		{
			x = newX;
			y = newY;
			z = newZ;
		}

		public void Set(float newX, float newY, float newZ)
		{
			x = (Fix64)newX;
			y = (Fix64)newY;
			z = (Fix64)newZ;
		}

		public static Vector3Fixed Scale(Vector3Fixed a, Vector3Fixed b)
		{
			return new Vector3Fixed(a.x * b.x, a.y * b.y, a.z * b.z);
		}

		public void Scale(Vector3Fixed scale)
		{
			x *= scale.x;
			y *= scale.y;
			z *= scale.z;
		}

		public void ScaleUniform(Fix64 scale)
		{
			x *= scale;
			y *= scale;
			z *= scale;
		}

		public static Vector3Fixed Cross(Vector3Fixed lhs, Vector3Fixed rhs)
		{
			return new Vector3Fixed(lhs.y * rhs.z - lhs.z * rhs.y, lhs.z * rhs.x - lhs.x * rhs.z, lhs.x * rhs.y - lhs.y * rhs.x);
		}

		public override int GetHashCode()
		{
			return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode();
		}

		public override bool Equals(object other)
		{
			if (other != null && typeof(Vector3Fixed).IsAssignableFrom(other.GetType()))
			{
				return Equals((Vector3Fixed)other);
			}
			return false;
		}

		public bool Equals(Vector3Fixed other)
		{
			if (x == other.x && y == other.y)
			{
				return z == other.z;
			}
			return false;
		}

		public static Vector3Fixed Reflect(Vector3Fixed inDirection, Vector3Fixed inNormal)
		{
			throw new NotImplementedException();
		}

		public static Vector3Fixed Normalize(Vector3Fixed value)
		{
			Vector3Fixed result = new Vector3Fixed(value);
			result.Normalize();
			return result;
		}

		public void Normalize()
		{
			Fix64 fix = magnitude;
			x /= fix;
			y /= fix;
			z /= fix;
		}

		public static Fix64 Dot(Vector3Fixed lhs, Vector3Fixed rhs)
		{
			return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
		}

		public static Vector3Fixed Project(Vector3Fixed vector, Vector3Fixed onNormal)
		{
			throw new NotImplementedException();
		}

		public static Vector3Fixed ProjectOnPlane(Vector3Fixed vector, Vector3Fixed planeNormal)
		{
			throw new NotImplementedException();
		}

		public static Fix64 Angle(Vector3Fixed from, Vector3Fixed to)
		{
			return Fix64.Acos(Dot(from.normalized, to.normalized));
		}

		public static Vector3Fixed RotateByQuaternion(Vector3Fixed v, Quaternion q)
		{
			Vector3Fixed vector3Fixed = new Vector3Fixed(q.x, q.y, q.z);
			Fix64 fix = (Fix64)q.w;
			return Fix64Consts.Two * Dot(vector3Fixed, v) * vector3Fixed + (fix * fix - Dot(vector3Fixed, vector3Fixed)) * v + Fix64Consts.Two * fix * Cross(vector3Fixed, v);
		}

		public static Fix64 SignedAngle(Vector3Fixed from, Vector3Fixed to, Vector3Fixed axis)
		{
			throw new NotImplementedException();
		}

		public static Fix64 Distance(Vector3Fixed a, Vector3Fixed b)
		{
			return (a - b).magnitude;
		}

		public static Vector3Fixed ClampMagnitude(Vector3Fixed vector, Fix64 maxLength)
		{
			_ = maxLength * maxLength;
			if (SqrMagnitude(vector) > maxLength)
			{
				return vector.normalized * maxLength;
			}
			return vector;
		}

		public static Fix64 Magnitude(Vector3Fixed vector)
		{
			return Fix64.Sqrt(SqrMagnitude(vector));
		}

		public static Fix64 SqrMagnitude(Vector3Fixed vector)
		{
			return vector.x * vector.x + vector.y * vector.y + vector.z * vector.z;
		}

		public static Vector3Fixed Min(Vector3Fixed lhs, Vector3Fixed rhs)
		{
			return new Vector3Fixed(Fix64.Min(lhs.x, rhs.x), Fix64.Min(lhs.y, rhs.y), Fix64.Min(lhs.z, rhs.z));
		}

		public static Vector3Fixed Max(Vector3Fixed lhs, Vector3Fixed rhs)
		{
			return new Vector3Fixed(Fix64.Max(lhs.x, rhs.x), Fix64.Max(lhs.y, rhs.y), Fix64.Max(lhs.z, rhs.z));
		}

		public static Vector3Fixed operator +(Vector3Fixed a, Vector3Fixed b)
		{
			return new Vector3Fixed(a.x + b.x, a.y + b.y, a.z + b.z);
		}

		public static Vector3Fixed operator -(Vector3Fixed a, Vector3Fixed b)
		{
			return new Vector3Fixed(a.x - b.x, a.y - b.y, a.z - b.z);
		}

		public static Vector3Fixed operator -(Vector3Fixed a)
		{
			return new Vector3Fixed(-a.x, -a.y, -a.z);
		}

		public static Vector3Fixed operator *(Vector3Fixed a, Fix64 d)
		{
			return new Vector3Fixed(a.x * d, a.y * d, a.z * d);
		}

		public static Vector3Fixed operator *(Fix64 d, Vector3Fixed a)
		{
			return new Vector3Fixed(a.x * d, a.y * d, a.z * d);
		}

		public static Vector3Fixed operator /(Vector3Fixed a, Fix64 d)
		{
			return new Vector3Fixed(a.x / d, a.y / d, a.z / d);
		}

		public static bool operator ==(Vector3Fixed lhs, Vector3Fixed rhs)
		{
			if (lhs.x == rhs.x && lhs.y == rhs.y)
			{
				return lhs.z == rhs.z;
			}
			return false;
		}

		public static bool operator !=(Vector3Fixed lhs, Vector3Fixed rhs)
		{
			if (!(lhs.x != rhs.x) && !(lhs.y != rhs.y))
			{
				return lhs.z != rhs.z;
			}
			return true;
		}

		public static explicit operator Vector3Fixed(Vector3 value)
		{
			return new Vector3Fixed(value);
		}

		public static explicit operator Vector3(Vector3Fixed value)
		{
			return new Vector3((float)value.x, (float)value.y, (float)value.z);
		}

		public static explicit operator Vector2(Vector3Fixed value)
		{
			return new Vector3((float)value.x, (float)value.y);
		}

		public override string ToString()
		{
			return ((Vector3)this).ToString();
		}

		public string ToString(string format)
		{
			return ((Vector3)this).ToString(format);
		}
	}
}
