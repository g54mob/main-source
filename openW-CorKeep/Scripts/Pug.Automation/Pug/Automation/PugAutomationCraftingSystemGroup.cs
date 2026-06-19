using Unity.Entities;
using UnityEngine.Scripting;

namespace Pug.Automation
{
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	public class PugAutomationCraftingSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		public PugAutomationCraftingSystemGroup()
		{
		}
	}
}
