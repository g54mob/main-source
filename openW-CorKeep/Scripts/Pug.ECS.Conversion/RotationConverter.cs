using Pug.Conversion;

public class RotationConverter : SingleAuthoringComponentConverter<RotationAuthoring>
{
	protected override void Convert(RotationAuthoring authoring)
	{
		AddComponentData(new DirectionCD
		{
			direction = authoring.initialDirection,
			rotationIconOffset = authoring.rotationIconOffset
		});
	}
}
