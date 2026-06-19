using Unity.Entities;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(BeforePredictedSimulationSystemGroup))]
public class TriggerLightUpdateSystem : SystemBase
{
	[Preserve]
	protected override void OnUpdate()
	{
		ManagedLight.UpdateOptimization();
		Manager.lights.UpdateLightFlickerEffect();
	}

	[Preserve]
	public TriggerLightUpdateSystem()
	{
	}
}
