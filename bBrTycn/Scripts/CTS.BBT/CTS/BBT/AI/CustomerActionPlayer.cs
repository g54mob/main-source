using System.Collections;

namespace CTS.BBT.AI
{
	public sealed class CustomerActionPlayer : AgentActionPlayer
	{
		private Customer Customer => (Customer)agent;

		protected override IEnumerator WaitForRoutine()
		{
			yield return StartCoroutine(base.CurrentAction.WaitForRoutine());
		}

		protected override IEnumerator ActionRoutine()
		{
			yield return StartCoroutine(base.CurrentAction.ActionRoutine());
		}

		public override void PlayInstantly(AgentAction action, EInsertType insertType = EInsertType.CancelAction, EActionPriority priority = EActionPriority.Forced)
		{
			InsertAction(action, insertType, priority);
			if (base.CurrentAction != null)
			{
				return;
			}
			if (!(action is CustomerAction p_action))
			{
				if (action is AgentAction<Agent> p_action2)
				{
					Customer.FSM.SetState(new CustomerActionState<Agent>(p_action2));
				}
			}
			else
			{
				Customer.FSM.SetState(new CustomerActionState<Customer>(p_action));
			}
		}
	}
}
