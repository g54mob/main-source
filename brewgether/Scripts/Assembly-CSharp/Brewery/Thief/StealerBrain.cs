using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Environment;
using InventorySystem;
using UnityEngine;

namespace Brewery.Thief
{
	public class StealerBrain : ThiefBrainBase
	{
		[CompilerGenerated]
		private sealed class _003CDelayedInitialization_003Ed__73 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public StealerBrain _003C_003E4__this;

			private Vector3 _003CcorrectSpawnPos_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDelayedInitialization_003Ed__73(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private const float STEAL_ARRIVAL_BUFFER = 0.5f;

		private const float DEFAULT_COMBAT_FLEE_TIME = 5f;

		private const float DETECTION_CHECK_INTERVAL = 0.25f;

		private const float DETECTION_RATE_PER_SECOND = 0.2f;

		private const float DETECTION_DECAY_RATE = 0.15f;

		private const float FLEE_DETECTION_THRESHOLD = 0.8f;

		private const float MOVEMENT_PROGRESS_THRESHOLD = 2f;

		private const float MOVEMENT_STUCK_TIMEOUT = 15f;

		private TheftTarget target;

		private int targetSlotIndex;

		private Vector3 targetPosition;

		private float detectionMeter;

		private Transform detectedByPlayer;

		private float lastDetectionCheckTime;

		private Vector3 lastProgressPosition;

		private float lastProgressTime;

		private bool hasLoggedPathfindingFailure;

		private int consecutivePathFailures;

		private const int MAX_PATH_FAILURES_BEFORE_ABORT = 3;

		private bool hasLoggedFirstScoutingTick;

		private readonly List<StolenItemData> carriedLoot;

		private int itemsStolenThisTrip;

		private bool hasStealSlot;

		private ThiefCarryingController carryingController;

		private SlidingFenceGate currentGate;

		private SlidingFenceGate recentlyBrokenGate;

		private StealerState stateBeforeGate;

		private bool isPassive;

		private bool isPanickingRequested;

		private Vector3 panicTarget;

		private float panicMoveTimer;

		private const float PANIC_MOVE_INTERVAL_MIN = 2f;

		private const float PANIC_MOVE_INTERVAL_MAX = 5f;

		private const float PANIC_RUN_RADIUS = 10f;

		private const float LURK_PLAYER_DISTANCE = 20f;

		private const float MAX_LURK_TIME = 45f;

		private const float LURK_RECHECK_INTERVAL = 3f;

		private Vector3 lurkPosition;

		private float lurkStartTime;

		private float lurkRecheckTimer;

		private bool isDefendingCamp;

		private readonly Dictionary<ulong, float> unreachableTargets;

		private const float UNREACHABLE_BLACKLIST_DURATION = 120f;

		public override bool IsDefeated => false;

		public override int CurrentStateValue => 0;

		public StealerState CurrentState => default(StealerState);

		public float DetectionLevel => 0f;

		public bool IsCarryingLoot => false;

		public int CarriedItemCount => 0;

		public bool IsStealing => false;

		public bool IsPassive => false;

		public bool IsPanicking => false;

		public event Action<float> OnDetectionChanged
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

		public event Action<string, int> OnItemStolen
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

		public event Action OnLootCleared
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

		public override void OnCampRelocated(Vector3 oldCampPos, Vector3 newCampPos)
		{
		}

		public override void Revive(Vector3 spawnPosition)
		{
		}

		protected override void InitializeServer()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedInitialization_003Ed__73))]
		private IEnumerator DelayedInitialization()
		{
			return null;
		}

		protected override void Update()
		{
		}

		protected override void TickCurrentState()
		{
		}

		protected override void EnterState(int state)
		{
		}

		protected override void ExitState(int state)
		{
		}

		protected override float GetStateTimer(int state)
		{
			return 0f;
		}

		private bool IsOpportunityAvailable()
		{
			return false;
		}

		private void LogOpportunityBlock()
		{
		}

		private float GetRetryDelay()
		{
			return 0f;
		}

		private void TickIdle()
		{
		}

		private void TickScouting()
		{
		}

		private void TickInfiltrating()
		{
		}

		private void TickStealing()
		{
		}

		private void TickEscaping()
		{
		}

		private void TickStashing()
		{
		}

		private void TickFleeing()
		{
		}

		private void TickPanicking()
		{
		}

		private void TickLurking()
		{
		}

		private void PickLurkPosition()
		{
		}

		private void TickCombat()
		{
		}

		private void TickWaitingAtGate()
		{
		}

		protected override bool ShouldCheckForGates()
		{
			return false;
		}

		protected override void OnClosedGateDetected(SlidingFenceGate gate)
		{
		}

		public void WaitAtGate(SlidingFenceGate gate)
		{
		}

		public void OnGateOpened()
		{
		}

		public void OnBreakInDenied(SlidingFenceGate gate)
		{
		}

		protected override void OnCombatTargetLost()
		{
		}

		protected override void OnCombatStuck()
		{
		}

		private void UpdateDetection()
		{
		}

		private void OnFullyDetected()
		{
		}

		private void FindTargetAndMove()
		{
		}

		private Vector3 FindStealPositionWithLOS(Vector3 shelfPos, float offset, Transform targetTransform = null)
		{
			return default(Vector3);
		}

		private bool FindBestSlotToSteal()
		{
			return false;
		}

		private void StartStealChannel()
		{
		}

		private void CompleteSteal()
		{
		}

		private void DropCarriedItems()
		{
		}

		private void SpawnDroppedItem(StolenItemData loot, int dropIndex)
		{
		}

		private void TransferMetadataToDroppedItem(GameObject droppedItem, Item item, StolenItemData loot)
		{
		}

		private void DepositLootAtCamp()
		{
		}

		private void ReleaseStealSlot()
		{
		}

		public void AssignStealSlot()
		{
		}

		public void ForceReturnToCamp()
		{
		}

		public void SetPassiveMode(bool passive)
		{
		}

		public void SetPanicking(bool panicking)
		{
		}

		protected override void HandleDamageReceived(float damage, ulong attackerId, Transform attacker)
		{
		}

		public bool TryStartCampDefense(Transform intruder)
		{
			return false;
		}

		private bool IsSoloState()
		{
			return false;
		}

		protected override void HandleDefeat()
		{
		}

		private void HandleDefeatInternal()
		{
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

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
