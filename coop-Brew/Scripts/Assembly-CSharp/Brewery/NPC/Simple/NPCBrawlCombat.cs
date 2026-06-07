using Brewery.CombatSystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.NPC.Simple
{
	public class NPCBrawlCombat : NetworkBehaviour
	{
		public enum CombatPhase
		{
			Idle = 0,
			Approach = 1,
			Attack = 2,
			Retreat = 3
		}

		[Header("Combat Configuration (Single Source of Truth)")]
		[Tooltip("ScriptableObject containing all combat settings. If set, overrides all other config.")]
		[SerializeField]
		private NPCCombatConfig combatConfig;

		[Header("Legacy Combat Configuration (used if no NPCCombatConfig)")]
		[Tooltip("Distance at which NPC will start attacking (auto-synced from hit detection range)")]
		[SerializeField]
		private float attackRange;

		[Tooltip("Buffer to ensure NPC stops INSIDE hit detection range, not at edge")]
		[SerializeField]
		private float attackRangeBuffer;

		[Tooltip("Maximum distance to chase target before giving up")]
		[SerializeField]
		private float maxCombatDistance;

		[Tooltip("Distance NPC retreats to after attacking")]
		[SerializeField]
		private float retreatDistance;

		[Tooltip("Movement speed when approaching target")]
		[SerializeField]
		private float approachSpeed;

		[Tooltip("Slower menacing walk speed for self-defense mode")]
		[SerializeField]
		private float selfDefenseApproachSpeed;

		[Tooltip("Movement speed when retreating")]
		[SerializeField]
		private float retreatSpeed;

		[Tooltip("Time between attacks (seconds)")]
		[SerializeField]
		private float attackCooldown;

		[Tooltip("Duration of retreat phase (seconds)")]
		[SerializeField]
		private float retreatDuration;

		[Tooltip("Chance to retreat after each attack (0-1)")]
		[Range(0f, 1f)]
		[SerializeField]
		private float retreatChance;

		[Header("Unarmed Combat")]
		[Tooltip("Weapon item for unarmed attacks (damage/stamina values)")]
		[SerializeField]
		private WeaponItem unarmedWeapon;

		[Header("Distance-Based Combat")]
		[Tooltip("Distance-based hit detection component (replaces collider-based detection)")]
		[SerializeField]
		private DistanceBasedCombat distanceCombat;

		[Tooltip("Animator attack indices for left hand punches")]
		[SerializeField]
		private int[] leftHandAttackIndices;

		[Tooltip("Animator attack indices for right hand punches")]
		[SerializeField]
		private int[] rightHandAttackIndices;

		[Header("Debug")]
		private static readonly int IsUnarmedAttackingHash;

		private static readonly int UnarmedAttackIndexHash;

		private static readonly int InCombatHash;

		private INPCMotor motor;

		private Animator animator;

		private NPCBrawlAgent brawlAgent;

		private SimpleNPCAnimator npcAnimator;

		private CombatBrain combatBrain;

		private CombatPhase currentPhase;

		private Transform currentTarget;

		private float lastAttackTime;

		private float retreatStartTime;

		private bool useLeftHand;

		private bool isInSelfDefenseMode;

		private bool isExternallyManaged;

		private int lastLeftAttackIndex;

		private int lastRightAttackIndex;

		private int attacksInCurrentPhase;

		private const int MaxAttacksBeforeReposition = 4;

		private Vector3 lastTargetPosition;

		private float lastPathUpdateTime;

		private const float PATH_UPDATE_INTERVAL = 0.2f;

		private const float PATH_UPDATE_DISTANCE = 1f;

		private float lastRetargetCheckTime;

		private INPCProfile _npcProfile;

		private bool _profileCached;

		private int hitsTakenWithoutAttacking;

		private bool isInRevengeMode;

		private float currentAttackCooldown;

		[Header("Timeout")]
		[Tooltip("Seconds without valid target before auto-exiting combat")]
		[SerializeField]
		private float combatIdleTimeout;

		[Tooltip("Maximum seconds in combat before auto-exiting (0 = no limit)")]
		[SerializeField]
		private float maxCombatDuration;

		private float lastValidTargetTime;

		private float combatStartTime;

		private string _aiId;

		private INPCProfile npcProfile => null;

		private string AiId => null;

		public CombatPhase CurrentPhase => default(CombatPhase);

		public bool IsInCombat => false;

		public Transform CurrentTarget => null;

		public NPCCombatConfig CombatConfig => null;

		private void ApplyProfileOverrides()
		{
		}

		private void ApplyFromCombatConfig(NPCCombatConfig config)
		{
		}

		internal void SetCombatBrain(CombatBrain brain)
		{
		}

		public void SetCombatConfig(NPCCombatConfig config)
		{
		}

		public void SetExternallyManaged(bool managed)
		{
		}

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void Update()
		{
		}

		private void OnDisable()
		{
		}

		private void ForceCleanupCombatState()
		{
		}

		public void StartCombat(Transform target)
		{
		}

		public void UpdateCombat(Transform target)
		{
		}

		public void StopCombat()
		{
		}

		public void SetSelfDefenseMode(bool selfDefense)
		{
		}

		public void SetApproachSpeed(float speed)
		{
		}

		public void InterruptAttack()
		{
		}

		public void OnHitReceived()
		{
		}

		public void OnStaggerRecovered()
		{
		}

		public void ForceResumeChasing()
		{
		}

		private void UpdateApproach(float distance)
		{
		}

		private void UpdateAttack(float distance)
		{
		}

		private void UpdateRetreat(float distance)
		{
		}

		private void ExitRetreatPhase()
		{
		}

		private void EnterAttackPhase()
		{
		}

		private void EnterRetreatPhase()
		{
		}

		private void TriggerAttack()
		{
		}

		private int GetNextAttackIndex()
		{
			return 0;
		}

		public void OnAttackStart()
		{
		}

		public void OnSwingSound()
		{
		}

		[ClientRpc]
		private void PlaySwingSoundClientRpc(Vector3 position)
		{
		}

		[ClientRpc]
		private void PlayHitSoundClientRpc(Vector3 position)
		{
		}

		public void OnCanChangeHand()
		{
		}

		public void OnHit()
		{
		}

		public void OnAttackEnd()
		{
		}

		public void OnDrinkStart()
		{
		}

		public void OnDrinkFinished()
		{
		}

		private void EndAttackWindow()
		{
		}

		private void FaceTarget()
		{
		}

		private bool IsTargetIncapacitated()
		{
			return false;
		}

		private Transform CheckForCloserTarget()
		{
			return null;
		}

		private void OnDrawGizmosSelected()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1242533943(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3316134175(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
