using Unity.Entities;
using UnityEngine.Scripting;

namespace Inventory
{
	[UpdateInGroup(typeof(EndPredictedSimulationSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public class InventorySystemGroup : ComponentSystemGroup
	{
		[Preserve]
		public InventorySystemGroup()
		{
		}
	}
}
