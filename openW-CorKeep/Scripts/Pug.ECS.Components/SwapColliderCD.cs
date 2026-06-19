using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct SwapColliderCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool swap;
}
