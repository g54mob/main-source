using System;
using System.Collections;

namespace CTS.BBT.AI
{
	public class AgentActionGetUp : AgentAction<Agent>
	{
		public static event Action<Agent> GettingUp;

		public override bool CanBePerformed(Agent agentRef)
		{
			return agentRef.Tags.HasTag(EAgentTag.IsUnconscious);
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
			AgentActionGetUp.GettingUp?.Invoke(base.ActionAgent);
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.GetUp);
		}

		public override void OnComplete()
		{
			base.OnComplete();
			base.ActionAgent.Tags.RemoveTag(EAgentTag.IsUnconscious);
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
