using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class GizmoLineSlider2DSettings
	{
		[SerializeField]
		private float _lineHoverEps = 10f;

		[SerializeField]
		private float _boxHoverEps = 10f;

		[SerializeField]
		private float _offsetSnapStep = 1f;

		[SerializeField]
		private float _rotationSnapStep = 15f;

		[SerializeField]
		private GizmoSnapMode _rotationSnapMode;

		[SerializeField]
		private float _scaleSnapStep = 0.1f;

		[SerializeField]
		private float _offsetSensitivity = 1f;

		[SerializeField]
		private float _rotationSensitivity = 0.45f;

		[SerializeField]
		private float _scaleSensitivity = 1f;

		public float LineHoverEps
		{
			get
			{
				return _lineHoverEps;
			}
			set
			{
				_lineHoverEps = Mathf.Max(0f, value);
			}
		}

		public float BoxHoverEps
		{
			get
			{
				return _boxHoverEps;
			}
			set
			{
				_boxHoverEps = Mathf.Max(0f, value);
			}
		}

		public float OffsetSnapStep
		{
			get
			{
				return _offsetSnapStep;
			}
			set
			{
				_offsetSnapStep = Mathf.Max(0.0001f, value);
			}
		}

		public float RotationSnapStep
		{
			get
			{
				return _rotationSnapStep;
			}
			set
			{
				_rotationSnapStep = Mathf.Max(0.0001f, value);
			}
		}

		public GizmoSnapMode RotationSnapMode
		{
			get
			{
				return _rotationSnapMode;
			}
			set
			{
				_rotationSnapMode = value;
			}
		}

		public float ScaleSnapStep
		{
			get
			{
				return _scaleSnapStep;
			}
			set
			{
				_scaleSnapStep = Mathf.Max(0.0001f, value);
			}
		}

		public float OffsetSensitivity
		{
			get
			{
				return _offsetSensitivity;
			}
			set
			{
				_offsetSensitivity = Mathf.Max(0.0001f, value);
			}
		}

		public float RotationSensitivity
		{
			get
			{
				return _rotationSensitivity;
			}
			set
			{
				_rotationSensitivity = Mathf.Max(0.0001f, value);
			}
		}

		public float ScaleSensitivity
		{
			get
			{
				return _scaleSensitivity;
			}
			set
			{
				_scaleSensitivity = Mathf.Max(0.0001f, value);
			}
		}
	}
}
