using Amazon.Runtime;

namespace Amazon.S3
{
	public class ObjectAttributes : ConstantClass
	{
		public static readonly ObjectAttributes Checksum = new ObjectAttributes("Checksum");

		public static readonly ObjectAttributes ETag = new ObjectAttributes("ETag");

		public static readonly ObjectAttributes ObjectParts = new ObjectAttributes("ObjectParts");

		public static readonly ObjectAttributes ObjectSize = new ObjectAttributes("ObjectSize");

		public static readonly ObjectAttributes StorageClass = new ObjectAttributes("StorageClass");

		public ObjectAttributes(string value)
			: base(value)
		{
		}

		public static ObjectAttributes FindValue(string value)
		{
			return ConstantClass.FindValue<ObjectAttributes>(value);
		}

		public static implicit operator ObjectAttributes(string value)
		{
			return FindValue(value);
		}
	}
}
