using System.Collections.Concurrent;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.CombatAi;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.CommanderAI.Utilities;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Tutorial;
using NSMedieval.Utils.TimeHelpers;
using NSMedieval.Village;
using NSMedieval.Village.Map.Pathfinding;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Unit Orders")]
	[Description("Issue attack order on target and wait until target destroyed")]
	public class AttackTargetBTAction : UnitsBTActionBaseThread
	{
		[RequiredField]
		public BBParameter<IDamageTakingAgent> target;

		public bool SpreadToNearbyTargets;

		private List<IDamageTakingAgent> targets;

		private Dictionary<IDamageTakingAgent, int> attackersOfTarget;

		private ConcurrentBag<(CommanderAIUnit, AttackOrder)> ordersToAssign;

		private List<CommanderAIUnit> unitsCopy;

		private Cooldown isAttackPossibleCheckCooldown;

		private bool isFirstTick;

		protected override string info
		{
			get
			{
				if (!SpreadToNearbyTargets)
				{
					return $"{base.info}: Attack {target}";
				}
				return $"{base.info}: Attack {target} (spread)";
			}
		}

		protected override int ThreadTickIntervalMinutes => 5;

		protected override void OnStart()
		{
			isFirstTick = true;
			if (targets == null)
			{
				targets = new List<IDamageTakingAgent>();
			}
			targets.Clear();
			isAttackPossibleCheckCooldown = Cooldown.FromNowMinutes(0, TutorialManager.IsTutorialActive);
			IDamageTakingAgent value = target.value;
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\UnitOrders\\AttackTargetBTAction.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Start, attack '");
				messageBuilder.AppendFormatted(value);
				messageBuilder.AppendLiteral("'");
			}
			Log.Debug(messageBuilder);
			if (CombatAiUtils.IsAgentDefeated(target.value) || base.Units == null || base.UnitCount == 0)
			{
				EndAction(success: false);
				return;
			}
			if (target.value.GetNode().HasFirePresence())
			{
				EndAction(success: false);
				return;
			}
			if (target.value is WorldObject obj && !PathfinderUtil.IsPathPossible(Repository<WalkableModelRepository, WalkableModel>.Instance.GetTestAgentWalkableDoors(), base.UnitForPathfinding.Humanoid.GetGridPosition(), obj))
			{
				EndAction(success: false);
				return;
			}
			targets.Add(value);
			base.OnStart();
		}

		protected override bool OnThread()
		{
			Log.Trace("Thread tick", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\UnitOrders\\AttackTargetBTAction.cs");
			if (ordersToAssign == null)
			{
				ordersToAssign = new ConcurrentBag<(CommanderAIUnit, AttackOrder)>();
			}
			ordersToAssign.Clear();
			if (attackersOfTarget == null)
			{
				attackersOfTarget = new Dictionary<IDamageTakingAgent, int>();
			}
			attackersOfTarget.Clear();
			if (unitsCopy == null)
			{
				unitsCopy = new List<CommanderAIUnit>();
			}
			unitsCopy.Clear();
			unitsCopy.AddRange(base.Units);
			if (targets == null)
			{
				targets = new List<IDamageTakingAgent>();
			}
			if (targets.Count == 0)
			{
				targets.Add(target.value);
			}
			IDamageTakingAgent damageTakingAgent = targets[0];
			if (SpreadToNearbyTargets)
			{
				int count = unitsCopy.Count;
				bool isEnabled;
				try
				{
					CombatAiUtils.GatherNearbyTargets(base.UnitForPathfinding.Humanoid, damageTakingAgent, targets, count, CommanderAIFilters.BuildingTypesToSpreadAttack);
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(43, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\UnitOrders\\AttackTargetBTAction.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Gathered ");
						messageBuilder.AppendFormatted(targets.Count);
						messageBuilder.AppendLiteral(" targets (maxTargets ");
						messageBuilder.AppendFormatted(count);
						messageBuilder.AppendLiteral(") for target ");
						messageBuilder.AppendFormatted(damageTakingAgent);
					}
					Log.Debug(messageBuilder);
				}
				catch
				{
					isEnabled = false;
					return isEnabled;
				}
			}
			else
			{
				targets.Clear();
				targets.Add(damageTakingAgent);
			}
			if (targets.Count == 0)
			{
				return false;
			}
			foreach (CommanderAIUnit item in unitsCopy)
			{
				if (item.Humanoid.HasDiedOrFainted)
				{
					continue;
				}
				IDamageTakingAgent nextBestTarget = GetNextBestTarget();
				if (nextBestTarget == null)
				{
					continue;
				}
				if (!isFirstTick && item.CurrentOrder is AttackOrder attackOrder && CheckCanAttack(item, attackOrder.Target))
				{
					if (item.Humanoid.GetGoapAgent()?.CurrentGoalName == "AttackGoal")
					{
						continue;
					}
					float num = item.Humanoid.GetPosition().DistanceSquared(nextBestTarget.GetPosition());
					float num2 = item.Humanoid.GetPosition().DistanceSquared(attackOrder.Target.GetPosition());
					if (num >= num2)
					{
						continue;
					}
				}
				attackersOfTarget.TryAdd(nextBestTarget, 0);
				attackersOfTarget[nextBestTarget]++;
				ordersToAssign.Add((item, CreateAttackOrder(nextBestTarget)));
			}
			return true;
		}

		protected override void OnDoneCallback(bool result)
		{
			if (!result)
			{
				EndAction(success: false);
				return;
			}
			(CommanderAIUnit, AttackOrder) result2;
			while (ordersToAssign.TryTake(out result2))
			{
				var (commanderAIUnit, _) = result2;
				if (!commanderAIUnit.Humanoid.HasDiedOrFainted && !commanderAIUnit.Humanoid.HasDisposed)
				{
					AttackOrder item = result2.Item2;
					commanderAIUnit.CurrentOrder = item;
				}
			}
			isFirstTick = false;
		}

		protected override void OnTick()
		{
			if (base.IsThreadJobRunning || base.IsWaitingForThreadJobDiscard)
			{
				return;
			}
			if (targets.Count == 0 || base.Units == null || base.UnitCount == 0)
			{
				EndAction(success: false);
			}
			else
			{
				if (!isAttackPossibleCheckCooldown.HasEnded)
				{
					return;
				}
				isAttackPossibleCheckCooldown = Cooldown.FromNowMinutes(5, TutorialManager.IsTutorialActive);
				bool flag = false;
				foreach (CommanderAIUnit unit in base.Units)
				{
					if (!(unit.CurrentOrder is AttackOrder attackOrder) || !CheckCanAttack(unit, attackOrder.Target, forceMelee: true))
					{
						unit.CurrentOrder = MoveOrder.Stop(unit);
						continue;
					}
					flag = true;
					break;
				}
				if (!flag)
				{
					EndAction(success: false);
				}
			}
		}

		private static bool CheckCanAttack(CommanderAIUnit unit, IDamageTakingAgent target, bool forceMelee = false)
		{
			if (CombatAiUtils.IsAgentDefeated(unit.Humanoid) || CombatAiUtils.IsAgentDefeated(target))
			{
				return false;
			}
			if (!(target is CreatureBase) && unit.Humanoid.Map.FirePresenceGrid.HasFirePresence(target.GetNode()))
			{
				return false;
			}
			if (!CombatUtils.IsAttackPossible(unit.Humanoid, target))
			{
				return false;
			}
			if (!MonoSingleton<CombatAttackerPositioningManager>.Instance.CanCreatePath(unit.Humanoid, target, executePathfinding: false, forceMelee))
			{
				return false;
			}
			return true;
		}

		private IDamageTakingAgent GetNextBestTarget()
		{
			if (targets.Count == 1)
			{
				if (!CombatAiUtils.IsAgentDefeated(targets[0]))
				{
					return targets[0];
				}
				return null;
			}
			return targets.MinItem((IDamageTakingAgent target) => attackersOfTarget.GetValueOrDefault(target, 0), null, delegate(IDamageTakingAgent target)
			{
				if (CombatAiUtils.IsAgentDefeated(target))
				{
					return false;
				}
				return (target is CreatureBase || !target.Map.FirePresenceGrid.HasFirePresence(target.GetNode())) ? true : false;
			});
		}

		protected override void OnStop()
		{
			Log.Debug("Stop", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\UnitOrders\\AttackTargetBTAction.cs");
		}
	}
}
