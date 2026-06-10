using System.Collections.Generic;
using NSEipix;
using NSMedieval.CombatAi;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class FollowMoveOrderGoal : FollowOrderBaseGoal<MoveOrder>
	{
		private const float FollowRange = 2f;

		private readonly HumanoidInstance HumanoidOwner;

		public FollowMoveOrderGoal(Agent selfAgent)
			: base(selfAgent, "FollowMoveOrderGoal")
		{
			HumanoidOwner = base.AgentOwner as HumanoidInstance;
			AddInitStep(new ThreadSequenceStep(null, SetMoveTarget));
		}

		protected override bool CanStartFollowingOrder()
		{
			return true;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			if (!HasTarget(TargetIndex.A))
			{
				GoapAction goapAction = GeneralActions.Wait(1f);
				goapAction.OnInit = delegate
				{
					if (HumanoidOwner.CombatAi.TryGetState<IDamageDealAgent>(CombatAiState.NearestHostile, out var value))
					{
						base.EnemyOwner.FaceObject(value.GetPosition());
					}
					else if (base.CurrentOrder.LookAtPoint != default(Vector3))
					{
						base.EnemyOwner.FaceObject(base.CurrentOrder.LookAtPoint);
					}
				};
				yield return goapAction;
			}
			else if (base.CurrentOrder.FollowCreature != null)
			{
				yield return GoToActions.GoToCreatureTarget(TargetIndex.A, 2f).FailIfTargetDisposedOrNull(TargetIndex.A);
			}
			else
			{
				GoapAction goapAction2 = GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition, base.CurrentOrder.LookAtPoint);
				goapAction2.FailIfTargetBecomesFireDangerous(TargetIndex.A);
				yield return goapAction2;
			}
		}

		private bool SetMoveTarget()
		{
			if (base.CurrentOrder.FollowCreature != null)
			{
				SetTarget(TargetIndex.A, new TargetObject(base.CurrentOrder.FollowCreature));
				return true;
			}
			Vec3Int nodePos = base.CurrentOrder.Destination.ToGridVec3Int();
			MapNode node = Map.GetNode(nodePos);
			if (Map.FirePresenceGrid.HasFirePresence(in nodePos))
			{
				using PooledList<MapNode> pooledList = FloodFillUtil.ScoreWalkable(HumanoidOwner, node, 20f, 100, (MapNode mapNode) => (float)(-Map.FirePresenceGrid.GetFirePresence(mapNode)) * 100f - (float)(int)mapNode.CreaturesCount, debugDraw: false, preferNonWater: false, null, (MapNode mapNode) => mapNode.CreaturesCount == 0 && !Map.FirePresenceGrid.HasFirePresence(mapNode));
				if (pooledList.Count == 0)
				{
					return false;
				}
				node = pooledList[0];
				nodePos = node.Position;
			}
			if (base.EnemyOwner.GetPosition().Distance(nodePos.ToVector3World()) > 0.5f)
			{
				SetTarget(TargetIndex.A, new TargetObject(nodePos));
			}
			return true;
		}
	}
}
