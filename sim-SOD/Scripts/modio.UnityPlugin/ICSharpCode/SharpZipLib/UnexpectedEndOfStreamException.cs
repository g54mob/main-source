using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib
{
	[Serializable]
	public class UnexpectedEndOfStreamException : StreamDecodingException
	{
		private const string GenericMessage = "Input stream ended unexpectedly";

		public UnexpectedEndOfStreamException()
		{
		}

		public UnexpectedEndOfStreamException(string message)
		{
		}

		public UnexpectedEndOfStreamException(string message, Exception innerException)
		{
		}

		protected UnexpectedEndOfStreamException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
