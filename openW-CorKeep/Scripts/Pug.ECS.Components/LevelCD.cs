using Unity.Entities;

public struct LevelCD : IComponentData, IQueryTypeParameter
{
	public int level;

	public AreaLevel areaLevel;
}
