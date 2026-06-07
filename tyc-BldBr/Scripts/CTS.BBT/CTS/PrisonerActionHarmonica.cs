using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	public class PrisonerActionHarmonica : AgentAction<Agent>
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
			base.ActionAgent.Animator.SetIdleAndPlay(AgentAnim.Idle);
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			base.ActionAgent.Animator.SetIdle(AgentAnim.PrisonnerHarmonicaStandup);
			yield return new WaitForSeconds(Random.Range(8, 12));
			base.ActionAgent.Animator.SetIdle(AgentAnim.Idle);
		}

		protected override void OnStopped()
		{
			base.ActionAgent.Tools.DisableTools();
		}
	}
}
