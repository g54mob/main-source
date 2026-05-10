using System.Collections;

namespace CTS.BBT.AI
{
	internal class CustomerActionCallWaiter : CustomerAction
	{
		public override bool CanBePerformed(Agent agentRef)
		{
			if (!(agentRef is Customer customer))
			{
				return false;
			}
			if (!customer.AssignedSeat)
			{
				return false;
			}
			if (customer.CurrentOrder != null)
			{
				return false;
			}
			return true;
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public override IEnumerator ActionRoutine()
		{
			if (base.ActionAgent.GroupData.TryGetWaitingOrder(out var p_order))
			{
				CustomerOrder p_order2 = new CustomerOrder(base.ActionAgent, p_order);
				p_order.AddOrder(p_order2);
				yield break;
			}
			p_order = new GroupOrder(base.ActionAgent);
			CustomerOrder p_order3 = new CustomerOrder(base.ActionAgent, p_order);
			p_order.AddOrder(p_order3);
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.SummonWaiter);
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
