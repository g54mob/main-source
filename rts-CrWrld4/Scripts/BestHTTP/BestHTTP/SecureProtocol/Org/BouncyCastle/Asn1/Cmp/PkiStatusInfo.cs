using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class PkiStatusInfo : Asn1Encodable
	{
		private DerInteger status;

		private PkiFreeText statusString;

		private DerBitString failInfo;

		public BigInteger Status => null;

		public PkiFreeText StatusString => null;

		public DerBitString FailInfo => null;

		public static PkiStatusInfo GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public static PkiStatusInfo GetInstance(object obj)
		{
			return null;
		}

		public PkiStatusInfo(Asn1Sequence seq)
		{
		}

		public PkiStatusInfo(int status)
		{
		}

		public PkiStatusInfo(int status, PkiFreeText statusString)
		{
		}

		public PkiStatusInfo(int status, PkiFreeText statusString, PkiFailureInfo failInfo)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
