using System.Collections.Generic;

namespace Mirror
{
	public class DistanceInterestManagement : InterestManagement
	{
		public int visRange;

		public float rebuildInterval;

		private double lastRebuildTime;

		public override bool OnCheckObserver(NetworkIdentity identity, NetworkConnection newObserver)
		{
			return false;
		}

		public override void OnRebuildObservers(NetworkIdentity identity, HashSet<NetworkConnection> newObservers, bool initialize)
		{
		}

		private void Update()
		{
		}
	}
}
