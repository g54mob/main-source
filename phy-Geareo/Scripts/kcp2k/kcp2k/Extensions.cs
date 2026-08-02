using System;
using System.Net;
using System.Net.Sockets;

namespace kcp2k
{
	public static class Extensions
	{
		public static string ToHexString(this ArraySegment<byte> segment)
		{
			return null;
		}

		public static bool SendToNonBlocking(this Socket socket, ArraySegment<byte> data, EndPoint remoteEP)
		{
			return false;
		}

		public static bool SendNonBlocking(this Socket socket, ArraySegment<byte> data)
		{
			return false;
		}

		public static bool ReceiveFromNonBlocking(this Socket socket, byte[] recvBuffer, out ArraySegment<byte> data, ref EndPoint remoteEP)
		{
			data = default(ArraySegment<byte>);
			return false;
		}

		public static bool ReceiveNonBlocking(this Socket socket, byte[] recvBuffer, out ArraySegment<byte> data)
		{
			data = default(ArraySegment<byte>);
			return false;
		}
	}
}
