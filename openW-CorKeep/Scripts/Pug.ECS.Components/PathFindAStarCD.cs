using Unity.Entities;

public struct PathFindAStarCD : IComponentData, IQueryTypeParameter
{
	public enum PolicyType
	{
		UniformCost = 0,
		AllowButAvoidWalls = 1
	}

	public PolicyType Policy;

	public int MiningDamage;
}
