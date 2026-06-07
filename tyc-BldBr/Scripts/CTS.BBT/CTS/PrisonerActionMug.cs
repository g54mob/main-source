using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	public class PrisonerActionMug : AgentAction<Agent>
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
			yield return base.ActionAgent.Animator.PlayPunctual(((double)Random.value >= 0.5) ? AgentAnim.Prisonnermug : AgentAnim.PrisonnermugB);
		}

		protected override void OnStopped()
		{
			base.ActionAgent.Tools.DisableTools();
		}
	}
}
