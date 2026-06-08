using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class ObjectOwnership : ConstantClass
	{
		public static readonly ObjectOwnership BucketOwnerEnforced = new ObjectOwnership("BucketOwnerEnforced");

		public static readonly ObjectOwnership BucketOwnerPreferred = new ObjectOwnership("BucketOwnerPreferred");

		public static readonly ObjectOwnership ObjectWriter = new ObjectOwnership("ObjectWriter");

		public ObjectOwnership(string value)
			: base(value)
		{
		}

		public static ObjectOwnership FindValue(string value)
		{
			return ConstantClass.FindValue<ObjectOwnership>(value);
		}

		public static implicit operator ObjectOwnership(string value)
		{
			return FindValue(value);
		}
	}
}
