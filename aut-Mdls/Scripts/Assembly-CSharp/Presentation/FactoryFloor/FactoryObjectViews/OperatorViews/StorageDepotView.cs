using System;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews
{
	public class StorageDepotView : FactoryResourceHolderView<StorageDepotBehaviour>
	{
		[SerializeField]
		private FactoryObjectViewCullingController _cullingController;

		[SerializeField]
		private ResourceProjectorWidgetView _resourceProjectorWidgetView;

		[SerializeField]
		private MeshRenderer _fillMeshRenderer;

		protected override void Init()
		{
			base.Init();
			_behaviour.OnStoredResourceChanged.RegisterMainThread(HandleStoredResourceChanged);
			_behaviour.OnStoredAmountChanged.RegisterMainThread(HandleStoredAmountChanged);
			_behaviour.OnOutputResource.RegisterMainThread(base.PassResource);
			FactoryObjectViewCullingController cullingController = _cullingController;
			cullingController.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Combine(cullingController.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(OnCullingChanged));
			HandleStoredResourceChanged(_behaviour.StoredResource);
			HandleStoredAmountChanged(_behaviour.StoredAmount);
		}

		protected override void ResetFactoryObject()
		{
			ResetView();
			base.ResetFactoryObject();
		}

		protected override void OnDestroy()
		{
			ResetView();
			base.OnDestroy();
		}

		private void ResetView()
		{
			if ((bool)_behaviour)
			{
				_behaviour.OnStoredResourceChanged.UnRegisterMainThread(HandleStoredResourceChanged);
				_behaviour.OnStoredAmountChanged.UnRegisterMainThread(HandleStoredAmountChanged);
				_behaviour.OnOutputResource.UnRegisterMainThread(base.PassResource);
			}
			FactoryObjectViewCullingController cullingController = _cullingController;
			cullingController.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Remove(cullingController.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(OnCullingChanged));
		}

		private void OnCullingChanged(CullableObjectState newState, CullableObjectState prevState)
		{
			HandleStoredResourceChanged(_behaviour.StoredResource);
		}

		private void HandleStoredResourceChanged(Resource newResource)
		{
			if (newResource != null && !_cullingController.IsCulledOrShadowsOnly)
			{
				_resourceProjectorWidgetView.ShowResource(newResource);
			}
			else
			{
				_resourceProjectorWidgetView.Reset();
			}
		}

		private void HandleStoredAmountChanged(ulong newAmount)
		{
			_fillMeshRenderer.materials[0].SetFloat("_ProgressTime", Mathf.Clamp01((float)newAmount / (float)_behaviour.MaxStorage));
		}
	}
}
