using Pug.Conversion;

public class WaterSpreaderConverter : SingleAuthoringComponentConverter<WaterSpreaderAuthoring>
{
	protected override void Convert(WaterSpreaderAuthoring authoring)
	{
		AddComponentData(new WaterSpreaderCD
		{
			timer = authoring.timer,
			position = authoring.position
		});
	}
}
