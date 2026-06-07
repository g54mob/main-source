using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Agreement
{
	public class ECMqvWithKdfBasicAgreement : ECMqvBasicAgreement
	{
		private readonly string algorithm;

		private readonly IDerivationFunction kdf;

		public ECMqvWithKdfBasicAgreement(string algorithm, IDerivationFunction kdf)
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
