using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Agreement
{
	public class ECDHWithKdfBasicAgreement : ECDHBasicAgreement
	{
		private readonly string algorithm;

		private readonly IDerivationFunction kdf;

		public ECDHWithKdfBasicAgreement(string algorithm, IDerivationFunction kdf)
		{
		}

		public override BigInteger CalculateAgreement(ICipherParameters pubKey)
		{
			return null;
		}

		private byte[] BigIntToBytes(BigInteger r)
		{
			return null;
		}
	}
}
