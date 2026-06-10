using System;
using FoxyVoxel.Logging;
using JetBrains.Annotations;
using NSMedieval.BuildingComponents;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;

namespace NSMedieval.Goap
{
	public class ConstructionJobManager
	{
		private VillageMap map;

		private DeliveryJobManager deliveryJobManager;

		private CreateVoxelJobManager createVoxelJobManager;

		private DestroyVoxelJobManager destroyVoxelJobManager;

		public bool HasCreateVoxelJobs => createVoxelJobManager.HasJobs;

		public bool HasDeconstructJobs => destroyVoxelJobManager.HasDeconstructJobs;

		public bool HasDigJobs => destroyVoxelJobManager.HasDigJobs;

		public CreateVoxelJobManager CreateVoxelManager => createVoxelJobManager;

		public DestroyVoxelJobManager DestroyVoxelManager => destroyVoxelJobManager;

		public event Action<BaseBuildingInstance> MarkedForDeconstructionEvent;

		public event Action<BaseBuildingInstance> UnMarkedForDeconstructionEvent;

		public ConstructionJobManager(VillageMap villageMap)
		{
			map = villageMap;
			deliveryJobManager = new DeliveryJobManager(map, 256);
			createVoxelJobManager = new CreateVoxelJobManager(map, 256, deliveryJobManager);
			destroyVoxelJobManager = new DestroyVoxelJobManager(map, 256);
		}

		public void Dispose()
		{
			map = null;
			deliveryJobManager.Dispose();
			deliveryJobManager = null;
			createVoxelJobManager.Dispose();
			createVoxelJobManager = null;
			destroyVoxelJobManager.Dispose();
			destroyVoxelJobManager = null;
			this.MarkedForDeconstructionEvent = null;
			this.UnMarkedForDeconstructionEvent = null;
		}

		public bool HasDoableDeliveryJobs()
		{
			return deliveryJobManager.HasDoableJobs();
		}

		public void ReleaseCreateClaim(HumanoidInstance worker)
		{
			createVoxelJobManager.ReleaseClaim(worker);
		}

		public void ReleaseDestroyClaim(HumanoidInstance worker)
		{
			destroyVoxelJobManager.ReleaseClaim(worker);
		}

		public void CreateDeliverResourceJob(BaseBuildingInstance building)
		{
			if (map == null)
			{
				Log.Error("Construction job manager is disposed, but you tried calling its method", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\ConstructionJobManager.cs");
			}
			else
			{
				deliveryJobManager.CreateDeliverResourceJob(building);
			}
		}

		public void RemoveDeliverResourceJob(BaseBuildingInstance building)
		{
			if (map == null)
			{
				Log.Error("Construction job manager is disposed, but you tried calling its method", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\ConstructionJobManager.cs");
			}
			else
			{
				deliveryJobManager.RemoveDeliverResourceJob(building);
			}
		}

		public bool TryReserveDeliverResourceJobs(HumanoidInstance agent, [MustDisposeResource] out PooledList<BaseBuildingInstance> outJobs, out SimpleResourceCount agentResourceOrder)
		{
			if (map == null)
			{
				Log.Error("Construction job manager is disposed, but you tried calling its method", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\ConstructionJobManager.cs");
				outJobs = default(PooledList<BaseBuildingInstance>);
				agentResourceOrder = default(SimpleResourceCount);
				return false;
			}
			return deliveryJobManager.TryReserveDeliverResourceJobs(agent, out outJobs, out agentResourceOrder);
		}

		public void CreateConstructBuildingJob(BaseBuildingInstance building)
		{
			if (map == null)
			{
				Log.Error("Construction job manager is disposed, but you tried calling its method", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\ConstructionJobManager.cs");
			}
			else
			{
				createVoxelJobManager.CreateConstructBuildingJob(building);
			}
		}

		public void RemoveConstructBuildingJob(BaseBuildingInstance building)
		{
			if (map == null)
			{
				Log.Error("Construction job manager is disposed, but you tried calling its method", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\ConstructionJobManager.cs");
			}
			else
			{
				createVoxelJobManager.RemoveConstructBuildingJob(building);
			}
		}

		public bool TryReserveConstructBuildingJob(HumanoidInstance agent, [MustDisposeResource] out PooledList<(BaseBuildingInstance, Vec3Int)> outJobBuildings, out bool allJobsAreBlocking)
		{
			if (map == null)
			{
				Log.Error("Construction job manager is disposed, but you tried calling its method", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\ConstructionJobManager.cs");
				allJobsAreBlocking = false;
				outJobBuildings = default(PooledList<(BaseBuildingInstance, Vec3Int)>);
				return false;
			}
			return createVoxelJobManager.TryReserveConstructBuildingJob(agent, out outJobBuildings, out allJobsAreBlocking);
		}

		public void CreateDigJobs(DigMarkerResourceInstance newDigMarker)
		{
			if (map == null)
			{
				Log.Error("Construction job manager is disposed, but you tried calling its method", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\ConstructionJobManager.cs");
			}
			else
			{
				destroyVoxelJobManager.CreateDigJobs(newDigMarker);
			}
		}

		public void RemoveDigJobs(DigMarkerResourceInstance digMarker)
		{
			if (map == null)
			{
				Log.Error("Construction job manager is disposed, but you tried calling its method", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\ConstructionJobManager.cs");
			}
			else
			{
				destroyVoxelJobManager.RemoveDigJobs(digMarker);
			}
		}

		public bool TryReserveDigJob(CreatureBase agent, [MustDisposeResource] out PooledList<(DestroyVoxelJob, Vec3Int)> outJobs, out bool allJobsWouldEncloseRegion)
		{
			if (map == null)
			{
				Log.Error("Construction job manager is disposed, but you tried calling its method", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\ConstructionJobManager.cs");
				allJobsWouldEncloseRegion = false;
				outJobs = default(PooledList<(DestroyVoxelJob, Vec3Int)>);
				return false;
			}
			if (!destroyVoxelJobManager.TryReserveDestroyJob(agent, JobType.Mining, out outJobs, out allJobsWouldEncloseRegion))
			{
				return false;
			}
			return true;
		}

		public void CreateDeconstructJob(BaseBuildingInstance building)
		{
			if (map == null)
			{
				Log.Error("Construction job manager is disposed, but you tried calling its method", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\ConstructionJobManager.cs");
				return;
			}
			destroyVoxelJobManager.CreateDeconstructJob(building);
			this.MarkedForDeconstructionEvent?.Invoke(building);
		}

		public void RemoveDeconstructJobs(BaseBuildingInstance building)
		{
			if (map == null)
			{
				Log.Error("Construction job manager is disposed, but you tried calling its method", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\ConstructionJobManager.cs");
				return;
			}
			destroyVoxelJobManager.RemoveDeconstructJobs(building);
			this.UnMarkedForDeconstructionEvent?.Invoke(building);
		}

		public bool TryReserveDeconstructJob(HumanoidInstance humanoidOwner, [MustDisposeResource] out PooledList<(DestroyVoxelJob, Vec3Int)> outJobs, out bool allJobsWouldEncloseRegion)
		{
			if (map == null)
			{
				Log.Error("Construction job manager is disposed, but you tried calling its method", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\ConstructionJobManager.cs");
				allJobsWouldEncloseRegion = false;
				outJobs = default(PooledList<(DestroyVoxelJob, Vec3Int)>);
				return false;
			}
			if (!destroyVoxelJobManager.TryReserveDestroyJob(humanoidOwner, JobType.Construction, out outJobs, out allJobsWouldEncloseRegion))
			{
				outJobs = default(PooledList<(DestroyVoxelJob, Vec3Int)>);
				return false;
			}
			return true;
		}

		public bool WouldJobEncloseRegion(BaseBuildingInstance jobBuilding, bool reCalculateFloodFill = false)
		{
			if (map == null)
			{
				Log.Error("Construction job manager is disposed, but you tried calling its method", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\ConstructionJobManager.cs");
				return false;
			}
			return createVoxelJobManager.WouldJobEncloseRegion(jobBuilding, reCalculateFloodFill);
		}

		public bool WouldDestroyJobEncloseRegion(MapNode node, bool reCalculateFloodFill = false)
		{
			if (map == null)
			{
				Log.Error("Construction job manager is disposed, but you tried calling its method", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\ConstructionJobManager.cs");
				return false;
			}
			return destroyVoxelJobManager.WouldJobEncloseRegion(node, reCalculateFloodFill);
		}

		public void RemoveAllJobs(BaseBuildingInstance building)
		{
			if (map == null)
			{
				Log.Error("Construction job manager is disposed, but you tried calling its method", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\ConstructionJobManager.cs");
				return;
			}
			RemoveDeliverResourceJob(building);
			RemoveConstructBuildingJob(building);
			RemoveDeconstructJobs(building);
		}

		public void OnLateTick()
		{
			deliveryJobManager.OnLateTick();
			createVoxelJobManager.OnLateTick();
			destroyVoxelJobManager.OnLateTick();
		}

		public bool IsDeconstructJobEnclosed(BaseBuildingInstance building)
		{
			return destroyVoxelJobManager.IsDeconstructJobEnclosed(building);
		}

		public bool IsDigJobEnclosed(DigMarkerResourceInstance digMarker)
		{
			return destroyVoxelJobManager.IsDigJobEnclosed(digMarker);
		}
	}
}
