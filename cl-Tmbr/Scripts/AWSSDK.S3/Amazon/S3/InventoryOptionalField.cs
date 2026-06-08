using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class InventoryOptionalField : ConstantClass
	{
		public static readonly InventoryOptionalField Size = new InventoryOptionalField("Size");

		public static readonly InventoryOptionalField LastModifiedDate = new InventoryOptionalField("LastModifiedDate");

		public static readonly InventoryOptionalField StorageClass = new InventoryOptionalField("StorageClass");

		public static readonly InventoryOptionalField ETag = new InventoryOptionalField("ETag");

		public static readonly InventoryOptionalField IsMultipartUploaded = new InventoryOptionalField("IsMultipartUploaded");

		public static readonly InventoryOptionalField ReplicationStatus = new InventoryOptionalField("ReplicationStatus");

		public static readonly InventoryOptionalField EncryptionStatus = new InventoryOptionalField("EncryptionStatus");

		public static readonly InventoryOptionalField ObjectLockRetainUntilDate = new InventoryOptionalField("ObjectLockRetainUntilDate");

		public static readonly InventoryOptionalField ObjectLockMode = new InventoryOptionalField("ObjectLockMode");

		public static readonly InventoryOptionalField ObjectLockLegalHoldStatus = new InventoryOptionalField("ObjectLockLegalHoldStatus");

		public static readonly InventoryOptionalField IntelligentTieringAccessTier = new InventoryOptionalField("IntelligentTieringAccessTier");

		public static readonly InventoryOptionalField BucketKeyStatus = new InventoryOptionalField("BucketKeyStatus");

		public static readonly InventoryOptionalField ChecksumAlgorithm = new InventoryOptionalField("ChecksumAlgorithm");

		public static readonly InventoryOptionalField ObjectAccessControlList = new InventoryOptionalField("ObjectAccessControlList");

		public static readonly InventoryOptionalField ObjectOwner = new InventoryOptionalField("ObjectOwner");

		public InventoryOptionalField(string value)
			: base(value)
		{
		}

		public static InventoryOptionalField FindValue(string value)
		{
			return ConstantClass.FindValue<InventoryOptionalField>(value);
		}

		public static implicit operator InventoryOptionalField(string value)
		{
			return ConstantClass.FindValue<InventoryOptionalField>(value);
		}
	}
}
