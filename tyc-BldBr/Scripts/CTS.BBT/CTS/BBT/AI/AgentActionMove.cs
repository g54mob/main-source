using System.Collections;
using CTS.AI;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT.AI
{
	public class AgentActionMove : AgentAction<Agent>, IGive<MoveTarget>, IGive<Vector3>
	{
		private SoftReference<MoveTarget> _target;

		public Vector3 Position { get; set; }

		public AgentActionMove(Vector3 p_position, bool playBlockedAction = false)
		{
			Position = p_position;
			base.CanPlayBlockedAction = playBlockedAction;
		}

		public AgentActionMove(SoftReference<MoveTarget> targetReference, bool playBlockedAction = false)
		{
			_target = targetReference;
			base.CanPlayBlockedAction = playBlockedAction;
		}

		public AgentActionMove(MoveTarget target, bool playBlockedAction = false)
			: this(SoftReference.Create(target), playBlockedAction)
		{
		}

		public override bool CanBePerformed(Agent p_agent)
		{
			if (base.IsPlaying)
			{
				return true;
			}
			if (_target.HasValue)
			{
				return !p_agent.Movement.CheckDestination(_target);
			}
			return (Position - p_agent.transform.position).sqrMagnitude > 0.25f;
		}

		public override void OnStart()
		{
			SeatCheck();
		}

		public override IEnumerator WaitForRoutine()
		{
			if (_target.HasValue)
			{
				yield return MoveToTarget(_target);
			}
			else
			{
				yield return MoveToPosition(Position);
			}
		}

		public override IEnumerator ActionRoutine()
		{
			yield break;
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}

		MoveTarget IGive<MoveTarget>.Get()
		{
			if (_target.HasValue)
			{
				return _target;
			}
			return null;
		}

		Vector3 IGive<Vector3>.Get()
		{
			if (!_target.HasValue)
			{
				return Position;
			}
			return _target.Value.Position;
		}
	}
}
