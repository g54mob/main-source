using System;
using System.Collections.Generic;

namespace Mirror
{
	[Obsolete]
	public class NetworkProximityChecker : NetworkVisibility
	{
		public int visRange;

		public float visUpdateInterval;

		[Obsolete]
		public bool forceHidden
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override void OnStartServer()
		{
		}

		public override void OnStopServer()
		{
		}

		private void RebuildObservers()
		{
		}

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
