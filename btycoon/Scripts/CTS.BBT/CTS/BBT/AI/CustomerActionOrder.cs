using System.Collections;
using UnityEngine;

namespace CTS.BBT.AI
{
	internal sealed class CustomerActionOrder : CustomerAction
	{
		private readonly Agent _waiter;

		public CustomerActionOrder(Agent waiter)
		{
			_waiter = waiter;
		}

		public override bool CanBePerformed(Agent p_agent)
		{
			p_agent.ContextualFSM.CurrentStateEquals<ContextualStateNormal>();
			return true;
		}

		public override void OnStart()
		{
			if (!base.ActionAgent.AtTable)
			{
				PlayActionAndResumeThis(new AgentActionSitDown(base.ActionAgent.AssignedSeat));
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public override IEnumerator ActionRoutine()
		{
			Transform boneTransform;
			bool headBone = _waiter.SkeletonData.TryGetBone(EBone.Head, out boneTransform);
			if (headBone)
			{
				base.ActionAgent.ProceduralAnimator.LookAt(boneTransform);
			}
			switch (Random.Range(0, 3))
			{
			case 1:
				yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.Talk02);
				break;
			case 2:
				yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.Talk03);
				break;
			default:
				yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.Talk01);
				break;
			}
			if (headBone)
			{
				base.ActionAgent.ProceduralAnimator.StopLookAt();
			}
		}

		protected override void OnStopped()
		{
			_ = base.ActionAgent.isActiveAndEnabled;
		}

		public override void OnCancel()
		{
		}
	}
}
