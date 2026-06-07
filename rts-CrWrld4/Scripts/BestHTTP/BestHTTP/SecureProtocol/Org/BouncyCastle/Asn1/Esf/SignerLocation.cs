using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X500;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Esf
{
	public class SignerLocation : Asn1Encodable
	{
		private DirectoryString countryName;

		private DirectoryString localityName;

		private Asn1Sequence postalAddress;

		public DirectoryString Country => null;

		public DirectoryString Locality => null;

		public DerUtf8String CountryName => null;

		public DerUtf8String LocalityName => null;

		public Asn1Sequence PostalAddress => null;

		public SignerLocation(Asn1Sequence seq)
		{
		}

		private SignerLocation(DirectoryString countryName, DirectoryString localityName, Asn1Sequence postalAddress)
		{
		}

		public SignerLocation(DirectoryString countryName, DirectoryString localityName, DirectoryString[] postalAddress)
		{
		}

		public SignerLocation(DerUtf8String countryName, DerUtf8String localityName, Asn1Sequence postalAddress)
		{
		}

		public static SignerLocation GetInstance(object obj)
		{
			return null;
		}

		public DirectoryString[] GetPostal()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
