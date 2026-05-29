using System.Collections;
using CTS.BBT.AI;
using CTS.Core.Utilities;

namespace CTS
{
	public class AgentActionWanderStreet : AgentAction<Agent>
	{
		public override bool CanBePerformed(Agent agentRef)
		{
			return agentRef is Customer;
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			PathingTracker pathingTracker = MoveToPosition(base.ActionAgent.Cast<Customer>().SpawnPoint.GetGroupDestination().Position);
			pathingTracker.PathUpdate = 2f;
			yield return pathingTracker;
		}

		public override IEnumerator ActionRoutine()
		{
			yield break;
		}

		public override void OnComplete()
		{
			base.OnComplete();
			base.ActionAgent.ClearObject();
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
