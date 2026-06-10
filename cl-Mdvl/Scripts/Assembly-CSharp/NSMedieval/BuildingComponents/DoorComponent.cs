using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.RoomDetection;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(BaseBuildingViewComponent), typeof(BuildingUsePositionsComponent))]
	public class DoorComponent : BaseComponent
	{
		[NonSerialized]
		private DoorViewComponent viewComponent;

		[NonSerialized]
		private DoorComponentInstance componentInstance;

		[SerializeField]
		private GameObject navmeshSurface;

		[SerializeField]
		private GameObject lockMarker;

		[SerializeField]
		private GameObject thresholdNavmeshSurface;

		[NonSerialized]
		private Transform useTransform;

		[NonSerialized]
		private BuildingUsePositionsComponent buildingUsePositionsComponent;

		public Transform UseTransform => useTransform;

		public DoorComponentInstance ComponentInstance => componentInstance;

		public event Action DoorLockStatusChangedEvent;

		public event Action<bool> DoorEnteredFinishedStateEvent;

		public event Action DrawbridgeClosingCanceledEvent;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.DoorLockStatusChangedEvent = null;
			this.DoorEnteredFinishedStateEvent = null;
			viewComponent = null;
			componentInstance = null;
			buildingUsePositionsComponent = null;
		}

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			viewComponent = GetComponent<DoorViewComponent>();
			buildingUsePositionsComponent = GetComponent<BuildingUsePositionsComponent>();
			lockMarker.SetActive(value: false);
		}

		protected override void OnEnterPoolOnMainSceneLeaving()
		{
			base.OnEnterPoolOnMainSceneLeaving();
			componentInstance = null;
			if (buildingUsePositionsComponent != null)
			{
				buildingUsePositionsComponent.Dispose();
			}
		}

		protected override void OnReturnToPoolDuringGameplay()
		{
			base.OnReturnToPoolDuringGameplay();
			componentInstance = null;
			if (buildingUsePositionsComponent != null)
			{
				buildingUsePositionsComponent.Dispose();
			}
		}

		public void StartCoroutineRefreshDoorAnim()
		{
			StartCoroutine(RefreshDoorAnimAt());
		}

		private IEnumerator RefreshDoorAnimAt()
		{
			yield return new WaitForEndOfFrame();
			if (viewComponent != null)
			{
				viewComponent.UpdateDoorAnim();
			}
		}

		protected override void OnBaseBuildingEnterFinishedState(bool afterLoading = false)
		{
			if (!afterLoading)
			{
				DoorComponentBlueprint byID = Repository<DoorComponentRepository, DoorComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.DoorComponentID);
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID);
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as DoorComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(101, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Doors\\DoorComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find DoorComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
						messageBuilder.AppendLiteral(". Creating new door component instance.");
					}
					Log.Error(messageBuilder);
					componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, Repository<DoorComponentRepository, DoorComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.DoorComponentID));
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			base.BaseComponentInstance = componentInstance;
			componentInstance.Map.DoorComponentManager.AddToCache(this, componentInstance);
			base.BaseBuildingViewComponent.SetAdditionalMenuItemId("doorBuilding");
			base.BaseBuildingViewComponent.RequestInfoPanelDataEvent += OnInfoPanelDataRequested;
			componentInstance.DoorLockStatusChangedEvent += OnLockStatusChanged;
			base.OnBaseBuildingEnterFinishedState(afterLoading);
			ComponentInstance.OwnerBuilding.RefreshWalkableColliderEvent += OnRefreshWalkableCollider;
			RefreshWalkableCollider();
			componentInstance.SetupLocks();
			useTransform = buildingUsePositionsComponent.UseTransforms.FirstOrDefault();
			if (useTransform != null)
			{
				ComponentInstance.SetUsePosition(useTransform.position.ToGridVec3Int());
			}
			this.DoorEnteredFinishedStateEvent?.Invoke(afterLoading);
		}

		protected override void OnInfoPanelDataRequested()
		{
			InfoPanelHeader headerData = base.BaseBuildingViewComponent.GetHeaderData();
			InfoPanelBody body = new InfoPanelBody(base.OwnerBuilding.BlueprintId, base.OwnerBuilding.GetBuildingName(), string.Empty, base.BaseBuildingViewComponent.GetInfoStats(), GetBuildPhaseInfo(), base.BaseBuildingViewComponent.GetResourcesInfo(), base.BaseBuildingViewComponent.GetDescriptions(), base.BaseBuildingViewComponent.GetInfos());
			InfoPanelFooter footer = new InfoPanelFooter(base.BaseBuildingViewComponent.GetInfoPanelActions(), null, base.OwnerBuilding, componentInstance);
			InfoPanelMeshVariations extraPanelView = null;
			if (base.OwnerBuilding.Blueprint.ShowVariations)
			{
				extraPanelView = new InfoPanelMeshVariations(base.OwnerBuilding);
			}
			InfoPanelData infoPanelData = new InfoPanelData(InfoPanelDataType.General, headerData, body, footer, extraPanelView);
			base.BaseBuildingViewComponent.SetInfoPanelData(infoPanelData);
		}

		protected override void OnAfterBaseBuildingPlaced(bool afterLoading = false)
		{
			base.OnAfterBaseBuildingPlaced(afterLoading);
			if (!afterLoading)
			{
				return;
			}
			MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.1f).Then(delegate
			{
				if (!(base.transform == null) && base.OwnerBuilding != null && !base.OwnerBuilding.HasDisposed)
				{
					base.transform.position = GridUtils.GetWorldPosition(base.OwnerBuilding.GridDataPosition);
					base.transform.eulerAngles = new Vector3(0f, base.OwnerBuilding.Angle, 0f);
				}
			});
		}

		private List<string> GetBuildPhaseInfo()
		{
			List<string> buildPhaseInfo = base.BaseBuildingViewComponent.GetBuildPhaseInfo();
			buildPhaseInfo.AddIfNotNullOrEmpty(BuildingUtils.GetLocalizedDoorLockState(componentInstance));
			return buildPhaseInfo;
		}

		private void OnLockStatusChanged()
		{
			lockMarker.SetActive(componentInstance.LockState == LockState.Locked);
			this.DoorLockStatusChangedEvent?.Invoke();
			MapNode mapNode = base.OwnerBuilding?.GetNode();
			if (mapNode == null)
			{
				return;
			}
			using PooledHashSet<Room> pooledHashSet = HashSetPool<Room>.GetJanitor();
			foreach (MapNode neighbour in mapNode.Neighbours)
			{
				Room room = base.OwnerBuilding.Map.RoomDetection.GetRoom(neighbour);
				if (room != null && !pooledHashSet.Contains(room))
				{
					room.CalculateHasOpenPortals();
					pooledHashSet.Add(room);
				}
			}
		}

		private void OnDrawbridgeClosingCanceled()
		{
			lockMarker.SetActive(value: false);
		}

		private void OnRefreshWalkableCollider()
		{
			RefreshWalkableCollider();
		}

		private void RefreshWalkableCollider()
		{
			if (componentInstance != null && componentInstance.OwnerBuilding != null && !componentInstance.OwnerBuilding.HasDisposed && !(navmeshSurface == null))
			{
				navmeshSurface.SetActive(componentInstance.OwnerBuilding.CanPlaceNavmeshAbove());
			}
		}
	}
}
