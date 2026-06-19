using Pug.Conversion;

public class SlimeTerritorySpawnerConverter : SingleAuthoringComponentConverter<SlimeTerritorySpawnerAuthoring>
{
	protected override void Convert(SlimeTerritorySpawnerAuthoring authoring)
	{
		AddComponentData(new SlimeTerritorySpawnerCD
		{
			size = authoring.size,
			slimeBlobSpawnChance = authoring.slimeBlobSpawnChance
		});
	}
}
