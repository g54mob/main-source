using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class RotationGizmoSettings3D : Settings
	{
		[SerializeField]
		private float _camRightSnapStep = 15f;

		[SerializeField]
		private float _camUpSnapStep = 15f;

		[SerializeField]
		private GizmoPlaneSlider3DSettings[] _sliderSettings = new GizmoPlaneSlider3DSettings[3];

		[SerializeField]
		private GizmoPlaneSlider2DSettings _camLookSliderSettings = new GizmoPlaneSlider2DSettings();

		public float AxisLineHoverEps => _sliderSettings[0].BorderLineHoverEps;

		public float AxisTorusHoverEps => _sliderSettings[0].BorderTorusHoverEps;

		public float CamLookLineHoverEps => _camLookSliderSettings.BorderLineHoverEps;

		public float CamLookThickHoverEps => _camLookSliderSettings.ThickBorderPolyHoverEps;

		public bool CanHoverCulledPixels => !_sliderSettings[0].IsCircleHoverCullEnabled;

		public GizmoSnapMode SnapMode => _sliderSettings[0].RotationSnapMode;

		public float XSnapStep => _sliderSettings[0].RotationSnapStep;

		public float YSnapStep => _sliderSettings[1].RotationSnapStep;

		public float ZSnapStep => _sliderSettings[2].RotationSnapStep;

		public float CamRightSnapStep => _camRightSnapStep;

		public float CamUpSnapStep => _camUpSnapStep;

		public float CamLookSnapStep => _camLookSliderSettings.RotationSnapStep;

		public float DragSensitivity => _sliderSettings[0].RotationSensitivity;

		public RotationGizmoSettings3D()
		{
			for (int i = 0; i < _sliderSettings.Length; i++)
			{
				_sliderSettings[i] = new GizmoPlaneSlider3DSettings();
			}
			SetCamLookLineHoverEps(7f);
			SetCanHoverCulledPixels(canHover: false);
			SetAxisTorusHoverEps(0.4f);
		}

		public void SetCanHoverCulledPixels(bool canHover)
		{
			GizmoPlaneSlider3DSettings[] sliderSettings = _sliderSettings;
			for (int i = 0; i < sliderSettings.Length; i++)
			{
				sliderSettings[i].IsCircleHoverCullEnabled = !canHover;
			}
		}

		public void SetAxisLineHoverEps(float eps)
		{
			GizmoPlaneSlider3DSettings[] sliderSettings = _sliderSettings;
			for (int i = 0; i < sliderSettings.Length; i++)
			{
				sliderSettings[i].BorderLineHoverEps = eps;
			}
		}

		public void SetAxisTorusHoverEps(float eps)
		{
			GizmoPlaneSlider3DSettings[] sliderSettings = _sliderSettings;
			for (int i = 0; i < sliderSettings.Length; i++)
			{
				sliderSettings[i].BorderTorusHoverEps = eps;
			}
		}

		public void SetCamLookLineHoverEps(float eps)
		{
			_camLookSliderSettings.BorderLineHoverEps = eps;
		}

		public void SetCamLookThickHoverEps(float eps)
		{
			_camLookSliderSettings.ThickBorderPolyHoverEps = eps;
		}

		public void SetAxisSnapStep(int axisIndex, float snapStep)
		{
			_sliderSettings[axisIndex].RotationSnapStep = snapStep;
		}

		public void SetCamRightSnapStep(float snapStep)
		{
			_camRightSnapStep = Mathf.Max(0.0001f, snapStep);
		}

		public void SetCamUpSnapStep(float snapStep)
		{
			_camUpSnapStep = Mathf.Max(0.0001f, snapStep);
		}

		public void SetCamLookSnapStep(float snapStep)
		{
			_camLookSliderSettings.RotationSnapStep = snapStep;
		}

		public void SetSnapMode(GizmoSnapMode snapMode)
		{
			GizmoPlaneSlider3DSettings[] sliderSettings = _sliderSettings;
			for (int i = 0; i < sliderSettings.Length; i++)
			{
				sliderSettings[i].RotationSnapMode = snapMode;
			}
			_camLookSliderSettings.RotationSnapMode = snapMode;
		}

		public void SetDragSensitivity(float sensitivity)
		{
			GizmoPlaneSlider3DSettings[] sliderSettings = _sliderSettings;
			for (int i = 0; i < sliderSettings.Length; i++)
			{
				sliderSettings[i].RotationSensitivity = sensitivity;
			}
			_camLookSliderSettings.RotationSensitivity = sensitivity;
		}

		public void ConnectSliderSettings(GizmoPlaneSlider3D slider, int axisIndex)
		{
			slider.SharedSettings = _sliderSettings[axisIndex];
		}

		public void ConnectCamLookSliderSettings(GizmoPlaneSlider2D slider)
		{
			slider.SharedSettings = _camLookSliderSettings;
		}
	}
}
