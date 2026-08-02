using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class OldGearVisual : MonoBehaviour
	{
		public int toothCount;

		public float toothSize;

		public float toothOffset;

		public GameObject toothPrefab;

		public List<GameObject> teeth;

		public List<GameObject> pool;

		public float radius => 0f;

		public float spawnRadius => 0f;

		public float innerRadius => 0f;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void Build()
		{
		}

		private void OnDrawGizmos()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
