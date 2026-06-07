using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Agreement.JPake
{
	public class JPakePrimeOrderGroup
	{
		private readonly BigInteger p;

		private readonly BigInteger q;

		private readonly BigInteger g;

		public virtual BigInteger P => null;

		public virtual BigInteger Q => null;

		public virtual BigInteger G => null;

		public JPakePrimeOrderGroup(BigInteger p, BigInteger q, BigInteger g)
		{
		}

		public JPakePrimeOrderGroup(BigInteger p, BigInteger q, BigInteger g, bool skipChecks)
		{
		}
	}
}
