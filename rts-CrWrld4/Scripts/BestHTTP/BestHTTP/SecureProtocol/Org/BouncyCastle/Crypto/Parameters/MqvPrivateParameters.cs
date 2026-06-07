namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class MqvPrivateParameters : ICipherParameters
	{
		private readonly ECPrivateKeyParameters staticPrivateKey;

		private readonly ECPrivateKeyParameters ephemeralPrivateKey;

		private readonly ECPublicKeyParameters ephemeralPublicKey;

		public virtual ECPrivateKeyParameters StaticPrivateKey => null;

		public virtual ECPrivateKeyParameters EphemeralPrivateKey => null;

		public virtual ECPublicKeyParameters EphemeralPublicKey => null;

		public MqvPrivateParameters(ECPrivateKeyParameters staticPrivateKey, ECPrivateKeyParameters ephemeralPrivateKey)
		{
		}

		public MqvPrivateParameters(ECPrivateKeyParameters staticPrivateKey, ECPrivateKeyParameters ephemeralPrivateKey, ECPublicKeyParameters ephemeralPublicKey)
		{
		}
	}
}
