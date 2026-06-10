using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent), typeof(BuildingUsePositionsComponent))]
	public class WellComponent : BaseComponent
	{
		[SerializeField]
		private WellComponentInstance componentInstance;

		[SerializeField]
		private GameObject wellUnavailableIndicator;

		[NonSerialized]
		private BuildingUsePositionsComponent buildingUsePositionsComponent;

		public WellComponentInstance ComponentInstance => componentInstance;

		public BuildingUsePositionsComponent BuildingUsePositionsComponent => buildingUsePositionsComponent;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			buildingUsePositionsComponent = null;
			componentInstance = null;
		}

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			buildingUsePositionsComponent = GetComponent<BuildingUsePositionsComponent>();
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

		protected override void OnBaseBuildingEnterFinishedState(bool afterLoading = false)
		{
			ReservablePositionsComponentInstance reservablePositionsComponentInstance = new ReservablePositionsComponentInstance();
			reservablePositionsComponentInstance.SetupReservablePositions(buildingUsePositionsComponent.UseTransforms);
			if (!afterLoading)
			{
				WellComponentBlueprint byID = Repository<WellComponentRepository, WellComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.WellComponentID);
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID);
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as WellComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(62, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Wells\\WellComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find WellComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
					}
					Log.Error(messageBuilder);
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			componentInstance.CacheReservablePositionsComponentInstance(reservablePositionsComponentInstance);
			base.BaseComponentInstance = componentInstance;
			componentInstance.Map.WellComponentManager.AddToCache(this, componentInstance);
			componentInstance.RefreshCanBeUsedEvent += OnAvailabilityChanged;
			OnAvailabilityChanged(!componentInstance.CanBeUsed);
			base.OnBaseBuildingEnterFinishedState(afterLoading);
		}

		private void OnAvailabilityChanged(bool isUnavailable)
		{
			wellUnavailableIndicator.SetActive(isUnavailable);
		}
	}
}
