using System;
using System.Collections.Generic;
using System.Globalization;

namespace UniRx
{
	[Serializable]
	public struct TimeInterval<T> : IEquatable<TimeInterval<T>>
	{
		private readonly TimeSpan _interval;

		private readonly T _value;

		public T Value => _value;

		public TimeSpan Interval => _interval;

		public TimeInterval(T value, TimeSpan interval)
		{
			_interval = interval;
			_value = value;
		}

		public bool Equals(TimeInterval<T> other)
		{
			if (other.Interval.Equals(Interval))
			{
				return EqualityComparer<T>.Default.Equals(Value, other.Value);
			}
			return false;
		}

		public static bool operator ==(TimeInterval<T> first, TimeInterval<T> second)
		{
			return first.Equals(second);
		}

		public static bool operator !=(TimeInterval<T> first, TimeInterval<T> second)
		{
			return !first.Equals(second);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is TimeInterval<T> other))
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
