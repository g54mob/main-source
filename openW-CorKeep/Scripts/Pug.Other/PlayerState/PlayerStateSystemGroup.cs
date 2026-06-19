using Unity.Entities;
using UnityEngine.Scripting;

namespace PlayerState
{
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation)]
	[UpdateInGroup(typeof(BeforePredictedFixedStepSimulationSystemGroup))]
	public class PlayerStateSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		public PlayerStateSystemGroup()
		{
		}
	}
}
