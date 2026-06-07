namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class SignedData : Asn1Encodable
	{
		private static readonly DerInteger Version1;

		private static readonly DerInteger Version3;

		private static readonly DerInteger Version4;

		private static readonly DerInteger Version5;

		private readonly DerInteger version;

		private readonly Asn1Set digestAlgorithms;

		private readonly ContentInfo contentInfo;

		private readonly Asn1Set certificates;

		private readonly Asn1Set crls;

		private readonly Asn1Set signerInfos;

		private readonly bool certsBer;

		private readonly bool crlsBer;

		public DerInteger Version => null;

		public Asn1Set DigestAlgorithms => null;

		public ContentInfo EncapContentInfo => null;

		public Asn1Set Certificates => null;

		public Asn1Set CRLs => null;

		public Asn1Set SignerInfos => null;

		public static SignedData GetInstance(object obj)
		{
			return null;
		}

		public SignedData(Asn1Set digestAlgorithms, ContentInfo contentInfo, Asn1Set certificates, Asn1Set crls, Asn1Set signerInfos)
		{
		}

		private DerInteger CalculateVersion(DerObjectIdentifier contentOid, Asn1Set certs, Asn1Set crls, Asn1Set signerInfs)
		{
			return null;
		}

		private bool CheckForVersion3(Asn1Set signerInfs)
		{
			return false;
		}

		private SignedData(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
