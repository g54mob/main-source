using Unity.Entities;
using Unity.NetCode;

namespace PlayerState
{
	public struct FishingMiniGameStateCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public TickTimer beginMiniGameTimer;

		[GhostField]
		public TickTimer miniGameOverTimer;

		[GhostField]
		public TickTimer fishStruggleTimer;

		[GhostField]
		public MiniGameOutcome miniGameOutcome;

		[GhostField]
		public int fishStruggleIndex;

		[GhostField]
		public bool isInFishingMiniGame;

		[GhostField]
		public bool fishIsStruggling;

		[GhostField]
		public bool playerReeling;

		[GhostField]
		public bool prevPlayerReeling;

		[GhostField]
		public float struggleBlend;

		[GhostField]
		public float reelVolume;

		[GhostField]
		public float lineTension;

		[GhostField]
		public float struggleAudioFadeOutTime;

		[GhostField]
		public float fishPosition;

		[GhostField]
		public int fishLevel;
	}
}
