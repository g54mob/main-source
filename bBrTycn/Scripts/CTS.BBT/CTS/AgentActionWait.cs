using System.Collections;
using CTS.BBT.AI;
using CTS.Core;

namespace CTS
{
	public class AgentActionWait : AgentAction<Agent>
	{
		public float Duration { get; set; } = 1f;

		public override bool CanBePerformed(Agent agentRef)
		{
			return true;
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return Coroutines.WaitForSeconds(Duration);
		}

		public override IEnumerator ActionRoutine()
		{
			yield break;
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
