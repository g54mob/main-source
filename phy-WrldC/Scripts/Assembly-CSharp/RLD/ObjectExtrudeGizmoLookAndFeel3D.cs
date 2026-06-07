using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ObjectExtrudeGizmoLookAndFeel3D : Settings
	{
		[SerializeField]
		private Color _boxWireColor = new Color(1f, 1f, 1f, RTSystemValues.AxisAlpha);

		[SerializeField]
		private GizmoLineSlider3DLookAndFeel[] _sglSlidersLookAndFeel = new GizmoLineSlider3DLookAndFeel[6];

		[SerializeField]
		private bool[] _extrudeSliderVis = new bool[6];

		public bool UseZoomFactor => _sglSlidersLookAndFeel[0].CapLookAndFeel.UseZoomFactor;

		public Color BoxWireColor => _boxWireColor;

		public GizmoCap3DType SliderCapType => _sglSlidersLookAndFeel[0].CapLookAndFeel.CapType;

		public GizmoShadeMode SliderCapShadeMode => _sglSlidersLookAndFeel[0].CapLookAndFeel.ShadeMode;

		public GizmoFillMode3D SliderCapFillMode => _sglSlidersLookAndFeel[0].CapLookAndFeel.FillMode;

		public Color XColor => GetSglSliderLookAndFeel(0, AxisSign.Positive).Color;

		public Color YColor => GetSglSliderLookAndFeel(1, AxisSign.Positive).Color;

		public Color ZColor => GetSglSliderLookAndFeel(2, AxisSign.Positive).Color;

		public Color HoveredColor => _sglSlidersLookAndFeel[0].HoveredColor;

		public float SliderBoxCapWidth => _sglSlidersLookAndFeel[0].CapLookAndFeel.BoxWidth;

		public float SliderBoxCapHeight => _sglSlidersLookAndFeel[0].CapLookAndFeel.BoxHeight;

		public float SliderBoxCapDepth => _sglSlidersLookAndFeel[0].CapLookAndFeel.BoxDepth;

		public float SliderConeCapHeight => _sglSlidersLookAndFeel[0].CapLookAndFeel.ConeHeight;

		public float SliderConeCapBaseRadius => _sglSlidersLookAndFeel[0].CapLookAndFeel.ConeRadius;

		public float SliderPyramidCapWidth => _sglSlidersLookAndFeel[0].CapLookAndFeel.PyramidWidth;

		public float SliderPyramidCapHeight => _sglSlidersLookAndFeel[0].CapLookAndFeel.PyramidHeight;

		public float SliderPyramidCapDepth => _sglSlidersLookAndFeel[0].CapLookAndFeel.PyramidDepth;

		public float SliderTriPrismCapWidth => _sglSlidersLookAndFeel[0].CapLookAndFeel.TrPrismWidth;

		public float SliderTriPrismCapHeight => _sglSlidersLookAndFeel[0].CapLookAndFeel.TrPrismHeight;

		public float SliderTriPrismCapDepth => _sglSlidersLookAndFeel[0].CapLookAndFeel.TrPrismDepth;

		public float SliderSphereCapRadius => _sglSlidersLookAndFeel[0].CapLookAndFeel.SphereRadius;

		public ObjectExtrudeGizmoLookAndFeel3D()
		{
			for (int i = 0; i < _sglSlidersLookAndFeel.Length; i++)
			{
				_sglSlidersLookAndFeel[i] = new GizmoLineSlider3DLookAndFeel();
				_sglSlidersLookAndFeel[i].Length = 0f;
			}
			SetAxisColor(0, RTSystemValues.XAxisColor);
			SetAxisColor(1, RTSystemValues.YAxisColor);
			SetAxisColor(2, RTSystemValues.ZAxisColor);
			SetSliderCapType(GizmoCap3DType.Pyramid);
			SetExtrudeSliderVisible(0, AxisSign.Positive, isVisible: true);
			SetExtrudeSliderVisible(1, AxisSign.Positive, isVisible: true);
			SetExtrudeSliderVisible(2, AxisSign.Positive, isVisible: true);
			SetExtrudeSliderVisible(0, AxisSign.Negative, isVisible: true);
			SetExtrudeSliderVisible(1, AxisSign.Negative, isVisible: true);
			SetExtrudeSliderVisible(2, AxisSign.Negative, isVisible: true);
		}

		public bool IsExtrudeSliderVisible(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _extrudeSliderVis[axisIndex];
			}
			return _extrudeSliderVis[3 + axisIndex];
		}

		public void SetExtrudeSliderVisible(int axisIndex, AxisSign axisSign, bool isVisible)
		{
			if (axisSign == AxisSign.Positive)
			{
				_extrudeSliderVis[axisIndex] = isVisible;
			}
			else
			{
				_extrudeSliderVis[3 + axisIndex] = isVisible;
			}
		}

		public void SetBoxWireColor(Color color)
		{
			_boxWireColor = color;
		}

		public void SetSliderCapType(GizmoCap3DType capType)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].CapLookAndFeel.CapType = capType;
			}
		}

		public void SetSliderBoxCapWidth(float width)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].CapLookAndFeel.BoxWidth = width;
			}
		}

		public void SetSliderBoxCapHeight(float height)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].CapLookAndFeel.BoxHeight = height;
			}
		}

		public void SetSliderBoxCapDepth(float depth)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].CapLookAndFeel.BoxDepth = depth;
			}
		}

		public void SetSliderConeCapHeight(float height)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].CapLookAndFeel.ConeHeight = height;
			}
		}

		public void SetSliderConeCapBaseRadius(float radius)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].CapLookAndFeel.ConeRadius = radius;
			}
		}

		public void SetSliderPyramidCapWidth(float width)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].CapLookAndFeel.PyramidWidth = width;
			}
		}

		public void SetSliderPyramidCapHeight(float height)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].CapLookAndFeel.PyramidHeight = height;
			}
		}

		public void SetSliderPyramidCapDepth(float depth)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].CapLookAndFeel.PyramidDepth = depth;
			}
		}

		public void SetSliderTriPrismCapWidth(float width)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].CapLookAndFeel.TrPrismWidth = width;
			}
		}

		public void SetSliderTriPrismCapHeight(float height)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].CapLookAndFeel.TrPrismHeight = height;
			}
		}

		public void SetSliderTriPrismCapDepth(float depth)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].CapLookAndFeel.TrPrismDepth = depth;
			}
		}

		public void SetSliderSphereCapRadius(float radius)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].CapLookAndFeel.SphereRadius = radius;
			}
		}

		public void SetUseZoomFactor(bool useZoomFactor)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].CapLookAndFeel.UseZoomFactor = useZoomFactor;
			}
		}

		public void SetSliderCapShadeMode(GizmoShadeMode shadeMode)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].CapLookAndFeel.ShadeMode = shadeMode;
			}
		}

		public void SetSliderCapFillMode(GizmoFillMode3D fillMode)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].CapLookAndFeel.FillMode = fillMode;
			}
		}

		public void SetAxisColor(int axisIndex, Color color)
		{
			GetSglSliderLookAndFeel(axisIndex, AxisSign.Positive).Color = color;
			GetSglSliderLookAndFeel(axisIndex, AxisSign.Positive).CapLookAndFeel.Color = color;
			GetSglSliderLookAndFeel(axisIndex, AxisSign.Negative).Color = color;
			GetSglSliderLookAndFeel(axisIndex, AxisSign.Negative).CapLookAndFeel.Color = color;
		}

		public void SetHoveredColor(Color hoveredColor)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			foreach (GizmoLineSlider3DLookAndFeel obj in sglSlidersLookAndFeel)
			{
				obj.HoveredColor = hoveredColor;
				obj.CapLookAndFeel.HoveredColor = hoveredColor;
			}
		}

		public void ConnectSliderLookAndFeel(GizmoLineSlider3D slider, int axisIndex, AxisSign axisSign)
		{
			slider.SharedLookAndFeel = GetSglSliderLookAndFeel(axisIndex, axisSign);
		}

		private GizmoLineSlider3DLookAndFeel GetSglSliderLookAndFeel(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _sglSlidersLookAndFeel[axisIndex];
			}
			return _sglSlidersLookAndFeel[3 + axisIndex];
		}
	}
}
