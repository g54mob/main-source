using NSMedieval.Goap;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.CombatAi
{
	public class AttackFleeAiActionGoal : AttackAiActionGoal
	{
		private bool isNextFlee;

		private AnimalInstance animalOwner;

		public AttackFleeAiActionGoal(Agent selfAgent)
			: base("AttackFleeAiActionGoal", selfAgent)
		{
			animalOwner = base.AgentOwner as AnimalInstance;
		}

		protected override void StartGoal()
		{
			if (animalOwner != null && isNextFlee)
			{
				isNextFlee = Random.value <= animalOwner.Blueprint.FleeAfterAttackChanceWildAggro;
			}
			if (isNextFlee)
			{
				base.CombatAi.SetState(CombatAiState.IsFleeingDisabled, false);
				base.CombatAi.SetState(CombatAiState.IsFleeing, true);
				base.CombatAi.SetState(CombatAiState.MinFleeDistance, 3f);
				base.CombatAi.SetState(CombatAiState.MaxFleeDistance, 6f);
				ForceGoapAgentGoal("FleeGoal");
			}
			else
			{
				base.StartGoal();
			}
			isNextFlee = !isNextFlee;
		}
	}
}
