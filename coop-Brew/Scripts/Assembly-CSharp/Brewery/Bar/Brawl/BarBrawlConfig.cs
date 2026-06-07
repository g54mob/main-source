using UnityEngine;

namespace Brewery.Bar.Brawl
{
	[CreateAssetMenu(fileName = "BarBrawlConfig", menuName = "Brewery/Bar/BrawlConfig", order = 200)]
	public class BarBrawlConfig : ScriptableObject
	{
		[Header("Enable/Scope")]
		[Tooltip("Enable or disable bar brawls for this bar")]
		public bool brawlEnabled;

		[Tooltip("Minimum bar upgrade level required to enable brawls (0 = no requirement)")]
		public int brawlMinUpgradesToEnable;

		[Tooltip("Clear all brawls when game loads")]
		public bool resetBrawlsOnLoad;

		[Header("Participant Limits")]
		[Tooltip("Maximum NPCs fighting at once")]
		[Range(2f, 10f)]
		public int brawlMaxParticipants;

		[Tooltip("Maximum attackers per target (anti-dogpile)")]
		[Range(1f, 4f)]
		public int maxAttackersPerTarget;

		[Header("Timing")]
		[Tooltip("Seconds after brawl ends before new one can start")]
		public float brawlCooldownGlobal;

		[Tooltip("Seconds between spectator join checks")]
		public float spectatorJoinCheckInterval;

		[Header("Spatial")]
		[Tooltip("Radius from bar center for brawl detection")]
		public float brawlDetectionRadius;

		[Tooltip("Radius for inviting spectators to join")]
		public float brawlInviteRadius;

		[Header("Targeting")]
		[Tooltip("Allow NPCs to target player in brawls")]
		public bool brawlAllowPlayerTarget;

		[Header("KO Settings")]
		[Tooltip("Seconds NPC stays down after knockout")]
		public float knockoutRecoveryTime;

		[Header("Debug")]
		[Tooltip("Show debug logs in console")]
		public bool showDebugLogs;

		[Tooltip("Draw gizmos for detection radii")]
		public bool showGizmos;
	}
}
