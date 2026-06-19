using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct SummonAreaCD : IComponentData, IQueryTypeParameter
{
	public ObjectID bossToSummon;

	public ObjectID optionalBossToSummon;

	public float anticipationTime;

	public float spawnTime;

	public int distanceToDestroyTilesOnSpawn;

	[HideInInspector]
	public int internalState;

	[HideInInspector]
	public ThreadSafeTimerSimple internalTimer;

	[HideInInspector]
	public ObjectID currentBossToSummon;

	public float3 spawnOffset;

	public bool dontOffsetSpawnItemLocation;

	public float overrideDistanceSqToCheckSummoningItem;

	public float overrideDistanceSqToCheckForExistingBoss;
}
