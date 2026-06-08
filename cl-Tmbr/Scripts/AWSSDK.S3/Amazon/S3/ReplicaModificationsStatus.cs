using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class ReplicaModificationsStatus : ConstantClass
	{
		public static readonly ReplicaModificationsStatus Enabled = new ReplicaModificationsStatus("Enabled");

		public static readonly ReplicaModificationsStatus Disabled = new ReplicaModificationsStatus("Disabled");

		public ReplicaModificationsStatus(string value)
			: base(value)
		{
		}

		public static ReplicaModificationsStatus FindValue(string value)
		{
			return ConstantClass.FindValue<ReplicaModificationsStatus>(value);
		}

		public static implicit operator ReplicaModificationsStatus(string value)
		{
			return FindValue(value);
		}
	}
}
