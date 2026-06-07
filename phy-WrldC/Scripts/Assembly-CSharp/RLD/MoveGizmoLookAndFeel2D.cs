using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class MoveGizmoLookAndFeel2D : Settings
	{
		[SerializeField]
		private GizmoPlaneSlider2DLookAndFeel _dblSliderLookAndFeel = new GizmoPlaneSlider2DLookAndFeel();

		[SerializeField]
		private GizmoLineSlider2DLookAndFeel[] _sglSliderLookAndFeel = new GizmoLineSlider2DLookAndFeel[4];

		[SerializeField]
		private bool _isDblSliderVisible = true;

		[SerializeField]
		private bool[] _sglSliderVis = new bool[4];

		[SerializeField]
		private bool[] _sglSliderCapVis = new bool[4];

		public float Scale => _sglSliderLookAndFeel[0].Scale;

		public float SliderLength => _sglSliderLookAndFeel[0].Length;

		public float BoxSliderThickness => _sglSliderLookAndFeel[0].BoxThickness;

		public float SliderArrowCapHeight => _sglSliderLookAndFeel[0].CapLookAndFeel.ArrowHeight;

		public float SliderArrowCapBaseRadius => _sglSliderLookAndFeel[0].CapLookAndFeel.ArrowBaseRadius;

		public float SliderQuadCapWidth => _sglSliderLookAndFeel[0].CapLookAndFeel.QuadWidth;

		public float SliderQuadCapHeight => _sglSliderLookAndFeel[0].CapLookAndFeel.QuadHeight;

		public float SliderCircleCapRadius => _sglSliderLookAndFeel[0].CapLookAndFeel.CircleRadius;

		public float DblSliderQuadWidth => _dblSliderLookAndFeel.QuadWidth;

		public float DblSliderQuadHeight => _dblSliderLookAndFeel.QuadHeight;

		public float DblSliderCircleRadius => _dblSliderLookAndFeel.CircleRadius;

		public Color XColor => GetSliderLookAndFeel(0, AxisSign.Positive).Color;

		public Color YColor => GetSliderLookAndFeel(1, AxisSign.Positive).Color;

		public Color XBorderColor => GetSliderLookAndFeel(0, AxisSign.Positive).BorderColor;

		public Color YBorderColor => GetSliderLookAndFeel(1, AxisSign.Positive).BorderColor;

		public Color DblSliderColor => _dblSliderLookAndFeel.Color;

		public Color DblSliderBorderColor => _dblSliderLookAndFeel.BorderColor;

		public Color DblSliderHoveredColor => _dblSliderLookAndFeel.HoveredColor;

		public Color DblSliderHoveredBorderColor => _dblSliderLookAndFeel.HoveredBorderColor;

		public bool IsDblSliderVisible => _isDblSliderVisible;

		public Color SliderHoveredColor => _sglSliderLookAndFeel[0].HoveredColor;

		public Color SliderHoveredBorderColor => _sglSliderLookAndFeel[0].HoveredBorderColor;

		public GizmoFillMode2D SliderFillMode => _sglSliderLookAndFeel[0].FillMode;

		public GizmoFillMode2D SliderCapFillMode => _sglSliderLookAndFeel[0].CapLookAndFeel.FillMode;

		public GizmoFillMode2D DblSliderFillMode => _dblSliderLookAndFeel.FillMode;

		public GizmoCap2DType SliderCapType => _sglSliderLookAndFeel[0].CapLookAndFeel.CapType;

		public GizmoLine2DType SliderLineType => _sglSliderLookAndFeel[0].LineType;

		public GizmoPlane2DType DblSliderPlaneType => _dblSliderLookAndFeel.PlaneType;

		public MoveGizmoLookAndFeel2D()
		{
			for (int i = 0; i < _sglSliderLookAndFeel.Length; i++)
			{
				_sglSliderLookAndFeel[i] = new GizmoLineSlider2DLookAndFeel();
			}
			SetAxisColor(0, RTSystemValues.XAxisColor);
			SetAxisColor(1, RTSystemValues.YAxisColor);
			SetAxisBorderColor(0, RTSystemValues.XAxisColor);
			SetAxisBorderColor(1, RTSystemValues.YAxisColor);
			SetSliderHoveredFillColor(RTSystemValues.HoveredAxisColor);
			SetSliderHoveredBorderColor(RTSystemValues.HoveredAxisColor);
			SetSliderCapType(GizmoCap2DType.Arrow);
			SetSliderCapFillMode(GizmoFillMode2D.Filled);
			SetSliderFillMode(GizmoFillMode2D.Filled);
			SetSliderVisible(0, AxisSign.Positive, isVisible: true);
			SetSliderVisible(1, AxisSign.Positive, isVisible: true);
			SetSliderCapVisible(0, AxisSign.Positive, isVisible: true);
			SetSliderCapVisible(1, AxisSign.Positive, isVisible: true);
			SetDblSliderFillMode(GizmoFillMode2D.Border);
			SetDblSliderColor(Color.white.KeepAllButAlpha(RTSystemValues.AxisAlpha));
			SetDblSliderBorderColor(Color.white);
			SetDblSliderHoveredColor(RTSystemValues.HoveredAxisColor.KeepAllButAlpha(RTSystemValues.AxisAlpha));
			SetDblSliderHoveredBorderColor(RTSystemValues.HoveredAxisColor);
		}

		public bool IsDblSliderPlaneTypeAllowed(GizmoPlane2DType planeType)
		{
			if (planeType != GizmoPlane2DType.Circle)
			{
				return planeType == GizmoPlane2DType.Quad;
			}
			return true;
		}

		public List<Enum> GetAllowedDblSliderPlaneTypes()
		{
			return new List<Enum>
			{
				GizmoPlane2DType.Circle,
				GizmoPlane2DType.Quad
			};
		}

		public void SetDblSliderVisible(bool isVisible)
		{
			_isDblSliderVisible = isVisible;
		}

		public bool IsSliderVisible(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _sglSliderVis[axisIndex];
			}
			return _sglSliderVis[2 + axisIndex];
		}

		public bool IsPositiveSliderVisible(int axisIndex)
		{
			return _sglSliderVis[axisIndex];
		}

		public bool IsNegativeSliderVisible(int axisIndex)
		{
			return _sglSliderVis[2 + axisIndex];
		}

		public void SetSliderVisible(int axisIndex, AxisSign axisSign, bool isVisible)
		{
			if (axisSign == AxisSign.Positive)
			{
				_sglSliderVis[axisIndex] = isVisible;
			}
			else
			{
				_sglSliderVis[2 + axisIndex] = isVisible;
			}
		}

		public bool IsSliderCapVisible(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _sglSliderCapVis[axisIndex];
			}
			return _sglSliderCapVis[2 + axisIndex];
		}

		public bool IsPositiveSliderCapVisible(int axisIndex)
		{
			return _sglSliderCapVis[axisIndex];
		}

		public bool IsNegativeSliderCapVisible(int axisIndex)
		{
			return _sglSliderCapVis[2 + axisIndex];
		}

		public void SetSliderCapVisible(int axisIndex, AxisSign axisSign, bool isVisible)
		{
			if (axisSign == AxisSign.Positive)
			{
				_sglSliderCapVis[axisIndex] = isVisible;
			}
			else
			{
				_sglSliderCapVis[2 + axisIndex] = isVisible;
			}
		}

		public void SetAxisColor(int axisIndex, Color color)
		{
			GetSliderLookAndFeel(axisIndex, AxisSign.Positive).Color = color;
			GetSliderLookAndFeel(axisIndex, AxisSign.Positive).CapLookAndFeel.Color = color;
			GetSliderLookAndFeel(axisIndex, AxisSign.Negative).Color = color;
			GetSliderLookAndFeel(axisIndex, AxisSign.Negative).CapLookAndFeel.Color = color;
		}

		public void SetAxisBorderColor(int axisIndex, Color color)
		{
			GetSliderLookAndFeel(axisIndex, AxisSign.Positive).BorderColor = color;
			GetSliderLookAndFeel(axisIndex, AxisSign.Positive).CapLookAndFeel.BorderColor = color;
			GetSliderLookAndFeel(axisIndex, AxisSign.Negative).BorderColor = color;
			GetSliderLookAndFeel(axisIndex, AxisSign.Negative).CapLookAndFeel.BorderColor = color;
		}

		public void SetSliderHoveredFillColor(Color color)
		{
			GizmoLineSlider2DLookAndFeel[] sglSliderLookAndFeel = _sglSliderLookAndFeel;
			foreach (GizmoLineSlider2DLookAndFeel obj in sglSliderLookAndFeel)
			{
				obj.HoveredColor = color;
				obj.CapLookAndFeel.HoveredColor = color;
			}
		}

		public void SetSliderHoveredBorderColor(Color color)
		{
			GizmoLineSlider2DLookAndFeel[] sglSliderLookAndFeel = _sglSliderLookAndFeel;
			foreach (GizmoLineSlider2DLookAndFeel obj in sglSliderLookAndFeel)
			{
				obj.HoveredBorderColor = color;
				obj.CapLookAndFeel.HoveredBorderColor = color;
			}
		}

		public void SetSliderFillMode(GizmoFillMode2D fillMode)
		{
			GizmoLineSlider2DLookAndFeel[] sglSliderLookAndFeel = _sglSliderLookAndFeel;
			for (int i = 0; i < sglSliderLookAndFeel.Length; i++)
			{
				sglSliderLookAndFeel[i].FillMode = fillMode;
			}
		}

		public void SetDblSliderFillMode(GizmoFillMode2D fillMode)
		{
			_dblSliderLookAndFeel.FillMode = fillMode;
		}

		public void SetSliderCapFillMode(GizmoFillMode2D fillMode)
		{
			GizmoLineSlider2DLookAndFeel[] sglSliderLookAndFeel = _sglSliderLookAndFeel;
			for (int i = 0; i < sglSliderLookAndFeel.Length; i++)
			{
				sglSliderLookAndFeel[i].CapLookAndFeel.FillMode = fillMode;
			}
		}

		public void SetSliderLineType(GizmoLine2DType lineType)
		{
			GizmoLineSlider2DLookAndFeel[] sglSliderLookAndFeel = _sglSliderLookAndFeel;
			for (int i = 0; i < sglSliderLookAndFeel.Length; i++)
			{
				sglSliderLookAndFeel[i].LineType = lineType;
			}
		}

		public void SetBoxSliderThickness(float thickness)
		{
			GizmoLineSlider2DLookAndFeel[] sglSliderLookAndFeel = _sglSliderLookAndFeel;
			for (int i = 0; i < sglSliderLookAndFeel.Length; i++)
			{
				sglSliderLookAndFeel[i].BoxThickness = thickness;
			}
		}

		public void SetSliderLength(float length)
		{
			GizmoLineSlider2DLookAndFeel[] sglSliderLookAndFeel = _sglSliderLookAndFeel;
			for (int i = 0; i < sglSliderLookAndFeel.Length; i++)
			{
				sglSliderLookAndFeel[i].Length = length;
			}
		}

		public void SetSliderCapType(GizmoCap2DType capType)
		{
			GizmoLineSlider2DLookAndFeel[] sglSliderLookAndFeel = _sglSliderLookAndFeel;
			for (int i = 0; i < sglSliderLookAndFeel.Length; i++)
			{
				sglSliderLookAndFeel[i].CapLookAndFeel.CapType = capType;
			}
		}

		public void SetSliderArrowCapBaseRadius(float radius)
		{
			GizmoLineSlider2DLookAndFeel[] sglSliderLookAndFeel = _sglSliderLookAndFeel;
			for (int i = 0; i < sglSliderLookAndFeel.Length; i++)
			{
				sglSliderLookAndFeel[i].CapLookAndFeel.ArrowBaseRadius = radius;
			}
		}

		public void SetSliderArrowCapHeight(float height)
		{
			GizmoLineSlider2DLookAndFeel[] sglSliderLookAndFeel = _sglSliderLookAndFeel;
			for (int i = 0; i < sglSliderLookAndFeel.Length; i++)
			{
				sglSliderLookAndFeel[i].CapLookAndFeel.ArrowHeight = height;
			}
		}

		public void SetSliderQuadCapWidth(float width)
		{
			GizmoLineSlider2DLookAndFeel[] sglSliderLookAndFeel = _sglSliderLookAndFeel;
			for (int i = 0; i < sglSliderLookAndFeel.Length; i++)
			{
				sglSliderLookAndFeel[i].CapLookAndFeel.QuadWidth = width;
			}
		}

		public void SetSliderQuadCapHeight(float height)
		{
			GizmoLineSlider2DLookAndFeel[] sglSliderLookAndFeel = _sglSliderLookAndFeel;
			for (int i = 0; i < sglSliderLookAndFeel.Length; i++)
			{
				sglSliderLookAndFeel[i].CapLookAndFeel.QuadHeight = height;
			}
		}

		public void SetSliderCircleCapRadius(float radius)
		{
			GizmoLineSlider2DLookAndFeel[] sglSliderLookAndFeel = _sglSliderLookAndFeel;
			for (int i = 0; i < sglSliderLookAndFeel.Length; i++)
			{
				sglSliderLookAndFeel[i].CapLookAndFeel.CircleRadius = radius;
			}
		}

		public void SetDblSliderPlaneType(GizmoPlane2DType sliderType)
		{
			_dblSliderLookAndFeel.PlaneType = sliderType;
		}

		public void SetDblSliderQuadWidth(float width)
		{
			_dblSliderLookAndFeel.QuadWidth = width;
		}

		public void SetDblSliderQuadHeight(float height)
		{
			_dblSliderLookAndFeel.QuadHeight = height;
		}

		public void SetDblSliderCircleRadius(float radius)
		{
			_dblSliderLookAndFeel.CircleRadius = radius;
		}

		public void SetDblSliderColor(Color color)
		{
			_dblSliderLookAndFeel.Color = color;
		}

		public void SetDblSliderBorderColor(Color color)
		{
			_dblSliderLookAndFeel.BorderColor = color;
		}

		public void SetDblSliderHoveredColor(Color color)
		{
			_dblSliderLookAndFeel.HoveredColor = color;
		}

		public void SetDblSliderHoveredBorderColor(Color color)
		{
			_dblSliderLookAndFeel.HoveredBorderColor = color;
		}

		public void SetScale(float scale)
		{
			GizmoLineSlider2DLookAndFeel[] sglSliderLookAndFeel = _sglSliderLookAndFeel;
			foreach (GizmoLineSlider2DLookAndFeel obj in sglSliderLookAndFeel)
			{
				obj.Scale = scale;
				obj.CapLookAndFeel.Scale = scale;
			}
			_dblSliderLookAndFeel.Scale = scale;
		}

		public void ConnectSliderLookAndFeel(GizmoLineSlider2D slider, int axisIndex, AxisSign axisSign)
		{
			slider.SharedLookAndFeel = GetSliderLookAndFeel(axisIndex, axisSign);
		}

		public void ConnectDblSliderLookAndFeel(GizmoPlaneSlider2D slider)
		{
			slider.SharedLookAndFeel = _dblSliderLookAndFeel;
		}

		private GizmoLineSlider2DLookAndFeel GetSliderLookAndFeel(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _sglSliderLookAndFeel[axisIndex];
			}
			return _sglSliderLookAndFeel[2 + axisIndex];
		}
	}
}
