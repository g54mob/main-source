using Interaction;
using Pug.Conversion;

public class MinecartConverter : SingleAuthoringComponentConverter<MinecartAuthoring>
{
	protected override void Convert(MinecartAuthoring authoring)
	{
		AddComponentData(new MinecartCD
		{
			currentSpeed = authoring.currentSpeed,
			isBreaking = authoring.isBreaking,
			maxSpeed = authoring.maxSpeed
		});
		EnsureHasBuffer<TriggerUseInteractionBuffer>();
	}
}
