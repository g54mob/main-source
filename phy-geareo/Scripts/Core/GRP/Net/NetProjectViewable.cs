using System;
using System.Collections.Generic;
using Rhizomatic.Reactive;

namespace GRP.Net
{
	public class NetProjectViewable : Viewable
	{
		public StateSelector<List<NetProjectPlayerViewable>> players;

		public StateSelector<Dictionary<ulong, ulong[]>> allSelections;

		public Project project;

		public NetGame netGame;

		public StateSelector<List<NetPlayer>> netPlayers;

		public NetProjectViewable(Project project, Func<NetPlayer, bool> filter)
		{
		}

		public void Dispose()
		{
		}

		private void OnHandleUpdate(NetPresenceHandle handle)
		{
		}
	}
}
