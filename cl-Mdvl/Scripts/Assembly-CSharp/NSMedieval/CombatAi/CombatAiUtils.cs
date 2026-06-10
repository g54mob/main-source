using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.CombatAi
{
	public static class CombatAiUtils
	{
		public static void SetStateForEveryAgent(CombatAiState stateType, object value, Func<IDamageDealAgent, bool> filter = null)
		{
			MonoSingleton<CombatAgentManager>.Instance.DamageDealAgentSafeForEach(delegate(IDamageDealAgent item)
			{
				if (filter == null || filter(item))
				{
					item.CombatAi?.SetState(stateType, value);
				}
			});
		}

		public static IDamageTakingAgent PickBestTarget(IDamageDealAgent attacker, IDamageTakingAgent target1, IDamageTakingAgent target2)
		{
			if (!CombatUtils.IsAttackPossible(attacker, target1))
			{
				return target2;
			}
			if (!CombatUtils.IsAttackPossible(attacker, target2))
			{
				return target1;
			}
			CombatAiAgent combatAiAgent = (target1 as IDamageDealAgent)?.CombatAi;
			CombatAiAgent combatAiAgent2 = (target2 as IDamageDealAgent)?.CombatAi;
			int num = combatAiAgent?.GetState<int>(CombatAiState.TargetersCount) ?? MonoSingleton<CombatTargetManager>.Instance.CountPreferedAttackers(target1);
			int num2 = combatAiAgent2?.GetState<int>(CombatAiState.TargetersCount) ?? MonoSingleton<CombatTargetManager>.Instance.CountPreferedAttackers(target2);
			if (target1.DamageAgentType.HasFlag(DamageTakingAgentType.Building) && target2.DamageAgentType.HasFlag(DamageTakingAgentType.Building))
			{
				if (num >= num2)
				{
					return target2;
				}
				return target1;
			}
			if (target1.DamageAgentType.HasFlag(DamageTakingAgentType.Building))
			{
				return target2;
			}
			if (target2.DamageAgentType.HasFlag(DamageTakingAgentType.Building))
			{
				return target1;
			}
			if ((target1.DamageAgentType & (DamageTakingAgentType.Animal | DamageTakingAgentType.Worker | DamageTakingAgentType.NPC)) == 0)
			{
				return target2;
			}
			if ((target2.DamageAgentType & (DamageTakingAgentType.Animal | DamageTakingAgentType.Worker | DamageTakingAgentType.NPC)) == 0)
			{
				return target1;
			}
			if (CombatUtils.GetAttackType(attacker) == AttackType.Melee)
			{
				if (num == num2)
				{
					float num3 = ((IDamageTakingAgent)combatAiAgent.AgentOwner).Stats.GetStat(StatType.Health)?.Current ?? (-1f);
					float num4 = ((IDamageTakingAgent)combatAiAgent2.AgentOwner).Stats.GetStat(StatType.Health)?.Current ?? (-1f);
					if (num3 > 0f && num4 >= 0f)
					{
						if (!(num3 < num4))
						{
							return target2;
						}
						return target1;
					}
				}
				if (num + num2 == 1)
				{
					IDamageTakingAgent preferredTarget = MonoSingleton<CombatTargetManager>.Instance.GetPreferredTarget(attacker);
					if (CombatUtils.IsInAttackRange(attacker, preferredTarget) && (preferredTarget == target1 || preferredTarget == target2) && MonoSingleton<CombatTargetManager>.Instance.GetPreferredTarget(preferredTarget as IDamageDealAgent) == attacker)
					{
						return preferredTarget;
					}
				}
				if (num >= num2)
				{
					return target2;
				}
				return target1;
			}
			bool flag = CombatUtils.IsInAttackRange(attacker, target1);
			bool flag2 = CombatUtils.IsInAttackRange(attacker, target2);
			if (flag && flag2)
			{
				if (num >= num2)
				{
					return target2;
				}
				return target1;
			}
			if (flag)
			{
				return target1;
			}
			if (flag2)
			{
				return target2;
			}
			float num5 = Vector3.Distance(attacker.GetPosition(), target1.GetPosition());
			float num6 = Vector3.Distance(attacker.GetPosition(), target2.GetPosition());
			if (!(num5 < num6))
			{
				return target2;
			}
			return target1;
		}

		public static DoorComponentInstance GetFirstReachableDoor(Path path, IDamageDealAgent agent)
		{
			IPathfindingAgent pathfindingAgent = agent as IPathfindingAgent;
			for (int num = path.NodePath.Count - 1; num >= 0; num--)
			{
				MapNode mapNode = path.NodePath[num];
				DoorComponentInstance componentInstance = mapNode.Map.DoorComponentManager.GetComponentInstance(mapNode.Position);
				if (componentInstance == null)
				{
					if (pathfindingAgent != null && !pathfindingAgent.PathTraversalProvider.CanStandOnNode(mapNode))
					{
						return null;
					}
				}
				else if (!IsAgentDefeated(componentInstance.OwnerBuilding))
				{
					if (agent.GetTarget() == componentInstance.OwnerBuilding)
					{
						return componentInstance;
					}
					if (PathfinderUtil.IsPathPossible((IPathfindingAgent)agent, componentInstance.OwnerBuilding))
					{
						Path path2 = MonoSingleton<CombatAttackerPositioningManager>.Instance.CreatePath(agent, componentInstance.OwnerBuilding);
						if (path2 != null)
						{
							Path.ReleasePath(path2);
							return componentInstance;
						}
					}
				}
			}
			return null;
		}

		public static HumanoidInstance GetFirstReachableWorkerObstacle(Path path, IDamageDealAgent agent)
		{
			if (CombatUtils.IsNullOrDisposed(agent))
			{
				return null;
			}
			WalkableModel testAgentUnwalkableDoors = Repository<WalkableModelRepository, WalkableModel>.Instance.GetTestAgentUnwalkableDoors();
			for (int num = path.NodePath.Count - 1; num >= 0; num--)
			{
				MapNode mapNode = path.NodePath[num];
				if (mapNode.Map.CreaturesOnNodes.TryGetValue(mapNode.Index, out var value))
				{
					foreach (CreatureBase item in value)
					{
						if (item is HumanoidInstance humanoidInstance && humanoidInstance.IsWorker() && !IsAgentDefeated(humanoidInstance) && PathfinderUtil.IsPathPossible(testAgentUnwalkableDoors, agent.GetNode(), humanoidInstance.GetNode()))
						{
							return humanoidInstance;
						}
					}
				}
			}
			return null;
		}

		public static void GatherNearbyTargets(IDamageDealAgent attacker, IDamageTakingAgent target, ICollection<IDamageTakingAgent> outputTargets, int maxTargets, BuildingType buildingCategoriesToSpreadAttack, float radius = 10f)
		{
			outputTargets.Clear();
			if (maxTargets < 2)
			{
				outputTargets.Add(target);
			}
			else if (target is BaseBuildingInstance targetBuilding)
			{
				AddNearbyTargetsBuilding(attacker, targetBuilding, outputTargets, maxTargets, buildingCategoriesToSpreadAttack, radius);
			}
			else
			{
				AddNearbyTargetsCreature(attacker, target, outputTargets, maxTargets, radius);
			}
		}

		private static void AddNearbyTargetsCreature(IDamageDealAgent attacker, IDamageTakingAgent target, ICollection<IDamageTakingAgent> outputTargets, int maxTargets, float radius = 10f)
		{
			if (CombatUtils.IsNullOrDisposed(attacker))
			{
				return;
			}
			float num = attacker.GetPosition().Distance(target.GetPosition()) * 1.2f;
			if (num > 30f)
			{
				outputTargets.Add(target);
				return;
			}
			MapNode node = attacker.GetNode();
			foreach (MapNode item in FloodFillUtil.IterateFloodFillConnections(node, num, SpreadStopFilter))
			{
				if (outputTargets.Count >= maxTargets)
				{
					break;
				}
				if (!item.IsWalkable || item.WorldPosition.Distance(target.GetPosition()) > radius || item == node || item.CreaturesCount == 0 || !item.Map.CreaturesOnNodes.TryGetValue(item.Index, out var value))
				{
					continue;
				}
				bool flag = false;
				foreach (MapNode item2 in item.ConnectionsSafe)
				{
					if (!item2.IsWalkable || item.IsHorizontallyDiagonalTo(item2))
					{
						continue;
					}
					if (item2.CreaturesCount == 0)
					{
						flag = true;
						break;
					}
					if (!item2.Map.CreaturesOnNodes.TryGetValue(item2.Index, out var value2))
					{
						flag = true;
						break;
					}
					bool flag2 = false;
					foreach (CreatureBase item3 in value2)
					{
						if (item3 is HumanoidInstance humanoidInstance && humanoidInstance.IsWorker())
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					continue;
				}
				CreatureBase creatureBase = value.MinItem((CreatureBase x) => x.GetPosition().DistanceSquared(attacker.GetPosition()), null, delegate(CreatureBase x)
				{
					if (IsAgentDefeated(x) || (x is HumanoidInstance humanoidInstance2 && humanoidInstance2.IsEnemy()))
					{
						return false;
					}
					if (target is HumanoidInstance humanoidInstance3 && humanoidInstance3.IsWorker() && (x is AnimalInstance || !(x is HumanoidInstance humanoidInstance4) || !humanoidInstance4.IsWorker()))
					{
						return false;
					}
					return MonoSingleton<CombatAttackerPositioningManager>.Instance.CanCreatePath(attacker, x) ? true : false;
				});
				if (creatureBase != null)
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(13, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\CombatAiUtils.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Add creature ");
						messageBuilder.AppendFormatted(creatureBase);
					}
					Log.Trace(messageBuilder);
					outputTargets.Add(creatureBase);
				}
			}
			if (outputTargets.Count == 0)
			{
				outputTargets.Add(target);
			}
			static bool SpreadStopFilter(MapNode mapNode)
			{
				if (!mapNode.IsWalkable)
				{
					return true;
				}
				if (mapNode.CreaturesCount == 0)
				{
					return false;
				}
				if (!mapNode.Map.CreaturesOnNodes.TryGetValue(mapNode.Index, out var value3))
				{
					return false;
				}
				foreach (CreatureBase item4 in value3)
				{
					if (item4 is HumanoidInstance humanoidInstance2 && humanoidInstance2.IsWorker() && humanoidInstance2.WorkerBehaviour.IsDrafting && !IsAgentDefeated(humanoidInstance2))
					{
						return true;
					}
				}
				return false;
			}
		}

		private static void AddNearbyTargetsBuilding(IDamageDealAgent attacker, BaseBuildingInstance targetBuilding, ICollection<IDamageTakingAgent> outputTargets, int maxTargets, BuildingType buildingCategoriesToSpreadAttack, float radius = 10f)
		{
			if (targetBuilding == null)
			{
				return;
			}
			outputTargets.Add(targetBuilding);
			if (!buildingCategoriesToSpreadAttack.HasFlag(targetBuilding.BuildingType))
			{
				return;
			}
			MapNode node = targetBuilding.GetNode();
			using PooledList<IDamageTakingAgent> pooledList = ListPool<IDamageTakingAgent>.GetJanitor();
			foreach (MapNode item2 in FloodFillUtil.IterateFloodFillConnections(node, radius))
			{
				if (item2 == node || item2.Map.FirePresenceGrid.HasFirePresence(item2))
				{
					continue;
				}
				foreach (WorldObject worldObject in item2.WorldObjects)
				{
					if (worldObject is BaseBuildingInstance baseBuildingInstance && !IsAgentDefeated(baseBuildingInstance) && baseBuildingInstance.GetComponentInstance<DoorComponentInstance>() == null && buildingCategoriesToSpreadAttack.HasFlag(baseBuildingInstance.BuildingType) && MonoSingleton<CombatAttackerPositioningManager>.Instance.CanCreatePath(attacker, baseBuildingInstance))
					{
						pooledList.Add(baseBuildingInstance);
					}
				}
			}
			Vector3 attackerPosition = attacker.GetPosition();
			pooledList.Sort(delegate(IDamageTakingAgent t1, IDamageTakingAgent t2)
			{
				float num2 = attackerPosition.DistanceSquared(t1.GetPosition());
				float value = attackerPosition.DistanceSquared(t2.GetPosition());
				return num2.CompareTo(value);
			});
			for (int num = 0; num < maxTargets; num++)
			{
				if (pooledList.Count <= 0)
				{
					break;
				}
				IDamageTakingAgent item = pooledList[0];
				pooledList.RemoveAt(0);
				outputTargets.Add(item);
			}
		}

		public static bool AreTargetsDefeated(List<IDamageTakingAgent> targets)
		{
			if (targets == null)
			{
				return true;
			}
			foreach (IDamageTakingAgent target in targets)
			{
				if (!IsAgentDefeated(target))
				{
					return false;
				}
			}
			return true;
		}

		public static bool IsAgentDefeated(IDamageCommonAgent agent)
		{
			if (agent == null)
			{
				return true;
			}
			bool flag = agent.HasDisposed || agent.HasDiedOrFainted;
			if (flag)
			{
				return true;
			}
			if (agent is BaseBuildingInstance { ConstructionPhase: var constructionPhase } baseBuildingInstance)
			{
				if (constructionPhase != ConstructionPhase.Finished && constructionPhase != ConstructionPhase.Foundation)
				{
					return true;
				}
				DoorComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<DoorComponentInstance>();
				if (componentInstance != null)
				{
					flag = componentInstance.LockState == LockState.ForcedOpen || componentInstance.LockState == LockState.AlwaysOpen;
				}
			}
			return flag;
		}
	}
}
