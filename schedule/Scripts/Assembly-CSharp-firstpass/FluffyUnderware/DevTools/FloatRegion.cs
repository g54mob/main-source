using System;

namespace FluffyUnderware.DevTools
{
	[Serializable]
	public struct FloatRegion : IEquatable<FloatRegion>
	{
		public float From;

		public float To;

		public bool SimpleValue;

		public static FloatRegion ZeroOne => default(FloatRegion);

		public bool Positive => false;

		public float Low
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float High
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Random => 0f;

		public float Next => 0f;

		public float Length => 0f;

		public float LengthPositive => 0f;

		public FloatRegion(float value)
		{
			From = 0f;
			To = 0f;
			SimpleValue = false;
		}

		public FloatRegion(float A, float B)
		{
			From = 0f;
			To = 0f;
			SimpleValue = false;
		}

		public void MakePositive()
		{
		}

		public void Clamp(float low, float high)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Equals(FloatRegion other)
		{
			return false;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public static FloatRegion operator +(FloatRegion a, FloatRegion b)
		{
			return default(FloatRegion);
		}

		public static FloatRegion operator -(FloatRegion a, FloatRegion b)
		{
			return default(FloatRegion);
		}

		public static FloatRegion operator -(FloatRegion a)
		{
			return default(FloatRegion);
		}

		public static FloatRegion operator *(FloatRegion a, float v)
		{
			return default(FloatRegion);
		}

		public static FloatRegion operator *(float v, FloatRegion a)
		{
			return default(FloatRegion);
		}

		public static FloatRegion operator /(FloatRegion a, float v)
		{
			return default(FloatRegion);
		}

		public static bool operator ==(FloatRegion lhs, FloatRegion rhs)
		{
			return false;
		}

		public static bool operator !=(FloatRegion lhs, FloatRegion rhs)
		{
			return false;
		}
	}
}
