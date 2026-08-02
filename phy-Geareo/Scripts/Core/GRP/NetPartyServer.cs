using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GRP.Net;
using Rhizomatic.Reactive;

namespace GRP
{
	public class NetPartyServer : NetModuleServer
	{
		public StateList<NetPlayer> players;

		public Dictionary<NetConn, NetPlayer> playerByConn;

		public Dictionary<string, NetPlayer> playerByUsername;

		private List<NetConn> waitingConnections;

		private IdGenerator idGenerator;

		public event Action<NetPlayer> onPlayerJoined
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

		public event Action<NetPlayer> onPlayerLeft
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

		public void SendLog(string message)
		{
		}

		public void SendLogButOne(NetPlayer player, string message)
		{
		}

		public void SendLogToOne(NetPlayer player, string message)
		{
		}

		public void SendPlayers()
		{
		}

		public NetPlayer GetPlayer(Id id)
		{
			return null;
		}

		public override void Build()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
