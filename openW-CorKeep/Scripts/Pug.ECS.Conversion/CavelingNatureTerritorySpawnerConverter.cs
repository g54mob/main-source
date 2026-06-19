using Pug.Conversion;

public class CavelingNatureTerritorySpawnerConverter : SingleAuthoringComponentConverter<CavelingNatureTerritorySpawnerAuthoring>
{
	protected override void Convert(CavelingNatureTerritorySpawnerAuthoring authoring)
	{
		AddComponentData(new CavelingNatureTerritorySpawnerCD
		{
			size = authoring.size,
			farmerSpawnChance = authoring.farmerSpawnChance,
			hunterSpawnChance = authoring.hunterSpawnChance
		});
	}
}
