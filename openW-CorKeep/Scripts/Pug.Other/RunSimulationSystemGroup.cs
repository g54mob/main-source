#define UNITY_ENTITIES_DYNAMIC_SIMPLE_DEPENDENCY
using Unity.Entities;
using Unity.NetCode;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.Editor | WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup), OrderFirst = true)]
[UpdateBefore(typeof(BeginSimulationSystemGroup))]
[UpdateBefore(typeof(NetworkReceiveSystemGroup))]
[UpdateAfter(typeof(BeginSimulationEntityCommandBufferSystem))]
public class RunSimulationSystemGroup : ComponentSystemGroup
{
	[Preserve]
	[Preserve]
	public RunSimulationSystemGroup()
	{
	}

	[Preserve]
	protected override void OnUpdate()
	{
		base.EntityManager.BeginSingleSystemDependencyMode();
		base.OnUpdate();
		base.EntityManager.EndSingleSystemDependencyMode();
	}
}
