using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.Tar
{
	[Serializable]
	public class TarException : SharpZipBaseException
	{
		public TarException()
		{
		}

		public TarException(string message)
		{
		}

		public TarException(string message, Exception innerException)
		{
		}

		protected TarException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
