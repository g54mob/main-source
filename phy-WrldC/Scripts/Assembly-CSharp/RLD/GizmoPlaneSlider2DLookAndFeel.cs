using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class GizmoPlaneSlider2DLookAndFeel
	{
		[SerializeField]
		private GizmoFillMode2D _fillMode = GizmoFillMode2D.FilledAndBorder;

		[SerializeField]
		private GizmoPlane2DType _planeType;

		[SerializeField]
		private float _scale = 1f;

		[SerializeField]
		private float _quadWidth = 25f;

		[SerializeField]
		private float _quadHeight = 25f;

		[SerializeField]
		private float _circleRadius = 12f;

		[SerializeField]
		private bool _isRotationArcVisible = true;

		[SerializeField]
		private GizmoRotationArc2DLookAndFeel _rotationArcLookAndFeel = new GizmoRotationArc2DLookAndFeel();

		[SerializeField]
		private Color _color = Color.white;

		[SerializeField]
		private Color _hoveredColor = RTSystemValues.HoveredAxisColor;

		[SerializeField]
		private Color _borderColor = Color.white;

		[SerializeField]
		private Color _hoveredBorderColor = RTSystemValues.HoveredAxisColor;

		[SerializeField]
		private GizmoQuad2DBorderType _quadBorderType;

		[SerializeField]
		private GizmoCircle2DBorderType _circleBorderType;

		[SerializeField]
		private GizmoPolygon2DBorderType _polygonBorderType;

		[SerializeField]
		private float _borderPolyThickness = 8f;

		public GizmoFillMode2D FillMode
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

		public GizmoPlane2DType PlaneType
		{
			get
			{
				return _planeType;
			}
			set
			{
				_planeType = value;
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

		public float QuadWidth
		{
			get
			{
				return _quadWidth;
			}
			set
			{
				_quadWidth = Mathf.Max(0f, value);
			}
		}

		public float QuadHeight
		{
			get
			{
				return _quadHeight;
			}
			set
			{
				_quadHeight = Mathf.Max(0f, value);
			}
		}

		public float CircleRadius
		{
			get
			{
				return _circleRadius;
			}
			set
			{
				_circleRadius = Mathf.Max(0f, value);
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

		public GizmoRotationArc2DLookAndFeel RotationArcLookAndFeel => _rotationArcLookAndFeel;

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

		public Color BorderColor
		{
			get
			{
				return _borderColor;
			}
			set
			{
				_borderColor = value;
			}
		}

		public Color HoveredBorderColor
		{
			get
			{
				return _hoveredBorderColor;
			}
			set
			{
				_hoveredBorderColor = value;
			}
		}

		public GizmoQuad2DBorderType QuadBorderType
		{
			get
			{
				return _quadBorderType;
			}
			set
			{
				_quadBorderType = value;
			}
		}

		public GizmoCircle2DBorderType CircleBorderType
		{
			get
			{
				return _circleBorderType;
			}
			set
			{
				_circleBorderType = value;
			}
		}

		public GizmoPolygon2DBorderType PolygonBorderType
		{
			get
			{
				return _polygonBorderType;
			}
			set
			{
				_polygonBorderType = value;
			}
		}

		public float BorderPolyThickness
		{
			get
			{
				return _borderPolyThickness;
			}
			set
			{
				_borderPolyThickness = Mathf.Max(0f, value);
			}
		}
	}
}
