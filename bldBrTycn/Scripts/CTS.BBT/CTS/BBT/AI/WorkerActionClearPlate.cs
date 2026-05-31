using System.Collections;

namespace CTS.BBT.AI
{
	public class WorkerActionClearPlate : WorkerAction
	{
		private OrderPlate _orderPlate;

		public override bool CanBePerformed(Agent agentRef)
		{
			return agentRef.ObjectHolding.IsHolding<OrderPlate>();
		}

		public override void OnStart()
		{
			_orderPlate = base.ActionAgent.ObjectHolding.GetHeldObject<OrderPlate>();
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public override IEnumerator ActionRoutine()
		{
			_orderPlate.DoFade();
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.ClearPlate, 0f);
			base.ActionAgent.ObjectHolding.DropObject();
		}

		public override void OnComplete()
		{
			base.OnComplete();
			_orderPlate.ClearAll();
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
