using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.Server)]
public struct DestroyEntityIfNotOnTileCD : IComponentData, IQueryTypeParameter
{
	public float timer;
}
