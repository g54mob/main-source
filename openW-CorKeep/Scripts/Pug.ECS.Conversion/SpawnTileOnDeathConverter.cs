using Pug.Conversion;

public class SpawnTileOnDeathConverter : SingleAuthoringComponentConverter<SpawnTileOnDeathAuthoring>
{
	protected override void Convert(SpawnTileOnDeathAuthoring authoring)
	{
		AddComponentData(new SpawnTileOnDeathCD
		{
			tileType = authoring.tileType,
			tileset = authoring.tileset,
			spawnChance = authoring.spawnChance,
			clearOtherTiles = authoring.clearOtherTiles
		});
	}
}
