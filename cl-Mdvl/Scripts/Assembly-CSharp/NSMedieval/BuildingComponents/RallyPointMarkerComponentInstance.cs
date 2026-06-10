using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.View;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("RallyPointMarkerComponentInstance", "")]
	public class RallyPointMarkerComponentInstance : BaseComponentInstance
	{
		private readonly RallyPointMarkerComponentBlueprint blueprint;

		private readonly HashSet<int> workerIds;

		public string Name { get; set; }

		public UnitCombatModeType DraftedStance { get; set; } = UnitCombatModeType.DraftedDefault;

		public bool ArmedSettlersOnly { get; set; }

		public RallyPointMarkerComponentBlueprint Blueprint => blueprint;

		public bool IsDrafted
		{
			get
			{
				if (workerIds.Count == 0)
				{
					return false;
				}
				foreach (HumanoidInstance item in WorkerManager.WorkersHere)
				{
					if (!item.HasDiedOrFainted && !item.WorkerBehaviour.IsCrazy && workerIds.Contains(item.UniqueId) && item.WorkerBehaviour.UseRallyPoints)
					{
						return item.WorkerBehaviour.IsDrafting;
					}
				}
				return false;
			}
		}

		public event Action ChangedEvent;

		public RallyPointMarkerComponentInstance(BaseBuildingInstance ownerBuilding, RallyPointMarkerComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), BuildingType.Decoration)
		{
			this.blueprint = blueprint;
			string text = MonoSingleton<LocalizationController>.Instance.GetText("rally_point_marker_default_name");
			int componentCount = base.Map.RallyPointMarkerComponentManager.ComponentCount;
			Name = $"{text} ({componentCount})";
			workerIds = new HashSet<int>();
			foreach (HumanoidInstance item in WorkerManager.WorkersEverywhere)
			{
				workerIds.Add(item.UniqueId);
			}
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				base.Map.RallyPointMarkerComponentManager.RemoveFromCache(this);
				base.Dispose();
			}
		}

		public void StartDraft()
		{
			using PooledList<WorkerView> selectedWorkers = ListPool<WorkerView>.GetJanitor();
			foreach (HumanoidInstance item in WorkerManager.WorkersHere)
			{
				if (workerIds.Contains(item.UniqueId) && !item.HasDiedOrFainted && !item.WorkerBehaviour.IsCrazy && item.WorkerBehaviour.UseRallyPoints && (!ArmedSettlersOnly || item.HasWeapon()))
				{
					WorkerView agentView = item.GetAgentView<WorkerView>();
					agentView.StartDraft();
					selectedWorkers.Add(agentView);
				}
			}
			MonoSingleton<DraftManager>.Instance.MoveToLocation(base.OwnerBuilding.WorldPosition, selectedWorkers, excludeOriginPoint: true, sameYLevel: true, DraftedStance, minimizeNodePenalties: true);
		}

		public void EndDraft()
		{
			foreach (HumanoidInstance item in WorkerManager.WorkersHere)
			{
				if (workerIds.Contains(item.UniqueId) && !item.HasDiedOrFainted && !item.WorkerBehaviour.IsCrazy && item.WorkerBehaviour.UseRallyPoints)
				{
					item.GetAgentView<WorkerView>()?.EndDraft();
				}
			}
		}

		public void AssignWorker(HumanoidInstance worker)
		{
			workerIds.Add(worker.UniqueId);
			this.ChangedEvent?.Invoke();
		}

		public void RemoveWorker(HumanoidInstance worker)
		{
			workerIds.Remove(worker.UniqueId);
			this.ChangedEvent?.Invoke();
		}

		public void AssignAllWorkers()
		{
			foreach (HumanoidInstance item in WorkerManager.WorkersEverywhere)
			{
				workerIds.Add(item.UniqueId);
			}
			this.ChangedEvent?.Invoke();
		}

		public void ClearAllWorkers()
		{
			workerIds.Clear();
			this.ChangedEvent?.Invoke();
		}

		public bool IsWorkerSet(HumanoidInstance worker)
		{
			return workerIds.Contains(worker.UniqueId);
		}

		public override string ToString()
		{
			return $"Rally point '{Name}' at {base.OwnerBuilding.GridDataPosition}";
		}

		public void RemoveDisposedWorkers()
		{
			using PooledList<int> pooledList = ListPool<int>.GetJanitor();
			List<HumanoidInstance> workers = GlobalSaveController.CurrentVillageData.Workers;
			List<HumanoidInstance> source = GlobalSaveController.CurrentVillageData.WorldMapData.CaravanWorkers.ToList();
			foreach (int workerId in workerIds)
			{
				if (workers.FirstOrDefault((HumanoidInstance worker) => worker.UniqueId == workerId) == null && source.FirstOrDefault((HumanoidInstance worker) => worker.UniqueId == workerId) == null)
				{
					pooledList.Add(workerId);
				}
			}
			foreach (int item in pooledList)
			{
				workerIds.Remove(item);
			}
			if (pooledList.Count > 0)
			{
				this.ChangedEvent?.Invoke();
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("name", Name);
			serializer.Write("workerIds", workerIds);
			serializer.WriteEnum("draftedStance", DraftedStance);
			serializer.Write("armedSettlersOnly", ArmedSettlersOnly);
		}

		public RallyPointMarkerComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<RallyPointMarkerComponentRepository, RallyPointMarkerComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(38, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\RallyPointMarkers\\RallyPointMarkerComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in ");
					messageBuilder.AppendFormatted("RallyPointMarkerComponentRepository");
					messageBuilder.AppendLiteral(". ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				Name = deserializer.ReadString("name");
				workerIds = deserializer.ReadIntHashSet("workerIds") ?? new HashSet<int>();
				DraftedStance = deserializer.ReadEnum("draftedStance", UnitCombatModeType.DraftedDefault);
				ArmedSettlersOnly = deserializer.ReadBool("armedSettlersOnly");
			}
		}
	}
}
