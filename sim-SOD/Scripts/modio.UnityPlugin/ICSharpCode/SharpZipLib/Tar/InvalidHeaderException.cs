using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.Tar
{
	[Serializable]
	public class InvalidHeaderException : TarException
	{
		public InvalidHeaderException()
		{
		}

		public InvalidHeaderException(string message)
		{
		}

		public InvalidHeaderException(string message, Exception exception)
		{
		}

		protected InvalidHeaderException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
