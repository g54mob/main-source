using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class ArchiveStatus : ConstantClass
	{
		public static readonly ArchiveStatus ARCHIVE_ACCESS = new ArchiveStatus("ARCHIVE_ACCESS");

		public static readonly ArchiveStatus DEEP_ARCHIVE_ACCESS = new ArchiveStatus("DEEP_ARCHIVE_ACCESS");

		public ArchiveStatus(string value)
			: base(value)
		{
		}

		public static ArchiveStatus FindValue(string value)
		{
			return ConstantClass.FindValue<ArchiveStatus>(value);
		}

		public static implicit operator ArchiveStatus(string value)
		{
			return ConstantClass.FindValue<ArchiveStatus>(value);
		}
	}
}
