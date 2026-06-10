using NSEipix.Base;
using NSMedieval.CombatAi;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using UnityEngine;

namespace NSMedieval.Draft
{
	public class DraftOrderForceAttackTarget : DraftOrder
	{
		private Agent attackerAgent;

		private IDamageTakingAgent target;

		public DraftOrderForceAttackTarget(IDamageTakingAgent target)
			: base(DraftOrderType.ForceAttackTarget)
		{
			this.target = target;
		}

		public override bool CheckRequirements(HumanoidInstance instance, DraftOrder lastDraftOrder)
		{
			attackerAgent = instance.GetGoapAgent();
			return true;
		}

		public override void Execute(HumanoidInstance instance)
		{
			if (CombatCalculator.CalculateDamage(instance, target, isCritical: false) <= 0f)
			{
				DamagePopup.Create(target.GetPosition(), MonoSingleton<LocalizationController>.Instance.GetText("can_not_deal_damage_to_target"), Color.yellow);
				return;
			}
			if (instance.WorkerBehaviour.CombatMode == UnitCombatModeType.DraftedHoldGround)
			{
				instance.WorkerBehaviour.SetCombatMode(UnitCombatModeType.DraftedDefault);
			}
			MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(instance, target);
			instance.CombatAi.SetState(CombatAiState.LastAttackOrderTarget, target);
			attackerAgent.ForceNextGoal("AttackGoal");
		}

		public override void OnNewOrder(HumanoidInstance instance, DraftOrder newOrder)
		{
			if (newOrder.Type != DraftOrderType.ForceAttackTarget)
			{
				instance?.SetTarget(null);
				MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(instance);
				instance?.CombatAi.SetState(CombatAiState.LastAttackOrderTarget, null);
			}
		}

		public override void OnDraftEnd(HumanoidInstance instance)
		{
			instance?.SetTarget(null);
			MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(instance);
		}
	}
}
