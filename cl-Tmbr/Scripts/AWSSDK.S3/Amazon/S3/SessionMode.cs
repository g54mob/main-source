using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class SessionMode : ConstantClass
	{
		public static readonly SessionMode ReadOnly = new SessionMode("ReadOnly");

		public static readonly SessionMode ReadWrite = new SessionMode("ReadWrite");

		public SessionMode(string value)
			: base(value)
		{
		}

		public static SessionMode FindValue(string value)
		{
			return ConstantClass.FindValue<SessionMode>(value);
		}

		public static implicit operator SessionMode(string value)
		{
			return FindValue(value);
		}
	}
}
