using System;

namespace GRP.Net
{
	public class NetTransport
	{
		public Action OnClientConnected;

		public Action<ArraySegment<byte>, NetChannel> OnClientDataReceived;

		public Action<TransportError, string> OnClientError;

		public Action<Exception> OnClientTransportException;

		public Action OnClientDisconnected;

		public Action<int> OnServerConnected;

		public Action<int, ArraySegment<byte>, NetChannel> OnServerDataReceived;

		public Action<int, TransportError, string> OnServerError;

		public Action<int, Exception> OnServerTransportException;

		public Action<int> OnServerDisconnected;

		public virtual bool ClientConnected()
		{
			return false;
		}

		public virtual void ClientConnect(string address, ushort port)
		{
		}

		public virtual void ClientSend(ArraySegment<byte> segment, NetChannel channel)
		{
		}

		public virtual void ClientDisconnect()
		{
		}

		public virtual void ClientEarlyUpdate()
		{
		}

		public virtual void ClientLateUpdate()
		{
		}

		public virtual bool ServerActive()
		{
			return false;
		}

		public virtual void ServerStart(ushort port)
		{
		}

		public virtual void ServerSend(int connectionId, ArraySegment<byte> segment, NetChannel channel)
		{
		}

		public virtual void ServerDisconnect(int connectionId)
		{
		}

		public virtual void ServerStop()
		{
		}

		public virtual void ServerEarlyUpdate()
		{
		}

		public virtual void ServerLateUpdate()
		{
		}

		public virtual int GetMaxPacketSize(NetChannel channel)
		{
			return 0;
		}
	}
}
