using Pug.Conversion;

public class InteractWithEnvironmentConverter : SingleAuthoringComponentConverter<InteractWithEnvironmentAuthoring>
{
	protected override void Convert(InteractWithEnvironmentAuthoring authoring)
	{
		if (!authoring.disableComponent.GetValueForCurrentPlatform())
		{
			AddComponentData(new InteractWithEnvironmentCD
			{
				radius = authoring.radius
			});
		}
	}
}
