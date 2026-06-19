using System.Collections.Generic;
using UnityEngine;

namespace Water2D
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField]
		private float areaX;

		[SerializeField]
		private float areaY;

		[SerializeField]
		private int num;

		[SerializeField]
		private bool gizmos;

		[SerializeField]
		private bool randomOffset;

		[SerializeField]
		private Vector4 offsetMinMax;

		[SerializeField]
		private List<GameObject> objects;

		private int c;

		public void Spawn()
		{
		}

		public void DestroyC()
		{
		}

		private void SpawnObj(Vector2 pos)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
