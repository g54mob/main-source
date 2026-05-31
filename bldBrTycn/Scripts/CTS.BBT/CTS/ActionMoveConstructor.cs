using CTS.AI;
using CTS.BBT.AI;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class ActionMoveConstructor : ActionConstructor<AgentActionMove>, IGive<MoveTarget>, IGive<Vector3>
	{
		[SerializeField]
		private SoftReference<MoveTarget> _target;

		[SerializeField]
		[HideIf("HasTarget")]
		private Vector3 _position;

		private bool HasTarget => _target.Value != null;

		protected override AgentActionMove ConstructAction()
		{
			if (HasTarget)
			{
				return new AgentActionMove(_target);
			}
			return new AgentActionMove(_position);
		}

		MoveTarget IGive<MoveTarget>.Get()
		{
			return _target;
		}

		Vector3 IGive<Vector3>.Get()
		{
			if (!HasTarget)
			{
				return _position;
			}
			return _target.Get().Position;
		}

		private void OnDrawGizmosSelected()
		{
			if (!HasTarget)
			{
				_ = _position;
			}
			else
			{
				_ = _target.Get().Position;
			}
			Gizmos.color = Color.green;
		}
	}
}
