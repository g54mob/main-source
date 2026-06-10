using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent))]
	public class MapTableComponent : BaseComponent
	{
		[SerializeField]
		private MapTableComponentInstance componentInstance;

		public MapTableComponentInstance ComponentInstance => componentInstance;

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

		protected override void OnBaseBuildingEnterFinishedState(bool afterLoading = false)
		{
			if (!afterLoading)
			{
				MapTableComponentBlueprint byID = Repository<MapTableComponentRepository, MapTableComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.MapTableComponentID);
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID);
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as MapTableComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(69, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\MapTable\\MapTableComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find CaravanPostComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
					}
					Log.Error(messageBuilder);
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			base.BaseBuildingViewComponent.SetAdditionalMenuItemId("mapTable");
			base.BaseComponentInstance = componentInstance;
			componentInstance.Map.MapTableComponentManager.AddToCache(this, componentInstance);
			base.OnBaseBuildingEnterFinishedState(afterLoading);
		}

		protected override void OnInfoPanelDataRequested()
		{
		}
	}
}
