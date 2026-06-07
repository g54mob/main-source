using System.Collections.Generic;
using BestHTTP.SocketIO.Events;

namespace BestHTTP.SocketIO
{
	public sealed class Socket : ISocket
	{
		private Dictionary<int, SocketIOAckCallback> AckCallbacks;

		private EventTable EventCallbacks;

		private List<object> arguments;

		public SocketManager Manager { get; private set; }

		public string Namespace { get; private set; }

		public string Id { get; private set; }

		public bool IsOpen { get; private set; }

		public bool AutoDecodePayload { get; set; }

		internal Socket(string nsp, SocketManager manager)
		{
		}

		void ISocket.Open()
		{
		}

		public void Disconnect()
		{
		}

		void ISocket.Disconnect(bool remove)
		{
		}

		public Socket Emit(string eventName, params object[] args)
		{
			return null;
		}

		public Socket Emit(string eventName, SocketIOAckCallback callback, params object[] args)
		{
			return null;
		}

		public Socket EmitAck(Packet originalPacket, params object[] args)
		{
			return null;
		}

		public void On(string eventName, SocketIOCallback callback)
		{
		}

		public void On(SocketIOEventTypes type, SocketIOCallback callback)
		{
		}

		public void On(string eventName, SocketIOCallback callback, bool autoDecodePayload)
		{
		}

		public void On(SocketIOEventTypes type, SocketIOCallback callback, bool autoDecodePayload)
		{
		}

		public void Once(string eventName, SocketIOCallback callback)
		{
		}

		public void Once(SocketIOEventTypes type, SocketIOCallback callback)
		{
		}

		public void Once(string eventName, SocketIOCallback callback, bool autoDecodePayload)
		{
		}

		public void Once(SocketIOEventTypes type, SocketIOCallback callback, bool autoDecodePayload)
		{
		}

		public void Off()
		{
		}

		public void Off(string eventName)
		{
		}

		public void Off(SocketIOEventTypes type)
		{
		}

		public void Off(string eventName, SocketIOCallback callback)
		{
		}

		public void Off(SocketIOEventTypes type, SocketIOCallback callback)
		{
		}

		void ISocket.OnPacket(Packet packet)
		{
		}

		void ISocket.EmitEvent(SocketIOEventTypes type, params object[] args)
		{
		}

		void ISocket.EmitEvent(string eventName, params object[] args)
		{
		}

		void ISocket.EmitError(SocketIOErrors errCode, string msg)
		{
		}

		internal void OnTransportOpen()
		{
		}
	}
}
