using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class IntelligentTieringAccessTier : ConstantClass
	{
		public static readonly IntelligentTieringAccessTier ARCHIVE_ACCESS = new IntelligentTieringAccessTier("ARCHIVE_ACCESS");

		public static readonly IntelligentTieringAccessTier DEEP_ARCHIVE_ACCESS = new IntelligentTieringAccessTier("DEEP_ARCHIVE_ACCESS");

		public IntelligentTieringAccessTier(string value)
			: base(value)
		{
		}

		public static IntelligentTieringAccessTier FindValue(string value)
		{
			return ConstantClass.FindValue<IntelligentTieringAccessTier>(value);
		}

		public static implicit operator IntelligentTieringAccessTier(string value)
		{
			return FindValue(value);
		}
	}
}
