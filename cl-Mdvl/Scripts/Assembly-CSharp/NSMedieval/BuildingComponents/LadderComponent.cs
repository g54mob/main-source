using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent))]
	public class LadderComponent : BaseComponent
	{
		[SerializeField]
		private LadderComponentInstance componentInstance;

		public LadderComponentInstance ComponentInstance => componentInstance;

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
				LadderComponentBlueprint byID = Repository<LadderComponentRepository, LadderComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.LadderComponentID);
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID);
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as LadderComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(64, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Ladders\\LadderComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find LadderComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
					}
					Log.Error(messageBuilder);
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			base.BaseComponentInstance = componentInstance;
			componentInstance.Map.LadderComponentManager.AddToCache(this, componentInstance);
			base.OnBaseBuildingEnterFinishedState(afterLoading);
		}

		protected override void OnInfoPanelDataRequested()
		{
		}
	}
}
