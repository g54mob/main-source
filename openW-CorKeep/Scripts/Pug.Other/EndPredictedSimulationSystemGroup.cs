using Unity.Entities;
using Unity.NetCode;
using UnityEngine.Scripting;

[UpdateInGroup(typeof(PredictedSimulationSystemGroup), OrderLast = true)]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public class EndPredictedSimulationSystemGroup : SimulationSystemGroup
{
	[Preserve]
	public EndPredictedSimulationSystemGroup()
	{
	}
}
