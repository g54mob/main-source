using Unity.Entities;
using UnityEngine.Scripting;

namespace Interaction
{
	[UpdateInGroup(typeof(InteractionSystemGroup), OrderLast = true)]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public class PerformInteractionSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		[Preserve]
		public PerformInteractionSystemGroup()
		{
		}
	}
}
