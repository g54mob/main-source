using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X500;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509.SigI
{
	public class PersonalData : Asn1Encodable
	{
		private readonly NameOrPseudonym nameOrPseudonym;

		private readonly BigInteger nameDistinguisher;

		private readonly DerGeneralizedTime dateOfBirth;

		private readonly DirectoryString placeOfBirth;

		private readonly string gender;

		private readonly DirectoryString postalAddress;

		public NameOrPseudonym NameOrPseudonym => null;

		public BigInteger NameDistinguisher => null;

		public DerGeneralizedTime DateOfBirth => null;

		public DirectoryString PlaceOfBirth => null;

		public string Gender => null;

		public DirectoryString PostalAddress => null;

		public static PersonalData GetInstance(object obj)
		{
			return null;
		}

		private PersonalData(Asn1Sequence seq)
		{
		}

		public PersonalData(NameOrPseudonym nameOrPseudonym, BigInteger nameDistinguisher, DerGeneralizedTime dateOfBirth, DirectoryString placeOfBirth, string gender, DirectoryString postalAddress)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
