using Pug.Conversion;

public class SpawnTileOnExplosionConversion : SingleAuthoringComponentConverter<SpawnTileOnExplosionAuthoring>
{
	protected override void Convert(SpawnTileOnExplosionAuthoring authoring)
	{
		uint simulationTickRate = (uint)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
		AddComponentData(new SpawnTileOnExplosionCD
		{
			spawnTimer = new TickTimer(authoring.duration, simulationTickRate),
			tileType = authoring.tileType,
			tileset = authoring.tileset,
			spawnRequiresWalkable = authoring.spawnRequiresWalkable
		});
		EnsureHasComponent<IsSpawningTilesFromExplosionCD>(componentIsEnabled: false);
	}
}
