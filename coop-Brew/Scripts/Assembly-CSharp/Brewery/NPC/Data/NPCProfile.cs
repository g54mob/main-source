using Brewery.CombatSystem;
using Brewery.Data;
using Brewery.NPC.Scheduling;
using UnityEngine;

namespace Brewery.NPC.Data
{
	[CreateAssetMenu(fileName = "NPC_Profile", menuName = "Brewery/NPC/Profile", order = 100)]
	public class NPCProfile : ScriptableObject, INPCProfile
	{
		[Header("Identity")]
		[SerializeField]
		private string npcId;

		[SerializeField]
		private string displayName;

		[Header("Localization")]
		[SerializeField]
		private string displayNameKey;

		[SerializeField]
		private NPCGender gender;

		[SerializeField]
		private Sprite portrait;

		[SerializeField]
		[Tooltip("The faction this NPC belongs to (determines price multipliers and refused drinks).")]
		private FactionData faction;

		[Tooltip("NPC prefab to spawn for this character. Must have SimpleNPCController and NetworkObject components.")]
		[SerializeField]
		private GameObject npcPrefab;

		[Header("Population System")]
		[Tooltip("If true, this NPC spawns at game start as a local resident (market clerks, essential NPCs). If false, this NPC can appear as a visitor.")]
		[SerializeField]
		private bool isLocalNPC;

		[Header("Travel")]
		[SerializeField]
		private NPCTravelMode travelMode;

		[SerializeField]
		[Tooltip("Meters per second when walking between points.")]
		private float walkSpeed;

		[SerializeField]
		[Tooltip("Meters per second when running (used for urgency/drunk wobble).")]
		private float runSpeed;

		[SerializeField]
		[Tooltip("Optional ID for the car or parking spot reserved for this NPC.")]
		private string vehicleAssignmentId;

		[Header("Bar Routine")]
		[SerializeField]
		[Tooltip("Minimum and maximum number of drinks purchased per bar visit.")]
		private Vector2Int drinkPurchaseRange;

		[SerializeField]
		[Tooltip("Seconds spent hanging out in the bar after purchasing.")]
		private Vector2 hangoutDurationRange;

		[SerializeField]
		[Tooltip("Seconds minimum between bar visit loops once back home.")]
		private Vector2 homeCooldownRange;

		[SerializeField]
		[Tooltip("If false, this NPC will never visit bars (clerks go directly home after work).")]
		private bool canVisitBar;

		[Header("Bar Brawl")]
		[SerializeField]
		[Tooltip("Chance (0-1) to start a bar brawl after finishing a drink.")]
		private float brawlStartChanceAfterDrink;

		[SerializeField]
		[Tooltip("Chance (0-1) to join an ongoing bar brawl when nearby.")]
		private float brawlJoinChance;

		[SerializeField]
		[Tooltip("Meters to look for targets to start a brawl.")]
		private float brawlAggroRadius;

		[SerializeField]
		[Tooltip("Meters to invite others to join a brawl.")]
		private float brawlCallRadius;

		[SerializeField]
		[Tooltip("Chance (0-1) to pick the player as target when in range.")]
		private float brawlTargetPlayerChance;

		[SerializeField]
		[Tooltip("Seconds between brawl attempts for this NPC.")]
		private float brawlCooldownSeconds;

		[SerializeField]
		[Tooltip("Fraction of max health to trigger flee (0-1).")]
		[Range(0f, 1f)]
		private float brawlFleeHealthThreshold;

		[SerializeField]
		[Tooltip("Chance (0-1) to just watch a brawl instead of joining.")]
		private float brawlWatchOnlyChance;

		[SerializeField]
		[Tooltip("If true, this NPC never starts or joins brawls.")]
		private bool brawlNonCombatant;

		[SerializeField]
		[Tooltip("Max attackers per target to avoid dogpiles.")]
		private int brawlMaxConcurrentTargets;

		[SerializeField]
		[Tooltip("Optional unarmed weapon override for brawls (damage, stamina, block).")]
		private WeaponItem brawlUnarmedWeaponOverride;

		[SerializeField]
		[Tooltip("Optional per-NPC cap on participants; leave 0 for bar default.")]
		private int brawlMaxParticipantsOverride;

		[Header("Health & Combat (INPCProfile)")]
		[SerializeField]
		[Tooltip("Maximum health points for this NPC.")]
		private float maxHealth;

		[SerializeField]
		[Tooltip("Health points regenerated per second.")]
		private float healthRegenRate;

		[SerializeField]
		[Tooltip("Delay before health regeneration starts after taking damage (seconds).")]
		private float healthRegenDelay;

		[Header("Poise System (INPCProfile)")]
		[SerializeField]
		[Tooltip("Maximum poise - how much poise damage before stagger.")]
		private float maxPoise;

		[SerializeField]
		[Tooltip("Poise damage taken per hit.")]
		private float poiseDamagePerHit;

		[SerializeField]
		[Tooltip("Cooldown after being staggered (can't be staggered again for X seconds).")]
		private float staggerCooldown;

		[SerializeField]
		[Tooltip("Poise regeneration per second when not taking hits.")]
		private float poiseRegenRate;

		[SerializeField]
		[Tooltip("Delay before poise starts regenerating after last hit (seconds).")]
		private float poiseRegenDelay;

		[SerializeField]
		[Tooltip("Duration of stagger animation/freeze when poise breaks (seconds).")]
		private float staggerDuration;

		[Header("Hit Visual Feedback (INPCProfile)")]
		[SerializeField]
		[Tooltip("Enable white glow flash when hit.")]
		private bool enableHitFlash;

		[SerializeField]
		[Tooltip("Initial brightness of hit flash.")]
		private float hitFlashIntensity;

		[SerializeField]
		[Tooltip("How long the flash takes to fade out (seconds).")]
		private float hitFlashFadeOutDuration;

		[SerializeField]
		[Tooltip("Color of hit flash.")]
		private Color hitFlashColor;

		[SerializeField]
		[Tooltip("Radius/size of hit flash effect.")]
		private float hitFlashRadius;

		[Header("Drunk Parameters")]
		[SerializeField]
		[Tooltip("How much each drink increases intoxication (0-1).")]
		private float intoxicationPerDrink;

		[SerializeField]
		[Tooltip("Max intoxication before switching to drunk movement profile.")]
		private float drunkThreshold;

		[SerializeField]
		[Tooltip("Seconds to reduce intoxication by half once at home.")]
		private float sobrietyHalfLifeSeconds;

		[Header("Selection Weights")]
		[SerializeField]
		[Tooltip("Optional override weight when manager randomly selects this NPC.")]
		private float spawnWeight;

		[SerializeField]
		[Tooltip("Optional tag bias for choosing bars (comma separated, optional).")]
		private string preferredBarTags;

		[Header("Debug")]
		[SerializeField]
		private string notes;

		[Header("Schedule")]
		[SerializeField]
		[Tooltip("NPC role determining their daily schedule (StoreClerk or Townsfolk).")]
		private NPCRoles role;

		[SerializeField]
		[Tooltip("Optional schedule profile override. If null, will use Resources/NPC/Schedules/{Role}_Default.asset")]
		private NPCScheduleProfile scheduleProfile;

		[SerializeField]
		[Tooltip("Optional: Specific work location ID this NPC should be assigned to. Leave empty for auto-assignment.")]
		private string assignedWorkLocationId;

		[Header("Store Clerk Work Hours (Only used when Role = StoreClerk)")]
		[SerializeField]
		[Tooltip("Hour when this clerk starts work (0-23)")]
		[Range(0f, 23f)]
		private int workStartHour;

		[SerializeField]
		[Tooltip("Hour when this clerk ends work (0-23)")]
		[Range(0f, 23f)]
		private int workEndHour;

		[Header("Personality (Combat Brain)")]
		[SerializeField]
		[Tooltip("If true, use custom personality values below. If false, generate random personality from NetworkObjectId.")]
		private bool useCustomPersonality;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("Likelihood to fight when provoked (0=pacifist, 1=always fights)")]
		private float personalityAggression;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("Likelihood to stay and fight vs flee (0=coward, 1=never flees)")]
		private float personalityBravery;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("Drinks before becoming rowdy (0=lightweight, 1=high tolerance)")]
		private float personalityDrunkTolerance;

		[Header("Combat Rhythm")]
		[SerializeField]
		[Range(0.5f, 3f)]
		[Tooltip("Minimum time between attacks")]
		private float attackCooldownMin;

		[SerializeField]
		[Range(1f, 5f)]
		[Tooltip("Maximum time between attacks")]
		private float attackCooldownMax;

		[SerializeField]
		[Tooltip("If true, getting hit resets attack cooldown")]
		private bool resetCooldownOnHit;

		[SerializeField]
		[Range(1f, 10f)]
		[Tooltip("Hits taken before revenge attack (ignores cooldown reset)")]
		private int revengeHitThreshold;

		[SerializeField]
		[Range(0f, 3f)]
		[Tooltip("Extra cooldown after stagger recovery")]
		private float postStaggerCooldown;

		[Header("Haggle Personality")]
		[SerializeField]
		[Range(1f, 2f)]
		[Tooltip("Maximum price multiplier this NPC will pay (1.0=base price, 1.5=50% over base)")]
		private float haggleMaxPriceMultiplier;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("How patient the NPC is during haggling (affects willingness drop rate)")]
		private float hagglePatience;

		[SerializeField]
		[Range(1f, 5f)]
		[Tooltip("Maximum times this NPC will return after being refused")]
		private int haggleMaxAttempts;

		[SerializeField]
		[Range(0.02f, 0.15f)]
		[Tooltip("Bonus tolerance added each time NPC returns after refusal")]
		private float haggleReturnBonus;

		[Header("Combat Behavior")]
		[SerializeField]
		[Tooltip("Distance at which NPC will start attacking")]
		private float combatAttackRange;

		[SerializeField]
		[Tooltip("Maximum distance to chase target before giving up")]
		private float combatMaxDistance;

		[SerializeField]
		[Tooltip("Distance NPC retreats to after attacking")]
		private float combatRetreatDistance;

		[SerializeField]
		[Tooltip("Movement speed when approaching target")]
		private float combatApproachSpeed;

		[SerializeField]
		[Tooltip("Slower menacing walk speed for self-defense mode")]
		private float combatSelfDefenseApproachSpeed;

		[SerializeField]
		[Tooltip("Movement speed when retreating")]
		private float combatRetreatSpeed;

		[SerializeField]
		[Tooltip("Duration of retreat phase (seconds)")]
		private float combatRetreatDuration;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("Chance to retreat after each attack (0-1)")]
		private float combatRetreatChance;

		[SerializeField]
		[Tooltip("Seconds without valid target before auto-exiting combat")]
		private float combatIdleTimeout;

		[SerializeField]
		[Tooltip("Maximum seconds in combat before auto-exiting (0 = no limit)")]
		private float combatMaxDuration;

		public string NpcId => null;

		public string DisplayName => null;

		public NPCGender Gender => default(NPCGender);

		public Sprite Portrait => null;

		public FactionData Faction => null;

		public GameObject NpcPrefab => null;

		public bool IsLocalNPC => false;

		public NPCTravelMode TravelMode => default(NPCTravelMode);

		public float WalkSpeed => 0f;

		public float RunSpeed => 0f;

		public string VehicleAssignmentId => null;

		public Vector2Int DrinkPurchaseRange => default(Vector2Int);

		public Vector2 HangoutDurationRange => default(Vector2);

		public Vector2 HomeCooldownRange => default(Vector2);

		public bool CanVisitBar => false;

		public float IntoxicationPerDrink => 0f;

		public float DrunkThreshold => 0f;

		public float SobrietyHalfLifeSeconds => 0f;

		public float SpawnWeight => 0f;

		public string PreferredBarTags => null;

		public string Notes => null;

		public NPCRoles Role => default(NPCRoles);

		public NPCScheduleProfile ScheduleProfile => null;

		public string AssignedWorkLocationId => null;

		public int WorkStartHour => 0;

		public int WorkEndHour => 0;

		public bool UseCustomPersonality => false;

		public float PersonalityAggression => 0f;

		public float PersonalityBravery => 0f;

		public float PersonalityDrunkTolerance => 0f;

		public float HaggleMaxPriceMultiplier => 0f;

		public float HagglePatience => 0f;

		public int HaggleMaxAttempts => 0;

		public float HaggleReturnBonus => 0f;

		public float AttackCooldownMin => 0f;

		public float AttackCooldownMax => 0f;

		public bool ResetCooldownOnHit => false;

		public int RevengeHitThreshold => 0;

		public float PostStaggerCooldown => 0f;

		public float CombatAttackRange => 0f;

		public float CombatMaxDistance => 0f;

		public float CombatRetreatDistance => 0f;

		public float CombatApproachSpeed => 0f;

		public float CombatSelfDefenseApproachSpeed => 0f;

		public float CombatRetreatSpeed => 0f;

		public float CombatRetreatDuration => 0f;

		public float CombatRetreatChance => 0f;

		public float CombatIdleTimeout => 0f;

		public float CombatMaxDuration => 0f;

		public float BrawlStartChanceAfterDrink => 0f;

		public float BrawlJoinChance => 0f;

		public float BrawlAggroRadius => 0f;

		public float BrawlCallRadius => 0f;

		public float BrawlTargetPlayerChance => 0f;

		public float BrawlCooldownSeconds => 0f;

		public float BrawlFleeHealthThreshold => 0f;

		public float BrawlWatchOnlyChance => 0f;

		public bool BrawlNonCombatant => false;

		public int BrawlMaxConcurrentTargets => 0;

		public WeaponItem BrawlUnarmedWeaponOverride => null;

		public int BrawlMaxParticipantsOverride => 0;

		public float MaxHealth => 0f;

		public float HealthRegenRate => 0f;

		public float HealthRegenDelay => 0f;

		public float MaxPoise => 0f;

		public float PoiseDamagePerHit => 0f;

		public float StaggerCooldown => 0f;

		public float PoiseRegenRate => 0f;

		public float PoiseRegenDelay => 0f;

		public float StaggerDuration => 0f;

		public bool EnableHitFlash => false;

		public float HitFlashIntensity => 0f;

		public float HitFlashFadeOutDuration => 0f;

		public Color HitFlashColor => default(Color);

		public float HitFlashRadius => 0f;

		private void OnValidate()
		{
		}
	}
}
