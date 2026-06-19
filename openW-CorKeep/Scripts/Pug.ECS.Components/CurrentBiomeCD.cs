using Unity.Entities;

public struct CurrentBiomeCD : IComponentData, IQueryTypeParameter
{
	public Biome biome;
}
