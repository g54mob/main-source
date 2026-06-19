using Pug.Conversion;

public class TileConverter : SingleAuthoringComponentConverter<TileAuthoring>
{
	protected override void Convert(TileAuthoring authoring)
	{
		AddComponentData(new TileCD
		{
			tileset = (int)authoring.tileset,
			tileType = authoring.tileType
		});
		EnsureHasComponent<TileDamageTagCD>(componentIsEnabled: false);
	}
}
