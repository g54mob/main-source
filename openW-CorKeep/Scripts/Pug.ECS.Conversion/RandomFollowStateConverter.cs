using Pug.Conversion;

public class RandomFollowStateConverter : SingleAuthoringComponentConverter<RandomFollowStateAuthoring>
{
	protected override void Convert(RandomFollowStateAuthoring authoring)
	{
		EnsureHasComponent<StateInfoCD>();
		EnsureHasComponent<DetectCollisionCD>();
		AddComponentData(new RandomFollowStateCD
		{
			objectToFollow = authoring.objectToFollow,
			minDistanceFromObjectToFollow = authoring.minDistanceFromObjectToFollow,
			maxDistanceFromObjectToFollow = authoring.maxDistanceFromObjectToFollow,
			maxWalkDuration = authoring.maxWalkDuration,
			minIdleDuration = authoring.minIdleDuration,
			maxIdleDuration = authoring.maxIdleDuration
		});
		EnsureHasComponent<DetectCollisionCD>();
	}
}
