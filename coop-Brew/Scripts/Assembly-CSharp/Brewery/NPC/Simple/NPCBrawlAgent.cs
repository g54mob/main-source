using Brewery.Bar.Brawl;
using Brewery.CombatSystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.NPC.Simple
{
	public class NPCBrawlAgent : NetworkBehaviour
	{
		public enum BrawlState : byte
		{
			Idle = 0,
			Candidate = 1,
			Aggressor = 2,
			Defender = 3,
			Spectator = 4,
			Fleeing = 5,
			Exempt = 6
		}

		[Header("Config")]
		[SerializeField]
		private WeaponItem unarmedWeapon;

		[SerializeField]
		private bool showDebugLogs;

		[Header("Self-Defense")]
		[Tooltip("Time in seconds before NPC gives up self-defense if not hit again")]
		[SerializeField]
		private float selfDefenseTimeout;

		private NPCBrawlCombat brawlCombat;

		private NetworkVariable<byte> networkBrawlState;

		private NetworkVariable<bool> networkIsFleeing;

		private SimpleNPCController npcController;

		private SimpleNPCLifeBrain lifeBrain;

		private NPCHealthController healthController;

		private NPCRagdollController ragdollController;

		private NPCDrinkingBehavior drinkingBehavior;

		private INPCMotor motor;

		private Animator animator;

		private INPCProfile profile;

		private BarBrawlManager currentBrawlManager;

		private Transform currentTargetTransform;

		private NPCBrawlAgent currentTargetBrawlAgent;

		private bool isInSelfDefenseMode;

		private float selfDefenseLastDamageTime;

		private float personalCooldownEndTime;

		private float nextSpectatorJoinCheck;

		private float fleeStartTime;

		private const float FleeTimeout = 10f;

		private float nextSpectatorDetectionCheck;

		private const float SpectatorDetectionInterval = 1.5f;

		private const float SpectatorDetectionRange = 12f;

		private Vector3 watchingBrawlPosition;

		private bool isWatchingBrawl;

		public BrawlState CurrentState => default(BrawlState);

		public bool IsFleeing => false;

		public bool IsInBrawl => false;

		public bool IsBrawling => false;

		public bool IsInSelfDefense => false;

		public INPCProfile Profile => null;

		public Transform CurrentTargetTransform => null;

		public NPCBrawlAgent CurrentTargetBrawlAgent => null;

		public bool IsInCombatMode => false;

		public bool IsNewBrainActive => false;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		public void OnSwingSound()
		{
		}

		private void Update()
		{
		}

		private void SubscribeToEvents()
		{
		}

		private void UnsubscribeFromEvents()
		{
		}

		internal void SetDrinkingBehavior(NPCDrinkingBehavior behavior)
		{
		}

		private void HandleDrinkFinished()
		{
		}

		internal void HandleDrinkFinishedFromBrain(SimpleBarLocation currentBar)
		{
		}

		private void TryStartBrawlFromDrink(SimpleBarLocation currentBar)
		{
		}

		private void HandleDamagedByAttacker(ulong attackerNetworkId, Vector3 position, float damage)
		{
		}

		private void HandleKnockedOut()
		{
		}

		private void HandleRagdollRecovered()
		{
		}

		private void UpdateBrawlStateMachine()
		{
		}

		private void UpdateCandidateState()
		{
		}

		private void UpdateCombatState()
		{
		}

		private void StopCombatAI()
		{
		}

		private void UpdateSpectatorState()
		{
		}

		private void UpdateFleeingState()
		{
		}

		private void SetState(BrawlState newState)
		{
		}

		public void ForceExitCombat()
		{
		}

		public void EnterAggressor()
		{
		}

		public void EnterDefender()
		{
		}

		private void EnterSelfDefenseMode()
		{
		}

		private void ExitSelfDefenseMode()
		{
		}

		public void EnterSpectator()
		{
		}

		private void ExitSpectatorState()
		{
		}

		private void EnterFleeingState()
		{
		}

		private void Say(string trigger)
		{
		}

		private void EnsureMotorReady()
		{
		}

		private void DropDrinkIfHolding()
		{
		}

		private bool IsNearBar()
		{
			return false;
		}

		public bool IsAtBarLocation(SimpleBarLocation bar)
		{
			return false;
		}

		private void CheckForNearbyBrawls()
		{
		}

		private void ReactToNearbyBrawl(Vector3 brawlPosition, float distance)
		{
		}

		private void TryJoinNearbyBrawl()
		{
		}

		private void FacePosition(Vector3 position)
		{
		}

		private void SetTarget(Transform targetTransform, NPCBrawlAgent targetBrawlAgent = null)
		{
		}

		private void ClearTarget()
		{
		}

		private bool IsTargetValid()
		{
			return false;
		}

		private Transform FindTransformByNetworkId(ulong networkObjectId)
		{
			return null;
		}

		private void FindBarBrawlManager()
		{
		}

		private void ReleaseBarSpotIfSeated()
		{
		}

		private void UnregisterFromBarServing()
		{
		}

		private void PrepareForCombat()
		{
		}

		private NPCBrawlAgent FindBrawlAgentByNetworkId(ulong networkId)
		{
			return null;
		}

		private void OnBrawlStateChanged(byte previousValue, byte newValue)
		{
		}

		public void SetCurrentTarget(NPCBrawlAgent target)
		{
		}

		public void SetCurrentTarget(Transform target)
		{
		}

		public void SetBrawlManager(BarBrawlManager manager)
		{
		}

		public bool CanBeTargeted()
		{
			return false;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
