using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class SummonAreaAuthoring : MonoBehaviour
{
	public ObjectID bossToSummon;

	public ObjectID optionalBossToSummon;

	public float anticipationTime;

	public float spawnTime;

	public int distanceToDestroyTilesOnSpawn;

	public int internalState;

	public ThreadSafeTimerSimple internalTimer;

	public float3 spawnOffset;

	public bool dontOffsetSpawnItemLocation;

	[Header("If these values are 0 then default distances will be used")]
	public float overrideDistanceToCheckSummoningItem;

	public float overrideDistanceToCheckForExistingBoss;
}
