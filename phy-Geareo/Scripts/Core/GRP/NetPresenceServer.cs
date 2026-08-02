using System.Collections.Generic;
using GRP.Net;
using Rhizomatic.Reactive;

namespace GRP
{
	public class NetPresenceServer : NetModuleServer
	{
		public StateList<NetPresenceHandle> handles;

		public Dictionary<NetPlayer, short[]> playerListeners;

		public Dictionary<short, List<NetPlayer>> listeners;

		private IdGenerator idGenerator;

		public override void Setup()
		{
		}

		public NetPresenceHandle GetHandle(Id id)
		{
			return null;
		}

		public NetPresenceHandle GetHandle(Id playerId, short channel, string key)
		{
			return null;
		}

		public override void Build()
		{
		}
	}
}
