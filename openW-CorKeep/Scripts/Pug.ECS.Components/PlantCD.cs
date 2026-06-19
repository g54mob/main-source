using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct PlantCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int numberOfPlantsToDrop;

	public ObjectID objectToDropWhenHarvested;
}
