using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ScaleGizmoSettings3D : Settings
	{
		[SerializeField]
		private float _uniformSnapStep = 0.1f;

		[SerializeField]
		private GizmoLineSlider3DSettings[] _sglSliderSettings = new GizmoLineSlider3DSettings[6];

		[SerializeField]
		private GizmoPlaneSlider3DSettings[] _dblSliderSettings = new GizmoPlaneSlider3DSettings[3];

		public float LineSliderHoverEps => _sglSliderSettings[0].LineHoverEps;

		public float BoxSliderHoverEps => _sglSliderSettings[0].BoxHoverEps;

		public float CylinderSliderHoverEps => _sglSliderSettings[0].CylinderHoverEps;

		public float XSnapStep => GetSglSliderSettings(0, AxisSign.Positive).ScaleSnapStep;

		public float YSnapStep => GetSglSliderSettings(1, AxisSign.Positive).ScaleSnapStep;

		public float ZSnapStep => GetSglSliderSettings(2, AxisSign.Positive).ScaleSnapStep;

		public float XYSnapStep => GetDblSliderSettings(PlaneId.XY).ProportionalScaleSnapStep;

		public float YZSnapStep => GetDblSliderSettings(PlaneId.YZ).ProportionalScaleSnapStep;

		public float ZXSnapStep => GetDblSliderSettings(PlaneId.ZX).ProportionalScaleSnapStep;

		public float UniformSnapStep => _uniformSnapStep;

		public float DragSensitivity => _sglSliderSettings[0].ScaleSensitivity;

		public ScaleGizmoSettings3D()
		{
			for (int i = 0; i < _sglSliderSettings.Length; i++)
			{
				_sglSliderSettings[i] = new GizmoLineSlider3DSettings();
			}
			for (int j = 0; j < _dblSliderSettings.Length; j++)
			{
				_dblSliderSettings[j] = new GizmoPlaneSlider3DSettings();
				_dblSliderSettings[j].AreaHoverEps = 0f;
				_dblSliderSettings[j].BorderLineHoverEps = 0f;
				_dblSliderSettings[j].BorderBoxHoverEps = 0f;
			}
			SetDragSensitivity(0.6f);
		}

		public void SetLineSliderHoverEps(float eps)
		{
			GizmoLineSlider3DSettings[] sglSliderSettings = _sglSliderSettings;
			for (int i = 0; i < sglSliderSettings.Length; i++)
			{
				sglSliderSettings[i].LineHoverEps = eps;
			}
		}

		public void SetBoxSliderHoverEps(float eps)
		{
			GizmoLineSlider3DSettings[] sglSliderSettings = _sglSliderSettings;
			for (int i = 0; i < sglSliderSettings.Length; i++)
			{
				sglSliderSettings[i].BoxHoverEps = eps;
			}
		}

		public void SetCylinderSliderHoverEps(float eps)
		{
			GizmoLineSlider3DSettings[] sglSliderSettings = _sglSliderSettings;
			for (int i = 0; i < sglSliderSettings.Length; i++)
			{
				sglSliderSettings[i].CylinderHoverEps = eps;
			}
		}

		public void SetXSnapStep(float snapStep)
		{
			GetSglSliderSettings(0, AxisSign.Positive).ScaleSnapStep = snapStep;
			GetSglSliderSettings(0, AxisSign.Negative).ScaleSnapStep = snapStep;
			GetDblSliderSettings(PlaneId.XY).ScaleSnapStepRight = snapStep;
			GetDblSliderSettings(PlaneId.ZX).ScaleSnapStepUp = snapStep;
		}

		public void SetYSnapStep(float snapStep)
		{
			GetSglSliderSettings(1, AxisSign.Positive).ScaleSnapStep = snapStep;
			GetSglSliderSettings(1, AxisSign.Negative).ScaleSnapStep = snapStep;
			GetDblSliderSettings(PlaneId.XY).ScaleSnapStepUp = snapStep;
			GetDblSliderSettings(PlaneId.YZ).ScaleSnapStepRight = snapStep;
		}

		public void SetZSnapStep(float snapStep)
		{
			GetSglSliderSettings(2, AxisSign.Positive).ScaleSnapStep = snapStep;
			GetSglSliderSettings(2, AxisSign.Negative).ScaleSnapStep = snapStep;
			GetDblSliderSettings(PlaneId.YZ).ScaleSnapStepUp = snapStep;
			GetDblSliderSettings(PlaneId.ZX).ScaleSnapStepRight = snapStep;
		}

		public void SetXYSnapStep(float snapStep)
		{
			GetDblSliderSettings(PlaneId.XY).ProportionalScaleSnapStep = snapStep;
		}

		public void SetYZSnapStep(float snapStep)
		{
			GetDblSliderSettings(PlaneId.YZ).ProportionalScaleSnapStep = snapStep;
		}

		public void SetZXSnapStep(float snapStep)
		{
			GetDblSliderSettings(PlaneId.ZX).ProportionalScaleSnapStep = snapStep;
		}

		public void SetUniformScaleSnapStep(float snapStep)
		{
			_uniformSnapStep = Mathf.Max(0.0001f, snapStep);
		}

		public void SetDragSensitivity(float sensitivity)
		{
			GizmoLineSlider3DSettings[] sglSliderSettings = _sglSliderSettings;
			for (int i = 0; i < sglSliderSettings.Length; i++)
			{
				sglSliderSettings[i].ScaleSensitivity = sensitivity;
			}
		}

		public void ConnectSliderSettings(GizmoLineSlider3D slider, int axisIndex, AxisSign axisSign)
		{
			slider.SharedSettings = GetSglSliderSettings(axisIndex, axisSign);
		}

		public void ConnectDblSliderSettings(GizmoPlaneSlider3D dblSlider, PlaneId planeId)
		{
			dblSlider.SharedSettings = GetDblSliderSettings(planeId);
		}

		private GizmoLineSlider3DSettings GetSglSliderSettings(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _sglSliderSettings[axisIndex];
			}
			return _sglSliderSettings[3 + axisIndex];
		}

		private GizmoPlaneSlider3DSettings GetDblSliderSettings(PlaneId planeId)
		{
			return _dblSliderSettings[(int)planeId];
		}
	}
}
