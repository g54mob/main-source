using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X500;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509.SigI
{
	public class NameOrPseudonym : Asn1Encodable, IAsn1Choice
	{
		private readonly DirectoryString pseudonym;

		private readonly DirectoryString surname;

		private readonly Asn1Sequence givenName;

		public DirectoryString Pseudonym => null;

		public DirectoryString Surname => null;

		public static NameOrPseudonym GetInstance(object obj)
		{
			return null;
		}

		public NameOrPseudonym(DirectoryString pseudonym)
		{
		}

		private NameOrPseudonym(Asn1Sequence seq)
		{
		}

		public NameOrPseudonym(string pseudonym)
		{
		}

		public NameOrPseudonym(DirectoryString surname, Asn1Sequence givenName)
		{
		}

		public DirectoryString[] GetGivenName()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
