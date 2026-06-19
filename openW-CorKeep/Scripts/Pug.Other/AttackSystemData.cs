using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct AttackSystemData : IComponentData, IQueryTypeParameter
{
	public NativeParallelHashMap<SpawnedGhost, float3> PlayerHitLookup;

	public NativeParallelHashMap<SpawnedGhost, NetworkTick> LastPlayerHit;
}
