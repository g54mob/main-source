using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.RoomDetection;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("BaseComponentInstance", "")]
	public abstract class BaseComponentInstance : IComponentDisposable, IDisposable, IReservable, IGameDisposable, IGoapTargetable, IFVSerializable
	{
		[SerializeField]
		private bool isUnavailablePrisonCell;

		[NonSerialized]
		private BaseBuildingInstance ownerBuilding;

		[NonSerialized]
		private string ownerBuildingID;

		[NonSerialized]
		private Vec3Int gridPosition;

		[SerializeField]
		private readonly int uniqueId;

		[SerializeField]
		private string componentBlueprintID;

		[NonSerialized]
		private bool hasSubscribedToEvents;

		public bool IsUnavailablePrisonCell => isUnavailablePrisonCell;

		public string OwnerBuildingID => ownerBuildingID;

		public string ComponentBlueprintID => componentBlueprintID;

		public int UniqueID => uniqueId;

		public bool Underwater => ownerBuilding?.UnderWater() ?? false;

		public bool IsOnFire => ownerBuilding?.IsOnFire ?? false;

		public bool OwnedByPlayer => OwnerBuilding?.OwnedByPlayer() ?? false;

		public BaseBuildingBlueprint BaseBuildingBlueprint => ownerBuilding.Blueprint;

		public VillageMap Map => ownerBuilding?.Village?.Map;

		public Vec3Int GridPosition => ownerBuilding.GridDataPosition;

		public Vector3 WorldPosition => ownerBuilding.GetPosition();

		public float Angle => OwnerBuilding.Angle;

		public bool HasDisposed { get; private set; }

		public BaseBuildingInstance OwnerBuilding => ownerBuilding;

		public Vec3Int GridDataPosition => ownerBuilding.GridDataPosition;

		public List<Vec3Int> Positions => ownerBuilding.Positions;

		public ConcurrentHashSet<Vec3Int> ReachablePositions
		{
			get
			{
				if (OwnerBuilding == null)
				{
					return new ConcurrentHashSet<Vec3Int>();
				}
				return OwnerBuilding.ReachablePositions;
			}
		}

		public event Action<IComponentDisposable> OnDisposedComponentEvent;

		public event Action<IReservable, IGoapAgentOwner> OnReservedEvent;

		public event Action<IReservable, IGoapAgentOwner> OnReleasedEvent;

		public event Action<IGameDisposable> OnDisposedEvent;

		public event Action<IGameDisposable> DisposeComponentsEvent;

		protected BaseComponentInstance(BaseBuildingInstance ownerBuilding)
		{
			this.ownerBuilding = ownerBuilding;
			ownerBuildingID = ownerBuilding.Blueprint.GetID();
			uniqueId = this.ownerBuilding.UniqueId;
			gridPosition = ownerBuilding.GridDataPosition;
			OwnerBuilding.DisposeComponentsEvent += Dispose;
			OwnerBuilding.BaseBuildingEnterFinishedStateEvent += OnBaseBuildingEnterFinishedState;
			OwnerBuilding.WaterLevelChangedEvent += OnWaterLevelChanged;
			OwnerBuilding.RefreshRoomChangedEvent += OnRefreshRoomChanged;
		}

		protected BaseComponentInstance(BaseBuildingInstance ownerBuilding, string componentBlueprintID, BuildingType componentType)
		{
			this.componentBlueprintID = componentBlueprintID;
			this.ownerBuilding = ownerBuilding;
			ownerBuildingID = ownerBuilding.Blueprint.GetID();
			this.ownerBuilding.AddNewComponent(componentType);
			uniqueId = this.ownerBuilding.UniqueId;
			SubscribeToEvents();
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(11, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Basic buildings\\BaseComponentInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(this);
				messageBuilder.AppendLiteral(" Coverage: ");
				messageBuilder.AppendFormatted(GetNode().Coverage);
			}
			Log.Debug(messageBuilder);
		}

		protected BaseComponentInstance(string componentBlueprintID, int uniqueId)
		{
			this.componentBlueprintID = componentBlueprintID;
			this.uniqueId = uniqueId;
		}

		protected BaseComponentInstance(string componentBlueprintID)
		{
			this.componentBlueprintID = componentBlueprintID;
		}

		public Vector3 GetPosition()
		{
			if (HasDisposed || OwnerBuilding.HasDisposed || OwnerBuilding == null)
			{
				return Vector3.zero;
			}
			return OwnerBuilding.GetPosition();
		}

		public virtual void SetupAfterInstantiation()
		{
		}

		public virtual void Dispose()
		{
			if (!HasDisposed)
			{
				if (ownerBuilding != null)
				{
					ownerBuilding.DisposeComponentsEvent -= Dispose;
					ownerBuilding.BaseBuildingEnterFinishedStateEvent -= OnBaseBuildingEnterFinishedState;
					ownerBuilding.WaterLevelChangedEvent -= OnWaterLevelChanged;
					OwnerBuilding.RefreshRoomChangedEvent -= OnRefreshRoomChanged;
				}
				if (Map != null)
				{
					Map.BuildingsManagerMain.StabilityCarrierDestroyedEvent -= OnStabilityCarrierDestroyed;
				}
				HasDisposed = true;
				ownerBuilding = null;
				if (!LoadingController.IsLeavingMainScene)
				{
					this.OnDisposedEvent?.Invoke(this);
				}
				else
				{
					this.DisposeComponentsEvent?.Invoke(this);
				}
				this.OnDisposedEvent = null;
				this.DisposeComponentsEvent = null;
				this.OnReleasedEvent = null;
				this.OnReservedEvent = null;
				this.OnDisposedComponentEvent = null;
			}
		}

		public virtual void SetupAfterLoading(BaseBuildingInstance ownerBuilding)
		{
			this.ownerBuilding = ownerBuilding;
			ownerBuildingID = this.ownerBuilding.Blueprint.GetID();
			SubscribeToEvents();
		}

		public bool IsDisposedOrNull()
		{
			if (!HasDisposed && ownerBuilding != null)
			{
				return ownerBuilding.HasDisposed;
			}
			return true;
		}

		public int GetMaxReservers()
		{
			return 1;
		}

		public Room GetRoom()
		{
			return ownerBuilding?.GetRoom();
		}

		public void OnReservationChanged(bool isReserved, IGoapAgentOwner agent)
		{
			if (ownerBuilding != null)
			{
				ownerBuilding.ComponentReservationChanged(agent, this, isReserved);
				ReservationChanged(isReserved);
				if (isReserved)
				{
					this.OnReservedEvent?.Invoke(this, agent);
				}
				else
				{
					this.OnReleasedEvent?.Invoke(this, agent);
				}
			}
		}

		public MapNode GetNode()
		{
			return Map?.GetNode(GridDataPosition);
		}

		public Vec3Int GetGridPosition()
		{
			return GridDataPosition;
		}

		protected virtual void ReservationChanged(bool isReserved)
		{
		}

		protected void FixOwnerBuildingMigration()
		{
			ownerBuilding = VillageManager.ActiveVillage.WorldObjectStorage.GetWorldObjectByUniqueId(UniqueID) as BaseBuildingInstance;
		}

		protected virtual void OnStabilityCarrierDestroyed(BaseBuildingInstance destroyedBuilding, bool replaced)
		{
		}

		protected virtual void OnHealthUpdated(StatInstance healthStat)
		{
		}

		protected virtual void OnBuildingRepairingTick(StatInstance healthState)
		{
		}

		protected virtual void OnWaterLevelChanged(WaterDepthLevel waterDepthLevel)
		{
		}

		protected virtual void OnBaseBuildingEnterFinishedState(bool afterLoading = false)
		{
		}

		protected virtual void OnRefreshRoomChanged()
		{
		}

		protected virtual void CheckIfInPrisonCell()
		{
			if (!HasDisposed && OwnerBuilding != null && !OwnerBuilding.HasDisposed)
			{
				isUnavailablePrisonCell = GetRoom()?.RoomType.Prison ?? false;
				OwnerBuilding.IsForbiddenPrisonCell = isUnavailablePrisonCell;
			}
		}

		protected void SetComponentBlueprintID(string componentBlueprintID)
		{
			this.componentBlueprintID = componentBlueprintID;
		}

		private void SubscribeToEvents()
		{
			if (!hasSubscribedToEvents)
			{
				OwnerBuilding.DisposeComponentsEvent += Dispose;
				OwnerBuilding.BaseBuildingEnterFinishedStateEvent += OnBaseBuildingEnterFinishedState;
				OwnerBuilding.WaterLevelChangedEvent += OnWaterLevelChanged;
				Map.BuildingsManagerMain.StabilityCarrierDestroyedEvent += OnStabilityCarrierDestroyed;
				OwnerBuilding.BuildingHealthUpdatedEvent += OnHealthUpdated;
				OwnerBuilding.BuildingRepairingTickEvent += OnBuildingRepairingTick;
				OwnerBuilding.RefreshRoomChangedEvent += OnRefreshRoomChanged;
				hasSubscribedToEvents = true;
			}
		}

		public virtual void Serialize(FVSerializer serializer)
		{
			serializer.Write("uniqueId", uniqueId);
			serializer.Write("componentBlueprintID", componentBlueprintID);
			serializer.Write("isUnavailablePrisonCell", isUnavailablePrisonCell);
		}

		public BaseComponentInstance(FVDeserializer deserializer)
		{
			componentBlueprintID = deserializer.ReadString("componentBlueprintID");
			uniqueId = deserializer.ReadInt("uniqueId");
			isUnavailablePrisonCell = deserializer.ReadBool("isUnavailablePrisonCell");
			if (componentBlueprintID == null && deserializer.HasTempDataKey("uniqueId"))
			{
				uniqueId = (int)deserializer.GetTempData("uniqueId");
				componentBlueprintID = (string)deserializer.GetTempData("componentBlueprintID");
			}
		}
	}
}
