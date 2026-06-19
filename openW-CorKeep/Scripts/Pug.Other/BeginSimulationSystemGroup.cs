using Unity.Entities;
using Unity.NetCode;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.Default | WorldSystemFilterFlags.Editor, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup), OrderFirst = true)]
[UpdateAfter(typeof(PredictedSimulationSystemGroup))]
[UpdateBefore(typeof(FixedStepSimulationSystemGroup))]
public class BeginSimulationSystemGroup : ComponentSystemGroup
{
	[Preserve]
	[Preserve]
	public BeginSimulationSystemGroup()
	{
	}
}
