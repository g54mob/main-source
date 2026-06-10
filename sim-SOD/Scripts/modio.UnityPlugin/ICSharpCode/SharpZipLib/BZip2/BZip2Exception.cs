using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.BZip2
{
	[Serializable]
	public class BZip2Exception : SharpZipBaseException
	{
		public BZip2Exception()
		{
		}

		public BZip2Exception(string message)
		{
		}

		public BZip2Exception(string message, Exception innerException)
		{
		}

		protected BZip2Exception(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
