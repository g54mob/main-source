using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public class MacData : Asn1Encodable
	{
		internal DigestInfo digInfo;

		internal byte[] salt;

		internal BigInteger iterationCount;

		public DigestInfo Mac => null;

		public BigInteger IterationCount => null;

		public static MacData GetInstance(object obj)
		{
			return null;
		}

		private MacData(Asn1Sequence seq)
		{
		}

		public MacData(DigestInfo digInfo, byte[] salt, int iterationCount)
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
