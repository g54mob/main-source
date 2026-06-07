using BestHTTP.Logger;
using BestHTTP.SocketIO3.Transports;

namespace BestHTTP.SocketIO3
{
	public interface IManager
	{
		LoggingContext Context { get; }

		void Remove(Socket socket);

		void Close(bool removeSockets = true);

		void TryToReconnect();

		bool OnTransportConnected(ITransport transport);

		void OnTransportError(ITransport trans, string err);

		void OnTransportProbed(ITransport trans);

		void SendPacket(OutgoingPacket packet);

		void OnPacket(IncomingPacket packet);

		void EmitEvent(string eventName, params object[] args);

		void EmitEvent(SocketIOEventTypes type, params object[] args);

		void EmitError(string msg);

		void EmitAll(string eventName, params object[] args);
	}
}
