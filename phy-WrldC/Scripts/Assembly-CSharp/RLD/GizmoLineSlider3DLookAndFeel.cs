using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class GizmoLineSlider3DLookAndFeel
	{
		[SerializeField]
		private GizmoShadeMode _shadeMode;

		[SerializeField]
		private GizmoLine3DType _lineType;

		[SerializeField]
		private GizmoFillMode3D _fillMode;

		[SerializeField]
		private float _length = 5f;

		[SerializeField]
		private float _scale = 1f;

		[SerializeField]
		private bool _useZoomFactor = true;

		[SerializeField]
		private float _boxHeight = 0.18f;

		[SerializeField]
		private float _boxDepth = 0.18f;

		[SerializeField]
		private float _cylinderRadius = 0.15f;

		[SerializeField]
		private bool _isRotationArcVisible = true;

		[SerializeField]
		private GizmoRotationArc3DLookAndFeel _rotationArcLookAndFeel = new GizmoRotationArc3DLookAndFeel();

		[SerializeField]
		private Color _color = RTSystemValues.XAxisColor;

		[SerializeField]
		private Color _hoveredColor = RTSystemValues.HoveredAxisColor;

		[SerializeField]
		private GizmoCap3DLookAndFeel _capLookAndFeel = new GizmoCap3DLookAndFeel();

		public GizmoShadeMode ShadeMode
		{
			get
			{
				return _shadeMode;
			}
			set
			{
				_shadeMode = value;
			}
		}

		public GizmoLine3DType LineType
		{
			get
			{
				return _lineType;
			}
			set
			{
				_lineType = value;
			}
		}

		public GizmoFillMode3D FillMode
		{
			get
			{
				return _fillMode;
			}
			set
			{
				_fillMode = value;
			}
		}

		public float Length
		{
			get
			{
				return _length;
			}
			set
			{
				_length = Mathf.Max(0f, value);
			}
		}

		public float Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				_scale = Mathf.Max(0f, value);
			}
		}

		public bool UseZoomFactor
		{
			get
			{
				return _useZoomFactor;
			}
			set
			{
				_useZoomFactor = value;
			}
		}

		public bool IsRotationArcVisible
		{
			get
			{
				return _isRotationArcVisible;
			}
			set
			{
				_isRotationArcVisible = value;
			}
		}

		public GizmoRotationArc3DLookAndFeel RotationArcLookAndFeel => _rotationArcLookAndFeel;

		public GizmoCap3DLookAndFeel CapLookAndFeel => _capLookAndFeel;

		public float BoxHeight
		{
			get
			{
				return _boxHeight;
			}
			set
			{
				_boxHeight = Mathf.Max(0f, value);
			}
		}

		public float BoxDepth
		{
			get
			{
				return _boxDepth;
			}
			set
			{
				_boxDepth = Mathf.Max(0f, value);
			}
		}

		public float CylinderRadius
		{
			get
			{
				return _cylinderRadius;
			}
			set
			{
				_cylinderRadius = Mathf.Max(0f, value);
			}
		}

		public Color Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
			}
		}

		public Color HoveredColor
		{
			get
			{
				return _hoveredColor;
			}
			set
			{
				_hoveredColor = value;
			}
		}
	}
}
