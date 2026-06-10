using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Village;
using NSMedieval_Pooling;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent))]
	public class ChairComponent : BaseComponent
	{
		[SerializeField]
		private ChairComponentInstance componentInstance;

		private Transform chairSitPosition;

		public Transform ChairSitPosition => chairSitPosition;

		public ChairComponentInstance ComponentInstance => componentInstance;

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
				ChairComponentBlueprint byID = Repository<ChairComponentRepository, ChairComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.ChairComponentID);
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID);
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as ChairComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(63, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Chairs\\ChairComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find ChairComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
					}
					Log.Error(messageBuilder);
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			base.BaseComponentInstance = componentInstance;
			componentInstance.Map.ChairComponentManager.AddToCache(this, componentInstance);
			chairSitPosition = GameObjectPool.GetDefaultEmpty(returnActive: true, "SitPosition").transform;
			chairSitPosition.SetParent(base.BaseBuildingViewComponent.Finished.transform, worldPositionStays: false);
			componentInstance.Blueprint.SittingPosition.ApplyToTransform(chairSitPosition);
			base.OnBaseBuildingEnterFinishedState(afterLoading);
		}
	}
}
