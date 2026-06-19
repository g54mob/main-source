using Pug.Conversion;

public class RandomWalkGravityConverter : SingleAuthoringComponentConverter<RandomWalkGravityAuthoring>
{
	protected override void Convert(RandomWalkGravityAuthoring authoring)
	{
		AddComponentData(new RandomWalkGravityCD
		{
			attractMask = authoring.attractMask,
			chanceToBeAffectedByGravityWell = authoring.chanceToBeAffectedByGravityWell,
			strength = authoring.strength,
			maxDistanceToBeAffected = authoring.maxDistanceToBeAffected,
			maxAngleDeviation = authoring.maxAngleDeviation,
			isAffected = authoring.isAffected,
			position = authoring.position,
			timer = authoring.timer
		});
	}
}
