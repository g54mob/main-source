using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Environment;
using UnityEngine;

namespace Brewery.Thief
{
	public class DefenderBrain : ThiefBrainBase
	{
		[CompilerGenerated]
		private sealed class _003CDelayedInitialization_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DefenderBrain _003C_003E4__this;

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
			public _003CDelayedInitialization_003Ed__28(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CGateBreakInCoroutine_003Ed__59 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SlidingFenceGate gate;

			public DefenderBrain _003C_003E4__this;

			private float _003Ctimer_003E5__2;

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
			public _003CGateBreakInCoroutine_003Ed__59(int _003C_003E1__state)
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

		private bool hasReachedTargetForRevenge;

		private bool isPanickingRequested;

		private Vector3 panicTarget;

		private float panicMoveTimer;

		private const float PANIC_RADIUS = 12f;

		private const float PANIC_MOVE_TIME_MIN = 1f;

		private const float PANIC_MOVE_TIME_MAX = 3f;

		private const float PANIC_PLAYER_DETECT_RANGE = 15f;

		private Vector3 currentPatrolTarget;

		private bool hasPatrolTarget;

		private float patrolWaitTimer;

		private const float PATROL_RADIUS = 12f;

		private const float PATROL_WAIT_MIN = 1.5f;

		private const float PATROL_WAIT_MAX = 4f;

		private const float PATROL_ARRIVAL_DIST = 1.5f;

		private float patrolTargetSetTime;

		private const float PATROL_STUCK_TIMEOUT = 10f;

		private SlidingFenceGate pendingGateBreakIn;

		private Coroutine gateBreakInCoroutine;

		private const float DEFENDER_GATE_BREAK_IN_DELAY = 3f;

		public override bool IsDefeated => false;

		public override int CurrentStateValue => 0;

		public DefenderState CurrentState => default(DefenderState);

		public bool IsAvailable => false;

		public bool IsPanicking => false;

		protected override void InitializeServer()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedInitialization_003Ed__28))]
		private IEnumerator DelayedInitialization()
		{
			return null;
		}

		public void EngageCombatTarget(Transform target)
		{
		}

		public bool TryStartCampDefense(Transform intruder)
		{
			return false;
		}

		public void StartCampDefense(Transform intruder)
		{
		}

		public void SetPanicking(bool panicking)
		{
		}

		public override void OnCampRelocated(Vector3 oldCampPos, Vector3 newCampPos)
		{
		}

		public override void Revive(Vector3 spawnPosition)
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

		private void TickIdle()
		{
		}

		private void TickPatrol(Vector3 campPos)
		{
		}

		private void PickNewPatrolPoint(Vector3 campPos)
		{
		}

		private void TickRevengeAttack()
		{
		}

		private void TickCampDefense()
		{
		}

		private void TickCombat()
		{
		}

		private void TickReturning()
		{
		}

		private void TickPanicking()
		{
		}

		private void PickNewPanicPoint(Vector3 campPos)
		{
		}

		protected override void OnCombatTargetLost()
		{
		}

		protected override void OnCombatStuck()
		{
		}

		private void NotifyRevengeComplete()
		{
		}

		protected override void HandleDamageReceived(float damage, ulong attackerId, Transform attacker)
		{
		}

		protected override void HandleDefeat()
		{
		}

		private void HandleDefeatInternal()
		{
		}

		protected override bool ShouldCheckForGates()
		{
			return false;
		}

		protected override void OnClosedGateDetected(SlidingFenceGate gate)
		{
		}

		[IteratorStateMachine(typeof(_003CGateBreakInCoroutine_003Ed__59))]
		private IEnumerator GateBreakInCoroutine(SlidingFenceGate gate)
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

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
