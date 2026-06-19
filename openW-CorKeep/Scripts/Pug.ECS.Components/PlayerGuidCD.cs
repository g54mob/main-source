using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct PlayerGuidCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Hash128 Value;

	public bool IsCreated => Value != default(Hash128);
}
