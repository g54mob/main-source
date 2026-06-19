using Pug.Conversion;

public class AnimationSpeedConverter : SingleAuthoringComponentConverter<AnimationSpeedAuthoring>
{
	protected override void Convert(AnimationSpeedAuthoring authoring)
	{
		AddComponentData(new AnimationSpeedCD
		{
			speed = authoring.speed,
			movementX = authoring.movementX,
			movementY = authoring.movementY
		});
	}
}
