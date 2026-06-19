using Unity.Entities;
using Unity.NetCode;
using UnityEngine.Scripting;

[UpdateAfter(typeof(EndPredictedSimulationSystemGroup))]
[UpdateBefore(typeof(GhostPredictionSmoothingSystem))]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup), OrderLast = true)]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public class PredictionSmoothingSystemGroup : ComponentSystemGroup
{
	[Preserve]
	protected override void OnCreate()
	{
		base.World.GetExistingSystemManaged<PredictedSimulationSystemGroup>().AddSystemToPartialTickUpdate(ref base.CheckedStateRef);
		base.OnCreate();
	}

	[Preserve]
	public PredictionSmoothingSystemGroup()
	{
	}
}
