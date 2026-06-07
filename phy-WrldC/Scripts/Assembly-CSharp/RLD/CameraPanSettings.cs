using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class CameraPanSettings : Settings
	{
		[SerializeField]
		private CameraPanMode _panMode;

		[SerializeField]
		private float _standardPanSensitivity = 1f;

		[SerializeField]
		private float _smoothPanSensitivity = 0.7f;

		[SerializeField]
		private float _smoothValue = 4f;

		[SerializeField]
		private bool _invertX;

		[SerializeField]
		private bool _invertY;

		[SerializeField]
		private bool _isPanningEnabled = true;

		public CameraPanMode PanMode
		{
			get
			{
				return _panMode;
			}
			set
			{
				_panMode = value;
			}
		}

		public float StandardPanSensitivity
		{
			get
			{
				return _standardPanSensitivity;
			}
			set
			{
				_standardPanSensitivity = Mathf.Max(value, 0.001f);
			}
		}

		public float SmoothPanSensitivity
		{
			get
			{
				return _smoothPanSensitivity;
			}
			set
			{
				_smoothPanSensitivity = Mathf.Max(value, 0.001f);
			}
		}

		public float Sensitivity
		{
			get
			{
				if (_panMode != CameraPanMode.Standard)
				{
					return _smoothPanSensitivity;
				}
				return _standardPanSensitivity;
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

		public bool IsPanningEnabled
		{
			get
			{
				return _isPanningEnabled;
			}
			set
			{
				_isPanningEnabled = value;
			}
		}
	}
}
