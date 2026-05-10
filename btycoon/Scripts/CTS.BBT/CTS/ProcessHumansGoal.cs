using CTS.BBT.AI;

namespace CTS
{
	public class ProcessHumansGoal : QuestNumericGoal
	{
		public ProcessHumansGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			MachineBase.VictimHarvested -= OnVictimHarvested;
		}

		public override void StartObserving()
		{
			MachineBase.VictimHarvested += OnVictimHarvested;
		}

		private void OnVictimHarvested(MachineBase machine, Agent victim)
		{
			AddToGoalVariable(1);
		}
	}
}
