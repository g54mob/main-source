using Unity.Entities;
using UnityEngine.Scripting;

namespace Pug.Automation
{
	[UpdateAfter(typeof(PugAutomationStartCraftSystemGroup))]
	[UpdateInGroup(typeof(PugAutomationCraftingSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	public class PugAutomationFinishCraftingSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		public PugAutomationFinishCraftingSystemGroup()
		{
		}
	}
}
