using Pug.Conversion;

public class ProximityTriggerConverter : SingleAuthoringComponentConverter<ProximityTriggerAuthoring>
{
	protected override void Convert(ProximityTriggerAuthoring authoring)
	{
		AddComponentData(new ProximityTriggerCD
		{
			radius = authoring.radius,
			delayTime = authoring.delayTime
		});
	}
}
