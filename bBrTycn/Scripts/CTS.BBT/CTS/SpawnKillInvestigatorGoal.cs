using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;

namespace CTS
{
	public class SpawnKillInvestigatorGoal : QuestNumericGoal
	{
		private List<Agent> _targets = new List<Agent>();

		public SpawnKillInvestigatorGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			Agent.Died -= OnAgentDied;
		}

		public override void StartObserving()
		{
			for (int i = 0; (float)i < base.TargetValue; i++)
			{
				Customer customer = CTSSingleton<HostileCharacterSpawner>.Instance.SpawnInvestigator();
				customer.ActionPlayer.ForceAction(new AgentActionEnterBar(forceEnter: true), EActionPriority.Forced);
				_targets.Add(customer);
			}
			Agent.Died += OnAgentDied;
		}

		private void OnAgentDied(Agent agent)
		{
			if (_targets.Contains(agent))
			{
				_targets.Remove(agent);
				AddToGoalVariable(1);
			}
		}
	}
}
