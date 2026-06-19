using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Sentry.Protocol.Metrics
{
	internal struct MetricResourceIdentifier
	{
		public MetricType MetricType { get; set; }

		public string Key { get; set; }

		public MeasurementUnit Unit { get; set; }

		public MetricResourceIdentifier(MetricType MetricType, string Key, MeasurementUnit Unit)
		{
			this.MetricType = MetricType;
			this.Key = Key;
			this.Unit = Unit;
		}

		public override string ToString()
		{
			return $"{MetricType.ToStatsdType()}:{MetricHelper.SanitizeTagKey(Key)}@{Unit}";
		}

		[CompilerGenerated]
		private readonly bool PrintMembers(StringBuilder builder)
		{
			builder.Append("MetricType = ");
			builder.Append(MetricType.ToString());
			builder.Append(", Key = ");
			builder.Append((object)Key);
			builder.Append(", Unit = ");
			builder.Append(Unit.ToString());
			return true;
		}

		[CompilerGenerated]
		public static bool operator !=(MetricResourceIdentifier left, MetricResourceIdentifier right)
		{
			return !(left == right);
		}

		[CompilerGenerated]
		public static bool operator ==(MetricResourceIdentifier left, MetricResourceIdentifier right)
		{
			return left.Equals(right);
		}

		[CompilerGenerated]
		public override readonly int GetHashCode()
		{
			return (EqualityComparer<MetricType>.Default.GetHashCode(MetricType) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Key)) * -1521134295 + EqualityComparer<MeasurementUnit>.Default.GetHashCode(Unit);
		}

		[CompilerGenerated]
		public override readonly bool Equals(object obj)
		{
			if (obj is MetricResourceIdentifier)
			{
				return Equals((MetricResourceIdentifier)obj);
			}
			return false;
		}

		[CompilerGenerated]
		public readonly bool Equals(MetricResourceIdentifier other)
		{
			if (EqualityComparer<MetricType>.Default.Equals(MetricType, other.MetricType) && EqualityComparer<string>.Default.Equals(Key, other.Key))
			{
				return EqualityComparer<MeasurementUnit>.Default.Equals(Unit, other.Unit);
			}
			return false;
		}

		[CompilerGenerated]
		public readonly void Deconstruct(out MetricType MetricType, out string Key, out MeasurementUnit Unit)
		{
			MetricType = this.MetricType;
			Key = this.Key;
			Unit = this.Unit;
		}
	}
}
