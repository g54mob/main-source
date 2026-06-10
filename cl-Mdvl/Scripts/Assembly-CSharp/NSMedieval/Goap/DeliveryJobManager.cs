using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tutorial;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Utils.TimeHelpers;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Goap
{
	public class DeliveryJobManager
	{
		private const int MaxContinuousBuildingsCount = 6;

		private const float MaxContinuousBuildingDistance = 6f;

		private const int ThreadUpdateIntervalMinutes = 2;

		private readonly object jobsLock = new object();

		private List<CreateVoxelJob> jobs;

		private HashSet<BaseBuildingInstance> buildingHasJob;

		private ConcurrentQueue<(bool isAdd, BaseBuildingInstance building)> toProcessQueue;

		private VillageMap map;

		private Cooldown threadUpdateCooldown;

		public bool IsThreadJobRunning { get; private set; }

		public bool HasDeliverResourceJobs { get; private set; }

		public DeliveryJobManager(VillageMap map, int initialCollectionCapacity)
		{
			this.map = map;
			threadUpdateCooldown = new Cooldown(0L, TutorialManager.IsTutorialActive);
			jobs = new List<CreateVoxelJob>(initialCollectionCapacity);
			buildingHasJob = new HashSet<BaseBuildingInstance>(initialCollectionCapacity);
			toProcessQueue = new ConcurrentQueue<(bool, BaseBuildingInstance)>();
		}

		public void Dispose()
		{
			map = null;
			jobs = null;
			buildingHasJob = null;
			toProcessQueue = null;
		}

		public void CreateDeliverResourceJob(BaseBuildingInstance building)
		{
			toProcessQueue.Enqueue((true, building));
			HasDeliverResourceJobs = true;
		}

		public void RemoveDeliverResourceJob(BaseBuildingInstance building)
		{
			toProcessQueue.Enqueue((false, building));
		}

		public bool HasDoableJobs()
		{
			if (IsThreadJobRunning || !HasDeliverResourceJobs)
			{
				return false;
			}
			lock (jobsLock)
			{
				for (int i = 0; i < jobs.Count; i++)
				{
					BaseBuildingInstance building = jobs[i].Building;
					if (building.Reachable && building.ResourcesAvailable)
					{
						return true;
					}
				}
				return false;
			}
		}

		public bool TryReserveDeliverResourceJobs(HumanoidInstance agent, [MustDisposeResource] out PooledList<BaseBuildingInstance> outJobs, out SimpleResourceCount agentResourceOrder)
		{
			agentResourceOrder = default(SimpleResourceCount);
			outJobs = default(PooledList<BaseBuildingInstance>);
			if (IsThreadJobRunning)
			{
				return false;
			}
			outJobs = ListPool<BaseBuildingInstance>.GetJanitor();
			Vec3Int agentPosition = agent.GetGridPosition();
			int agentSkillLevel = agent.Skills.GetSkill(SkillType.Construction)?.Level ?? 0;
			lock (jobsLock)
			{
				if (jobs.Count == 0)
				{
					return false;
				}
				BaseBuildingInstance firstFoundBuilding = null;
				for (int i = 0; i < jobs.Count; i++)
				{
					CreateVoxelJob createVoxelJob = jobs[i];
					if (createVoxelJob.Building.ConstructionPhase == ConstructionPhase.Foundation || MonoSingleton<ReservationManager>.Instance.IsReserved(createVoxelJob.Building) || !MonoSingleton<ReservationManager>.Instance.CanReserve(createVoxelJob.Building, agent) || !CanDeliveryJobBeAssigned(agent, createVoxelJob.Building, agentSkillLevel, firstFoundBuilding, in agentResourceOrder))
					{
						continue;
					}
					BaseBuildingInstance building = createVoxelJob.Building;
					IEnumerable<SimpleResourceCount> resourceOrder = building.GetResourceOrder(agent);
					if (resourceOrder == null)
					{
						continue;
					}
					if (agentResourceOrder.Equals(default(SimpleResourceCount)))
					{
						SimpleResourceCount simpleResourceCount = resourceOrder.FirstOrDefault();
						if (!simpleResourceCount.Equals(default(SimpleResourceCount)))
						{
							firstFoundBuilding = building;
							agentResourceOrder = simpleResourceCount;
							outJobs.Add(createVoxelJob.Building);
						}
						continue;
					}
					foreach (SimpleResourceCount item in resourceOrder)
					{
						if (!(item.Blueprint != agentResourceOrder.Blueprint))
						{
							agentResourceOrder = new SimpleResourceCount(item.Blueprint, item.Amount + agentResourceOrder.Amount);
							outJobs.Add(createVoxelJob.Building);
							break;
						}
					}
					int maximumStorableCount = agent.Storage.GetMaximumStorableCount(agentResourceOrder.Blueprint);
					if (agentResourceOrder.Amount >= maximumStorableCount)
					{
						agentResourceOrder = new SimpleResourceCount(agentResourceOrder.Blueprint, maximumStorableCount);
					}
					if (agentResourceOrder.Amount == maximumStorableCount || outJobs.Count >= 6)
					{
						break;
					}
				}
				outJobs.Sort(delegate(BaseBuildingInstance baseBuildingInstance, BaseBuildingInstance baseBuildingInstance2)
				{
					float num2 = baseBuildingInstance.GetGridPosition().DistanceSquared(in agentPosition);
					float value = baseBuildingInstance2.GetGridPosition().DistanceSquared(in agentPosition);
					return num2.CompareTo(value);
				});
				int num = 0;
				while (num < outJobs.Count)
				{
					BaseBuildingInstance reservableObject = outJobs[num];
					if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(reservableObject, agent))
					{
						outJobs.RemoveAt(num);
					}
					else
					{
						num++;
					}
				}
				return outJobs.Count > 0;
			}
		}

		private static bool CanDeliveryJobBeAssigned(CreatureBase agent, BaseBuildingInstance building, int agentSkillLevel, BaseBuildingInstance firstFoundBuilding, in SimpleResourceCount agentResourceOrder)
		{
			if (building.IsForbidden)
			{
				return false;
			}
			int minBuildSkillRequired = building.Blueprint.MinBuildSkillRequired;
			if (minBuildSkillRequired > 0 && agentSkillLevel < minBuildSkillRequired)
			{
				return false;
			}
			if (building.IsOnFire)
			{
				return false;
			}
			if (building.FactionOwnership != FactionOwnership.Player)
			{
				return false;
			}
			if (!PathfinderUtil.IsPathPossible(agent, building, preferEmptyNodes: true, WorldDirection.None, out var reachedPosition))
			{
				return false;
			}
			MapNode node = VillageManager.ActiveVillage.Map.GetNode(reachedPosition);
			MapNode nodeAbove = node.GetNodeAbove();
			if (node.WaterLevel == WaterDepthLevel.High && nodeAbove != null && nodeAbove.IsWater && nodeAbove.WaterLevel != WaterDepthLevel.Low)
			{
				return false;
			}
			IEnumerable<SimpleResourceCount> resourceOrder = building.GetResourceOrder(agent);
			using IEnumerator<SimpleResourceCount> enumerator = resourceOrder.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				return false;
			}
			if (firstFoundBuilding != null)
			{
				if (Vector3.Distance(firstFoundBuilding.GetPosition(), building.GetPosition()) > 6f)
				{
					return false;
				}
				bool flag = false;
				foreach (SimpleResourceCount item in resourceOrder)
				{
					if (item.Blueprint == agentResourceOrder.Blueprint)
					{
						flag = true;
						break;
					}
				}
				return flag && building.HasStabilityToBuild && building.IsBlueprintOnClearNode() && !building.IsMoveBlueprint;
			}
			return building.HasStabilityToBuild && building.IsBlueprintOnClearNode() && !building.IsMoveBlueprint;
		}

		public void OnLateTick()
		{
			if (!IsThreadJobRunning && threadUpdateCooldown.HasEnded)
			{
				IsThreadJobRunning = true;
				MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(RecalculateThread, OnRecalculateThreadDone);
			}
		}

		private bool RecalculateThread()
		{
			lock (jobsLock)
			{
				(bool, BaseBuildingInstance) result;
				while (toProcessQueue.TryDequeue(out result))
				{
					if (result.Item1)
					{
						if (buildingHasJob.Add(result.Item2))
						{
							jobs.Add(new CreateVoxelJob(result.Item2));
						}
					}
					else
					{
						if (!buildingHasJob.Remove(result.Item2))
						{
							continue;
						}
						for (int i = 0; i < jobs.Count; i++)
						{
							if (jobs[i].Building == result.Item2)
							{
								jobs.RemoveAt(i);
								break;
							}
						}
					}
				}
				for (int j = 0; j < jobs.Count; j++)
				{
					CreateVoxelJob value = jobs[j];
					value.RecalculatePriority();
					jobs[j] = value;
				}
				CreateVoxelJob.SortByPriority(jobs);
			}
			return true;
		}

		private void OnRecalculateThreadDone(bool result)
		{
			threadUpdateCooldown = Cooldown.FromNowMinutes(2, TutorialManager.IsTutorialActive);
			lock (jobsLock)
			{
				HasDeliverResourceJobs = jobs.Count > 0 || !toProcessQueue.IsEmpty;
			}
			IsThreadJobRunning = false;
		}
	}
}
