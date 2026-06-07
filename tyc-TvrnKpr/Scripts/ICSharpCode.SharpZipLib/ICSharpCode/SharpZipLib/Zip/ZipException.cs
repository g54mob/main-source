using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.Zip
{
	[Serializable]
	public class ZipException : SharpZipBaseException
	{
		protected ZipException(SerializationInfo info, StreamingContext context)
			: base(null, default(StreamingContext))
		{
		}

		public ZipException()
			: base(null, default(StreamingContext))
		{
		}

		public ZipException(string message)
			: base(null, default(StreamingContext))
		{
		}

		public ZipException(string message, Exception exception)
			: base(null, default(StreamingContext))
		{
		}
	}
}
