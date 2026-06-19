using Pug.Conversion;

public class VisualSmoothFollowConverter : SingleAuthoringComponentConverter<VisualSmoothFollowAuthoring>
{
	protected override void Convert(VisualSmoothFollowAuthoring authoring)
	{
		EnsureHasComponent<VisualSmoothFollowEntityCD>();
		AddComponentData(new VisualSmoothFollowSpeedCD
		{
			Value = authoring.speed
		});
	}
}
