using System;
using System.Collections.Generic;
using System.Globalization;

namespace UniRx
{
	[Serializable]
	public struct FrameInterval<T> : IEquatable<FrameInterval<T>>
	{
		private readonly int _interval;

		private readonly T _value;

		public T Value => _value;

		public int Interval => _interval;

		public FrameInterval(T value, int interval)
		{
			_interval = interval;
			_value = value;
		}

		public bool Equals(FrameInterval<T> other)
		{
			if (other.Interval.Equals(Interval))
			{
				return EqualityComparer<T>.Default.Equals(Value, other.Value);
			}
			return false;
		}

		public static bool operator ==(FrameInterval<T> first, FrameInterval<T> second)
		{
			return first.Equals(second);
		}

		public static bool operator !=(FrameInterval<T> first, FrameInterval<T> second)
		{
			return !first.Equals(second);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is FrameInterval<T> other))
			{
				return false;
			}
			return Equals(other);
		}

		public override int GetHashCode()
		{
			int num = ((Value == null) ? 1963 : Value.GetHashCode());
			return Interval.GetHashCode() ^ num;
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "{0}@{1}", Value, Interval);
		}
	}
}
