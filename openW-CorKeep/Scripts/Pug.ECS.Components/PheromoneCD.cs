using Unity.Entities;
using Unity.Mathematics;

public struct PheromoneCD : IComponentData, IQueryTypeParameter
{
	public int2 position;

	public Pheromone pheromone;
}
