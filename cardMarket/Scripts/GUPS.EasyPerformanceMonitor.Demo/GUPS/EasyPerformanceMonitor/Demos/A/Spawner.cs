using System;
using System.Collections.Generic;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Demos.A
{
	[Serializable]
	public class Spawner : MonoBehaviour
	{
		[SerializeField]
		public Vector3 MinSpawnPosition = new Vector3(0f, 0f, 0f);

		[SerializeField]
		public Vector3 MaxSpawnPosition = new Vector3(10f, 10f, 10f);

		[SerializeField]
		public float SpawnIntervall = 0.5f;

		[SerializeField]
		public List<GameObject> ObjectsToSpawn;

		private void Start()
		{
			InvokeRepeating("Spawn", 0f, SpawnIntervall);
		}

		private void Spawn()
		{
			Vector3 zero = Vector3.zero;
			zero.x = UnityEngine.Random.Range(MinSpawnPosition.x, MaxSpawnPosition.x);
			zero.y = UnityEngine.Random.Range(MinSpawnPosition.y, MaxSpawnPosition.y);
			zero.z = UnityEngine.Random.Range(MinSpawnPosition.z, MaxSpawnPosition.z);
			Quaternion rotation = Quaternion.Euler(UnityEngine.Random.Range(0f, 180f), UnityEngine.Random.Range(0f, 180f), UnityEngine.Random.Range(0f, 180f));
			int index = UnityEngine.Random.Range(0, ObjectsToSpawn.Count);
			UnityEngine.Object.Instantiate(ObjectsToSpawn[index], zero, rotation);
		}
	}
}
