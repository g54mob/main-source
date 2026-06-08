using System;
using System.Runtime.CompilerServices;
using Rhizomatic.Reactive;

namespace GRP.Net
{
	public abstract class NetSessionClient
	{
		public State<NetSessionState> state;

		public StateSelector<bool> canStart;

		public StateSelector<bool> canJoin;

		public NetGame netGame;

		public int tag;

		public bool joined => false;

		public bool host => false;

		public bool client => false;
	}
	public class NetSessionClient<TStart, TJoin, TLeave> : NetSessionClient where TStart : struct, NetMessage where TJoin : struct, NetMessage where TLeave : struct, NetMessage
	{
		public event Action<TJoin> onJoin
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

		public event Action<TLeave> onLeave
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

		public NetSessionClient(NetGame netGame, int tag)
		{
		}

		public void StartSession(TStart msg)
		{
		}

		public void JoinSession()
		{
		}

		public void JoinSession(TJoin msg)
		{
		}

		public void LeaveSession()
		{
		}

		public void LeaveSession(TLeave msg)
		{
		}

		public void Build()
		{
		}
	}
}
