using System;
using System.Collections;
using CTS.AI;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	internal class AgentActionElevator : AgentAction<Agent>
	{
		private readonly ElevatorPortal _elevatorPortal;

		private static readonly Func<AgentAction, bool> NotStartedActionFilter = (AgentAction action) => action.Status < EStatus.InProgress;

		private readonly LockToggle _elevatorLocker;

		private readonly Transform _updateTarget;

		private Coroutine _lookForTargetRoutine;

		private static readonly WaitForSeconds UpdateWait = new WaitForSeconds(0.2f);

		private const float DistanceToCallElevator = 9f;

		public int TargetFloor { get; }

		public int StartFloor { get; private set; }

		public bool ReadyToEnter { get; private set; }

		public bool CanEnterElevator { get; set; }

		public bool CanExitElevator { get; set; }

		public AgentActionElevator(ElevatorPortal p_elevatorPortal, int p_targetFloor, Transform target = null)
		{
			_updateTarget = target;
			_elevatorPortal = p_elevatorPortal;
			TargetFloor = p_targetFloor;
			_elevatorLocker = new LockToggle(_elevatorPortal.Line);
			base.Name = "Taking Elevator";
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			return true;
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			MoveTarget waitTarget = _elevatorPortal.ContextActorData.GetInteractionTarget(EInteractionKey.RegularUsage, base.ActionAgent.transform.position);
			StartFloor = FloorsManager.GetNearestFloorIndex(waitTarget.Position.y);
			if ((bool)_updateTarget)
			{
				_lookForTargetRoutine = base.ActionAgent.StartCoroutine(LookForTarget());
			}
			bool hasCalled = false;
			PathingTracker moveTo = MoveToTarget(waitTarget);
			yield return null;
			while (!moveTo.IsCompleted)
			{
				if (hasCalled)
				{
					yield return null;
					continue;
				}
				if ((waitTarget.Position - base.ActionAgent.transform.position).sqrMagnitude < 9f)
				{
					hasCalled = true;
					_elevatorPortal.Line.AddRequest(TargetFloor, StartFloor, this);
					TryAddElevatorActionToControlled();
				}
				yield return null;
			}
			ReadyToEnter = true;
			float nextCheck = Time.time + 1f;
			while (!CanEnterElevator)
			{
				if (Time.time > nextCheck)
				{
					_elevatorPortal.Line.AddRequest(TargetFloor, StartFloor, this);
					nextCheck = Time.time + 1f;
				}
				yield return null;
			}
			_elevatorLocker.Lock();
			yield return MoveToTarget(_elevatorPortal.ContextActorData.GetInteractionTarget(EInteractionKey.PickUp, base.ActionAgent.transform.position));
			_elevatorLocker.Unlock();
		}

		private IEnumerator LookForTarget()
		{
			while (base.Status < EStatus.InProgress)
			{
				if (FloorsManager.GetNearestFloorIndex(_updateTarget.position.y) != TargetFloor)
				{
					CancelAction("");
					_lookForTargetRoutine = null;
					yield break;
				}
				yield return UpdateWait;
			}
			_lookForTargetRoutine = null;
		}

		private void TryAddElevatorActionToControlled()
		{
			if (base.ActionAgent is Worker worker && !worker.ControlledHuman.ActionPlayer.HasAnyActionOfType(typeof(AgentActionElevator), NotStartedActionFilter))
			{
				AgentActionElevator agentActionElevator = new AgentActionElevator(_elevatorPortal, TargetFloor);
				AgentAction.LinkCancellationOneSide(this, agentActionElevator);
				worker.ControlledHuman.ActionPlayer.ForceAction(agentActionElevator, (Priority == EActionPriority.Forced) ? EActionPriority.Forced : EActionPriority.Player);
			}
		}

		public override IEnumerator ActionRoutine()
		{
			_elevatorPortal.Line.AddOccupant(this, TargetFloor);
			base.ActionAgent.SetVisualActive(value: false);
			while (!CanExitElevator)
			{
				yield return null;
			}
			ElevatorPortal currentPortal = _elevatorPortal.Line.CurrentPortal;
			base.ActionAgent.transform.SetPositionAndRotation(currentPortal.ContextActorData.GetInteractionTarget(EInteractionKey.PickUp, base.ActionAgent.transform.position).Position, currentPortal.transform.rotation);
			base.ActionAgent.SetVisualActive(value: true);
			MoveTarget interactionTarget = currentPortal.ContextActorData.GetInteractionTarget(EInteractionKey.BackUsage, base.ActionAgent.transform.position);
			yield return MoveToTarget(interactionTarget, (int?)(-1));
			if (base.ActionAgent is Customer customer && (bool)customer.ControllingVampire && customer.ControllingVampire.ActionPlayer.TryGetActionOfType<AgentActionElevator>(out var elevatorAction))
			{
				while (!elevatorAction.Stopped)
				{
					yield return null;
				}
			}
		}

		protected override void OnStopped()
		{
			if (_lookForTargetRoutine != null)
			{
				base.ActionAgent.StopCoroutine(_lookForTargetRoutine);
				_lookForTargetRoutine = null;
			}
			_elevatorLocker.Unlock();
			_elevatorPortal.Line.ClearRequest(this);
		}

		public override void OnCancel()
		{
		}
	}
}
