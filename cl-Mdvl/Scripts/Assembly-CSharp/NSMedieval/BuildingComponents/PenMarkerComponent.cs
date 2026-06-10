using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.UI;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent))]
	public class PenMarkerComponent : BaseComponent
	{
		[SerializeField]
		private PenMarkerComponentInstance componentInstance;

		public BaseBuildingInstance BaseBuildingInstance => base.BaseBuildingViewComponent.BaseBuildingInstance;

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
				PenMarkerComponentBlueprint byID = Repository<PenMarkerComponentRepository, PenMarkerComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.PenMarkerComponentID);
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID);
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as PenMarkerComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(67, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\PenMarkers\\PenMarkerComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find PenMarkerComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
					}
					Log.Error(messageBuilder);
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			base.BaseComponentInstance = componentInstance;
			componentInstance.Map.PenMarkerComponentManager.AddToCache(this, componentInstance);
			base.OnBaseBuildingEnterFinishedState(afterLoading);
		}

		protected override void OnInfoPanelDataRequested()
		{
			InfoPanelHeader header = new InfoPanelHeader(BaseBuildingInstance.BlueprintId, BaseBuildingInstance.GetBuildingName(), string.Empty);
			InfoPanelBody body = new InfoPanelBody(base.OwnerBuilding.BlueprintId, base.OwnerBuilding.GetBuildingName(), string.Empty, base.BaseBuildingViewComponent.GetInfoStats(), base.BaseBuildingViewComponent.GetBuildPhaseInfo(), base.BaseBuildingViewComponent.GetResourcesInfo(), base.BaseBuildingViewComponent.GetDescriptions(), base.BaseBuildingViewComponent.GetInfos());
			InfoPanelFooter footer = new InfoPanelFooter(base.BaseBuildingViewComponent.GetInfoPanelActions(), base.OwnerBuilding);
			InfoPanelData infoPanelData = new InfoPanelData(InfoPanelDataType.General, header, body, footer, new InfoPanelPenMarker(BaseBuildingInstance));
			base.BaseBuildingViewComponent.SetInfoPanelData(infoPanelData);
		}
	}
}
