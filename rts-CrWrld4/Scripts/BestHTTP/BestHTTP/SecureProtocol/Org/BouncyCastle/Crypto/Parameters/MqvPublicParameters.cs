namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class MqvPublicParameters : ICipherParameters
	{
		private readonly ECPublicKeyParameters staticPublicKey;

		private readonly ECPublicKeyParameters ephemeralPublicKey;

		public virtual ECPublicKeyParameters StaticPublicKey => null;

		public virtual ECPublicKeyParameters EphemeralPublicKey => null;

		public MqvPublicParameters(ECPublicKeyParameters staticPublicKey, ECPublicKeyParameters ephemeralPublicKey)
		{
		}
	}
}
