using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class CameraRotationSwitchSettings : Settings
	{
		private static readonly float _minConstantDuration = 0.1f;

		[SerializeField]
		private CameraRotationSwitchMode _switchMode = CameraRotationSwitchMode.Smooth;

		[SerializeField]
		private float _constantSwitchDurationInSeconds = 0.3f;

		[SerializeField]
		private float _smoothValue = 8f;

		public CameraRotationSwitchMode SwitchMode
		{
			get
			{
				return _switchMode;
			}
			set
			{
				_switchMode = value;
			}
		}

		public float ConstantSwitchDurationInSeconds
		{
			get
			{
				return _constantSwitchDurationInSeconds;
			}
			set
			{
				_constantSwitchDurationInSeconds = Mathf.Max(value, _minConstantDuration);
			}
		}

		public float SmoothValue
		{
			get
			{
				return _smoothValue;
			}
			set
			{
				_smoothValue = Mathf.Max(value, 0.001f);
			}
		}
	}
}
