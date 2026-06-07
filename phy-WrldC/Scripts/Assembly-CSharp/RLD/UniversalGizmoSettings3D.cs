using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class UniversalGizmoSettings3D : Settings
	{
		[SerializeField]
		private UniversalGizmoSettingsCategory _displayCategory;

		[SerializeField]
		private GizmoObjectVertexSnapSettings _mvVertexSnapSettings = new GizmoObjectVertexSnapSettings();

		[SerializeField]
		private GizmoLineSlider3DSettings[] _mvSglSliderSettings = new GizmoLineSlider3DSettings[6];

		[SerializeField]
		private GizmoPlaneSlider3DSettings[] _mvDblSliderSettings = new GizmoPlaneSlider3DSettings[3];

		[SerializeField]
		private float _rtCamRightSnapStep = 15f;

		[SerializeField]
		private float _rtCamUpSnapStep = 15f;

		[SerializeField]
		private GizmoPlaneSlider3DSettings[] _rtSliderSettings = new GizmoPlaneSlider3DSettings[3];

		[SerializeField]
		private GizmoPlaneSlider2DSettings _rtCamLookSliderSettings = new GizmoPlaneSlider2DSettings();

		[SerializeField]
		private float _scUniformSnapStep = 0.1f;

		[SerializeField]
		private GizmoLineSlider3DSettings[] _scSglSliderSettings = new GizmoLineSlider3DSettings[6];

		[SerializeField]
		private GizmoPlaneSlider3DSettings[] _scDblSliderSettings = new GizmoPlaneSlider3DSettings[3];

		public GizmoObjectVertexSnapSettings VertexSnapSettings => _mvVertexSnapSettings;

		public float MvLineSliderHoverEps => _mvSglSliderSettings[0].LineHoverEps;

		public float MvBoxSliderHoverEps => _mvSglSliderSettings[0].BoxHoverEps;

		public float MvCylinderSliderHoverEps => _mvSglSliderSettings[0].CylinderHoverEps;

		public float MvXSnapStep => GetMvSglSliderSettings(0, AxisSign.Positive).OffsetSnapStep;

		public float MvYSnapStep => GetMvSglSliderSettings(1, AxisSign.Positive).OffsetSnapStep;

		public float MvZSnapStep => GetMvSglSliderSettings(2, AxisSign.Positive).OffsetSnapStep;

		public float MvDragSensitivity => _mvSglSliderSettings[0].OffsetSensitivity;

		public float RtAxisLineHoverEps => _rtSliderSettings[0].BorderLineHoverEps;

		public float RtAxisTorusHoverEps => _rtSliderSettings[0].BorderTorusHoverEps;

		public float RtCamLookLineHoverEps => _rtCamLookSliderSettings.BorderLineHoverEps;

		public float RtCamLookThickHoverEps => _rtCamLookSliderSettings.ThickBorderPolyHoverEps;

		public bool RtCanHoverCulledPixels => !_rtSliderSettings[0].IsCircleHoverCullEnabled;

		public GizmoSnapMode RtSnapMode => _rtSliderSettings[0].RotationSnapMode;

		public float RtXSnapStep => _rtSliderSettings[0].RotationSnapStep;

		public float RtYSnapStep => _rtSliderSettings[1].RotationSnapStep;

		public float RtZSnapStep => _rtSliderSettings[2].RotationSnapStep;

		public float RtCamRightSnapStep => _rtCamRightSnapStep;

		public float RtCamUpSnapStep => _rtCamUpSnapStep;

		public float RtCamLookSnapStep => _rtCamLookSliderSettings.RotationSnapStep;

		public float RtDragSensitivity => _rtSliderSettings[0].RotationSensitivity;

		public float ScLineSliderHoverEps => _scSglSliderSettings[0].LineHoverEps;

		public float ScBoxSliderHoverEps => _scSglSliderSettings[0].BoxHoverEps;

		public float ScCylinderSliderHoverEps => _scSglSliderSettings[0].CylinderHoverEps;

		public float ScXSnapStep => GetScSglSliderSettings(0, AxisSign.Positive).ScaleSnapStep;

		public float ScYSnapStep => GetScSglSliderSettings(1, AxisSign.Positive).ScaleSnapStep;

		public float ScZSnapStep => GetScSglSliderSettings(2, AxisSign.Positive).ScaleSnapStep;

		public float ScXYSnapStep => GetScDblSliderSettings(PlaneId.XY).ProportionalScaleSnapStep;

		public float ScYZSnapStep => GetScDblSliderSettings(PlaneId.YZ).ProportionalScaleSnapStep;

		public float ScZXSnapStep => GetScDblSliderSettings(PlaneId.ZX).ProportionalScaleSnapStep;

		public float ScUniformSnapStep => _scUniformSnapStep;

		public float ScDragSensitivity => _scSglSliderSettings[0].ScaleSensitivity;

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

		public UniversalGizmoSettings3D()
		{
			for (int i = 0; i < _mvSglSliderSettings.Length; i++)
			{
				_mvSglSliderSettings[i] = new GizmoLineSlider3DSettings();
			}
			for (int j = 0; j < _mvDblSliderSettings.Length; j++)
			{
				_mvDblSliderSettings[j] = new GizmoPlaneSlider3DSettings();
				_mvDblSliderSettings[j].AreaHoverEps = 0f;
				_mvDblSliderSettings[j].BorderLineHoverEps = 0f;
				_mvDblSliderSettings[j].BorderBoxHoverEps = 0f;
			}
			for (int k = 0; k < _rtSliderSettings.Length; k++)
			{
				_rtSliderSettings[k] = new GizmoPlaneSlider3DSettings();
			}
			SetRtCamLookLineHoverEps(7f);
			SetRtCanHoverCulledPixels(canHover: false);
			SetRtAxisTorusHoverEps(0.4f);
			for (int l = 0; l < _scSglSliderSettings.Length; l++)
			{
				_scSglSliderSettings[l] = new GizmoLineSlider3DSettings();
			}
			for (int m = 0; m < _scDblSliderSettings.Length; m++)
			{
				_scDblSliderSettings[m] = new GizmoPlaneSlider3DSettings();
				_scDblSliderSettings[m].AreaHoverEps = 0f;
				_scDblSliderSettings[m].BorderLineHoverEps = 0f;
				_scDblSliderSettings[m].BorderBoxHoverEps = 0f;
			}
			SetScDragSensitivity(0.6f);
		}

		public void SetMvLineSliderHoverEps(float eps)
		{
			GizmoLineSlider3DSettings[] mvSglSliderSettings = _mvSglSliderSettings;
			for (int i = 0; i < mvSglSliderSettings.Length; i++)
			{
				mvSglSliderSettings[i].LineHoverEps = eps;
			}
		}

		public void SetMvBoxSliderHoverEps(float eps)
		{
			GizmoLineSlider3DSettings[] mvSglSliderSettings = _mvSglSliderSettings;
			for (int i = 0; i < mvSglSliderSettings.Length; i++)
			{
				mvSglSliderSettings[i].BoxHoverEps = eps;
			}
		}

		public void SetMvCylinderSliderHoverEps(float eps)
		{
			GizmoLineSlider3DSettings[] mvSglSliderSettings = _mvSglSliderSettings;
			for (int i = 0; i < mvSglSliderSettings.Length; i++)
			{
				mvSglSliderSettings[i].CylinderHoverEps = eps;
			}
		}

		public void SetMvXSnapStep(float snapStep)
		{
			GetMvSglSliderSettings(0, AxisSign.Positive).OffsetSnapStep = snapStep;
			GetMvSglSliderSettings(0, AxisSign.Negative).OffsetSnapStep = snapStep;
			GetMvDblSliderSettings(PlaneId.XY).OffsetSnapStepRight = snapStep;
			GetMvDblSliderSettings(PlaneId.ZX).OffsetSnapStepUp = snapStep;
		}

		public void SetMvYSnapStep(float snapStep)
		{
			GetMvSglSliderSettings(1, AxisSign.Positive).OffsetSnapStep = snapStep;
			GetMvSglSliderSettings(1, AxisSign.Negative).OffsetSnapStep = snapStep;
			GetMvDblSliderSettings(PlaneId.XY).OffsetSnapStepUp = snapStep;
			GetMvDblSliderSettings(PlaneId.YZ).OffsetSnapStepRight = snapStep;
		}

		public void SetMvZSnapStep(float snapStep)
		{
			GetMvSglSliderSettings(2, AxisSign.Positive).OffsetSnapStep = snapStep;
			GetMvSglSliderSettings(2, AxisSign.Negative).OffsetSnapStep = snapStep;
			GetMvDblSliderSettings(PlaneId.YZ).OffsetSnapStepUp = snapStep;
			GetMvDblSliderSettings(PlaneId.ZX).OffsetSnapStepRight = snapStep;
		}

		public void SetMvDragSensitivity(float sensitivity)
		{
			GizmoLineSlider3DSettings[] mvSglSliderSettings = _mvSglSliderSettings;
			for (int i = 0; i < mvSglSliderSettings.Length; i++)
			{
				mvSglSliderSettings[i].OffsetSensitivity = sensitivity;
			}
			GizmoPlaneSlider3DSettings[] mvDblSliderSettings = _mvDblSliderSettings;
			for (int i = 0; i < mvDblSliderSettings.Length; i++)
			{
				mvDblSliderSettings[i].OffsetSensitivity = sensitivity;
			}
		}

		public void ConnectMvSliderSettings(GizmoLineSlider3D slider, int axisIndex, AxisSign axisSign)
		{
			slider.SharedSettings = GetMvSglSliderSettings(axisIndex, axisSign);
		}

		public void ConnectMvDblSliderSettings(GizmoPlaneSlider3D dblSlider, PlaneId planeId)
		{
			dblSlider.SharedSettings = GetMvDblSliderSettings(planeId);
		}

		public void Inherit(MoveGizmoSettings3D settings)
		{
			SetMvLineSliderHoverEps(settings.LineSliderHoverEps);
			SetMvBoxSliderHoverEps(settings.BoxSliderHoverEps);
			SetMvCylinderSliderHoverEps(settings.CylinderSliderHoverEps);
			SetMvDragSensitivity(settings.DragSensitivity);
			SetMvXSnapStep(settings.XSnapStep);
			SetMvYSnapStep(settings.YSnapStep);
			SetMvZSnapStep(settings.ZSnapStep);
			settings.VertexSnapSettings.Transfer(_mvVertexSnapSettings);
		}

		private GizmoLineSlider3DSettings GetMvSglSliderSettings(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _mvSglSliderSettings[axisIndex];
			}
			return _mvSglSliderSettings[3 + axisIndex];
		}

		private GizmoPlaneSlider3DSettings GetMvDblSliderSettings(PlaneId planeId)
		{
			return _mvDblSliderSettings[(int)planeId];
		}

		public void SetRtCanHoverCulledPixels(bool canHover)
		{
			GizmoPlaneSlider3DSettings[] rtSliderSettings = _rtSliderSettings;
			for (int i = 0; i < rtSliderSettings.Length; i++)
			{
				rtSliderSettings[i].IsCircleHoverCullEnabled = !canHover;
			}
		}

		public void SetRtAxisLineHoverEps(float eps)
		{
			GizmoPlaneSlider3DSettings[] rtSliderSettings = _rtSliderSettings;
			for (int i = 0; i < rtSliderSettings.Length; i++)
			{
				rtSliderSettings[i].BorderLineHoverEps = eps;
			}
		}

		public void SetRtAxisTorusHoverEps(float eps)
		{
			GizmoPlaneSlider3DSettings[] rtSliderSettings = _rtSliderSettings;
			for (int i = 0; i < rtSliderSettings.Length; i++)
			{
				rtSliderSettings[i].BorderTorusHoverEps = eps;
			}
		}

		public void SetRtCamLookLineHoverEps(float eps)
		{
			_rtCamLookSliderSettings.BorderLineHoverEps = eps;
		}

		public void SetRtCamLookThickHoverEps(float eps)
		{
			_rtCamLookSliderSettings.ThickBorderPolyHoverEps = eps;
		}

		public void SetRtAxisSnapStep(int axisIndex, float snapStep)
		{
			_rtSliderSettings[axisIndex].RotationSnapStep = snapStep;
		}

		public void SetRtCamRightSnapStep(float snapStep)
		{
			_rtCamRightSnapStep = Mathf.Max(0.0001f, snapStep);
		}

		public void SetRtCamUpSnapStep(float snapStep)
		{
			_rtCamUpSnapStep = Mathf.Max(0.0001f, snapStep);
		}

		public void SetRtCamLookSnapStep(float snapStep)
		{
			_rtCamLookSliderSettings.RotationSnapStep = snapStep;
		}

		public void SetRtSnapMode(GizmoSnapMode snapMode)
		{
			GizmoPlaneSlider3DSettings[] rtSliderSettings = _rtSliderSettings;
			for (int i = 0; i < rtSliderSettings.Length; i++)
			{
				rtSliderSettings[i].RotationSnapMode = snapMode;
			}
			_rtCamLookSliderSettings.RotationSnapMode = snapMode;
		}

		public void SetRtDragSensitivity(float sensitivity)
		{
			GizmoPlaneSlider3DSettings[] rtSliderSettings = _rtSliderSettings;
			for (int i = 0; i < rtSliderSettings.Length; i++)
			{
				rtSliderSettings[i].RotationSensitivity = sensitivity;
			}
			_rtCamLookSliderSettings.RotationSensitivity = sensitivity;
		}

		public void ConnectRtSliderSettings(GizmoPlaneSlider3D slider, int axisIndex)
		{
			slider.SharedSettings = _rtSliderSettings[axisIndex];
		}

		public void ConnectRtCamLookSliderSettings(GizmoPlaneSlider2D slider)
		{
			slider.SharedSettings = _rtCamLookSliderSettings;
		}

		public void Inherit(RotationGizmoSettings3D settings)
		{
			SetRtAxisLineHoverEps(settings.AxisLineHoverEps);
			SetRtAxisTorusHoverEps(settings.AxisTorusHoverEps);
			SetRtCamLookThickHoverEps(settings.CamLookThickHoverEps);
			SetRtCamLookLineHoverEps(settings.CamLookLineHoverEps);
			SetRtCamLookSnapStep(settings.CamLookSnapStep);
			SetRtCamRightSnapStep(settings.CamRightSnapStep);
			SetRtCamUpSnapStep(settings.CamUpSnapStep);
			SetRtCanHoverCulledPixels(settings.CanHoverCulledPixels);
			SetRtDragSensitivity(settings.DragSensitivity);
			SetRtSnapMode(settings.SnapMode);
			SetRtAxisSnapStep(0, settings.XSnapStep);
			SetRtAxisSnapStep(1, settings.YSnapStep);
			SetRtAxisSnapStep(2, settings.ZSnapStep);
		}

		public void SetScLineSliderHoverEps(float eps)
		{
			GizmoLineSlider3DSettings[] scSglSliderSettings = _scSglSliderSettings;
			for (int i = 0; i < scSglSliderSettings.Length; i++)
			{
				scSglSliderSettings[i].LineHoverEps = eps;
			}
		}

		public void SetScBoxSliderHoverEps(float eps)
		{
			GizmoLineSlider3DSettings[] scSglSliderSettings = _scSglSliderSettings;
			for (int i = 0; i < scSglSliderSettings.Length; i++)
			{
				scSglSliderSettings[i].BoxHoverEps = eps;
			}
		}

		public void SetScCylinderSliderHoverEps(float eps)
		{
			GizmoLineSlider3DSettings[] scSglSliderSettings = _scSglSliderSettings;
			for (int i = 0; i < scSglSliderSettings.Length; i++)
			{
				scSglSliderSettings[i].CylinderHoverEps = eps;
			}
		}

		public void SetScXSnapStep(float snapStep)
		{
			GetScSglSliderSettings(0, AxisSign.Positive).ScaleSnapStep = snapStep;
			GetScSglSliderSettings(0, AxisSign.Negative).ScaleSnapStep = snapStep;
			GetScDblSliderSettings(PlaneId.XY).ScaleSnapStepRight = snapStep;
			GetScDblSliderSettings(PlaneId.ZX).ScaleSnapStepUp = snapStep;
		}

		public void SetScYSnapStep(float snapStep)
		{
			GetScSglSliderSettings(1, AxisSign.Positive).ScaleSnapStep = snapStep;
			GetScSglSliderSettings(1, AxisSign.Negative).ScaleSnapStep = snapStep;
			GetScDblSliderSettings(PlaneId.XY).ScaleSnapStepUp = snapStep;
			GetScDblSliderSettings(PlaneId.YZ).ScaleSnapStepRight = snapStep;
		}

		public void SetScZSnapStep(float snapStep)
		{
			GetScSglSliderSettings(2, AxisSign.Positive).ScaleSnapStep = snapStep;
			GetScSglSliderSettings(2, AxisSign.Negative).ScaleSnapStep = snapStep;
			GetScDblSliderSettings(PlaneId.YZ).ScaleSnapStepUp = snapStep;
			GetScDblSliderSettings(PlaneId.ZX).ScaleSnapStepRight = snapStep;
		}

		public void SetScXYSnapStep(float snapStep)
		{
			GetScDblSliderSettings(PlaneId.XY).ProportionalScaleSnapStep = snapStep;
		}

		public void SetScYZSnapStep(float snapStep)
		{
			GetScDblSliderSettings(PlaneId.YZ).ProportionalScaleSnapStep = snapStep;
		}

		public void SetScZXSnapStep(float snapStep)
		{
			GetScDblSliderSettings(PlaneId.ZX).ProportionalScaleSnapStep = snapStep;
		}

		public void SetScUniformScaleSnapStep(float snapStep)
		{
			_scUniformSnapStep = Mathf.Max(0.0001f, snapStep);
		}

		public void SetScDragSensitivity(float sensitivity)
		{
			GizmoLineSlider3DSettings[] scSglSliderSettings = _scSglSliderSettings;
			for (int i = 0; i < scSglSliderSettings.Length; i++)
			{
				scSglSliderSettings[i].ScaleSensitivity = sensitivity;
			}
		}

		public void ConnectScSliderSettings(GizmoLineSlider3D slider, int axisIndex, AxisSign axisSign)
		{
			slider.SharedSettings = GetScSglSliderSettings(axisIndex, axisSign);
		}

		public void ConnectScDblSliderSettings(GizmoPlaneSlider3D dblSlider, PlaneId planeId)
		{
			dblSlider.SharedSettings = GetScDblSliderSettings(planeId);
		}

		public void Inherit(ScaleGizmoSettings3D settings)
		{
			SetScLineSliderHoverEps(settings.LineSliderHoverEps);
			SetScCylinderSliderHoverEps(settings.CylinderSliderHoverEps);
			SetScBoxSliderHoverEps(settings.BoxSliderHoverEps);
			SetScDragSensitivity(settings.DragSensitivity);
			SetScUniformScaleSnapStep(settings.UniformSnapStep);
			SetScXSnapStep(settings.XSnapStep);
			SetScYSnapStep(settings.YSnapStep);
			SetScZSnapStep(settings.ZSnapStep);
			SetScXYSnapStep(settings.XYSnapStep);
			SetScYZSnapStep(settings.YZSnapStep);
			SetScZXSnapStep(settings.ZXSnapStep);
		}

		private GizmoLineSlider3DSettings GetScSglSliderSettings(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _scSglSliderSettings[axisIndex];
			}
			return _scSglSliderSettings[3 + axisIndex];
		}

		private GizmoPlaneSlider3DSettings GetScDblSliderSettings(PlaneId planeId)
		{
			return _scDblSliderSettings[(int)planeId];
		}
	}
}
