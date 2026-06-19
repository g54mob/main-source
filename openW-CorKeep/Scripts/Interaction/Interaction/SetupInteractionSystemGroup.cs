using Unity.Entities;
using UnityEngine.Scripting;

namespace Interaction
{
	[UpdateInGroup(typeof(InteractionSystemGroup), OrderFirst = true)]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public class SetupInteractionSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		[Preserve]
		public SetupInteractionSystemGroup()
		{
		}
	}
}
