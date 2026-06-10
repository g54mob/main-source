using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Goap;
using NSMedieval.Goap.Goals;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.View;
using UnityEngine;

namespace NSMedieval.State
{
	[FVSerializableKey("EnemyBehaviour", "EnemyBehavior")]
	public class EnemyBehaviour : HumanoidBehaviour
	{
		private OrderBase currentOrder;

		public override BehaviourType BehaviourType => BehaviourType.Enemy;

		public int RaidId { get; set; }

		public OrderBase CurrentOrder
		{
			get
			{
				return currentOrder;
			}
			set
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder;
				if (base.Humanoid.IsLeaving)
				{
					messageBuilder = new FVLogTraceInterpolationHandler(52, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\EnemyBehaviour.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Tried to set order of humanoid but they are leaving ");
						messageBuilder.AppendFormatted(base.Humanoid);
					}
					Log.Trace(messageBuilder);
					return;
				}
				bool flag = OrderUtil.ShouldAbortGoapAgent(base.Humanoid, currentOrder, value);
				currentOrder = value;
				if (flag)
				{
					base.Humanoid?.GetGoapAgent()?.Abort();
				}
				messageBuilder = new FVLogTraceInterpolationHandler(44, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\EnemyBehaviour.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Set order (abortAgent = ");
					messageBuilder.AppendFormatted(flag);
					messageBuilder.AppendLiteral(") for agent '");
					messageBuilder.AppendFormatted(base.Humanoid?.GetFullName());
					messageBuilder.AppendLiteral("' -> '");
					messageBuilder.AppendFormatted(value);
					messageBuilder.AppendLiteral("'");
				}
				Log.Trace(messageBuilder);
				currentOrder?.OnAssigned(this);
			}
		}

		protected override string HumanTypeId => "enemy";

		public CombatAiAgent CombatAi => base.Humanoid.CombatAi;

		public bool IsPartOfCommanderAIGroup => CurrentOrder != null;

		public override string IndicatorPrefabName => "enemy_indicator";

		public EnemyBehaviour()
		{
		}

		protected override void OnActivate()
		{
			base.OnActivate();
			base.Humanoid.SetWalkableModel(base.Humanoid.CurrentHumanType.WalkableModelAggressive);
			base.Humanoid.SetCombatAiAgent("EnemyDefaultAiAgent");
			base.Humanoid.CombatAi.SetState(CombatAiState.IsAggressive, true);
			base.GoapAgent.ForceNextGoal("AttackGoal");
			SetAnimCombatAlert(newValue: true);
		}

		public override void OnAfterSpawn()
		{
			base.OnAfterSpawn();
			if (GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				base.Humanoid.SetCombatAiAgent("EnemyCampBehaviour");
				base.Humanoid.CombatAi.SetState(CombatAiState.IsAggressive, true);
				base.GoapAgent.ForceNextGoal("AttackGoal");
				base.GoapAgent.GoalScheduler.AddToPool(new EnemyIdlePatrolGoal(base.GoapAgent), enableGoal: true);
				base.GoapAgent.GoalScheduler.DisableGoal("EnemyIdleGoal");
			}
		}

		protected override void OnDeactivate()
		{
			base.OnDeactivate();
			SetAnimCombatAlert(newValue: false);
		}

		private void SetAnimCombatAlert(bool newValue)
		{
			NPCView agentView = base.Humanoid.GetAgentView<NPCView>();
			if (agentView != null)
			{
				agentView.TrySetParameter("IsCombatAlert", newValue);
			}
		}

		protected override Agent CreateGoapAgent()
		{
			return new EnemyGoapAgent(base.Humanoid);
		}

		public override string GetGoapAgentId()
		{
			return "enemy";
		}

		public override string GetMultiselectName()
		{
			return "enemy";
		}

		public override void OnKilled(IDamageDealAgent killer)
		{
			if (RaidId != 0)
			{
				MonoSingleton<AchievementManager>.Instance.UnlockAchievement("KILL_RAIDER");
			}
			if (!MonoSingleton<AchievementManager>.Instance.IsUnlocked("KILL_ENEMY_TREBUCHET") && killer is SiegeWeaponProjectileInstance siegeWeaponProjectileInstance && siegeWeaponProjectileInstance.Blueprint.GetID().Contains("trebuchet_ammo"))
			{
				MonoSingleton<AchievementManager>.Instance.UnlockAchievement("KILL_ENEMY_TREBUCHET");
			}
		}

		public override void OnTrapTriggered(TrapComponentInstance trapInstance)
		{
			if (trapInstance.Operational)
			{
				CombatHitManager.DealTrapDamage(base.Humanoid, trapInstance);
			}
		}

		public IDamageTakingAgent GetTarget()
		{
			return base.Humanoid.GetTarget();
		}

		public Vector3 GetPosition()
		{
			return base.Humanoid.GetPosition();
		}

		public Vec3Int GetGridPosition()
		{
			return base.Humanoid.GetGridPosition();
		}

		public override void Serialize(FVSerializer serializer)
		{
			serializer.Write("raidId", RaidId);
		}

		public EnemyBehaviour(FVDeserializer deserializer)
			: base(deserializer)
		{
			RaidId = deserializer.ReadInt("raidId");
		}
	}
}
