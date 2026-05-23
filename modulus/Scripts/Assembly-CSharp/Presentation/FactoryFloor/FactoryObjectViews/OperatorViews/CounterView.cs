using System;
using DG.Tweening;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;
using Presentation.Locators;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews
{
	public class CounterView : FactoryResourceHolderView<CounterBehaviour>
	{
		[SerializeField]
		private TextMeshPro _counterTextField;

		[SerializeField]
		private Image _calibrationBar;

		[SerializeField]
		private CameraLocator _cameraLocator;

		[SerializeField]
		private Spinner _spinner;

		[SerializeField]
		private FactoryObjectViewCullingController _factoryObjectViewCullingController;

		private float _lastCameraAngle;

		private bool _isCalibrating;

		private bool _isBlocked;

		private float? _lastAverage;

		protected override void Init()
		{
			base.Init();
			_behaviour.OnOutputResource.RegisterMainThread(HandlePassResource);
			_behaviour.OnCounterUpdated.RegisterMainThread(HandleCounterUpdated);
			_behaviour.OnCalibrating.RegisterMainThread(HandleCalibrating);
			FactoryObjectViewCullingController factoryObjectViewCullingController = _factoryObjectViewCullingController;
			factoryObjectViewCullingController.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Combine(factoryObjectViewCullingController.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(HandleCullState));
			_counterTextField.SetText(string.Empty);
		}

		protected override void OnDestroy()
		{
			FactoryObjectViewCullingController factoryObjectViewCullingController = _factoryObjectViewCullingController;
			factoryObjectViewCullingController.OnNewCullState = (Action<CullableObjectState, CullableObjectState>)Delegate.Remove(factoryObjectViewCullingController.OnNewCullState, new Action<CullableObjectState, CullableObjectState>(HandleCullState));
			Reset();
			base.OnDestroy();
		}

		protected override void ResetFactoryObject()
		{
			Reset();
			base.ResetFactoryObject();
		}

		private void Reset()
		{
			if (_behaviour != null)
			{
				_behaviour.OnOutputResource.UnRegisterMainThread(HandlePassResource);
				_behaviour.OnCounterUpdated.UnRegisterMainThread(HandleCounterUpdated);
				_behaviour.OnCalibrating.UnRegisterMainThread(HandleCalibrating);
			}
		}

		private void HandleCullState(CullableObjectState state, CullableObjectState prevState)
		{
			if (_lastAverage.HasValue)
			{
				HandleCounterUpdated(_lastAverage.Value);
			}
		}

		private void HandleCalibrating(CounterBehaviour.CalibratingValues values)
		{
			SetIsCalibrating(values.IsCalibrating, values.CalibrationProgress);
			SetIsBlocked(values.IsBlocked);
		}

		private void SetIsCalibrating(bool isCalibrating, float calibrationProgress)
		{
			if (isCalibrating)
			{
				_calibrationBar.fillAmount = calibrationProgress;
			}
			if (_isCalibrating != isCalibrating)
			{
				_isCalibrating = isCalibrating;
				_spinner.gameObject.SetActive(isCalibrating);
				_counterTextField.gameObject.SetActive(!isCalibrating);
				_calibrationBar.gameObject.SetActive(isCalibrating);
			}
		}

		private void SetIsBlocked(bool isBlocked)
		{
			if (_isBlocked != isBlocked)
			{
				_isBlocked = isBlocked;
				if (isBlocked)
				{
					_spinner.SetSpeed(Vector3.zero);
				}
				else
				{
					_spinner.ResetToDefaultSpeed();
				}
			}
		}

		private void UpdateDisplayRotation()
		{
			float num = (_cameraLocator.Camera.transform.rotation.eulerAngles.y - base.transform.parent.rotation.eulerAngles.y + 360f) % 360f;
			if (Math.Abs(num - _lastCameraAngle) < 5f)
			{
				return;
			}
			_lastCameraAngle = num;
			if (num < 225f)
			{
				if (num >= 45f)
				{
					if (num < 135f)
					{
						_counterTextField.transform.parent.DORotate(new Vector3(90f, 90f, 0f), 0.2f);
					}
					else
					{
						_counterTextField.transform.parent.DORotate(new Vector3(90f, 180f, 0f), 0.2f);
					}
					return;
				}
			}
			else if (num < 315f)
			{
				_counterTextField.transform.parent.DORotate(new Vector3(90f, 270f, 0f), 0.2f);
				return;
			}
			_counterTextField.transform.parent.DORotate(new Vector3(90f, 0f, 0f), 0.2f);
		}

		private void HandleCounterUpdated(float average)
		{
			_lastAverage = average;
			if (_factoryObjectViewCullingController.CurrentState == CullableObjectState.Normal)
			{
				UpdateDisplayRotation();
				_counterTextField.SetText(Mathf.RoundToInt(average).ToString());
			}
		}

		private void HandlePassResource(Resource resource, int outputIndex)
		{
			PassResource(resource, outputIndex);
		}
	}
}
