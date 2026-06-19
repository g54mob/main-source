using Unity.Entities;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.ClientSimulation)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class LocalPresentationCueSystemGroup : ComponentSystemGroup
{
	[Preserve]
	[Preserve]
	public LocalPresentationCueSystemGroup()
	{
	}
}
