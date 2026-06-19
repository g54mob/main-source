using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct EntityPartCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Entity mainEntity;

	[GhostField]
	public bool showHitFeedbackOnThisPart;

	[GhostField]
	public bool handleImmuneToDamageOnThisPart;
}
