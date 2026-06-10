using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent), typeof(BuildingUsePositionsComponent))]
	public class ShrineComponent : BaseComponent
	{
		[NonSerialized]
		private BuildingUsePositionsComponent buildingUsePositionsComponent;

		[SerializeField]
		private ShrineComponentInstance componentInstance;

		public BuildingUsePositionsComponent ReservablePositionsComponent => buildingUsePositionsComponent;

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
				ShrineComponentBlueprint byID = Repository<ShrineComponentRepository, ShrineComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.ShrineComponentID);
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID, reservablePositionsComponentInstance);
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as ShrineComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(64, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Shrines\\ShrineComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find ShrineComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
					}
					Log.Error(messageBuilder);
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			componentInstance.CacheReservablePositionsComponentInstance(reservablePositionsComponentInstance);
			base.BaseComponentInstance = componentInstance;
			componentInstance.Map.ShrineComponentManager.AddToCache(this, componentInstance);
			base.OnBaseBuildingEnterFinishedState(afterLoading);
		}

		protected override void OnInfoPanelDataRequested()
		{
		}
	}
}
