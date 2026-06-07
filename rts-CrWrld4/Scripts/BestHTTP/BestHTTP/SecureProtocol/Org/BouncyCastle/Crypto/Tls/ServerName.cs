using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class ServerName
	{
		protected readonly byte mNameType;

		protected readonly object mName;

		public virtual byte NameType => 0;

		public virtual object Name => null;

		public ServerName(byte nameType, object name)
		{
		}

		public virtual string GetHostName()
		{
			return null;
		}

		public virtual void Encode(Stream output)
		{
		}

		public static ServerName Parse(Stream input)
		{
			return null;
		}

		protected static bool IsCorrectType(byte nameType, object name)
		{
			return false;
		}
	}
}
