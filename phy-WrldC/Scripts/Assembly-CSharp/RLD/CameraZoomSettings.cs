using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class CameraZoomSettings : Settings
	{
		[SerializeField]
		private CameraZoomMode _zoomMode;

		[SerializeField]
		private float _orthoStandardZoomSensitivity = 10f;

		[SerializeField]
		private float _perspStandardZoomSensitivity = 10f;

		[SerializeField]
		private float _orthoSmoothZoomSensitivity = 5f;

		[SerializeField]
		private float _perspSmoothZoomSensitivity = 5f;

		[SerializeField]
		private float _orthoZoomSmoothValue = 5f;

		[SerializeField]
		private float _perspZoomSmoothValue = 5f;

		[SerializeField]
		private bool _invertZoomAxis;

		[SerializeField]
		private bool _isZoomEnabled = true;

		public CameraZoomMode ZoomMode
		{
			get
			{
				return _zoomMode;
			}
			set
			{
				_zoomMode = value;
			}
		}

		public float OrthoStandardZoomSensitivity
		{
			get
			{
				return _orthoStandardZoomSensitivity;
			}
			set
			{
				_orthoStandardZoomSensitivity = Mathf.Max(value, 0.001f);
			}
		}

		public float PerspStandardZoomSensitivity
		{
			get
			{
				return _perspStandardZoomSensitivity;
			}
			set
			{
				_perspStandardZoomSensitivity = Mathf.Max(value, 0.001f);
			}
		}

		public float OrthoSmoothZoomSensitivity
		{
			get
			{
				return _orthoSmoothZoomSensitivity;
			}
			set
			{
				_orthoSmoothZoomSensitivity = Mathf.Max(value, 0.001f);
			}
		}

		public float PerspSmoothZoomSensitivity
		{
			get
			{
				return _perspSmoothZoomSensitivity;
			}
			set
			{
				_perspSmoothZoomSensitivity = Mathf.Max(value, 0.001f);
			}
		}

		public float OrthoZoomSmoothValue
		{
			get
			{
				return _orthoZoomSmoothValue;
			}
			set
			{
				_orthoZoomSmoothValue = Mathf.Max(value, 0.001f);
			}
		}

		public float PerspZoomSmoothValue
		{
			get
			{
				return _perspZoomSmoothValue;
			}
			set
			{
				_perspZoomSmoothValue = Mathf.Max(value, 0.001f);
			}
		}

		public bool InvertZoomAxis
		{
			get
			{
				return _invertZoomAxis;
			}
			set
			{
				_invertZoomAxis = value;
			}
		}

		public bool IsZoomEnabled
		{
			get
			{
				return _isZoomEnabled;
			}
			set
			{
				_isZoomEnabled = value;
			}
		}

		public float GetZoomSmoothValue(Camera camera)
		{
			if (!camera.orthographic)
			{
				return PerspZoomSmoothValue;
			}
			return OrthoZoomSmoothValue;
		}

		public float GetZoomSensitivity(Camera camera)
		{
			if (_zoomMode == CameraZoomMode.Standard)
			{
				if (!camera.orthographic)
				{
					return PerspStandardZoomSensitivity;
				}
				return OrthoStandardZoomSensitivity;
			}
			if (_zoomMode == CameraZoomMode.Smooth)
			{
				if (!camera.orthographic)
				{
					return PerspSmoothZoomSensitivity;
				}
				return OrthoSmoothZoomSensitivity;
			}
			return 0f;
		}
	}
}
