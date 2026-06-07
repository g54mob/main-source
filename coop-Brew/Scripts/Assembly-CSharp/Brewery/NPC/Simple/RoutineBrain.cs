using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Brewery.Stand;
using UnityEngine;

namespace Brewery.NPC.Simple
{
	internal class RoutineBrain
	{
		private readonly NPCContext ctx;

		private readonly INPCMotor motor;

		private readonly BarInteractor barInteractor;

		private readonly StandInteractor standInteractor;

		private readonly SimpleNPCController controller;

		private RoutineState currentState;

		private float stateTimer;

		private float walkStartTime;

		private float walkTimeout;

		private float pathPendingStartTime;

		private float barSpotInitialDistance;

		private float barSpotMinDistance;

		private float barVisitStartTime;

		private int barSpotRetryCount;

		private const int MaxBarSpotRetries = 3;

		private const float BarServiceArrivalDistance = 1.75f;

		private bool isRecoveringPath;

		private Vector3 recoveryTarget;

		private float recoveryStartTime;

		private int barServiceRecoveryAttempts;

		private int barSpotRecoveryAttempts;

		private float lastRecoveryAttemptTime;

		private const float RecoveryArrivalDistance = 1.2f;

		private const float RecoveryTimeout = 6f;

		private const float RecoveryCooldown = 2f;

		private const int MaxRecoveryAttempts = 5;

		private bool enablePending;

		private float nextEnableRetryTime;

		private int enableRetryCount;

		private const float EnableRetryInterval = 0.5f;

		private const int MaxEnableRetries = 10;

		private const float MaxPathPendingTime = 12f;

		private bool isFirstNavigationCycle;

		private const float MinInitialNavDelay = 0.1f;

		private const float MaxInitialNavDelay = 0.5f;

		private SimpleBarLocation targetBar;

		private StandLocation targetStand;

		private Vector3 _standIdlePos;

		private bool _arrivedAtStand;

		private bool _notifiedPoolOnArrival;

		private Vector3 _standWanderCenter;

		private float _nextStandWanderTime;

		private float _leaveStandStartTime;

		private string _standLeaveReason;

		private Vector3 closedBarLookAtTarget;

		private const float ClosedBarApproachDistance = 10f;

		private const float ClosedBarLookDuration = 2f;

		private float nextComplaintCheckTime;

		private const float ComplaintCheckInterval = 5f;

		private const float ComplaintChance = 0.3f;

		private const float NewViolationComplaintChance = 0.85f;

		private HashSet<string> _previouslySatisfiedRules;

		private float StandDrinkDuration => 0f;

		private float StandWanderRadius => 0f;

		private float StandWanderInterval => 0f;

		private float LeaveStandTimeout => 0f;

		private string AiId => null;

		private string Pos => null;

		private float minHomeTime => 0f;

		private float maxHomeTime => 0f;

		private float minHotspotTime => 0f;

		private float maxHotspotTime => 0f;

		private float maxBarSpotWaitTime => 0f;

		private float wanderInterval => 0f;

		public RoutineState CurrentState => default(RoutineState);

		public bool IsActive => false;

		public event Action OnRoutineFailed
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

		private string FormatPos(Vector3 p)
		{
			return null;
		}

		public RoutineBrain(NPCContext context, INPCMotor agentMotor, BarInteractor bar, StandInteractor stand = null)
		{
		}

		private void OnDrunkExpired()
		{
		}

		private void Say(string trigger)
		{
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		public void ForceGoHome(bool run = false)
		{
		}

		public void ForceGoToBar()
		{
		}

		public void Tick()
		{
		}

		private void TickHomeIdle()
		{
		}

		private void TickWalkToHotspot()
		{
		}

		private void TickHotspotIdle()
		{
		}

		private void TickWalkToBar()
		{
		}

		private void TickAcquireBarSpot()
		{
		}

		private void TickWalkToBarSpot()
		{
		}

		private void TickAtBar()
		{
		}

		private void TickWalkHome()
		{
		}

		private void TransitionToWalkToHotspot()
		{
		}

		private void ArriveAtHotspot()
		{
		}

		private void TransitionToWalkToBar()
		{
		}

		private void TransitionToWalkToClosedBar(Vector3 barServiceLocation)
		{
		}

		private void TickWalkToClosedBar()
		{
		}

		private void TransitionToLookingAtClosedBar()
		{
		}

		private void TickLookingAtClosedBar()
		{
		}

		private void TransitionToAcquireBarSpot()
		{
		}

		private void TransitionToWalkToBarSpot()
		{
		}

		private void ArriveAtBarSpot()
		{
		}

		private void LeaveBar(string reason)
		{
		}

		private void TransitionToWalkHome(string reason = "")
		{
		}

		private void ArriveAtHome()
		{
		}

		private void ApplyWalkSpeed()
		{
		}

		private void ApplyRunSpeed()
		{
		}

		private void WarpHome()
		{
		}

		private bool IsNearPosition(Vector3 position, float radius)
		{
			return false;
		}

		private bool IsBarVisitTimedOut()
		{
			return false;
		}

		private float GetBarPresenceMaxDistance()
		{
			return 0f;
		}

		private bool TickRecovery(Vector3 target, bool sameFloor, ref int attempts)
		{
			return false;
		}

		private bool StartPathRecovery(Vector3 target, bool sameFloor, ref int attempts, string reason)
		{
			return false;
		}

		private bool TryFindRecoveryPoint(Vector3 target, bool sameFloor, out Vector3 recoveryPoint)
		{
			recoveryPoint = default(Vector3);
			return false;
		}

		private void ReissueDestination(Vector3 target, bool sameFloor, string reason)
		{
		}

		private void ResetBarVisitTracking()
		{
		}

		private void RepathToBarServiceLocation(string reason)
		{
		}

		private void HandleBarSpotNavigationFailure(string reason)
		{
		}

		private bool SetDestination(Vector3 destination)
		{
			return false;
		}

		private void StopMovement()
		{
		}

		private bool HasArrived(float customDistance = -1f)
		{
			return false;
		}

		private float CalculateWalkTimeout(Vector3 destination)
		{
			return 0f;
		}

		private bool TryVisitStand()
		{
			return false;
		}

		private StandLocation SelectStand()
		{
			return null;
		}

		private void TransitionToWalkToStand()
		{
		}

		private void TickWalkToStand()
		{
		}

		private void ArriveAtStand()
		{
		}

		private void TickAtStand()
		{
		}

		private void TickLeaveStand()
		{
		}

		private void LeaveStandState(string reason)
		{
		}

		private SimpleBarLocation SelectBar()
		{
			return null;
		}

		private void CheckAndComplainAboutRules()
		{
		}
	}
}
