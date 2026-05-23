using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class SpawnRect : MonoBehaviour
	{
		[Serializable]
		public class SpawnSetting
		{
			public bool enabled;

			public GameObject spawnItem;

			public bool onLine;

			public Rect spawnRect;

			public float interval;

			public float nextSpawnTime;

			public void NextRap()
			{
			}
		}

		public List<SpawnSetting> spawnSetting;

		private Color[] rectColor;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void UpdateSpawnRect()
		{
		}

		public void Spawn(SpawnSetting spawnSetting)
		{
		}

		public void StopSpawnAt(int idx)
		{
		}

		public void StopAllSpawn()
		{
		}

		public void PlaySpawnAt(int idx)
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
