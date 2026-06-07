using System;

namespace AltSerialize
{
	[Serializable]
	public class AltSerializeException : Exception
	{
		public AltSerializeException(string message)
			: base(message)
		{
		}

		public AltSerializeException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public AltSerializeException()
		{
		}
	}
}
