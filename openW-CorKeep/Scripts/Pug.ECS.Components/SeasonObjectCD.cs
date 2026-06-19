using Unity.Entities;

public struct SeasonObjectCD : IComponentData, IQueryTypeParameter
{
	public Season belongsToSeason;

	public bool removeFromWorldWhenOutOfSeason;
}
