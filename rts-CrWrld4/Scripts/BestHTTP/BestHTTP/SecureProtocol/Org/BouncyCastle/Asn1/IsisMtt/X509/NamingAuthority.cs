using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X500;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.IsisMtt.X509
{
	public class NamingAuthority : Asn1Encodable
	{
		public static readonly DerObjectIdentifier IdIsisMttATNamingAuthoritiesRechtWirtschaftSteuern;

		private readonly DerObjectIdentifier namingAuthorityID;

		private readonly string namingAuthorityUrl;

		private readonly DirectoryString namingAuthorityText;

		public virtual DerObjectIdentifier NamingAuthorityID => null;

		public virtual DirectoryString NamingAuthorityText => null;

		public virtual string NamingAuthorityUrl => null;

		public static NamingAuthority GetInstance(object obj)
		{
			return null;
		}

		public static NamingAuthority GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		private NamingAuthority(Asn1Sequence seq)
		{
		}

		public NamingAuthority(DerObjectIdentifier namingAuthorityID, string namingAuthorityUrl, DirectoryString namingAuthorityText)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
