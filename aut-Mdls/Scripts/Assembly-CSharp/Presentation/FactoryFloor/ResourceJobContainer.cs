using System;
using Data.Variables;
using JobSystem;
using Logic.Factory;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class ResourceJobContainer : ITransformJobAble, IDisposable
	{
		public enum ScalingMode
		{
			ScaleUp = 0,
			ScaleDown = 1,
			NoScaling = 2
		}

		private readonly IntVariableSO _conveyorUpdateFrequency;

		private Transform _resourceTransform;

		private readonly ICullable _cullable;

		private readonly bool _hasCullable;

		private float _speedMultiplier = 1f;

		private float _totalTimeForAnimation;

		private ResourceView _resourceView;

		private bool _returnResourceToPoolAfter;

		private Vector3 _startPosition;

		private readonly Vector3 _endPosition;

		private readonly float _baseStartScale;

		private readonly float _baseEndScale;

		private float _startScale;

		private float _endScale;

		private bool _hasResourceView;

		private bool _transformAddedToJobManager;

		private int _resourceReceivedStep;

		public ResourceJobContainer(Vector3 startPosition, Vector3 endPosition, ScalingMode scalingMode, bool returnResourceToPoolAfter, ICullable cullable)
		{
			_cullable = cullable;
			_hasCullable = _cullable != null;
			_conveyorUpdateFrequency = FactoryUpdater.Instance.ConveyorUpdateFrequency;
			_startPosition = startPosition;
			_endPosition = endPosition;
			_returnResourceToPoolAfter = returnResourceToPoolAfter;
			switch (scalingMode)
			{
			case ScalingMode.ScaleUp:
				_baseStartScale = 0f;
				_baseEndScale = 1f;
				break;
			case ScalingMode.ScaleDown:
				_baseStartScale = 1f;
				_baseEndScale = 0f;
				break;
			case ScalingMode.NoScaling:
				_baseStartScale = 1f;
				_baseEndScale = 1f;
				break;
			}
			CalculateTotalTimeForAnimation();
			FactoryUpdater.Instance.OnFactorySpeedChanged += CalculateTotalTimeForAnimation;
			FactoryUpdater.Instance.ConveyorUpdateFrequency.ValueChanged += CalculateTotalTimeForAnimation;
			if (_hasCullable)
			{
				ICullable cullable2 = _cullable;
				cullable2.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Combine(cullable2.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(OnCullStateChanged));
			}
		}

		public void Dispose()
		{
			ClearAnimation();
			FactoryUpdater.Instance.OnFactorySpeedChanged -= CalculateTotalTimeForAnimation;
			FactoryUpdater.Instance.ConveyorUpdateFrequency.ValueChanged -= CalculateTotalTimeForAnimation;
			if (_hasCullable)
			{
				ICullable cullable = _cullable;
				cullable.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Remove(cullable.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(OnCullStateChanged));
			}
			_returnResourceToPoolAfter = false;
		}

		private void CalculateTotalTimeForAnimation(int _)
		{
			CalculateTotalTimeForAnimation();
		}

		private void CalculateTotalTimeForAnimation()
		{
			_totalTimeForAnimation = (float)_conveyorUpdateFrequency.Value / Mathf.Max(FactoryUpdater.Instance.GetStepsPerSecond(), Mathf.Epsilon);
		}

		public void SetSpeedMultiplier(float speedMultiplier)
		{
			_speedMultiplier = speedMultiplier;
		}

		public void SetStartPosition(Vector3 position)
		{
			_startPosition = position;
		}

		public void PlayAnimation(ResourceView resourceView)
		{
			float totalTime = _totalTimeForAnimation / _speedMultiplier;
			ClearAnimation();
			PlayAnimation(resourceView, _cullable.CurrentState, totalTime);
		}

		private void PlayAnimation(ResourceView resourceView, CullableObjectState cullState, float totalTime, float startTime = 0f)
		{
			_resourceView = resourceView;
			_startScale = _baseStartScale * resourceView.Resource.TargetScale;
			_endScale = _baseEndScale * resourceView.Resource.TargetScale;
			_hasResourceView = true;
			if (_hasCullable && _cullable.IsCulledOrShadowsOnly)
			{
				resourceView.transform.position = _endPosition;
				resourceView.transform.localScale = Vector3.one * _endScale;
				_resourceReceivedStep = FactoryUpdater.Instance.CurrentStep;
			}
			else
			{
				_transformAddedToJobManager = true;
				_resourceTransform = resourceView.transform;
				TransformJobManager.AddTransform(_resourceTransform, this, _startPosition, _endPosition, _startScale, _endScale, totalTime, startTime);
			}
		}

		private void ClearAnimation()
		{
			if (_hasResourceView)
			{
				RemoveTransformFromJobManager();
				AnimationEnd();
			}
		}

		private void RemoveTransformFromJobManager()
		{
			if (_transformAddedToJobManager)
			{
				TransformJobManager.RemoveTransform(_resourceTransform, this);
				_transformAddedToJobManager = false;
			}
		}

		public void AnimationEnd()
		{
			if (_returnResourceToPoolAfter)
			{
				ResourceViewManager.Instance.ReturnResourceToPool(_resourceView);
			}
			else
			{
				_resourceView.transform.position = _endPosition;
				_resourceView.transform.localScale = Vector3.one * _endScale;
			}
			_resourceView = null;
			_resourceTransform = null;
			_hasResourceView = false;
			_transformAddedToJobManager = false;
		}

		private void OnCullStateChanged(CullableObjectState state, CullableObjectState prevState)
		{
			if (_cullable.IsCulledOrShadowsOnly)
			{
				ClearAnimation();
			}
			else if (state == CullableObjectState.Normal && state != prevState && _hasResourceView)
			{
				float num = _totalTimeForAnimation / _speedMultiplier;
				int processTicks = FactoryUpdater.Instance.CurrentStep - _resourceReceivedStep;
				float startTime = FactoryUpdater.Instance.GetProcessTicksToRealTime(processTicks) / num;
				RemoveTransformFromJobManager();
				PlayAnimation(_resourceView, state, num, startTime);
			}
		}
	}
}
