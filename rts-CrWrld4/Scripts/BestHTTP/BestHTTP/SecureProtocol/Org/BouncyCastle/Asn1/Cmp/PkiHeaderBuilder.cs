using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class PkiHeaderBuilder
	{
		private DerInteger pvno;

		private GeneralName sender;

		private GeneralName recipient;

		private DerGeneralizedTime messageTime;

		private AlgorithmIdentifier protectionAlg;

		private Asn1OctetString senderKID;

		private Asn1OctetString recipKID;

		private Asn1OctetString transactionID;

		private Asn1OctetString senderNonce;

		private Asn1OctetString recipNonce;

		private PkiFreeText freeText;

		private Asn1Sequence generalInfo;

		public PkiHeaderBuilder(int pvno, GeneralName sender, GeneralName recipient)
		{
		}

		private PkiHeaderBuilder(DerInteger pvno, GeneralName sender, GeneralName recipient)
		{
		}

		public virtual PkiHeaderBuilder SetMessageTime(DerGeneralizedTime time)
		{
			return null;
		}

		public virtual PkiHeaderBuilder SetProtectionAlg(AlgorithmIdentifier aid)
		{
			return null;
		}

		public virtual PkiHeaderBuilder SetSenderKID(byte[] kid)
		{
			return null;
		}

		public virtual PkiHeaderBuilder SetSenderKID(Asn1OctetString kid)
		{
			return null;
		}

		public virtual PkiHeaderBuilder SetRecipKID(byte[] kid)
		{
			return null;
		}

		public virtual PkiHeaderBuilder SetRecipKID(DerOctetString kid)
		{
			return null;
		}

		public virtual PkiHeaderBuilder SetTransactionID(byte[] tid)
		{
			return null;
		}

		public virtual PkiHeaderBuilder SetTransactionID(Asn1OctetString tid)
		{
			return null;
		}

		public virtual PkiHeaderBuilder SetSenderNonce(byte[] nonce)
		{
			return null;
		}

		public virtual PkiHeaderBuilder SetSenderNonce(Asn1OctetString nonce)
		{
			return null;
		}

		public virtual PkiHeaderBuilder SetRecipNonce(byte[] nonce)
		{
			return null;
		}

		public virtual PkiHeaderBuilder SetRecipNonce(Asn1OctetString nonce)
		{
			return null;
		}

		public virtual PkiHeaderBuilder SetFreeText(PkiFreeText text)
		{
			return null;
		}

		public virtual PkiHeaderBuilder SetGeneralInfo(InfoTypeAndValue genInfo)
		{
			return null;
		}

		public virtual PkiHeaderBuilder SetGeneralInfo(InfoTypeAndValue[] genInfos)
		{
			return null;
		}

		public virtual PkiHeaderBuilder SetGeneralInfo(Asn1Sequence seqOfInfoTypeAndValue)
		{
			return null;
		}

		private static Asn1Sequence MakeGeneralInfoSeq(InfoTypeAndValue generalInfo)
		{
			return null;
		}

		private static Asn1Sequence MakeGeneralInfoSeq(InfoTypeAndValue[] generalInfos)
		{
			return null;
		}

		public virtual PkiHeader Build()
		{
			return null;
		}

		private void AddOptional(Asn1EncodableVector v, int tagNo, Asn1Encodable obj)
		{
		}
	}
}
