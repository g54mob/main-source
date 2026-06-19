using Unity.Burst;
using Unity.Entities;
using UnityEngine.Scripting;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(EndPredictedSimulationSystemGroup))]
public class UpdateSubMapSystemServer : ComponentSystemGroup
{
	[Preserve]
	protected override void OnCreate()
	{
		base.OnCreate();
		AddSystemToUpdateList(base.World.CreateSystem(typeof(UpdateSubMapSystemServerEditor)));
	}

	[Preserve]
	public UpdateSubMapSystemServer()
	{
	}
}
