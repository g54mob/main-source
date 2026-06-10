namespace NSMedieval.Village
{
	public static class VillageConstants
	{
		public const int RegionMaxNodesCount = 420;

		public const uint HeuristicsScale = 100u;

		public const ushort DefaultPenalty = 1000;

		public const ushort MaxPenalty = ushort.MaxValue;

		public const ushort FirePenalty = 20000;

		public const ushort StockpilePenalty = 2000;

		public const ushort ResourcePilePenalty = 2000;

		public const ushort OthersUnfinishedPenalty = 6000;

		public const float DefaultSpeedMultiplier = 0.85f;

		public const float AgentMinimumMovementSpeed = 0.22f;

		public const float LadderClimbMovementMultiplier = 0.8f;

		public const float LadderMinimumClimbAnimationThreshold = 0.035f;

		public static readonly float AgentLadderFallDownAcceleration = 1.3f;

		public static readonly float AgentFallDownDelay = 1f;

		public static readonly float AgentPathfindingDriverAtNodeCenter = 0.08f;

		public const float HumanFoodRequirementPerHour = 5f;
	}
}
