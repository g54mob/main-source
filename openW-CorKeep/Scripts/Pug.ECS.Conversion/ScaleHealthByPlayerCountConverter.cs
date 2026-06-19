using Pug.Conversion;

public class ScaleHealthByPlayerCountConverter : SingleAuthoringComponentConverter<ScaleHealthByPlayerCountAuthoring>
{
	protected override void Convert(ScaleHealthByPlayerCountAuthoring authoring)
	{
		AddComponentData(new ScaleHealthByPlayerCountCD
		{
			scalingFactor = authoring.scalingFactor
		});
	}
}
