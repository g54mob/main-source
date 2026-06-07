using System;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public abstract class AbstractTlsPeer : TlsPeer
	{
		private TlsCloseable mCloseHandle;

		public virtual void Cancel()
		{
		}

		public virtual void NotifyCloseHandle(TlsCloseable closeHandle)
		{
		}

		public virtual bool RequiresExtendedMasterSecret()
		{
			return false;
		}

		public virtual bool ShouldUseGmtUnixTime()
		{
			return false;
		}

		public virtual void NotifySecureRenegotiation(bool secureRenegotiation)
		{
		}

		public abstract TlsCompression GetCompression();

		public abstract TlsCipher GetCipher();

		public virtual void NotifyAlertRaised(byte alertLevel, byte alertDescription, string message, Exception cause)
		{
		}

		public virtual void NotifyAlertReceived(byte alertLevel, byte alertDescription)
		{
		}

		public virtual void NotifyHandshakeComplete()
		{
		}
	}
}
