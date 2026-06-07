using System.Collections;
using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class ServerNameList
	{
		protected readonly IList mServerNameList;

		public virtual IList ServerNames => null;

		public ServerNameList(IList serverNameList)
		{
		}

		public virtual void Encode(Stream output)
		{
		}

		public static ServerNameList Parse(Stream input)
		{
			return null;
		}

		private static byte[] CheckNameType(byte[] nameTypesSeen, byte nameType)
		{
			return null;
		}
	}
}
