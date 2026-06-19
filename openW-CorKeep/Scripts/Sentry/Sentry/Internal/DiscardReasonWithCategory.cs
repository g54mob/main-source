using System;

namespace Sentry.Internal
{
	internal readonly struct DiscardReasonWithCategory : IEquatable<DiscardReasonWithCategory>, IComparable<DiscardReasonWithCategory>, IComparable
	{
		public DiscardReason Reason { get; }

		public DataCategory Category { get; }

		public DiscardReasonWithCategory(string reason, string category)
		{
			Reason = new DiscardReason(reason);
			Category = new DataCategory(category);
		}

		public DiscardReasonWithCategory(DiscardReason reason, DataCategory category)
		{
			Reason = reason;
			Category = category;
		}

		public int CompareTo(DiscardReasonWithCategory other)
		{
			int num = Reason.CompareTo(other.Reason);
			if (num == 0)
			{
				return Category.CompareTo(other.Category);
			}
			return num;
		}

		public int CompareTo(object? obj)
		{
			if (obj == null)
			{
				return 1;
			}
			if (!(obj is DiscardReasonWithCategory other))
			{
				throw new ArgumentException("Object must be of type DiscardReasonWithCategory");
			}
			return CompareTo(other);
		}

		public bool Equals(DiscardReasonWithCategory other)
		{
			if (Reason.Equals(other.Reason))
			{
				return Category.Equals(other.Category);
			}
			return false;
		}

		public override bool Equals(object? obj)
		{
			if (obj is DiscardReasonWithCategory other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (Reason.GetHashCode() * 397) ^ Category.GetHashCode();
		}

		public override string ToString()
		{
			return $"{{ Reason = \"{Reason}\", Category = \"{Category}\" }}";
		}
	}
}
