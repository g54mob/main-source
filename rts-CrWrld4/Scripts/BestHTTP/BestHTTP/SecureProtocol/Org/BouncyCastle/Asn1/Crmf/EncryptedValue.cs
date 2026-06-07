using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf
{
	public class EncryptedValue : Asn1Encodable
	{
		private readonly AlgorithmIdentifier intendedAlg;

		private readonly AlgorithmIdentifier symmAlg;

		private readonly DerBitString encSymmKey;

		private readonly AlgorithmIdentifier keyAlg;

		private readonly Asn1OctetString valueHint;

		private readonly DerBitString encValue;

		public virtual AlgorithmIdentifier IntendedAlg => null;

		public virtual AlgorithmIdentifier SymmAlg => null;

		public virtual DerBitString EncSymmKey => null;

		public virtual AlgorithmIdentifier KeyAlg => null;

		public virtual Asn1OctetString ValueHint => null;

		public virtual DerBitString EncValue => null;

		private EncryptedValue(Asn1Sequence seq)
		{
		}

		public static EncryptedValue GetInstance(object obj)
		{
			return null;
		}

		public EncryptedValue(AlgorithmIdentifier intendedAlg, AlgorithmIdentifier symmAlg, DerBitString encSymmKey, AlgorithmIdentifier keyAlg, Asn1OctetString valueHint, DerBitString encValue)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
