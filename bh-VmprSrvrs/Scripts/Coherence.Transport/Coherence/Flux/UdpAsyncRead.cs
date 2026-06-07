using System;
using System.Net;
using System.Net.Sockets;

namespace Coherence.Flux
{
	public class UdpAsyncRead
	{
		private readonly System.Net.Sockets.UdpClient Udp;

		private readonly PortReceivedDataCallback UserCallback;

		private readonly object UserData;

		private readonly AsyncCallback ReceiveCallback;

		private byte[] ReceivedBytes;

		private IPEndPoint ReceivedFrom;

		public UdpAsyncRead(System.Net.Sockets.UdpClient udp, PortReceivedDataCallback userCallback, object userData, AsyncCallback receiveCallback)
		{
		}

		public void Begin()
		{
		}

		public void End(IAsyncResult ar)
		{
		}

		public void Report()
		{
		}

		private void ResetToBeginRead()
		{
		}
	}
}
