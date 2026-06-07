using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class UniversalGizmoSettings2D : Settings
	{
		[SerializeField]
		private UniversalGizmoSettingsCategory _displayCategory;

		[SerializeField]
		private GizmoPlaneSlider2DSettings _mvDblSliderSettings = new GizmoPlaneSlider2DSettings();

		[SerializeField]
		private GizmoLineSlider2DSettings[] _mvSglSliderSettings = new GizmoLineSlider2DSettings[4];

		public float MvLineSliderHoverEps => _mvSglSliderSettings[0].LineHoverEps;

		public float MvBoxSliderHoverEps => _mvSglSliderSettings[0].BoxHoverEps;

		public float MvXSnapStep => _mvDblSliderSettings.OffsetSnapStepRight;

		public float MvYSnapStep => _mvDblSliderSettings.OffsetSnapStepUp;

		public float MvDragSensitivity => _mvDblSliderSettings.OffsetSensitivity;

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

		public UniversalGizmoSettings2D()
		{
			for (int i = 0; i < _mvSglSliderSettings.Length; i++)
			{
				_mvSglSliderSettings[i] = new GizmoLineSlider2DSettings();
			}
		}

		public void SetMvLineSliderHoverEps(float eps)
		{
			GizmoLineSlider2DSettings[] mvSglSliderSettings = _mvSglSliderSettings;
			for (int i = 0; i < mvSglSliderSettings.Length; i++)
			{
				mvSglSliderSettings[i].LineHoverEps = eps;
			}
		}

		public void SetMvBoxSliderHoverEps(float eps)
		{
			GizmoLineSlider2DSettings[] mvSglSliderSettings = _mvSglSliderSettings;
			for (int i = 0; i < mvSglSliderSettings.Length; i++)
			{
				mvSglSliderSettings[i].BoxHoverEps = eps;
			}
		}

		public void SetMvXSnapStep(float snapStep)
		{
			GetMvSliderSettings(0, AxisSign.Positive).OffsetSnapStep = snapStep;
			GetMvSliderSettings(0, AxisSign.Negative).OffsetSnapStep = snapStep;
			_mvDblSliderSettings.OffsetSnapStepRight = snapStep;
		}

		public void SetMvYSnapStep(float snapStep)
		{
			GetMvSliderSettings(1, AxisSign.Positive).OffsetSnapStep = snapStep;
			GetMvSliderSettings(1, AxisSign.Negative).OffsetSnapStep = snapStep;
			_mvDblSliderSettings.OffsetSnapStepUp = snapStep;
		}

		public void SetMvDragSensitivity(float sensitivity)
		{
			GizmoLineSlider2DSettings[] mvSglSliderSettings = _mvSglSliderSettings;
			for (int i = 0; i < mvSglSliderSettings.Length; i++)
			{
				mvSglSliderSettings[i].OffsetSensitivity = sensitivity;
			}
			_mvDblSliderSettings.OffsetSensitivity = sensitivity;
		}

		public void ConnectMvSliderSettings(GizmoLineSlider2D slider, int axisIndex, AxisSign axisSign)
		{
			slider.SharedSettings = GetMvSliderSettings(axisIndex, axisSign);
		}

		public void ConnectMvDblSliderSettings(GizmoPlaneSlider2D slider)
		{
			slider.SharedSettings = _mvDblSliderSettings;
		}

		public void Inherit(MoveGizmoSettings2D settings)
		{
			SetMvLineSliderHoverEps(settings.LineSliderHoverEps);
			SetMvBoxSliderHoverEps(settings.BoxSliderHoverEps);
			SetMvXSnapStep(settings.XSnapStep);
			SetMvYSnapStep(settings.YSnapStep);
			SetMvDragSensitivity(settings.DragSensitivity);
		}

		private GizmoLineSlider2DSettings GetMvSliderSettings(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _mvSglSliderSettings[axisIndex];
			}
			return _mvSglSliderSettings[2 + axisIndex];
		}
	}
}
