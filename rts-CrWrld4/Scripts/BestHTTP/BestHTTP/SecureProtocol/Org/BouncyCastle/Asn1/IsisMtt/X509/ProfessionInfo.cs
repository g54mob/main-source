using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X500;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.IsisMtt.X509
{
	public class ProfessionInfo : Asn1Encodable
	{
		public static readonly DerObjectIdentifier Rechtsanwltin;

		public static readonly DerObjectIdentifier Rechtsanwalt;

		public static readonly DerObjectIdentifier Rechtsbeistand;

		public static readonly DerObjectIdentifier Steuerberaterin;

		public static readonly DerObjectIdentifier Steuerberater;

		public static readonly DerObjectIdentifier Steuerbevollmchtigte;

		public static readonly DerObjectIdentifier Steuerbevollmchtigter;

		public static readonly DerObjectIdentifier Notarin;

		public static readonly DerObjectIdentifier Notar;

		public static readonly DerObjectIdentifier Notarvertreterin;

		public static readonly DerObjectIdentifier Notarvertreter;

		public static readonly DerObjectIdentifier Notariatsverwalterin;

		public static readonly DerObjectIdentifier Notariatsverwalter;

		public static readonly DerObjectIdentifier Wirtschaftsprferin;

		public static readonly DerObjectIdentifier Wirtschaftsprfer;

		public static readonly DerObjectIdentifier VereidigteBuchprferin;

		public static readonly DerObjectIdentifier VereidigterBuchprfer;

		public static readonly DerObjectIdentifier Patentanwltin;

		public static readonly DerObjectIdentifier Patentanwalt;

		private readonly NamingAuthority namingAuthority;

		private readonly Asn1Sequence professionItems;

		private readonly Asn1Sequence professionOids;

		private readonly string registrationNumber;

		private readonly Asn1OctetString addProfessionInfo;

		public virtual Asn1OctetString AddProfessionInfo => null;

		public virtual NamingAuthority NamingAuthority => null;

		public virtual string RegistrationNumber => null;

		public static ProfessionInfo GetInstance(object obj)
		{
			return null;
		}

		private ProfessionInfo(Asn1Sequence seq)
		{
		}

		public ProfessionInfo(NamingAuthority namingAuthority, DirectoryString[] professionItems, DerObjectIdentifier[] professionOids, string registrationNumber, Asn1OctetString addProfessionInfo)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}

		public virtual DirectoryString[] GetProfessionItems()
		{
			return null;
		}

		public virtual DerObjectIdentifier[] GetProfessionOids()
		{
			return null;
		}
	}
}
