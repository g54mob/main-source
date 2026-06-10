using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.CombatAi;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Goap;
using NSMedieval.Goap.Goals;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Tutorial;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Utils.TimeHelpers;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

public class EnemySelfDefenseGoal : AttackBaseGoal
{
	private const float MinPursuitTime = 10f;

	private const float DefaultGuardRadius = 10f;

	private readonly EnemyBehaviour enemyOwner;

	private readonly float tickInterval;

	private float lastTickTime;

	private float attackStartTime;

	private Cooldown canStartCooldown;

	public override bool IsExemptFromConsecutiveFailsDisable => true;

	public EnemySelfDefenseGoal(Agent selfAgent)
		: base("EnemySelfDefenseGoal", selfAgent)
	{
		tickInterval = 0.5f + Random.Range(0.2f, 0.4f);
		canStartCooldown = Cooldown.FromNowMinutes(1, TutorialManager.IsTutorialActive);
		enemyOwner = (base.AgentOwner as HumanoidInstance)?.EnemyBehaviour;
	}

	protected override void AddInitSteps()
	{
		AddInitStep(new ThreadSequenceStep(SetStartTime, PickBestTarget));
	}

	public override bool CanStart(bool isForced = false)
	{
		if (enemyOwner.CurrentOrder == null || !canStartCooldown.HasEnded)
		{
			return false;
		}
		canStartCooldown = Cooldown.FromNowMinutes(10, TutorialManager.IsTutorialActive);
		if (enemyOwner.CurrentOrder is ConstructBuildingOrder constructBuildingOrder && PathfinderUtil.IsPathPossible(enemyOwner.Humanoid, constructBuildingOrder.Position))
		{
			return false;
		}
		if (enemyOwner.CurrentOrder is DigVoxelOrder digVoxelOrder && PathfinderUtil.IsPathPossible(enemyOwner.Humanoid, digVoxelOrder.VoxelPosition))
		{
			return false;
		}
		if (enemyOwner.CurrentOrder is AttackOrder attackOrder && attackOrder.Target is CreatureBase)
		{
			if (attackOrder.IsSiegePathObstacle)
			{
				return false;
			}
			if (attackOrder.Target is CreatureBase)
			{
				float num = attackOrder.Target.GetPosition().Distance(ownerAgent.GetPosition());
				if (!CombatAiUtils.IsAgentDefeated(attackOrder.Target) && num < 20f)
				{
					return false;
				}
			}
		}
		if (!MonoSingleton<CombatTargetManager>.IsInstantiated())
		{
			return false;
		}
		if (!enemyOwner.CombatAi.IsStateSet(CombatAiState.Fainted) && !enemyOwner.CombatAi.IsStateSet(CombatAiState.EnemyIsRetreating))
		{
			HumanoidInstance obj = base.AgentOwner as HumanoidInstance;
			if (obj == null || !obj.IsLeaving)
			{
				return true;
			}
		}
		return false;
	}

	protected override void OnTick()
	{
		if (Time.unscaledTime - lastTickTime < tickInterval)
		{
			return;
		}
		lastTickTime = Time.unscaledTime;
		if (ownerAgent.GetTarget() is IDamageDealAgent damageDealAgent && (!(damageDealAgent.GetTarget() is HumanoidInstance humanoidInstance) || !humanoidInstance.IsEnemy()) && !(Time.unscaledTime - attackStartTime < 10f))
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Enemy\\EnemySelfDefenseGoal.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Target disengaged, I will too (");
				messageBuilder.AppendFormatted(enemyOwner.Humanoid.GetFullName());
				messageBuilder.AppendLiteral(")");
			}
			Log.Trace(messageBuilder);
			EndGoalWith(GoalCondition.Succeeded);
		}
	}

	private bool SetStartTime()
	{
		attackStartTime = Time.unscaledTime;
		return true;
	}

	private bool PickBestTarget()
	{
		float num = 10f;
		if (enemyOwner.CurrentOrder is MoveOrder moveOrder)
		{
			num = moveOrder.GuardModeRadius;
		}
		using PooledList<IDamageDealAgent> pooledList = ListPool<IDamageDealAgent>.GetJanitor();
		foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
		{
			if (!(key.Distance(enemyOwner.Humanoid) > num) && key.GetTarget() is HumanoidInstance humanoidInstance && humanoidInstance.Distance(enemyOwner.Humanoid) < num && humanoidInstance.IsEnemy() && !key.HasDiedOrFainted && MonoSingleton<CombatAttackerPositioningManager>.Instance.CanCreatePath(enemyOwner.Humanoid, key))
			{
				pooledList.Add(key);
			}
		}
		foreach (AnimalInstance animal in MonoSingleton<AnimalManager>.Instance.GetAnimals(AnimalType.Pet))
		{
			if (!(animal.Distance(enemyOwner.Humanoid) > num) && animal.GetTarget() is HumanoidInstance humanoidInstance2 && humanoidInstance2.Distance(enemyOwner.Humanoid) < num && humanoidInstance2.IsEnemy() && !animal.HasDiedOrFainted && MonoSingleton<CombatAttackerPositioningManager>.Instance.CanCreatePath(enemyOwner.Humanoid, animal))
			{
				pooledList.Add(animal);
			}
		}
		IDamageTakingAgent bestTarget = null;
		float num2 = float.MinValue;
		foreach (IDamageDealAgent item in pooledList)
		{
			float num3 = enemyOwner.Humanoid.Distance(item);
			float num4 = 100f - num3 + (100f - 10f * (float)item.CombatAi.GetState<int>(CombatAiState.TargetersCount));
			if (num4 > num2)
			{
				num2 = num4;
				bestTarget = item as IDamageTakingAgent;
			}
		}
		if (bestTarget == null)
		{
			return false;
		}
		bool isEnabled;
		FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(30, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Enemy\\EnemySelfDefenseGoal.cs");
		if (isEnabled)
		{
			messageBuilder.AppendLiteral("SelfDefenseGoal ");
			messageBuilder.AppendFormatted(enemyOwner.Humanoid.GetFullName());
			messageBuilder.AppendLiteral(" - attacking: ");
			messageBuilder.AppendFormatted(bestTarget.GetLocalizedName());
		}
		Log.Trace(messageBuilder);
		MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThreadBlocking(delegate
		{
			MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(base.AgentOwner as IDamageDealAgent, bestTarget);
			ownerAgent.SetTarget(bestTarget);
		});
		return true;
	}
}
