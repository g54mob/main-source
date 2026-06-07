using System;
using UnityEngine;

namespace CTS.Utilities
{
	[Serializable]
	public readonly struct UnscaledGameTime : IEquatable<float>, IEquatable<UnscaledGameTime>
	{
		private readonly float _value;

		public float Value => _value;

		public static UnscaledGameTime Now => new UnscaledGameTime(Time.unscaledTime);

		public UnscaledGameTime(float value)
		{
			_value = value;
		}

		public static implicit operator UnscaledGameTime(float value)
		{
			return new UnscaledGameTime(value);
		}

		public static implicit operator float(UnscaledGameTime value)
		{
			return value._value;
		}

		public static bool operator ==(UnscaledGameTime left, UnscaledGameTime right)
		{
			return left._value == right._value;
		}

		public static bool operator !=(UnscaledGameTime left, UnscaledGameTime right)
		{
			return left._value != right._value;
		}

		public static bool operator <(UnscaledGameTime left, UnscaledGameTime right)
		{
			return left._value < right._value;
		}

		public static bool operator >(UnscaledGameTime left, UnscaledGameTime right)
		{
			return left._value > right._value;
		}

		public static bool operator <=(UnscaledGameTime left, UnscaledGameTime right)
		{
			return left._value <= right._value;
		}

		public static bool operator >=(UnscaledGameTime left, UnscaledGameTime right)
		{
			return left._value >= right._value;
		}

		public static UnscaledGameTime operator *(UnscaledGameTime left, UnscaledGameTime right)
		{
			return left._value * right._value;
		}

		public static UnscaledGameTime operator +(UnscaledGameTime left, UnscaledGameTime right)
		{
			return left._value + right._value;
		}

		public static UnscaledGameTime operator /(UnscaledGameTime left, UnscaledGameTime right)
		{
			return left._value / right._value;
		}

		public static UnscaledGameTime operator -(UnscaledGameTime left, UnscaledGameTime right)
		{
			return left._value - right._value;
		}

		public bool Equals(float other)
		{
			return _value.Equals(other);
		}

		public bool Equals(UnscaledGameTime other)
		{
			return Equals(other._value);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is float other))
			{
				if (obj is UnscaledGameTime other2)
				{
					return Equals(other2);
				}
				return false;
			}
			return Equals(other);
		}

		public override int GetHashCode()
		{
			return _value.GetHashCode();
		}
	}
}
