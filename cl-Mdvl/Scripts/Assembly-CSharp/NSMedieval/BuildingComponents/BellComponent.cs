using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.UI;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent))]
	public class BellComponent : BaseComponent
	{
		[SerializeField]
		private BellComponentInstance componentInstance;

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
				BellComponentBlueprint byID = Repository<BellComponentRepository, BellComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.BellComponentID);
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID);
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as BellComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(62, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Bell\\BellComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find BellComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
					}
					Log.Error(messageBuilder);
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			base.BaseComponentInstance = componentInstance;
			componentInstance.Map.BellComponentManager.AddToCache(this, componentInstance);
			base.OnBaseBuildingEnterFinishedState(afterLoading);
		}

		protected override void OnInfoPanelDataRequested()
		{
			InfoPanelHeader header = new InfoPanelHeader(BaseBuildingInstance.BlueprintId, BaseBuildingInstance.GetBuildingName(), string.Empty);
			InfoPanelBody body = new InfoPanelBody(base.OwnerBuilding.BlueprintId, base.OwnerBuilding.GetBuildingName(), string.Empty, base.BaseBuildingViewComponent.GetInfoStats(), base.BaseBuildingViewComponent.GetBuildPhaseInfo(), base.BaseBuildingViewComponent.GetResourcesInfo(), base.BaseBuildingViewComponent.GetDescriptions(), base.BaseBuildingViewComponent.GetInfos());
			List<InfoPanelAction> infoPanelActions = base.BaseBuildingViewComponent.GetInfoPanelActions();
			int currentIndex = (componentInstance.IsActivated ? 1 : 0);
			KeyValuePair<SelectionInputActionData, Action>[] objectActions = new KeyValuePair<SelectionInputActionData, Action>[2]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("ActivateBell"), delegate
				{
					componentInstance.Activate();
				}),
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("DeactivateBell"), delegate
				{
					componentInstance.Deactivate();
				})
			};
			infoPanelActions.Insert(0, new InfoPanelAction(objectActions, currentIndex));
			InfoPanelFooter footer = new InfoPanelFooter(infoPanelActions, base.OwnerBuilding);
			InfoPanelData infoPanelData = new InfoPanelData(InfoPanelDataType.General, header, body, footer, new InfoPanelBell(BaseBuildingInstance));
			base.BaseBuildingViewComponent.SetInfoPanelData(infoPanelData);
		}
	}
}
