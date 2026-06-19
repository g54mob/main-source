using Pug.Conversion;

public class PaintableObjectConverter : SingleAuthoringComponentConverter<PaintableObjectAuthoring>
{
	protected override void Convert(PaintableObjectAuthoring authoring)
	{
		AddComponentData(new PaintableObjectCD
		{
			color = authoring.color
		});
	}
}
