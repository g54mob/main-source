using Unity.Entities;
using Unity.NetCode;

namespace PlayerState
{
	public struct SittingStateCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public TickTimer tryingToLeaveStateTimer;

		[GhostField]
		public TickTimer allowedToLeaveStateTimer;
	}
}
