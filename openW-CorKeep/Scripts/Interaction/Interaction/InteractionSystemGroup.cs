using PlayerState;
using Unity.Entities;
using Unity.NetCode;
using UnityEngine.Scripting;

namespace Interaction
{
	[UpdateBefore(typeof(UpdatePlayerStateAfterPhysicsSystem))]
	[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public class InteractionSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		[Preserve]
		public InteractionSystemGroup()
		{
		}
	}
}
