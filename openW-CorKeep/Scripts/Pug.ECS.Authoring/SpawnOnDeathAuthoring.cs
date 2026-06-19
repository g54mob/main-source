using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
public class SpawnOnDeathAuthoring : MonoBehaviour
{
	public ObjectID objectToSpawn;

	public int objectVariation;

	public float spawnChance = 1f;

	public float3 offset;

	[MinMax(1f, 10f)]
	public Pug.UnityExtensions.RangeInt amount;

	[Tooltip("If 0 then any amount is allowed")]
	public int maxAmountAllowedWithinRadius;

	public float maxAmountCheckRadius;

	public bool dontSpawnIfKilledByDestroyTimer;
}
