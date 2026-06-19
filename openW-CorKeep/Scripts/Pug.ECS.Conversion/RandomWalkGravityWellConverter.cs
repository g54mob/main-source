using Pug.Conversion;

public class RandomWalkGravityWellConverter : SingleAuthoringComponentConverter<RandomWalkGravityWellAuthoring>
{
	protected override void Convert(RandomWalkGravityWellAuthoring authoring)
	{
		AddComponentData(new RandomWalkGravityWellCD
		{
			attractMask = authoring.attractMask,
			radius = authoring.radius,
			timer = authoring.timer
		});
	}
}
