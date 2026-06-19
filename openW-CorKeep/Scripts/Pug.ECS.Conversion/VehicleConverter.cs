using Interaction;
using Pug.Conversion;

public class VehicleConverter : SingleAuthoringComponentConverter<VehicleAuthoring>
{
	protected override void Convert(VehicleAuthoring authoring)
	{
		AddComponentData(new VehicleCD
		{
			speedMultiplier = authoring.speedMultiplier,
			driftingMultiplier = authoring.driftingMultiplier,
			accelerationMultiplier = authoring.accelerationMultiplier,
			honkSound = authoring.honkSound
		});
		EnsureHasBuffer<TriggerUseInteractionBuffer>();
	}
}
