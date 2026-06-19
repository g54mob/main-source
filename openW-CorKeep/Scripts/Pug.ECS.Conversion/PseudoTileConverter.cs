using Pug.Conversion;

public class PseudoTileConverter : SingleAuthoringComponentConverter<PseudoTileAuthoring>
{
	protected override void Convert(PseudoTileAuthoring authoring)
	{
		AddComponentData(new PseudoTileCD
		{
			tileset = (int)authoring.tileset,
			tileType = authoring.tileType
		});
	}
}
