using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public class PbeParameter : Asn1Encodable
	{
		private readonly Asn1OctetString salt;

		private readonly DerInteger iterationCount;

		public BigInteger IterationCount => null;

		public static PbeParameter GetInstance(object obj)
		{
			return null;
		}

		private PbeParameter(Asn1Sequence seq)
		{
		}

		public PbeParameter(byte[] salt, int iterationCount)
		{
		}

		public byte[] GetSalt()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
