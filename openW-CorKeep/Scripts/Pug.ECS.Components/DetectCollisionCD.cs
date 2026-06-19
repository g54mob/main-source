using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.Server)]
public struct DetectCollisionCD : IComponentData, IQueryTypeParameter
{
	public Entity hitEntity;

	public float3 Normal;

	public bool isTriggerEvent;
}
