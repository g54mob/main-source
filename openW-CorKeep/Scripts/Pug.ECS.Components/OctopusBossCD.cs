using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct OctopusBossCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool isFighting;

	public float canLeaveFightTimer;
}
