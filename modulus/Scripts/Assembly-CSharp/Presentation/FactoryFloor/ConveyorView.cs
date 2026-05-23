#define ENABLE_DEBUG_ERRORS
using System;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using JobSystem;
using Logic.Factory;
using Unity.Mathematics;
using UnityEngine;
using Utils;

namespace Presentation.FactoryFloor
{
	public class ConveyorView : FactoryResourceHolderView<ConveyorBehaviour>, ITransformJobAble
	{
		[SerializeField]
		private Vector3 _conveyorItemOffset;

		[SerializeField]
		private bool _showResource = true;

		[SerializeField]
		private FactoryObjectViewCullingController _cullingController;

		private ResourceView _resourceView;

		private bool _hasResourceView;

		private bool _isAnimating;

		private bool _scaleUpResource;

		private bool _initialized;

		private Vector3 _resourceViewStartPos = Vector3.zero;

		private float _totalTimeForAnimation;

		private float _startAnimationTime;

		private float3 _cachedPosition;

		private Transform _cachedResourceTransform;

		private int _resourceReceivedStep;

		public ResourceView ResourceView => _resourceView;

		public float TimeLeftInAnimation => Mathf.Max(0f, _totalTimeForAnimation - (Time.time - _startAnimationTime));

		protected override void Init()
		{
			if (_initialized)
			{
				return;
			}
			_initialized = true;
			base.Init();
			_behaviour.OnOutputResource.RegisterMainThread(PassResourceToNext);
			_behaviour.OnResourceRemoved.RegisterMainThread(RemoveResourceView);
			CalculateTotalTimeForAnimation();
			_cachedPosition = base.transform.position + _conveyorItemOffset;
			if (_behaviour.HasResource() && !_hasResourceView)
			{
				_resourceView = ResourceViewManager.Instance.CreateNewResourceView(_behaviour.Resource);
				_hasResourceView = true;
				_cachedResourceTransform = _resourceView.transform;
				_cachedResourceTransform.position = _cachedPosition;
				_resourceViewStartPos = _cachedPosition;
				_resourceView.transform.localScale = (_showResource ? (Vector3.one * _behaviour.Resource.TargetScale) : Vector3.zero);
				if (!_showResource)
				{
					_resourceView.Show(show: false);
				}
			}
			FactoryObjectViewCullingController cullingController = _cullingController;
			cullingController.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Combine(cullingController.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(HandleNewCullState));
		}

		private void HandleNewCullState(CullableObjectState state, CullableObjectState prevCullState = CullableObjectState.Normal)
		{
			if (_hasResourceView && _behaviour.Resource != null)
			{
				_resourceView.Show(!_cullingController.IsCulledOrShadowsOnly);
				if (_cullingController.IsCulledOrShadowsOnly)
				{
					SetIsAnimating(isAnimating: false, _resourceView.transform);
					_resourceView.transform.position = _cachedPosition;
					_resourceView.transform.localScale = Vector3.one * _behaviour.Resource.TargetScale;
				}
				else if (state == CullableObjectState.Normal)
				{
					int num = FactoryUpdater.Instance.CurrentStep - _resourceReceivedStep;
					float startTime = _totalTimeForAnimation * ((float)num / (float)_behaviour.UpdateFrequency);
					SetIsAnimating(isAnimating: true, _resourceView.transform, startTime);
				}
			}
		}

		protected override void ResetFactoryObject()
		{
			ResetConveyorView();
			base.ResetFactoryObject();
		}

		protected override void OnDestroy()
		{
			ResetConveyorView();
			base.OnDestroy();
		}

		private void ResetConveyorView()
		{
			if (_initialized)
			{
				_initialized = false;
				FactoryObjectViewCullingController cullingController = _cullingController;
				cullingController.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Remove(cullingController.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(HandleNewCullState));
				if ((bool)_resourceView)
				{
					_cachedPosition = base.transform.position;
					SetIsAnimating(isAnimating: false, _resourceView.transform);
					ReturnResource(_resourceView);
					_resourceView.transform.position = _cachedPosition;
					_resourceView = null;
					_hasResourceView = false;
					_cachedResourceTransform = null;
				}
				if (_behaviour != null)
				{
					_behaviour.OnOutputResource.UnRegisterMainThread(PassResourceToNext);
					_behaviour.OnResourceRemoved.UnRegisterMainThread(RemoveResourceView);
				}
			}
		}

		private void CalculateTotalTimeForAnimation()
		{
			if (_behaviour != null)
			{
				_totalTimeForAnimation = (float)_behaviour.UpdateFrequency / (float)Mathf.Max(FactoryUpdater.Instance.GetStepsPerSecond(), 1);
			}
			else
			{
				this.LogError($"Null behaviour on conveyor {_cachedPosition}", "CalculateTotalTimeForAnimation", 137);
			}
		}

		public override void ReceiveResourceView(ResourceView resource, int inputIndex, bool scaleUpResource = true)
		{
			if ((bool)_resourceView)
			{
				ReturnResource(_resourceView);
			}
			if (_behaviour == null)
			{
				ResourceViewManager.Instance.ReturnResourceToPool(resource);
				return;
			}
			_scaleUpResource = scaleUpResource;
			_resourceView = resource;
			_hasResourceView = true;
			_cachedResourceTransform = _resourceView.transform;
			_resourceViewStartPos = _cachedResourceTransform.position;
			_resourceReceivedStep = FactoryUpdater.Instance.CurrentStep;
			CalculateTotalTimeForAnimation();
			SetIsAnimating(isAnimating: true, _cachedResourceTransform);
			if (!_showResource || _cullingController.IsCulledOrShadowsOnly)
			{
				_resourceView.Show(show: false);
			}
		}

		private void PassResourceToNext(Resource resource, int _)
		{
			if ((bool)_resourceView)
			{
				ConveyorPassResource();
			}
		}

		private void ReturnResource(ResourceView resourceView)
		{
			if (!_showResource)
			{
				resourceView.Show(show: true);
			}
			ResourceViewManager.Instance.ReturnResourceToPool(resourceView);
		}

		private void ConveyorPassResource()
		{
			SetIsAnimating(isAnimating: false, _resourceView.transform);
			_resourceView.Show(show: true);
			if (!_showResource)
			{
				_resourceView.transform.localScale = Vector3.zero;
			}
			if (_outputResourceHolderViews.Length != 0 && _outputResourceHolderViews[0] != null && _behaviour.FactoryObject.OutputFactoryObjectsCount > 0)
			{
				int index = _behaviour.OutputFactoryObjects[0].InputData.Index;
				_outputResourceHolderViews[0].ReceiveResourceView(_resourceView, index, !_showResource);
				if (_hasAudioManagerLocator)
				{
					_audioManagerLocator.AudioManager.PlayItemEnter(_resourceView.transform.position);
				}
			}
			else
			{
				ReturnResource(_resourceView);
			}
			_resourceView = null;
			_hasResourceView = false;
			_cachedResourceTransform = null;
		}

		private void RemoveResourceView(Resource resource, bool returnResource)
		{
			if (_hasResourceView)
			{
				SetIsAnimating(isAnimating: false, _resourceView.transform);
				if (returnResource)
				{
					ReturnResource(_resourceView);
				}
				_resourceView = null;
				_hasResourceView = false;
				_cachedResourceTransform = null;
			}
		}

		private void SetIsAnimating(bool isAnimating, Transform resourceView, float startTime = 0f)
		{
			if (isAnimating == _isAnimating || !_showResource)
			{
				return;
			}
			_isAnimating = isAnimating;
			if (_isAnimating)
			{
				if (_cullingController.IsCulledOrShadowsOnly)
				{
					_isAnimating = false;
					resourceView.transform.position = _cachedPosition;
					resourceView.transform.localScale = _resourceView.Resource.TargetScale * Vector3.one;
					AnimationEnd();
				}
				else
				{
					float targetScale = _resourceView.Resource.TargetScale;
					float startScale = (_scaleUpResource ? 0f : targetScale);
					TransformJobManager.AddTransform(resourceView, this, _resourceViewStartPos, _cachedPosition, startScale, targetScale, _totalTimeForAnimation, startTime);
					_startAnimationTime = Time.time;
				}
			}
			else
			{
				TransformJobManager.RemoveTransform(resourceView, this);
			}
		}

		public void AnimationEnd()
		{
		}
	}
}
