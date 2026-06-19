using System;
using Sentry.Protocol.Envelopes;

namespace Sentry.Internal.Http
{
	internal class RateLimitCategory : IEquatable<RateLimitCategory>
	{
		public string Name { get; }

		public bool IsMatchAll => string.IsNullOrWhiteSpace(Name);

		public RateLimitCategory(string name)
		{
			Name = name;
		}

		public bool Matches(EnvelopeItem item)
		{
			if (IsMatchAll)
			{
				return true;
			}
			string text = item.TryGetType();
			if (string.IsNullOrWhiteSpace(text))
			{
				return false;
			}
			if (text == "statsd")
			{
				return string.Equals(Name, "metric_bucket", StringComparison.OrdinalIgnoreCase);
			}
			return string.Equals(Name, text, StringComparison.OrdinalIgnoreCase);
		}

		public bool Equals(RateLimitCategory? other)
		{
			if (other == null)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
		}

		public override bool Equals(object? obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((RateLimitCategory)obj);
		}

		public override int GetHashCode()
		{
			return StringComparer.OrdinalIgnoreCase.GetHashCode(Name);
		}
	}
}
