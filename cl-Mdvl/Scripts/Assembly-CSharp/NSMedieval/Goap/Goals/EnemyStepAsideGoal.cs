using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class EnemyStepAsideGoal : Goal
	{
		private HumanoidInstance enemyOwner;

		private Vector3 previousPosition;

		public override bool IsExemptFromConsecutiveFailsDisable => true;

		public EnemyStepAsideGoal(Agent selfAgent)
			: base("EnemyStepAsideGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
			enemyOwner = base.AgentOwner as HumanoidInstance;
			AddInitStep(new ThreadSequenceStep(null, PrepareThread));
		}

		public override bool CanStart(bool isForced = false)
		{
			MapNode node = enemyOwner.GetNode();
			if (node == null)
			{
				return false;
			}
			bool isEnabled;
			if (node.CreaturesCount < 3)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Enemy\\EnemyStepAsideGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("False because max creatures ");
					messageBuilder.AppendFormatted(enemyOwner);
				}
				Log.Trace(messageBuilder);
				return false;
			}
			if (enemyOwner.PathDriver.IsMoving || enemyOwner.PathDriver.TimeWithoutPath < 5f)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(26, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Enemy\\EnemyStepAsideGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("False because path driver ");
					messageBuilder.AppendFormatted(enemyOwner);
				}
				Log.Trace(messageBuilder);
				return false;
			}
			return true;
		}

		private bool PrepareThread()
		{
			MapNode node = enemyOwner.GetNode();
			if (node == null)
			{
				return false;
			}
			CreatureBase creatureBase = null;
			int num = int.MaxValue;
			bool flag = false;
			foreach (CreatureBase item in node.Map.CreaturesOnNodes[node.Index])
			{
				if (item is HumanoidInstance humanoidInstance && humanoidInstance.IsEnemy())
				{
					flag = flag || humanoidInstance.GetTarget() != null;
					if (item.UniqueId < num)
					{
						num = item.UniqueId;
						creatureBase = item;
					}
				}
			}
			if (!flag)
			{
				return false;
			}
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder;
			if (enemyOwner != creatureBase)
			{
				messageBuilder = new FVLogTraceInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Enemy\\EnemyStepAsideGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("False because not min id ");
					messageBuilder.AppendFormatted(enemyOwner);
				}
				Log.Trace(messageBuilder);
				return false;
			}
			foreach (MapNode item2 in FloodFillUtil.IterateFloodFillConnections(node, 30f, SpreadStopFilter))
			{
				if (!item2.IsWalkable || item2.HasFirePresence() || item2.WorldPosition.Distance(node.WorldPosition) < 1.5f || !PathfinderUtil.IsPathPossible(enemyOwner, item2) || item2.CreaturesCount >= 3)
				{
					continue;
				}
				if (item2.Map.CreaturesOnNodes.TryGetValue(item2.Index, out var value))
				{
					bool flag2 = false;
					foreach (CreatureBase item3 in value)
					{
						if (item3 is HumanoidInstance humanoidInstance2 && humanoidInstance2.IsWorker())
						{
							flag2 = true;
							break;
						}
					}
					if (flag2)
					{
						continue;
					}
				}
				messageBuilder = new FVLogTraceInterpolationHandler(26, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Enemy\\EnemyStepAsideGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Found stepAside node ");
					messageBuilder.AppendFormatted(item2.Position);
					messageBuilder.AppendLiteral(" for ");
					messageBuilder.AppendFormatted(enemyOwner);
				}
				Log.Trace(messageBuilder);
				SetTarget(TargetIndex.A, new TargetObject(item2.Position));
				previousPosition = enemyOwner.GetPosition();
				isEnabled = true;
				return isEnabled;
			}
			messageBuilder = new FVLogTraceInterpolationHandler(28, 1, out var isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Enemy\\EnemyStepAsideGoal.cs");
			if (isEnabled2)
			{
				messageBuilder.AppendLiteral("False because no node found ");
				messageBuilder.AppendFormatted(enemyOwner);
			}
			Log.Trace(messageBuilder);
			return false;
			static bool SpreadStopFilter(MapNode mapNode)
			{
				if (!mapNode.IsWalkable || mapNode.HasFirePresence())
				{
					return true;
				}
				if (mapNode.CreaturesCount == 0)
				{
					return false;
				}
				if (!mapNode.Map.CreaturesOnNodes.TryGetValue(mapNode.Index, out var value2))
				{
					return false;
				}
				foreach (CreatureBase item4 in value2)
				{
					if (item4 is HumanoidInstance humanoidInstance3 && humanoidInstance3.IsWorker())
					{
						return true;
					}
				}
				return false;
			}
		}

		public override bool AgentTypeCheck()
		{
			if (base.AgentOwner is HumanoidInstance humanoidInstance)
			{
				return humanoidInstance.IsEnemy();
			}
			return false;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition, previousPosition);
			yield return GeneralActions.Wait(2f);
		}
	}
}
