using System.Collections;
using CTS.AI;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public class AgentActionReturnToNavMesh : AgentAction<Agent>
	{
		public override bool CanBePerformed(Agent agentRef)
		{
			return true;
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			if (!NavMesh.SamplePosition(base.ActionAgent.transform.position + Random.insideUnitCircle.normalized.ToHorizontal3D() * 2f, out var hit, 1.5f, AgentsMover.AllAreas))
			{
				CancelAction("Couldn't find a spot on navmesh", playBlockedAction: true);
				yield break;
			}
			Debug.DrawRay(hit.position, Vector3.up, Color.blue, 5f);
			yield return MoveToPosition(hit.position, null, 0.1f);
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
