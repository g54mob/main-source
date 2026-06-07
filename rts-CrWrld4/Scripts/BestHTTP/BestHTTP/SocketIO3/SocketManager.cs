using System;
using System.Collections.Generic;
using BestHTTP.Extensions;
using BestHTTP.Logger;
using BestHTTP.SocketIO3.Parsers;
using BestHTTP.SocketIO3.Transports;

namespace BestHTTP.SocketIO3
{
	public sealed class SocketManager : IHeartbeat, IManager
	{
		public enum States
		{
			Initial = 0,
			Opening = 1,
			Open = 2,
			Paused = 3,
			Reconnecting = 4,
			Closed = 5
		}

		private States state;

		private int nextAckId;

		private Dictionary<string, Socket> Namespaces;

		private List<Socket> Sockets;

		private List<OutgoingPacket> OfflinePackets;

		private DateTime LastHeartbeat;

		private DateTime ReconnectAt;

		private DateTime ConnectionStarted;

		private bool closing;

		private DateTime lastPingReceived;

		public int ProtocolVersion => 0;

		public States State
		{
			get
			{
				return default(States);
			}
			private set
			{
			}
		}

		public SocketOptions Options { get; private set; }

		public Uri Uri { get; private set; }

		public HandshakeData Handshake { get; private set; }

		public ITransport Transport { get; private set; }

		public ulong RequestCounter { get; internal set; }

		public Socket Socket => null;

		public Socket Item => null;

		public int ReconnectAttempts { get; private set; }

		public IParser Parser { get; set; }

		public LoggingContext Context { get; private set; }

		internal ulong Timestamp => 0uL;

		internal int NextAckId => 0;

		internal States PreviousState { get; private set; }

		internal ITransport UpgradingTransport { get; set; }

		public SocketManager(Uri uri)
		{
		}

		public SocketManager(Uri uri, IParser parser)
		{
		}

		public SocketManager(Uri uri, SocketOptions options)
		{
		}

		public SocketManager(Uri uri, IParser parser, SocketOptions options)
		{
		}

		public Socket GetSocket()
		{
			return null;
		}

		public Socket GetSocket(string nsp)
		{
			return null;
		}

		void IManager.Remove(Socket socket)
		{
		}

		public void Open()
		{
		}

		public void Close()
		{
		}

		void IManager.Close(bool removeSockets)
		{
		}

		void IManager.TryToReconnect()
		{
		}

		bool IManager.OnTransportConnected(ITransport trans)
		{
			return false;
		}

		void IManager.OnTransportError(ITransport trans, string err)
		{
		}

		void IManager.OnTransportProbed(ITransport trans)
		{
		}

		private ITransport SelectTransport()
		{
			return null;
		}

		private void SendOfflinePackets()
		{
		}

		void IManager.SendPacket(OutgoingPacket packet)
		{
		}

		void IManager.OnPacket(IncomingPacket packet)
		{
		}

		public void EmitAll(string eventName, params object[] args)
		{
		}

		void IManager.EmitEvent(string eventName, params object[] args)
		{
		}

		void IManager.EmitEvent(SocketIOEventTypes type, params object[] args)
		{
		}

		void IManager.EmitError(string msg)
		{
		}

		void IManager.EmitAll(string eventName, params object[] args)
		{
		}

		void IHeartbeat.OnHeartbeatUpdate(TimeSpan dif)
		{
		}
	}
}
