namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class KeyRecRepContent : Asn1Encodable
	{
		private readonly PkiStatusInfo status;

		private readonly CmpCertificate newSigCert;

		private readonly Asn1Sequence caCerts;

		private readonly Asn1Sequence keyPairHist;

		public virtual PkiStatusInfo Status => null;

		public virtual CmpCertificate NewSigCert => null;

		private KeyRecRepContent(Asn1Sequence seq)
		{
		}

		public static KeyRecRepContent GetInstance(object obj)
		{
			return null;
		}

		public virtual CmpCertificate[] GetCACerts()
		{
			return null;
		}

		public virtual CertifiedKeyPair[] GetKeyPairHist()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
