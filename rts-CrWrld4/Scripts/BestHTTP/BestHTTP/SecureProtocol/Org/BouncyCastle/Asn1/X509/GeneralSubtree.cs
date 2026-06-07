using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class GeneralSubtree : Asn1Encodable
	{
		private readonly GeneralName baseName;

		private readonly DerInteger minimum;

		private readonly DerInteger maximum;

		public GeneralName Base => null;

		public BigInteger Minimum => null;

		public BigInteger Maximum => null;

		private GeneralSubtree(Asn1Sequence seq)
		{
		}

		public GeneralSubtree(GeneralName baseName, BigInteger minimum, BigInteger maximum)
		{
		}

		public GeneralSubtree(GeneralName baseName)
		{
		}

		public static GeneralSubtree GetInstance(Asn1TaggedObject o, bool isExplicit)
		{
			return null;
		}

		public static GeneralSubtree GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
