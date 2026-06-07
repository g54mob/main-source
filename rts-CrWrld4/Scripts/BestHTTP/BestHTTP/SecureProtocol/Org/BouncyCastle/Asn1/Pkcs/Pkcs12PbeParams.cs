using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public class Pkcs12PbeParams : Asn1Encodable
	{
		private readonly DerInteger iterations;

		private readonly Asn1OctetString iv;

		public BigInteger Iterations => null;

		public Pkcs12PbeParams(byte[] salt, int iterations)
		{
		}

		private Pkcs12PbeParams(Asn1Sequence seq)
		{
		}

		public static Pkcs12PbeParams GetInstance(object obj)
		{
			return null;
		}

		public byte[] GetIV()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
