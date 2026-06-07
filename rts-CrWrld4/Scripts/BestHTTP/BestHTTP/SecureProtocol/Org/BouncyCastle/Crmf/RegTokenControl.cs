using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crmf
{
	public class RegTokenControl : IControl
	{
		private static readonly DerObjectIdentifier type;

		private readonly DerUtf8String token;

		public DerObjectIdentifier Type => null;

		public Asn1Encodable Value => null;

		public RegTokenControl(DerUtf8String token)
		{
		}

		public RegTokenControl(string token)
		{
		}
	}
}
