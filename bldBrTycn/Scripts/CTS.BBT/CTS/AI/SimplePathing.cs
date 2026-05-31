using System.Collections.Generic;
using CTS.BBT.AI;
using UnityEngine;
using UnityEngine.AI;

namespace CTS.AI
{
	public class SimplePathing : PathingTracker
	{
		private static readonly Stack<SimplePathing> _pool = new Stack<SimplePathing>();

		private Vector3 _pos;

		private float _distancePadding;

		private SimplePathing()
		{
		}

		internal static SimplePathing Start(AgentAction action, Vector3 pos, NavMeshQueryFilter? filter, float distancePadding = 0.5f)
		{
			SimplePathing obj = ((_pool.Count > 0) ? _pool.Pop() : new SimplePathing());
			obj._pos = pos;
			obj.filter = filter;
			obj._distancePadding = distancePadding;
			obj.Start(action);
			return obj;
		}

		protected override void OnStart()
		{
		}

		protected override float GetTeleportDistance()
		{
			return 1f;
		}

		protected override void OnStopped()
		{
		}

		protected override void OnCompleted()
		{
		}

		public override bool IsAtDestination(Transform actionPlayerTransform)
		{
			return Vector3.Distance(_pos, actionPlayerTransform.position) < _distancePadding;
		}

		protected override void SpreadUpdate()
		{
			if (!ShouldAvoidRetargeting(base.ActionAgent.transform.position))
			{
				base.ActionAgent.Movement.SetDestination(_pos, out var outPath, base.filter);
				if (outPath != null)
				{
					base.CurrentPath = outPath;
				}
			}
		}
	}
}
