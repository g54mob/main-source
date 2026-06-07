using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Agreement.Srp;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class SimulatedTlsSrpIdentityManager : TlsSrpIdentityManager
	{
		private static readonly byte[] PREFIX_PASSWORD;

		private static readonly byte[] PREFIX_SALT;

		protected readonly Srp6GroupParameters mGroup;

		protected readonly Srp6VerifierGenerator mVerifierGenerator;

		protected readonly IMac mMac;

		public static SimulatedTlsSrpIdentityManager GetRfc5054Default(Srp6GroupParameters group, byte[] seedKey)
		{
			return null;
		}

		public SimulatedTlsSrpIdentityManager(Srp6GroupParameters group, Srp6VerifierGenerator verifierGenerator, IMac mac)
		{
		}

		public virtual TlsSrpLoginParameters GetLoginParameters(byte[] identity)
		{
			return null;
		}
	}
}
