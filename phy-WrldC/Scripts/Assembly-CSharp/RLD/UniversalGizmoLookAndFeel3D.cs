using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class UniversalGizmoLookAndFeel3D : Settings
	{
		[SerializeField]
		private UniversalGizmoSettingsCategory _displayCategory;

		[SerializeField]
		private GizmoCap2DLookAndFeel _mvVertSnapCapLookAndFeel = new GizmoCap2DLookAndFeel();

		[SerializeField]
		private bool[] _mvSglSliderVis = new bool[6];

		[SerializeField]
		private bool[] _mvSglSliderCapVis = new bool[6];

		[SerializeField]
		private bool[] _mvDblSliderVis = new bool[3];

		[SerializeField]
		private GizmoLineSlider3DLookAndFeel[] _mvSglSlidersLookAndFeel = new GizmoLineSlider3DLookAndFeel[6];

		[SerializeField]
		private GizmoPlaneSlider3DLookAndFeel[] _mvDblSlidersLookAndFeel = new GizmoPlaneSlider3DLookAndFeel[3];

		[SerializeField]
		private bool _isRtMidCapVisible = true;

		[SerializeField]
		private GizmoCap3DLookAndFeel _rtMidCapLookAndFeel = new GizmoCap3DLookAndFeel();

		[SerializeField]
		private bool[] _rtAxesVis = new bool[3];

		[SerializeField]
		private GizmoPlaneSlider3DLookAndFeel[] _rtAxesLookAndFeel = new GizmoPlaneSlider3DLookAndFeel[3];

		[SerializeField]
		private bool _isRtCamLookSliderVisible = true;

		[SerializeField]
		private float _rtCamLookSliderRadiusOffset = 0.65f;

		[SerializeField]
		private GizmoPlaneSlider2DLookAndFeel _rtCamLookSliderLookAndFeel = new GizmoPlaneSlider2DLookAndFeel();

		[SerializeField]
		private GizmoCap3DLookAndFeel _scMidCapLookAndFeel = new GizmoCap3DLookAndFeel();

		[SerializeField]
		private bool[] _scSglSliderVis = new bool[6];

		[SerializeField]
		private bool[] _scSglSliderCapVis = new bool[6];

		[SerializeField]
		private bool[] _scDblSliderVis = new bool[3];

		[SerializeField]
		private bool _isScMidCapVisible = true;

		[SerializeField]
		private GizmoScaleGuideLookAndFeel _scScaleGuideLookAndFeel = new GizmoScaleGuideLookAndFeel();

		[SerializeField]
		private bool _isScScaleGuideVisible = true;

		[SerializeField]
		private GizmoLineSlider3DLookAndFeel[] _scSglSlidersLookAndFeel = new GizmoLineSlider3DLookAndFeel[6];

		[SerializeField]
		private GizmoPlaneSlider3DLookAndFeel[] _scDblSlidersLookAndFeel = new GizmoPlaneSlider3DLookAndFeel[3];

		public float MvScale => _mvSglSlidersLookAndFeel[0].Scale;

		public bool MvUseZoomFactor => _mvSglSlidersLookAndFeel[0].UseZoomFactor;

		public float MvSliderLength => _mvSglSlidersLookAndFeel[0].Length;

		public float MvBoxSliderHeight => _mvSglSlidersLookAndFeel[0].BoxHeight;

		public float MvBoxSliderDepth => _mvSglSlidersLookAndFeel[0].BoxDepth;

		public float MvCylinderSliderRadius => _mvSglSlidersLookAndFeel[0].CylinderRadius;

		public float MvSliderBoxCapWidth => _mvSglSlidersLookAndFeel[0].CapLookAndFeel.BoxWidth;

		public float MvSliderBoxCapHeight => _mvSglSlidersLookAndFeel[0].CapLookAndFeel.BoxHeight;

		public float MvSliderBoxCapDepth => _mvSglSlidersLookAndFeel[0].CapLookAndFeel.BoxDepth;

		public float MvSliderConeCapHeight => _mvSglSlidersLookAndFeel[0].CapLookAndFeel.ConeHeight;

		public float MvSliderConeCapBaseRadius => _mvSglSlidersLookAndFeel[0].CapLookAndFeel.ConeRadius;

		public float MvSliderPyramidCapWidth => _mvSglSlidersLookAndFeel[0].CapLookAndFeel.PyramidWidth;

		public float MvSliderPyramidCapHeight => _mvSglSlidersLookAndFeel[0].CapLookAndFeel.PyramidHeight;

		public float MvSliderPyramidCapDepth => _mvSglSlidersLookAndFeel[0].CapLookAndFeel.PyramidDepth;

		public float MvSliderTriPrismCapWidth => _mvSglSlidersLookAndFeel[0].CapLookAndFeel.TrPrismWidth;

		public float MvSliderTriPrismCapHeight => _mvSglSlidersLookAndFeel[0].CapLookAndFeel.TrPrismHeight;

		public float MvSliderTriPrismCapDepth => _mvSglSlidersLookAndFeel[0].CapLookAndFeel.TrPrismDepth;

		public float MvSliderSphereCapRadius => _mvSglSlidersLookAndFeel[0].CapLookAndFeel.SphereRadius;

		public GizmoFillMode3D MvSliderFillMode => _mvSglSlidersLookAndFeel[0].FillMode;

		public GizmoFillMode3D MvSliderCapFillMode => _mvSglSlidersLookAndFeel[0].CapLookAndFeel.FillMode;

		public GizmoCap3DType MvSliderCapType => _mvSglSlidersLookAndFeel[0].CapLookAndFeel.CapType;

		public GizmoShadeMode MvSliderShadeMode => _mvSglSlidersLookAndFeel[0].ShadeMode;

		public GizmoShadeMode MvSliderCapShadeMode => _mvSglSlidersLookAndFeel[0].CapLookAndFeel.ShadeMode;

		public GizmoLine3DType MvSliderLineType => _mvSglSlidersLookAndFeel[0].LineType;

		public Color MvPXColor => GetMvSglSliderLookAndFeel(0, AxisSign.Positive).Color;

		public Color MvNXColor => GetMvSglSliderLookAndFeel(0, AxisSign.Negative).Color;

		public Color MvPYColor => GetMvSglSliderLookAndFeel(1, AxisSign.Positive).Color;

		public Color MvNYColor => GetMvSglSliderLookAndFeel(1, AxisSign.Negative).Color;

		public Color MvPZColor => GetMvSglSliderLookAndFeel(2, AxisSign.Positive).Color;

		public Color MvNZColor => GetMvSglSliderLookAndFeel(2, AxisSign.Negative).Color;

		public float MvDblSliderSize => _mvDblSlidersLookAndFeel[0].QuadWidth;

		public float MvDblSliderBorderBoxHeight => _mvDblSlidersLookAndFeel[0].BorderBoxHeight;

		public float MvDblSliderBorderBoxDepth => _mvDblSlidersLookAndFeel[0].BorderBoxDepth;

		public float MvDblSliderFillAlpha => _mvDblSlidersLookAndFeel[0].Color.a;

		public GizmoShadeMode MvDblSliderBorderShadeMode => _mvDblSlidersLookAndFeel[0].BorderShadeMode;

		public GizmoQuad3DBorderType MvDblSliderBorderType => _mvDblSlidersLookAndFeel[0].QuadBorderType;

		public GizmoFillMode3D MvDblSliderBorderFillMode => _mvDblSlidersLookAndFeel[0].BorderFillMode;

		public float MvVertSnapCapQuadWidth => _mvVertSnapCapLookAndFeel.QuadWidth;

		public float MvVertSnapCapQuadHeight => _mvVertSnapCapLookAndFeel.QuadHeight;

		public float MvVertSnapCapCircleRadius => _mvVertSnapCapLookAndFeel.CircleRadius;

		public Color MvVertSnapCapColor => _mvVertSnapCapLookAndFeel.Color;

		public Color MvVertSnapCapBorderColor => _mvVertSnapCapLookAndFeel.BorderColor;

		public Color MvVertSnapCapHoveredColor => _mvVertSnapCapLookAndFeel.HoveredColor;

		public Color MvVertSnapCapHoveredBorderColor => _mvVertSnapCapLookAndFeel.HoveredBorderColor;

		public GizmoFillMode2D MvVertSnapCapFillMode => _mvVertSnapCapLookAndFeel.FillMode;

		public GizmoCap2DType MvVertSnapCapType => _mvVertSnapCapLookAndFeel.CapType;

		public Color MvHoveredColor => _mvSglSlidersLookAndFeel[0].HoveredColor;

		public float RtScale => _rtMidCapLookAndFeel.Scale;

		public float RtRadius => _rtMidCapLookAndFeel.SphereRadius;

		public bool RtUseZoomFactor => _rtMidCapLookAndFeel.UseZoomFactor;

		public Color RtXBorderColor => _rtAxesLookAndFeel[0].BorderColor;

		public Color RtYBorderColor => _rtAxesLookAndFeel[1].BorderColor;

		public Color RtZBorderColor => _rtAxesLookAndFeel[2].BorderColor;

		public Color RtHoveredColor => _rtAxesLookAndFeel[0].HoveredColor;

		public float RtAxisTorusThickness => _rtAxesLookAndFeel[0].BorderTorusThickness;

		public float RtAxisCylTorusWidth => _rtAxesLookAndFeel[0].BorderCylTorusWidth;

		public float RtAxisCylTorusHeight => _rtAxesLookAndFeel[0].BorderCylTorusHeight;

		public float RtAxisCullAlphaScale => _rtAxesLookAndFeel[0].BorderCircleCullAlphaScale;

		public GizmoShadeMode RtShadeMode => _rtMidCapLookAndFeel.ShadeMode;

		public GizmoCircle3DBorderType RtAxisBorderType => _rtAxesLookAndFeel[0].CircleBorderType;

		public GizmoFillMode3D RtAxisBorderFillMode => _rtAxesLookAndFeel[0].BorderFillMode;

		public int RtNumAxisTorusWireAxialSlices => _rtAxesLookAndFeel[0].NumBorderTorusWireAxialSlices;

		public Color RtRotationArcColor => _rtAxesLookAndFeel[0].RotationArcLookAndFeel.Color;

		public Color RtRotationArcBorderColor => _rtAxesLookAndFeel[0].RotationArcLookAndFeel.BorderColor;

		public bool RtUseShortestRotationArc => _rtAxesLookAndFeel[0].RotationArcLookAndFeel.UseShortestRotation;

		public bool IsRtRotationArcVisible => _rtAxesLookAndFeel[0].IsRotationArcVisible;

		public Color RtMidCapColor => _rtMidCapLookAndFeel.Color;

		public Color RtHoveredMidCapColor => _rtMidCapLookAndFeel.HoveredColor;

		public bool IsRtMidCapVisible => _isRtMidCapVisible;

		public bool IsRtMidCapBorderVisible => _rtMidCapLookAndFeel.IsSphereBorderVisible;

		public float RtCamLookSliderRadiusOffset => _rtCamLookSliderRadiusOffset;

		public Color RtCamLookSliderBorderColor => _rtCamLookSliderLookAndFeel.BorderColor;

		public Color RtCamLookSliderHoveredBorderColor => _rtCamLookSliderLookAndFeel.HoveredBorderColor;

		public GizmoPolygon2DBorderType RtCamLookSliderPolyBorderType => _rtCamLookSliderLookAndFeel.PolygonBorderType;

		public float RtCamLookSliderPolyBorderThickness => _rtCamLookSliderLookAndFeel.BorderPolyThickness;

		public bool IsRtCamLookSliderVisible => _isRtCamLookSliderVisible;

		public float ScScale => _scMidCapLookAndFeel.Scale;

		public bool ScUseZoomFactor => _scMidCapLookAndFeel.UseZoomFactor;

		public float ScSliderLength => _scSglSlidersLookAndFeel[0].Length;

		public float ScBoxSliderHeight => _scSglSlidersLookAndFeel[0].BoxHeight;

		public float ScBoxSliderDepth => _scSglSlidersLookAndFeel[0].BoxDepth;

		public float ScCylinderSliderRadius => _scSglSlidersLookAndFeel[0].CylinderRadius;

		public float ScSliderBoxCapWidth => _scSglSlidersLookAndFeel[0].CapLookAndFeel.BoxWidth;

		public float ScSliderBoxCapHeight => _scSglSlidersLookAndFeel[0].CapLookAndFeel.BoxHeight;

		public float ScSliderBoxCapDepth => _scSglSlidersLookAndFeel[0].CapLookAndFeel.BoxDepth;

		public float ScSliderConeCapHeight => _scSglSlidersLookAndFeel[0].CapLookAndFeel.ConeHeight;

		public float ScSliderConeCapBaseRadius => _scSglSlidersLookAndFeel[0].CapLookAndFeel.ConeRadius;

		public float ScSliderPyramidCapWidth => _scSglSlidersLookAndFeel[0].CapLookAndFeel.PyramidWidth;

		public float ScSliderPyramidCapHeight => _scSglSlidersLookAndFeel[0].CapLookAndFeel.PyramidHeight;

		public float ScSliderPyramidCapDepth => _scSglSlidersLookAndFeel[0].CapLookAndFeel.PyramidDepth;

		public float ScSliderTriPrismCapWidth => _scSglSlidersLookAndFeel[0].CapLookAndFeel.TrPrismWidth;

		public float ScSliderTriPrismCapHeight => _scSglSlidersLookAndFeel[0].CapLookAndFeel.TrPrismHeight;

		public float ScSliderTriPrismCapDepth => _scSglSlidersLookAndFeel[0].CapLookAndFeel.TrPrismDepth;

		public float ScSliderSphereCapRadius => _scSglSlidersLookAndFeel[0].CapLookAndFeel.SphereRadius;

		public GizmoFillMode3D ScSliderFillMode => _scSglSlidersLookAndFeel[0].FillMode;

		public GizmoFillMode3D ScSliderCapFillMode => _scSglSlidersLookAndFeel[0].CapLookAndFeel.FillMode;

		public GizmoCap3DType ScSliderCapType => _scSglSlidersLookAndFeel[0].CapLookAndFeel.CapType;

		public GizmoShadeMode ScSliderShadeMode => _scSglSlidersLookAndFeel[0].ShadeMode;

		public GizmoShadeMode ScSliderCapShadeMode => _scSglSlidersLookAndFeel[0].CapLookAndFeel.ShadeMode;

		public GizmoLine3DType ScSliderLineType => _scSglSlidersLookAndFeel[0].LineType;

		public Color ScPXColor => GetScSglSliderLookAndFeel(0, AxisSign.Positive).Color;

		public Color ScNXColor => GetScSglSliderLookAndFeel(0, AxisSign.Negative).Color;

		public Color ScPYColor => GetScSglSliderLookAndFeel(1, AxisSign.Positive).Color;

		public Color ScNYColor => GetScSglSliderLookAndFeel(1, AxisSign.Negative).Color;

		public Color ScPZColor => GetScSglSliderLookAndFeel(2, AxisSign.Positive).Color;

		public Color ScNZColor => GetScSglSliderLookAndFeel(2, AxisSign.Negative).Color;

		public float ScDblSliderSize => _scDblSlidersLookAndFeel[0].RATriangleXLength;

		public float ScDblSliderFillAlpha => _scDblSlidersLookAndFeel[0].Color.a;

		public float ScMidCapBoxWidth => _scMidCapLookAndFeel.BoxWidth;

		public float ScMidCapBoxHeight => _scMidCapLookAndFeel.BoxHeight;

		public float ScMidCapBoxDepth => _scMidCapLookAndFeel.BoxDepth;

		public float ScMidCapSphereRadius => _scMidCapLookAndFeel.SphereRadius;

		public GizmoCap3DType ScMidCapType => _scMidCapLookAndFeel.CapType;

		public GizmoShadeMode ScMidCapShadeMode => _scMidCapLookAndFeel.ShadeMode;

		public GizmoFillMode3D ScMidCapFillMode => _scMidCapLookAndFeel.FillMode;

		public bool IsScMidCapVisible => _isScMidCapVisible;

		public Color ScMidCapColor => _scMidCapLookAndFeel.Color;

		public Color ScHoveredColor => _scSglSlidersLookAndFeel[0].HoveredColor;

		public bool IsScScaleGuideVisible => _isScScaleGuideVisible;

		public float ScScaleGuideAxisLength => _scScaleGuideLookAndFeel.AxisLength;

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

		public UniversalGizmoLookAndFeel3D()
		{
			for (int i = 0; i < _mvSglSlidersLookAndFeel.Length; i++)
			{
				_mvSglSlidersLookAndFeel[i] = new GizmoLineSlider3DLookAndFeel();
			}
			for (int j = 0; j < _mvDblSlidersLookAndFeel.Length; j++)
			{
				_mvDblSlidersLookAndFeel[j] = new GizmoPlaneSlider3DLookAndFeel();
			}
			SetMvSliderLength(5.5f);
			SetMvAxisColor(0, RTSystemValues.XAxisColor);
			SetMvAxisColor(1, RTSystemValues.YAxisColor);
			SetMvAxisColor(2, RTSystemValues.ZAxisColor);
			SetMvHoveredColor(RTSystemValues.HoveredAxisColor);
			SetMvDblSliderFillAlpha(RTSystemValues.AxisAlpha);
			SetMvDblSliderSize(1.5f);
			SetMvDblSliderVisible(PlaneId.XY, isVisible: true);
			SetMvDblSliderVisible(PlaneId.YZ, isVisible: true);
			SetMvDblSliderVisible(PlaneId.ZX, isVisible: true);
			SetMvSliderVisible(0, AxisSign.Positive, isVisible: true);
			SetMvSliderCapVisible(0, AxisSign.Positive, isVisible: true);
			SetMvSliderVisible(1, AxisSign.Positive, isVisible: true);
			SetMvSliderCapVisible(1, AxisSign.Positive, isVisible: true);
			SetMvSliderVisible(2, AxisSign.Positive, isVisible: true);
			SetMvSliderCapVisible(2, AxisSign.Positive, isVisible: true);
			SetMvVertSnapCapFillMode(GizmoFillMode2D.Border);
			SetMvVertSnapCapColor(Color.white.KeepAllButAlpha(RTSystemValues.AxisAlpha));
			SetMvVertSnapCapBorderColor(Color.white);
			SetMvVertSnapCapHoveredColor(RTSystemValues.HoveredAxisColor.KeepAllButAlpha(RTSystemValues.AxisAlpha));
			SetMvVertSnapCapHoveredBorderColor(RTSystemValues.HoveredAxisColor);
			for (int k = 0; k < _rtAxesLookAndFeel.Length; k++)
			{
				_rtAxesLookAndFeel[k] = new GizmoPlaneSlider3DLookAndFeel();
				_rtAxesLookAndFeel[k].PlaneType = GizmoPlane3DType.Circle;
			}
			SetRtAxisVisible(0, isVisible: true);
			SetRtAxisVisible(1, isVisible: true);
			SetRtAxisVisible(2, isVisible: true);
			_rtMidCapLookAndFeel.CapType = GizmoCap3DType.Sphere;
			_rtCamLookSliderLookAndFeel.PlaneType = GizmoPlane2DType.Polygon;
			Color color = new Color(0.3f, 0.3f, 0.3f, 0.12f);
			SetRtMidCapColor(color);
			SetRtHoveredMidCapColor(color);
			SetRtMidCapBorderVisible(isVisible: true);
			SetRtMidCapBorderColor(Color.white);
			SetRtRadius(6.5f);
			SetRtAxisBorderColor(0, RTSystemValues.XAxisColor);
			SetRtAxisBorderColor(1, RTSystemValues.YAxisColor);
			SetRtAxisBorderColor(2, RTSystemValues.ZAxisColor);
			SetRtHoveredColor(RTSystemValues.HoveredAxisColor);
			SetRtCamLookSliderPolyBorderThickness(4f);
			SetRtCamLookSliderBorderColor(Color.white);
			SetRtCamLookSliderHoveredBorderColor(RTSystemValues.HoveredAxisColor);
			SetRtNumAxisTorusWireAxialSlices(2);
			for (int l = 0; l < _scSglSlidersLookAndFeel.Length; l++)
			{
				_scSglSlidersLookAndFeel[l] = new GizmoLineSlider3DLookAndFeel();
			}
			for (int m = 0; m < _scDblSlidersLookAndFeel.Length; m++)
			{
				_scDblSlidersLookAndFeel[m] = new GizmoPlaneSlider3DLookAndFeel();
				_scDblSlidersLookAndFeel[m].PlaneType = GizmoPlane3DType.RATriangle;
			}
			SetScSliderCapType(GizmoCap3DType.Box);
			SetScSliderLength(5.5f);
			SetScAxisColor(0, RTSystemValues.XAxisColor);
			SetScAxisColor(1, RTSystemValues.YAxisColor);
			SetScAxisColor(2, RTSystemValues.ZAxisColor);
			SetScHoveredColor(RTSystemValues.HoveredAxisColor);
			SetScSliderVisible(0, AxisSign.Positive, isVisible: true);
			SetScSliderCapVisible(0, AxisSign.Positive, isVisible: true);
			SetScSliderVisible(1, AxisSign.Positive, isVisible: true);
			SetScSliderCapVisible(1, AxisSign.Positive, isVisible: true);
			SetScSliderVisible(2, AxisSign.Positive, isVisible: true);
			SetScSliderCapVisible(2, AxisSign.Positive, isVisible: true);
			SetScMidCapColor(RTSystemValues.CenterAxisColor);
			SetScMidCapType(GizmoCap3DType.Box);
			SetScMidCapBoxWidth(0.9f);
			SetScMidCapBoxHeight(0.9f);
			SetScMidCapBoxDepth(0.9f);
			SetScMidCapSphereRadius(0.65f);
			SetScDblSliderFillAlpha(RTSystemValues.AxisAlpha);
			SetScDblSliderSize(1.9f);
			SetScDblSliderVisible(PlaneId.XY, isVisible: true);
			SetScDblSliderVisible(PlaneId.YZ, isVisible: true);
			SetScDblSliderVisible(PlaneId.ZX, isVisible: true);
		}

		public bool IsMvVertSnapCapTypeAllowed(GizmoCap2DType capType)
		{
			if (capType != GizmoCap2DType.Circle)
			{
				return capType == GizmoCap2DType.Quad;
			}
			return true;
		}

		public List<Enum> GetAllowedMvVertSnapCapTypes()
		{
			return new List<Enum>
			{
				GizmoCap2DType.Circle,
				GizmoCap2DType.Quad
			};
		}

		public void SetMvVertSnapCapType(GizmoCap2DType capType)
		{
			if (IsMvVertSnapCapTypeAllowed(capType))
			{
				_mvVertSnapCapLookAndFeel.CapType = capType;
			}
		}

		public void SetMvVertSnapCapQuadWidth(float width)
		{
			_mvVertSnapCapLookAndFeel.QuadWidth = width;
		}

		public void SetMvVertSnapCapQuadHeight(float height)
		{
			_mvVertSnapCapLookAndFeel.QuadHeight = height;
		}

		public void SetMvVertSnapCapCircleRadius(float radius)
		{
			_mvVertSnapCapLookAndFeel.CircleRadius = radius;
		}

		public void SetMvVertSnapCapFillMode(GizmoFillMode2D fillMode)
		{
			_mvVertSnapCapLookAndFeel.FillMode = fillMode;
		}

		public void SetMvVertSnapCapColor(Color color)
		{
			_mvVertSnapCapLookAndFeel.Color = color;
		}

		public void SetMvVertSnapCapBorderColor(Color color)
		{
			_mvVertSnapCapLookAndFeel.BorderColor = color;
		}

		public void SetMvVertSnapCapHoveredColor(Color color)
		{
			_mvVertSnapCapLookAndFeel.HoveredColor = color;
		}

		public void SetMvVertSnapCapHoveredBorderColor(Color color)
		{
			_mvVertSnapCapLookAndFeel.HoveredBorderColor = color;
		}

		public bool IsMvSliderVisible(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _mvSglSliderVis[axisIndex];
			}
			return _mvSglSliderVis[3 + axisIndex];
		}

		public bool IsMvDblSliderVisible(PlaneId planeId)
		{
			return _mvDblSliderVis[(int)planeId];
		}

		public bool IsMvSliderCapVisible(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _mvSglSliderCapVis[axisIndex];
			}
			return _mvSglSliderCapVis[3 + axisIndex];
		}

		public bool IsMvPositiveSliderVisible(int axisIndex)
		{
			return _mvSglSliderVis[axisIndex];
		}

		public bool IsMvPositiveSliderCapVisible(int axisIndex)
		{
			return _mvSglSliderCapVis[axisIndex];
		}

		public bool IsMvNegativeSliderVisible(int axisIndex)
		{
			return _mvSglSliderVis[3 + axisIndex];
		}

		public bool IsMvNegativeSliderCapVisible(int axisIndex)
		{
			return _mvSglSliderCapVis[3 + axisIndex];
		}

		public void SetMvSliderVisible(int axisIndex, AxisSign axisSign, bool isVisible)
		{
			if (axisSign == AxisSign.Positive)
			{
				_mvSglSliderVis[axisIndex] = isVisible;
			}
			else
			{
				_mvSglSliderVis[3 + axisIndex] = isVisible;
			}
		}

		public void SetMvDblSliderVisible(PlaneId planeId, bool isVisible)
		{
			_mvDblSliderVis[(int)planeId] = isVisible;
		}

		public void SetMvSliderCapVisible(int axisIndex, AxisSign axisSign, bool isVisible)
		{
			if (axisSign == AxisSign.Positive)
			{
				_mvSglSliderCapVis[axisIndex] = isVisible;
			}
			else
			{
				_mvSglSliderCapVis[3 + axisIndex] = isVisible;
			}
		}

		public void SetMvPositiveSliderVisible(int axisIndex, bool isVisible)
		{
			_mvSglSliderVis[axisIndex] = isVisible;
		}

		public void SetMvPositiveSliderCapVisible(int axisIndex, bool isVisible)
		{
			_mvSglSliderCapVis[axisIndex] = isVisible;
		}

		public void SetMvNegativeSliderVisible(int axisIndex, bool isVisible)
		{
			_mvSglSliderVis[3 + axisIndex] = isVisible;
		}

		public void SetMvNegativeSliderCapVisible(int axisIndex, bool isVisible)
		{
			_mvSglSliderCapVis[3 + axisIndex] = isVisible;
		}

		public void SetMvSliderLength(float axisLength)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].Length = axisLength;
			}
		}

		public void SetMvSliderLineType(GizmoLine3DType lineType)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].LineType = lineType;
			}
		}

		public void SetMvDblSliderBorderType(GizmoQuad3DBorderType borderType)
		{
			GizmoPlaneSlider3DLookAndFeel[] mvDblSlidersLookAndFeel = _mvDblSlidersLookAndFeel;
			for (int i = 0; i < mvDblSlidersLookAndFeel.Length; i++)
			{
				mvDblSlidersLookAndFeel[i].QuadBorderType = borderType;
			}
		}

		public void SetMvDblSliderBorderBoxHeight(float height)
		{
			GizmoPlaneSlider3DLookAndFeel[] mvDblSlidersLookAndFeel = _mvDblSlidersLookAndFeel;
			for (int i = 0; i < mvDblSlidersLookAndFeel.Length; i++)
			{
				mvDblSlidersLookAndFeel[i].BorderBoxHeight = height;
			}
		}

		public void SetMvDblSliderBorderBoxDepth(float depth)
		{
			GizmoPlaneSlider3DLookAndFeel[] mvDblSlidersLookAndFeel = _mvDblSlidersLookAndFeel;
			for (int i = 0; i < mvDblSlidersLookAndFeel.Length; i++)
			{
				mvDblSlidersLookAndFeel[i].BorderBoxDepth = depth;
			}
		}

		public void SetMvBoxSliderHeight(float height)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].BoxHeight = height;
			}
		}

		public void SetMvBoxSliderDepth(float depth)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].BoxDepth = depth;
			}
		}

		public void SetMvCylinderSliderRadius(float radius)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].CylinderRadius = radius;
			}
		}

		public void SetMvDblSliderSize(float size)
		{
			GizmoPlaneSlider3DLookAndFeel[] mvDblSlidersLookAndFeel = _mvDblSlidersLookAndFeel;
			foreach (GizmoPlaneSlider3DLookAndFeel obj in mvDblSlidersLookAndFeel)
			{
				obj.QuadWidth = size;
				obj.QuadHeight = size;
			}
		}

		public void SetMvScale(float scale)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			foreach (GizmoLineSlider3DLookAndFeel obj in mvSglSlidersLookAndFeel)
			{
				obj.Scale = scale;
				obj.CapLookAndFeel.Scale = scale;
			}
			GizmoPlaneSlider3DLookAndFeel[] mvDblSlidersLookAndFeel = _mvDblSlidersLookAndFeel;
			for (int i = 0; i < mvDblSlidersLookAndFeel.Length; i++)
			{
				mvDblSlidersLookAndFeel[i].Scale = scale;
			}
		}

		public void SetMvUseZoomFactor(bool useZoomFactor)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			foreach (GizmoLineSlider3DLookAndFeel obj in mvSglSlidersLookAndFeel)
			{
				obj.UseZoomFactor = useZoomFactor;
				obj.CapLookAndFeel.UseZoomFactor = useZoomFactor;
			}
			GizmoPlaneSlider3DLookAndFeel[] mvDblSlidersLookAndFeel = _mvDblSlidersLookAndFeel;
			for (int i = 0; i < mvDblSlidersLookAndFeel.Length; i++)
			{
				mvDblSlidersLookAndFeel[i].UseZoomFactor = useZoomFactor;
			}
		}

		public void SetMvAxisColor(int axisIndex, Color color)
		{
			GetMvSglSliderLookAndFeel(axisIndex, AxisSign.Positive).Color = color;
			GetMvSglSliderLookAndFeel(axisIndex, AxisSign.Positive).CapLookAndFeel.Color = color;
			GetMvSglSliderLookAndFeel(axisIndex, AxisSign.Negative).Color = color;
			GetMvSglSliderLookAndFeel(axisIndex, AxisSign.Negative).CapLookAndFeel.Color = color;
			GizmoPlaneSlider3DLookAndFeel gizmoPlaneSlider3DLookAndFeel = null;
			switch (axisIndex)
			{
			case 0:
				gizmoPlaneSlider3DLookAndFeel = GetMvDblSliderLookAndFeel(PlaneId.YZ);
				break;
			case 1:
				gizmoPlaneSlider3DLookAndFeel = GetMvDblSliderLookAndFeel(PlaneId.ZX);
				break;
			case 2:
				gizmoPlaneSlider3DLookAndFeel = GetMvDblSliderLookAndFeel(PlaneId.XY);
				break;
			}
			gizmoPlaneSlider3DLookAndFeel.Color = color.KeepAllButAlpha(gizmoPlaneSlider3DLookAndFeel.Color.a);
			gizmoPlaneSlider3DLookAndFeel.BorderColor = color;
		}

		public void SetMvDblSliderFillAlpha(float alpha)
		{
			alpha = Mathf.Clamp(alpha, 0f, 1f);
			GizmoPlaneSlider3DLookAndFeel[] mvDblSlidersLookAndFeel = _mvDblSlidersLookAndFeel;
			foreach (GizmoPlaneSlider3DLookAndFeel obj in mvDblSlidersLookAndFeel)
			{
				obj.Color = obj.Color.KeepAllButAlpha(alpha);
				obj.HoveredColor = obj.HoveredColor.KeepAllButAlpha(alpha);
			}
		}

		public void SetMvHoveredColor(Color hoveredColor)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			foreach (GizmoLineSlider3DLookAndFeel obj in mvSglSlidersLookAndFeel)
			{
				obj.HoveredColor = hoveredColor;
				obj.CapLookAndFeel.HoveredColor = hoveredColor;
			}
			GizmoPlaneSlider3DLookAndFeel[] mvDblSlidersLookAndFeel = _mvDblSlidersLookAndFeel;
			foreach (GizmoPlaneSlider3DLookAndFeel gizmoPlaneSlider3DLookAndFeel in mvDblSlidersLookAndFeel)
			{
				gizmoPlaneSlider3DLookAndFeel.HoveredBorderColor = hoveredColor;
				gizmoPlaneSlider3DLookAndFeel.HoveredColor = hoveredColor.KeepAllButAlpha(gizmoPlaneSlider3DLookAndFeel.Color.a);
			}
		}

		public void SetMvSliderShadeMode(GizmoShadeMode shadeMode)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].ShadeMode = shadeMode;
			}
		}

		public void SetMvSliderCapShadeMode(GizmoShadeMode shadeMode)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].CapLookAndFeel.ShadeMode = shadeMode;
			}
		}

		public void SetMvDblSliderBorderShadeMode(GizmoShadeMode shadeMode)
		{
			GizmoPlaneSlider3DLookAndFeel[] mvDblSlidersLookAndFeel = _mvDblSlidersLookAndFeel;
			for (int i = 0; i < mvDblSlidersLookAndFeel.Length; i++)
			{
				mvDblSlidersLookAndFeel[i].BorderShadeMode = shadeMode;
			}
		}

		public void SetMvSliderCapType(GizmoCap3DType capType)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].CapLookAndFeel.CapType = capType;
			}
		}

		public void SetMvSliderFillMode(GizmoFillMode3D fillMode)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].FillMode = fillMode;
			}
		}

		public void SetMvSliderCapFillMode(GizmoFillMode3D fillMode)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].CapLookAndFeel.FillMode = fillMode;
			}
		}

		public void SetMvDblSliderBorderFillMode(GizmoFillMode3D fillMode)
		{
			GizmoPlaneSlider3DLookAndFeel[] mvDblSlidersLookAndFeel = _mvDblSlidersLookAndFeel;
			for (int i = 0; i < mvDblSlidersLookAndFeel.Length; i++)
			{
				mvDblSlidersLookAndFeel[i].BorderFillMode = fillMode;
			}
		}

		public void SetMvSliderBoxCapWidth(float width)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].CapLookAndFeel.BoxWidth = width;
			}
		}

		public void SetMvSliderBoxCapHeight(float height)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].CapLookAndFeel.BoxHeight = height;
			}
		}

		public void SetMvSliderBoxCapDepth(float depth)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].CapLookAndFeel.BoxDepth = depth;
			}
		}

		public void SetMvSliderConeCapHeight(float height)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].CapLookAndFeel.ConeHeight = height;
			}
		}

		public void SetMvSliderConeCapBaseRadius(float radius)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].CapLookAndFeel.ConeRadius = radius;
			}
		}

		public void SetMvSliderPyramidCapWidth(float width)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].CapLookAndFeel.PyramidWidth = width;
			}
		}

		public void SetMvSliderPyramidCapHeight(float height)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].CapLookAndFeel.PyramidHeight = height;
			}
		}

		public void SetMvSliderPyramidCapDepth(float depth)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].CapLookAndFeel.PyramidDepth = depth;
			}
		}

		public void SetMvSliderTriPrismCapWidth(float width)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].CapLookAndFeel.TrPrismWidth = width;
			}
		}

		public void SetMvSliderTriPrismCapHeight(float height)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].CapLookAndFeel.TrPrismHeight = height;
			}
		}

		public void SetMvSliderTriPrismCapDepth(float depth)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].CapLookAndFeel.TrPrismDepth = depth;
			}
		}

		public void SetMvSliderSphereCapRadius(float radius)
		{
			GizmoLineSlider3DLookAndFeel[] mvSglSlidersLookAndFeel = _mvSglSlidersLookAndFeel;
			for (int i = 0; i < mvSglSlidersLookAndFeel.Length; i++)
			{
				mvSglSlidersLookAndFeel[i].CapLookAndFeel.SphereRadius = radius;
			}
		}

		public void ConnectMvSliderLookAndFeel(GizmoLineSlider3D slider, int axisIndex, AxisSign axisSign)
		{
			slider.SharedLookAndFeel = GetMvSglSliderLookAndFeel(axisIndex, axisSign);
		}

		public void ConnectMvDblSliderLookAndFeel(GizmoPlaneSlider3D dblSlider, PlaneId planeId)
		{
			dblSlider.SharedLookAndFeel = GetMvDblSliderLookAndFeel(planeId);
		}

		public void ConnectMvVertSnapCapLookAndFeel(GizmoCap2D vertSnapCap)
		{
			vertSnapCap.SharedLookAndFeel = _mvVertSnapCapLookAndFeel;
		}

		public void Inherit(MoveGizmoLookAndFeel3D lookAndFeel)
		{
			SetMvAxisColor(0, lookAndFeel.XColor);
			SetMvAxisColor(1, lookAndFeel.YColor);
			SetMvAxisColor(2, lookAndFeel.ZColor);
			SetMvBoxSliderDepth(lookAndFeel.BoxSliderDepth);
			SetMvBoxSliderHeight(lookAndFeel.BoxSliderHeight);
			SetMvCylinderSliderRadius(lookAndFeel.CylinderSliderRadius);
			SetMvDblSliderBorderBoxDepth(lookAndFeel.DblSliderBorderBoxDepth);
			SetMvDblSliderBorderBoxHeight(lookAndFeel.DblSliderBorderBoxHeight);
			SetMvDblSliderBorderFillMode(lookAndFeel.DblSliderBorderFillMode);
			SetMvDblSliderBorderShadeMode(lookAndFeel.DblSliderBorderShadeMode);
			SetMvDblSliderBorderType(lookAndFeel.DblSliderBorderType);
			SetMvDblSliderFillAlpha(lookAndFeel.DblSliderFillAlpha);
			SetMvDblSliderSize(lookAndFeel.DblSliderSize);
			SetMvDblSliderVisible(PlaneId.XY, lookAndFeel.IsDblSliderVisible(PlaneId.XY));
			SetMvDblSliderVisible(PlaneId.YZ, lookAndFeel.IsDblSliderVisible(PlaneId.YZ));
			SetMvDblSliderVisible(PlaneId.ZX, lookAndFeel.IsDblSliderVisible(PlaneId.ZX));
			SetMvHoveredColor(lookAndFeel.HoveredColor);
			SetMvScale(lookAndFeel.Scale);
			SetMvSliderBoxCapDepth(lookAndFeel.SliderBoxCapDepth);
			SetMvSliderBoxCapHeight(lookAndFeel.SliderBoxCapHeight);
			SetMvSliderBoxCapWidth(lookAndFeel.SliderBoxCapWidth);
			SetMvSliderCapFillMode(lookAndFeel.SliderCapFillMode);
			SetMvSliderCapShadeMode(lookAndFeel.SliderCapShadeMode);
			SetMvSliderCapType(lookAndFeel.SliderCapType);
			SetMvSliderCapVisible(0, AxisSign.Positive, lookAndFeel.IsSliderCapVisible(0, AxisSign.Positive));
			SetMvSliderCapVisible(1, AxisSign.Positive, lookAndFeel.IsSliderCapVisible(1, AxisSign.Positive));
			SetMvSliderCapVisible(2, AxisSign.Positive, lookAndFeel.IsSliderCapVisible(2, AxisSign.Positive));
			SetMvSliderCapVisible(0, AxisSign.Negative, lookAndFeel.IsSliderCapVisible(0, AxisSign.Negative));
			SetMvSliderCapVisible(1, AxisSign.Negative, lookAndFeel.IsSliderCapVisible(1, AxisSign.Negative));
			SetMvSliderCapVisible(2, AxisSign.Negative, lookAndFeel.IsSliderCapVisible(2, AxisSign.Negative));
			SetMvSliderConeCapHeight(lookAndFeel.SliderConeCapHeight);
			SetMvSliderConeCapBaseRadius(lookAndFeel.SliderConeCapBaseRadius);
			SetMvSliderFillMode(lookAndFeel.SliderFillMode);
			SetMvSliderLength(lookAndFeel.SliderLength);
			SetMvSliderLineType(lookAndFeel.SliderLineType);
			SetMvSliderPyramidCapDepth(lookAndFeel.SliderPyramidCapDepth);
			SetMvSliderPyramidCapHeight(lookAndFeel.SliderPyramidCapHeight);
			SetMvSliderPyramidCapWidth(lookAndFeel.SliderPyramidCapWidth);
			SetMvSliderShadeMode(lookAndFeel.SliderShadeMode);
			SetMvSliderSphereCapRadius(lookAndFeel.SliderSphereCapRadius);
			SetMvSliderTriPrismCapDepth(lookAndFeel.SliderTriPrismCapDepth);
			SetMvSliderTriPrismCapHeight(lookAndFeel.SliderTriPrismCapHeight);
			SetMvSliderTriPrismCapWidth(lookAndFeel.SliderTriPrismCapWidth);
			SetMvSliderVisible(0, AxisSign.Positive, lookAndFeel.IsSliderVisible(0, AxisSign.Positive));
			SetMvSliderVisible(1, AxisSign.Positive, lookAndFeel.IsSliderVisible(1, AxisSign.Positive));
			SetMvSliderVisible(2, AxisSign.Positive, lookAndFeel.IsSliderVisible(2, AxisSign.Positive));
			SetMvSliderVisible(0, AxisSign.Negative, lookAndFeel.IsSliderVisible(0, AxisSign.Negative));
			SetMvSliderVisible(1, AxisSign.Negative, lookAndFeel.IsSliderVisible(1, AxisSign.Negative));
			SetMvSliderVisible(2, AxisSign.Negative, lookAndFeel.IsSliderVisible(2, AxisSign.Negative));
			SetMvUseZoomFactor(lookAndFeel.UseZoomFactor);
			SetMvVertSnapCapBorderColor(lookAndFeel.VertSnapCapBorderColor);
			SetMvVertSnapCapCircleRadius(lookAndFeel.VertSnapCapCircleRadius);
			SetMvVertSnapCapColor(lookAndFeel.VertSnapCapColor);
			SetMvVertSnapCapFillMode(lookAndFeel.VertSnapCapFillMode);
			SetMvVertSnapCapHoveredBorderColor(lookAndFeel.VertSnapCapHoveredBorderColor);
			SetMvVertSnapCapHoveredColor(lookAndFeel.VertSnapCapHoveredColor);
			SetMvVertSnapCapQuadHeight(lookAndFeel.VertSnapCapQuadHeight);
			SetMvVertSnapCapQuadWidth(lookAndFeel.VertSnapCapQuadWidth);
			SetMvVertSnapCapType(lookAndFeel.VertSnapCapType);
		}

		private GizmoLineSlider3DLookAndFeel GetMvSglSliderLookAndFeel(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _mvSglSlidersLookAndFeel[axisIndex];
			}
			return _mvSglSlidersLookAndFeel[3 + axisIndex];
		}

		private GizmoPlaneSlider3DLookAndFeel GetMvDblSliderLookAndFeel(PlaneId planeId)
		{
			return _mvDblSlidersLookAndFeel[(int)planeId];
		}

		public bool IsRtAxisVisible(int axisIndex)
		{
			return _rtAxesVis[axisIndex];
		}

		public void SetRtAxisVisible(int axisIndex, bool isVisible)
		{
			_rtAxesVis[axisIndex] = isVisible;
		}

		public void SetRtShadeMode(GizmoShadeMode shadeMode)
		{
			GizmoPlaneSlider3DLookAndFeel[] rtAxesLookAndFeel = _rtAxesLookAndFeel;
			foreach (GizmoPlaneSlider3DLookAndFeel obj in rtAxesLookAndFeel)
			{
				obj.ShadeMode = shadeMode;
				obj.BorderShadeMode = shadeMode;
			}
			_rtMidCapLookAndFeel.ShadeMode = shadeMode;
		}

		public void SetRtAxisBorderFillMode(GizmoFillMode3D fillMode)
		{
			GizmoPlaneSlider3DLookAndFeel[] rtAxesLookAndFeel = _rtAxesLookAndFeel;
			for (int i = 0; i < rtAxesLookAndFeel.Length; i++)
			{
				rtAxesLookAndFeel[i].BorderFillMode = fillMode;
			}
		}

		public void SetRtNumAxisTorusWireAxialSlices(int numSlices)
		{
			GizmoPlaneSlider3DLookAndFeel[] rtAxesLookAndFeel = _rtAxesLookAndFeel;
			for (int i = 0; i < rtAxesLookAndFeel.Length; i++)
			{
				rtAxesLookAndFeel[i].NumBorderTorusWireAxialSlices = numSlices;
			}
		}

		public void SetRtUseZoomFactor(bool useZoomFactor)
		{
			GizmoPlaneSlider3DLookAndFeel[] rtAxesLookAndFeel = _rtAxesLookAndFeel;
			for (int i = 0; i < rtAxesLookAndFeel.Length; i++)
			{
				rtAxesLookAndFeel[i].UseZoomFactor = useZoomFactor;
			}
			_rtMidCapLookAndFeel.UseZoomFactor = useZoomFactor;
		}

		public void SetRtScale(float scale)
		{
			GizmoPlaneSlider3DLookAndFeel[] rtAxesLookAndFeel = _rtAxesLookAndFeel;
			for (int i = 0; i < rtAxesLookAndFeel.Length; i++)
			{
				rtAxesLookAndFeel[i].Scale = scale;
			}
			_rtMidCapLookAndFeel.Scale = scale;
		}

		public void SetRtRadius(float radius)
		{
			GizmoPlaneSlider3DLookAndFeel[] rtAxesLookAndFeel = _rtAxesLookAndFeel;
			for (int i = 0; i < rtAxesLookAndFeel.Length; i++)
			{
				rtAxesLookAndFeel[i].CircleRadius = radius;
			}
			_rtMidCapLookAndFeel.SphereRadius = radius;
		}

		public void SetRtAxisBorderCullAlphaScale(float scale)
		{
			GizmoPlaneSlider3DLookAndFeel[] rtAxesLookAndFeel = _rtAxesLookAndFeel;
			for (int i = 0; i < rtAxesLookAndFeel.Length; i++)
			{
				rtAxesLookAndFeel[i].BorderCircleCullAlphaScale = scale;
			}
		}

		public void SetRtAxisBorderType(GizmoCircle3DBorderType borderType)
		{
			GizmoPlaneSlider3DLookAndFeel[] rtAxesLookAndFeel = _rtAxesLookAndFeel;
			for (int i = 0; i < rtAxesLookAndFeel.Length; i++)
			{
				rtAxesLookAndFeel[i].CircleBorderType = borderType;
			}
		}

		public void SetRtAxisTorusThickness(float thickness)
		{
			GizmoPlaneSlider3DLookAndFeel[] rtAxesLookAndFeel = _rtAxesLookAndFeel;
			for (int i = 0; i < rtAxesLookAndFeel.Length; i++)
			{
				rtAxesLookAndFeel[i].BorderTorusThickness = thickness;
			}
		}

		public void SetRtAxisCylTorusWidth(float width)
		{
			GizmoPlaneSlider3DLookAndFeel[] rtAxesLookAndFeel = _rtAxesLookAndFeel;
			for (int i = 0; i < rtAxesLookAndFeel.Length; i++)
			{
				rtAxesLookAndFeel[i].BorderCylTorusWidth = width;
			}
		}

		public void SetRtAxisCylTorusHeight(float height)
		{
			GizmoPlaneSlider3DLookAndFeel[] rtAxesLookAndFeel = _rtAxesLookAndFeel;
			for (int i = 0; i < rtAxesLookAndFeel.Length; i++)
			{
				rtAxesLookAndFeel[i].BorderCylTorusHeight = height;
			}
		}

		public void SetRtMidCapVisible(bool isVisible)
		{
			_isRtMidCapVisible = isVisible;
		}

		public void SetRtMidCapColor(Color color)
		{
			_rtMidCapLookAndFeel.Color = color;
		}

		public void SetRtHoveredMidCapColor(Color color)
		{
			_rtMidCapLookAndFeel.HoveredColor = color;
		}

		public void SetRtMidCapBorderVisible(bool isVisible)
		{
			_rtMidCapLookAndFeel.IsSphereBorderVisible = isVisible;
		}

		public void SetRtMidCapBorderColor(Color color)
		{
			_rtMidCapLookAndFeel.SphereBorderColor = color;
		}

		public void SetRtAxisBorderColor(int axisIndex, Color color)
		{
			_rtAxesLookAndFeel[axisIndex].BorderColor = color;
		}

		public void SetRtHoveredColor(Color hoveredColor)
		{
			GizmoPlaneSlider3DLookAndFeel[] rtAxesLookAndFeel = _rtAxesLookAndFeel;
			foreach (GizmoPlaneSlider3DLookAndFeel obj in rtAxesLookAndFeel)
			{
				obj.HoveredColor = hoveredColor;
				obj.HoveredBorderColor = hoveredColor;
			}
		}

		public void SetRtRotationArcColor(Color color)
		{
			GizmoPlaneSlider3DLookAndFeel[] rtAxesLookAndFeel = _rtAxesLookAndFeel;
			for (int i = 0; i < rtAxesLookAndFeel.Length; i++)
			{
				rtAxesLookAndFeel[i].RotationArcLookAndFeel.Color = color;
			}
			_rtCamLookSliderLookAndFeel.RotationArcLookAndFeel.Color = color;
		}

		public void SetRtRotationArcBorderColor(Color color)
		{
			GizmoPlaneSlider3DLookAndFeel[] rtAxesLookAndFeel = _rtAxesLookAndFeel;
			for (int i = 0; i < rtAxesLookAndFeel.Length; i++)
			{
				rtAxesLookAndFeel[i].RotationArcLookAndFeel.BorderColor = color;
			}
			_rtCamLookSliderLookAndFeel.RotationArcLookAndFeel.BorderColor = color;
		}

		public void SetRtUseShortestRotationArc(bool useShortest)
		{
			GizmoPlaneSlider3DLookAndFeel[] rtAxesLookAndFeel = _rtAxesLookAndFeel;
			for (int i = 0; i < rtAxesLookAndFeel.Length; i++)
			{
				rtAxesLookAndFeel[i].RotationArcLookAndFeel.UseShortestRotation = useShortest;
			}
			_rtCamLookSliderLookAndFeel.RotationArcLookAndFeel.UseShortestRotation = useShortest;
		}

		public void SetRtRotationArcVisible(bool isVisible)
		{
			GizmoPlaneSlider3DLookAndFeel[] rtAxesLookAndFeel = _rtAxesLookAndFeel;
			for (int i = 0; i < rtAxesLookAndFeel.Length; i++)
			{
				rtAxesLookAndFeel[i].IsRotationArcVisible = isVisible;
			}
			_rtCamLookSliderLookAndFeel.IsRotationArcVisible = isVisible;
		}

		public void SetRtCamLookSliderRadiusOffset(float offset)
		{
			_rtCamLookSliderRadiusOffset = Mathf.Max(0f, offset);
		}

		public void SetRtCamLookSliderBorderColor(Color color)
		{
			_rtCamLookSliderLookAndFeel.BorderColor = color;
		}

		public void SetRtCamLookSliderHoveredBorderColor(Color color)
		{
			_rtCamLookSliderLookAndFeel.HoveredBorderColor = color;
		}

		public void SetRtCamLookSliderVisible(bool isVisible)
		{
			_isRtCamLookSliderVisible = isVisible;
		}

		public void SetRtCamLookSliderPolyBorderType(GizmoPolygon2DBorderType polyBorderType)
		{
			_rtCamLookSliderLookAndFeel.PolygonBorderType = polyBorderType;
		}

		public void SetRtCamLookSliderPolyBorderThickness(float thickness)
		{
			_rtCamLookSliderLookAndFeel.BorderPolyThickness = thickness;
		}

		public void ConnectRtSliderLookAndFeel(GizmoPlaneSlider3D slider, int axisIndex)
		{
			slider.SharedLookAndFeel = _rtAxesLookAndFeel[axisIndex];
		}

		public void ConnectRtMidCapLookAndFeel(GizmoCap3D cap)
		{
			cap.SharedLookAndFeel = _rtMidCapLookAndFeel;
		}

		public void ConnectRtCamLookSliderLookAndFeel(GizmoPlaneSlider2D slider)
		{
			slider.SharedLookAndFeel = _rtCamLookSliderLookAndFeel;
		}

		public void Inherit(RotationGizmoLookAndFeel3D lookAndFeel)
		{
			SetRtAxisBorderColor(0, lookAndFeel.XBorderColor);
			SetRtAxisBorderColor(1, lookAndFeel.YBorderColor);
			SetRtAxisBorderColor(2, lookAndFeel.ZBorderColor);
			SetRtAxisBorderCullAlphaScale(lookAndFeel.AxisCullAlphaScale);
			SetRtAxisBorderFillMode(lookAndFeel.AxisBorderFillMode);
			SetRtAxisBorderType(lookAndFeel.AxisBorderType);
			SetRtAxisCylTorusHeight(lookAndFeel.AxisCylTorusHeight);
			SetRtAxisCylTorusWidth(lookAndFeel.AxisCylTorusWidth);
			SetRtAxisTorusThickness(lookAndFeel.AxisTorusThickness);
			SetRtAxisVisible(0, lookAndFeel.IsAxisVisible(0));
			SetRtAxisVisible(1, lookAndFeel.IsAxisVisible(1));
			SetRtAxisVisible(2, lookAndFeel.IsAxisVisible(2));
			SetRtCamLookSliderBorderColor(lookAndFeel.CamLookSliderBorderColor);
			SetRtCamLookSliderHoveredBorderColor(lookAndFeel.CamLookSliderHoveredBorderColor);
			SetRtCamLookSliderPolyBorderThickness(lookAndFeel.CamLookSliderPolyBorderThickness);
			SetRtCamLookSliderPolyBorderType(lookAndFeel.CamLookSliderPolyBorderType);
			SetRtCamLookSliderRadiusOffset(lookAndFeel.CamLookSliderRadiusOffset);
			SetRtCamLookSliderVisible(lookAndFeel.IsCamLookSliderVisible);
			SetRtHoveredColor(lookAndFeel.HoveredColor);
			SetRtHoveredMidCapColor(lookAndFeel.HoveredMidCapColor);
			SetRtMidCapBorderColor(lookAndFeel.MidCapBorderColor);
			SetRtMidCapBorderVisible(lookAndFeel.IsMidCapBorderVisible);
			SetRtMidCapColor(lookAndFeel.MidCapColor);
			SetRtMidCapVisible(lookAndFeel.IsMidCapVisible);
			SetRtNumAxisTorusWireAxialSlices(lookAndFeel.NumAxisTorusWireAxialSlices);
			SetRtRadius(lookAndFeel.Radius);
			SetRtRotationArcBorderColor(lookAndFeel.RotationArcBorderColor);
			SetRtRotationArcColor(lookAndFeel.RotationArcColor);
			SetRtRotationArcVisible(lookAndFeel.IsRotationArcVisible);
			SetRtScale(lookAndFeel.Scale);
			SetRtShadeMode(lookAndFeel.ShadeMode);
			SetRtUseShortestRotationArc(lookAndFeel.UseShortestRotationArc);
			SetRtUseZoomFactor(lookAndFeel.UseZoomFactor);
		}

		public void SetScScaleGuideVisible(bool isVisible)
		{
			_isScScaleGuideVisible = isVisible;
		}

		public bool IsScDblSliderVisible(PlaneId planeId)
		{
			return _scDblSliderVis[(int)planeId];
		}

		public void SetScDblSliderVisible(PlaneId planeId, bool isVisible)
		{
			_scDblSliderVis[(int)planeId] = isVisible;
		}

		public bool IsScSliderVisible(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _scSglSliderVis[axisIndex];
			}
			return _scSglSliderVis[3 + axisIndex];
		}

		public bool IsScSliderCapVisible(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _scSglSliderCapVis[axisIndex];
			}
			return _scSglSliderCapVis[3 + axisIndex];
		}

		public bool IsScPositiveSliderVisible(int axisIndex)
		{
			return _scSglSliderVis[axisIndex];
		}

		public bool IsScPositiveSliderCapVisible(int axisIndex)
		{
			return _scSglSliderCapVis[axisIndex];
		}

		public bool IsScNegativeSliderVisible(int axisIndex)
		{
			return _scSglSliderVis[3 + axisIndex];
		}

		public bool IsScNegativeSliderCapVisible(int axisIndex)
		{
			return _scSglSliderCapVis[3 + axisIndex];
		}

		public void SetScSliderVisible(int axisIndex, AxisSign axisSign, bool isVisible)
		{
			if (axisSign == AxisSign.Positive)
			{
				_scSglSliderVis[axisIndex] = isVisible;
			}
			else
			{
				_scSglSliderVis[3 + axisIndex] = isVisible;
			}
		}

		public void SetScSliderCapVisible(int axisIndex, AxisSign axisSign, bool isVisible)
		{
			if (axisSign == AxisSign.Positive)
			{
				_scSglSliderCapVis[axisIndex] = isVisible;
			}
			else
			{
				_scSglSliderCapVis[3 + axisIndex] = isVisible;
			}
		}

		public void SetScPositiveSliderVisible(int axisIndex, bool isVisible)
		{
			_scSglSliderVis[axisIndex] = isVisible;
		}

		public void SetScPositiveSliderCapVisible(int axisIndex, bool isVisible)
		{
			_scSglSliderCapVis[axisIndex] = isVisible;
		}

		public void SetScNegativeSliderVisible(int axisIndex, bool isVisible)
		{
			_scSglSliderVis[3 + axisIndex] = isVisible;
		}

		public void SetScNegativeSliderCapVisible(int axisIndex, bool isVisible)
		{
			_scSglSliderCapVis[3 + axisIndex] = isVisible;
		}

		public void SetScSliderLength(float axisLength)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].Length = axisLength;
			}
		}

		public void SetScSliderLineType(GizmoLine3DType lineType)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].LineType = lineType;
			}
		}

		public void SetScBoxSliderHeight(float height)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].BoxHeight = height;
			}
		}

		public void SetScBoxSliderDepth(float depth)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].BoxDepth = depth;
			}
		}

		public void SetScCylinderSliderRadius(float radius)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].CylinderRadius = radius;
			}
		}

		public void SetScScale(float scale)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			foreach (GizmoLineSlider3DLookAndFeel obj in scSglSlidersLookAndFeel)
			{
				obj.Scale = scale;
				obj.CapLookAndFeel.Scale = scale;
			}
			GizmoPlaneSlider3DLookAndFeel[] scDblSlidersLookAndFeel = _scDblSlidersLookAndFeel;
			for (int i = 0; i < scDblSlidersLookAndFeel.Length; i++)
			{
				scDblSlidersLookAndFeel[i].Scale = scale;
			}
			_scMidCapLookAndFeel.Scale = scale;
		}

		public void SetScUseZoomFactor(bool useZoomFactor)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			foreach (GizmoLineSlider3DLookAndFeel obj in scSglSlidersLookAndFeel)
			{
				obj.UseZoomFactor = useZoomFactor;
				obj.CapLookAndFeel.UseZoomFactor = useZoomFactor;
			}
			GizmoPlaneSlider3DLookAndFeel[] scDblSlidersLookAndFeel = _scDblSlidersLookAndFeel;
			for (int i = 0; i < scDblSlidersLookAndFeel.Length; i++)
			{
				scDblSlidersLookAndFeel[i].UseZoomFactor = useZoomFactor;
			}
			_scMidCapLookAndFeel.UseZoomFactor = useZoomFactor;
			_scScaleGuideLookAndFeel.UseZoomFactor = useZoomFactor;
		}

		public void SetScScaleGuideAxisLength(float length)
		{
			_scScaleGuideLookAndFeel.AxisLength = length;
		}

		public void SetScAxisColor(int axisIndex, Color color)
		{
			GetScSglSliderLookAndFeel(axisIndex, AxisSign.Positive).Color = color;
			GetScSglSliderLookAndFeel(axisIndex, AxisSign.Positive).CapLookAndFeel.Color = color;
			GetScSglSliderLookAndFeel(axisIndex, AxisSign.Negative).Color = color;
			GetScSglSliderLookAndFeel(axisIndex, AxisSign.Negative).CapLookAndFeel.Color = color;
			GizmoPlaneSlider3DLookAndFeel gizmoPlaneSlider3DLookAndFeel = null;
			switch (axisIndex)
			{
			case 0:
				gizmoPlaneSlider3DLookAndFeel = GetScDblSliderLookAndFeel(PlaneId.YZ);
				_scScaleGuideLookAndFeel.XAxisColor = color;
				break;
			case 1:
				gizmoPlaneSlider3DLookAndFeel = GetScDblSliderLookAndFeel(PlaneId.ZX);
				_scScaleGuideLookAndFeel.YAxisColor = color;
				break;
			case 2:
				gizmoPlaneSlider3DLookAndFeel = GetScDblSliderLookAndFeel(PlaneId.XY);
				_scScaleGuideLookAndFeel.ZAxisColor = color;
				break;
			}
			gizmoPlaneSlider3DLookAndFeel.Color = color.KeepAllButAlpha(gizmoPlaneSlider3DLookAndFeel.Color.a);
			gizmoPlaneSlider3DLookAndFeel.BorderColor = color;
		}

		public void SetScDblSliderFillAlpha(float alpha)
		{
			alpha = Mathf.Clamp(alpha, 0f, 1f);
			GizmoPlaneSlider3DLookAndFeel[] scDblSlidersLookAndFeel = _scDblSlidersLookAndFeel;
			foreach (GizmoPlaneSlider3DLookAndFeel obj in scDblSlidersLookAndFeel)
			{
				obj.Color = obj.Color.KeepAllButAlpha(alpha);
				obj.HoveredColor = obj.HoveredColor.KeepAllButAlpha(alpha);
			}
		}

		public void SetScMidCapColor(Color color)
		{
			_scMidCapLookAndFeel.Color = color;
		}

		public void SetScMidCapVisible(bool visible)
		{
			_isScMidCapVisible = visible;
		}

		public void SetScHoveredColor(Color hoveredColor)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			foreach (GizmoLineSlider3DLookAndFeel obj in scSglSlidersLookAndFeel)
			{
				obj.HoveredColor = hoveredColor;
				obj.CapLookAndFeel.HoveredColor = hoveredColor;
			}
			GizmoPlaneSlider3DLookAndFeel[] scDblSlidersLookAndFeel = _scDblSlidersLookAndFeel;
			foreach (GizmoPlaneSlider3DLookAndFeel gizmoPlaneSlider3DLookAndFeel in scDblSlidersLookAndFeel)
			{
				gizmoPlaneSlider3DLookAndFeel.HoveredBorderColor = hoveredColor;
				gizmoPlaneSlider3DLookAndFeel.HoveredColor = hoveredColor.KeepAllButAlpha(gizmoPlaneSlider3DLookAndFeel.Color.a);
			}
			_scMidCapLookAndFeel.HoveredColor = hoveredColor;
		}

		public void SetScSliderShadeMode(GizmoShadeMode shadeMode)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].ShadeMode = shadeMode;
			}
		}

		public void SetScSliderCapShadeMode(GizmoShadeMode shadeMode)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].CapLookAndFeel.ShadeMode = shadeMode;
			}
		}

		public void SetScMidCapShadeMode(GizmoShadeMode shadeMode)
		{
			_scMidCapLookAndFeel.ShadeMode = shadeMode;
		}

		public void SetScSliderCapType(GizmoCap3DType capType)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].CapLookAndFeel.CapType = capType;
			}
		}

		public void SetScMidCapType(GizmoCap3DType capType)
		{
			if (IsScMidCapTypeAllowed(capType))
			{
				_scMidCapLookAndFeel.CapType = capType;
			}
		}

		public bool IsScMidCapTypeAllowed(GizmoCap3DType capType)
		{
			if (capType != GizmoCap3DType.Box)
			{
				return capType == GizmoCap3DType.Sphere;
			}
			return true;
		}

		public List<Enum> GetAllowedScMidCapTypes()
		{
			return new List<Enum>
			{
				GizmoCap3DType.Box,
				GizmoCap3DType.Sphere
			};
		}

		public void SetScSliderFillMode(GizmoFillMode3D fillMode)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].FillMode = fillMode;
			}
		}

		public void SetScSliderCapFillMode(GizmoFillMode3D fillMode)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].CapLookAndFeel.FillMode = fillMode;
			}
		}

		public void SetScMidCapFillMode(GizmoFillMode3D fillMode)
		{
			_scMidCapLookAndFeel.FillMode = fillMode;
		}

		public void SetScSliderBoxCapWidth(float width)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].CapLookAndFeel.BoxWidth = width;
			}
		}

		public void SetScSliderBoxCapHeight(float height)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].CapLookAndFeel.BoxHeight = height;
			}
		}

		public void SetScSliderBoxCapDepth(float depth)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].CapLookAndFeel.BoxDepth = depth;
			}
		}

		public void SetScSliderConeCapHeight(float height)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].CapLookAndFeel.ConeHeight = height;
			}
		}

		public void SetScSliderConeCapBaseRadius(float radius)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].CapLookAndFeel.ConeRadius = radius;
			}
		}

		public void SetScSliderPyramidCapWidth(float width)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].CapLookAndFeel.PyramidWidth = width;
			}
		}

		public void SetScSliderPyramidCapHeight(float height)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].CapLookAndFeel.PyramidHeight = height;
			}
		}

		public void SetScSliderPyramidCapDepth(float depth)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].CapLookAndFeel.PyramidDepth = depth;
			}
		}

		public void SetScSliderTriPrismCapWidth(float width)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].CapLookAndFeel.TrPrismWidth = width;
			}
		}

		public void SetScSliderTriPrismCapHeight(float height)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].CapLookAndFeel.TrPrismHeight = height;
			}
		}

		public void SetScSliderTriPrismCapDepth(float depth)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].CapLookAndFeel.TrPrismDepth = depth;
			}
		}

		public void SetScSliderSphereCapRadius(float radius)
		{
			GizmoLineSlider3DLookAndFeel[] scSglSlidersLookAndFeel = _scSglSlidersLookAndFeel;
			for (int i = 0; i < scSglSlidersLookAndFeel.Length; i++)
			{
				scSglSlidersLookAndFeel[i].CapLookAndFeel.SphereRadius = radius;
			}
		}

		public void SetScMidCapBoxWidth(float width)
		{
			_scMidCapLookAndFeel.BoxWidth = width;
		}

		public void SetScMidCapBoxHeight(float height)
		{
			_scMidCapLookAndFeel.BoxHeight = height;
		}

		public void SetScMidCapBoxDepth(float depth)
		{
			_scMidCapLookAndFeel.BoxDepth = depth;
		}

		public void SetScMidCapSphereRadius(float radius)
		{
			_scMidCapLookAndFeel.SphereRadius = radius;
		}

		public void SetScDblSliderSize(float size)
		{
			GizmoPlaneSlider3DLookAndFeel[] scDblSlidersLookAndFeel = _scDblSlidersLookAndFeel;
			foreach (GizmoPlaneSlider3DLookAndFeel obj in scDblSlidersLookAndFeel)
			{
				obj.RATriangleXLength = size;
				obj.RATriangleYLength = size;
			}
		}

		public void ConnectScSliderLookAndFeel(GizmoLineSlider3D slider, int axisIndex, AxisSign axisSign)
		{
			slider.SharedLookAndFeel = GetScSglSliderLookAndFeel(axisIndex, axisSign);
		}

		public void ConnectScMidCapLookAndFeel(GizmoCap3D cap)
		{
			cap.SharedLookAndFeel = _scMidCapLookAndFeel;
		}

		public void ConnectScDblSliderLookAndFeel(GizmoPlaneSlider3D slider, PlaneId planeId)
		{
			slider.SharedLookAndFeel = GetScDblSliderLookAndFeel(planeId);
		}

		public void ConnectScGizmoScaleGuideLookAndFeel(GizmoScaleGuide scaleGuide)
		{
			scaleGuide.SharedLookAndFeel = _scScaleGuideLookAndFeel;
		}

		public void Inherit(ScaleGizmoLookAndFeel3D lookAndFeel)
		{
			SetScAxisColor(0, lookAndFeel.XColor);
			SetScAxisColor(1, lookAndFeel.YColor);
			SetScAxisColor(2, lookAndFeel.ZColor);
			SetScBoxSliderDepth(lookAndFeel.BoxSliderDepth);
			SetScBoxSliderHeight(lookAndFeel.BoxSliderHeight);
			SetScCylinderSliderRadius(lookAndFeel.CylinderSliderRadius);
			SetScDblSliderFillAlpha(lookAndFeel.DblSliderFillAlpha);
			SetScDblSliderSize(lookAndFeel.DblSliderSize);
			SetScDblSliderVisible(PlaneId.XY, lookAndFeel.IsDblSliderVisible(PlaneId.XY));
			SetScDblSliderVisible(PlaneId.YZ, lookAndFeel.IsDblSliderVisible(PlaneId.YZ));
			SetScDblSliderVisible(PlaneId.ZX, lookAndFeel.IsDblSliderVisible(PlaneId.ZX));
			SetScHoveredColor(lookAndFeel.HoveredColor);
			SetScMidCapBoxDepth(lookAndFeel.MidCapBoxDepth);
			SetScMidCapBoxHeight(lookAndFeel.MidCapBoxHeight);
			SetScMidCapBoxWidth(lookAndFeel.MidCapBoxWidth);
			SetScMidCapColor(lookAndFeel.MidCapColor);
			SetScMidCapFillMode(lookAndFeel.MidCapFillMode);
			SetScMidCapShadeMode(lookAndFeel.MidCapShadeMode);
			SetScMidCapSphereRadius(lookAndFeel.MidCapSphereRadius);
			SetScMidCapType(lookAndFeel.MidCapType);
			SetScScale(lookAndFeel.Scale);
			SetScScaleGuideAxisLength(lookAndFeel.ScaleGuideAxisLength);
			SetScSliderBoxCapDepth(lookAndFeel.SliderBoxCapDepth);
			SetScSliderBoxCapHeight(lookAndFeel.SliderBoxCapHeight);
			SetScSliderBoxCapWidth(lookAndFeel.SliderBoxCapWidth);
			SetScSliderCapFillMode(lookAndFeel.SliderCapFillMode);
			SetScSliderCapShadeMode(lookAndFeel.SliderCapShadeMode);
			SetScSliderCapType(lookAndFeel.SliderCapType);
			SetScSliderCapVisible(0, AxisSign.Positive, lookAndFeel.IsSliderCapVisible(0, AxisSign.Positive));
			SetScSliderCapVisible(1, AxisSign.Positive, lookAndFeel.IsSliderCapVisible(1, AxisSign.Positive));
			SetScSliderCapVisible(2, AxisSign.Positive, lookAndFeel.IsSliderCapVisible(2, AxisSign.Positive));
			SetScSliderCapVisible(0, AxisSign.Negative, lookAndFeel.IsSliderCapVisible(0, AxisSign.Negative));
			SetScSliderCapVisible(1, AxisSign.Negative, lookAndFeel.IsSliderCapVisible(1, AxisSign.Negative));
			SetScSliderCapVisible(2, AxisSign.Negative, lookAndFeel.IsSliderCapVisible(2, AxisSign.Negative));
			SetScSliderConeCapHeight(lookAndFeel.SliderConeCapHeight);
			SetScSliderConeCapBaseRadius(lookAndFeel.SliderConeCapBaseRadius);
			SetScSliderFillMode(lookAndFeel.SliderFillMode);
			SetScSliderLength(lookAndFeel.SliderLength);
			SetScSliderLineType(lookAndFeel.SliderLineType);
			SetScSliderPyramidCapDepth(lookAndFeel.SliderPyramidCapDepth);
			SetScSliderPyramidCapHeight(lookAndFeel.SliderPyramidCapHeight);
			SetScSliderPyramidCapWidth(lookAndFeel.SliderPyramidCapWidth);
			SetScSliderShadeMode(lookAndFeel.SliderShadeMode);
			SetScSliderSphereCapRadius(lookAndFeel.SliderSphereCapRadius);
			SetScSliderTriPrismCapDepth(lookAndFeel.SliderTriPrismCapDepth);
			SetScSliderTriPrismCapHeight(lookAndFeel.SliderTriPrismCapHeight);
			SetScSliderTriPrismCapWidth(lookAndFeel.SliderTriPrismCapWidth);
			SetScSliderVisible(0, AxisSign.Positive, lookAndFeel.IsSliderVisible(0, AxisSign.Positive));
			SetScSliderVisible(1, AxisSign.Positive, lookAndFeel.IsSliderVisible(1, AxisSign.Positive));
			SetScSliderVisible(2, AxisSign.Positive, lookAndFeel.IsSliderVisible(2, AxisSign.Positive));
			SetScSliderVisible(0, AxisSign.Negative, lookAndFeel.IsSliderVisible(0, AxisSign.Negative));
			SetScSliderVisible(1, AxisSign.Negative, lookAndFeel.IsSliderVisible(1, AxisSign.Negative));
			SetScSliderVisible(2, AxisSign.Negative, lookAndFeel.IsSliderVisible(2, AxisSign.Negative));
			SetScUseZoomFactor(lookAndFeel.UseZoomFactor);
		}

		private GizmoLineSlider3DLookAndFeel GetScSglSliderLookAndFeel(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _scSglSlidersLookAndFeel[axisIndex];
			}
			return _scSglSlidersLookAndFeel[3 + axisIndex];
		}

		private GizmoPlaneSlider3DLookAndFeel GetScDblSliderLookAndFeel(PlaneId planeId)
		{
			return _scDblSlidersLookAndFeel[(int)planeId];
		}
	}
}
