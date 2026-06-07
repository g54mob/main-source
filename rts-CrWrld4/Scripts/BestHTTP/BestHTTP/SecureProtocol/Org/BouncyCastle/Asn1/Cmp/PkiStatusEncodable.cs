using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class PkiStatusEncodable : Asn1Encodable
	{
		public static readonly PkiStatusEncodable granted;

		public static readonly PkiStatusEncodable grantedWithMods;

		public static readonly PkiStatusEncodable rejection;

		public static readonly PkiStatusEncodable waiting;

		public static readonly PkiStatusEncodable revocationWarning;

		public static readonly PkiStatusEncodable revocationNotification;

		public static readonly PkiStatusEncodable keyUpdateWaiting;

		private readonly DerInteger status;

		public virtual BigInteger Value => null;

		private PkiStatusEncodable(PkiStatus status)
		{
		}

		private PkiStatusEncodable(DerInteger status)
		{
		}

		public static PkiStatusEncodable GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
