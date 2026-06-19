using Unity.Entities;
using Unity.NetCode;
using UnityEngine;

namespace PlayerState
{
	public struct TeleportingStateCD : IComponentData, IQueryTypeParameter
	{
		public const float FadeOutStartTimestampSeconds = 1.1f;

		public const float PerformTeleportTimestampSeconds = 4.1f;

		public const float FinishTeleportingTimestampSeconds = 6.1f;

		[GhostField]
		public TickTimer teleportingTimer;

		[GhostField]
		public Vector3 targetPosition;

		public float lastVisualTeleportTimestamp;
	}
}
