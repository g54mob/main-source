using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror
{
	[Obsolete]
	[DisallowMultipleComponent]
	public abstract class NetworkVisibility : NetworkBehaviour
	{
		public abstract bool OnCheckObserver(NetworkConnection conn);

		public abstract void OnRebuildObservers(HashSet<NetworkConnection> observers, bool initialize);

		public virtual void OnSetHostVisibility(bool visible)
		{
		}
	}
}
