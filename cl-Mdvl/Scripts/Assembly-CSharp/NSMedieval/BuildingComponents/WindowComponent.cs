using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(BaseBuildingViewComponent))]
	public class WindowComponent : BaseComponent
	{
		[NonSerialized]
		private WindowComponentInstance componentInstance;

		[SerializeField]
		private GameObject navmeshSurface;

		public WindowComponentInstance ComponentInstance => componentInstance;

		public event Action WindowLockStatusChangedEvent;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.WindowLockStatusChangedEvent = null;
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
				WindowComponentBlueprint byID = Repository<WindowComponentRepository, WindowComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.WindowComponentID);
				componentInstance = ComponentFactory.CreateComponentInstance(base.OwnerBuilding, byID);
			}
			else
			{
				VillageInstance activeVillage = VillageManager.ActiveVillage;
				componentInstance = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(base.OwnerBuilding.UniqueId) as WindowComponentInstance;
				if (componentInstance == null)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(64, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Windows\\WindowComponent.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Couldn't find WindowComponentInstance in component storage! ID: ");
						messageBuilder.AppendFormatted(base.OwnerBuilding.UniqueId);
					}
					Log.Error(messageBuilder);
					return;
				}
				componentInstance.SetupAfterLoading(base.OwnerBuilding);
			}
			base.BaseComponentInstance = componentInstance;
			componentInstance.Map.WindowComponentManager.AddToCache(this, componentInstance);
			base.BaseBuildingViewComponent.SetAdditionalMenuItemId("windowBuilding");
			base.BaseBuildingViewComponent.RequestInfoPanelDataEvent += OnInfoPanelDataRequested;
			componentInstance.WindowLockStatusChangedEvent += OnLockStatusChanged;
			base.OnBaseBuildingEnterFinishedState(afterLoading);
			ComponentInstance.OwnerBuilding.RefreshWalkableColliderEvent += OnRefreshWalkableCollider;
			RefreshWalkableCollider();
			componentInstance.SetupLocksAfterLoading();
			if (afterLoading)
			{
				componentInstance.SetupLocksAfterLoading();
			}
		}

		private void OnLockStatusChanged()
		{
			this.WindowLockStatusChangedEvent?.Invoke();
		}

		private void OnRefreshWalkableCollider()
		{
			RefreshWalkableCollider();
		}

		private void RefreshWalkableCollider()
		{
			if (componentInstance != null && !componentInstance.HasDisposed && componentInstance.OwnerBuilding != null && !componentInstance.OwnerBuilding.HasDisposed && !(navmeshSurface == null))
			{
				navmeshSurface.SetActive(componentInstance.OwnerBuilding.CanPlaceNavmeshAbove());
			}
		}
	}
}
