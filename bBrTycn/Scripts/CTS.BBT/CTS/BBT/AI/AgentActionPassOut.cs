using System;
using System.Collections;

namespace CTS.BBT.AI
{
	internal sealed class AgentActionPassOut : AgentAction<Agent>
	{
		public static event Action<Agent> PassingOut;

		public override bool CanBePerformed(Agent p_agent)
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
			base.ActionAgent.Tags.AddTag(EAgentTag.IsUnconscious);
			AgentActionPassOut.PassingOut?.Invoke(base.ActionAgent);
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.PassOut);
			base.ActionAgent.ContextualFSM.SetStateUnconscious();
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
