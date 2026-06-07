using System;
using System.Net;

namespace Coherence.Flux
{
	public interface IPort
	{
		void Open(PortReceivedDataCallback userCallback, object userData);

		void Listen(IPEndPoint endPoint, PortReceivedDataCallback userCallback, object userData);

		void Close();

		void Send(IPEndPoint endPoint, ArraySegment<byte> data);
	}
}
