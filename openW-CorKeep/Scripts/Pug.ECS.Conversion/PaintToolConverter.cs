using Pug.Conversion;

public class PaintToolConverter : SingleAuthoringComponentConverter<PaintToolAuthoring>
{
	protected override void Convert(PaintToolAuthoring authoring)
	{
		AddComponentData(new PaintToolCD
		{
			paintIndex = authoring.paintIndex
		});
	}
}
