using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Tutorial;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Utils.TimeHelpers;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	public class StandAroundObjectInstance
	{
		private float GuardModeRadius = 30f;

		private float FollowHisteresis = 7f;

		private ICollection<CommanderAIUnit> units;

		private IGoapTargetable target;

		private Vec3Int previousPosition;

		private List<Vec3Int> generatedPoints;

		private float desiredSpacing;

		private VillageMap map;

		private Cooldown standingCooldown = new Cooldown(TutorialManager.IsTutorialActive);

		private bool isStanding;

		public StandAroundObjectInstance(ICollection<CommanderAIUnit> units, IGoapTargetable target, float spacing, VillageMap map)
		{
			this.units = units;
			this.target = target;
			desiredSpacing = spacing;
			this.map = map;
			previousPosition = target.GetGridPosition();
			generatedPoints = ListPool<Vec3Int>.Get();
			if (units.Count != 0)
			{
				if (this.target is CreatureBase creature)
				{
					isStanding = false;
					FollowTarget(creature);
				}
				else
				{
					isStanding = true;
					StandAroundTarget();
				}
			}
		}

		public bool Tick()
		{
			if (target == null || units == null || target.HasDisposed || generatedPoints == null)
			{
				return false;
			}
			if (target is CreatureBase { HasDiedOrFainted: not false })
			{
				return false;
			}
			if (units.Count == 0)
			{
				return true;
			}
			bool flag = false;
			foreach (Vec3Int generatedPoint in generatedPoints)
			{
				Vec3Int nodePos = generatedPoint;
				if (map.FirePresenceGrid.HasFirePresence(in nodePos))
				{
					flag = true;
					break;
				}
			}
			if (!flag && previousPosition.Distance(target.GetGridPosition()) < FollowHisteresis)
			{
				if (!isStanding && standingCooldown.HasEnded)
				{
					isStanding = true;
					StandAroundTarget();
				}
				return true;
			}
			isStanding = false;
			standingCooldown = Cooldown.FromNowMinutes(5, TutorialManager.IsTutorialActive);
			previousPosition = target.GetGridPosition();
			if (target is CreatureBase creatureBase2 && creatureBase2.PathDriver.IsMoving)
			{
				FollowTarget(creatureBase2);
			}
			else
			{
				isStanding = true;
				StandAroundTarget();
			}
			return true;
		}

		private void FollowTarget(CreatureBase creature)
		{
			generatedPoints.Clear();
			foreach (CommanderAIUnit unit in units)
			{
				if (!unit.Humanoid.HasDiedOrFainted && !unit.Humanoid.HasDisposed && !(unit.Humanoid.GetGoapAgent()?.GetCurrentGoal()?.GetType() == typeof(EnemySelfDefenseGoal)) && (!(unit.CurrentOrder is MoveOrder moveOrder) || moveOrder.FollowCreature != creature))
				{
					unit.CurrentOrder = new MoveOrder(creature, GuardModeRadius);
				}
			}
		}

		private void StandAroundTarget()
		{
			generatedPoints.Clear();
			MapNode startNode = null;
			HumanoidInstance humanoid = units.First().Humanoid;
			MapNode node = map.GetNode(target.GetGridPosition());
			if (target is WorldObject worldObject && node.IsWalkable)
			{
				Vec3Int lhs = worldObject.GetFirstReachablePosition(humanoid);
				if (lhs != Vec3Int.zero)
				{
					startNode = map.GetNode(lhs);
				}
			}
			if (startNode == null)
			{
				startNode = node;
			}
			int maxNodes = units.Count + (int)(desiredSpacing * desiredSpacing);
			using (PooledList<MapNode> pooledList = FloodFillUtil.ScoreWalkable(humanoid, startNode, 100f, maxNodes, delegate(MapNode mapNode)
			{
				float magnitude = (startNode.WorldPosition.ToVector2XZ() - mapNode.WorldPosition.ToVector2XZ()).magnitude;
				float num = 1000f * ((magnitude > desiredSpacing) ? 1f : 0f);
				if (mapNode.IsWater)
				{
					num -= 2000f;
				}
				if (startNode.Position.y != mapNode.Position.y)
				{
					num -= 500f;
				}
				return num;
			}, debugDraw: false, preferNonWater: true, DoorSpreadStopFilter, null, (MapNode mapNode) => !mapNode.HasFirePresence()))
			{
				foreach (MapNode item in pooledList)
				{
					generatedPoints.Add(item.Position);
				}
				using IEnumerator<CommanderAIUnit> enumerator2 = units.GetEnumerator();
				foreach (Vec3Int generatedPoint in generatedPoints)
				{
					if (!enumerator2.MoveNext())
					{
						break;
					}
					CommanderAIUnit current3 = enumerator2.Current;
					if (!current3.Humanoid.HasDiedOrFainted && !current3.Humanoid.HasDisposed && !(current3.Humanoid.GetGoapAgent()?.GetCurrentGoal()?.GetType() == typeof(EnemySelfDefenseGoal)))
					{
						Vector3 position = target.GetPosition();
						Vector3 vector = generatedPoint.ToVector3World();
						if (!(current3.CurrentOrder is MoveOrder moveOrder) || moveOrder.Destination != vector || moveOrder.LookAtPoint != position)
						{
							current3.CurrentOrder = new MoveOrder(vector, position, GuardModeRadius);
						}
					}
				}
			}
			static bool DoorSpreadStopFilter(MapNode mapNode)
			{
				return (mapNode.Tag & (MapNodeTags.DoorWorkerWalkable | MapNodeTags.DoorCompletelyLocked | MapNodeTags.DoorAlwaysOpen)) != 0;
			}
		}

		public void Dispose()
		{
			ListPool<Vec3Int>.Return(generatedPoints);
			generatedPoints = null;
		}
	}
}
