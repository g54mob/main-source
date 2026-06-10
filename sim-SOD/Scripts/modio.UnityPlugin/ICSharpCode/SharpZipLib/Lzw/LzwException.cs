using System;
using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib.Lzw
{
	[Serializable]
	public class LzwException : SharpZipBaseException
	{
		public LzwException()
		{
		}

		public LzwException(string message)
		{
		}

		public LzwException(string message, Exception innerException)
		{
		}

		protected LzwException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
