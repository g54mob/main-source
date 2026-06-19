using Pug.Conversion;

public class MovementSpeedConverter : SingleAuthoringComponentConverter<MovementSpeedAuthoring>
{
	protected override void Convert(MovementSpeedAuthoring authoring)
	{
		AddComponentData(new MovementSpeedCD
		{
			speed = authoring.speed,
			originalSpeed = authoring.speed
		});
	}
}
