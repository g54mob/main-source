using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct ShieldCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool active;

	public int shieldWidthDegrees;
}
