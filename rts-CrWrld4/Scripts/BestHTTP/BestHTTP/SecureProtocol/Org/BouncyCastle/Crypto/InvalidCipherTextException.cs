using System;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto
{
	[Serializable]
	public class InvalidCipherTextException : CryptoException
	{
		public InvalidCipherTextException()
		{
		}

		public InvalidCipherTextException(string message)
		{
		}

		public InvalidCipherTextException(string message, Exception exception)
		{
		}
	}
}
