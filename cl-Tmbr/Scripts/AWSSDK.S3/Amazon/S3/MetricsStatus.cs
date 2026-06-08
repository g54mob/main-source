using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class MetricsStatus : ConstantClass
	{
		public static readonly MetricsStatus Enabled = new MetricsStatus("Enabled");

		public static readonly MetricsStatus Disabled = new MetricsStatus("Disabled");

		public MetricsStatus(string value)
			: base(value)
		{
		}

		public static MetricsStatus FindValue(string value)
		{
			return ConstantClass.FindValue<MetricsStatus>(value);
		}

		public static implicit operator MetricsStatus(string value)
		{
			return FindValue(value);
		}
	}
}
