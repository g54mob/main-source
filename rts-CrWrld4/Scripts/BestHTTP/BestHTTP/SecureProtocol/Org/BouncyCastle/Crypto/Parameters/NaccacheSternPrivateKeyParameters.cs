using System;
using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class NaccacheSternPrivateKeyParameters : NaccacheSternKeyParameters
	{
		private readonly BigInteger phiN;

		private readonly IList smallPrimes;

		public BigInteger PhiN => null;

		public ArrayList SmallPrimes => null;

		public IList SmallPrimesList => null;

		[Obsolete]
		public NaccacheSternPrivateKeyParameters(BigInteger g, BigInteger n, int lowerSigmaBound, ArrayList smallPrimes, BigInteger phiN)
			: base(privateKey: false, null, null, 0)
		{
		}

		public NaccacheSternPrivateKeyParameters(BigInteger g, BigInteger n, int lowerSigmaBound, IList smallPrimes, BigInteger phiN)
			: base(privateKey: false, null, null, 0)
		{
		}
	}
}
