using System.Collections;

namespace CTS.BBT.AI
{
	internal sealed class CustomerActionFall : CustomerAction
	{
		private bool _repositioned;

		public override bool CanBePerformed(Agent p_agentRef)
		{
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
			base.ActionAgent.ContextualFSM.SetStateStuck();
			yield return base.ActionAgent.Animator.PlayPunctualInstantly(AgentAnim.TrapFall02);
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
