using System.IO;
using System.Security.Cryptography;

namespace Mirror.SimpleWeb
{
	internal class ServerHandshake
	{
		private const int GetSize = 3;

		private const int ResponseLength = 129;

		private const int KeyLength = 24;

		private const int MergedKeyLength = 60;

		private const string KeyHeaderString = "Sec-WebSocket-Key: ";

		private readonly int maxHttpHeaderSize;

		private readonly SHA1 sha1;

		private readonly BufferPool bufferPool;

		public ServerHandshake(BufferPool bufferPool, int handshakeMaxSize)
		{
		}

		~ServerHandshake()
		{
		}

		public bool TryHandshake(Connection conn)
		{
			return false;
		}

		private string ReadToEndForHandshake(Stream stream)
		{
			return null;
		}

		private static bool IsGet(byte[] getHeader)
		{
			return false;
		}

		private void AcceptHandshake(Stream stream, string msg)
		{
		}

		private static void GetKey(string msg, byte[] keyBuffer)
		{
		}

		private static void AppendGuid(byte[] keyBuffer)
		{
		}

		private byte[] CreateHash(byte[] keyBuffer)
		{
			return null;
		}

		private static void CreateResponse(byte[] keyHash, byte[] responseBuffer)
		{
		}
	}
}
