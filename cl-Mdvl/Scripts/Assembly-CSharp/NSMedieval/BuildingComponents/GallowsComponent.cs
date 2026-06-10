using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent), typeof(BuildingUsePositionsComponent))]
	public class GallowsComponent : BaseComponent
	{
		[SerializeField]
		private GallowsComponentInstance componentInstance;

		[SerializeField]
		private BuildingUsePositionsComponent buildingUsePositionsComponent;

		public GallowsComponentInstance ComponentInstance => componentInstance;

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
				GallowsComponentBlueprint byID = Repository<GallowsComponentRepository, GallowsComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.GallowsComponentID);
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID);
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as GallowsComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(65, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Gallows\\GallowsComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find GallowsComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
					}
					Log.Error(messageBuilder);
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			componentInstance.WorkplacePositions.UnionWith(buildingUsePositionsComponent.WorkplacePositions);
			componentInstance.AnimationPositions.UnionWith(buildingUsePositionsComponent.AnimationPositions);
			base.BaseComponentInstance = componentInstance;
			base.BaseBuildingViewComponent.SetAdditionalMenuItemId("gallows");
			componentInstance.Map.GallowsComponentManager.AddToCache(this, componentInstance);
			base.OnBaseBuildingEnterFinishedState(afterLoading);
		}
	}
}
