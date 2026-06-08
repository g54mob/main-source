using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GRP.Net;
using Rhizomatic.Reactive;

namespace GRP
{
	public class NetPresenceClient : NetModuleClient
	{
		public StateList<NetPresenceHandle> handles;

		public List<short> channels;

		public event Action<NetPresenceHandle> onHandleStart
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

		public event Action<NetPresenceHandle> onHandleUpdate
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

		public event Action<NetPresenceHandle> onHandleEnd
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

		public NetPresenceHandle GetHandle(Id id)
		{
			return null;
		}

		public NetPresenceHandle GetHandle(Id playerId, short channel, string key)
		{
			return null;
		}

		public NetPresenceHandle GetHandle(short channel, string key)
		{
			return null;
		}

		public void EnsureListen(short channel)
		{
		}

		public void Listen(params short[] channels)
		{
		}

		public void StartPresence(short channel, string key)
		{
		}

		public void StartPresence(short channel, string key, byte[] data)
		{
		}

		public void UpdatePresence(short channel, string key, byte[] data, NetChannel netChannel = NetChannel.Unreliable)
		{
		}

		public void UpdatePresence(Id id, byte[] data, NetChannel netChannel = NetChannel.Unreliable)
		{
		}

		public void EndPresence(short channel, string key)
		{
		}

		public void EndPresence(Id id)
		{
		}

		public override void Build()
		{
		}
	}
}
