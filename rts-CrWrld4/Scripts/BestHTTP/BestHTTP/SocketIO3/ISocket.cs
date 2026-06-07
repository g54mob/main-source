using BestHTTP.Logger;

namespace BestHTTP.SocketIO3
{
	public interface ISocket
	{
		LoggingContext Context { get; }

		void Open();

		void Disconnect(bool remove);

		void OnPacket(IncomingPacket packet);

		void EmitEvent(SocketIOEventTypes type, params object[] args);

		void EmitEvent(string eventName, params object[] args);

		void EmitError(string msg);
	}
}
