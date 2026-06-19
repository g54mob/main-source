using Pug.Conversion;

public class CoreBossSpawnConverter : SingleAuthoringComponentConverter<CoreBossSpawnAuthoring>
{
	protected override void Convert(CoreBossSpawnAuthoring authoring)
	{
		AddComponentData(new CoreBossSpawnCD
		{
			distanceSqToPlayerToActivate = authoring.distanceToPlayerToActivate * authoring.distanceToPlayerToActivate,
			distanceSqToPlayerToSpawn = authoring.distanceToPlayerToSpawn * authoring.distanceToPlayerToSpawn,
			spawnTime = authoring.spawnTime,
			destructionTime = authoring.destructionTime,
			spawnZOffset = authoring.spawnZOffset
		});
		EnsureHasComponent<DistanceToPlayerCD>();
		EnsureHasComponent<DisablePhysicsCD>(componentIsEnabled: false);
	}
}
