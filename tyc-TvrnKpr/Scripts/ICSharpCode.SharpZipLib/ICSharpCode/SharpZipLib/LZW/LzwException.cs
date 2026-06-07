using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.LZW
{
	[Serializable]
	public class LzwException : SharpZipBaseException
	{
		protected LzwException(SerializationInfo info, StreamingContext context)
			: base(null, default(StreamingContext))
		{
		}

		public LzwException()
			: base(null, default(StreamingContext))
		{
		}

		public LzwException(string message)
			: base(null, default(StreamingContext))
		{
		}

		public LzwException(string message, Exception innerException)
			: base(null, default(StreamingContext))
		{
		}
	}
}
