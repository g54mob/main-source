using System.Collections;
using Animancer;
using CTS.BBT;
using CTS.BBT.AI;

namespace CTS
{
	public class AgentActionPlayAnim : AgentAction<Agent>
	{
		private readonly AnimKey _animKey;

		private readonly bool _cancellable;

		public AgentActionPlayAnim(AnimKey animKey, bool cancellable = true)
		{
			_animKey = animKey;
			_cancellable = cancellable;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			return agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal, ContextualStatePanicking>();
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			if (_cancellable)
			{
				yield return PlayAnim();
			}
		}

		public override IEnumerator ActionRoutine()
		{
			if (!_cancellable)
			{
				yield return PlayAnim();
			}
		}

		private IEnumerator PlayAnim()
		{
			yield return base.ActionAgent.Animator.PlayPunctual(_animKey, FadeMode.FromStart);
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
