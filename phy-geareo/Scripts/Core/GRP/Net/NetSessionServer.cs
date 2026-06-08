using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GRP.Net
{
	public abstract class NetSessionServer
	{
		public NetPlayer host;

		public List<NetPlayer> players;

		public NetGame netGame;

		public int tag;

		public bool started => false;

		public void RegisterHandler<T>(Action<NetPlayer, T> handler) where T : struct, NetMessage
		{
		}
	}
	public class NetSessionServer<TStart, TJoin, TLeave> : NetSessionServer where TStart : struct, NetMessage where TJoin : struct, NetMessage where TLeave : struct, NetMessage
	{
		public event Action<NetPlayer, TStart> onStart
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

		public event Action<NetPlayer, TJoin> onJoin
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

		public event Action<NetPlayer, TLeave> onLeave
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

		public event Action<NetPlayer, TLeave> onEnd
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

		public NetSessionServer(NetGame netGame, int tag)
		{
		}

		private void StartSession(NetPlayer player, TStart msg)
		{
		}

		private void JoinSession(NetPlayer player, TJoin msg)
		{
		}

		private void LeaveSession(NetPlayer player, TLeave msg)
		{
		}

		private void SendStates()
		{
		}

		private void SendState(NetPlayer player)
		{
		}

		public void Build()
		{
		}
	}
}
