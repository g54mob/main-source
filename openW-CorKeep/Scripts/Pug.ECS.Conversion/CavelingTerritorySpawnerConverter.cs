using Pug.Conversion;

public class CavelingTerritorySpawnerConverter : SingleAuthoringComponentConverter<CavelingTerritorySpawnerAuthoring>
{
	protected override void Convert(CavelingTerritorySpawnerAuthoring authoring)
	{
		AddComponentData(new CavelingTerritorySpawnerCD
		{
			size = authoring.size,
			cavelingSpawnChance = authoring.cavelingSpawnChance,
			cavelingShamanSpawnChance = authoring.cavelingShamanSpawnChance,
			cavelingBruteSpawnChance = authoring.cavelingBruteSpawnChance
		});
	}
}
