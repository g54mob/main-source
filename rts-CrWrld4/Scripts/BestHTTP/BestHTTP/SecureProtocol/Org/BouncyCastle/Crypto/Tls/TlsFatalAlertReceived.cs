namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class TlsFatalAlertReceived : TlsException
	{
		private readonly byte alertDescription;

		public virtual byte AlertDescription => 0;

		public TlsFatalAlertReceived(byte alertDescription)
			: base(null, null)
		{
		}
	}
}
