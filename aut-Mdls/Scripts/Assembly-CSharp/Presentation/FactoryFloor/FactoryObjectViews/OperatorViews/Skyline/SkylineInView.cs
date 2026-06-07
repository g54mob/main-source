using System;
using System.Collections.Generic;
using System.Linq;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;
using NaughtyAttributes;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews.Skyline
{
	public class SkylineInView : FactoryResourceHolderView<SkylineInBehaviour>
	{
		[SerializeField]
		private SkylinePlatformView _platformPrefab;

		[SerializeField]
		private Transform _startPlatformTransform;

		[SerializeField]
		private Transform _backPlatformTransform;

		[SerializeField]
		private Transform _backPlatformEndTransform;

		[SerializeField]
		private FactoryObjectViewCullingController _factoryObjectViewCullingController;

		[SerializeField]
		[MinMaxSlider(0f, 16f)]
		private Vector2Int _jobContainerScalingIndices;

		private readonly List<SkylinePlatformView> _platformViewPool = new List<SkylinePlatformView>();

		private SkylinePlatformView[] _forwardResourcePlatformViews = Array.Empty<SkylinePlatformView>();

		private SkylinePlatformView[] _backResourcePlatformViews = Array.Empty<SkylinePlatformView>();

		private TransformJobContainer[] _forwardPlatformJobContainers = Array.Empty<TransformJobContainer>();

		private TransformJobContainer[] _backPlatformJobContainers = Array.Empty<TransformJobContainer>();

		protected override void Init()
		{
			base.Init();
			_behaviour.OnReceiveResource.RegisterMainThread(ReceiveResource);
			_behaviour.OnClearSkyline.RegisterMainThread(ClearSkyline);
			if (_behaviour.HasSkylineOutBehaviour)
			{
				InitView();
			}
			else
			{
				_behaviour.OnSkylineOutFound += InitView;
			}
			FactoryObjectViewCullingController factoryObjectViewCullingController = _factoryObjectViewCullingController;
			factoryObjectViewCullingController.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Combine(factoryObjectViewCullingController.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(OnNewCullState));
		}

		private void InitView()
		{
			_behaviour.OnSkylineOutFound -= InitView;
			if (_platformViewPool.Count > 0)
			{
				DestroyPlatformViews();
			}
			CreatePlatformViews();
			_behaviour.OnMoveResource.RegisterMainThread(MoveResourceView);
			_behaviour.OnRemoveLastResource.RegisterMainThread(RemoveLastResource);
			_behaviour.OnMoveBackPlatform.RegisterMainThread(OnMoveBackPlatform);
			_behaviour.OnRemoveLastBackPlatform.RegisterMainThread(RemoveLastBackPlatform);
			Vector3 cullingBoundsOverride = new Vector3((float)_behaviour.SkylineLength * 2f, 2f, (float)_behaviour.SkylineLength * 2f);
			_factoryObjectViewCullingController.SetCullingBoundsOverride(cullingBoundsOverride);
			_factoryObjectViewCullingController.RefreshCullingPosition();
		}

		protected override void ResetFactoryObject()
		{
			if (_behaviour != null)
			{
				_behaviour.OnReceiveResource.UnRegisterMainThread(ReceiveResource);
				_behaviour.OnClearSkyline.UnRegisterMainThread(ClearSkyline);
				_behaviour.OnMoveResource.UnRegisterMainThread(MoveResourceView);
				_behaviour.OnRemoveLastResource.UnRegisterMainThread(RemoveLastResource);
				_behaviour.OnMoveBackPlatform.UnRegisterMainThread(OnMoveBackPlatform);
				_behaviour.OnRemoveLastBackPlatform.UnRegisterMainThread(RemoveLastBackPlatform);
			}
			DestroyPlatformViews();
			FactoryObjectViewCullingController factoryObjectViewCullingController = _factoryObjectViewCullingController;
			factoryObjectViewCullingController.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Remove(factoryObjectViewCullingController.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(OnNewCullState));
			base.ResetFactoryObject();
		}

		private void ClearSkyline()
		{
			DestroyPlatformViews();
			CreatePlatformViews();
		}

		private void CreatePlatformViews()
		{
			_forwardResourcePlatformViews = new SkylinePlatformView[_behaviour.SkylineLength];
			_backResourcePlatformViews = new SkylinePlatformView[_behaviour.SkylineLength];
			for (int i = 0; i < _behaviour.SkylineLength * 2; i++)
			{
				SkylinePlatformView skylinePlatformView = UnityEngine.Object.Instantiate(_platformPrefab, base.transform);
				skylinePlatformView.Init(_startPlatformTransform.position, _behaviour.Direction);
				_platformViewPool.Add(skylinePlatformView);
			}
			for (int j = 0; j < _behaviour.Resources.Length; j++)
			{
				if (_behaviour.Resources[j] != null)
				{
					ResourceView resourceView = ResourceViewManager.Instance.CreateNewResourceView(_behaviour.Resources[j]);
					resourceView.transform.localScale = Vector3.one;
					_forwardResourcePlatformViews[j] = GetOrCreateFirstAvailablePlatformView().SpawnPlatform(resourceView, j);
					TransformJobContainer.ScalingMode scalingModeAtIndex = GetScalingModeAtIndex(j);
					float num = ((scalingModeAtIndex == TransformJobContainer.ScalingMode.ScaleUp || scalingModeAtIndex == TransformJobContainer.ScalingMode.NoScaling1) ? 1 : 0);
					_forwardResourcePlatformViews[j].transform.localScale = Vector3.one * num;
				}
			}
			_forwardPlatformJobContainers = new TransformJobContainer[_behaviour.SkylineLength];
			_backPlatformJobContainers = new TransformJobContainer[_behaviour.SkylineLength];
			for (int k = 0; k < _behaviour.SkylineLength; k++)
			{
				Vector3 startPosition = _startPlatformTransform.position + _behaviour.Direction * (k - 1);
				Vector3 endPosition = _startPlatformTransform.position + _behaviour.Direction * k;
				_forwardPlatformJobContainers[k] = new TransformJobContainer(startPosition, endPosition, GetScalingModeAtIndex(k), _factoryObjectViewCullingController);
				_forwardPlatformJobContainers[k].SetUpdateFrequency(_behaviour.VariableUpdateFrequency);
				startPosition = _backPlatformEndTransform.position - _behaviour.Direction * (k - 1);
				endPosition = _backPlatformEndTransform.position - _behaviour.Direction * k;
				_backPlatformJobContainers[k] = new TransformJobContainer(startPosition, endPosition, GetScalingModeAtIndex(k), _factoryObjectViewCullingController);
				_backPlatformJobContainers[k].SetUpdateFrequency(_behaviour.VariableUpdateFrequency);
			}
		}

		private TransformJobContainer.ScalingMode GetScalingModeAtIndex(int index)
		{
			if (index < _jobContainerScalingIndices.x || index > _jobContainerScalingIndices.y)
			{
				return TransformJobContainer.ScalingMode.NoScaling0;
			}
			if (index == _jobContainerScalingIndices.x)
			{
				return TransformJobContainer.ScalingMode.ScaleUp;
			}
			if (index == _jobContainerScalingIndices.y)
			{
				return TransformJobContainer.ScalingMode.ScaleDown;
			}
			return TransformJobContainer.ScalingMode.NoScaling1;
		}

		private void DestroyPlatformViews()
		{
			for (int num = _platformViewPool.Count - 1; num >= 0; num--)
			{
				ReturnPlatformViewToPool(_platformViewPool[num]);
			}
			_platformViewPool.Clear();
			_forwardResourcePlatformViews = Array.Empty<SkylinePlatformView>();
			_backResourcePlatformViews = Array.Empty<SkylinePlatformView>();
			if (_forwardPlatformJobContainers != null)
			{
				TransformJobContainer[] forwardPlatformJobContainers = _forwardPlatformJobContainers;
				for (int i = 0; i < forwardPlatformJobContainers.Length; i++)
				{
					forwardPlatformJobContainers[i].Dispose();
				}
				_forwardPlatformJobContainers = null;
			}
			if (_backPlatformJobContainers != null)
			{
				TransformJobContainer[] forwardPlatformJobContainers = _backPlatformJobContainers;
				for (int i = 0; i < forwardPlatformJobContainers.Length; i++)
				{
					forwardPlatformJobContainers[i].Dispose();
				}
				_backPlatformJobContainers = null;
			}
		}

		private void MoveResourceView(int destinationIndex)
		{
			_forwardPlatformJobContainers[destinationIndex].PlayAnimation(_forwardResourcePlatformViews[destinationIndex - 1].transform);
			_forwardResourcePlatformViews[destinationIndex] = _forwardResourcePlatformViews[destinationIndex - 1];
			_forwardResourcePlatformViews[destinationIndex - 1] = null;
		}

		private void OnMoveBackPlatform(int destinationIndex)
		{
			_backPlatformJobContainers[destinationIndex].PlayAnimation(_backResourcePlatformViews[destinationIndex - 1].transform);
			_backResourcePlatformViews[destinationIndex] = _backResourcePlatformViews[destinationIndex - 1];
			_backResourcePlatformViews[destinationIndex - 1] = null;
		}

		private void RemoveLastResource()
		{
			SkylinePlatformView obj = _forwardResourcePlatformViews[^1];
			obj.ResourceView.transform.SetParent(ResourceViewManager.Instance.transform);
			obj.ResourceView.transform.localScale = Vector3.one;
			obj.ReturnResourceToPool();
			obj.SetEmptyPlatform();
			obj.gameObject.SetActive(value: false);
			obj.SetIsAvailable(isAvailable: true);
			_forwardResourcePlatformViews[^1] = null;
			SkylinePlatformView orCreateFirstAvailablePlatformView = GetOrCreateFirstAvailablePlatformView();
			_backResourcePlatformViews[0] = orCreateFirstAvailablePlatformView;
			orCreateFirstAvailablePlatformView.transform.position = _backPlatformEndTransform.position;
			orCreateFirstAvailablePlatformView.SetIsAvailable(isAvailable: false);
			orCreateFirstAvailablePlatformView.transform.localScale = Vector3.one;
			orCreateFirstAvailablePlatformView.SetEmptyPlatform();
			orCreateFirstAvailablePlatformView.gameObject.SetActive(value: true);
		}

		private void RemoveLastBackPlatform()
		{
			SkylinePlatformView obj = _backResourcePlatformViews[^1];
			obj.ReturnResourceToPool();
			obj.SetIsAvailable(isAvailable: true);
			obj.gameObject.SetActive(value: false);
			_backResourcePlatformViews[^1] = null;
		}

		private void ReceiveResource(Resource resource)
		{
			if (!(_forwardResourcePlatformViews[0] != null))
			{
				ResourceView resourceView = ResourceViewManager.Instance.CreateNewResourceView(resource);
				resourceView.transform.localScale = Vector3.one * resource.TargetScale;
				SkylinePlatformView orCreateFirstAvailablePlatformView = GetOrCreateFirstAvailablePlatformView();
				_forwardResourcePlatformViews[0] = orCreateFirstAvailablePlatformView;
				orCreateFirstAvailablePlatformView.SetIsAvailable(isAvailable: false);
				orCreateFirstAvailablePlatformView.SpawnPlatform(resourceView);
				orCreateFirstAvailablePlatformView.transform.localScale = Vector3.zero;
			}
		}

		private void OnNewCullState(CullableObjectState state, CullableObjectState prevState)
		{
			bool isCulledOrShadowsOnly = _factoryObjectViewCullingController.IsCulledOrShadowsOnly;
			for (int i = 0; i < _forwardResourcePlatformViews.Length; i++)
			{
				if (_forwardResourcePlatformViews[i] != null)
				{
					_forwardResourcePlatformViews[i].SetForceRenderingOff(isCulledOrShadowsOnly);
				}
				if (_backResourcePlatformViews[i] != null)
				{
					_backResourcePlatformViews[i].SetForceRenderingOff(isCulledOrShadowsOnly);
				}
			}
		}

		private void ReturnPlatformViewToPool(SkylinePlatformView skylinePlatformView)
		{
			skylinePlatformView.Clear();
			if (skylinePlatformView.ResourceView != null)
			{
				skylinePlatformView.ResourceView.transform.SetParent(ResourceViewManager.Instance.transform);
				skylinePlatformView.ResourceView.transform.localScale = Vector3.one;
				skylinePlatformView.ReturnResourceToPool();
			}
			skylinePlatformView.SetEmptyPlatform();
			skylinePlatformView.gameObject.SetActive(value: false);
			skylinePlatformView.SetIsAvailable(isAvailable: true);
		}

		private SkylinePlatformView GetOrCreateFirstAvailablePlatformView()
		{
			SkylinePlatformView skylinePlatformView = _platformViewPool.FirstOrDefault((SkylinePlatformView p) => p.IsAvailable);
			if (skylinePlatformView == null)
			{
				skylinePlatformView = UnityEngine.Object.Instantiate(_platformPrefab, base.transform);
				skylinePlatformView.Init(_startPlatformTransform.position, _behaviour.Direction);
				_platformViewPool.Add(skylinePlatformView);
			}
			return skylinePlatformView;
		}
	}
}
