using UnityEngine;

namespace GameKit.Utilities.ObjectPooling.Examples
{
	public class ProjectileSpawner : MonoBehaviour
	{
		public GameObject Prefab;

		public bool UsePool;

		public float _instantiateDelay;

		private float _nextInstantiate;

		private void Update()
		{
		}
	}
}
