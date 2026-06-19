using Pug.Conversion;

public class TrophyConverter : SingleAuthoringComponentConverter<TrophyAuthoring>
{
	protected override void Convert(TrophyAuthoring authoring)
	{
		AddComponentData(new TrophyCD
		{
			enemyToSpawnFromSpawnerPlatform = authoring.enemyToSpawnFromSpawnerPlatform
		});
	}
}
