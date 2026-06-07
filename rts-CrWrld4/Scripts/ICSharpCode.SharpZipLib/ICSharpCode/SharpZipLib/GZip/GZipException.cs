using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.GZip
{
	[Serializable]
	public class GZipException : SharpZipBaseException
	{
		protected GZipException(SerializationInfo info, StreamingContext context)
			: base(null, default(StreamingContext))
		{
		}

		public GZipException()
			: base(null, default(StreamingContext))
		{
		}

		public GZipException(string message)
			: base(null, default(StreamingContext))
		{
		}
	}
}
