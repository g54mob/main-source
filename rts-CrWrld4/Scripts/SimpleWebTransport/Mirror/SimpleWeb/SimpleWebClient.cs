using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Mirror.SimpleWeb
{
	public abstract class SimpleWebClient
	{
		private readonly int maxMessagesPerTick;

		protected readonly int maxMessageSize;

		protected readonly ConcurrentQueue<Message> receiveQueue;

		protected readonly BufferPool bufferPool;

		protected ClientState state;

		public ClientState ConnectionState => default(ClientState);

		public event Action onConnect
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

		public event Action onDisconnect
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

		public event Action<ArraySegment<byte>> onData
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

		public event Action<Exception> onError
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

		public static SimpleWebClient Create(int maxMessageSize, int maxMessagesPerTick, TcpConfig tcpConfig)
		{
			return null;
		}

		protected SimpleWebClient(int maxMessageSize, int maxMessagesPerTick)
		{
		}

		public void ProcessMessageQueue(MonoBehaviour behaviour)
		{
		}

		public abstract void Connect(Uri serverAddress);

		public abstract void Disconnect();

		public abstract void Send(ArraySegment<byte> segment);
	}
}
