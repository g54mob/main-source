using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct ControlledByOtherEntityCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Entity controlledByEntity;
}
