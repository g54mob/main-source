namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public abstract class AlertLevel
	{
		public const byte warning = 1;

		public const byte fatal = 2;

		public static string GetName(byte alertDescription)
		{
			return null;
		}

		public static string GetText(byte alertDescription)
		{
			return null;
		}
	}
}
