using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.Zip
{
	[Serializable]
	public class ZipException : SharpZipBaseException
	{
		public ZipException()
		{
		}

		public ZipException(string message)
		{
		}

		public ZipException(string message, Exception innerException)
		{
		}

		protected ZipException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
