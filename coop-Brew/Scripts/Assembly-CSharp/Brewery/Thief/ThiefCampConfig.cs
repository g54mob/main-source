using Brewery.CombatSystem;
using UnityEngine;

namespace Brewery.Thief
{
	[CreateAssetMenu(fileName = "ThiefCampConfig", menuName = "Brewery/Thief Camp Config")]
	public class ThiefCampConfig : ScriptableObject
	{
		[Header("Prefab")]
		[Tooltip("Thief prefab. StealerBrain or DefenderBrain is added at runtime based on role.")]
		public GameObject thiefPrefab;

		[Header("Tier System")]
		[Tooltip("Day number when thieves start operating (1 = first day). Before this day = no thieves.")]
		public int activationDay;

		[Tooltip("Difficulty tiers. Each tier defines stealer/defender counts based on day progression. System uses the highest tier the player qualifies for. MAX: 2 stealers, 4 defenders.")]
		public ThiefTierConfig[] tiers;

		[Header("Spawn Settings")]
		[Tooltip("Base number of defenders that spawn when below activation day. Once a tier is active, the tier's defender count is used instead.")]
		[Range(1f, 5f)]
		public int baseDefenderCount;

		[Tooltip("Radius around camp for thief spawning.")]
		[Range(1f, 20f)]
		public float spawnRadius;

		[Tooltip("Hour of day (0-23) when the thief pool respawns.")]
		[Range(0f, 23f)]
		public int respawnHour;

		[Tooltip("Minute (0-59) of the respawn hour.")]
		[Range(0f, 59f)]
		public int respawnMinute;

		[Tooltip("Grace period at game start before thieves begin stealing (seconds).")]
		[Range(0f, 300f)]
		public float newPlayerGracePeriod;

		[Tooltip("Minimum real-time seconds before defeated stealers can respawn. These are the thieves that steal — longer cooldown means the player gets actual breathing room after killing them. 0 = no cooldown.")]
		[Range(0f, 3600f)]
		public float stealerRespawnCooldownSeconds;

		[Tooltip("Minimum real-time seconds before defeated defenders can respawn. Shorter than stealers so the camp stays dangerous to raid. 0 = no cooldown.")]
		[Range(0f, 3600f)]
		public float defenderRespawnCooldownSeconds;

		[Header("Theft Behavior")]
		[Tooltip("Time (seconds) the thief channels to steal items.")]
		[Range(2f, 10f)]
		public float stealChannelDuration;

		[Tooltip("Maximum items a thief can steal per theft attempt.")]
		[Range(1f, 10f)]
		public int maxItemsPerTheft;

		[Tooltip("Maximum stack size per item stolen.")]
		[Range(1f, 20f)]
		public int maxStackPerTheft;

		[Tooltip("Maximum total value a thief can steal per attempt.")]
		[Range(100f, 1000f)]
		public float maxValuePerTheft;

		[Tooltip("Minimum distance player must be from storage for thief to attempt theft.")]
		[Range(10f, 100f)]
		public float minPlayerDistanceForTheft;

		[Tooltip("Thief movement speed when approaching target.")]
		[Range(2f, 5f)]
		public float thiefApproachSpeed;

		[Tooltip("Thief movement speed when escaping with loot.")]
		[Range(4f, 8f)]
		public float thiefEscapeSpeed;

		[Tooltip("How far from the storage shelf the thief stops to steal.")]
		[Range(0.5f, 3f)]
		public float stealStopDistance;

		[Tooltip("Delay (seconds) before an idle thief decides to go steal. Set low (0.5) for instant action.")]
		[Range(0.1f, 60f)]
		public float stealDecisionDelay;

		[Header("Opportunity Timing")]
		[Tooltip("Seconds to wait before re-checking opportunity when all targets are guarded.")]
		[Range(10f, 120f)]
		public float opportunityRetryDelay;

		[Header("Thief-Specific Settings")]
		[Tooltip("Detection range for thieves to spot players (NOT hit detection).")]
		[Range(5f, 30f)]
		public float thiefDetectionRange;

		[Tooltip("Radius around camp where players trigger defense.")]
		[Range(10f, 30f)]
		public float campDefenseRadius;

		[Tooltip("Maximum distance from camp center that defenders will chase a player. Once the target exceeds this distance from camp, defenders disengage and return.")]
		[Range(15f, 60f)]
		public float campLeashRadius;

		[Tooltip("Detection range for defenders while patrolling to spot players.")]
		[Range(5f, 30f)]
		public float patrolDetectionRange;

		[Header("Combat Configurations")]
		[Tooltip("Combat config for defenders - ultra-aggressive, almost no cooldown.")]
		public NPCCombatConfig defenderCombatConfig;

		[Tooltip("Combat config for stealers - hit-and-run, quick retreat.")]
		public NPCCombatConfig stealerCombatConfig;

		[Header("Revenge System")]
		[Tooltip("How long revenge party fights before returning to camp (seconds from first hit).")]
		[Range(10f, 60f)]
		public float revengeAttackDuration;

		[Tooltip("Maximum defenders that respond to a revenge alert. Prevents overwhelming player.")]
		[Range(1f, 5f)]
		public int maxRevengeDefenders;

		[Tooltip("Sprint speed when defenders are chasing player or returning to camp.")]
		[Range(4f, 10f)]
		public float defenderSprintSpeed;

		[Header("Loot & Regeneration")]
		[Tooltip("Time (minutes) for camp to regenerate after being raided.")]
		[Range(1f, 30f)]
		public float campRegenerationMinutes;

		[Tooltip("Whether defeated thieves drop their carried loot.")]
		public bool dropsLootOnDeath;

		[Tooltip("Minimum bonus gold dropped when camp is raided.")]
		[Range(0f, 500f)]
		public int bonusGoldMin;

		[Tooltip("Maximum bonus gold dropped when camp is raided.")]
		[Range(100f, 1000f)]
		public int bonusGoldMax;

		[Tooltip("Chance for bonus item drop on camp raid.")]
		[Range(0f, 1f)]
		public float bonusItemDropChance;

		[Tooltip("Hours before stolen items expire.")]
		[Range(1f, 48f)]
		public float itemExpirationHours;

		[Header("Debug")]
		[Tooltip("Enable verbose logging for thief system.")]
		public bool showDebugLogs;

		[Header("Camp Relocation")]
		[Tooltip("Number of in-game days between camp relocations. Set to 0 to disable.")]
		[Range(0f, 30f)]
		public int relocationIntervalDays;

		[Tooltip("Radius to check for player proximity before relocating. Relocation is blocked if any player is within this radius of EITHER current OR target location.")]
		[Range(10f, 100f)]
		public float relocationProximityRadius;

		[Tooltip("Seconds between retry attempts when relocation is blocked by player proximity.")]
		[Range(1f, 60f)]
		public float relocationRetryInterval;

		[Tooltip("Hour of day (0-23) when relocation check occurs.")]
		[Range(0f, 23f)]
		public int relocationHour;

		[Tooltip("Minute (0-59) of the relocation hour.")]
		[Range(0f, 59f)]
		public int relocationMinute;

		public float CampRegenerationSeconds => 0f;

		public float ItemExpirationSeconds => 0f;

		public ThiefTierConfig GetCurrentTierByDay(int dayIndex)
		{
			return null;
		}

		public int GetTierIndexByDay(int dayIndex)
		{
			return 0;
		}

		public int GetStealerCountByDay(int dayIndex)
		{
			return 0;
		}

		public int GetDefenderCountByDay(int dayIndex)
		{
			return 0;
		}

		public bool ShouldThievesBeActiveByDay(int dayIndex)
		{
			return false;
		}

		private void OnValidate()
		{
		}
	}
}
