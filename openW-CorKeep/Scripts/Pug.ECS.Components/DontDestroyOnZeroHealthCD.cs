using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct DontDestroyOnZeroHealthCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool disabled;
}
