using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace CTS.BBT.AI
{
	internal sealed class CustomerIdleState : CustomerState
	{
		private float _nextIdleMove;

		private const float IdleRadius = 2.5f;

		private static readonly Vector2 IdleRange = new Vector2(5f, 10f);

		private static readonly NamedLayerMask MoveTargetMask = new NamedLayerMask("Furniture", "InterractionZone", "AgentInterCollision");

		public override void OnStateEnter()
		{
			_nextIdleMove = Time.time + Random.Range(IdleRange.x, IdleRange.y);
		}

		public override void SpreadUpdate()
		{
			_ = base.parent.ActionPlayer.isActiveAndEnabled;
			if (base.parent.ContextualFSM.CurrentStateEquals<ContextualStateNormal, ContextualStatePanicking>())
			{
				if (base.parent.AutonomousActions.TryGetAutonomousAction(out var outAction) && base.parent.ActionPlayer.TryForceAction(outAction, outAction.Priority))
				{
					PlayAction(outAction);
				}
				else
				{
					TryRandomMove();
				}
			}
		}

		public override void Update()
		{
			if (base.parent.ContextualFSM.CurrentStateEquals<ContextualStateNormal, ContextualStatePanicking>() && base.parent.ActionPlayer.CurrentAction == null && base.parent.ActionPlayer.TryGetNextAction<AgentAction>(out var outAction))
			{
				PlayAction(outAction);
			}
		}

		private void PlayAction(AgentAction action)
		{
			if (action == null)
			{
				return;
			}
			if (!(action is CustomerAction p_action))
			{
				if (action is AgentAction<Agent> p_action2)
				{
					base.fsm.SetState(new CustomerActionState<Agent>(p_action2));
				}
			}
			else
			{
				base.fsm.SetState(new CustomerActionState<Customer>(p_action));
			}
		}

		private void TryRandomMove()
		{
			if (base.parent.AutonomousActions.Paused || base.parent.ActionPlayer.CurrentAction is AgentActionMove || base.parent.ActionPlayer.ActionQueue.Count > 0 || (bool)base.parent.FurnitureAssignment.CurrentSeat)
			{
				return;
			}
			using (new TemporaryColliderEnable(base.parent.Selection.InterCollider, isEnabled: false))
			{
				if (Physics.CheckSphere(base.parent.transform.position, 0.2f, MoveTargetMask, QueryTriggerInteraction.Ignore))
				{
					DoRandomMove();
					return;
				}
			}
			if (!base.parent.ObjectHolding.IsCurrentlyHolding && !(Time.time < _nextIdleMove))
			{
				DoRandomMove();
			}
			void DoRandomMove()
			{
				Vector3 vector = (Random.insideUnitCircle * 2.5f).ToHorizontal3D();
				if (NavMesh.SamplePosition(base.parent.transform.position + vector, out var hit, 1f, base.parent.IsVampire ? base.parent.VampireRandomMovementAreaMask : base.parent.HumanRandomMovementAreaMask))
				{
					_nextIdleMove = Time.time + Random.Range(IdleRange.x, IdleRange.y);
					base.parent.ActionPlayer.Play(new AgentActionMove(hit.position));
				}
			}
		}

		public override void OnStateExit()
		{
		}
	}
}
