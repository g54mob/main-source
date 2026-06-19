using Pug.Conversion;

public class IdleWhenNearbyPlayerConverter : SingleAuthoringComponentConverter<IdleWhenNearbyPlayerStateAuthoring>
{
	protected override void Convert(IdleWhenNearbyPlayerStateAuthoring authoring)
	{
		EnsureHasComponent<StateInfoCD>();
		AddComponentData(new IdleWhenNearbyPlayerStateCD
		{
			sqDistanceToStartIdle = authoring.distanceToStartIdle * authoring.distanceToStartIdle
		});
		EnsureHasComponent<DistanceToPlayerCD>();
	}
}
