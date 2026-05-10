using System.Collections.Generic;
using UnityEngine;

namespace Photon.Pun
{
	public class DefaultPool : IPunPrefabPool
	{
		public readonly Dictionary<string, GameObject> ResourceCache;

		public GameObject Instantiate(string prefabId, Vector3 position, Quaternion rotation)
		{
			return null;
		}

		public void Destroy(GameObject gameObject)
		{
		}
	}
}
