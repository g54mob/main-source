using System.Collections;
using CTS.BBT.AI;

namespace CTS
{
	public class AgentActionGiveAction : AgentAction<Agent>
	{
		private readonly Agent _target;

		private readonly AgentAction _actionToGive;

		private readonly bool _forced;

		public AgentActionGiveAction(Agent agent, AgentAction action, bool forced = false)
		{
			_target = agent;
			_actionToGive = action;
			_forced = forced;
		}

		public override void OnStart()
		{
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			return true;
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public override IEnumerator ActionRoutine()
		{
			if (_forced)
			{
				_target.ActionPlayer.ForceAction(_actionToGive, EActionPriority.Player);
			}
			else
			{
				_target.ActionPlayer.AddAction(_actionToGive);
			}
			yield break;
		}

		public override void OnCancel()
		{
		}

		protected override void OnStopped()
		{
		}
	}
}
