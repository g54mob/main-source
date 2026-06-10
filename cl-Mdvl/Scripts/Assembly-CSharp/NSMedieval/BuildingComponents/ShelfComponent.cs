using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers.Selection.EventData;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Managers.Selection;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.MovableBuildings;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StorageUniversal;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent), typeof(UniversalStorageTooltipView))]
	public class ShelfComponent : BaseComponent
	{
		[SerializeField]
		private ShelfComponentInstance componentInstance;

		[NonSerialized]
		private UniversalStorageTooltipView universalStorageTooltipView;

		[NonSerialized]
		private ResourcePileIndicatorView indicatorUI;

		public ShelfComponentInstance ComponentInstance => componentInstance;

		public BaseBuildingInstance BaseBuildingInstance => base.BaseBuildingViewComponent.BaseBuildingInstance;

		public event Action ShelfEnteredFinishedStateEvent;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.ShelfEnteredFinishedStateEvent = null;
			componentInstance = null;
			universalStorageTooltipView = null;
		}

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			universalStorageTooltipView = GetComponent<UniversalStorageTooltipView>();
		}

		protected override void OnEnterPoolOnMainSceneLeaving()
		{
			base.OnEnterPoolOnMainSceneLeaving();
			componentInstance = null;
		}

		protected override void OnReturnToPoolDuringGameplay()
		{
			base.OnReturnToPoolDuringGameplay();
			componentInstance = null;
		}

		protected override void OnBaseBuildingEnterFinishedState(bool afterLoading = false)
		{
			if (!afterLoading)
			{
				ShelfComponentBlueprint byID = Repository<ShelfComponentRepository, ShelfComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.ShelfComponentID);
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID);
				ShelfCopySettingsData shelfCopySettingsData = null;
				foreach (ResourceInstance resource in base.OwnerBuilding.Storage.Resources)
				{
					if (resource is MoveBuildingResourceInstance moveBuildingResourceInstance)
					{
						shelfCopySettingsData = moveBuildingResourceInstance.ShelfCopySettingsData;
					}
				}
				if (shelfCopySettingsData != null)
				{
					componentInstance.PasteStorageSettings(shelfCopySettingsData);
				}
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as ShelfComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(86, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Shelves\\ShelfComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find ShelfComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
						messageBuilder.AppendLiteral(". Destroying the shelf.");
					}
					Log.Error(messageBuilder);
					base.OwnerBuilding.Map.BuildingsManagerMain.DestroyBuilding(base.OwnerBuilding);
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			MonoSingleton<SelectionManager>.Instance.AllowOrForbidEvent += OnForbidOrAllowPile;
			componentInstance.ShelfForbiddenStatusChangeEvent += OnShelfForbiddenStatusChange;
			base.BaseComponentInstance = componentInstance;
			componentInstance.Map.ShelfComponentManager.AddToCache(this, componentInstance);
			base.BaseBuildingViewComponent.RequestInfoPanelDataEvent += OnInfoPanelDataRequested;
			componentInstance.OnDisposedEvent += OnDisposeComponent;
			base.OnBaseBuildingEnterFinishedState(afterLoading);
			base.BaseBuildingViewComponent.SetAdditionalMenuItemId("storageBuilding");
			universalStorageTooltipView.Setup(ComponentInstance);
			Vector3 position = base.transform.position;
			indicatorUI = UnityEngine.Object.Instantiate(position: new Vector3(position.x, Mathf.Clamp(position.y + (float)base.OwnerBuilding.Size.y + 0.5f, 0f, position.y + (float)World.MapBlockHeight - 0.5f), position.z), original: MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress("resource_pile_indicator"), rotation: Quaternion.identity, parent: base.transform).GetComponent<ResourcePileIndicatorView>();
			UpdateIndicator();
			this.ShelfEnteredFinishedStateEvent?.Invoke();
		}

		private void OnDisposeComponent(IDisposable disposable)
		{
			if (MonoSingleton<SelectionManager>.IsInstantiated())
			{
				MonoSingleton<SelectionManager>.Instance.AllowOrForbidEvent -= OnForbidOrAllowPile;
				componentInstance.ShelfForbiddenStatusChangeEvent -= OnShelfForbiddenStatusChange;
			}
			universalStorageTooltipView = null;
			if ((bool)indicatorUI)
			{
				UnityEngine.Object.Destroy(indicatorUI);
				indicatorUI = null;
			}
		}

		private void OnForbidOrAllowPile(OrderEventData eventData)
		{
			if ((int)(base.transform.position.y / (float)World.MapBlockHeight) <= MonoSingleton<World>.Instance.ElevationLevel && eventData.OrderAllowType.HasFlag(OrderAllowType.Piles) && SelectionManager.IsWithinSelectionBounds(base.transform.position, eventData.MinPoint.x, eventData.MaxPoint.x, eventData.MinPoint.y, eventData.MaxPoint.y, isTolerantSingleSelection: true) && (!eventData.AffectOnlyOneLayer || (int)base.transform.position.y == (int)eventData.Y) && componentInstance?.AllStorage != null && componentInstance.AllStorage.Count != 0)
			{
				if (eventData.OrderType.Equals(OrderType.Allow))
				{
					SetForbidden(isForbidden: false);
				}
				else
				{
					SetForbidden(isForbidden: true);
				}
			}
		}

		private void SetForbidden(bool isForbidden)
		{
			componentInstance?.SetForbidden(isForbidden);
		}

		protected override void OnInfoPanelDataRequested()
		{
			InfoPanelHeader header = new InfoPanelHeader(BaseBuildingInstance.BlueprintId, ComponentInstance.StorageName, string.Empty);
			InfoPanelBody body = new InfoPanelBody(base.OwnerBuilding.BlueprintId, ComponentInstance.StorageName, string.Empty, base.BaseBuildingViewComponent.GetInfoStats(), GetBuildPhaseInfo(), base.BaseBuildingViewComponent.GetResourcesInfo(), base.BaseBuildingViewComponent.GetDescriptions(), base.BaseBuildingViewComponent.GetInfos(), BaseBuildingInstance.Blueprint.BuildingSubCategoryUI, ComponentInstance.GetStoredPiles(), ComponentInstance.GetLifeEventLog());
			List<InfoPanelAction> list = new List<InfoPanelAction>();
			int currentIndex = (componentInstance.IsForbidden() ? 1 : 0);
			KeyValuePair<SelectionInputActionData, Action>[] objectActions = new KeyValuePair<SelectionInputActionData, Action>[2]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Forbid"), delegate
				{
					SetForbidden(isForbidden: true);
				}),
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Allow"), delegate
				{
					SetForbidden(isForbidden: false);
				})
			};
			list.Add(new InfoPanelAction(objectActions, currentIndex));
			list.AddRange(base.BaseBuildingViewComponent.GetInfoPanelActions());
			InfoPanelFooter footer = new InfoPanelFooter(list, base.OwnerBuilding);
			InfoPanelData infoPanelData = new InfoPanelData(InfoPanelDataType.General, header, body, footer, new InfoPanelStockpile(ComponentInstance));
			base.BaseBuildingViewComponent.SetInfoPanelData(infoPanelData);
		}

		private List<string> GetBuildPhaseInfo()
		{
			List<string> buildPhaseInfo = base.BaseBuildingViewComponent.GetBuildPhaseInfo();
			if (componentInstance.IsForbidden())
			{
				buildPhaseInfo.Add(MonoSingleton<LocalizationController>.Instance.GetText("forbidden_shelf_info") ?? "");
			}
			return buildPhaseInfo;
		}

		private void OnShelfForbiddenStatusChange()
		{
			UpdateIndicator();
		}

		private void UpdateIndicator()
		{
			if (componentInstance != null && !componentInstance.HasDisposed)
			{
				ResourcePileIndicatorStatus indicator = (componentInstance.IsForbidden() ? ResourcePileIndicatorStatus.Forbidden : ResourcePileIndicatorStatus.None);
				indicatorUI.SetIndicator(indicator);
			}
		}
	}
}
