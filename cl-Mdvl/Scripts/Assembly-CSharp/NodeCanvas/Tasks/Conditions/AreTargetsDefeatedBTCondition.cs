using System.Collections.Generic;
using NSMedieval.CombatAi;
using NSMedieval.CommanderAI;
using NSMedieval.Goap;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Going Medieval")]
	[Description("Returns true if the targets are defeated")]
	public class AreTargetsDefeatedBTCondition : ConditionTask<CommanderAgentProxy>
	{
		public BBParameter<List<IDamageTakingAgent>> targets;

		protected override string info => $"all {targets} are defeated";

		protected override bool OnCheck()
		{
			return CombatAiUtils.AreTargetsDefeated(targets?.value);
		}
	}
}
