using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class UniversalGizmoLookAndFeel2D : Settings
	{
		[SerializeField]
		private UniversalGizmoSettingsCategory _displayCategory;

		[SerializeField]
		private GizmoPlaneSlider2DLookAndFeel _mvDblSliderLookAndFeel = new GizmoPlaneSlider2DLookAndFeel();

		[SerializeField]
		private GizmoLineSlider2DLookAndFeel[] _mvSglSliderLookAndFeel = new GizmoLineSlider2DLookAndFeel[4];

		[SerializeField]
		private bool _isMvDblSliderVisible = true;

		[SerializeField]
		private bool[] _mvSglSliderVis = new bool[4];

		[SerializeField]
		private bool[] _mvSglSliderCapVis = new bool[4];

		public float MvScale => _mvSglSliderLookAndFeel[0].Scale;

		public float MvSliderLength => _mvSglSliderLookAndFeel[0].Length;

		public float MvBoxSliderThickness => _mvSglSliderLookAndFeel[0].BoxThickness;

		public float MvSliderArrowCapHeight => _mvSglSliderLookAndFeel[0].CapLookAndFeel.ArrowHeight;

		public float MvSliderArrowCapBaseRadius => _mvSglSliderLookAndFeel[0].CapLookAndFeel.ArrowBaseRadius;

		public float MvSliderQuadCapWidth => _mvSglSliderLookAndFeel[0].CapLookAndFeel.QuadWidth;

		public float MvSliderQuadCapHeight => _mvSglSliderLookAndFeel[0].CapLookAndFeel.QuadHeight;

		public float MvSliderCircleCapRadius => _mvSglSliderLookAndFeel[0].CapLookAndFeel.CircleRadius;

		public float MvDblSliderQuadWidth => _mvDblSliderLookAndFeel.QuadWidth;

		public float MvDblSliderQuadHeight => _mvDblSliderLookAndFeel.QuadHeight;

		public float MvDblSliderCircleRadius => _mvDblSliderLookAndFeel.CircleRadius;

		public Color MvXColor => GetMvSliderLookAndFeel(0, AxisSign.Positive).Color;

		public Color MvYColor => GetMvSliderLookAndFeel(1, AxisSign.Positive).Color;

		public Color MvXBorderColor => GetMvSliderLookAndFeel(0, AxisSign.Positive).BorderColor;

		public Color MvYBorderColor => GetMvSliderLookAndFeel(1, AxisSign.Positive).BorderColor;

		public Color MvDblSliderColor => _mvDblSliderLookAndFeel.Color;

		public Color MvDblSliderBorderColor => _mvDblSliderLookAndFeel.BorderColor;

		public Color MvDblSliderHoveredColor => _mvDblSliderLookAndFeel.HoveredColor;

		public Color MvDblSliderHoveredBorderColor => _mvDblSliderLookAndFeel.HoveredBorderColor;

		public bool IsMvDblSliderVisible => _isMvDblSliderVisible;

		public Color MvSliderHoveredColor => _mvSglSliderLookAndFeel[0].HoveredColor;

		public Color MvSliderHoveredBorderColor => _mvSglSliderLookAndFeel[0].HoveredBorderColor;

		public GizmoFillMode2D MvSliderFillMode => _mvSglSliderLookAndFeel[0].FillMode;

		public GizmoFillMode2D MvSliderCapFillMode => _mvSglSliderLookAndFeel[0].CapLookAndFeel.FillMode;

		public GizmoFillMode2D MvDblSliderFillMode => _mvDblSliderLookAndFeel.FillMode;

		public GizmoCap2DType MvSliderCapType => _mvSglSliderLookAndFeel[0].CapLookAndFeel.CapType;

		public GizmoLine2DType MvSliderLineType => _mvSglSliderLookAndFeel[0].LineType;

		public GizmoPlane2DType MvDblSliderPlaneType => _mvDblSliderLookAndFeel.PlaneType;

		public UniversalGizmoSettingsCategory DisplayCategory
		{
			get
			{
				return _displayCategory;
			}
			set
			{
				_displayCategory = value;
			}
		}

		public UniversalGizmoLookAndFeel2D()
		{
			for (int i = 0; i < _mvSglSliderLookAndFeel.Length; i++)
			{
				_mvSglSliderLookAndFeel[i] = new GizmoLineSlider2DLookAndFeel();
			}
			SetMvAxisColor(0, RTSystemValues.XAxisColor);
			SetMvAxisColor(1, RTSystemValues.YAxisColor);
			SetMvAxisBorderColor(0, RTSystemValues.XAxisColor);
			SetMvAxisBorderColor(1, RTSystemValues.YAxisColor);
			SetMvSliderHoveredFillColor(RTSystemValues.HoveredAxisColor);
			SetMvSliderHoveredBorderColor(RTSystemValues.HoveredAxisColor);
			SetMvSliderCapType(GizmoCap2DType.Arrow);
			SetMvSliderCapFillMode(GizmoFillMode2D.Filled);
			SetMvSliderFillMode(GizmoFillMode2D.Filled);
			SetMvSliderVisible(0, AxisSign.Positive, isVisible: true);
			SetMvSliderVisible(1, AxisSign.Positive, isVisible: true);
			SetMvSliderCapVisible(0, AxisSign.Positive, isVisible: true);
			SetMvSliderCapVisible(1, AxisSign.Positive, isVisible: true);
			SetMvDblSliderFillMode(GizmoFillMode2D.Border);
			SetMvDblSliderColor(Color.white.KeepAllButAlpha(RTSystemValues.AxisAlpha));
			SetMvDblSliderBorderColor(Color.white);
			SetMvDblSliderHoveredColor(RTSystemValues.HoveredAxisColor.KeepAllButAlpha(RTSystemValues.AxisAlpha));
			SetMvDblSliderHoveredBorderColor(RTSystemValues.HoveredAxisColor);
		}

		public void SetMvDblSliderVisible(bool isVisible)
		{
			_isMvDblSliderVisible = isVisible;
		}

		public bool IsMvSliderVisible(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _mvSglSliderVis[axisIndex];
			}
			return _mvSglSliderVis[2 + axisIndex];
		}

		public bool IsMvPositiveSliderVisible(int axisIndex)
		{
			return _mvSglSliderVis[axisIndex];
		}

		public bool IsMvNegativeSliderVisible(int axisIndex)
		{
			return _mvSglSliderVis[2 + axisIndex];
		}

		public void SetMvSliderVisible(int axisIndex, AxisSign axisSign, bool isVisible)
		{
			if (axisSign == AxisSign.Positive)
			{
				_mvSglSliderVis[axisIndex] = isVisible;
			}
			else
			{
				_mvSglSliderVis[2 + axisIndex] = isVisible;
			}
		}

		public bool IsMvSliderCapVisible(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _mvSglSliderCapVis[axisIndex];
			}
			return _mvSglSliderCapVis[2 + axisIndex];
		}

		public bool IsMvPositiveSliderCapVisible(int axisIndex)
		{
			return _mvSglSliderCapVis[axisIndex];
		}

		public bool IsMvNegativeSliderCapVisible(int axisIndex)
		{
			return _mvSglSliderCapVis[2 + axisIndex];
		}

		public void SetMvSliderCapVisible(int axisIndex, AxisSign axisSign, bool isVisible)
		{
			if (axisSign == AxisSign.Positive)
			{
				_mvSglSliderCapVis[axisIndex] = isVisible;
			}
			else
			{
				_mvSglSliderCapVis[2 + axisIndex] = isVisible;
			}
		}

		public void SetMvAxisColor(int axisIndex, Color color)
		{
			GetMvSliderLookAndFeel(axisIndex, AxisSign.Positive).Color = color;
			GetMvSliderLookAndFeel(axisIndex, AxisSign.Positive).CapLookAndFeel.Color = color;
			GetMvSliderLookAndFeel(axisIndex, AxisSign.Negative).Color = color;
			GetMvSliderLookAndFeel(axisIndex, AxisSign.Negative).CapLookAndFeel.Color = color;
		}

		public void SetMvAxisBorderColor(int axisIndex, Color color)
		{
			GetMvSliderLookAndFeel(axisIndex, AxisSign.Positive).BorderColor = color;
			GetMvSliderLookAndFeel(axisIndex, AxisSign.Positive).CapLookAndFeel.BorderColor = color;
			GetMvSliderLookAndFeel(axisIndex, AxisSign.Negative).BorderColor = color;
			GetMvSliderLookAndFeel(axisIndex, AxisSign.Negative).CapLookAndFeel.BorderColor = color;
		}

		public void SetMvSliderHoveredFillColor(Color color)
		{
			GizmoLineSlider2DLookAndFeel[] mvSglSliderLookAndFeel = _mvSglSliderLookAndFeel;
			foreach (GizmoLineSlider2DLookAndFeel obj in mvSglSliderLookAndFeel)
			{
				obj.HoveredColor = color;
				obj.CapLookAndFeel.HoveredColor = color;
			}
		}

		public void SetMvSliderHoveredBorderColor(Color color)
		{
			GizmoLineSlider2DLookAndFeel[] mvSglSliderLookAndFeel = _mvSglSliderLookAndFeel;
			foreach (GizmoLineSlider2DLookAndFeel obj in mvSglSliderLookAndFeel)
			{
				obj.HoveredBorderColor = color;
				obj.CapLookAndFeel.HoveredBorderColor = color;
			}
		}

		public void SetMvSliderFillMode(GizmoFillMode2D fillMode)
		{
			GizmoLineSlider2DLookAndFeel[] mvSglSliderLookAndFeel = _mvSglSliderLookAndFeel;
			for (int i = 0; i < mvSglSliderLookAndFeel.Length; i++)
			{
				mvSglSliderLookAndFeel[i].FillMode = fillMode;
			}
		}

		public void SetMvDblSliderFillMode(GizmoFillMode2D fillMode)
		{
			_mvDblSliderLookAndFeel.FillMode = fillMode;
		}

		public void SetMvSliderCapFillMode(GizmoFillMode2D fillMode)
		{
			GizmoLineSlider2DLookAndFeel[] mvSglSliderLookAndFeel = _mvSglSliderLookAndFeel;
			for (int i = 0; i < mvSglSliderLookAndFeel.Length; i++)
			{
				mvSglSliderLookAndFeel[i].CapLookAndFeel.FillMode = fillMode;
			}
		}

		public void SetMvSliderLineType(GizmoLine2DType lineType)
		{
			GizmoLineSlider2DLookAndFeel[] mvSglSliderLookAndFeel = _mvSglSliderLookAndFeel;
			for (int i = 0; i < mvSglSliderLookAndFeel.Length; i++)
			{
				mvSglSliderLookAndFeel[i].LineType = lineType;
			}
		}

		public void SetMvBoxSliderThickness(float thickness)
		{
			GizmoLineSlider2DLookAndFeel[] mvSglSliderLookAndFeel = _mvSglSliderLookAndFeel;
			for (int i = 0; i < mvSglSliderLookAndFeel.Length; i++)
			{
				mvSglSliderLookAndFeel[i].BoxThickness = thickness;
			}
		}

		public void SetMvSliderLength(float length)
		{
			GizmoLineSlider2DLookAndFeel[] mvSglSliderLookAndFeel = _mvSglSliderLookAndFeel;
			for (int i = 0; i < mvSglSliderLookAndFeel.Length; i++)
			{
				mvSglSliderLookAndFeel[i].Length = length;
			}
		}

		public void SetMvSliderCapType(GizmoCap2DType capType)
		{
			GizmoLineSlider2DLookAndFeel[] mvSglSliderLookAndFeel = _mvSglSliderLookAndFeel;
			for (int i = 0; i < mvSglSliderLookAndFeel.Length; i++)
			{
				mvSglSliderLookAndFeel[i].CapLookAndFeel.CapType = capType;
			}
		}

		public void SetMvSliderArrowCapBaseRadius(float radius)
		{
			GizmoLineSlider2DLookAndFeel[] mvSglSliderLookAndFeel = _mvSglSliderLookAndFeel;
			for (int i = 0; i < mvSglSliderLookAndFeel.Length; i++)
			{
				mvSglSliderLookAndFeel[i].CapLookAndFeel.ArrowBaseRadius = radius;
			}
		}

		public void SetMvSliderArrowCapHeight(float height)
		{
			GizmoLineSlider2DLookAndFeel[] mvSglSliderLookAndFeel = _mvSglSliderLookAndFeel;
			for (int i = 0; i < mvSglSliderLookAndFeel.Length; i++)
			{
				mvSglSliderLookAndFeel[i].CapLookAndFeel.ArrowHeight = height;
			}
		}

		public void SetMvSliderQuadCapWidth(float width)
		{
			GizmoLineSlider2DLookAndFeel[] mvSglSliderLookAndFeel = _mvSglSliderLookAndFeel;
			for (int i = 0; i < mvSglSliderLookAndFeel.Length; i++)
			{
				mvSglSliderLookAndFeel[i].CapLookAndFeel.QuadWidth = width;
			}
		}

		public void SetMvSliderQuadCapHeight(float height)
		{
			GizmoLineSlider2DLookAndFeel[] mvSglSliderLookAndFeel = _mvSglSliderLookAndFeel;
			for (int i = 0; i < mvSglSliderLookAndFeel.Length; i++)
			{
				mvSglSliderLookAndFeel[i].CapLookAndFeel.QuadHeight = height;
			}
		}

		public void SetMvSliderCircleCapRadius(float radius)
		{
			GizmoLineSlider2DLookAndFeel[] mvSglSliderLookAndFeel = _mvSglSliderLookAndFeel;
			for (int i = 0; i < mvSglSliderLookAndFeel.Length; i++)
			{
				mvSglSliderLookAndFeel[i].CapLookAndFeel.CircleRadius = radius;
			}
		}

		public void SetMvDblSliderPlaneType(GizmoPlane2DType sliderType)
		{
			_mvDblSliderLookAndFeel.PlaneType = sliderType;
		}

		public void SetMvDblSliderQuadWidth(float width)
		{
			_mvDblSliderLookAndFeel.QuadWidth = width;
		}

		public void SetMvDblSliderQuadHeight(float height)
		{
			_mvDblSliderLookAndFeel.QuadHeight = height;
		}

		public void SetMvDblSliderCircleRadius(float radius)
		{
			_mvDblSliderLookAndFeel.CircleRadius = radius;
		}

		public void SetMvDblSliderColor(Color color)
		{
			_mvDblSliderLookAndFeel.Color = color;
		}

		public void SetMvDblSliderBorderColor(Color color)
		{
			_mvDblSliderLookAndFeel.BorderColor = color;
		}

		public void SetMvDblSliderHoveredColor(Color color)
		{
			_mvDblSliderLookAndFeel.HoveredColor = color;
		}

		public void SetMvDblSliderHoveredBorderColor(Color color)
		{
			_mvDblSliderLookAndFeel.HoveredBorderColor = color;
		}

		public void SetMvScale(float scale)
		{
			GizmoLineSlider2DLookAndFeel[] mvSglSliderLookAndFeel = _mvSglSliderLookAndFeel;
			foreach (GizmoLineSlider2DLookAndFeel obj in mvSglSliderLookAndFeel)
			{
				obj.Scale = scale;
				obj.CapLookAndFeel.Scale = scale;
			}
			_mvDblSliderLookAndFeel.Scale = scale;
		}

		public void ConnectMvSliderLookAndFeel(GizmoLineSlider2D slider, int axisIndex, AxisSign axisSign)
		{
			slider.SharedLookAndFeel = GetMvSliderLookAndFeel(axisIndex, axisSign);
		}

		public void ConnectMvDblSliderLookAndFeel(GizmoPlaneSlider2D slider)
		{
			slider.SharedLookAndFeel = _mvDblSliderLookAndFeel;
		}

		public void Inherit(MoveGizmoLookAndFeel2D lookAndFeel)
		{
			SetMvAxisBorderColor(0, lookAndFeel.XBorderColor);
			SetMvAxisBorderColor(1, lookAndFeel.YBorderColor);
			SetMvAxisColor(0, lookAndFeel.XColor);
			SetMvAxisColor(1, lookAndFeel.YColor);
			SetMvBoxSliderThickness(lookAndFeel.BoxSliderThickness);
			SetMvDblSliderBorderColor(lookAndFeel.DblSliderBorderColor);
			SetMvDblSliderCircleRadius(lookAndFeel.DblSliderCircleRadius);
			SetMvDblSliderColor(lookAndFeel.DblSliderColor);
			SetMvDblSliderFillMode(lookAndFeel.DblSliderFillMode);
			SetMvDblSliderHoveredBorderColor(lookAndFeel.DblSliderHoveredBorderColor);
			SetMvDblSliderHoveredColor(lookAndFeel.DblSliderHoveredColor);
			SetMvDblSliderQuadHeight(lookAndFeel.DblSliderQuadHeight);
			SetMvDblSliderQuadWidth(lookAndFeel.DblSliderQuadWidth);
			SetMvDblSliderPlaneType(lookAndFeel.DblSliderPlaneType);
			SetMvDblSliderVisible(lookAndFeel.IsDblSliderVisible);
			SetMvScale(lookAndFeel.Scale);
			SetMvSliderArrowCapHeight(lookAndFeel.SliderArrowCapHeight);
			SetMvSliderArrowCapBaseRadius(lookAndFeel.SliderArrowCapBaseRadius);
			SetMvSliderCircleCapRadius(lookAndFeel.SliderCircleCapRadius);
			SetMvSliderCapFillMode(lookAndFeel.SliderCapFillMode);
			SetMvSliderCapType(lookAndFeel.SliderCapType);
			SetMvSliderCapVisible(0, AxisSign.Positive, lookAndFeel.IsSliderCapVisible(0, AxisSign.Positive));
			SetMvSliderCapVisible(1, AxisSign.Positive, lookAndFeel.IsSliderCapVisible(1, AxisSign.Positive));
			SetMvSliderCapVisible(0, AxisSign.Negative, lookAndFeel.IsSliderCapVisible(0, AxisSign.Negative));
			SetMvSliderCapVisible(1, AxisSign.Negative, lookAndFeel.IsSliderCapVisible(1, AxisSign.Negative));
			SetMvSliderFillMode(lookAndFeel.SliderFillMode);
			SetMvSliderHoveredBorderColor(lookAndFeel.SliderHoveredBorderColor);
			SetMvSliderHoveredFillColor(lookAndFeel.SliderHoveredColor);
			SetMvSliderLength(lookAndFeel.SliderLength);
			SetMvSliderLineType(lookAndFeel.SliderLineType);
			SetMvSliderQuadCapHeight(lookAndFeel.SliderQuadCapHeight);
			SetMvSliderQuadCapWidth(lookAndFeel.SliderQuadCapWidth);
			SetMvSliderVisible(0, AxisSign.Positive, lookAndFeel.IsSliderVisible(0, AxisSign.Positive));
			SetMvSliderVisible(1, AxisSign.Positive, lookAndFeel.IsSliderVisible(1, AxisSign.Positive));
			SetMvSliderVisible(0, AxisSign.Negative, lookAndFeel.IsSliderVisible(0, AxisSign.Negative));
			SetMvSliderVisible(1, AxisSign.Negative, lookAndFeel.IsSliderVisible(1, AxisSign.Negative));
		}

		private GizmoLineSlider2DLookAndFeel GetMvSliderLookAndFeel(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _mvSglSliderLookAndFeel[axisIndex];
			}
			return _mvSglSliderLookAndFeel[2 + axisIndex];
		}
	}
}
