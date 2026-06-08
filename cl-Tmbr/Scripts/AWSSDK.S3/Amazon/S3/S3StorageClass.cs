using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class S3StorageClass : ConstantClass
	{
		public static readonly S3StorageClass DeepArchive = new S3StorageClass("DEEP_ARCHIVE");

		public static readonly S3StorageClass Glacier = new S3StorageClass("GLACIER");

		public static readonly S3StorageClass GlacierInstantRetrieval = new S3StorageClass("GLACIER_IR");

		public static readonly S3StorageClass IntelligentTiering = new S3StorageClass("INTELLIGENT_TIERING");

		public static readonly S3StorageClass OneZoneInfrequentAccess = new S3StorageClass("ONEZONE_IA");

		public static readonly S3StorageClass Outposts = new S3StorageClass("OUTPOSTS");

		public static readonly S3StorageClass ReducedRedundancy = new S3StorageClass("REDUCED_REDUNDANCY");

		public static readonly S3StorageClass Standard = new S3StorageClass("STANDARD");

		public static readonly S3StorageClass StandardInfrequentAccess = new S3StorageClass("STANDARD_IA");

		public static readonly S3StorageClass Snow = new S3StorageClass("SNOW");

		public static readonly S3StorageClass ExpressOnezone = new S3StorageClass("EXPRESS_ONEZONE");

		public S3StorageClass(string value)
			: base(value)
		{
		}

		public static S3StorageClass FindValue(string value)
		{
			return ConstantClass.FindValue<S3StorageClass>(value);
		}

		public static implicit operator S3StorageClass(string value)
		{
			return FindValue(value);
		}
	}
}
