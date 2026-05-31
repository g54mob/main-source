using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	internal class AgentActionForceLeaveToilet : AgentAction<Agent>
	{
		private Toilet _toilet;

		private NavMeshObstacle _toiletNavMeshObstacle;

		public AgentActionForceLeaveToilet(Toilet toilet, Vector3 positionBeforePickup)
		{
			_toilet = toilet;
			_toiletNavMeshObstacle = toilet.NavMeshObstacle;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			return true;
		}

		public override void OnStart()
		{
			if (_toiletNavMeshObstacle != null)
			{
				_toiletNavMeshObstacle.enabled = false;
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return null;
		}

		public override IEnumerator ActionRoutine()
		{
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.Idle);
			_toiletNavMeshObstacle.enabled = false;
			yield return _toilet.OpenDoorTween();
			yield return MoveToTarget(_toilet.UnloadTarget);
			yield return _toilet.CloseDoorTween();
			_toiletNavMeshObstacle.enabled = true;
			base.ActionAgent.ContextualFSM.SetStatePanicking();
			base.ActionAgent.ActionPlayer.ForceAction(new AgentActionLeave(), EActionPriority.Forced);
		}

		public override void OnCancel()
		{
			if (_toiletNavMeshObstacle != null)
			{
				_toiletNavMeshObstacle.enabled = true;
			}
		}

		protected override void OnStopped()
		{
		}
	}
}
