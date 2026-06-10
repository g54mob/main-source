using NSMedieval.Goap;

namespace NSMedieval.CombatAi
{
	public class FleeAiActionGoal : CombatAiActionGoal
	{
		public FleeAiActionGoal(Agent selfAgent)
			: base("FleeAiActionGoal", selfAgent)
		{
		}

		public override void Start()
		{
			base.Start();
			base.CombatAi.SetState(CombatAiState.IsFleeing, true);
			ForceGoapAgentGoal("FleeGoal");
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			base.CombatAi.SetState(CombatAiState.IsFleeing, false);
		}

		public override bool CanStart(bool isForced = false)
		{
			if (base.CombatAi.GetState<bool>(CombatAiState.IsFleeingDisabled))
			{
				return false;
			}
			IDamageDealAgent damageDealAgent = base.CombatAi.GetState<IDamageDealAgent>(CombatAiState.NearestHostile);
			if (damageDealAgent?.CombatAi == null || base.CombatAi.IsStateSet(CombatAiState.Fainted))
			{
				return false;
			}
			IEquipableAgent obj = base.AgentOwner as IEquipableAgent;
			if (obj == null || !(obj.Inventory?.EquipOrders?.Count > 0))
			{
				return damageDealAgent.CombatAi.GetState<bool>(CombatAiState.IsAggressive);
			}
			return false;
		}
	}
}
