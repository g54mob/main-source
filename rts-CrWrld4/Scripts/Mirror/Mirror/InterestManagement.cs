using System.Collections.Generic;
using UnityEngine;

namespace Mirror
{
	[DisallowMultipleComponent]
	public abstract class InterestManagement : MonoBehaviour
	{
		private void Awake()
		{
		}

		public abstract bool OnCheckObserver(NetworkIdentity identity, NetworkConnection newObserver);

		public abstract void OnRebuildObservers(NetworkIdentity identity, HashSet<NetworkConnection> newObservers, bool initialize);

		protected void RebuildAll()
		{
		}
	}
}
