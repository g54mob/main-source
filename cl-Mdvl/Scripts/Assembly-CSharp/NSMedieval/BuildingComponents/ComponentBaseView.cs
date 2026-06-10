using System;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	public abstract class ComponentBaseView : MonoBehaviour
	{
		[NonSerialized]
		protected BaseBuildingViewComponent BaseBuildingViewComponent;

		[NonSerialized]
		private BaseComponent baseComponent;

		protected BaseBuildingInstance BaseBuildingInstance => BaseBuildingViewComponent.BaseBuildingInstance;

		public virtual void PreSpawnInitialization()
		{
			baseComponent = GetComponent<BaseComponent>();
			BaseBuildingViewComponent = GetComponent<BaseBuildingViewComponent>();
			baseComponent.ComponentEnterFoundationStateEvent += OnComponentEnterFoundationState;
			baseComponent.ComponentEnterFinishedStateEvent += OnComponentEnterFinishedState;
			BaseBuildingViewComponent.EnterPoolEvent += OnEnterPool;
		}

		protected virtual void OnComponentEnterFoundationState()
		{
		}

		protected virtual void OnComponentEnterFinishedState(bool afterLoading = false)
		{
			baseComponent.BaseComponentInstance.OnDisposedEvent += OnBuildingDisposed;
			baseComponent.BaseComponentInstance.DisposeComponentsEvent += OnBuildingDisposed;
			BaseBuildingViewComponent.LayerObjectHide.ShowObjectEvent += OnShowObject;
			BaseBuildingViewComponent.LayerObjectHide.HideObjectEvent += OnHideObject;
		}

		protected virtual void OnBuildingDisposed(IDisposable disposable)
		{
		}

		protected virtual void OnShowObject()
		{
		}

		protected virtual void OnHideObject()
		{
		}

		protected virtual void OnEnterPool()
		{
		}
	}
}
