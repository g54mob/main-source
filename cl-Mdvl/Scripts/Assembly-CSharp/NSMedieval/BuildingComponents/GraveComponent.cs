using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent))]
	public class GraveComponent : BaseComponent
	{
		[SerializeField]
		private GraveComponentInstance componentInstance;

		public GraveComponentInstance ComponentInstance => componentInstance;

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
				GraveComponentBlueprint byID = Repository<GraveComponentRepository, GraveComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.GraveComponentID);
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID);
				base.BaseComponentInstance = componentInstance;
				componentInstance.Map.GraveComponentManager.AddToCache(this, componentInstance);
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as GraveComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(63, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Graves\\GraveComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find GraveComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
					}
					Log.Error(messageBuilder);
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			base.BaseComponentInstance = componentInstance;
			componentInstance.Map.GraveComponentManager.AddToCache(this, componentInstance);
			base.OnBaseBuildingEnterFinishedState(afterLoading);
		}

		protected override void OnInfoPanelDataRequested()
		{
			InfoPanelHeader headerData = base.BaseBuildingViewComponent.GetHeaderData();
			InfoPanelBody body = new InfoPanelBody(base.OwnerBuilding.BlueprintId, base.OwnerBuilding.GetBuildingName() + " - " + componentInstance.GetBodyName(), string.Empty, base.BaseBuildingViewComponent.GetInfoStats(), GetBuildPhaseInfo(), base.BaseBuildingViewComponent.GetResourcesInfo(), base.BaseBuildingViewComponent.GetDescriptions(), base.BaseBuildingViewComponent.GetInfos(), BuildingSubCategoryUI.SubCtgGraves, componentInstance.GetLifeEventLogs());
			InfoPanelFooter footer = new InfoPanelFooter(base.BaseBuildingViewComponent.GetInfoPanelActions(), base.OwnerBuilding);
			InfoPanelGraves extraPanelView = (base.OwnerBuilding.ConstructionPhase.Equals(ConstructionPhase.Finished) ? new InfoPanelGraves(componentInstance) : null);
			InfoPanelData infoPanelData = new InfoPanelData(InfoPanelDataType.General, headerData, body, footer, extraPanelView);
			base.BaseBuildingViewComponent.SetInfoPanelData(infoPanelData);
		}

		private List<string> GetBuildPhaseInfo()
		{
			List<string> list = new List<string>();
			list.AddRange(base.BaseBuildingViewComponent.GetBuildPhaseInfo());
			if (componentInstance.Underwater)
			{
				string text = MonoSingleton<LocalizationController>.Instance.GetText("structure_in_water");
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("not_available") + " (" + text + ")");
			}
			return list;
		}
	}
}
