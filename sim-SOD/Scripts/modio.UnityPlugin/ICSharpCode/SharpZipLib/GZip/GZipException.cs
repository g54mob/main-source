using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.GZip
{
	[Serializable]
	public class GZipException : SharpZipBaseException
	{
		public GZipException()
		{
		}

		public GZipException(string message)
		{
		}

		public GZipException(string message, Exception innerException)
		{
		}

		protected GZipException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
