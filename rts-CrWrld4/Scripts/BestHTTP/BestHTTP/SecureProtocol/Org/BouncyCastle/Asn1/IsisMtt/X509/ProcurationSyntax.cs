using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X500;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.IsisMtt.X509
{
	public class ProcurationSyntax : Asn1Encodable
	{
		private readonly string country;

		private readonly DirectoryString typeOfSubstitution;

		private readonly GeneralName thirdPerson;

		private readonly IssuerSerial certRef;

		public virtual string Country => null;

		public virtual DirectoryString TypeOfSubstitution => null;

		public virtual GeneralName ThirdPerson => null;

		public virtual IssuerSerial CertRef => null;

		public static ProcurationSyntax GetInstance(object obj)
		{
			return null;
		}

		private ProcurationSyntax(Asn1Sequence seq)
		{
		}

		public ProcurationSyntax(string country, DirectoryString typeOfSubstitution, IssuerSerial certRef)
		{
		}

		public ProcurationSyntax(string country, DirectoryString typeOfSubstitution, GeneralName thirdPerson)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
