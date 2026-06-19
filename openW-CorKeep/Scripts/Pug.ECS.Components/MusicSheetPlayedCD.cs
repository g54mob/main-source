using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct MusicSheetPlayedCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public ObjectID currentSheetPlayed;
}
