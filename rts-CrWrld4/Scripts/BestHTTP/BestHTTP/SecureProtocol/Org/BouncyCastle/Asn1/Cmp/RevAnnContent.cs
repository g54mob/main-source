using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class RevAnnContent : Asn1Encodable
	{
		private readonly PkiStatusEncodable status;

		private readonly CertId certId;

		private readonly DerGeneralizedTime willBeRevokedAt;

		private readonly DerGeneralizedTime badSinceDate;

		private readonly X509Extensions crlDetails;

		public virtual PkiStatusEncodable Status => null;

		public virtual CertId CertID => null;

		public virtual DerGeneralizedTime WillBeRevokedAt => null;

		public virtual DerGeneralizedTime BadSinceDate => null;

		public virtual X509Extensions CrlDetails => null;

		private RevAnnContent(Asn1Sequence seq)
		{
		}

		public static RevAnnContent GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
