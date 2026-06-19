using Pug.Conversion;

public class NearbyEntitiesTrackerConverter : SingleAuthoringComponentConverter<NearbyEntitiesTrackerAuthoring>
{
	protected override void Convert(NearbyEntitiesTrackerAuthoring authoring)
	{
		AddComponentData(new NearbyEntitiesTrackerCD
		{
			detectsLayer = authoring.detectsLayer.Value,
			radius = authoring.radius,
			ignoreCooldown = authoring.ignoreCooldown
		});
		EnsureHasBuffer<NearbyEntitiesBufferCD>();
	}
}
