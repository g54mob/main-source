using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

namespace FishNet.Utility.Performance
{
	public static class GetNonAlloc
	{
		public static void GetNetworkBehavioursNonAlloc(this Transform t, ref List<NetworkBehaviour> results)
		{
		}

		public static void GetTransformsInChildrenNonAlloc(this Transform t, ref List<Transform> results, bool includeInactive = false)
		{
		}
	}
}
