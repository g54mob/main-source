using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib
{
	[Serializable]
	public class StreamUnsupportedException : StreamDecodingException
	{
		private const string GenericMessage = "Input stream is in a unsupported format";

		public StreamUnsupportedException()
		{
		}

		public StreamUnsupportedException(string message)
		{
		}

		public StreamUnsupportedException(string message, Exception innerException)
		{
		}

		protected StreamUnsupportedException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
