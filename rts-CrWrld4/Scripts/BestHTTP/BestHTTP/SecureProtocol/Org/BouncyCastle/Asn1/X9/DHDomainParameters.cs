using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X9
{
	public class DHDomainParameters : Asn1Encodable
	{
		private readonly DerInteger p;

		private readonly DerInteger g;

		private readonly DerInteger q;

		private readonly DerInteger j;

		private readonly DHValidationParms validationParms;

		public DerInteger P => null;

		public DerInteger G => null;

		public DerInteger Q => null;

		public DerInteger J => null;

		public DHValidationParms ValidationParms => null;

		public static DHDomainParameters GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public static DHDomainParameters GetInstance(object obj)
		{
			return null;
		}

		public DHDomainParameters(DerInteger p, DerInteger g, DerInteger q, DerInteger j, DHValidationParms validationParms)
		{
		}

		private DHDomainParameters(Asn1Sequence seq)
		{
		}

		private static Asn1Encodable GetNext(IEnumerator e)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
