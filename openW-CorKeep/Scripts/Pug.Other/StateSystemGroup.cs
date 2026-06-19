using Unity.Entities;
using UnityEngine.Scripting;

[UpdateInGroup(typeof(SimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public class StateSystemGroup : ComponentSystemGroup
{
	[Preserve]
	[Preserve]
	public StateSystemGroup()
	{
	}
}
