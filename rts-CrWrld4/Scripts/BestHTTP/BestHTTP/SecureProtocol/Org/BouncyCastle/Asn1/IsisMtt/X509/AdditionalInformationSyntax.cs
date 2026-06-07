using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X500;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.IsisMtt.X509
{
	public class AdditionalInformationSyntax : Asn1Encodable
	{
		private readonly DirectoryString information;

		public virtual DirectoryString Information => null;

		public static AdditionalInformationSyntax GetInstance(object obj)
		{
			return null;
		}

		private AdditionalInformationSyntax(DirectoryString information)
		{
		}

		public AdditionalInformationSyntax(string information)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
