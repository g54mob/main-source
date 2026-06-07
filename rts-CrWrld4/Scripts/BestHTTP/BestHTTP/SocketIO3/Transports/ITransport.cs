using System.Collections.Generic;

namespace BestHTTP.SocketIO3.Transports
{
	public interface ITransport
	{
		TransportTypes Type { get; }

		TransportStates State { get; }

		SocketManager Manager { get; }

		bool IsRequestInProgress { get; }

		bool IsPollingInProgress { get; }

		void Open();

		void Poll();

		void Send(OutgoingPacket packet);

		void Send(List<OutgoingPacket> packets);

		void Close();
	}
}
