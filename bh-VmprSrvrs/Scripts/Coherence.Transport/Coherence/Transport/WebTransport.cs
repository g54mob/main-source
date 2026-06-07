using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Common.Pooling;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Stats;
using Coherence.Transport.Web;

namespace Coherence.Transport
{
	internal class WebTransport : ITransport
	{
		private readonly Action<int, string, int, string, string, string, string, string> WebConnect;

		private readonly Action<int> WebDisconnect;

		private readonly Action<int, byte[], int> WebSend;

		private readonly Queue<byte[]> receiveQueue;

		private readonly int interopId;

		private readonly IStats stats;

		private readonly Logger logger;

		private readonly Pool<PooledInOctetStream> streamPool;

		public TransportState State { get; private set; }

		public bool IsReliable => false;

		public bool CanSend => false;

		public int HeaderSize => 0;

		public string Description => null;

		public event Action OnOpen
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

		public event Action<ConnectionException> OnError
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

		public WebTransport(Func<Action, Action<byte[]>, Action<JsError>, int> initializeConnection, Action<int, string, int, string, string, string, string, string> connect, Action<int> disconnect, Action<int, byte[], int> send, IStats stats, Logger logger)
		{
		}

		public void Open(EndpointData data, ConnectionSettings _)
		{
		}

		public void Close()
		{
		}

		public void Send(IOutOctetStream stream)
		{
		}

		public void Receive(List<(IInOctetStream, IPEndPoint)> buffer)
		{
		}

		private void OnChannelOpen()
		{
		}

		private void OnPacket(byte[] data)
		{
		}

		private void OnJSError(JsError error)
		{
		}

		public void PrepareDisconnect()
		{
		}
	}
}
