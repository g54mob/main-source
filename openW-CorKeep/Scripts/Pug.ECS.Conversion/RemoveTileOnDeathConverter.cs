using Pug.Conversion;

public class RemoveTileOnDeathConverter : SingleAuthoringComponentConverter<RemoveTileOnDeathAuthoring>
{
	protected override void Convert(RemoveTileOnDeathAuthoring authoring)
	{
		AddComponentData(new RemoveTileOnDeathCD
		{
			tileType = authoring.tileType,
			tileset = authoring.tileset,
			removeChance = authoring.removeChance
		});
	}
}
