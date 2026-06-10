using NSEipix;
using NSEipix.Base;
using NSEipix.TaskManager;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village.Map;

namespace NSMedieval.CombatAi
{
	public class AttackAiActionGoal : CombatAiActionGoal
	{
		private IDamageTakingAgent startTarget;

		private Task buildingAbortAttackTask;

		public AttackAiActionGoal(Agent selfAgent)
			: base("AttackAiActionGoal", selfAgent)
		{
		}

		public AttackAiActionGoal(string id, Agent selfAgent)
			: base(id, selfAgent)
		{
		}

		public override void Start()
		{
			base.Start();
			StartGoal();
		}

		public override bool CanStart(bool isForced = false)
		{
			if (!MonoSingleton<CombatTargetManager>.IsInstantiated())
			{
				return false;
			}
			if (base.CombatAi.IsStateSet(CombatAiState.Fainted))
			{
				return false;
			}
			if (!base.CombatAi.IsStateSet(CombatAiState.EnemyIsRetreating))
			{
				HumanoidInstance obj = base.AgentOwner as HumanoidInstance;
				if (obj == null || !obj.IsLeaving)
				{
					IDamageTakingAgent damageTakingAgent = base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.PreferedTarget);
					if (damageTakingAgent == null)
					{
						return false;
					}
					if (startTarget != null && startTarget != damageTakingAgent)
					{
						return false;
					}
					if (damageTakingAgent is HumanoidInstance humanoidInstance && humanoidInstance.IsEnemy() && base.CombatAgent is HumanoidInstance humanoidInstance2 && humanoidInstance2.IsEnemy())
					{
						MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(base.CombatAgent);
						return false;
					}
					if (damageTakingAgent is CreatureBase creatureBase)
					{
						if (!creatureBase.HasFainted)
						{
							return CombatUtils.IsAlive(damageTakingAgent);
						}
						return false;
					}
					return true;
				}
			}
			return false;
		}

		protected virtual void StartGoal()
		{
			startTarget = base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.PreferedTarget);
			ForceGoapAgentGoal("AttackGoal");
			MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent += OnBuildingDestroyed;
		}

		protected override bool ShouldAbort()
		{
			IDamageTakingAgent preferredTarget = MonoSingleton<CombatTargetManager>.Instance.GetPreferredTarget(base.CombatAgent);
			if (base.AgentOwner is AnimalInstance && preferredTarget is AnimalInstance { AnimalType: not AnimalType.Wild, AnimalType: not AnimalType.WildAggressive } animalInstance)
			{
				MapNode node = animalInstance.GetNode();
				if (node != null && (node.Map.ProtectorCreatureManager.IsProtected(node.Index) || node.Map.ProtectorBuildingManager.IsProtected(node.Index)))
				{
					MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(base.CombatAgent, null);
					return true;
				}
			}
			if (preferredTarget is BaseBuildingInstance baseBuildingInstance)
			{
				DoorComponentInstance componentInstance = baseBuildingInstance.Map.DoorComponentManager.GetComponentInstance(baseBuildingInstance);
				if (componentInstance != null && (componentInstance.LockState == LockState.ForcedOpen || componentInstance.LockState == LockState.AlwaysOpen))
				{
					MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(base.CombatAgent, null);
					return true;
				}
			}
			return false;
		}

		protected override void OnEnd()
		{
			base.OnEnd();
			startTarget = null;
			MonoSingleton<ConstructionController>.Instance.DestroyBuildingEvent -= OnBuildingDestroyed;
			buildingAbortAttackTask?.Stop();
			buildingAbortAttackTask = null;
			Agent goapAgent = GetGoapAgent();
			if (goapAgent != null && (goapAgent.CurrentGoalName.Equals("AttackGoal") || goapAgent.CurrentGoalName.Equals("HuntingGoal")))
			{
				goapAgent.Abort();
			}
		}

		private void OnBuildingDestroyed(BaseBuildingInstance building)
		{
			if (!(startTarget is BaseBuildingInstance) || buildingAbortAttackTask != null || !building.OwnedByPlayer() || !MonoSingleton<CombatTargetManager>.IsInstantiated())
			{
				return;
			}
			buildingAbortAttackTask = MonoSingleton<TaskController>.Instance.WaitFor(1f).Then(delegate
			{
				if (MonoSingleton<CombatTargetManager>.IsInstantiated() && base.CombatAi != null && !base.CombatAi.HasDisposed && base.CombatAi.GetCurrentGoal() == this)
				{
					MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(base.CombatAgent, null);
					base.CombatAi.Abort();
				}
			});
		}
	}
}
