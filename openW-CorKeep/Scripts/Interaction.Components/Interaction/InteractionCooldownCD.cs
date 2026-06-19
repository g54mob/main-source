using Unity.Entities;
using Unity.NetCode;

namespace Interaction
{
	public struct InteractionCooldownCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public TickTimer cooldownTimer;
	}
}
