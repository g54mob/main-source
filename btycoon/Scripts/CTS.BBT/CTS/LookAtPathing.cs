using System.Collections.Generic;
using CTS.AI;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public class LookAtPathing : PathingTracker
	{
		private static readonly Stack<LookAtPathing> _pool = new Stack<LookAtPathing>();

		private Transform _target;

		private float _lookDistance;

		private float _fov;

		private LookAtPathing()
		{
		}

		internal static LookAtPathing Start(AgentAction action, Transform target, NavMeshQueryFilter? filter, float lookDistance = 1f, float fov = 0.5f)
		{
			LookAtPathing obj = ((_pool.Count > 0) ? _pool.Pop() : new LookAtPathing());
			obj._target = target;
			obj._lookDistance = lookDistance;
			obj.filter = filter;
			obj._fov = fov;
			obj.Start(action);
			return obj;
		}

		protected override void OnStart()
		{
		}

		protected override float GetTeleportDistance()
		{
			return _lookDistance + 1.5f;
		}

		protected override void OnStopped()
		{
		}

		protected override void OnCompleted()
		{
			Vector3 vector = _target.position - base.ActionAgent.transform.position;
			vector = vector.FlattenY();
			base.ActionAgent.Movement.FaceDirection(Quaternion.LookRotation(vector.normalized));
			base.ActionAgent.Movement.Velocity = Vector3.zero;
		}

		public override bool IsAtDestination(Transform actionPlayerTransform)
		{
			AgentPath.EPathingStatus? ePathingStatus = base.CurrentPath?.PathingStatus;
			if (ePathingStatus.HasValue && ePathingStatus == AgentPath.EPathingStatus.Completed)
			{
				return true;
			}
			Vector3 direction = _target.position - actionPlayerTransform.position;
			return AgentMovement.IsTransformAtDestinationLookAt(actionPlayerTransform, direction, _lookDistance, _fov);
		}

		protected override void SpreadUpdate()
		{
			if (!ShouldAvoidRetargeting(base.ActionAgent.transform.position))
			{
				base.ActionAgent.Movement.SetDestinationLookAt(_target, _lookDistance, out var outPath, _fov, base.filter);
				if (outPath != null)
				{
					base.CurrentPath = outPath;
				}
			}
		}
	}
}
