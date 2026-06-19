using System;

namespace Sentry.Internal
{
	internal readonly struct DiscardReason : IEnumeration<DiscardReason>, IEquatable<DiscardReason>, IComparable<DiscardReason>, IEnumeration, IComparable
	{
		public static DiscardReason BeforeSend = new DiscardReason("before_send");

		public static DiscardReason CacheOverflow = new DiscardReason("cache_overflow");

		public static DiscardReason EventProcessor = new DiscardReason("event_processor");

		public static DiscardReason NetworkError = new DiscardReason("network_error");

		public static DiscardReason QueueOverflow = new DiscardReason("queue_overflow");

		public static DiscardReason RateLimitBackoff = new DiscardReason("ratelimit_backoff");

		public static DiscardReason SampleRate = new DiscardReason("sample_rate");

		private readonly string _value;

		string IEnumeration.Value => _value;

		public DiscardReason(string value)
		{
			_value = value;
		}

		public DiscardReasonWithCategory WithCategory(DataCategory category)
		{
			return new DiscardReasonWithCategory(this, category);
		}

		public int CompareTo(DiscardReason other)
		{
			return string.Compare(_value, other._value, StringComparison.Ordinal);
		}

		public int CompareTo(object? obj)
		{
			if (obj == null)
			{
				return 1;
			}
			if (!(obj is DiscardReason other))
			{
				throw new ArgumentException("Object must be of type DiscardReason");
			}
			return CompareTo(other);
		}

		public bool Equals(DiscardReason other)
		{
			return _value == other._value;
		}

		public override bool Equals(object? obj)
		{
			if (obj is DiscardReason other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return _value.GetHashCode();
		}

		public override string ToString()
		{
			return _value;
		}
	}
}
