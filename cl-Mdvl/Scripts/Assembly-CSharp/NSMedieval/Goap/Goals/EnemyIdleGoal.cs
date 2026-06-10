using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class EnemyIdleGoal : Goal
	{
		private const float EnemyWaitTimeMin = 1f;

		private const float EnemyWaitTimeMax = 2f;

		private ActiveRaidInfo raidInfo;

		private MapNode reservedIdleNode;

		private Vector3 facePoint;

		private readonly EnemyBehaviour enemyOwner;

		public EnemyIdleGoal(Agent selfAgent)
			: base("EnemyIdleGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
			enemyOwner = ((HumanoidInstance)base.AgentOwner).EnemyBehaviour;
			facePoint.x = float.NaN;
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IPathfindingAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (raidInfo == null && enemyOwner.RaidId != 0)
			{
				raidInfo = ActiveRaidInfo.GetById(enemyOwner.RaidId);
			}
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			if (creatureBase.HasDisposed || creatureBase.IsOnFire)
			{
				return false;
			}
			return true;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			if (reservedIdleNode != null)
			{
				enemyOwner.Humanoid.Map.IdlePointManager.ReleaseIdleNodeReservation(reservedIdleNode);
				reservedIdleNode = null;
			}
			facePoint.x = float.NaN;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			bool weMoved = false;
			if (TryGetTarget(TargetIndex.A, out var target))
			{
				Vec3Int rhs = target.ReachablePosition;
				if (enemyOwner.GetGridPosition() != rhs && PathfinderUtil.IsPathPossible(base.AgentOwner as IPathfindingAgent, rhs))
				{
					weMoved = true;
					yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition);
				}
			}
			if (!float.IsNaN(facePoint.x))
			{
				GoapAction goapAction = GeneralActions.Instant("FacePoint");
				goapAction.OnInit = delegate
				{
					enemyOwner.Humanoid.GetAgentView<NPCView>()?.FaceObject(facePoint);
				};
				yield return goapAction;
			}
			float time = (weMoved ? 0.1f : Random.Range(1f, 2f));
			yield return GeneralActions.Wait(time);
		}

		private bool PrepareData()
		{
			if (LoadingController.IsSceneTransition || !MonoSingleton<World>.IsInstantiated())
			{
				return false;
			}
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			if (CombatUtils.IsNullOrDisposed(creatureBase))
			{
				return false;
			}
			if (raidInfo != null && !raidInfo.HasEngaged)
			{
				return true;
			}
			if (VillageManager.ActiveVillage.Map.RaidManager.PointOfInterestManager.TryGetPointOfInterest(creatureBase, out var point))
			{
				facePoint = point;
			}
			MapNode node = creatureBase.GetNode();
			if (node.CreaturesCount <= 1 && creatureBase.Map.IdlePointManager.TryReserveIdleNode(node, creatureBase))
			{
				reservedIdleNode = node;
				return true;
			}
			MapNode mapNode = null;
			if (!creatureBase.Map.IdlePointManager.IsUsingReservedIdlePoint(creatureBase))
			{
				foreach (MapNode item in FloodFillUtil.IterateFloodFillConnections(node, 30f))
				{
					if (item.CreaturesCount <= 0 && creatureBase.Map.IdlePointManager.TryReserveIdleNode(item, creatureBase))
					{
						mapNode = item;
						reservedIdleNode = item;
						break;
					}
				}
			}
			if (mapNode != null && mapNode != node)
			{
				SetTarget(TargetIndex.A, new TargetObject(mapNode.Position));
			}
			return true;
		}
	}
}
