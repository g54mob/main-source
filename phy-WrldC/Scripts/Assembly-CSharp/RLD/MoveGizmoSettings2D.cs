using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class MoveGizmoSettings2D : Settings
	{
		[SerializeField]
		private GizmoPlaneSlider2DSettings _dblSliderSettings = new GizmoPlaneSlider2DSettings();

		[SerializeField]
		private GizmoLineSlider2DSettings[] _sglSliderSettings = new GizmoLineSlider2DSettings[4];

		public float LineSliderHoverEps => _sglSliderSettings[0].LineHoverEps;

		public float BoxSliderHoverEps => _sglSliderSettings[0].BoxHoverEps;

		public float XSnapStep => _dblSliderSettings.OffsetSnapStepRight;

		public float YSnapStep => _dblSliderSettings.OffsetSnapStepUp;

		public float DragSensitivity => _dblSliderSettings.OffsetSensitivity;

		public MoveGizmoSettings2D()
		{
			for (int i = 0; i < _sglSliderSettings.Length; i++)
			{
				_sglSliderSettings[i] = new GizmoLineSlider2DSettings();
			}
		}

		public void SetLineSliderHoverEps(float eps)
		{
			GizmoLineSlider2DSettings[] sglSliderSettings = _sglSliderSettings;
			for (int i = 0; i < sglSliderSettings.Length; i++)
			{
				sglSliderSettings[i].LineHoverEps = eps;
			}
		}

		public void SetBoxSliderHoverEps(float eps)
		{
			GizmoLineSlider2DSettings[] sglSliderSettings = _sglSliderSettings;
			for (int i = 0; i < sglSliderSettings.Length; i++)
			{
				sglSliderSettings[i].BoxHoverEps = eps;
			}
		}

		public void SetXSnapStep(float snapStep)
		{
			GetSliderSettings(0, AxisSign.Positive).OffsetSnapStep = snapStep;
			GetSliderSettings(0, AxisSign.Negative).OffsetSnapStep = snapStep;
			_dblSliderSettings.OffsetSnapStepRight = snapStep;
		}

		public void SetYSnapStep(float snapStep)
		{
			GetSliderSettings(1, AxisSign.Positive).OffsetSnapStep = snapStep;
			GetSliderSettings(1, AxisSign.Negative).OffsetSnapStep = snapStep;
			_dblSliderSettings.OffsetSnapStepUp = snapStep;
		}

		public void SetDragSensitivity(float sensitivity)
		{
			GizmoLineSlider2DSettings[] sglSliderSettings = _sglSliderSettings;
			for (int i = 0; i < sglSliderSettings.Length; i++)
			{
				sglSliderSettings[i].OffsetSensitivity = sensitivity;
			}
			_dblSliderSettings.OffsetSensitivity = sensitivity;
		}

		public void ConnectSliderSettings(GizmoLineSlider2D slider, int axisIndex, AxisSign axisSign)
		{
			slider.SharedSettings = GetSliderSettings(axisIndex, axisSign);
		}

		public void ConnectDblSliderSettings(GizmoPlaneSlider2D slider)
		{
			slider.SharedSettings = _dblSliderSettings;
		}

		private GizmoLineSlider2DSettings GetSliderSettings(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _sglSliderSettings[axisIndex];
			}
			return _sglSliderSettings[2 + axisIndex];
		}
	}
}
