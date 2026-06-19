using Pug.Conversion;

public class WaterSourceConverter : SingleAuthoringComponentConverter<WaterSourceAuthoring>
{
	protected override void Convert(WaterSourceAuthoring authoring)
	{
		AddComponentData(new WaterSourceCD
		{
			waterTileset = authoring.watertileset,
			splashPosition = authoring.splashPosition
		});
	}
}
