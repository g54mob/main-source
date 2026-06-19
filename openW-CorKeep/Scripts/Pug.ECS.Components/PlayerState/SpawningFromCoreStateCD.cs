using Unity.Entities;
using Unity.NetCode;

namespace PlayerState
{
	public struct SpawningFromCoreStateCD : IComponentData, IQueryTypeParameter
	{
		public const float StartShakingWaitTime = 2f;

		public const float ShakingMoreWaitTime = 0.9f;

		public const int ShakeMoreCount = 3;

		public const float ShakeMoreWaitTimeEach = 0.4f;

		public const int ShakeALotCount = 20;

		public const float ShakeALotWaitTimeEach = 0.2f;

		public const int ShakeLessCount = 5;

		public const float ShakeLessWaitTimeEach = 0.25f;

		public const float FaceRightWaitTime = 1.7f;

		public const float FaceLeftWaitTime = 0.6f;

		public const float FaceBackWaitTime = 0.8f;

		public const float EmoteTextWaitTime = 0.5f;

		public const float FaceRightWaitTotal = 11.05f;

		public const float FaceLeftWaitTotal = 11.650001f;

		public const float FaceBackWaitTotal = 12.450001f;

		public const float EmoteTextWaitTotal = 12.950001f;

		[GhostField]
		public TickTimer spawnTimer;
	}
}
