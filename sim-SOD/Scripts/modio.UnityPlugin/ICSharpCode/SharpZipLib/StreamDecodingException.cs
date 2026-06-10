using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib
{
	[Serializable]
	public class StreamDecodingException : SharpZipBaseException
	{
		private const string GenericMessage = "Input stream could not be decoded";

		public StreamDecodingException()
		{
		}

		public StreamDecodingException(string message)
		{
		}

		public StreamDecodingException(string message, Exception innerException)
		{
		}

		protected StreamDecodingException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
