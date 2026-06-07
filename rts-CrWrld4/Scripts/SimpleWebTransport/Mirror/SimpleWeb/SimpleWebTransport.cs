using System;
using System.Security.Authentication;
using UnityEngine;

namespace Mirror.SimpleWeb
{
	[DisallowMultipleComponent]
	public class SimpleWebTransport : Transport
	{
		public const string NormalScheme = "ws";

		public const string SecureScheme = "wss";

		public ushort port;

		public int maxMessageSize;

		public int handshakeMaxSize;

		public bool noDelay;

		public int sendTimeout;

		public int receiveTimeout;

		public int serverMaxMessagesPerTick;

		public int clientMaxMessagesPerTick;

		public bool batchSend;

		public bool waitBeforeSend;

		public bool clientUseWss;

		public bool sslEnabled;

		public string sslCertJson;

		public SslProtocols sslProtocols;

		[SerializeField]
		private Log.Levels _logLevels;

		private SimpleWebClient client;

		private SimpleWebServer server;

		public Log.Levels LogLevels
		{
			get
			{
				return default(Log.Levels);
			}
			set
			{
			}
		}

		private TcpConfig TcpConfig => default(TcpConfig);

		private void OnValidate()
		{
		}

		public override bool Available()
		{
			return false;
		}

		public override int GetMaxPacketSize(int channelId = 0)
		{
			return 0;
		}

		private void Awake()
		{
		}

		public override void Shutdown()
		{
		}

		private string GetClientScheme()
		{
			return null;
		}

		private string GetServerScheme()
		{
			return null;
		}

		public override bool ClientConnected()
		{
			return false;
		}

		public override void ClientConnect(string hostname)
		{
		}

		public override void ClientDisconnect()
		{
		}

		public override void ClientSend(int channelId, ArraySegment<byte> segment)
		{
		}

		public override void ClientEarlyUpdate()
		{
		}

		public override bool ServerActive()
		{
			return false;
		}

		public override void ServerStart()
		{
		}

		public override void ServerStop()
		{
		}

		public override bool ServerDisconnect(int connectionId)
		{
			return false;
		}

		public override void ServerSend(int connectionId, int channelId, ArraySegment<byte> segment)
		{
		}

		public override string ServerGetClientAddress(int connectionId)
		{
			return null;
		}

		public override Uri ServerUri()
		{
			return null;
		}

		public override void ServerEarlyUpdate()
		{
		}
	}
}
