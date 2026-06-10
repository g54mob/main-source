using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.UI;
using NSMedieval_Pooling;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	public class BedComponent : BaseComponent
	{
		[SerializeField]
		private BedComponentInstance componentInstance;

		private Transform sleepTRS;

		[SerializeField]
		private Transform unavailableIcon;

		public BedComponentInstance ComponentInstance => componentInstance;

		public Transform SleepTRS => sleepTRS;

		public void SetUnavailableIconVisible(bool isBedUnavailable)
		{
			if (!(unavailableIcon == null))
			{
				unavailableIcon.gameObject.SetActive(isBedUnavailable);
			}
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
				BedComponentBlueprint byID = Repository<BedComponentRepository, BedComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.BedComponentID);
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID);
			}
			else
			{
				componentInstance = base.OwnerBuilding.Village.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as BedComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(61, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Beds\\BedComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find BedComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
					}
					Log.Error(messageBuilder);
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			base.BaseComponentInstance = componentInstance;
			componentInstance.Map.BedComponentManager.AddToCache(this, componentInstance);
			OnAvailabilityChanged(componentInstance.IsUnavailable);
			componentInstance.BedAvailabilityChangedEvent += OnAvailabilityChanged;
			sleepTRS = GameObjectPool.GetDefaultEmpty(returnActive: true, "SleepPosition").transform;
			sleepTRS.SetParent(base.BaseBuildingViewComponent.Finished.transform, worldPositionStays: false);
			componentInstance.Blueprint.SleepPosition.ApplyToTransform(sleepTRS);
			base.OnBaseBuildingEnterFinishedState(afterLoading);
		}

		protected override void OnInfoPanelDataRequested()
		{
			InfoPanelHeader headerData = base.BaseBuildingViewComponent.GetHeaderData();
			InfoPanelBody body = new InfoPanelBody(base.OwnerBuilding.BlueprintId, base.OwnerBuilding.GetBuildingName(), string.Empty, base.BaseBuildingViewComponent.GetInfoStats(), GetBuildPhaseInfo(), base.BaseBuildingViewComponent.GetResourcesInfo(), base.BaseBuildingViewComponent.GetDescriptions(), base.BaseBuildingViewComponent.GetInfos());
			InfoPanelFooter footer = new InfoPanelFooter(base.BaseBuildingViewComponent.GetInfoPanelActions(), base.OwnerBuilding);
			InfoPanelData infoPanelData = new InfoPanelData(InfoPanelDataType.General, headerData, body, footer);
			base.BaseBuildingViewComponent.SetInfoPanelData(infoPanelData);
		}

		private List<string> GetBuildPhaseInfo()
		{
			List<string> buildPhaseInfo = base.BaseBuildingViewComponent.GetBuildPhaseInfo();
			if (ComponentInstance.IsUnavailable)
			{
				buildPhaseInfo.Add(MonoSingleton<LocalizationController>.Instance.GetText("not_available") + " (" + ComponentInstance.GetUnavailableReasons() + ")");
			}
			return buildPhaseInfo;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			componentInstance = null;
		}

		private void OnAvailabilityChanged(bool isUnavailable)
		{
			if (base.BaseComponentInstance != null && !base.BaseComponentInstance.HasDisposed && !LoadingController.IsLeavingMainScene && !LoadingController.IsSceneTransition)
			{
				unavailableIcon.gameObject.SetActive(isUnavailable);
			}
		}
	}
}
