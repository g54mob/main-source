using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.BZip2
{
	[Serializable]
	public class BZip2Exception : SharpZipBaseException
	{
		protected BZip2Exception(SerializationInfo info, StreamingContext context)
			: base(null, default(StreamingContext))
		{
		}

		public BZip2Exception()
			: base(null, default(StreamingContext))
		{
		}

		public BZip2Exception(string message)
			: base(null, default(StreamingContext))
		{
		}

		public BZip2Exception(string message, Exception exception)
			: base(null, default(StreamingContext))
		{
		}
	}
}
