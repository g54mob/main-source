using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X500;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.IsisMtt.X509
{
	public class Restriction : Asn1Encodable
	{
		private readonly DirectoryString restriction;

		public virtual DirectoryString RestrictionString => null;

		public static Restriction GetInstance(object obj)
		{
			return null;
		}

		private Restriction(DirectoryString restriction)
		{
		}

		public Restriction(string restriction)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
