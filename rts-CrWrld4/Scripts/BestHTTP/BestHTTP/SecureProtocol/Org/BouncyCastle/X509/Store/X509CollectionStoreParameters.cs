using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store
{
	public class X509CollectionStoreParameters : IX509StoreParameters
	{
		private readonly IList collection;

		public X509CollectionStoreParameters(ICollection collection)
		{
		}

		public ICollection GetCollection()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
