using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class IntelligentTieringStatus : ConstantClass
	{
		public static readonly IntelligentTieringStatus Enabled = new IntelligentTieringStatus("Enabled");

		public static readonly IntelligentTieringStatus Disabled = new IntelligentTieringStatus("Disabled");

		public IntelligentTieringStatus(string value)
			: base(value)
		{
		}

		public static IntelligentTieringStatus FindValue(string value)
		{
			return ConstantClass.FindValue<IntelligentTieringStatus>(value);
		}

		public static implicit operator IntelligentTieringStatus(string value)
		{
			return FindValue(value);
		}
	}
}
