using Unity.Entities;
using UnityEngine.Scripting;

namespace Inventory
{
	[UpdateAfter(typeof(InventoryUpdateSystem))]
	[UpdateInGroup(typeof(InventorySystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public class InventoryResultEvaluationSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		public InventoryResultEvaluationSystemGroup()
		{
		}
	}
}
