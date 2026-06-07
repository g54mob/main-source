using System.Collections.Generic;
using CTS.AI;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public class AgentPathing : PathingTracker
	{
		private static readonly Stack<AgentPathing> _pool = new Stack<AgentPathing>();

		private AgentPath.EDestinationType _destinationType;

		private PooledRef<Agent> _targetAgent;

		private MoveTarget _preciseTarget;

		private MoveTarget _lookAtTarget;

		private AgentAction _syncedAction;

		private float _waitDistance;

		private float _failTime;

		private AgentPathing()
		{
		}

		internal static AgentPathing Start(AgentAction action, Agent targetAgent, float waitDistance, NavMeshQueryFilter? filter, AgentAction syncedAction = null, float pathUpdate = 0.5f)
		{
			AgentPathing obj = ((_pool.Count > 0) ? _pool.Pop() : new AgentPathing());
			obj._syncedAction = syncedAction;
			obj._targetAgent = new PooledRef<Agent>(targetAgent);
			obj._waitDistance = waitDistance;
			obj.PathUpdate = pathUpdate;
			obj.filter = filter;
			obj.Start(action);
			return obj;
		}

		protected override void OnStart()
		{
			Vector3 position = base.ActionAgent.transform.position;
			_targetAgent.Value.ContextActorData.TryGetInteractionTarget(EInteractionKey.RegularUsage, position, out _preciseTarget);
			_targetAgent.Value.ContextActorData.TryGetInteractionTarget(EInteractionKey.PickUp, position, out _lookAtTarget);
			if (!_preciseTarget || !_lookAtTarget)
			{
				base.Status = EStatus.Failed;
			}
			_failTime = Time.time + 8f;
		}

		protected override float GetTeleportDistance()
		{
			return _waitDistance;
		}

		protected override void OnStopped()
		{
		}

		protected override void OnCompleted()
		{
			base.ActionAgent.Movement.Velocity = Vector3.zero;
			base.ActionAgent.transform.SetPositionAndRotation(_preciseTarget.Position, _preciseTarget.Rotation);
		}

		public override bool IsAtDestination(Transform actionPlayerTransform)
		{
			if (Vector3.Distance(actionPlayerTransform.position, _preciseTarget.Position) < 0.1f && Vector3.Angle(actionPlayerTransform.forward, _preciseTarget.transform.forward) < 5f)
			{
				return true;
			}
			return false;
		}

		protected override void SpreadUpdate()
		{
			Transform transform = base.ActionAgent.transform;
			if (ShouldAvoidRetargeting(transform.position))
			{
				return;
			}
			if (Time.time >= _failTime)
			{
				base.Status = EStatus.Failed;
				return;
			}
			Agent value = _targetAgent.Value;
			bool flag = CanReachTarget(base.ActionAgent, _targetAgent);
			AgentPath outPath;
			if (!flag || !CanMove(value))
			{
				if (!flag)
				{
					OnTargetUnavailable(base.ActionAgent, value);
				}
				Vector3 direction = value.transform.position - transform.position;
				if (!AgentMovement.IsTransformAtDestinationLookAt(transform, direction, _waitDistance, 0.5f))
				{
					base.ActionAgent.Movement.SetDestinationLookAt(value.transform, _waitDistance, out outPath, 0.5f, base.filter);
					if (outPath != null)
					{
						base.CurrentPath = outPath;
					}
				}
			}
			else
			{
				_failTime = Time.time + 8f;
				base.ActionAgent.Movement.SetDestination(_preciseTarget, out outPath, base.filter);
				if (outPath != null)
				{
					base.CurrentPath = outPath;
				}
			}
		}

		protected virtual bool CanMove(Agent target)
		{
			if (target.ActionPlayer.HasAnyActionOfType<AgentActionSitUp>())
			{
				return false;
			}
			if (target.ActionPlayer.HasAnyActionOfType<AgentActionPrepareForSyncedAction>())
			{
				return false;
			}
			return true;
		}

		protected virtual bool CanReachTarget(Agent actionPlayer, Agent target)
		{
			if ((bool)target.FurnitureAssignment.CurrentSeat)
			{
				return false;
			}
			return actionPlayer.Movement.IsPointAvailable(_preciseTarget.Position, 0.1f, base.filter);
		}

		protected virtual void OnTargetUnavailable(Agent actionPlayer, Agent target)
		{
			if (target.ActionPlayer.HasAnyActionOfType<AgentActionPrepareForSyncedAction>())
			{
				return;
			}
			AgentActionPrepareForSyncedAction agentActionPrepareForSyncedAction = new AgentActionPrepareForSyncedAction(actionPlayer)
			{
				Priority = base.Action.Priority
			};
			int num;
			for (num = target.ActionPlayer.ActionQueue.Count - 1; num >= 0; num--)
			{
				num = num.ClampIndex(target.ActionPlayer.ActionQueue);
				AgentAction agentAction = target.ActionPlayer.ActionQueue[num];
				if (agentAction != base.Action && (_syncedAction == null || agentAction != _syncedAction))
				{
					agentAction.CancelAction("Cancelled when trying to sync action");
				}
			}
			target.ActionPlayer.InsertAction(agentActionPrepareForSyncedAction, AgentActionPlayer.EInsertType.StopAction, agentActionPrepareForSyncedAction.Priority);
		}
	}
}
