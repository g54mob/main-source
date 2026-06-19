using Pug.Conversion;

public class DestroyWhenNoNearbyPlayerConverter : SingleAuthoringComponentConverter<DestroyWhenNoNearbyPlayerAuthoring>
{
	protected override void Convert(DestroyWhenNoNearbyPlayerAuthoring authoring)
	{
		float num = ((authoring.distance > 0f) ? authoring.distance : 40f);
		AddComponentData(new DestroyEntityWhenNoNearbyPlayerCD
		{
			distanceSq = num * num,
			destroyDelay = authoring.destroyDelay
		});
		EnsureHasComponent<DistanceToPlayerCD>();
	}
}
