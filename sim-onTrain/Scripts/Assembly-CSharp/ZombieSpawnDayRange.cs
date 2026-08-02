using System;
using UnityEngine;

[Serializable]
public struct ZombieSpawnDayRange
{
	public int startDay;

	public int endDay;

	public int maxZombiesPerPlayer;

	[Tooltip("Bu aralıkta spawn olacak zombi tipi. Boş bırakılırsa default spawnData kullanılır.")]
	public ZombieSpawnData overrideSpawnData;
}
