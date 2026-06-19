using Unity.Entities;
using Unity.NetCode;

namespace PlayerState
{
	public struct AnticipationCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public TickTimer AnticipationDuration;

		[GhostField]
		public TickTimer cooldowmTimer;

		[GhostField]
		public bool firstAttack;
	}
}
