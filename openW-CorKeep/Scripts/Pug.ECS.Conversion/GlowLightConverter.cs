using Pug.Conversion;

public class GlowLightConverter : SingleAuthoringComponentConverter<GlowLightAuthoring>
{
	protected override void Convert(GlowLightAuthoring authoring)
	{
		AddComponentData(new SmallGlowLightCD
		{
			color = authoring.color,
			intensity = authoring.intensity
		});
	}
}
