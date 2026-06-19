using Unity.Entities;
using UnityEngine.Scripting;

namespace Pug.Automation
{
	[UpdateInGroup(typeof(PugAutomationCraftingSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	public class PugAutomationStartCraftSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		public PugAutomationStartCraftSystemGroup()
		{
		}
	}
}
