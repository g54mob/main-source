using System;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class TlsFatalAlert : TlsException
	{
		private readonly byte alertDescription;

		public virtual byte AlertDescription => 0;

		public TlsFatalAlert(byte alertDescription)
			: base(null, null)
		{
		}

		public TlsFatalAlert(byte alertDescription, Exception alertCause)
			: base(null, null)
		{
		}
	}
}
