using Unity.Entities;
using UnityEngine.Scripting;

namespace PugMod
{
	[UpdateInGroup(typeof(SimulationSystemGroup), OrderFirst = true)]
	[UpdateBefore(typeof(BeginSimulationEntityCommandBufferSystem))]
	public class RunSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		[Preserve]
		public RunSystemGroup()
		{
		}
	}
}
