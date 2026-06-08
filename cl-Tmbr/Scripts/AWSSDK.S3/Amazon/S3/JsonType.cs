using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class JsonType : ConstantClass
	{
		public static readonly JsonType Document = new JsonType("DOCUMENT");

		public static readonly JsonType Lines = new JsonType("LINES");

		public JsonType(string value)
			: base(value)
		{
		}

		public static JsonType FindValue(string value)
		{
			return ConstantClass.FindValue<JsonType>(value);
		}

		public static implicit operator JsonType(string value)
		{
			return FindValue(value);
		}
	}
}
