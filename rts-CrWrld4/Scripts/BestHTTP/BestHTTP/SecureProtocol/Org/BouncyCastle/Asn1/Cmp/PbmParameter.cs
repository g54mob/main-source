using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class PbmParameter : Asn1Encodable
	{
		private Asn1OctetString salt;

		private AlgorithmIdentifier owf;

		private DerInteger iterationCount;

		private AlgorithmIdentifier mac;

		public virtual Asn1OctetString Salt => null;

		public virtual AlgorithmIdentifier Owf => null;

		public virtual DerInteger IterationCount => null;

		public virtual AlgorithmIdentifier Mac => null;

		private PbmParameter(Asn1Sequence seq)
		{
		}

		public static PbmParameter GetInstance(object obj)
		{
			return null;
		}

		public PbmParameter(byte[] salt, AlgorithmIdentifier owf, int iterationCount, AlgorithmIdentifier mac)
		{
		}

		public PbmParameter(Asn1OctetString salt, AlgorithmIdentifier owf, DerInteger iterationCount, AlgorithmIdentifier mac)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
