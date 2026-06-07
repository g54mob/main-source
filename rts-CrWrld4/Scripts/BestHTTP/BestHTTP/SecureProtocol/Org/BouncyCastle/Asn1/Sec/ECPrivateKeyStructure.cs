using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Sec
{
	public class ECPrivateKeyStructure : Asn1Encodable
	{
		private readonly Asn1Sequence seq;

		public static ECPrivateKeyStructure GetInstance(object obj)
		{
			return null;
		}

		public ECPrivateKeyStructure(Asn1Sequence seq)
		{
		}

		public ECPrivateKeyStructure(BigInteger key)
		{
		}

		public ECPrivateKeyStructure(int orderBitLength, BigInteger key)
		{
		}

		public ECPrivateKeyStructure(BigInteger key, Asn1Encodable parameters)
		{
		}

		public ECPrivateKeyStructure(BigInteger key, DerBitString publicKey, Asn1Encodable parameters)
		{
		}

		public ECPrivateKeyStructure(int orderBitLength, BigInteger key, Asn1Encodable parameters)
		{
		}

		public ECPrivateKeyStructure(int orderBitLength, BigInteger key, DerBitString publicKey, Asn1Encodable parameters)
		{
		}

		public virtual BigInteger GetKey()
		{
			return null;
		}

		public virtual DerBitString GetPublicKey()
		{
			return null;
		}

		public virtual Asn1Object GetParameters()
		{
			return null;
		}

		private Asn1Object GetObjectInTag(int tagNo)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
