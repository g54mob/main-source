using System;
using NSMedieval.FloatingOverlaySystem;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	public abstract class BaseComponent : MonoBehaviour
	{
		[NonSerialized]
		private BaseBuildingViewComponent baseBuildingViewComponent;

		[NonSerialized]
		private BaseComponentInstance baseComponentInstance;

		public BaseBuildingViewComponent BaseBuildingViewComponent => baseBuildingViewComponent;

		public BaseComponentInstance BaseComponentInstance
		{
			get
			{
				return baseComponentInstance;
			}
			protected set
			{
				baseComponentInstance = value;
			}
		}

		protected BaseBuildingInstance OwnerBuilding => baseBuildingViewComponent.BaseBuildingInstance;

		[field: NonSerialized]
		public event Action AfterComponentPlacedEvent;

		[field: NonSerialized]
		public event Action<bool> ComponentEnterFinishedStateEvent;

		[field: NonSerialized]
		public event Action ComponentEnterFoundationStateEvent;

		public virtual void PreSpawnInitialization()
		{
			baseBuildingViewComponent = GetComponent<BaseBuildingViewComponent>();
			baseBuildingViewComponent.ObjectPlacedOnMapEvent -= OnObjectPlacedOnMap;
			baseBuildingViewComponent.AfterBaseBuildingPlacedEvent -= OnAfterBaseBuildingPlaced;
			baseBuildingViewComponent.ObjectPlacedOnMapEvent += OnObjectPlacedOnMap;
			baseBuildingViewComponent.AfterBaseBuildingPlacedEvent += OnAfterBaseBuildingPlaced;
			baseBuildingViewComponent.EnterPoolEvent += OnEnterPoolOnMainSceneLeaving;
			BaseBuildingViewComponent.ReturnToPoolEvent += OnReturnToPoolDuringGameplay;
		}

		protected virtual void OnInfoPanelDataRequested()
		{
		}

		protected virtual void OnOverrideSelectionExtraView()
		{
		}

		protected virtual void OnBuildingSelected()
		{
		}

		protected virtual void OnBuildingDeselected()
		{
		}

		protected virtual void OnAfterBaseBuildingPlaced(bool afterLoading = false)
		{
			OwnerBuilding.Map.BuildingsManagerMain.CacheBuildingInstance(baseBuildingViewComponent, afterLoading);
			OwnerBuilding.BaseBuildingEnterFinishedStateEvent += OnBaseBuildingEnterFinishedState;
			OwnerBuilding.BaseBuildingEnterFoundationStateEvent += OnBaseBuildingEnterFoundationState;
			this.AfterComponentPlacedEvent?.Invoke();
			this.AfterComponentPlacedEvent = null;
		}

		protected virtual void OnObjectPlacedOnMap(bool afterLoading = false)
		{
		}

		protected virtual void OnBaseBuildingEnterFoundationState(bool afterLoading = false)
		{
			this.ComponentEnterFoundationStateEvent?.Invoke();
			this.ComponentEnterFoundationStateEvent = null;
		}

		protected virtual void OnBaseBuildingEnterFinishedState(bool afterLoading = false)
		{
			this.ComponentEnterFinishedStateEvent?.Invoke(afterLoading);
			this.ComponentEnterFinishedStateEvent = null;
			baseBuildingViewComponent.OverrideSelectionExtraViewEvent += OnOverrideSelectionExtraView;
			baseBuildingViewComponent.RequestInfoPanelDataEvent += OnInfoPanelDataRequested;
			BaseBuildingViewComponent.BuildingSelectedEvent += OnBuildingSelected;
			baseBuildingViewComponent.BuildingDeselectedEvent += OnBuildingDeselected;
			BaseBuildingViewComponent.RequestGuiOverlayHookTransformEvent += OnRequestGuiOverlayHookTransform;
		}

		protected virtual void OnEnterPoolOnMainSceneLeaving()
		{
			EnterPoolClearCache();
		}

		protected virtual void OnReturnToPoolDuringGameplay()
		{
			EnterPoolClearCache();
		}

		protected virtual void OnDestroy()
		{
			this.AfterComponentPlacedEvent = null;
			this.ComponentEnterFinishedStateEvent = null;
			this.ComponentEnterFoundationStateEvent = null;
		}

		protected virtual Transform OnRequestGuiOverlayHookTransform()
		{
			return null;
		}

		private void EnterPoolClearCache()
		{
			if ((bool)baseBuildingViewComponent)
			{
				baseBuildingViewComponent.ObjectPlacedOnMapEvent -= OnObjectPlacedOnMap;
				baseBuildingViewComponent.AfterBaseBuildingPlacedEvent -= OnAfterBaseBuildingPlaced;
				baseBuildingViewComponent.OverrideSelectionExtraViewEvent -= OnOverrideSelectionExtraView;
				baseBuildingViewComponent.RequestInfoPanelDataEvent -= OnInfoPanelDataRequested;
				baseBuildingViewComponent.BuildingSelectedEvent -= OnBuildingSelected;
				baseBuildingViewComponent.BuildingDeselectedEvent -= OnBuildingDeselected;
				BaseBuildingViewComponent.RequestGuiOverlayHookTransformEvent -= OnRequestGuiOverlayHookTransform;
				baseComponentInstance = null;
				FloatingSystemRootTransform floatingSystemRootTransform = GetComponent<FloatingSystemRootTransform>();
				if (floatingSystemRootTransform == null)
				{
					floatingSystemRootTransform = GetComponentInChildren<FloatingSystemRootTransform>();
				}
				if (floatingSystemRootTransform != null)
				{
					UnityEngine.Object.DestroyImmediate(floatingSystemRootTransform);
				}
			}
		}
	}
}
