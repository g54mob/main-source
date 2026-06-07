namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class SM2KeyExchangePublicParameters : ICipherParameters
	{
		private readonly ECPublicKeyParameters mStaticPublicKey;

		private readonly ECPublicKeyParameters mEphemeralPublicKey;

		public virtual ECPublicKeyParameters StaticPublicKey => null;

		public virtual ECPublicKeyParameters EphemeralPublicKey => null;

		public SM2KeyExchangePublicParameters(ECPublicKeyParameters staticPublicKey, ECPublicKeyParameters ephemeralPublicKey)
		{
		}
	}
}
