using System;
using System.Net;
using System.Net.Sockets;
using Coherence.Log;

namespace Coherence.Flux
{
	internal class UdpClient : IPort
	{
		private System.Net.Sockets.UdpClient udp;

		private UdpAsyncRead read;

		private Logger logger;

		public UdpClient(Logger logger)
		{
		}

		public void Open(PortReceivedDataCallback userCallback, object userData)
		{
		}

		private void SetupUdpClient()
		{
		}

		public void Listen(IPEndPoint endPoint, PortReceivedDataCallback userCallback, object userData)
		{
		}

		public void Close()
		{
		}

		public void Send(IPEndPoint endPoint, ArraySegment<byte> data)
		{
		}

		private static void HandleReceivedData(IAsyncResult ar)
		{
		}

		private void ReceiveCallback(IAsyncResult ar)
		{
		}
	}
}
