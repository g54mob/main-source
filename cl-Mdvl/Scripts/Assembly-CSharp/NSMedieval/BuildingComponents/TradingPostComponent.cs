using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Repository;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent), typeof(BuildingUsePositionsComponent))]
	public class TradingPostComponent : BaseComponent
	{
		[SerializeField]
		private TradingPostComponentInstance componentInstance;

		[SerializeField]
		private BuildingUsePositionsComponent buildingUsePositionsComponent;

		public TradingPostComponentInstance ComponentInstance => componentInstance;

		public BuildingUsePositionsComponent BuildingUsePositionsComponent => buildingUsePositionsComponent;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			componentInstance = null;
			buildingUsePositionsComponent = null;
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
			buildingUsePositionsComponent.InitializePositions();
			if (!afterLoading)
			{
				TradingPostComponentBlueprint byID = Repository<TradingPostComponentRepository, TradingPostComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.TradingPostComponentID);
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID);
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as TradingPostComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(69, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\TradingPost\\TradingPostComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find TradingPostComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
					}
					Log.Error(messageBuilder);
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			componentInstance.WorkplacePositions.AddRangeUnique(buildingUsePositionsComponent.WorkplacePositions);
			base.BaseComponentInstance = componentInstance;
			base.BaseBuildingViewComponent.SetAdditionalMenuItemId("tradingPost");
			componentInstance.Map.TradingPostComponentManager.AddToCache(this, componentInstance);
			base.OnBaseBuildingEnterFinishedState(afterLoading);
		}
	}
}
