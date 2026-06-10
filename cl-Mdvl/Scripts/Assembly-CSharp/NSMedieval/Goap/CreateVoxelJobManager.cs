using System.Collections.Concurrent;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using JetBrains.Annotations;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
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
	public class CreateVoxelJobManager
	{
		private class DataFrame
		{
			public readonly List<CreateVoxelJob> Jobs;

			public readonly HashSet<BaseBuildingInstance> BuildingHasJob;

			public readonly HashSet<BaseBuildingInstance> WouldJobEncloseRegion;

			public readonly HashSet<BaseBuildingInstance> IsJobEnclosed;

			public DataFrame(int initialCapacity)
			{
				Jobs = new List<CreateVoxelJob>(initialCapacity);
				BuildingHasJob = new HashSet<BaseBuildingInstance>(initialCapacity);
				WouldJobEncloseRegion = new HashSet<BaseBuildingInstance>(initialCapacity);
				IsJobEnclosed = new HashSet<BaseBuildingInstance>(initialCapacity);
			}

			public void CopyTo(DataFrame other)
			{
				other.Jobs.Clear();
				other.BuildingHasJob.Clear();
				other.WouldJobEncloseRegion.Clear();
				other.IsJobEnclosed.Clear();
				other.Jobs.AddRange(Jobs);
				other.BuildingHasJob.AddRange(BuildingHasJob);
				other.WouldJobEncloseRegion.AddRange(WouldJobEncloseRegion);
				other.IsJobEnclosed.AddRange(IsJobEnclosed);
			}
		}

		private struct ClaimInfo
		{
			public Vec3Int Origin;

			public long ExpireTimeMinutes;
		}

		private struct CandidateJob
		{
			public CreateVoxelJob Job;

			public float RelativePriority;

			public Vec3Int ReachablePosition;
		}

		private const int ThreadUpdateIntervalMinutes = 2;

		private const int ClaimDurationMinutes = 7;

		private const float ClaimRadiusSquared = 4f;

		private readonly object jobsLock = new object();

		private VillageMap map;

		private ConcurrentQueue<(bool isAdd, BaseBuildingInstance building)> toProcessQueue;

		private Cooldown threadUpdateCooldown;

		private DataFrame readFrame;

		private DataFrame writeFrame;

		private ConcurrentDictionary<HumanoidInstance, ClaimInfo> claimRadiusUntilMinutes;

		private DeliveryJobManager deliveryJobManager;

		private WorldDate dateTime;

		public bool HasJobs { get; private set; }

		public bool IsThreadJobRunning { get; private set; }

		public uint Version { get; private set; }

		private List<CreateVoxelJob> Jobs => readFrame.Jobs;

		private HashSet<BaseBuildingInstance> BuildingHasJob => readFrame.BuildingHasJob;

		private HashSet<BaseBuildingInstance> JobWouldEncloseRegion => readFrame.WouldJobEncloseRegion;

		private HashSet<BaseBuildingInstance> IsJobEnclosed => readFrame.IsJobEnclosed;

		public CreateVoxelJobManager(VillageMap map, int initialCollectionCapacity, DeliveryJobManager deliveryJobManager)
		{
			this.map = map;
			dateTime = GlobalSaveController.CurrentVillageData.DateAndTime;
			threadUpdateCooldown = new Cooldown(0L, TutorialManager.IsTutorialActive);
			readFrame = new DataFrame(initialCollectionCapacity);
			writeFrame = new DataFrame(initialCollectionCapacity);
			toProcessQueue = new ConcurrentQueue<(bool, BaseBuildingInstance)>();
			this.deliveryJobManager = deliveryJobManager;
			claimRadiusUntilMinutes = new ConcurrentDictionary<HumanoidInstance, ClaimInfo>();
		}

		public void Dispose()
		{
			map = null;
			dateTime = null;
			toProcessQueue = null;
			readFrame = null;
			writeFrame = null;
			deliveryJobManager = null;
			claimRadiusUntilMinutes = null;
		}

		public void CreateConstructBuildingJob(BaseBuildingInstance building)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(27, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\CreateVoxelJobManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Create Construct Job for '");
				messageBuilder.AppendFormatted(building);
				messageBuilder.AppendLiteral("'");
			}
			Log.Trace(messageBuilder);
			toProcessQueue.Enqueue((true, building));
			HasJobs = true;
		}

		public void RemoveConstructBuildingJob(BaseBuildingInstance building)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(27, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\CreateVoxelJobManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Remove Construct Job for '");
				messageBuilder.AppendFormatted(building);
				messageBuilder.AppendLiteral("'");
			}
			Log.Trace(messageBuilder);
			toProcessQueue.Enqueue((false, building));
		}

		public bool TryReserveConstructBuildingJob(HumanoidInstance agent, [MustDisposeResource] out PooledList<(BaseBuildingInstance, Vec3Int)> outJobBuildings, out bool allJobsAreBlocking)
		{
			outJobBuildings = ListPool<(BaseBuildingInstance, Vec3Int)>.GetJanitor();
			bool flag = !deliveryJobManager.HasDoableJobs();
			using PooledList<(CreateVoxelJob, Vec3Int)> pooledList = ListPool<(CreateVoxelJob, Vec3Int)>.GetJanitor(256);
			allJobsAreBlocking = true;
			lock (jobsLock)
			{
				if (Jobs.Count == 0)
				{
					return false;
				}
				for (int i = 0; i < Jobs.Count; i++)
				{
					CreateVoxelJob item = Jobs[i];
					if (allJobsAreBlocking && !item.CanBeConstructed)
					{
						allJobsAreBlocking = false;
					}
					if (item.CanBeConstructed && PathfinderUtil.IsPathPossible(agent, item.Building, preferEmptyNodes: true, in item.AvoidReachableDirections, out var reachedPosition))
					{
						if (allJobsAreBlocking && !WouldJobEncloseRegion(item.Building))
						{
							allJobsAreBlocking = false;
						}
						pooledList.Add((item, reachedPosition));
					}
				}
			}
			if (pooledList.Count == 0)
			{
				return false;
			}
			int level = agent.Skills.GetSkill(SkillType.Construction).Level;
			Vector3 agentPosition = agent.GetPosition();
			short priority = pooledList[0].Item1.Priority;
			using PooledList<CandidateJob> pooledList2 = ListPool<CandidateJob>.GetJanitor();
			for (int j = 0; j < pooledList.Count; j++)
			{
				(CreateVoxelJob, Vec3Int) tuple = pooledList[j];
				CreateVoxelJob item2 = tuple.Item1;
				Vec3Int item3 = tuple.Item2;
				bool flag2 = false;
				long currentTimeTutorialAware = dateTime.CurrentTimeTutorialAware;
				foreach (var (humanoidInstance2, claimInfo2) in claimRadiusUntilMinutes)
				{
					if (humanoidInstance2 != agent && currentTimeTutorialAware <= claimInfo2.ExpireTimeMinutes && claimInfo2.Origin.DistanceSquared(item2.Building.GridDataPosition) < 4f)
					{
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					continue;
				}
				BaseBuildingInstance building = item2.Building;
				if (building.IsForbidden || building.OverlapsWithSleepingCreature() || building.FactionOwnership != FactionOwnership.Player)
				{
					continue;
				}
				int minBuildSkillRequired = building.Blueprint.MinBuildSkillRequired;
				if (level < minBuildSkillRequired)
				{
					continue;
				}
				MapNode node = VillageManager.ActiveVillage.Map.GetNode(item3);
				MapNode nodeAbove = node.GetNodeAbove();
				if ((node.WaterLevel == WaterDepthLevel.High && nodeAbove != null && nodeAbove.IsWater && nodeAbove.WaterLevel != WaterDepthLevel.Low) || !building.IsBlueprintOnClearNode())
				{
					continue;
				}
				if (allJobsAreBlocking && flag)
				{
					if (item2.Priority != priority)
					{
						break;
					}
				}
				else if (WouldJobEncloseRegion(item2.Building))
				{
					continue;
				}
				if (MonoSingleton<ReservationManager>.Instance.CanReserve(building, agent))
				{
					float relativePriority = ConstructionJobManagerUtil.CalculateRelativePriority(item2.Priority, item2.Building.WorldPosition, in agentPosition);
					pooledList2.Add(new CandidateJob
					{
						Job = item2,
						ReachablePosition = item3,
						RelativePriority = relativePriority
					});
				}
			}
			pooledList2.Sort((CandidateJob x, CandidateJob y) => y.RelativePriority.CompareTo(x.RelativePriority));
			int num = 0;
			Vec3Int lhs = default(Vec3Int);
			foreach (CandidateJob item4 in pooledList2)
			{
				if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(item4.Job.Building, agent))
				{
					if (lhs == default(Vec3Int))
					{
						lhs = item4.Job.Building.GridDataPosition;
					}
					num++;
					outJobBuildings.Add((item4.Job.Building, item4.ReachablePosition));
					if (num >= 3)
					{
						break;
					}
				}
			}
			if (num == 0)
			{
				return false;
			}
			claimRadiusUntilMinutes[agent] = new ClaimInfo
			{
				ExpireTimeMinutes = long.MaxValue,
				Origin = lhs
			};
			return true;
		}

		public void OnLateTick()
		{
			if (!IsThreadJobRunning && threadUpdateCooldown.HasEnded)
			{
				IsThreadJobRunning = true;
				MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(RecalculatePrioritiesThread, OnRecalculateFinished);
			}
		}

		private bool RecalculatePrioritiesThread()
		{
			readFrame.CopyTo(writeFrame);
			(bool, BaseBuildingInstance) result;
			while (toProcessQueue.TryDequeue(out result))
			{
				if (result.Item1)
				{
					if (writeFrame.BuildingHasJob.Add(result.Item2))
					{
						writeFrame.Jobs.Add(new CreateVoxelJob(result.Item2));
					}
				}
				else
				{
					if (!writeFrame.BuildingHasJob.Remove(result.Item2))
					{
						continue;
					}
					for (int i = 0; i < writeFrame.Jobs.Count; i++)
					{
						if (writeFrame.Jobs[i].Building == result.Item2)
						{
							writeFrame.Jobs.RemoveAt(i);
							break;
						}
					}
				}
			}
			writeFrame.WouldJobEncloseRegion.Clear();
			writeFrame.IsJobEnclosed.Clear();
			for (int j = 0; j < writeFrame.Jobs.Count; j++)
			{
				CreateVoxelJob value = writeFrame.Jobs[j];
				value.RecalculatePriority();
				if (value.IsBuildingWalkable)
				{
					writeFrame.Jobs[j] = value;
					continue;
				}
				MapNode node = value.Building.GetNode();
				bool flag = false;
				if (ConstructionJobManagerUtil.IsInEnclosedRegion(node))
				{
					flag = true;
					writeFrame.IsJobEnclosed.Add(value.Building);
				}
				WorldDirection avoidReachableDirections;
				bool errorHappened;
				bool flag2 = ConstructionJobManagerUtil.WouldJobEncloseRegion(map, node, out avoidReachableDirections, out errorHappened);
				if (flag || flag2)
				{
					value.AvoidReachableDirections = avoidReachableDirections;
					writeFrame.WouldJobEncloseRegion.Add(value.Building);
				}
				writeFrame.Jobs[j] = value;
			}
			CreateVoxelJob.SortByPriority(writeFrame.Jobs);
			lock (jobsLock)
			{
				DataFrame dataFrame = writeFrame;
				DataFrame dataFrame2 = readFrame;
				readFrame = dataFrame;
				writeFrame = dataFrame2;
			}
			return true;
		}

		private void OnRecalculateFinished(bool result)
		{
			HasJobs = Jobs.Count > 0 || !toProcessQueue.IsEmpty;
			threadUpdateCooldown = Cooldown.FromNowMinutes(2, TutorialManager.IsTutorialActive);
			Version++;
			IsThreadJobRunning = false;
		}

		public bool WouldJobEncloseRegion(BaseBuildingInstance jobBuilding, bool reCalculateFloodFill = false)
		{
			if (IsJobEnclosed.Contains(jobBuilding))
			{
				return false;
			}
			WorldDirection avoidReachableDirections;
			bool errorHappened;
			if (reCalculateFloodFill && jobBuilding.Blueprint.PathfindingPenalty == ushort.MaxValue)
			{
				return ConstructionJobManagerUtil.WouldJobEncloseRegion(map, jobBuilding.GetNode(), out avoidReachableDirections, out errorHappened);
			}
			return JobWouldEncloseRegion.Contains(jobBuilding);
		}

		public void ReleaseClaim(HumanoidInstance worker)
		{
			long currentTimeTutorialAware = dateTime.CurrentTimeTutorialAware;
			claimRadiusUntilMinutes[worker] = new ClaimInfo
			{
				ExpireTimeMinutes = currentTimeTutorialAware + 7,
				Origin = worker.GetGridPosition()
			};
		}
	}
}
