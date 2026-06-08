using System;
using MLAPI.Logging;
using UnityEngine;

namespace MLAPI.Configuration
{
	[Serializable]
	public class NetworkedPrefab
	{
		public GameObject Prefab;

		public bool PlayerPrefab;

		internal ulong Hash
		{
			get
			{
				if (Prefab == null)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("NetworkedPrefab is not assigned");
					}
					return 0uL;
				}
				if (Prefab.GetComponent<NetworkedObject>() == null)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning("The NetworkedPrefab " + Prefab.name + " does not have a NetworkedObject");
					}
					return 0uL;
				}
				return Prefab.GetComponent<NetworkedObject>().PrefabHash;
			}
		}
	}
}
