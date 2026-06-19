using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct ImmuneToDamageCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public ImmuneToDamageState Value;

	[GhostField]
	public EffectID effectIDOverride;
}
