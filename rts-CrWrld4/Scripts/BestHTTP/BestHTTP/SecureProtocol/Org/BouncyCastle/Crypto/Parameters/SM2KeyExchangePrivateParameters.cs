using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class SM2KeyExchangePrivateParameters : ICipherParameters
	{
		private readonly bool mInitiator;

		private readonly ECPrivateKeyParameters mStaticPrivateKey;

		private readonly ECPoint mStaticPublicPoint;

		private readonly ECPrivateKeyParameters mEphemeralPrivateKey;

		private readonly ECPoint mEphemeralPublicPoint;

		public virtual bool IsInitiator => false;

		public virtual ECPrivateKeyParameters StaticPrivateKey => null;

		public virtual ECPoint StaticPublicPoint => null;

		public virtual ECPrivateKeyParameters EphemeralPrivateKey => null;

		public virtual ECPoint EphemeralPublicPoint => null;

		public SM2KeyExchangePrivateParameters(bool initiator, ECPrivateKeyParameters staticPrivateKey, ECPrivateKeyParameters ephemeralPrivateKey)
		{
		}
	}
}
