using Pug.Conversion;

public class ActAsLightSourceWhenHeldInHandConverter : SingleAuthoringComponentConverter<ActAsLightSourceWhenHeldInHandAuthoring>
{
	protected override void Convert(ActAsLightSourceWhenHeldInHandAuthoring authoring)
	{
		AddComponentData(new ActAsLightSourceWhenHeldInHandCD
		{
			color = authoring.color,
			range = authoring.range
		});
	}
}
