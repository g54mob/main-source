using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Goap.Goals
{
	public class LeaveMapGoal : Goal
	{
		public LeaveMapGoal(Agent selfAgent)
			: base("LeaveMapGoal", selfAgent)
		{
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override bool AgentTypeCheck()
		{
			if (base.AgentOwner is IStatsOwner)
			{
				return base.AgentOwner is IPathfindingAgent;
			}
			return false;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (base.AgentOwner is AnimalInstance)
			{
				return true;
			}
			return ((IStatsOwner)base.AgentOwner).Stats.GetStat(StatType.Mood).Current <= 1f;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.Touch).WithMovementSpeedMultiplier(0.7f);
			yield return new GoapAction("LeftMap")
			{
				OnInit = delegate
				{
					CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
					creatureBase.DestroyStorage();
					creatureBase.DestroyEquipment();
					HumanoidInstance workerHumanoid = creatureBase as HumanoidInstance;
					if (workerHumanoid != null && workerHumanoid.WorkerBehaviour != null)
					{
						MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
						{
							workerHumanoid.DontSpawnCarcassOnDispose = true;
							MonoSingleton<WorkerController>.Instance.RemoveWorker(workerHumanoid);
							MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("worker_left_mood_message", workerHumanoid));
						});
					}
					else
					{
						HumanoidInstance enemyInstance = creatureBase as HumanoidInstance;
						if (enemyInstance != null && enemyInstance.IsEnemy())
						{
							MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
							{
								if (enemyInstance.IsTrader())
								{
									AnimalInstance[] array = enemyInstance.Pets.ToArray();
									foreach (AnimalInstance animal in array)
									{
										MonoSingleton<AnimalManager>.Instance.RemoveAnimal(animal, dropResources: false);
									}
								}
								MonoSingleton<NPCController>.Instance.RemoveNPC(enemyInstance);
							});
						}
						else
						{
							AnimalInstance animalInstance = creatureBase as AnimalInstance;
							if (animalInstance != null)
							{
								MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
								{
									MonoSingleton<AnimalManager>.Instance.RemoveAnimal(animalInstance, dropResources: false);
								});
							}
						}
					}
				}
			};
		}

		private bool PrepareData()
		{
			IPathfindingAgent pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
			if (!(pathfindingAgent is CreatureBase creatureBase))
			{
				return false;
			}
			Vec3Int creatureGridPosition = creatureBase.GetGridPosition();
			if (!MonoSingleton<NPCStartPositionManager>.IsInstantiated())
			{
				return false;
			}
			List<MapNode> nodesNearEdge = NPCStartPositionManager.GetNodesNearEdge(16, (MapNode node1, MapNode node2) => (NPCStartPositionManager.GetDistanceFromMapEdge(node1) + 1) * (creatureGridPosition - node1.Position).sqrMagnitude - (NPCStartPositionManager.GetDistanceFromMapEdge(node2) + 1) * (creatureGridPosition - node2.Position).sqrMagnitude, skipUnderwaterNodes: true);
			MapNode mapNode = null;
			foreach (MapNode item in nodesNearEdge)
			{
				if (PathfinderUtil.IsPathPossible(pathfindingAgent, item.Position))
				{
					mapNode = item;
					break;
				}
			}
			if (mapNode != null)
			{
				SetTarget(TargetIndex.A, new TargetObject(mapNode.Position));
				return true;
			}
			return false;
		}
	}
}
