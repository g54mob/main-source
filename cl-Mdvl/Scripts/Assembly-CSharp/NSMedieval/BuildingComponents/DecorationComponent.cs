using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent), typeof(BuildingUsePositionsComponent))]
	public class DecorationComponent : BaseComponent
	{
		[NonSerialized]
		private BuildingUsePositionsComponent buildingUsePositionsComponent;

		[SerializeField]
		private DecorationComponentInstance componentInstance;

		public BuildingUsePositionsComponent UsePositionsComponent => buildingUsePositionsComponent;

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
				DecorationComponentBlueprint byID = Repository<DecorationComponentRepository, DecorationComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.DecorationComponentID);
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID);
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as DecorationComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(68, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Decorations\\DecorationComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find DecorationComponentInstance in component storage! ID: ");
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
			componentInstance.Map.DecorationComponentManager.AddToCache(this, componentInstance);
			base.OnBaseBuildingEnterFinishedState(afterLoading);
		}
	}
}
