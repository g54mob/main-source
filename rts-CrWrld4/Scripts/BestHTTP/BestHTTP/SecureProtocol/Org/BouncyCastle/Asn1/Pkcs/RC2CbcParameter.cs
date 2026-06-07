using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public class RC2CbcParameter : Asn1Encodable
	{
		internal DerInteger version;

		internal Asn1OctetString iv;

		public BigInteger RC2ParameterVersion => null;

		public static RC2CbcParameter GetInstance(object obj)
		{
			return null;
		}

		public RC2CbcParameter(byte[] iv)
		{
		}

		public RC2CbcParameter(int parameterVersion, byte[] iv)
		{
		}

		private RC2CbcParameter(Asn1Sequence seq)
		{
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
