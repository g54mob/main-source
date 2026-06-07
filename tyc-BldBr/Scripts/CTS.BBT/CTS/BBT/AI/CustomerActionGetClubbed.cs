using System.Collections;

namespace CTS.BBT.AI
{
	internal sealed class CustomerActionGetClubbed : CustomerAction
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
			base.ActionAgent.AgentEyesBlinkControler.CurrentEyesState = AgentEyesBlinkControler.e_eyesState.StayClose;
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.GetClubbed);
			if ((bool)base.ActionAgent.FurnitureAssignment.CurrentSeat)
			{
				base.ActionAgent.FurnitureAssignment.ReleaseSeat();
				base.ActionAgent.Animator.ChangeIdle(AgentAnim.Idle);
			}
			base.ActionAgent.ContextualFSM.SetStateUnconscious(shouldPanic: true);
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
