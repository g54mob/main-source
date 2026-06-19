using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct PaintableObjectCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public PaintableColor color;
}
