using NSMedieval.CommanderAI.BehaviourTreeTasks;
using NSMedieval.Manager;
using ParadoxNotion.Design;

namespace CommanderAI.BTConditions
{
	[Category("✫ Going Medieval")]
	[Description("Returns true if half source units are defeated")]
	public class IsRaidHalfDeadBTCondition : UnitsBTConditionBase
	{
		private int totalRaiders;

		protected override string info => $"Check if half {sourceUnits} are defeated";

		protected override bool OnCheck()
		{
			ActiveRaidInfo linkedRaid = base.agent.Agent.LinkedRaid;
			if (totalRaiders == 0 && linkedRaid != null)
			{
				totalRaiders = linkedRaid.Blueprint.Enemies.Length;
			}
			if (sourceUnits.value.Count <= totalRaiders / 2)
			{
				return true;
			}
			return false;
		}
	}
}
