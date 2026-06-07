using UnityEngine;

namespace Brewery.CombatSystem
{
	[CreateAssetMenu(fileName = "NPCCombatConfig", menuName = "Brewery/NPC Combat Config")]
	public class NPCCombatConfig : ScriptableObject
	{
		private static NPCCombatConfig _default;

		private static bool _defaultLoaded;

		[Header("Hit Detection")]
		[Tooltip("Range at which attacks land (cone detection radius). This is THE hit detection range.")]
		[Range(0.5f, 3f)]
		public float hitDetectionRange;

		[Tooltip("Cone angle for hit detection (degrees).")]
		[Range(30f, 180f)]
		public float hitDetectionAngle;

		[Tooltip("Buffer to ensure NPC stops INSIDE hit range, not at edge.")]
		[Range(0f, 0.5f)]
		public float stoppingDistanceBuffer;

		[Header("Movement")]
		[Tooltip("Speed when approaching target.")]
		[Range(1f, 8f)]
		public float approachSpeed;

		[Tooltip("Slower menacing walk speed for self-defense mode.")]
		[Range(0.5f, 4f)]
		public float selfDefenseApproachSpeed;

		[Tooltip("Speed when retreating.")]
		[Range(1f, 8f)]
		public float retreatSpeed;

		[Tooltip("Distance to retreat after attacking.")]
		[Range(1f, 10f)]
		public float retreatDistance;

		[Header("Combat Timing")]
		[Tooltip("Minimum time between attacks (randomized per attack).")]
		[Range(0.1f, 5f)]
		public float attackCooldownMin;

		[Tooltip("Maximum time between attacks (randomized per attack).")]
		[Range(0.1f, 5f)]
		public float attackCooldownMax;

		[Tooltip("Duration of retreat phase (seconds).")]
		[Range(0.5f, 3f)]
		public float retreatDuration;

		[Tooltip("Chance to retreat after each attack (0-1).")]
		[Range(0f, 1f)]
		public float retreatChance;

		[Header("Target Selection (Proximity-Based Retargeting)")]
		[Tooltip("How often to check for closer targets (seconds). 0 = disabled.")]
		[Range(0f, 10f)]
		public float retargetInterval;

		[Tooltip("Switch to a closer player only if they are this much closer than current target (meters).")]
		[Range(0f, 10f)]
		public float retargetDistanceThreshold;

		[Header("Chase Limits")]
		[Tooltip("Max distance to chase target before giving up.")]
		[Range(5f, 500f)]
		public float maxChaseDistance;

		[Tooltip("Max time in combat before auto-exiting (0 = no limit).")]
		[Range(0f, 300f)]
		public float maxCombatDuration;

		[Tooltip("Time without valid target before exiting combat.")]
		[Range(1f, 30f)]
		public float combatIdleTimeout;

		[Header("Combat Rhythm")]
		[Tooltip("Whether taking damage resets attack cooldown (gives player breathing room).")]
		public bool resetCooldownOnHit;

		[Tooltip("Hits taken before revenge mode triggers (ignores cooldown reset).")]
		[Range(1f, 10f)]
		public int revengeHitThreshold;

		[Tooltip("Extra cooldown after recovering from stagger.")]
		[Range(0f, 3f)]
		public float postStaggerCooldown;

		[Header("Damage")]
		[Tooltip("Base damage per hit (can be scaled by difficulty).")]
		[Range(1f, 100f)]
		public float baseDamage;

		public static NPCCombatConfig Default => null;

		public float StoppingDistance => 0f;

		private static NPCCombatConfig CreateRuntimeDefault()
		{
			return null;
		}

		public static void ClearDefaultCache()
		{
		}

		public float GetRandomAttackCooldown()
		{
			return 0f;
		}

		private void OnValidate()
		{
		}
	}
}
