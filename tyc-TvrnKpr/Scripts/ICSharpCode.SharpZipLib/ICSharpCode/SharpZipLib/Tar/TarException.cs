using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.Tar
{
	[Serializable]
	public class TarException : SharpZipBaseException
	{
		protected TarException(SerializationInfo info, StreamingContext context)
			: base(null, default(StreamingContext))
		{
		}

		public TarException()
			: base(null, default(StreamingContext))
		{
		}

		public TarException(string message)
			: base(null, default(StreamingContext))
		{
		}

		public TarException(string message, Exception exception)
			: base(null, default(StreamingContext))
		{
		}
	}
}
