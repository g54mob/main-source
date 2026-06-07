using System;
using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.OpenSsl
{
	[Serializable]
	public class PemException : IOException
	{
		public PemException(string message)
		{
		}

		public PemException(string message, Exception exception)
		{
		}
	}
}
