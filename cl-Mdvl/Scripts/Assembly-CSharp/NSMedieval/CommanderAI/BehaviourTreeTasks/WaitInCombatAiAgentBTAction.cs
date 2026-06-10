using System.Collections.Generic;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Controllers;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Unit Orders")]
	[Description("Change the CombatAiAgent of a single unit or group and keep it until stopped")]
	public class WaitInCombatAiAgentBTAction : UnitsBTActionBase
	{
		public string combatAiAgentId;

		public bool restorePreviousOnEnd;

		private readonly Dictionary<CommanderAIUnit, string> previousAgentId = new Dictionary<CommanderAIUnit, string>();

		protected override string info => base.info + ": Wait in CombatAiAgent '" + combatAiAgentId + "'";

		protected override void OnStart()
		{
			if (base.Units == null || base.UnitCount == 0)
			{
				EndAction(success: false);
				return;
			}
			previousAgentId.Clear();
			foreach (CommanderAIUnit unit in base.Units)
			{
				if (restorePreviousOnEnd)
				{
					previousAgentId[unit] = unit.Humanoid.CombatAi.BlueprintId;
				}
				unit.Humanoid.SetCombatAiAgent(combatAiAgentId);
				unit.CurrentOrder = MoveOrder.Stop(unit);
			}
		}

		protected override void OnStop()
		{
			if (!restorePreviousOnEnd || LoadingController.IsSceneTransition)
			{
				return;
			}
			foreach (CommanderAIUnit unit in base.Units)
			{
				unit.Humanoid.SetCombatAiAgent(previousAgentId[unit]);
			}
		}
	}
}
