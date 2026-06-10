using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.MovableBuildings;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.Village;

namespace NSMedieval.BuildingComponents
{
	public class FuelConsumerComponent : BaseComponent
	{
		private FuelConsumerComponentInstance componentInstance;

		public FuelConsumerComponentInstance ComponentInstance => componentInstance;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			componentInstance = null;
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
				FuelConsumerComponentBlueprint byID = Repository<FuelConsumerComponentRepository, FuelConsumerComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.FuelConsumerComponentID);
				FuelConsumerCopySettingsData fuelConsumerCopySettingsData = null;
				foreach (ResourceInstance resource in base.OwnerBuilding.Storage.Resources)
				{
					if (resource is MoveBuildingResourceInstance moveBuildingResourceInstance)
					{
						fuelConsumerCopySettingsData = moveBuildingResourceInstance.FuelConsumerCopySettingsData;
						(base.OwnerBuilding.Storage.Take(moveBuildingResourceInstance) as MoveBuildingResourceInstance)?.Dispose();
					}
				}
				if (componentInstance == null)
				{
					componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID);
				}
				if (fuelConsumerCopySettingsData != null)
				{
					componentInstance.PasteFuelConsumerSettings(fuelConsumerCopySettingsData);
				}
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as FuelConsumerComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(123, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\FuelConsumers\\FuelConsumerComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find FuelConsumerComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
						messageBuilder.AppendLiteral(". Creating a new component. This should never happen.");
					}
					Log.Error(messageBuilder);
					FuelConsumerComponentBlueprint byID2 = Repository<FuelConsumerComponentRepository, FuelConsumerComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.FuelConsumerComponentID);
					componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID2);
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			base.BaseComponentInstance = componentInstance;
			base.BaseBuildingViewComponent.SetAdditionalMenuItemId("torchBuilding");
			componentInstance.Map.FuelConsumerComponentManager.AddToCache(this, componentInstance);
			base.OnBaseBuildingEnterFinishedState(afterLoading);
		}

		protected override void OnInfoPanelDataRequested()
		{
			InfoPanelHeader headerData = base.BaseBuildingViewComponent.GetHeaderData();
			InfoPanelBody body = new InfoPanelBody(base.OwnerBuilding.BlueprintId, base.OwnerBuilding.GetBuildingName(), string.Empty, base.BaseBuildingViewComponent.GetInfoStats(), GetBuildPhaseInfo(), base.BaseBuildingViewComponent.GetResourcesInfo(), base.BaseBuildingViewComponent.GetDescriptions(), base.BaseBuildingViewComponent.GetInfos());
			InfoPanelFooter footer = new InfoPanelFooter(base.BaseBuildingViewComponent.GetInfoPanelActions(), base.OwnerBuilding);
			InfoPanelData infoPanelData = new InfoPanelData(InfoPanelDataType.General, headerData, body, footer, new InfoPanelFuelConsumer(ComponentInstance));
			base.BaseBuildingViewComponent.SetInfoPanelData(infoPanelData);
		}

		private List<string> GetBuildPhaseInfo()
		{
			List<string> buildPhaseInfo = base.BaseBuildingViewComponent.GetBuildPhaseInfo();
			if (componentInstance.Underwater)
			{
				string text = MonoSingleton<LocalizationController>.Instance.GetText("structure_in_water");
				buildPhaseInfo.Add(MonoSingleton<LocalizationController>.Instance.GetText("not_available") + " (" + text + ")");
			}
			if (componentInstance.TorchState == TorchState.Off)
			{
				return buildPhaseInfo;
			}
			if (componentInstance.CanBurn())
			{
				buildPhaseInfo.Add(MonoSingleton<LocalizationController>.Instance.GetText("info_can_ignite_projectiles") ?? "");
				return buildPhaseInfo;
			}
			if (MonoSingleton<ResourcePileTracker>.Instance.GetCount(componentInstance.Blueprint.FuelType).AllowedCount <= 0)
			{
				buildPhaseInfo.Add("<style=DefaultRed>" + MonoSingleton<LocalizationController>.Instance.GetText("general_lacks") + ": " + MonoSingleton<LocalizationController>.Instance.GetText("fuel_type") + "</style>");
			}
			return buildPhaseInfo;
		}
	}
}
