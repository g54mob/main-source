using System.Collections;
using CTS.BBT.AI;

namespace CTS
{
	public class ActionDebugLoop : AgentAction<Agent>
	{
		protected internal override void OnActionGiven()
		{
			base.OnActionGiven();
			base.Status = EStatus.Completed;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			return false;
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
