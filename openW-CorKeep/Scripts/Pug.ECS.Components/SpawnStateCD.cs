using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;

public struct SpawnStateCD : IComponentData, IQueryTypeParameter
{
	public float duration;

	public int animId;

	public float2 facingDirection;

	public bool removeTilesOnSpawn;

	public float radiusSqToRemoveTilesWithin;

	public float2 removeTilesOnSpawnOffset;

	public int internalState;

	public ThreadSafeTimerSimple timer;
}
