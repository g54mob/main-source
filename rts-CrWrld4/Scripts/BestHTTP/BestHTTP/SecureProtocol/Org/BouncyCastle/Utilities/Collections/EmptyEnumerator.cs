using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections
{
	public sealed class EmptyEnumerator : IEnumerator
	{
		public static readonly IEnumerator Instance;

		public object Current => null;

		private EmptyEnumerator()
		{
		}

		public bool MoveNext()
		{
			return false;
		}

		public void Reset()
		{
		}
	}
}
