using System;
using System.Runtime.CompilerServices;
using Brewery.CombatSystem;
using Brewery.Environment;
using Brewery.NPC;
using Brewery.NPC.Simple;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Thief
{
	[RequireComponent(typeof(AStarNPCMotor))]
	public abstract class ThiefBrainBase : NetworkBehaviour
	{
		protected const float ARRIVAL_DISTANCE = 2f;

		protected const MotorOwner THIEF_MOTOR_OWNER = MotorOwner.Thief;

		[Header("Debug")]
		[SerializeField]
		protected bool showDebugLogs;

		protected INPCMotor motor;

		protected NPCHealthController healthController;

		protected NetworkObject networkObject;

		protected NPCBrawlCombat combatExecutor;

		protected ThiefSpeechController speechController;

		protected ThiefCampManager campManager;

		protected ThiefCampConfig config;

		protected int currentState;

		protected float stateTimer;

		protected float stateEntryTime;

		protected Vector3 lastSetDestination;

		protected bool hasSetDestinationThisState;

		protected Transform combatTarget;

		protected float combatStartTime;

		protected bool combatExecutorActive;

		private Vector3 lastCombatPosition;

		private float lastCombatMoveTime;

		protected int combatStuckCount;

		private const float COMBAT_STUCK_CHECK_INTERVAL = 3f;

		private const float COMBAT_STUCK_DISTANCE = 0.5f;

		private const int MAX_COMBAT_STUCK_ATTEMPTS = 5;

		protected bool hasInitialized;

		private const float GATE_CHECK_INTERVAL = 0.15f;

		private const float GATE_DETECTION_RADIUS = 2f;

		private const float GATE_FORWARD_DOT_THRESHOLD = 0.5f;

		private float lastGateCheckTime;

		private static Collider[] gateCheckBuffer;

		public ThiefCampManager CampManager => null;

		public abstract bool IsDefeated { get; }

		public abstract int CurrentStateValue { get; }

		public event Action<int, int> OnStateChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnDefeated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public virtual void OnCampRelocated(Vector3 oldCampPos, Vector3 newCampPos)
		{
		}

		public virtual void Revive(Vector3 spawnPosition)
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		protected virtual void InitializeServer()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		public void InitializeWithCamp(ThiefCampManager manager, NPCCombatConfig combatConfigOverride = null)
		{
		}

		protected virtual void Update()
		{
		}

		protected abstract void TickCurrentState();

		protected void TransitionToState(int newState)
		{
		}

		protected abstract void EnterState(int state);

		protected abstract void ExitState(int state);

		protected abstract float GetStateTimer(int state);

		protected Vector3 GetCampPosition()
		{
			return default(Vector3);
		}

		protected bool HasArrivedAt(Vector3 position, float distance)
		{
			return false;
		}

		protected float Get2DDistance(Vector3 a, Vector3 b)
		{
			return 0f;
		}

		protected bool AcquireMotorAndMove(Vector3 destination, float speed)
		{
			return false;
		}

		protected void AcquireMotorAndStop()
		{
		}

		protected bool MoveToCamp(float speed)
		{
			return false;
		}

		protected void SetDestinationIfChanged(Vector3 destination, float speed)
		{
		}

		protected void StartCombatWithExecutor(Transform target)
		{
		}

		protected void StartCombatWithExecutorSprint(Transform target, float sprintSpeed)
		{
		}

		protected void StopCombatExecution()
		{
		}

		protected void TickCombatCommon()
		{
		}

		protected virtual void OnCombatTargetLost()
		{
		}

		protected virtual void OnCombatStuck()
		{
		}

		private void HandleDamageReceivedInternal(ulong attackerId, Vector3 attackerPosition, float damage)
		{
		}

		private Transform FindAttackerTransform(ulong attackerId)
		{
			return null;
		}

		protected virtual void HandleDamageReceived(float damage, ulong attackerId, Transform attacker)
		{
		}

		protected virtual void HandleDefeat()
		{
		}

		protected Transform FindNearestPlayer()
		{
			return null;
		}

		protected void CheckForNearbyGates()
		{
		}

		protected bool IsGateBlockingPath(SlidingFenceGate gate)
		{
			return false;
		}

		protected virtual bool ShouldCheckForGates()
		{
			return false;
		}

		protected virtual void OnClosedGateDetected(SlidingFenceGate gate)
		{
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
