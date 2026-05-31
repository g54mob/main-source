using System.Collections;

namespace CTS.BBT.AI
{
	internal sealed class CustomerActionClubTutorial : CustomerAction
	{
		public override bool CanBePerformed(Agent p_agent)
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
			base.ActionAgent.ClearLivingState();
			base.ActionAgent.Tags.AddTag(EAgentTag.IsUnconscious);
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.GetClubbed);
			base.ActionAgent.ContextualFSM.SetStateUnconscious(-1f);
		}

		public override void OnComplete()
		{
			base.OnComplete();
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
