using System.Net.Sockets;
using System.Threading;

namespace Telepathy
{
	public static class ThreadFunctions
	{
		public static bool SendMessagesBlocking(NetworkStream stream, byte[] payload, int packetSize)
		{
			return false;
		}

		public static bool ReadMessageBlocking(NetworkStream stream, int MaxMessageSize, byte[] headerBuffer, byte[] payloadBuffer, out int size)
		{
			size = default(int);
			return false;
		}

		public static void ReceiveLoop(int connectionId, TcpClient client, int MaxMessageSize, MagnificentReceivePipe receivePipe, int QueueLimit)
		{
		}

		public static void SendLoop(int connectionId, TcpClient client, MagnificentSendPipe sendPipe, ManualResetEvent sendPending)
		{
		}
	}
}
