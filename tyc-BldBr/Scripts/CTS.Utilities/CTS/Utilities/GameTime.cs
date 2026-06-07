using System;
using UnityEngine;

namespace CTS.Utilities
{
	[Serializable]
	public readonly struct GameTime : IEquatable<float>, IEquatable<GameTime>
	{
		private readonly float _value;

		public float Value => _value;

		public static GameTime Now => new GameTime(Time.time);

		public GameTime(float value)
		{
			_value = value;
		}

		public static implicit operator GameTime(float value)
		{
			return new GameTime(value);
		}

		public static implicit operator float(GameTime value)
		{
			return value._value;
		}

		public static bool operator ==(GameTime left, GameTime right)
		{
			return left._value == right._value;
		}

		public static bool operator !=(GameTime left, GameTime right)
		{
			return left._value != right._value;
		}

		public static bool operator <(GameTime left, GameTime right)
		{
			return left._value < right._value;
		}

		public static bool operator >(GameTime left, GameTime right)
		{
			return left._value > right._value;
		}

		public static bool operator <=(GameTime left, GameTime right)
		{
			return left._value <= right._value;
		}

		public static bool operator >=(GameTime left, GameTime right)
		{
			return left._value >= right._value;
		}

		public static GameTime operator *(GameTime left, GameTime right)
		{
			return left._value * right._value;
		}

		public static GameTime operator +(GameTime left, GameTime right)
		{
			return left._value + right._value;
		}

		public static GameTime operator /(GameTime left, GameTime right)
		{
			return left._value / right._value;
		}

		public static GameTime operator -(GameTime left, GameTime right)
		{
			return left._value - right._value;
		}

		public bool Equals(float other)
		{
			return _value.Equals(other);
		}

		public bool Equals(GameTime other)
		{
			return Equals(other._value);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is float other))
			{
				if (obj is GameTime other2)
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
