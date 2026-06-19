using Unity.Entities;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.Default | WorldSystemFilterFlags.Editor, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
[UpdateBefore(typeof(EndSimulationEntityCommandBufferSystem))]
public class EndSimulationSystemGroup : ComponentSystemGroup
{
	[Preserve]
	[Preserve]
	public EndSimulationSystemGroup()
	{
	}
}
