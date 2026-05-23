using System.Security.Cryptography;

namespace Lidgren.Network
{
	public class NetAESEncryption : NetCryptoProviderBase
	{
		public NetAESEncryption(NetPeer peer)
			: base(peer, new RijndaelManaged())
		{
		}

		public NetAESEncryption(NetPeer peer, string key)
			: base(peer, new RijndaelManaged())
		{
			SetKey(key);
		}

		public NetAESEncryption(NetPeer peer, byte[] data, int offset, int count)
			: base(peer, new RijndaelManaged())
		{
			SetKey(data, offset, count);
		}
	}
}
