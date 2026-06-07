using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class RotationGizmoLookAndFeel3D : Settings
	{
		[SerializeField]
		private bool _isMidCapVisible = true;

		[SerializeField]
		private GizmoCap3DLookAndFeel _midCapLookAndFeel = new GizmoCap3DLookAndFeel();

		[SerializeField]
		private bool[] _axesVis = new bool[3];

		[SerializeField]
		private GizmoPlaneSlider3DLookAndFeel[] _axesLookAndFeel = new GizmoPlaneSlider3DLookAndFeel[3];

		[SerializeField]
		private bool _isCamLookSliderVisible = true;

		[SerializeField]
		private float _camLookSliderRadiusOffset = 0.65f;

		[SerializeField]
		private GizmoPlaneSlider2DLookAndFeel _camLookSliderLookAndFeel = new GizmoPlaneSlider2DLookAndFeel();

		public float Scale => _midCapLookAndFeel.Scale;

		public float Radius => _midCapLookAndFeel.SphereRadius;

		public bool UseZoomFactor => _midCapLookAndFeel.UseZoomFactor;

		public Color XBorderColor => _axesLookAndFeel[0].BorderColor;

		public Color YBorderColor => _axesLookAndFeel[1].BorderColor;

		public Color ZBorderColor => _axesLookAndFeel[2].BorderColor;

		public Color HoveredColor => _axesLookAndFeel[0].HoveredColor;

		public float AxisTorusThickness => _axesLookAndFeel[0].BorderTorusThickness;

		public float AxisCylTorusWidth => _axesLookAndFeel[0].BorderCylTorusWidth;

		public float AxisCylTorusHeight => _axesLookAndFeel[0].BorderCylTorusHeight;

		public float AxisCullAlphaScale => _axesLookAndFeel[0].BorderCircleCullAlphaScale;

		public GizmoShadeMode ShadeMode => _midCapLookAndFeel.ShadeMode;

		public GizmoCircle3DBorderType AxisBorderType => _axesLookAndFeel[0].CircleBorderType;

		public GizmoFillMode3D AxisBorderFillMode => _axesLookAndFeel[0].BorderFillMode;

		public int NumAxisTorusWireAxialSlices => _axesLookAndFeel[0].NumBorderTorusWireAxialSlices;

		public Color RotationArcColor => _axesLookAndFeel[0].RotationArcLookAndFeel.Color;

		public Color RotationArcBorderColor => _axesLookAndFeel[0].RotationArcLookAndFeel.BorderColor;

		public bool UseShortestRotationArc => _axesLookAndFeel[0].RotationArcLookAndFeel.UseShortestRotation;

		public bool IsRotationArcVisible => _axesLookAndFeel[0].IsRotationArcVisible;

		public Color MidCapColor => _midCapLookAndFeel.Color;

		public Color MidCapBorderColor => _midCapLookAndFeel.SphereBorderColor;

		public Color HoveredMidCapColor => _midCapLookAndFeel.HoveredColor;

		public bool IsMidCapVisible => _isMidCapVisible;

		public bool IsMidCapBorderVisible => _midCapLookAndFeel.IsSphereBorderVisible;

		public float CamLookSliderRadiusOffset => _camLookSliderRadiusOffset;

		public Color CamLookSliderBorderColor => _camLookSliderLookAndFeel.BorderColor;

		public Color CamLookSliderHoveredBorderColor => _camLookSliderLookAndFeel.HoveredBorderColor;

		public GizmoPolygon2DBorderType CamLookSliderPolyBorderType => _camLookSliderLookAndFeel.PolygonBorderType;

		public float CamLookSliderPolyBorderThickness => _camLookSliderLookAndFeel.BorderPolyThickness;

		public bool IsCamLookSliderVisible => _isCamLookSliderVisible;

		public RotationGizmoLookAndFeel3D()
		{
			for (int i = 0; i < _axesLookAndFeel.Length; i++)
			{
				_axesLookAndFeel[i] = new GizmoPlaneSlider3DLookAndFeel();
				_axesLookAndFeel[i].PlaneType = GizmoPlane3DType.Circle;
			}
			SetAxisVisible(0, isVisible: true);
			SetAxisVisible(1, isVisible: true);
			SetAxisVisible(2, isVisible: true);
			_midCapLookAndFeel.CapType = GizmoCap3DType.Sphere;
			_camLookSliderLookAndFeel.PlaneType = GizmoPlane2DType.Polygon;
			Color color = new Color(0.3f, 0.3f, 0.3f, 0.12f);
			SetMidCapColor(color);
			SetHoveredMidCapColor(color);
			SetMidCapBorderVisible(isVisible: true);
			SetMidCapBorderColor(Color.white);
			SetRadius(6.5f);
			SetAxisBorderColor(0, RTSystemValues.XAxisColor);
			SetAxisBorderColor(1, RTSystemValues.YAxisColor);
			SetAxisBorderColor(2, RTSystemValues.ZAxisColor);
			SetHoveredColor(RTSystemValues.HoveredAxisColor);
			SetCamLookSliderPolyBorderThickness(4f);
			SetCamLookSliderBorderColor(Color.white);
			SetCamLookSliderHoveredBorderColor(RTSystemValues.HoveredAxisColor);
			SetNumAxisTorusWireAxialSlices(2);
		}

		public bool IsAxisVisible(int axisIndex)
		{
			return _axesVis[axisIndex];
		}

		public void SetAxisVisible(int axisIndex, bool isVisible)
		{
			_axesVis[axisIndex] = isVisible;
		}

		public void SetShadeMode(GizmoShadeMode shadeMode)
		{
			GizmoPlaneSlider3DLookAndFeel[] axesLookAndFeel = _axesLookAndFeel;
			foreach (GizmoPlaneSlider3DLookAndFeel obj in axesLookAndFeel)
			{
				obj.ShadeMode = shadeMode;
				obj.BorderShadeMode = shadeMode;
			}
			_midCapLookAndFeel.ShadeMode = shadeMode;
		}

		public void SetAxisBorderFillMode(GizmoFillMode3D fillMode)
		{
			GizmoPlaneSlider3DLookAndFeel[] axesLookAndFeel = _axesLookAndFeel;
			for (int i = 0; i < axesLookAndFeel.Length; i++)
			{
				axesLookAndFeel[i].BorderFillMode = fillMode;
			}
		}

		public void SetNumAxisTorusWireAxialSlices(int numSlices)
		{
			GizmoPlaneSlider3DLookAndFeel[] axesLookAndFeel = _axesLookAndFeel;
			for (int i = 0; i < axesLookAndFeel.Length; i++)
			{
				axesLookAndFeel[i].NumBorderTorusWireAxialSlices = numSlices;
			}
		}

		public void SetUseZoomFactor(bool useZoomFactor)
		{
			GizmoPlaneSlider3DLookAndFeel[] axesLookAndFeel = _axesLookAndFeel;
			for (int i = 0; i < axesLookAndFeel.Length; i++)
			{
				axesLookAndFeel[i].UseZoomFactor = useZoomFactor;
			}
			_midCapLookAndFeel.UseZoomFactor = useZoomFactor;
		}

		public void SetScale(float scale)
		{
			GizmoPlaneSlider3DLookAndFeel[] axesLookAndFeel = _axesLookAndFeel;
			for (int i = 0; i < axesLookAndFeel.Length; i++)
			{
				axesLookAndFeel[i].Scale = scale;
			}
			_midCapLookAndFeel.Scale = scale;
		}

		public void SetRadius(float radius)
		{
			GizmoPlaneSlider3DLookAndFeel[] axesLookAndFeel = _axesLookAndFeel;
			for (int i = 0; i < axesLookAndFeel.Length; i++)
			{
				axesLookAndFeel[i].CircleRadius = radius;
			}
			_midCapLookAndFeel.SphereRadius = radius;
		}

		public void SetAxisBorderCullAlphaScale(float scale)
		{
			GizmoPlaneSlider3DLookAndFeel[] axesLookAndFeel = _axesLookAndFeel;
			for (int i = 0; i < axesLookAndFeel.Length; i++)
			{
				axesLookAndFeel[i].BorderCircleCullAlphaScale = scale;
			}
		}

		public void SetAxisBorderType(GizmoCircle3DBorderType borderType)
		{
			GizmoPlaneSlider3DLookAndFeel[] axesLookAndFeel = _axesLookAndFeel;
			for (int i = 0; i < axesLookAndFeel.Length; i++)
			{
				axesLookAndFeel[i].CircleBorderType = borderType;
			}
		}

		public void SetAxisTorusThickness(float thickness)
		{
			GizmoPlaneSlider3DLookAndFeel[] axesLookAndFeel = _axesLookAndFeel;
			for (int i = 0; i < axesLookAndFeel.Length; i++)
			{
				axesLookAndFeel[i].BorderTorusThickness = thickness;
			}
		}

		public void SetAxisCylTorusWidth(float width)
		{
			GizmoPlaneSlider3DLookAndFeel[] axesLookAndFeel = _axesLookAndFeel;
			for (int i = 0; i < axesLookAndFeel.Length; i++)
			{
				axesLookAndFeel[i].BorderCylTorusWidth = width;
			}
		}

		public void SetAxisCylTorusHeight(float height)
		{
			GizmoPlaneSlider3DLookAndFeel[] axesLookAndFeel = _axesLookAndFeel;
			for (int i = 0; i < axesLookAndFeel.Length; i++)
			{
				axesLookAndFeel[i].BorderCylTorusHeight = height;
			}
		}

		public void SetMidCapVisible(bool isVisible)
		{
			_isMidCapVisible = isVisible;
		}

		public void SetMidCapColor(Color color)
		{
			_midCapLookAndFeel.Color = color;
		}

		public void SetHoveredMidCapColor(Color color)
		{
			_midCapLookAndFeel.HoveredColor = color;
		}

		public void SetMidCapBorderVisible(bool isVisible)
		{
			_midCapLookAndFeel.IsSphereBorderVisible = isVisible;
		}

		public void SetMidCapBorderColor(Color color)
		{
			_midCapLookAndFeel.SphereBorderColor = color;
		}

		public void SetAxisBorderColor(int axisIndex, Color color)
		{
			_axesLookAndFeel[axisIndex].BorderColor = color;
		}

		public void SetHoveredColor(Color hoveredColor)
		{
			GizmoPlaneSlider3DLookAndFeel[] axesLookAndFeel = _axesLookAndFeel;
			foreach (GizmoPlaneSlider3DLookAndFeel obj in axesLookAndFeel)
			{
				obj.HoveredColor = hoveredColor;
				obj.HoveredBorderColor = hoveredColor;
			}
		}

		public void SetRotationArcColor(Color color)
		{
			GizmoPlaneSlider3DLookAndFeel[] axesLookAndFeel = _axesLookAndFeel;
			for (int i = 0; i < axesLookAndFeel.Length; i++)
			{
				axesLookAndFeel[i].RotationArcLookAndFeel.Color = color;
			}
			_camLookSliderLookAndFeel.RotationArcLookAndFeel.Color = color;
		}

		public void SetRotationArcBorderColor(Color color)
		{
			GizmoPlaneSlider3DLookAndFeel[] axesLookAndFeel = _axesLookAndFeel;
			for (int i = 0; i < axesLookAndFeel.Length; i++)
			{
				axesLookAndFeel[i].RotationArcLookAndFeel.BorderColor = color;
			}
			_camLookSliderLookAndFeel.RotationArcLookAndFeel.BorderColor = color;
		}

		public void SetUseShortestRotationArc(bool useShortest)
		{
			GizmoPlaneSlider3DLookAndFeel[] axesLookAndFeel = _axesLookAndFeel;
			for (int i = 0; i < axesLookAndFeel.Length; i++)
			{
				axesLookAndFeel[i].RotationArcLookAndFeel.UseShortestRotation = useShortest;
			}
			_camLookSliderLookAndFeel.RotationArcLookAndFeel.UseShortestRotation = useShortest;
		}

		public void SetRotationArcVisible(bool isVisible)
		{
			GizmoPlaneSlider3DLookAndFeel[] axesLookAndFeel = _axesLookAndFeel;
			for (int i = 0; i < axesLookAndFeel.Length; i++)
			{
				axesLookAndFeel[i].IsRotationArcVisible = isVisible;
			}
			_camLookSliderLookAndFeel.IsRotationArcVisible = isVisible;
		}

		public void SetCamLookSliderRadiusOffset(float offset)
		{
			_camLookSliderRadiusOffset = Mathf.Max(0f, offset);
		}

		public void SetCamLookSliderBorderColor(Color color)
		{
			_camLookSliderLookAndFeel.BorderColor = color;
		}

		public void SetCamLookSliderHoveredBorderColor(Color color)
		{
			_camLookSliderLookAndFeel.HoveredBorderColor = color;
		}

		public void SetCamLookSliderVisible(bool isVisible)
		{
			_isCamLookSliderVisible = isVisible;
		}

		public void SetCamLookSliderPolyBorderType(GizmoPolygon2DBorderType polyBorderType)
		{
			_camLookSliderLookAndFeel.PolygonBorderType = polyBorderType;
		}

		public void SetCamLookSliderPolyBorderThickness(float thickness)
		{
			_camLookSliderLookAndFeel.BorderPolyThickness = thickness;
		}

		public void ConnectSliderLookAndFeel(GizmoPlaneSlider3D slider, int axisIndex)
		{
			slider.SharedLookAndFeel = _axesLookAndFeel[axisIndex];
		}

		public void ConnectMidCapLookAndFeel(GizmoCap3D cap)
		{
			cap.SharedLookAndFeel = _midCapLookAndFeel;
		}

		public void ConnectCamLookSliderLookAndFeel(GizmoPlaneSlider2D slider)
		{
			slider.SharedLookAndFeel = _camLookSliderLookAndFeel;
		}
	}
}
