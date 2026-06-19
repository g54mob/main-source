using Unity.Burst;
using Unity.Entities;
using UnityEngine.Scripting;

namespace ContainedMiniSim
{
	[BurstCompile]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public class ContainedMiniSimSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		[Preserve]
		public ContainedMiniSimSystemGroup()
		{
		}
	}
}
