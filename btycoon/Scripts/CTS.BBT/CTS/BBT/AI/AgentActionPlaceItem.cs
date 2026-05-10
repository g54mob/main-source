using System.Collections;
using CTS.AI;

namespace CTS.BBT.AI
{
	internal sealed class AgentActionPlaceItem : AgentAction<Agent>
	{
		private ItemSlot _slot;

		private MoveTarget _moveTarget;

		public AgentActionPlaceItem(ItemSlot p_slot)
		{
			base.Name = "Placing Item";
			_slot = p_slot;
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			return p_agentRef.ObjectHolding.IsCurrentlyHolding;
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			_moveTarget = MoveTarget.CreateNew(_slot.transform.position, _slot.transform.rotation, AgentPath.EDestinationType.LookAtDistance);
			yield return MoveToTarget(_moveTarget);
		}

		public override IEnumerator ActionRoutine()
		{
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.DropObjectLeft);
			base.ActionAgent.ObjectHolding.DropObject();
		}

		protected override void OnStopped()
		{
			MoveTarget.Clear(ref _moveTarget);
		}

		public override void OnCancel()
		{
		}
	}
}
