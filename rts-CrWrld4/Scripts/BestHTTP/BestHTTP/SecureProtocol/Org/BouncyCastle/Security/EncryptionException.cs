using System;
using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Security
{
	[Serializable]
	public class EncryptionException : IOException
	{
		public EncryptionException(string message)
		{
		}

		public EncryptionException(string message, Exception exception)
		{
		}
	}
}
