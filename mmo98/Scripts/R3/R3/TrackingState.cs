using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace R3
{
	public struct TrackingState : IComparable<TrackingState>
	{
		public int TrackingId { get; set; }

		public string FormattedType { get; set; }

		public DateTime AddTime { get; set; }

		public string StackTrace { get; set; }

		public TrackingState(int TrackingId, string FormattedType, DateTime AddTime, string StackTrace)
		{
			this.TrackingId = TrackingId;
			this.FormattedType = FormattedType;
			this.AddTime = AddTime;
			this.StackTrace = StackTrace;
		}

		public int CompareTo(TrackingState other)
		{
			return TrackingId.CompareTo(other.TrackingId);
		}

		[CompilerGenerated]
		public override readonly string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("TrackingState");
			stringBuilder.Append(" { ");
			if (PrintMembers(stringBuilder))
			{
				stringBuilder.Append(' ');
			}
			stringBuilder.Append('}');
			return stringBuilder.ToString();
		}

		[CompilerGenerated]
		private readonly bool PrintMembers(StringBuilder builder)
		{
			builder.Append("TrackingId = ");
			builder.Append(TrackingId.ToString());
			builder.Append(", FormattedType = ");
			builder.Append((object)FormattedType);
			builder.Append(", AddTime = ");
			builder.Append(AddTime.ToString());
			builder.Append(", StackTrace = ");
			builder.Append((object)StackTrace);
			return true;
		}

		[CompilerGenerated]
		public static bool operator !=(TrackingState left, TrackingState right)
		{
			return !(left == right);
		}

		[CompilerGenerated]
		public static bool operator ==(TrackingState left, TrackingState right)
		{
			return left.Equals(right);
		}

		[CompilerGenerated]
		public override readonly int GetHashCode()
		{
			return ((EqualityComparer<int>.Default.GetHashCode(TrackingId) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FormattedType)) * -1521134295 + EqualityComparer<DateTime>.Default.GetHashCode(AddTime)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(StackTrace);
		}

		[CompilerGenerated]
		public override readonly bool Equals(object obj)
		{
			if (obj is TrackingState)
			{
				return Equals((TrackingState)obj);
			}
			return false;
		}

		[CompilerGenerated]
		public readonly bool Equals(TrackingState other)
		{
			if (EqualityComparer<int>.Default.Equals(TrackingId, other.TrackingId) && EqualityComparer<string>.Default.Equals(FormattedType, other.FormattedType) && EqualityComparer<DateTime>.Default.Equals(AddTime, other.AddTime))
			{
				return EqualityComparer<string>.Default.Equals(StackTrace, other.StackTrace);
			}
			return false;
		}

		[CompilerGenerated]
		public readonly void Deconstruct(out int TrackingId, out string FormattedType, out DateTime AddTime, out string StackTrace)
		{
			TrackingId = this.TrackingId;
			FormattedType = this.FormattedType;
			AddTime = this.AddTime;
			StackTrace = this.StackTrace;
		}
	}
}
