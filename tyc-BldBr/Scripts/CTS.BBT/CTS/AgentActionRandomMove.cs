using System.Collections;
using CTS.AI;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public class AgentActionRandomMove : AgentAction<Agent>
	{
		private Vector3? _targetPos;

		private readonly float _searchRadius;

		private readonly int? _areaMask;

		private readonly FrameCheck<AgentActionRandomMove, Agent> _positionCheck = new FrameCheck<AgentActionRandomMove, Agent>(TryGetPosition);

		public AgentActionRandomMove(float searchRadius = 10f, int? areaMask = null)
		{
			_searchRadius = searchRadius;
			_areaMask = areaMask;
		}

		private static bool TryGetPosition(AgentActionRandomMove action, Agent agent)
		{
			action._targetPos = null;
			int num = 0;
			int areaMask = action._areaMask ?? AgentsMover.AllAreas;
			while (true)
			{
				Vector3? targetPos = action._targetPos;
				if (targetPos.HasValue || num >= 5)
				{
					break;
				}
				if (NavMesh.SamplePosition(agent.transform.position + (Random.insideUnitCircle * (action._searchRadius - 1f)).ToHorizontal3D(), out var hit, 1f, areaMask))
				{
					action._targetPos = hit.position;
					return true;
				}
				num++;
			}
			return false;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			if (!agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal, ContextualStatePanicking>())
			{
				return false;
			}
			return _positionCheck.Check(this, agentRef);
		}

		public override void OnStart()
		{
			if (!TryGetPosition(this, base.ActionAgent))
			{
				CancelAction("");
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return MoveToPosition(_targetPos.Value, AgentsMover.AllAreas);
		}

		public override IEnumerator ActionRoutine()
		{
			base.ActionAgent.Cooldowns.StartCooldown(BBTAgentTags.RandomMove);
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
