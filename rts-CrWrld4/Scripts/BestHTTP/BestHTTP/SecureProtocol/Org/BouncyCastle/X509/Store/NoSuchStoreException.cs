using System;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store
{
	[Serializable]
	public class NoSuchStoreException : X509StoreException
	{
		public NoSuchStoreException()
		{
		}

		public NoSuchStoreException(string message)
		{
		}

		public NoSuchStoreException(string message, Exception e)
		{
		}
	}
}
