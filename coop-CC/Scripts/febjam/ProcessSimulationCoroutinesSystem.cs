using Aggro.Core;

[UpdateInGroup(typeof(SimulationEarlySystemGroup), -100)]
public class ProcessSimulationCoroutinesSystem : EntitySystemBase
{
	protected override void OnUpdateSystem()
	{
		base.world.simulationCoroutineManager.Update();
	}
}
