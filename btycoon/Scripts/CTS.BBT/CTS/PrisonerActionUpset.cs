using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;

namespace CTS
{
	public class PrisonerActionUpset : AgentAction<Agent>
	{
		public override IEnumerator ActionRoutine()
		{
			yield break;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			return true;
		}

		public override void OnCancel()
		{
			base.ActionAgent.Animator.ReturnToIdle();
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.PrisonnerBar);
		}

		protected override void OnStopped()
		{
		}
	}
}
