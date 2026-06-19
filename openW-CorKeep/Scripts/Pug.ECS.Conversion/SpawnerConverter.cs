using Pug.Conversion;

public class SpawnerConverter : SingleAuthoringComponentConverter<SpawnerAuthoring>
{
	protected override void Convert(SpawnerAuthoring authoring)
	{
		AddComponentData(new SpawnerCD
		{
			minSpawnDistance = authoring.minSpawnDistance,
			maxSpawnDistance = authoring.maxSpawnDistance,
			maxNumberSpawned = authoring.maxNumberSpawned,
			forgetWhenThisFarAway = authoring.forgetWhenThisFarAway,
			lastPosition = authoring.lastPosition,
			disableSpawnWhenStationary = authoring.disableSpawnWhenStationary
		});
	}
}
