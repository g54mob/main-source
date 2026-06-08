using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace kcp2k
{
	public static class Common
	{
		private static readonly RNGCryptoServiceProvider cryptoRandom;

		private static readonly byte[] cryptoRandomBuffer;

		public static bool ResolveHostname(string hostname, out IPAddress[] addresses)
		{
			addresses = null;
			return false;
		}

		public static void ConfigureSocketBuffers(Socket socket, int recvBufferSize, int sendBufferSize)
		{
		}

		public static int ConnectionHash(EndPoint endPoint)
		{
			return 0;
		}

		public static uint GenerateCookie()
		{
			return 0u;
		}
	}
}
