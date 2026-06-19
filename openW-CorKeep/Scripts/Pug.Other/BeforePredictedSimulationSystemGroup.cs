using Unity.Entities;
using Unity.NetCode;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup), OrderFirst = true)]
[UpdateAfter(typeof(GhostSimulationSystemGroup))]
[UpdateBefore(typeof(PredictedSimulationSystemGroup))]
public class BeforePredictedSimulationSystemGroup : ComponentSystemGroup
{
	[Preserve]
	public BeforePredictedSimulationSystemGroup()
	{
	}
}
