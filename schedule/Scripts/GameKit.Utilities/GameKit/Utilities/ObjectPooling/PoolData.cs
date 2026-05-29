using System.Collections.Generic;
using UnityEngine;

namespace GameKit.Utilities.ObjectPooling
{
	public class PoolData
	{
		public readonly GameObject Prefab;

		public ListStack<GameObject> Objects;

		private float _expirationDuration;

		public PoolData(GameObject prefab, float expirationDuration)
		{
		}

		public bool PoolExpired()
		{
			return false;
		}

		public List<GameObject> Cull()
		{
			return null;
		}
	}
}
