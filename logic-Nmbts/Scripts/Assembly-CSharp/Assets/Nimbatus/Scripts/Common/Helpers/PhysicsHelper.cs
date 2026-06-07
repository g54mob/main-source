using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public static class PhysicsHelper
	{
		public static List<GameObject> OverlapSphere(Vector3 pos, float radius)
		{
			List<Collider> list = new List<Collider>();
			list.AddRange(Physics.OverlapSphere(pos, radius));
			HashSet<GameObject> hashSet = new HashSet<GameObject>();
			foreach (Collider item in list)
			{
				if (item != null && item.gameObject != null && !hashSet.Contains(item.gameObject))
				{
					hashSet.Add(item.gameObject);
				}
			}
			return hashSet.ToList();
		}

		public static bool IsLayer(LayerMask mask, int layer)
		{
			return (mask.value & (1 << layer)) != 0;
		}
	}
}
