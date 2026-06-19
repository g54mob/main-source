using Unity.Entities;

public struct ScarabBossCD : IComponentData, IQueryTypeParameter
{
	public bool hasPreparedNextMortarShots;

	public int patternCounter;
}
