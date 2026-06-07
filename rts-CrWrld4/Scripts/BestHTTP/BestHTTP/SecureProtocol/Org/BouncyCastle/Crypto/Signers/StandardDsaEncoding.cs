using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Signers
{
	public class StandardDsaEncoding : IDsaEncoding
	{
		public static readonly StandardDsaEncoding Instance;

		public virtual BigInteger[] Decode(BigInteger n, byte[] encoding)
		{
			return null;
		}

		public virtual byte[] Encode(BigInteger n, BigInteger r, BigInteger s)
		{
			return null;
		}

		protected virtual BigInteger CheckValue(BigInteger n, BigInteger x)
		{
			return null;
		}

		protected virtual BigInteger DecodeValue(BigInteger n, Asn1Sequence s, int pos)
		{
			return null;
		}

		protected virtual DerInteger EncodeValue(BigInteger n, BigInteger x)
		{
			return null;
		}
	}
}
