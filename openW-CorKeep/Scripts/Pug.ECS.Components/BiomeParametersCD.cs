using Unity.Entities;

public struct BiomeParametersCD : IComponentData, IQueryTypeParameter
{
	public BiomesTable.BiomeParameters Value;

	public uint ringLayerIndex;
}
