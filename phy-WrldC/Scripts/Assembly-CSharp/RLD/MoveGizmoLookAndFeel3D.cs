using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class MoveGizmoLookAndFeel3D : Settings
	{
		[SerializeField]
		private bool _isMidCapVisible;

		[SerializeField]
		private GizmoCap3DLookAndFeel _midCapLookAndFeel = new GizmoCap3DLookAndFeel();

		[SerializeField]
		private GizmoCap2DLookAndFeel _vertSnapCapLookAndFeel = new GizmoCap2DLookAndFeel();

		[SerializeField]
		private bool[] _sglSliderVis = new bool[6];

		[SerializeField]
		private bool[] _sglSliderCapVis = new bool[6];

		[SerializeField]
		private bool[] _dblSliderVis = new bool[3];

		[SerializeField]
		private GizmoLineSlider3DLookAndFeel[] _sglSlidersLookAndFeel = new GizmoLineSlider3DLookAndFeel[6];

		[SerializeField]
		private GizmoPlaneSlider3DLookAndFeel[] _dblSlidersLookAndFeel = new GizmoPlaneSlider3DLookAndFeel[3];

		public float Scale => _midCapLookAndFeel.Scale;

		public bool UseZoomFactor => _midCapLookAndFeel.UseZoomFactor;

		public float SliderLength => _sglSlidersLookAndFeel[0].Length;

		public float BoxSliderHeight => _sglSlidersLookAndFeel[0].BoxHeight;

		public float BoxSliderDepth => _sglSlidersLookAndFeel[0].BoxDepth;

		public float CylinderSliderRadius => _sglSlidersLookAndFeel[0].CylinderRadius;

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

		public GizmoFillMode3D SliderFillMode => _sglSlidersLookAndFeel[0].FillMode;

		public GizmoFillMode3D SliderCapFillMode => _sglSlidersLookAndFeel[0].CapLookAndFeel.FillMode;

		public GizmoCap3DType SliderCapType => _sglSlidersLookAndFeel[0].CapLookAndFeel.CapType;

		public GizmoShadeMode SliderShadeMode => _sglSlidersLookAndFeel[0].ShadeMode;

		public GizmoShadeMode SliderCapShadeMode => _sglSlidersLookAndFeel[0].CapLookAndFeel.ShadeMode;

		public GizmoLine3DType SliderLineType => _sglSlidersLookAndFeel[0].LineType;

		public Color XColor => GetSglSliderLookAndFeel(0, AxisSign.Positive).Color;

		public Color YColor => GetSglSliderLookAndFeel(1, AxisSign.Positive).Color;

		public Color ZColor => GetSglSliderLookAndFeel(2, AxisSign.Positive).Color;

		public float DblSliderSize => _dblSlidersLookAndFeel[0].QuadWidth;

		public float DblSliderBorderBoxHeight => _dblSlidersLookAndFeel[0].BorderBoxHeight;

		public float DblSliderBorderBoxDepth => _dblSlidersLookAndFeel[0].BorderBoxDepth;

		public float DblSliderFillAlpha => _dblSlidersLookAndFeel[0].Color.a;

		public GizmoShadeMode DblSliderBorderShadeMode => _dblSlidersLookAndFeel[0].BorderShadeMode;

		public GizmoQuad3DBorderType DblSliderBorderType => _dblSlidersLookAndFeel[0].QuadBorderType;

		public GizmoFillMode3D DblSliderBorderFillMode => _dblSlidersLookAndFeel[0].BorderFillMode;

		public float VertSnapCapQuadWidth => _vertSnapCapLookAndFeel.QuadWidth;

		public float VertSnapCapQuadHeight => _vertSnapCapLookAndFeel.QuadHeight;

		public float VertSnapCapCircleRadius => _vertSnapCapLookAndFeel.CircleRadius;

		public Color VertSnapCapColor => _vertSnapCapLookAndFeel.Color;

		public Color VertSnapCapBorderColor => _vertSnapCapLookAndFeel.BorderColor;

		public Color VertSnapCapHoveredColor => _vertSnapCapLookAndFeel.HoveredColor;

		public Color VertSnapCapHoveredBorderColor => _vertSnapCapLookAndFeel.HoveredBorderColor;

		public GizmoFillMode2D VertSnapCapFillMode => _vertSnapCapLookAndFeel.FillMode;

		public GizmoCap2DType VertSnapCapType => _vertSnapCapLookAndFeel.CapType;

		public bool IsMidCapVisible
		{
			get
			{
				return _isMidCapVisible;
			}
			set
			{
				_isMidCapVisible = value;
			}
		}

		public float MidCapBoxWidth => _midCapLookAndFeel.BoxWidth;

		public float MidCapBoxHeight => _midCapLookAndFeel.BoxHeight;

		public float MidCapBoxDepth => _midCapLookAndFeel.BoxDepth;

		public float MidCapSphereRadius => _midCapLookAndFeel.SphereRadius;

		public Color MidCapColor => _midCapLookAndFeel.Color;

		public GizmoFillMode3D MidCapFillMode => _midCapLookAndFeel.FillMode;

		public GizmoShadeMode MidCapShadeMode => _midCapLookAndFeel.ShadeMode;

		public GizmoCap3DType MidCapType => _midCapLookAndFeel.CapType;

		public Color HoveredColor => _sglSlidersLookAndFeel[0].HoveredColor;

		public MoveGizmoLookAndFeel3D()
		{
			for (int i = 0; i < _sglSlidersLookAndFeel.Length; i++)
			{
				_sglSlidersLookAndFeel[i] = new GizmoLineSlider3DLookAndFeel();
			}
			for (int j = 0; j < _dblSlidersLookAndFeel.Length; j++)
			{
				_dblSlidersLookAndFeel[j] = new GizmoPlaneSlider3DLookAndFeel();
			}
			SetSliderLength(5.5f);
			SetAxisColor(0, RTSystemValues.XAxisColor);
			SetAxisColor(1, RTSystemValues.YAxisColor);
			SetAxisColor(2, RTSystemValues.ZAxisColor);
			SetHoveredColor(RTSystemValues.HoveredAxisColor);
			SetDblSliderFillAlpha(RTSystemValues.AxisAlpha);
			SetDblSliderSize(1.5f);
			SetDblSliderVisible(PlaneId.XY, isVisible: true);
			SetDblSliderVisible(PlaneId.YZ, isVisible: true);
			SetDblSliderVisible(PlaneId.ZX, isVisible: true);
			SetSliderVisible(0, AxisSign.Positive, isVisible: true);
			SetSliderCapVisible(0, AxisSign.Positive, isVisible: true);
			SetSliderVisible(1, AxisSign.Positive, isVisible: true);
			SetSliderCapVisible(1, AxisSign.Positive, isVisible: true);
			SetSliderVisible(2, AxisSign.Positive, isVisible: true);
			SetSliderCapVisible(2, AxisSign.Positive, isVisible: true);
			SetMidCapType(GizmoCap3DType.Box);
			SetMidCapSphereRadius(0.67f);
			SetMidCapColor(RTSystemValues.CenterAxisColor);
			SetVertSnapCapFillMode(GizmoFillMode2D.Border);
			SetVertSnapCapColor(Color.white.KeepAllButAlpha(RTSystemValues.AxisAlpha));
			SetVertSnapCapBorderColor(Color.white);
			SetVertSnapCapHoveredColor(RTSystemValues.HoveredAxisColor.KeepAllButAlpha(RTSystemValues.AxisAlpha));
			SetVertSnapCapHoveredBorderColor(RTSystemValues.HoveredAxisColor);
		}

		public bool IsVertSnapCapTypeAllowed(GizmoCap2DType capType)
		{
			if (capType != GizmoCap2DType.Circle)
			{
				return capType == GizmoCap2DType.Quad;
			}
			return true;
		}

		public List<Enum> GetAllowedVertSnapCapTypes()
		{
			return new List<Enum>
			{
				GizmoCap2DType.Circle,
				GizmoCap2DType.Quad
			};
		}

		public void SetVertSnapCapType(GizmoCap2DType capType)
		{
			if (IsVertSnapCapTypeAllowed(capType))
			{
				_vertSnapCapLookAndFeel.CapType = capType;
			}
		}

		public void SetVertSnapCapQuadWidth(float width)
		{
			_vertSnapCapLookAndFeel.QuadWidth = width;
		}

		public void SetVertSnapCapQuadHeight(float height)
		{
			_vertSnapCapLookAndFeel.QuadHeight = height;
		}

		public void SetVertSnapCapCircleRadius(float radius)
		{
			_vertSnapCapLookAndFeel.CircleRadius = radius;
		}

		public void SetVertSnapCapFillMode(GizmoFillMode2D fillMode)
		{
			_vertSnapCapLookAndFeel.FillMode = fillMode;
		}

		public void SetVertSnapCapColor(Color color)
		{
			_vertSnapCapLookAndFeel.Color = color;
		}

		public void SetVertSnapCapBorderColor(Color color)
		{
			_vertSnapCapLookAndFeel.BorderColor = color;
		}

		public void SetVertSnapCapHoveredColor(Color color)
		{
			_vertSnapCapLookAndFeel.HoveredColor = color;
		}

		public void SetVertSnapCapHoveredBorderColor(Color color)
		{
			_vertSnapCapLookAndFeel.HoveredBorderColor = color;
		}

		public bool IsMidCapTypeAllowed(GizmoCap3DType capType)
		{
			if (capType != GizmoCap3DType.Box)
			{
				return capType == GizmoCap3DType.Sphere;
			}
			return true;
		}

		public List<Enum> GetAllowedMidCapTypes()
		{
			return new List<Enum>
			{
				GizmoCap3DType.Box,
				GizmoCap3DType.Sphere
			};
		}

		public void SetMidCapType(GizmoCap3DType capType)
		{
			if (IsMidCapTypeAllowed(capType))
			{
				_midCapLookAndFeel.CapType = capType;
			}
		}

		public void SetMidCapBoxWidth(float width)
		{
			_midCapLookAndFeel.BoxWidth = width;
		}

		public void SetMidCapBoxHeight(float height)
		{
			_midCapLookAndFeel.BoxHeight = height;
		}

		public void SetMidCapBoxDepth(float depth)
		{
			_midCapLookAndFeel.BoxDepth = depth;
		}

		public void SetMidCapSphereRadius(float radius)
		{
			_midCapLookAndFeel.SphereRadius = radius;
		}

		public void SetMidCapColor(Color color)
		{
			_midCapLookAndFeel.Color = color;
		}

		public bool IsSliderVisible(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _sglSliderVis[axisIndex];
			}
			return _sglSliderVis[3 + axisIndex];
		}

		public bool IsDblSliderVisible(PlaneId planeId)
		{
			return _dblSliderVis[(int)planeId];
		}

		public bool IsSliderCapVisible(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _sglSliderCapVis[axisIndex];
			}
			return _sglSliderCapVis[3 + axisIndex];
		}

		public bool IsPositiveSliderVisible(int axisIndex)
		{
			return _sglSliderVis[axisIndex];
		}

		public bool IsPositiveSliderCapVisible(int axisIndex)
		{
			return _sglSliderCapVis[axisIndex];
		}

		public bool IsNegativeSliderVisible(int axisIndex)
		{
			return _sglSliderVis[3 + axisIndex];
		}

		public bool IsNegativeSliderCapVisible(int axisIndex)
		{
			return _sglSliderCapVis[3 + axisIndex];
		}

		public void SetSliderVisible(int axisIndex, AxisSign axisSign, bool isVisible)
		{
			if (axisSign == AxisSign.Positive)
			{
				_sglSliderVis[axisIndex] = isVisible;
			}
			else
			{
				_sglSliderVis[3 + axisIndex] = isVisible;
			}
		}

		public void SetDblSliderVisible(PlaneId planeId, bool isVisible)
		{
			_dblSliderVis[(int)planeId] = isVisible;
		}

		public void SetSliderCapVisible(int axisIndex, AxisSign axisSign, bool isVisible)
		{
			if (axisSign == AxisSign.Positive)
			{
				_sglSliderCapVis[axisIndex] = isVisible;
			}
			else
			{
				_sglSliderCapVis[3 + axisIndex] = isVisible;
			}
		}

		public void SetPositiveSliderVisible(int axisIndex, bool isVisible)
		{
			_sglSliderVis[axisIndex] = isVisible;
		}

		public void SetPositiveCapVisible(int axisIndex, bool isVisible)
		{
			_sglSliderCapVis[axisIndex] = isVisible;
		}

		public void SetNegativeSliderVisible(int axisIndex, bool isVisible)
		{
			_sglSliderVis[3 + axisIndex] = isVisible;
		}

		public void SetNegativeCapVisible(int axisIndex, bool isVisible)
		{
			_sglSliderCapVis[3 + axisIndex] = isVisible;
		}

		public void SetSliderLength(float axisLength)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].Length = axisLength;
			}
		}

		public void SetSliderLineType(GizmoLine3DType lineType)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].LineType = lineType;
			}
		}

		public void SetDblSliderBorderType(GizmoQuad3DBorderType borderType)
		{
			GizmoPlaneSlider3DLookAndFeel[] dblSlidersLookAndFeel = _dblSlidersLookAndFeel;
			for (int i = 0; i < dblSlidersLookAndFeel.Length; i++)
			{
				dblSlidersLookAndFeel[i].QuadBorderType = borderType;
			}
		}

		public void SetDblSliderBorderBoxHeight(float height)
		{
			GizmoPlaneSlider3DLookAndFeel[] dblSlidersLookAndFeel = _dblSlidersLookAndFeel;
			for (int i = 0; i < dblSlidersLookAndFeel.Length; i++)
			{
				dblSlidersLookAndFeel[i].BorderBoxHeight = height;
			}
		}

		public void SetDblSliderBorderBoxDepth(float depth)
		{
			GizmoPlaneSlider3DLookAndFeel[] dblSlidersLookAndFeel = _dblSlidersLookAndFeel;
			for (int i = 0; i < dblSlidersLookAndFeel.Length; i++)
			{
				dblSlidersLookAndFeel[i].BorderBoxDepth = depth;
			}
		}

		public void SetBoxSliderHeight(float height)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].BoxHeight = height;
			}
		}

		public void SetBoxSliderDepth(float depth)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].BoxDepth = depth;
			}
		}

		public void SetCylinderSliderRadius(float radius)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].CylinderRadius = radius;
			}
		}

		public void SetDblSliderSize(float size)
		{
			GizmoPlaneSlider3DLookAndFeel[] dblSlidersLookAndFeel = _dblSlidersLookAndFeel;
			foreach (GizmoPlaneSlider3DLookAndFeel obj in dblSlidersLookAndFeel)
			{
				obj.QuadWidth = size;
				obj.QuadHeight = size;
			}
		}

		public void SetScale(float scale)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			foreach (GizmoLineSlider3DLookAndFeel obj in sglSlidersLookAndFeel)
			{
				obj.Scale = scale;
				obj.CapLookAndFeel.Scale = scale;
			}
			GizmoPlaneSlider3DLookAndFeel[] dblSlidersLookAndFeel = _dblSlidersLookAndFeel;
			for (int i = 0; i < dblSlidersLookAndFeel.Length; i++)
			{
				dblSlidersLookAndFeel[i].Scale = scale;
			}
			_midCapLookAndFeel.Scale = scale;
		}

		public void SetUseZoomFactor(bool useZoomFactor)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			foreach (GizmoLineSlider3DLookAndFeel obj in sglSlidersLookAndFeel)
			{
				obj.UseZoomFactor = useZoomFactor;
				obj.CapLookAndFeel.UseZoomFactor = useZoomFactor;
			}
			GizmoPlaneSlider3DLookAndFeel[] dblSlidersLookAndFeel = _dblSlidersLookAndFeel;
			for (int i = 0; i < dblSlidersLookAndFeel.Length; i++)
			{
				dblSlidersLookAndFeel[i].UseZoomFactor = useZoomFactor;
			}
			_midCapLookAndFeel.UseZoomFactor = useZoomFactor;
		}

		public void SetAxisColor(int axisIndex, Color color)
		{
			GetSglSliderLookAndFeel(axisIndex, AxisSign.Positive).Color = color;
			GetSglSliderLookAndFeel(axisIndex, AxisSign.Positive).CapLookAndFeel.Color = color;
			GetSglSliderLookAndFeel(axisIndex, AxisSign.Negative).Color = color;
			GetSglSliderLookAndFeel(axisIndex, AxisSign.Negative).CapLookAndFeel.Color = color;
			GizmoPlaneSlider3DLookAndFeel gizmoPlaneSlider3DLookAndFeel = null;
			switch (axisIndex)
			{
			case 0:
				gizmoPlaneSlider3DLookAndFeel = GetDblSliderLookAndFeel(PlaneId.YZ);
				break;
			case 1:
				gizmoPlaneSlider3DLookAndFeel = GetDblSliderLookAndFeel(PlaneId.ZX);
				break;
			case 2:
				gizmoPlaneSlider3DLookAndFeel = GetDblSliderLookAndFeel(PlaneId.XY);
				break;
			}
			gizmoPlaneSlider3DLookAndFeel.Color = color.KeepAllButAlpha(gizmoPlaneSlider3DLookAndFeel.Color.a);
			gizmoPlaneSlider3DLookAndFeel.BorderColor = color;
		}

		public void SetDblSliderFillAlpha(float alpha)
		{
			alpha = Mathf.Clamp(alpha, 0f, 1f);
			GizmoPlaneSlider3DLookAndFeel[] dblSlidersLookAndFeel = _dblSlidersLookAndFeel;
			foreach (GizmoPlaneSlider3DLookAndFeel obj in dblSlidersLookAndFeel)
			{
				obj.Color = obj.Color.KeepAllButAlpha(alpha);
				obj.HoveredColor = obj.HoveredColor.KeepAllButAlpha(alpha);
			}
		}

		public void SetHoveredColor(Color hoveredColor)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			foreach (GizmoLineSlider3DLookAndFeel obj in sglSlidersLookAndFeel)
			{
				obj.HoveredColor = hoveredColor;
				obj.CapLookAndFeel.HoveredColor = hoveredColor;
			}
			GizmoPlaneSlider3DLookAndFeel[] dblSlidersLookAndFeel = _dblSlidersLookAndFeel;
			foreach (GizmoPlaneSlider3DLookAndFeel gizmoPlaneSlider3DLookAndFeel in dblSlidersLookAndFeel)
			{
				gizmoPlaneSlider3DLookAndFeel.HoveredBorderColor = hoveredColor;
				gizmoPlaneSlider3DLookAndFeel.HoveredColor = hoveredColor.KeepAllButAlpha(gizmoPlaneSlider3DLookAndFeel.Color.a);
			}
		}

		public void SetSliderShadeMode(GizmoShadeMode shadeMode)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].ShadeMode = shadeMode;
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

		public void SetMidCapShadeMode(GizmoShadeMode shadeMode)
		{
			_midCapLookAndFeel.ShadeMode = shadeMode;
		}

		public void SetDblSliderBorderShadeMode(GizmoShadeMode shadeMode)
		{
			GizmoPlaneSlider3DLookAndFeel[] dblSlidersLookAndFeel = _dblSlidersLookAndFeel;
			for (int i = 0; i < dblSlidersLookAndFeel.Length; i++)
			{
				dblSlidersLookAndFeel[i].BorderShadeMode = shadeMode;
			}
		}

		public void SetSliderCapType(GizmoCap3DType capType)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].CapLookAndFeel.CapType = capType;
			}
		}

		public void SetSliderFillMode(GizmoFillMode3D fillMode)
		{
			GizmoLineSlider3DLookAndFeel[] sglSlidersLookAndFeel = _sglSlidersLookAndFeel;
			for (int i = 0; i < sglSlidersLookAndFeel.Length; i++)
			{
				sglSlidersLookAndFeel[i].FillMode = fillMode;
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

		public void SetMidCapFillMode(GizmoFillMode3D fillMode)
		{
			_midCapLookAndFeel.FillMode = fillMode;
		}

		public void SetDblSliderBorderFillMode(GizmoFillMode3D fillMode)
		{
			GizmoPlaneSlider3DLookAndFeel[] dblSlidersLookAndFeel = _dblSlidersLookAndFeel;
			for (int i = 0; i < dblSlidersLookAndFeel.Length; i++)
			{
				dblSlidersLookAndFeel[i].BorderFillMode = fillMode;
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

		public void ConnectSliderLookAndFeel(GizmoLineSlider3D slider, int axisIndex, AxisSign axisSign)
		{
			slider.SharedLookAndFeel = GetSglSliderLookAndFeel(axisIndex, axisSign);
		}

		public void ConnectDblSliderLookAndFeel(GizmoPlaneSlider3D dblSlider, PlaneId planeId)
		{
			dblSlider.SharedLookAndFeel = GetDblSliderLookAndFeel(planeId);
		}

		public void ConnectMidCapLookAndFeel(GizmoCap3D midCap)
		{
			midCap.SharedLookAndFeel = _midCapLookAndFeel;
		}

		public void ConnectVertSnapCapLookAndFeel(GizmoCap2D vertSnapCap)
		{
			vertSnapCap.SharedLookAndFeel = _vertSnapCapLookAndFeel;
		}

		private GizmoLineSlider3DLookAndFeel GetSglSliderLookAndFeel(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _sglSlidersLookAndFeel[axisIndex];
			}
			return _sglSlidersLookAndFeel[3 + axisIndex];
		}

		private GizmoPlaneSlider3DLookAndFeel GetDblSliderLookAndFeel(PlaneId planeId)
		{
			return _dblSlidersLookAndFeel[(int)planeId];
		}
	}
}
