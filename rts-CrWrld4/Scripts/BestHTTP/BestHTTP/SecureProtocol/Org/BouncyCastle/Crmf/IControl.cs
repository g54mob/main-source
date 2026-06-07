using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crmf
{
	public interface IControl
	{
		DerObjectIdentifier Type { get; }

		Asn1Encodable Value { get; }
	}
}
