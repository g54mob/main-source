namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class PkiMessage : Asn1Encodable
	{
		private readonly PkiHeader header;

		private readonly PkiBody body;

		private readonly DerBitString protection;

		private readonly Asn1Sequence extraCerts;

		public virtual PkiHeader Header => null;

		public virtual PkiBody Body => null;

		public virtual DerBitString Protection => null;

		private PkiMessage(Asn1Sequence seq)
		{
		}

		public static PkiMessage GetInstance(object obj)
		{
			return null;
		}

		public PkiMessage(PkiHeader header, PkiBody body, DerBitString protection, CmpCertificate[] extraCerts)
		{
		}

		public PkiMessage(PkiHeader header, PkiBody body, DerBitString protection)
		{
		}

		public PkiMessage(PkiHeader header, PkiBody body)
		{
		}

		public virtual CmpCertificate[] GetExtraCerts()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
