using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib
{
	[Serializable]
	public class SharpZipBaseException : ApplicationException
	{
		protected SharpZipBaseException(SerializationInfo info, StreamingContext context)
		{
		}

		public SharpZipBaseException()
		{
		}

		public SharpZipBaseException(string message)
		{
		}

		public SharpZipBaseException(string message, Exception innerException)
		{
		}
	}
}
