using System;
using System.Net;
using Coherence.Brook;
using Coherence.Transport;

namespace Coherence.RSL.Transport
{
	public interface ITransportConnection
	{
		Action<IInOctetStream> RecvChannel { set; }

		IPEndPoint Address { get; }

		int HeaderSize { get; }

		ITransport Transport { get; }

		ConnectionID ID();

		bool IsReliable();

		SessionID SessionID();

		bool CanSend();

		void SendPacket(IOutOctetStream data);

		void HandleIncomingPacket(IInOctetStream data);

		void Close(IOutOctetStream optionalData = null);
	}
}
