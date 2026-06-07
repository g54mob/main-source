using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class NameConstraints : Asn1Encodable
	{
		private Asn1Sequence permitted;

		private Asn1Sequence excluded;

		public Asn1Sequence PermittedSubtrees => null;

		public Asn1Sequence ExcludedSubtrees => null;

		public static NameConstraints GetInstance(object obj)
		{
			return null;
		}

		public NameConstraints(Asn1Sequence seq)
		{
		}

		public NameConstraints(ArrayList permitted, ArrayList excluded)
		{
		}

		public NameConstraints(IList permitted, IList excluded)
		{
		}

		private DerSequence CreateSequence(IList subtrees)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
