using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class ReplicationTimeStatus : ConstantClass
	{
		public static readonly ReplicationTimeStatus Enabled = new ReplicationTimeStatus("Enabled");

		public static readonly ReplicationTimeStatus Disabled = new ReplicationTimeStatus("Disabled");

		public ReplicationTimeStatus(string value)
			: base(value)
		{
		}

		public static ReplicationTimeStatus FindValue(string value)
		{
			return ConstantClass.FindValue<ReplicationTimeStatus>(value);
		}

		public static implicit operator ReplicationTimeStatus(string value)
		{
			return FindValue(value);
		}
	}
}
