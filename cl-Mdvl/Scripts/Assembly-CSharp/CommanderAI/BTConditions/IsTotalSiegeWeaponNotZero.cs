using NSMedieval.CommanderAI;
using NodeCanvas.Framework;

namespace CommanderAI.BTConditions
{
	public class IsTotalSiegeWeaponNotZero : ConditionTask<CommanderAgentProxy>
	{
		protected override bool OnCheck()
		{
			return base.agent.TotalSiegeWeaponsCount > 0;
		}
	}
}
