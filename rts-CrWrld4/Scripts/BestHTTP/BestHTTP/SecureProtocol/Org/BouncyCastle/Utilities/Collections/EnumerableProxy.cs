using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections
{
	public sealed class EnumerableProxy : IEnumerable
	{
		private readonly IEnumerable inner;

		public EnumerableProxy(IEnumerable inner)
		{
		}

		public IEnumerator GetEnumerator()
		{
			return null;
		}
	}
}
