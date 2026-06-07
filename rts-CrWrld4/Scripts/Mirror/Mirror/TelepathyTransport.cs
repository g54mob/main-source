using System;
using Telepathy;
using UnityEngine;

namespace Mirror
{
	[DisallowMultipleComponent]
	public class TelepathyTransport : Transport
	{
		public const string Scheme = "tcp4";

		public ushort port;

		public bool NoDelay;

		public int SendTimeout;

		public int ReceiveTimeout;

		public int serverMaxMessageSize;

		public int serverMaxReceivesPerTick;

		public int serverSendQueueLimitPerConnection;

		public int serverReceiveQueueLimitPerConnection;

		public int clientMaxMessageSize;

		public int clientMaxReceivesPerTick;

		public int clientSendQueueLimit;

		public int clientReceiveQueueLimit;

		private Client client;

		private Server server;

		private Func<bool> enabledCheck;

		private void Awake()
		{
		}

		public override bool Available()
		{
			return false;
		}

		public override bool ClientConnected()
		{
			return false;
		}

		public override void ClientConnect(string address)
		{
		}

		public override void ClientConnect(Uri uri)
		{
		}

		public override void ClientSend(int channelId, ArraySegment<byte> segment)
		{
		}

		public override void ClientDisconnect()
		{
		}

		public override void ClientEarlyUpdate()
		{
		}

		public override Uri ServerUri()
		{
			return null;
		}

		public override bool ServerActive()
		{
			return false;
		}

		public override void ServerStart()
		{
		}

		public override void ServerSend(int connectionId, int channelId, ArraySegment<byte> segment)
		{
		}

		public override bool ServerDisconnect(int connectionId)
		{
			return false;
		}

		public override string ServerGetClientAddress(int connectionId)
		{
			return null;
		}

		public override void ServerStop()
		{
		}

		public override void ServerEarlyUpdate()
		{
		}

		public override void Shutdown()
		{
		}

		public override int GetMaxPacketSize(int channelId)
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
