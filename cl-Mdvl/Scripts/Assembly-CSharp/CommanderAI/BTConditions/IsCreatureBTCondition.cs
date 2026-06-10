using NSMedieval.CommanderAI;
using NSMedieval.Goap;
using NSMedieval.State;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace CommanderAI.BTConditions
{
	[Category("✫ Going Medieval")]
	[Description("Returns true if the given agent is a creature")]
	public class IsCreatureBTCondition : ConditionTask<CommanderAgentProxy>
	{
		public BBParameter<IDamageTakingAgent> target;

		protected override string info => $"{target} is a creature";

		protected override bool OnCheck()
		{
			return target.value is CreatureBase;
		}
	}
}
