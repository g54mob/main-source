using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace CTS.AI
{
	public class MoveTargetPathing : PathingTracker
	{
		private static readonly Stack<MoveTargetPathing> _pool = new Stack<MoveTargetPathing>();

		private MoveTarget _target;

		private MoveTargetPathing()
		{
		}

		internal static MoveTargetPathing Start(AgentAction action, MoveTarget target, NavMeshQueryFilter? filter, float pathUpdate = 0.5f)
		{
			MoveTargetPathing obj = ((_pool.Count > 0) ? _pool.Pop() : new MoveTargetPathing());
			obj.PathUpdate = pathUpdate;
			obj._target = target;
			obj.filter = filter;
			obj.Start(action);
			return obj;
		}

		protected override void OnStart()
		{
		}

		protected override float GetTeleportDistance()
		{
			if (_target.DestinationType == AgentPath.EDestinationType.LookAtDistance)
			{
				return _target.maxDistance + 1.5f;
			}
			return 1f;
		}

		public override bool IsAtDestination(Transform actionPlayerTransform)
		{
			AgentPath.EPathingStatus? ePathingStatus = base.CurrentPath?.PathingStatus;
			if (ePathingStatus.HasValue && ePathingStatus == AgentPath.EPathingStatus.Completed)
			{
				return true;
			}
			return AgentMovement.IsTransformAtDestination(actionPlayerTransform, _target);
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
			base.ActionAgent.Movement.SetDestination(_target, out var outPath, base.filter);
			if (outPath != null)
			{
				base.CurrentPath = outPath;
			}
		}

		protected override void OnStopped()
		{
		}

		protected override void OnCompleted()
		{
			if (_target.DestinationType != AgentPath.EDestinationType.Simple)
			{
				base.ActionAgent.Movement.Velocity = Vector3.zero;
				if (_target.DestinationType == AgentPath.EDestinationType.LookAtDistance)
				{
					Vector3 vector = _target.Position - base.ActionAgent.transform.position;
					vector = vector.FlattenY();
					base.ActionAgent.Movement.FaceDirection(Quaternion.LookRotation(vector.normalized));
				}
			}
		}
	}
}
