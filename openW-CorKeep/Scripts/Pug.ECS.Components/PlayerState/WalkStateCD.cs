using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

namespace PlayerState
{
	public struct WalkStateCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public Direction previousDirection;

		[GhostField]
		public float3 previousVelocity;

		[GhostField]
		public TickTimer reorientationDelay;

		public float accumulatedSkillMovement;
	}
}
