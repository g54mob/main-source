using PlayerState;
using Unity.Entities;
using UnityEngine.Scripting;

namespace PlayerEquipment
{
	[UpdateBefore(typeof(PlayerStateSystemGroup))]
	[UpdateInGroup(typeof(BeforePredictedFixedStepSimulationSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation)]
	public class EquipmentSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		[Preserve]
		public EquipmentSystemGroup()
		{
		}
	}
}
