using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.UI;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent))]
	public class SignComponent : BaseComponent
	{
		[SerializeField]
		private SignTooltipView tooltipView;

		[SerializeField]
		private SignComponentInstance componentInstance;

		public SignComponentInstance ComponentInstance => componentInstance;

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
				SignComponentBlueprint byID = Repository<SignComponentRepository, SignComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.SignComponentID);
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID);
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as SignComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(62, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Signs\\SignComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find SignComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
					}
					Log.Error(messageBuilder);
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			base.BaseComponentInstance = componentInstance;
			tooltipView.SetTooltipData(ComponentInstance.Message);
			componentInstance.Map.SignComponentManager.AddToCache(this, componentInstance);
			base.OnBaseBuildingEnterFinishedState(afterLoading);
		}

		protected override void OnOverrideSelectionExtraView()
		{
			SelectionExtraView selectionExtraView = null;
			if (tooltipView != null)
			{
				selectionExtraView = new InfoPanelSign(MessageCallback, ComponentInstance.OwnerBuilding);
			}
			base.BaseBuildingViewComponent.SetSelectionExtraView(selectionExtraView);
		}

		private void MessageCallback(string message)
		{
			ComponentInstance.SetMessage(message);
			tooltipView.SetTooltipData(message);
		}
	}
}
