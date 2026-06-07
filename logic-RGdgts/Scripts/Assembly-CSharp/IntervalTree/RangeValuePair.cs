using System;

namespace IntervalTree
{
	public readonly struct RangeValuePair<TKey, TValue> : IEquatable<RangeValuePair<TKey, TValue>>
	{
		public TKey From { get; }

		public TKey To { get; }

		public TValue Value { get; }

		public RangeValuePair(TKey from, TKey to, TValue value)
		{
			From = default(TKey);
			To = default(TKey);
			Value = default(TValue);
		}

		public override string ToString()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Equals(RangeValuePair<TKey, TValue> other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public static bool operator ==(RangeValuePair<TKey, TValue> left, RangeValuePair<TKey, TValue> right)
		{
			return false;
		}

		public static bool operator !=(RangeValuePair<TKey, TValue> left, RangeValuePair<TKey, TValue> right)
		{
			return false;
		}
	}
}
