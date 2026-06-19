using Unity.Entities;
using Unity.NetCode;

namespace PlayerState
{
	public struct ReleaseStateCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public PlayerStateEnum nextState;
	}
}
