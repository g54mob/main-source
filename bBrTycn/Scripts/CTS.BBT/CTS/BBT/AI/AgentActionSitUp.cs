using System.Collections;
using CTS.AI;
using UnityEngine;
using UnityEngine.AI;

namespace CTS.BBT.AI
{
	internal sealed class AgentActionSitUp : AgentAction<Agent>
	{
		private Seat _seat;

		private static NavMeshPath _dummyPath;

		public AgentActionSitUp()
		{
			if (_dummyPath == null)
			{
				_dummyPath = new NavMeshPath();
			}
			base.Name = "Sitting up";
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			if (!p_agentRef.FurnitureAssignment.CurrentSeat)
			{
				return false;
			}
			return p_agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal, ContextualStatePanicking>();
		}

		public override void OnStart()
		{
			_seat = base.ActionAgent.FurnitureAssignment.CurrentSeat;
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public override IEnumerator ActionRoutine()
		{
			base.ActionAgent.Animator.ChangeIdle(AgentAnim.Idle);
			int num = (int)(Random.value * 2f);
			MoveTarget moveTarget = _seat.ContextActorData.InteractionTargets[EInteractionKey.RegularUsage][num];
			NavMesh.CalculatePath(moveTarget.Position, EntranceResolver.ExitNavMeshCheck.position, AgentsMover.AllAreas, _dummyPath);
			if (_dummyPath.status != NavMeshPathStatus.PathComplete)
			{
				moveTarget = _seat.ContextActorData.InteractionTargets[EInteractionKey.RegularUsage][1 - num];
			}
			Vector3 vector = _seat.transform.position - moveTarget.Position;
			if (Vector3.SignedAngle(_seat.transform.forward, vector.normalized, Vector3.up) < 0f)
			{
				yield return base.ActionAgent.Animator.PlayPunctual(_seat.IsLow ? AgentAnim.SitLowUp : AgentAnim.SitHighRUp);
			}
			else
			{
				yield return base.ActionAgent.Animator.PlayPunctual(_seat.IsLow ? AgentAnim.SitLowUp : AgentAnim.SitHighLUp);
			}
		}

		public override void OnComplete()
		{
			base.OnComplete();
			base.ActionAgent.FurnitureAssignment.ReleaseSeat();
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
