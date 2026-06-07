using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X9
{
	public class X9FieldID : Asn1Encodable
	{
		private readonly DerObjectIdentifier id;

		private readonly Asn1Object parameters;

		public DerObjectIdentifier Identifier => null;

		public Asn1Object Parameters => null;

		public X9FieldID(BigInteger primeP)
		{
		}

		public X9FieldID(int m, int k1)
		{
		}

		public X9FieldID(int m, int k1, int k2, int k3)
		{
		}

		private X9FieldID(Asn1Sequence seq)
		{
		}

		public static X9FieldID GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
