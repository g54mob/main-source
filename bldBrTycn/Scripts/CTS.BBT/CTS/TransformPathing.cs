using System;
using System.Collections.Generic;
using CTS.AI;
using CTS.BBT.AI;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public class TransformPathing : PathingTracker
	{
		private static readonly Stack<TransformPathing> _pool = new Stack<TransformPathing>();

		private AgentPath.EDestinationType _destinationType;

		private Transform _target;

		private MoveTarget _moveTarget;

		private TransformPathing()
		{
		}

		internal static TransformPathing Start(AgentAction action, Transform target, AgentPath.EDestinationType destinationType, NavMeshQueryFilter? filter, float pathUpdate = 0.5f)
		{
			TransformPathing obj = ((_pool.Count > 0) ? _pool.Pop() : new TransformPathing());
			obj._destinationType = destinationType;
			obj._target = target;
			obj.PathUpdate = pathUpdate;
			obj.filter = filter;
			obj.Start(action);
			return obj;
		}

		protected override void OnStart()
		{
			_moveTarget = MoveTarget.CreateNew(_target, _destinationType);
		}

		protected override float GetTeleportDistance()
		{
			if (_destinationType == AgentPath.EDestinationType.LookAtDistance)
			{
				return _moveTarget.maxDistance + 1.5f;
			}
			return 1f;
		}

		protected override void OnStopped()
		{
			MoveTarget.Clear(ref _moveTarget);
		}

		protected override void OnCompleted()
		{
			if (_destinationType != AgentPath.EDestinationType.Simple)
			{
				base.ActionAgent.Movement.Velocity = Vector3.zero;
			}
		}

		public override bool IsAtDestination(Transform actionPlayerTransform)
		{
			AgentPath.EPathingStatus? ePathingStatus = base.CurrentPath?.PathingStatus;
			if (ePathingStatus.HasValue && ePathingStatus == AgentPath.EPathingStatus.Completed)
			{
				return true;
			}
			return _destinationType switch
			{
				AgentPath.EDestinationType.Precise => AgentMovement.IsTransformAtDestinationPrecise(actionPlayerTransform, _target.position, _target.forward), 
				AgentPath.EDestinationType.LookAtDistance => AgentMovement.IsTransformAtDestinationLookAt(actionPlayerTransform, _target.position - actionPlayerTransform.position, 1f, 0.5f), 
				AgentPath.EDestinationType.Simple => AgentMovement.IsTransformAtDestinationSimple(actionPlayerTransform, _target.position), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		protected override void SpreadUpdate()
		{
			if (ShouldAvoidRetargeting(base.ActionAgent.transform.position))
			{
				return;
			}
			if (_target == null)
			{
				base.Status = EStatus.Failed;
				return;
			}
			base.ActionAgent.Movement.SetDestination(_moveTarget, out var outPath, base.filter);
			if (outPath != null)
			{
				base.CurrentPath = outPath;
			}
		}
	}
}
