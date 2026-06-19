using Pug.Conversion;
using PugTilemap;

public class RootPlantConverter : SingleAuthoringComponentConverter<RootPlantAuthoring>
{
	protected override void Convert(RootPlantAuthoring authoring)
	{
		RootPlantCD component = new RootPlantCD
		{
			tileset = authoring.tileset,
			minTimeBetweenSpread = authoring.minTimeBetweenSpread,
			maxTimeBetweenSpread = authoring.maxTimeBetweenSpread
		};
		foreach (Tileset canGrowOnTileset in authoring.canGrowOnTilesets)
		{
			Tileset item = canGrowOnTileset;
			component.allowedTilesets.Add(in item);
		}
		AddComponentData(component);
		AddComponentData(new PugFloraDoGrowCD
		{
			initialize = true
		});
	}
}
