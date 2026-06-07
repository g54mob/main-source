using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.Tar
{
	[Serializable]
	public class InvalidHeaderException : TarException
	{
		protected InvalidHeaderException(SerializationInfo information, StreamingContext context)
			: base(null, default(StreamingContext))
		{
		}

		public InvalidHeaderException()
			: base(null, default(StreamingContext))
		{
		}

		public InvalidHeaderException(string message)
			: base(null, default(StreamingContext))
		{
		}

		public InvalidHeaderException(string message, Exception exception)
			: base(null, default(StreamingContext))
		{
		}
	}
}
