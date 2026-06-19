using Pug.Conversion;
using Unity.Mathematics;

public class DestroyTimerConverter : SingleAuthoringComponentConverter<DestroyTimerAuthoring>
{
	protected override void Convert(DestroyTimerAuthoring authoring)
	{
		uint simulationTickRate = (uint)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
		AddComponentData(new DestroyTimerCD
		{
			timer = new TickTimer(authoring.lifetime.GetValueForCurrentPlatform(), simulationTickRate),
			dontDropLootAfterTimerRunsOut = authoring.dontDropLootAfterTimerRunsOut,
			disablePhysicsAfterTicks = (uint)math.round(authoring.disablePhysicsAfterDuration / (float)simulationTickRate),
			startTimerWhenVariation = authoring.startTimerWhenVariation
		});
		if (authoring.disablePhysicsAfterDuration > 0f)
		{
			EnsureHasComponent<DisablePhysicsCD>(componentIsEnabled: false);
		}
	}
}
