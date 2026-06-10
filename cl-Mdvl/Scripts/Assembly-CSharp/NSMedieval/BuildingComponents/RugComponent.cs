using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent), typeof(BuildingUsePositionsComponent))]
	public class RugComponent : BaseComponent
	{
		[SerializeField]
		private RugComponentInstance componentInstance;

		[SerializeField]
		private BuildingUsePositionsComponent buildingUsePositionsComponent;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			componentInstance = null;
			buildingUsePositionsComponent = null;
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
			if (!afterLoading)
			{
				RugComponentBlueprint byID = Repository<RugComponentRepository, RugComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.RugComponentID);
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID);
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as RugComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(61, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Rugs\\RugComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find RugComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
					}
					Log.Error(messageBuilder);
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			base.BaseComponentInstance = componentInstance;
			if (buildingUsePositionsComponent != null)
			{
				buildingUsePositionsComponent.InitializePositions();
				componentInstance.WorkplacePositions.UnionWith(buildingUsePositionsComponent.WorkplacePositions);
			}
			componentInstance.Map.RugComponentManager.AddToCache(this, componentInstance);
			base.OnBaseBuildingEnterFinishedState(afterLoading);
		}
	}
}
