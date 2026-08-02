using System;
using UnityEngine;

[Serializable]
public struct ZombieSpawnTimeRange
{
	[Tooltip("Bu aralığın başladığı gerçek oyun süresi (dakika)")]
	public float minPlayedMinutes;

	[Tooltip("Bu aralığın bittiği gerçek oyun süresi (dakika). 0 = sonsuz")]
	public float maxPlayedMinutes;

	public int maxZombiesPerPlayer;

	[Tooltip("Bu aralıkta spawn olacak zombi tipi. Boş bırakılırsa default spawnData kullanılır.")]
	public ZombieSpawnData overrideSpawnData;
}
