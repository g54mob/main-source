using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct MinecartCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public float currentSpeed;

	[GhostField]
	public bool isBreaking;

	public float maxSpeed;
}
