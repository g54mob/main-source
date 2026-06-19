using Pug.Conversion;

public class HatchWhenPlayerNearbyStateConverter : SingleAuthoringComponentConverter<HatchWhenPlayerNearbyStateAuthoring>
{
	protected override void Convert(HatchWhenPlayerNearbyStateAuthoring authoring)
	{
		EnsureHasComponent<StateInfoCD>();
		AddComponentData(new HatchWhenPlayerNearbyStateCD
		{
			timer = authoring.timer,
			timeToHatch = authoring.timeToHatch,
			internalState = authoring.internalState,
			objectToSpawn = authoring.objectToSpawn,
			minSpawnAmount = authoring.minSpawnAmount,
			maxSpawnAmount = authoring.maxSpawnAmount,
			hatchAnimationIsPlaying = authoring.hatchAnimationIsPlaying
		});
	}
}
