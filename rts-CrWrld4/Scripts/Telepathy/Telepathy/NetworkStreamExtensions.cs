using System.Net.Sockets;

namespace Telepathy
{
	public static class NetworkStreamExtensions
	{
		public static int ReadSafely(this NetworkStream stream, byte[] buffer, int offset, int size)
		{
			return 0;
		}

		public static bool ReadExactly(this NetworkStream stream, byte[] buffer, int amount)
		{
			return false;
		}
	}
}
