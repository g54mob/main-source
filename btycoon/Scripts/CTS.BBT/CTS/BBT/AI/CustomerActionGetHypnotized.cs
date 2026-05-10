using System.Collections;
using Animancer;
using CTS.Core;

namespace CTS.BBT.AI
{
	internal sealed class CustomerActionGetHypnotized : CustomerAction
	{
		private readonly Worker _vampire;

		private bool _wasPanicking;

		public CustomerActionGetHypnotized(Worker p_vampire)
		{
			_vampire = p_vampire;
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			return true;
		}

		public override void OnStart()
		{
			SeatCheck();
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public override IEnumerator ActionRoutine()
		{
			DrinkInHandCheck();
			base.ActionAgent.ClearLivingState();
			base.ActionAgent.Animator.PlayPunctual(AgentAnim.Scared);
			yield return Coroutines.WaitForSeconds(1.25f);
			_wasPanicking = base.ActionAgent.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>();
			base.ActionAgent.ContextualFSM.SetStateNormal();
			base.ActionAgent.Animator.Events.TriggerVFX(VFXList.HypnosisLoopStart);
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.Hypnotised, FadeMode.FromStart);
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
