using System.Net;
using System.Net.Sockets;

namespace LiteNetLib.Utils
{
	internal sealed class NtpRequest
	{
		private const int ResendTimer = 1000;

		private const int KillTimer = 10000;

		public const int DefaultPort = 123;

		private readonly IPEndPoint _ntpEndPoint;

		private int _resendTime;

		private int _killTime;

		public bool NeedToKill => false;

		public NtpRequest(IPEndPoint endPoint)
		{
		}

		public bool Send(Socket socket, int time)
		{
			return false;
		}
	}
}
