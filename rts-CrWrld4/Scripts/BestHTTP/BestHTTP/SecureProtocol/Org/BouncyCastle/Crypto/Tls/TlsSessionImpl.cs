namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	internal class TlsSessionImpl : TlsSession
	{
		internal readonly byte[] mSessionID;

		internal readonly SessionParameters mSessionParameters;

		internal bool mResumable;

		public virtual byte[] SessionID => null;

		public virtual bool IsResumable => false;

		internal TlsSessionImpl(byte[] sessionID, SessionParameters sessionParameters)
		{
		}

		public virtual SessionParameters ExportSessionParameters()
		{
			return null;
		}

		public virtual void Invalidate()
		{
		}
	}
}
