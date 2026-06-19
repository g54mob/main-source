using Interaction;
using Pug.Conversion;

public class BoatConverter : SingleAuthoringComponentConverter<BoatAuthoring>
{
	protected override void Convert(BoatAuthoring authoring)
	{
		AddComponentData(new BoatCD
		{
			speedMultiplier = authoring.speedMultiplier
		});
		EnsureHasBuffer<TriggerUseInteractionBuffer>();
	}
}
