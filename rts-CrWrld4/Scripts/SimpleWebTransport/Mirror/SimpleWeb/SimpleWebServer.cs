using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Mirror.SimpleWeb
{
	public class SimpleWebServer
	{
		private readonly int maxMessagesPerTick;

		private readonly WebSocketServer server;

		private readonly BufferPool bufferPool;

		public bool Active { get; private set; }

		public event Action<int> onConnect
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<int> onDisconnect
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<int, ArraySegment<byte>> onData
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<int, Exception> onError
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public SimpleWebServer(int maxMessagesPerTick, TcpConfig tcpConfig, int maxMessageSize, int handshakeMaxSize, SslConfig sslConfig)
		{
		}

		public void Start(ushort port)
		{
		}

		public void Stop()
		{
		}

		public void SendAll(List<int> connectionIds, ArraySegment<byte> source)
		{
		}

		public void SendOne(int connectionId, ArraySegment<byte> source)
		{
		}

		public bool KickClient(int connectionId)
		{
			return false;
		}

		public string GetClientAddress(int connectionId)
		{
			return null;
		}

		public void ProcessMessageQueue(MonoBehaviour behaviour)
		{
		}
	}
}
