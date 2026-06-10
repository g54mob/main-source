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
using NSMedieval.State.WorkerJobs;
using NSMedieval.Tools;
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
	public class DestroyVoxelJobManager
	{
		private class DataFrame
		{
			public readonly List<DestroyVoxelJob> Jobs;

			public readonly HashSet<int> VoxelHasJob;

			public readonly HashSet<BaseBuildingInstance> BuildingHasJob;

			public readonly HashSet<int> WouldJobEncloseRegion;

			public readonly HashSet<int> IsJobEnclosed;

			public DataFrame(int collectionCapacity)
			{
				Jobs = new List<DestroyVoxelJob>(collectionCapacity);
				VoxelHasJob = new HashSet<int>(collectionCapacity);
				WouldJobEncloseRegion = new HashSet<int>(collectionCapacity);
				IsJobEnclosed = new HashSet<int>(collectionCapacity);
				BuildingHasJob = new HashSet<BaseBuildingInstance>(collectionCapacity);
			}

			public void CopyTo(DataFrame other)
			{
				other.Jobs.Clear();
				other.VoxelHasJob.Clear();
				other.WouldJobEncloseRegion.Clear();
				other.IsJobEnclosed.Clear();
				other.BuildingHasJob.Clear();
				other.Jobs.AddRange(Jobs);
				other.VoxelHasJob.AddRange(VoxelHasJob);
				other.WouldJobEncloseRegion.AddRange(WouldJobEncloseRegion);
				other.IsJobEnclosed.AddRange(IsJobEnclosed);
				other.BuildingHasJob.AddRange(BuildingHasJob);
			}
		}

		private struct ClaimInfo
		{
			public Vec3Int Origin;

			public long ExpireTimeMinutes;
		}

		private struct CandidateJob
		{
			public DestroyVoxelJob Job;

			public IReservable TargetObject;

			public float RelativePriority;

			public Vec3Int ReachablePosition;

			public override string ToString()
			{
				return $"{RelativePriority:F2}, {ReachablePosition}";
			}
		}

		private const int ThreadUpdateIntervalMinutes = 2;

		private const int ClaimDurationMinutes = 7;

		private const float ClaimRadiusSquared = 4f;

		private VillageMap map;

		private WorldDate dateTime;

		private readonly object jobsLock = new object();

		private DataFrame readFrame;

		private DataFrame writeFrame;

		private ConcurrentQueue<(bool isAdd, DestroyVoxelJob job)> toProcessQueue;

		private Cooldown threadUpdateCooldown;

		private ConcurrentDictionary<CreatureBase, ClaimInfo> claimRadiusUntilMinutes;

		public bool IsThreadJobRunning { get; private set; }

		public bool HasDeconstructJobs { get; private set; }

		public bool HasDigJobs { get; private set; }

		public uint Version { get; private set; }

		public List<DestroyVoxelJob> Jobs => readFrame.Jobs;

		public HashSet<int> VoxelHasJob => readFrame.WouldJobEncloseRegion;

		private HashSet<int> WouldEncloseRegion => readFrame.WouldJobEncloseRegion;

		private HashSet<int> IsJobEnclosed => readFrame.IsJobEnclosed;

		public DestroyVoxelJobManager(VillageMap map, int initialCollectionCapacity)
		{
			this.map = map;
			dateTime = GlobalSaveController.CurrentVillageData.DateAndTime;
			threadUpdateCooldown = new Cooldown(0L, TutorialManager.IsTutorialActive);
			readFrame = new DataFrame(initialCollectionCapacity);
			writeFrame = new DataFrame(initialCollectionCapacity);
			toProcessQueue = new ConcurrentQueue<(bool, DestroyVoxelJob)>();
			claimRadiusUntilMinutes = new ConcurrentDictionary<CreatureBase, ClaimInfo>();
		}

		public void Dispose()
		{
			map = null;
			dateTime = null;
			readFrame = null;
			writeFrame = null;
			toProcessQueue = null;
			claimRadiusUntilMinutes = null;
		}

		public void CreateDigJobs(DigMarkerResourceInstance newDigMarker)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\DestroyVoxelJobManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Creating dig jobs for dig marker at ");
				messageBuilder.AppendFormatted(newDigMarker.GridDataPosition);
			}
			Log.Trace(messageBuilder);
			if (newDigMarker.Positions.Count == 0)
			{
				Vec3Int voxelPos = DigMarkerPosToVoxelPos(newDigMarker.GridDataPosition);
				AddMineJob(voxelPos);
				return;
			}
			for (int i = 0; i < newDigMarker.Positions.Count; i++)
			{
				Vec3Int voxelPos2 = DigMarkerPosToVoxelPos(newDigMarker.Positions[i]);
				AddMineJob(voxelPos2);
			}
		}

		public void RemoveDigJobs(DigMarkerResourceInstance digMarker)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\DestroyVoxelJobManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Removing dig jobs for dig marker at ");
				messageBuilder.AppendFormatted(digMarker.GridDataPosition);
			}
			Log.Trace(messageBuilder);
			Vec3Int position = DigMarkerPosToVoxelPos(digMarker.GridDataPosition);
			RemoveMineJob(position);
			if (digMarker.Positions.Count > 0)
			{
				for (int i = 0; i < digMarker.Positions.Count; i++)
				{
					position = DigMarkerPosToVoxelPos(digMarker.Positions[i]);
					RemoveMineJob(position);
				}
			}
		}

		public void CreateDeconstructJob(BaseBuildingInstance building)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(38, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\DestroyVoxelJobManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Creating destroy jobs for building at ");
				messageBuilder.AppendFormatted(building.GridDataPosition);
			}
			Log.Trace(messageBuilder);
			toProcessQueue.Enqueue((true, new DestroyVoxelJob(building)));
		}

		public void RemoveDeconstructJobs(BaseBuildingInstance building)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(38, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\DestroyVoxelJobManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Removing destroy jobs for building at ");
				messageBuilder.AppendFormatted(building.GridDataPosition);
			}
			Log.Trace(messageBuilder);
			toProcessQueue.Enqueue((false, new DestroyVoxelJob(building)));
		}

		private void AddMineJob(Vec3Int voxelPos)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(11, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\DestroyVoxelJobManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("AddMineJob ");
				messageBuilder.AppendFormatted(voxelPos);
			}
			Log.Trace(messageBuilder);
			MapNode node = map.GetNode(voxelPos);
			toProcessQueue.Enqueue((true, new DestroyVoxelJob(node)));
		}

		private void RemoveMineJob(Vec3Int position)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(14, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\DestroyVoxelJobManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("RemoveMineJob ");
				messageBuilder.AppendFormatted(position);
			}
			Log.Trace(messageBuilder);
			MapNode node = map.GetNode(position);
			toProcessQueue.Enqueue((false, new DestroyVoxelJob(node)));
		}

		private static Vec3Int DigMarkerPosToVoxelPos(in Vec3Int position)
		{
			return position - Vec3Int.up;
		}

		private static Vec3Int VoxelPosToDigMarkerPos(in Vec3Int position)
		{
			return position + Vec3Int.up;
		}

		public bool TryReserveDestroyJob(CreatureBase agent, JobType jobType, [MustDisposeResource] out PooledList<(DestroyVoxelJob, Vec3Int)> outJobs, out bool allJobsWouldEncloseRegion)
		{
			outJobs = ListPool<(DestroyVoxelJob, Vec3Int)>.GetJanitor();
			using PooledList<(DestroyVoxelJob, Vec3Int)> pooledList = ListPool<(DestroyVoxelJob, Vec3Int)>.GetJanitor(256);
			allJobsWouldEncloseRegion = true;
			bool preferSameYLevel = claimRadiusUntilMinutes.ContainsKey(agent);
			lock (jobsLock)
			{
				if (Jobs.Count == 0)
				{
					return false;
				}
				for (int i = 0; i < Jobs.Count; i++)
				{
					DestroyVoxelJob item = Jobs[i];
					if (allJobsWouldEncloseRegion && item.IsDone)
					{
						allJobsWouldEncloseRegion = false;
					}
					if (jobType != item.Type || item.IsDone)
					{
						continue;
					}
					WorldObject target;
					if (jobType == JobType.Mining)
					{
						Vec3Int gridPosition = VoxelPosToDigMarkerPos(item.NodeToRemove.Position);
						target = MonoSingleton<DigMarkerResourceManager>.Instance.GetDigMarker(in gridPosition);
					}
					else
					{
						if (item.Building.DeconstructionBlockedBySleepingOrFaintedCreature())
						{
							continue;
						}
						target = item.Building;
					}
					if (PathfinderUtil.IsPathPossible(agent, target, preferEmptyNodes: true, in item.AvoidReachableDirections, out var reachedPosition, preferSameYLevel))
					{
						if (allJobsWouldEncloseRegion && !WouldJobEncloseRegion(item.NodeToRemove))
						{
							allJobsWouldEncloseRegion = false;
						}
						pooledList.Add((item, reachedPosition));
					}
				}
			}
			if (pooledList.Count == 0)
			{
				return false;
			}
			Vector3 agentPosition = agent.GetPosition();
			short priority = pooledList[0].Item1.Priority;
			using PooledList<CandidateJob> pooledList2 = ListPool<CandidateJob>.GetJanitor();
			for (int j = 0; j < pooledList.Count; j++)
			{
				(DestroyVoxelJob, Vec3Int) tuple = pooledList[j];
				DestroyVoxelJob item2 = tuple.Item1;
				Vec3Int item3 = tuple.Item2;
				bool flag = false;
				long currentTimeTutorialAware = dateTime.CurrentTimeTutorialAware;
				foreach (var (creatureBase2, claimInfo2) in claimRadiusUntilMinutes)
				{
					if (creatureBase2 != agent)
					{
						if (currentTimeTutorialAware > claimInfo2.ExpireTimeMinutes)
						{
							claimRadiusUntilMinutes.Remove(creatureBase2);
						}
						else if (claimInfo2.Origin.DistanceSquared(item2.NodeToRemove.Position) < 4f)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					continue;
				}
				WorldObject worldObject;
				if (jobType == JobType.Mining)
				{
					Vec3Int gridPosition2 = VoxelPosToDigMarkerPos(item2.NodeToRemove.Position);
					worldObject = MonoSingleton<DigMarkerResourceManager>.Instance.GetDigMarker(in gridPosition2);
				}
				else
				{
					worldObject = item2.Building;
				}
				MapNode node = VillageManager.ActiveVillage.Map.GetNode(item3);
				MapNode nodeAbove = node.GetNodeAbove();
				if (node.WaterLevel == WaterDepthLevel.High && nodeAbove != null && nodeAbove.IsWater && nodeAbove.WaterLevel != WaterDepthLevel.Low)
				{
					continue;
				}
				if (allJobsWouldEncloseRegion)
				{
					if (item2.Priority != priority)
					{
						break;
					}
				}
				else if (WouldJobEncloseRegion(item2.NodeToRemove))
				{
					continue;
				}
				if (MonoSingleton<ReservationManager>.Instance.CanReserve(worldObject, agent))
				{
					float yModifier = 1f;
					if (claimRadiusUntilMinutes.TryGetValue(agent, out var value) && currentTimeTutorialAware - value.ExpireTimeMinutes < 3)
					{
						yModifier = 10000f;
					}
					float num = ConstructionJobManagerUtil.CalculateRelativePriority(item2.Priority, item3.ToVector3World(), in agentPosition, yModifier);
					if (node.CreaturesCount > 0)
					{
						num -= 1000f;
					}
					pooledList2.Add(new CandidateJob
					{
						Job = item2,
						TargetObject = worldObject,
						RelativePriority = num,
						ReachablePosition = item3
					});
				}
			}
			pooledList2.Sort((CandidateJob x, CandidateJob y) => y.RelativePriority.CompareTo(x.RelativePriority));
			int num2 = 0;
			Vec3Int lhs = default(Vec3Int);
			foreach (CandidateJob item4 in pooledList2)
			{
				if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(item4.TargetObject, agent))
				{
					continue;
				}
				num2++;
				outJobs.Add((item4.Job, item4.ReachablePosition));
				if (lhs == default(Vec3Int))
				{
					lhs = item4.Job.NodeToRemove.Position;
					if (jobType == JobType.Mining)
					{
						for (int num3 = 0; num3 < item4.Job.NodeToRemove.DigAmount - 1; num3++)
						{
							outJobs.Add((item4.Job, item4.ReachablePosition));
							num2++;
						}
					}
				}
				if (num2 >= 3)
				{
					break;
				}
			}
			if (num2 == 0)
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

		public bool WouldJobEncloseRegion(MapNode jobNode, bool reCalculateFloodFill = false)
		{
			if (IsJobEnclosed.Contains(jobNode.Index))
			{
				return false;
			}
			WorldDirection avoidReachableDirections;
			bool errorHappened;
			if (reCalculateFloodFill)
			{
				return ConstructionJobManagerUtil.WouldJobEncloseRegion(map, jobNode, out avoidReachableDirections, out errorHappened, wouldRemoveNode: true);
			}
			return WouldEncloseRegion.Contains(jobNode.Index);
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
			(bool, DestroyVoxelJob) result;
			while (toProcessQueue.TryDequeue(out result))
			{
				if (result.Item1)
				{
					if ((result.Item2.Building == null || writeFrame.BuildingHasJob.Add(result.Item2.Building)) && (result.Item2.Building != null || writeFrame.VoxelHasJob.Add(result.Item2.NodeToRemove.Index)))
					{
						writeFrame.Jobs.Add(result.Item2);
					}
					continue;
				}
				MapNode nodeToRemove = result.Item2.NodeToRemove;
				if ((result.Item2.Building != null && !writeFrame.BuildingHasJob.Remove(result.Item2.Building)) || (result.Item2.Building == null && !writeFrame.VoxelHasJob.Remove(nodeToRemove.Index)))
				{
					continue;
				}
				for (int i = 0; i < writeFrame.Jobs.Count; i++)
				{
					if (writeFrame.Jobs[i].NodeToRemove == nodeToRemove)
					{
						writeFrame.Jobs.RemoveAt(i);
						break;
					}
				}
			}
			writeFrame.WouldJobEncloseRegion.Clear();
			writeFrame.IsJobEnclosed.Clear();
			HasDeconstructJobs = false;
			HasDigJobs = false;
			for (int j = 0; j < writeFrame.Jobs.Count; j++)
			{
				DestroyVoxelJob value = writeFrame.Jobs[j];
				if (value.Type == JobType.Construction && !HasDeconstructJobs)
				{
					HasDeconstructJobs = true;
				}
				if (value.Type == JobType.Mining && !HasDigJobs)
				{
					HasDigJobs = true;
				}
				value.RecalculatePriority();
				MapNode node = ((!value.NodeToRemove.IsWalkable) ? value.NodeToRemove.GetNodeAbove() : value.NodeToRemove);
				bool flag = false;
				if (ConstructionJobManagerUtil.IsInEnclosedRegion(node))
				{
					flag = true;
					writeFrame.IsJobEnclosed.Add(value.NodeToRemove.Index);
				}
				bool errorHappened;
				bool flag2 = ConstructionJobManagerUtil.WouldJobEncloseRegion(map, value.NodeToRemove, out value.AvoidReachableDirections, out errorHappened, wouldRemoveNode: true);
				if (flag || flag2)
				{
					writeFrame.WouldJobEncloseRegion.Add(value.NodeToRemove.Index);
				}
				writeFrame.Jobs[j] = value;
			}
			DestroyVoxelJob.SortByPriority(writeFrame.Jobs);
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
			threadUpdateCooldown = Cooldown.FromNowMinutes(2, TutorialManager.IsTutorialActive);
			Version++;
			IsThreadJobRunning = false;
		}

		public bool IsDeconstructJobEnclosed(BaseBuildingInstance building)
		{
			MapNode mapNode = building?.GetNode();
			if (mapNode == null)
			{
				return false;
			}
			return IsJobEnclosed.Contains(mapNode.Index);
		}

		public bool IsDigJobEnclosed(DigMarkerResourceInstance digMarker)
		{
			if (digMarker == null)
			{
				return false;
			}
			int item = GridDataIndexTools.FastTo1DIndex(DigMarkerPosToVoxelPos(digMarker.GridDataPosition));
			return IsJobEnclosed.Contains(item);
		}
	}
}
