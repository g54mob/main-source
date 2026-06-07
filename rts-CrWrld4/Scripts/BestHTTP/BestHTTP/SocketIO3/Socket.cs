using System;
using BestHTTP.Logger;
using BestHTTP.SocketIO3.Events;

namespace BestHTTP.SocketIO3
{
	public sealed class Socket : ISocket
	{
		internal TypedEventTable TypedEventTable;

		private IncomingPacket currentPacket;

		public SocketManager Manager { get; private set; }

		public string Namespace { get; private set; }

		public string Id { get; private set; }

		public bool IsOpen { get; private set; }

		public LoggingContext Context { get; private set; }

		internal Socket(string nsp, SocketManager manager)
		{
		}

		private void OnConnected(ConnectResponse resp)
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

		public EmitBuilder Volatile()
		{
			return default(EmitBuilder);
		}

		public EmitBuilder ExpectAcknowledgement(Action callback)
		{
			return default(EmitBuilder);
		}

		public EmitBuilder ExpectAcknowledgement<T>(Action<T> callback)
		{
			return default(EmitBuilder);
		}

		public Socket Emit(string eventName, params object[] args)
		{
			return null;
		}

		public Socket EmitAck(params object[] args)
		{
			return null;
		}

		public void On(SocketIOEventTypes eventType, Action callback)
		{
		}

		public void On<T>(SocketIOEventTypes eventType, Action<T> callback)
		{
		}

		public void On(string eventName, Action callback)
		{
		}

		public void On<T>(string eventName, Action<T> callback)
		{
		}

		public void On<T1, T2>(string eventName, Action<T1, T2> callback)
		{
		}

		public void On<T1, T2, T3>(string eventName, Action<T1, T2, T3> callback)
		{
		}

		public void On<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> callback)
		{
		}

		public void On<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> callback)
		{
		}

		public void Once(string eventName, Action callback)
		{
		}

		public void Once<T>(string eventName, Action<T> callback)
		{
		}

		public void Once<T1, T2>(string eventName, Action<T1, T2> callback)
		{
		}

		public void Once<T1, T2, T3>(string eventName, Action<T1, T2, T3> callback)
		{
		}

		public void Once<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> callback)
		{
		}

		public void Once<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> callback)
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

		void ISocket.OnPacket(IncomingPacket packet)
		{
		}

		public Subscription GetSubscription(string name)
		{
			return null;
		}

		void ISocket.EmitEvent(SocketIOEventTypes type, params object[] args)
		{
		}

		void ISocket.EmitEvent(string eventName, params object[] args)
		{
		}

		void ISocket.EmitError(string msg)
		{
		}

		internal void OnTransportOpen()
		{
		}
	}
}
