using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct BeamBuffer : IBufferElementData
{
	[GhostField]
	public float3 targetDirection;

	[GhostField]
	public float currentReachDistance;
}
