using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

namespace PlayerState
{
	public struct FishingStateCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public TickTimer castTimer;

		[GhostField]
		public TickTimer throwTimer;

		[GhostField]
		public TickTimer pullUpTimer;

		[GhostField]
		public TickTimer allowedToLeaveStateTimer;

		[GhostField]
		public TickTimer fishBiteTimer;

		[GhostField]
		public bool queueThrowAgain;

		[GhostField]
		public bool isSuccessfullyFishing;

		[GhostField]
		public bool fishOnTheHook;

		[GhostField]
		public Entity fishShoalEntity;

		[GhostField]
		public Entity octopusBossSpawnLocationEntity;

		[GhostField]
		public Entity octopusBossEntity;

		[GhostField]
		public bool fishIsNibbling;

		[GhostField]
		public ObjectID fishingLootToSpawn;

		[GhostField]
		public float3 targetSinkWorldPosition;

		[GhostField]
		public bool useFishingMiniGame;

		[GhostField]
		public ObjectID startingBaitObjectID;

		[GhostField]
		public int caughtFishCounter;

		public int caughtFishLocalCounter;

		public bool playFishOnHookLocalSound;

		public int displayCaughtFishingLoot;

		public ObjectID displayFishingLootToSpawn;

		public bool isFishingAtOctopusBoss
		{
			get
			{
				if (octopusBossEntity != Entity.Null)
				{
					return octopusBossSpawnLocationEntity != Entity.Null;
				}
				return false;
			}
		}

		public bool spawnOctopusBoss
		{
			get
			{
				if (fishIsNibbling)
				{
					return isFishingAtOctopusBoss;
				}
				return false;
			}
		}

		public bool isFishingInShoal => fishShoalEntity != Entity.Null;

		public bool IsPullingUp => pullUpTimer.isRunning;

		public bool IsCasting(NetworkTick currentTick)
		{
			if (castTimer.isRunning)
			{
				return !castTimer.IsTimerElapsed(currentTick);
			}
			return false;
		}
	}
}
