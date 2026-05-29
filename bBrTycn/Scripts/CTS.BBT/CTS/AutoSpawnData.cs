using System;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public struct AutoSpawnData
	{
		[Min(0f)]
		public float FirstSpawnDelay;

		[Min(1f)]
		public float SpawnCooldown;

		[Min(0f)]
		public int AmountPerSpawn;
	}
}
