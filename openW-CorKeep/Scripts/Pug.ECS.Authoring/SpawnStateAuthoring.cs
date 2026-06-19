using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;

public class SpawnStateAuthoring : MonoBehaviour
{
	public float duration;

	public string animId;

	public float2 facingDirection;

	public bool removeTilesOnSpawn;

	[AllowNesting]
	[ShowIf("removeTilesOnSpawn")]
	public float radiusToRemoveTilesWithin;

	[AllowNesting]
	[ShowIf("removeTilesOnSpawn")]
	public float2 removeTilesOnSpawnOffset;
}
