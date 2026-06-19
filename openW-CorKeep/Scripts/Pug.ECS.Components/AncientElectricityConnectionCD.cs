using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct AncientElectricityConnectionCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int electricityAmount;

	public int sourceEnergy;

	public bool blocksElectricity;
}
