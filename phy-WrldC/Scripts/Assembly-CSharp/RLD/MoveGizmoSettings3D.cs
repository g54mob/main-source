using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class MoveGizmoSettings3D : Settings
	{
		[SerializeField]
		private GizmoObjectVertexSnapSettings _vertexSnapSettings = new GizmoObjectVertexSnapSettings();

		[SerializeField]
		private GizmoLineSlider3DSettings[] _sglSliderSettings = new GizmoLineSlider3DSettings[6];

		[SerializeField]
		private GizmoPlaneSlider3DSettings[] _dblSliderSettings = new GizmoPlaneSlider3DSettings[3];

		public GizmoObjectVertexSnapSettings VertexSnapSettings => _vertexSnapSettings;

		public float LineSliderHoverEps => _sglSliderSettings[0].LineHoverEps;

		public float BoxSliderHoverEps => _sglSliderSettings[0].BoxHoverEps;

		public float CylinderSliderHoverEps => _sglSliderSettings[0].CylinderHoverEps;

		public float XSnapStep => GetSglSliderSettings(0, AxisSign.Positive).OffsetSnapStep;

		public float YSnapStep => GetSglSliderSettings(1, AxisSign.Positive).OffsetSnapStep;

		public float ZSnapStep => GetSglSliderSettings(2, AxisSign.Positive).OffsetSnapStep;

		public float DragSensitivity => _sglSliderSettings[0].OffsetSensitivity;

		public MoveGizmoSettings3D()
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
			GetSglSliderSettings(0, AxisSign.Positive).OffsetSnapStep = snapStep;
			GetSglSliderSettings(0, AxisSign.Negative).OffsetSnapStep = snapStep;
			GetDblSliderSettings(PlaneId.XY).OffsetSnapStepRight = snapStep;
			GetDblSliderSettings(PlaneId.ZX).OffsetSnapStepUp = snapStep;
		}

		public void SetYSnapStep(float snapStep)
		{
			GetSglSliderSettings(1, AxisSign.Positive).OffsetSnapStep = snapStep;
			GetSglSliderSettings(1, AxisSign.Negative).OffsetSnapStep = snapStep;
			GetDblSliderSettings(PlaneId.XY).OffsetSnapStepUp = snapStep;
			GetDblSliderSettings(PlaneId.YZ).OffsetSnapStepRight = snapStep;
		}

		public void SetZSnapStep(float snapStep)
		{
			GetSglSliderSettings(2, AxisSign.Positive).OffsetSnapStep = snapStep;
			GetSglSliderSettings(2, AxisSign.Negative).OffsetSnapStep = snapStep;
			GetDblSliderSettings(PlaneId.YZ).OffsetSnapStepUp = snapStep;
			GetDblSliderSettings(PlaneId.ZX).OffsetSnapStepRight = snapStep;
		}

		public void SetDragSensitivity(float sensitivity)
		{
			GizmoLineSlider3DSettings[] sglSliderSettings = _sglSliderSettings;
			for (int i = 0; i < sglSliderSettings.Length; i++)
			{
				sglSliderSettings[i].OffsetSensitivity = sensitivity;
			}
			GizmoPlaneSlider3DSettings[] dblSliderSettings = _dblSliderSettings;
			for (int i = 0; i < dblSliderSettings.Length; i++)
			{
				dblSliderSettings[i].OffsetSensitivity = sensitivity;
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
