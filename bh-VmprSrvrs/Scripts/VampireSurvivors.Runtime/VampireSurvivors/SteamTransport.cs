using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Stats;
using Coherence.Transport;
using Steamworks.Data;

namespace VampireSurvivors
{
	public class SteamTransport : ITransport
	{
		internal const int HeaderSizeBytes = 4;

		private readonly IStats _stats;

		private readonly Logger _logger;

		private readonly SteamConnectionManager _steamConnectionManager;

		private readonly Queue<byte[]> _incomingPackets;

		private bool _isClosing;

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

		public SteamTransport(IStats stats, Logger logger, SteamConnectionManager steamConnectionManager)
		{
		}

		public void Open(EndpointData _, ConnectionSettings __)
		{
		}

		public void PrepareDisconnect()
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

		private void OnHostDisconnected(ConnectionInfo info)
		{
		}

		private void OnMessage(IntPtr data, int size)
		{
		}
	}
}
