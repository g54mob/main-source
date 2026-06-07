using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class CameraLookAroundSettings : Settings
	{
		[SerializeField]
		private CameraLookAroundMode _lookAroundMode;

		[SerializeField]
		private float _standardLookAroundSensitivity = 5f;

		[SerializeField]
		private float _smoothLookAroundSensitivity = 5f;

		[SerializeField]
		private float smoothValue = 4f;

		[SerializeField]
		private bool _invertX;

		[SerializeField]
		private bool _invertY;

		[SerializeField]
		private bool _isLookAroundEnabled = true;

		public CameraLookAroundMode LookAroundMode
		{
			get
			{
				return _lookAroundMode;
			}
			set
			{
				_lookAroundMode = value;
			}
		}

		public float StandardLookAroundSensitivity
		{
			get
			{
				return _standardLookAroundSensitivity;
			}
			set
			{
				_standardLookAroundSensitivity = Mathf.Max(value, 0.001f);
			}
		}

		public float SmoothLookAroundSensitivity
		{
			get
			{
				return _smoothLookAroundSensitivity;
			}
			set
			{
				_smoothLookAroundSensitivity = Mathf.Max(value, 0.001f);
			}
		}

		public float Sensitivity
		{
			get
			{
				if (_lookAroundMode != CameraLookAroundMode.Standard)
				{
					return _smoothLookAroundSensitivity;
				}
				return _standardLookAroundSensitivity;
			}
		}

		public float SmoothValue
		{
			get
			{
				return smoothValue;
			}
			set
			{
				smoothValue = Mathf.Max(value, 0.001f);
			}
		}

		public bool InvertX
		{
			get
			{
				return _invertX;
			}
			set
			{
				_invertX = value;
			}
		}

		public bool InvertY
		{
			get
			{
				return _invertY;
			}
			set
			{
				_invertY = value;
			}
		}

		public bool IsLookAroundEnabled
		{
			get
			{
				return _isLookAroundEnabled;
			}
			set
			{
				_isLookAroundEnabled = value;
			}
		}
	}
}
