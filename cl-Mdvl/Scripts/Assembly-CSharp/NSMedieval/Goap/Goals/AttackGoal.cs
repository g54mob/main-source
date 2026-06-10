using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Types;

namespace NSMedieval.Goap.Goals
{
	public class AttackGoal : AttackBaseGoal
	{
		public AttackGoal(Agent selfAgent)
			: base("AttackGoal", selfAgent)
		{
		}

		public override bool CanStart(bool isForced = false)
		{
			if (!MonoSingleton<CombatTargetManager>.IsInstantiated())
			{
				return false;
			}
			if (base.AgentOwner is CreatureBase { IsOnFire: not false })
			{
				return false;
			}
			IDamageDealAgent damageDealAgent = (IDamageDealAgent)base.AgentOwner;
			CreatureBase obj = damageDealAgent as CreatureBase;
			if (obj != null && obj.HasFainted)
			{
				return false;
			}
			DamageTakingAgentType damageTakingAgentType = damageDealAgent.CanAttackTypes();
			if (damageTakingAgentType == DamageTakingAgentType.None || !MonoSingleton<CombatTargetManager>.Instance.HasPreferredTarget(damageDealAgent))
			{
				return false;
			}
			if (base.AgentOwner is HumanoidInstance { OperatingSiegeWeapon: not false })
			{
				return false;
			}
			IDamageTakingAgent preferredTarget = MonoSingleton<CombatTargetManager>.Instance.GetPreferredTarget(damageDealAgent);
			if (preferredTarget is AnimalInstance animalInstance && damageDealAgent is HumanoidInstance humanoidInstance2)
			{
				if (!humanoidInstance2.IsWorker())
				{
					return true;
				}
				if (humanoidInstance2.WorkerBehaviour.IsDrafting)
				{
					return true;
				}
				IDamageTakingAgent preferredTarget2 = MonoSingleton<CombatTargetManager>.Instance.GetPreferredTarget(animalInstance);
				if (preferredTarget2 != null && (preferredTarget2.DamageAgentType & ((IDamageTakingAgent)base.AgentOwner).DamageAgentType) != DamageTakingAgentType.None)
				{
					return (preferredTarget.DamageAgentType & damageTakingAgentType) != 0;
				}
				return false;
			}
			return (preferredTarget.DamageAgentType & damageTakingAgentType) != 0;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			if (condition == GoalCondition.Incompletable && base.AgentOwner is HumanoidInstance humanoidInstance && humanoidInstance.IsEnemy() && CombatUtils.IsAlive(humanoidInstance))
			{
				humanoidInstance.CombatAi.ForceRefreshSensors();
				humanoidInstance.CombatAi.ForceRefreshReactions();
			}
		}

		public bool TryHotSwapTarget(IDamageTakingAgent target)
		{
			if (!CombatUtils.IsAlive(target) || !CombatUtils.IsAttackPossible(ownerAgent, target))
			{
				return false;
			}
			IDamageDealAgent agent = (IDamageDealAgent)base.AgentOwner;
			if (CombatUtils.IsNullOrDisposed(agent, target))
			{
				return false;
			}
			MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(agent, target);
			ownerAgent.SetTarget(target);
			return true;
		}
	}
}
