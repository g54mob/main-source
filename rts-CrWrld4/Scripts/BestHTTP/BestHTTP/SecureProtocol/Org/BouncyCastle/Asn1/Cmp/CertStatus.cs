using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class CertStatus : Asn1Encodable
	{
		private readonly Asn1OctetString certHash;

		private readonly DerInteger certReqId;

		private readonly PkiStatusInfo statusInfo;

		public virtual Asn1OctetString CertHash => null;

		public virtual DerInteger CertReqID => null;

		public virtual PkiStatusInfo StatusInfo => null;

		private CertStatus(Asn1Sequence seq)
		{
		}

		public CertStatus(byte[] certHash, BigInteger certReqId)
		{
		}

		public CertStatus(byte[] certHash, BigInteger certReqId, PkiStatusInfo statusInfo)
		{
		}

		public static CertStatus GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
