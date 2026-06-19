using Pug.Conversion;

public class SeasonObjectConverter : SingleAuthoringComponentConverter<SeasonObjectAuthoring>
{
	protected override void Convert(SeasonObjectAuthoring authoring)
	{
		AddComponentData(new SeasonObjectCD
		{
			belongsToSeason = authoring.belongsToSeason,
			removeFromWorldWhenOutOfSeason = authoring.removeFromWorldWhenOutOfSeason
		});
	}
}
