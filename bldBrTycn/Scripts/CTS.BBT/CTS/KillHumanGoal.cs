using CTS.BBT.AI;

namespace CTS
{
	public class KillHumanGoal : QuestNumericGoal
	{
		public KillHumanGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			Agent.Died -= OnDeath;
		}

		public override void StartObserving()
		{
			Agent.Died += OnDeath;
		}

		private void OnDeath(Agent agent)
		{
			if (agent.IsHuman)
			{
				AddToGoalVariable(1);
			}
		}
	}
}
