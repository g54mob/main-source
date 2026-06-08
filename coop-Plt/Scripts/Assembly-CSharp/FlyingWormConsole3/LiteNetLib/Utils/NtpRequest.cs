using System.Net;
using System.Net.Sockets;

namespace FlyingWormConsole3.LiteNetLib.Utils
{
	internal sealed class NtpRequest
	{
		private const int ResendTimer = 1000;

		private const int KillTimer = 10000;

		public const int DefaultPort = 123;

		private readonly IPEndPoint _ntpEndPoint;

		private int _resendTime = 1000;

		private int _killTime;

		public bool NeedToKill => _killTime >= 10000;

		public NtpRequest(IPEndPoint endPoint)
		{
			_ntpEndPoint = endPoint;
		}

		public bool Send(NetSocket socket, int time)
		{
			_resendTime += time;
			_killTime += time;
			if (_resendTime < 1000)
			{
				return false;
			}
			SocketError errorCode = SocketError.Success;
			NtpPacket ntpPacket = new NtpPacket();
			int num = socket.SendTo(ntpPacket.Bytes, 0, ntpPacket.Bytes.Length, _ntpEndPoint, ref errorCode);
			if (errorCode == SocketError.Success)
			{
				return num == ntpPacket.Bytes.Length;
			}
			return false;
		}
	}
}
