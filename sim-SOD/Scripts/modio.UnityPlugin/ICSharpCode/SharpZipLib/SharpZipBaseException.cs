using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib
{
	[Serializable]
	public class SharpZipBaseException : Exception
	{
		public SharpZipBaseException()
		{
		}

		public SharpZipBaseException(string message)
		{
		}

		public SharpZipBaseException(string message, Exception innerException)
		{
		}

		protected SharpZipBaseException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
