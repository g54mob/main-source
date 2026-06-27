using System;
using UnityEngine;
using UnityEngine.Events;

namespace Restory.Gameplay.GameSettings
{
	[Serializable]
	public class CameraSettings
	{
		public UnityEvent<float> OnZoomSensitivityChanged = new UnityEvent<float>();

		public UnityEvent<float> OnRotationSensitivityChanged = new UnityEvent<float>();

		public UnityEvent<bool> OnRotationInversionChanged = new UnityEvent<bool>();

		public UnityEvent<bool> OnCameraSmoothingChanged = new UnityEvent<bool>();

		[SerializeField]
		private float zoomSensitivity = 1f;

		[SerializeField]
		private float rotationSensitivity = 1f;

		[SerializeField]
		private bool isRotationInverted;

		[SerializeField]
		private bool isFollowingSmoothed = true;

		public float ZoomSensitivity
		{
			get
			{
				return zoomSensitivity;
			}
			set
			{
				if (zoomSensitivity != value)
				{
					zoomSensitivity = value;
					OnZoomSensitivityChanged?.Invoke(value);
				}
			}
		}

		public float RotationSensitivity
		{
			get
			{
				return rotationSensitivity;
			}
			set
			{
				if (rotationSensitivity != value)
				{
					rotationSensitivity = value;
					OnRotationSensitivityChanged?.Invoke(value);
				}
			}
		}

		public bool IsRotationInverted
		{
			get
			{
				return isRotationInverted;
			}
			set
			{
				if (isRotationInverted != value)
				{
					isRotationInverted = value;
					OnRotationInversionChanged?.Invoke(value);
				}
			}
		}

		public bool IsFollowingSmoothed
		{
			get
			{
				return isFollowingSmoothed;
			}
			set
			{
				if (isFollowingSmoothed != value)
				{
					isFollowingSmoothed = value;
					OnCameraSmoothingChanged?.Invoke(value);
				}
			}
		}

		public CameraSettings Clone()
		{
			return new CameraSettings
			{
				zoomSensitivity = zoomSensitivity,
				rotationSensitivity = rotationSensitivity,
				isRotationInverted = isRotationInverted,
				isFollowingSmoothed = isFollowingSmoothed
			};
		}
	}
}
