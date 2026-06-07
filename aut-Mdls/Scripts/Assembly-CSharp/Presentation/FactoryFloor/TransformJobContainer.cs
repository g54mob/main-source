using System;
using Data.Variables;
using JobSystem;
using Logic.Factory;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class TransformJobContainer : ITransformJobAble
	{
		public enum ScalingMode
		{
			ScaleUp = 0,
			ScaleDown = 1,
			NoScaling1 = 2,
			NoScaling0 = 3
		}

		private IntVariableSO _updateFrequency;

		private Transform _transform;

		private readonly ICullable _cullable;

		private readonly bool _hasCullable;

		private readonly Vector3 _startPosition;

		private readonly Vector3 _endPosition;

		private readonly float _startScale;

		private readonly float _endScale;

		private readonly float _distance;

		private bool _hasTransform;

		private int _resourceReceivedStep;

		public event Action<TransformJobContainer> OnAnimationEnd = delegate
		{
		};

		public TransformJobContainer(Vector3 startPosition, Vector3 endPosition, ScalingMode scalingMode, ICullable cullable, float distance = 1f)
		{
			_cullable = cullable;
			_hasCullable = _cullable != null;
			_updateFrequency = FactoryUpdater.Instance.ConveyorUpdateFrequency;
			_startPosition = startPosition;
			_endPosition = endPosition;
			switch (scalingMode)
			{
			case ScalingMode.ScaleUp:
				_startScale = 0f;
				_endScale = 1f;
				break;
			case ScalingMode.ScaleDown:
				_startScale = 1f;
				_endScale = 0f;
				break;
			case ScalingMode.NoScaling1:
				_startScale = 1f;
				_endScale = 1f;
				break;
			case ScalingMode.NoScaling0:
				_startScale = 0f;
				_endScale = 0f;
				break;
			}
			_distance = distance;
			if (_hasCullable)
			{
				ICullable cullable2 = _cullable;
				cullable2.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Combine(cullable2.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(OnCullStateChanged));
			}
		}

		public void Dispose()
		{
			ClearAnimation();
			if (_hasCullable)
			{
				ICullable cullable = _cullable;
				cullable.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Remove(cullable.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(OnCullStateChanged));
			}
		}

		public void SetUpdateFrequency(IntVariableSO updateFrequency)
		{
			_updateFrequency = updateFrequency;
		}

		public void PlayAnimation(Transform transform)
		{
			float totalTime = 1f / ((float)FactoryUpdater.Instance.GetStepsPerSecond() / (float)_updateFrequency.Value) * _distance;
			PlayAnimation(transform, _cullable.CurrentState, totalTime);
		}

		private void PlayAnimation(Transform transform, CullableObjectState cullState, float totalTime, float startTime = 0f)
		{
			ClearAnimation();
			_hasTransform = true;
			_transform = transform;
			if (_hasCullable && _cullable.IsCulledOrShadowsOnly)
			{
				transform.position = _endPosition;
				transform.localScale = Vector3.one * _endScale;
				_resourceReceivedStep = FactoryUpdater.Instance.CurrentStep;
			}
			else
			{
				TransformJobManager.AddTransform(_transform, this, _startPosition, _endPosition, _startScale, _endScale, totalTime, startTime);
			}
		}

		private void ClearAnimation()
		{
			if (_hasTransform)
			{
				RemoveTransformFromJobManager();
				AnimationEnd();
			}
		}

		private void RemoveTransformFromJobManager()
		{
			TransformJobManager.RemoveTransform(_transform, this);
		}

		public void AnimationEnd()
		{
			if ((bool)_transform)
			{
				_transform.position = _endPosition;
				_transform.localScale = Vector3.one * _endScale;
			}
			_transform = null;
			_hasTransform = false;
			this.OnAnimationEnd(this);
			this.OnAnimationEnd = delegate
			{
			};
		}

		private void OnCullStateChanged(CullableObjectState state, CullableObjectState prevCullState)
		{
			if (_cullable.IsCulledOrShadowsOnly)
			{
				ClearAnimation();
			}
			else if (state == CullableObjectState.Normal && state != prevCullState && _hasTransform)
			{
				float num = 1f / ((float)FactoryUpdater.Instance.GetStepsPerSecond() / (float)_updateFrequency.Value) * _distance;
				int num2 = FactoryUpdater.Instance.CurrentStep - _resourceReceivedStep;
				float startTime = num * ((float)num2 / (float)_updateFrequency.Value);
				PlayAnimation(_transform, state, num, startTime);
			}
		}
	}
}
