using Unity.Entities;
using Unity.NetCode;
using UnityEngine.Scripting;

[UpdateAfter(typeof(PhysicsWorldHistory))]
[UpdateBefore(typeof(PredictedFixedStepSimulationSystemGroup))]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup), OrderFirst = true)]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public class BeforePredictedFixedStepSimulationSystemGroup : ComponentSystemGroup
{
	[Preserve]
	public BeforePredictedFixedStepSimulationSystemGroup()
	{
	}
}
