using Pug.Conversion;

public class EnemySpawnerPlatformAuthoringConverter : SingleAuthoringComponentConverter<EnemySpawnerPlatformAuthoring>
{
	protected override void Convert(EnemySpawnerPlatformAuthoring authoring)
	{
		AddComponentData(new EnemySpawnerPlatformCD
		{
			enemyToSpawn = authoring.enemyToSpawn
		});
		EnsureHasComponent<DistanceToPlayerCD>();
	}
}
