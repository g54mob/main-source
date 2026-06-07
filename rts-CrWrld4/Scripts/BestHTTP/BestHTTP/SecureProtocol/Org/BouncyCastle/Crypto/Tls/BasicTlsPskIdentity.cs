namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class BasicTlsPskIdentity : TlsPskIdentity
	{
		protected byte[] mIdentity;

		protected byte[] mPsk;

		public BasicTlsPskIdentity(byte[] identity, byte[] psk)
		{
		}

		public BasicTlsPskIdentity(string identity, byte[] psk)
		{
		}

		public virtual void SkipIdentityHint()
		{
		}

		public virtual void NotifyIdentityHint(byte[] psk_identity_hint)
		{
		}

		public virtual byte[] GetPskIdentity()
		{
			return null;
		}

		public virtual byte[] GetPsk()
		{
			return null;
		}
	}
}
