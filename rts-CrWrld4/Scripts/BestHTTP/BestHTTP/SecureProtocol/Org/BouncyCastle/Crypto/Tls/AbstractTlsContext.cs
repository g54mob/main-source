using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Prng;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	internal abstract class AbstractTlsContext : TlsContext
	{
		private static long counter;

		private readonly IRandomGenerator mNonceRandom;

		private readonly SecureRandom mSecureRandom;

		private readonly SecurityParameters mSecurityParameters;

		private ProtocolVersion mClientVersion;

		private ProtocolVersion mServerVersion;

		private TlsSession mSession;

		private object mUserObject;

		public virtual IRandomGenerator NonceRandomGenerator => null;

		public virtual SecureRandom SecureRandom => null;

		public virtual SecurityParameters SecurityParameters => null;

		public abstract bool IsServer { get; }

		public virtual ProtocolVersion ClientVersion => null;

		public virtual ProtocolVersion ServerVersion => null;

		public virtual TlsSession ResumableSession => null;

		public virtual object UserObject
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private static long NextCounterValue()
		{
			return 0L;
		}

		internal AbstractTlsContext(SecureRandom secureRandom, SecurityParameters securityParameters)
		{
		}

		internal virtual void SetClientVersion(ProtocolVersion clientVersion)
		{
		}

		internal virtual void SetServerVersion(ProtocolVersion serverVersion)
		{
		}

		internal virtual void SetResumableSession(TlsSession session)
		{
		}

		public virtual byte[] ExportKeyingMaterial(string asciiLabel, byte[] context_value, int length)
		{
			return null;
		}
	}
}
