using UnityEngine;

namespace Brewery.NPC.Data
{
	[CreateAssetMenu(fileName = "NPCBehaviorSettings", menuName = "Brewery/NPC/Behavior Settings", order = 130)]
	public class NPCBehaviorSettings : ScriptableObject
	{
		[Header("Movement & Navigation")]
		[Tooltip("How close to destination before considered 'arrived' (meters)")]
		[Range(0.1f, 3f)]
		public float destinationTolerance;

		[Tooltip("NavMeshAgent rotation speed (degrees/second)")]
		[Range(90f, 720f)]
		public float angularSpeed;

		[Tooltip("Check if NPC is stuck every N seconds")]
		[Range(0.5f, 10f)]
		public float stuckDetectionInterval;

		[Tooltip("NPC must move at least this far (meters) during stuck check to not be stuck")]
		[Range(0.1f, 2f)]
		public float stuckPositionThreshold;

		[Tooltip("Give up pathfinding after N seconds")]
		[Range(10f, 120f)]
		public float pathfindingTimeout;

		[Tooltip("Distance to be considered 'at home' (meters)")]
		[Range(1f, 10f)]
		public float homeDistanceThreshold;

		[Header("Wander & Idle Behavior")]
		[Tooltip("⭐ MINIMUM seconds NPC must sit still after arriving before allowing any wander movement")]
		[Range(0f, 10f)]
		public float minimumSitTimeBeforeMovement;

		[Tooltip("Minimum seconds between idle wanders (applies to low-energy NPCs)")]
		[Range(1f, 30f)]
		public float idleWanderIntervalMin;

		[Tooltip("Maximum seconds between idle wanders (applies to high-energy NPCs)")]
		[Range(1f, 30f)]
		public float idleWanderIntervalMax;

		[Tooltip("Additional random variance added to wander interval")]
		[Range(0f, 10f)]
		public float idleWanderIntervalVariance;

		[Tooltip("If true, high-energy NPCs wander more frequently")]
		public bool idleWanderEnergyInfluence;

		[Tooltip("Minimum multiplier of hotspot radius for wander distance (e.g., 0.8 = 80%)")]
		[Range(0.1f, 2f)]
		public float wanderRadiusMinMultiplier;

		[Tooltip("Maximum multiplier of hotspot radius for wander distance (e.g., 1.2 = 120%)")]
		[Range(0.1f, 2f)]
		public float wanderRadiusMaxMultiplier;

		[Tooltip("Minimum multiplier for initial spread when arriving at hotspot")]
		[Range(0.1f, 1f)]
		public float spreadRadiusMinMultiplier;

		[Tooltip("Maximum multiplier for initial spread when arriving at hotspot")]
		[Range(0.1f, 1f)]
		public float spreadRadiusMaxMultiplier;

		[Header("Interaction & Social")]
		[Tooltip("Wait N seconds after interaction ends before allowing movement")]
		[Range(0f, 10f)]
		public float postInteractionCooldown;

		[Tooltip("Distance at which NPCs can start interacting (meters)")]
		[Range(0.5f, 5f)]
		public float interactionCloseEnoughDistance;

		[Tooltip("Target distance NPCs try to maintain during interaction (meters)")]
		[Range(0.3f, 3f)]
		public float interactionIdealDistance;

		[Tooltip("Spatial partitioning grid cell size for interaction detection (meters)")]
		[Range(5f, 50f)]
		public float gridCellSize;

		[Tooltip("How often to check for new interactions (seconds)")]
		[Range(0.05f, 1f)]
		public float interactionUpdateInterval;

		[Header("Animation")]
		[Tooltip("Maximum vertical head look angle (up/down, degrees)")]
		[Range(10f, 60f)]
		public float maxVerticalHeadAngle;

		[Tooltip("Range at which NPCs look at other NPCs (meters)")]
		[Range(1f, 10f)]
		public float npcToNPCLookRange;

		[Tooltip("Field of view angle for NPC-to-NPC looking (degrees, from forward)")]
		[Range(30f, 180f)]
		public float npcLookFieldOfView;

		[Tooltip("⭐ Minimum time between idle animation changes (seconds) - prevents animations from being too rare")]
		[Range(5f, 60f)]
		public float minAnimationChangeInterval;

		[Tooltip("⭐ Maximum time between idle animation changes (seconds) - prevents animations from being too frequent")]
		[Range(10f, 120f)]
		public float maxAnimationChangeInterval;

		[Header("Bar & Purchasing")]
		[Tooltip("Maximum attempts to find bar spot before giving up")]
		[Range(1f, 50f)]
		public int maxBarAcquisitionAttempts;

		[Tooltip("Maximum attempts to complete a purchase")]
		[Range(1f, 100f)]
		public int maxPurchaseAttempts;

		[Tooltip("Give up purchase after N seconds")]
		[Range(5f, 120f)]
		public float maxPurchaseWaitTime;

		[Tooltip("Cooldown after successful purchase (seconds)")]
		[Range(0.1f, 10f)]
		public float purchaseCooldownSuccess;

		[Tooltip("Cooldown between purchase retry attempts (seconds)")]
		[Range(0.1f, 10f)]
		public float purchaseCooldownRetry;

		[Header("Intoxication")]
		[Tooltip("Intoxication level (0-1) at which NPC is considered 'drunk'")]
		[Range(0f, 1f)]
		public float drunkThreshold;

		[Tooltip("Movement speed multiplier at drunk threshold (e.g., 0.65 = 35% slower)")]
		[Range(0.1f, 1f)]
		public float drunkSpeedMultiplierMin;

		[Tooltip("Movement speed multiplier when fully drunk (e.g., 0.3 = 70% slower)")]
		[Range(0.1f, 1f)]
		public float drunkSpeedMultiplierMax;

		[Header("Performance & Limits")]
		[Tooltip("AI tick rate (seconds between updates). Lower = more responsive but higher CPU cost")]
		[Range(0.05f, 0.5f)]
		public float tickInterval;

		[Tooltip("Maximum hotspots to track in cooldown list")]
		[Range(10f, 200f)]
		public int maxVisitedHotspots;

		[Tooltip("Exponential backoff base for retry delays")]
		[Range(1.5f, 3f)]
		public float retryBackoffBase;

		[Tooltip("Maximum random variance added to retry delays (seconds)")]
		[Range(0f, 5f)]
		public float retryRandomVariance;

		private void OnValidate()
		{
		}

		public string GetSummary()
		{
			return null;
		}
	}
}
