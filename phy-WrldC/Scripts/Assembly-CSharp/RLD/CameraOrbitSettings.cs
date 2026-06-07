using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class CameraOrbitSettings : Settings
	{
		[SerializeField]
		private CameraOrbitMode _orbitMode;

		[SerializeField]
		private float _standardOrbitSensitivity = 5f;

		[SerializeField]
		private float _smoothOrbitSensitivity = 5f;

		[SerializeField]
		private float _smoothValue = 8f;

		[SerializeField]
		private bool _invertX;

		[SerializeField]
		private bool _invertY;

		[SerializeField]
		private bool _isOrbitEnabled = true;

		public CameraOrbitMode OrbitMode
		{
			get
			{
				return _orbitMode;
			}
			set
			{
				_orbitMode = value;
			}
		}

		public float StandardOrbitSensitivity
		{
			get
			{
				return _standardOrbitSensitivity;
			}
			set
			{
				_standardOrbitSensitivity = Mathf.Max(value, 0.001f);
			}
		}

		public float SmoothOrbitSensitivity
		{
			get
			{
				return _smoothOrbitSensitivity;
			}
			set
			{
				_smoothOrbitSensitivity = Mathf.Max(value, 0.001f);
			}
		}

		public float OrbitSensitivity
		{
			get
			{
				if (_orbitMode != CameraOrbitMode.Smooth)
				{
					return _standardOrbitSensitivity;
				}
				return _smoothOrbitSensitivity;
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

		public bool IsOrbitEnabled
		{
			get
			{
				return _isOrbitEnabled;
			}
			set
			{
				_isOrbitEnabled = value;
			}
		}
	}
}
