using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509.Store
{
	internal class X509CollectionStore : IX509Store
	{
		private ICollection _local;

		internal X509CollectionStore(ICollection collection)
		{
		}

		public ICollection GetMatches(IX509Selector selector)
		{
			return null;
		}
	}
}
