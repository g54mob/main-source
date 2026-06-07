using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror
{
	[Obsolete]
	[DisallowMultipleComponent]
	public class NetworkOwnerChecker : NetworkVisibility
	{
		public override bool OnCheckObserver(NetworkConnection conn)
		{
			return false;
		}

		public override void OnRebuildObservers(HashSet<NetworkConnection> observers, bool initialize)
		{
		}

		private void MirrorProcessed()
		{
		}
	}
}
