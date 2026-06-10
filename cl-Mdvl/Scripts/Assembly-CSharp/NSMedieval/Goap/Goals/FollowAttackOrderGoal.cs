using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Village.Map;

namespace NSMedieval.Goap.Goals
{
	public class FollowAttackOrderGoal : FollowOrderBaseGoal<AttackOrder>
	{
		public FollowAttackOrderGoal(Agent selfAgent)
			: base(selfAgent, "FollowAttackOrderGoal")
		{
			AddInitStep(new ThreadSequenceStep(null, PrepareAlternativeNode));
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			base.CombatAi?.SetState(CombatAiState.OperatingTrebuchet, null);
		}

		protected override bool CanStartFollowingOrder()
		{
			if (CombatAiUtils.IsAgentDefeated(base.CurrentOrder.Target))
			{
				return false;
			}
			SiegeWeaponComponentInstance siegeWeapon = base.CurrentOrder.SiegeWeapon;
			if (siegeWeapon != null && siegeWeapon.CanEnemyStartAttackPreCheck())
			{
				return true;
			}
			IDamageTakingAgent preferredTarget = MonoSingleton<CombatTargetManager>.Instance.GetPreferredTarget((IDamageDealAgent)base.AgentOwner);
			bool result = preferredTarget != base.CurrentOrder.Target || !(base.Agent.GetCurrentGoal() is AttackGoal);
			if (preferredTarget != null && !base.CurrentOrder.HasSuccessfullyHotSwapped && !(preferredTarget is CreatureBase) && preferredTarget.GetNode().HasFirePresence())
			{
				result = false;
			}
			return result;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			if (HasTarget(TargetIndex.A))
			{
				yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.Touch);
				yield return GeneralActions.Wait(1f);
				yield break;
			}
			GoapAction goapAction = new GoapAction("StartAttack");
			goapAction.OnInit = delegate
			{
				if (base.CurrentOrder.SiegeWeapon != null)
				{
					base.CombatAi.SetState(CombatAiState.OperatingTrebuchet, base.CurrentOrder.SiegeWeapon);
					base.CurrentOrder.SiegeWeapon.SetTarget(base.CurrentOrder.Target);
					if (base.CurrentOrder.SiegeWeapon.CanEnemyStartAttack())
					{
						base.CurrentOrder.SiegeWeapon.IsOperatorReady = true;
					}
					base.CurrentOrder.SiegeWeapon.EnemyStartAttack();
				}
				else
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(53, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Enemy\\FollowOrder\\FollowAttackOrderGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Siege weapon is null, following regular attack order ");
						messageBuilder.AppendFormatted(base.AgentOwner);
					}
					Log.Trace(messageBuilder);
					MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget((IDamageDealAgent)base.AgentOwner, base.CurrentOrder.Target);
					base.Agent.ForceNextGoal("AttackGoal");
				}
			};
			yield return goapAction;
		}

		private bool PrepareAlternativeNode()
		{
			if (base.CurrentOrder?.Target?.GetNode() == null)
			{
				return false;
			}
			if (base.CurrentOrder.SiegeWeapon != null)
			{
				return true;
			}
			MapNode node = base.CurrentOrder.Target.GetNode();
			if (node == null)
			{
				return false;
			}
			if (!CombatUtils.IsAttackPossible(base.EnemyOwner.Humanoid, base.CurrentOrder.Target))
			{
				return SetNearbyReachableNode(node);
			}
			if (!MonoSingleton<CombatAttackerPositioningManager>.Instance.CanCreatePath(base.EnemyOwner.Humanoid, base.CurrentOrder.Target))
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(20, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Enemy\\FollowOrder\\FollowAttackOrderGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Can't reach ");
					messageBuilder.AppendFormatted(node);
					messageBuilder.AppendLiteral(", agent ");
					messageBuilder.AppendFormatted(base.EnemyOwner.Humanoid?.GetFullName());
				}
				Log.Trace(messageBuilder);
				return SetNearbyReachableNode(node);
			}
			return true;
		}

		private bool SetNearbyReachableNode(MapNode startNode)
		{
			SetTarget(TargetIndex.A, new TargetObject(startNode.Position));
			return true;
		}
	}
}
