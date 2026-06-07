using CTS.BBT.AI;

namespace CTS
{
	public class MachineCaptureGoal : QuestNumericGoal
	{
		public MachineCaptureGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			MachineBase.VictimCaptured -= OnVictimCaptured;
		}

		public override void StartObserving()
		{
			MachineBase.VictimCaptured += OnVictimCaptured;
		}

		private void OnVictimCaptured(MachineBase machine, Agent victim)
		{
			AddToGoalVariable(1);
		}
	}
}
