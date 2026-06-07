using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	public class PrisonerActionSadSitDown : AgentAction<Agent>
	{
		private enum EState
		{
			Up = 0,
			SittingDown = 1,
			Down = 2,
			GettingUp = 3
		}

		private EState _state;

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
			ResetAnimation();
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			_state = EState.SittingDown;
			base.ActionAgent.Animator.SetIdle(AgentAnim.PrisonnerPlsLoop);
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.SitDownPls);
			_state = EState.Down;
			yield return new WaitForSeconds(Random.Range(10, 15));
			_state = EState.GettingUp;
			base.ActionAgent.Animator.SetIdleAndPlay(AgentAnim.Idle);
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.GetUpPls);
			_state = EState.Up;
		}

		protected override void OnStopped()
		{
		}

		private void ResetAnimation()
		{
			switch (_state)
			{
			case EState.SittingDown:
				base.ActionAgent.Animator.SetIdleAndPlay(AgentAnim.Idle);
				break;
			case EState.Down:
				base.ActionAgent.Animator.SetIdle(AgentAnim.Idle);
				base.ActionAgent.Animator.PlayPunctual(AgentAnim.GetUpPls);
				break;
			case EState.GettingUp:
				base.ActionAgent.Animator.SetIdle(AgentAnim.Idle);
				break;
			case EState.Up:
				break;
			}
		}
	}
}
