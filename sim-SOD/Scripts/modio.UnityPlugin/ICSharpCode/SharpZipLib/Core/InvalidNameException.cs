using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.Core
{
	[Serializable]
	public class InvalidNameException : SharpZipBaseException
	{
		public InvalidNameException()
		{
		}

		public InvalidNameException(string message)
		{
		}

		public InvalidNameException(string message, Exception innerException)
		{
		}

		protected InvalidNameException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
