using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[DisallowMultipleComponent]
	public class SocketComponent : BaseComponent
	{
		[SerializeField]
		private BaseBuildingViewComponent baseBuildingViewComponent;

		[SerializeField]
		private SocketComponentInstance componentInstance;

		public SocketComponentInstance ComponentInstance => componentInstance;

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

		protected override void OnDestroy()
		{
			base.OnDestroy();
			baseBuildingViewComponent = null;
			componentInstance = null;
		}

		protected override void OnObjectPlacedOnMap(bool afterLoading = false)
		{
			if (!afterLoading)
			{
				componentInstance = ComponentFactory.CreateComponentInstance(baseBuildingViewComponent.BaseBuildingInstance);
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as SocketComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(133, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\BuildingSockets\\SocketComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find SocketComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
						messageBuilder.AppendLiteral("; grid position ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.GridDataPosition);
						messageBuilder.AppendLiteral(". Creating a new component. This should never happen.");
					}
					Log.Error(messageBuilder);
					componentInstance = ComponentFactory.CreateComponentInstance(baseBuildingViewComponent.BaseBuildingInstance);
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			base.BaseComponentInstance = componentInstance;
			componentInstance.Map.SocketComponentManager.AddToCache(this, componentInstance);
			base.OnObjectPlacedOnMap(afterLoading);
		}
	}
}
