using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Connection;
using Coherence.Toolkit.Relay;
using Steamworks.Data;

namespace VampireSurvivors
{
	public class SteamRelay : IRelay
	{
		private readonly Dictionary<Connection, SteamRelayConnection> _connectionMap;

		private SteamSocketManager _steamSocketManager;

		public CoherenceRelayManager RelayManager { get; set; }

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

		public SteamRelay(SteamSocketManager socketManager)
		{
		}

		public void Open()
		{
		}

		public void Update()
		{
		}

		public void Close()
		{
		}

		private void CreateRelayConnections()
		{
		}

		public void OnDisconnected(Connection steamConnection, ConnectionInfo info)
		{
		}

		public void OnMessage(Connection steamConnection, IntPtr data, int size)
		{
		}
	}
}
