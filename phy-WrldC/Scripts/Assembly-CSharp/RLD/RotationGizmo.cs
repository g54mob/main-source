using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class RotationGizmo : GizmoBehaviour
	{
		private GizmoPlaneSlider3D _xSlider;

		private GizmoPlaneSlider3D _ySlider;

		private GizmoPlaneSlider3D _zSlider;

		private GizmoPlaneSlider3DCollection _axesSliders = new GizmoPlaneSlider3DCollection();

		private GizmoCap3D _midCap;

		private GizmoDblAxisRotationDrag3D _camXYRotationDrag = new GizmoDblAxisRotationDrag3D();

		private GizmoPlaneSlider2D _camLookSlider;

		[SerializeField]
		private RotationGizmoHotkeys _hotkeys = new RotationGizmoHotkeys();

		[SerializeField]
		private RotationGizmoSettings3D _settings3D = new RotationGizmoSettings3D();

		[SerializeField]
		private RotationGizmoLookAndFeel3D _lookAndFeel3D = new RotationGizmoLookAndFeel3D();

		[SerializeField]
		private bool _useSnapEnableHotkey = true;

		private RotationGizmoHotkeys _sharedHotkeys;

		private RotationGizmoSettings3D _sharedSettings3D;

		private RotationGizmoLookAndFeel3D _sharedLookAndFeel3D;

		public RotationGizmoSettings3D Settings3D
		{
			get
			{
				if (_sharedSettings3D != null)
				{
					return _sharedSettings3D;
				}
				return _settings3D;
			}
		}

		public RotationGizmoLookAndFeel3D LookAndFeel3D
		{
			get
			{
				if (_sharedLookAndFeel3D != null)
				{
					return _sharedLookAndFeel3D;
				}
				return _lookAndFeel3D;
			}
		}

		public RotationGizmoHotkeys Hotkeys
		{
			get
			{
				if (_sharedHotkeys != null)
				{
					return _sharedHotkeys;
				}
				return _hotkeys;
			}
		}

		public RotationGizmoSettings3D SharedSettings3D
		{
			get
			{
				return _sharedSettings3D;
			}
			set
			{
				_sharedSettings3D = value;
				SetupSharedSettings();
			}
		}

		public RotationGizmoLookAndFeel3D SharedLookAndFeel3D
		{
			get
			{
				return _sharedLookAndFeel3D;
			}
			set
			{
				_sharedLookAndFeel3D = value;
				SetupSharedLookAndFeel();
			}
		}

		public RotationGizmoHotkeys SharedHotkeys
		{
			get
			{
				return _sharedHotkeys;
			}
			set
			{
				_sharedHotkeys = value;
			}
		}

		public bool UseSnapEnableHotkey
		{
			get
			{
				return _useSnapEnableHotkey;
			}
			set
			{
				_useSnapEnableHotkey = value;
			}
		}

		public float GetZoomFactor(Vector3 position)
		{
			if (!LookAndFeel3D.UseZoomFactor)
			{
				return 1f;
			}
			return base.Gizmo.GetWorkCamera().EstimateZoomFactor(position);
		}

		public float GetZoomFactor(Vector3 position, Camera camera)
		{
			if (!LookAndFeel3D.UseZoomFactor)
			{
				return 1f;
			}
			return camera.EstimateZoomFactor(position);
		}

		public bool OwnsHandle(int handleId)
		{
			if (!_axesSliders.Contains(handleId))
			{
				return _midCap.HandleId == handleId;
			}
			return true;
		}

		public void SetMidCapHoverable(bool hoverable)
		{
			_midCap.SetHoverable(hoverable);
		}

		public void SetSnapEnabled(bool isEnabled)
		{
			_axesSliders.SetSnapEnabled(isEnabled);
			_camXYRotationDrag.IsSnapEnabled = isEnabled;
			_camLookSlider.SetSnapEnabled(isEnabled);
		}

		public override void OnGizmoEnabled()
		{
			OnGizmoUpdateBegin();
		}

		public override void OnDetached()
		{
			base.Gizmo.Transform.Changed -= OnGizmoTransformChanged;
		}

		public override void OnEnabled()
		{
			base.Gizmo.Transform.Changed += OnGizmoTransformChanged;
		}

		public override void OnDisabled()
		{
			base.Gizmo.Transform.Changed -= OnGizmoTransformChanged;
		}

		public override void OnAttached()
		{
			_midCap = new GizmoCap3D(base.Gizmo, GizmoHandleId.CamXYRotation);
			_midCap.DragSession = _camXYRotationDrag;
			_camXYRotationDrag.AddTargetTransform(base.Gizmo.Transform);
			_xSlider = new GizmoPlaneSlider3D(base.Gizmo, GizmoHandleId.XRotationSlider);
			_xSlider.SetDragChannel(GizmoDragChannel.Rotation);
			_xSlider.LocalRotation = Quaternion.Euler(0f, 90f, 0f);
			_xSlider.SetVisible(isVisible: false);
			_axesSliders.Add(_xSlider);
			_ySlider = new GizmoPlaneSlider3D(base.Gizmo, GizmoHandleId.YRotationSlider);
			_ySlider.SetDragChannel(GizmoDragChannel.Rotation);
			_ySlider.LocalRotation = Quaternion.Euler(90f, 0f, 0f);
			_ySlider.SetVisible(isVisible: false);
			_axesSliders.Add(_ySlider);
			_zSlider = new GizmoPlaneSlider3D(base.Gizmo, GizmoHandleId.ZRotationSlider);
			_zSlider.SetDragChannel(GizmoDragChannel.Rotation);
			_zSlider.SetVisible(isVisible: false);
			_axesSliders.Add(_zSlider);
			_axesSliders.Make3DHoverPriorityHigherThan(_midCap.HoverPriority3D);
			_camLookSlider = new GizmoPlaneSlider2D(base.Gizmo, GizmoHandleId.CamZRotation);
			_camLookSlider.SetDragChannel(GizmoDragChannel.Rotation);
			_camLookSlider.SetVisible(isVisible: false);
			SetupSharedLookAndFeel();
			SetupSharedSettings();
		}

		public override void OnGizmoUpdateBegin()
		{
			if (UseSnapEnableHotkey)
			{
				SetSnapEnabled(!Hotkeys.EnableSnapping.IsActive());
			}
			_midCap.SetVisible(LookAndFeel3D.IsMidCapVisible);
			_camXYRotationDrag.Sensitivity = Settings3D.DragSensitivity;
			_xSlider.SetBorderVisible(LookAndFeel3D.IsAxisVisible(0));
			_ySlider.SetBorderVisible(LookAndFeel3D.IsAxisVisible(1));
			_zSlider.SetBorderVisible(LookAndFeel3D.IsAxisVisible(2));
			_camLookSlider.SetBorderVisible(LookAndFeel3D.IsCamLookSliderVisible);
			if (_camLookSlider.IsBorderVisible)
			{
				UpdateCamLookSlider(base.Gizmo.FocusCamera);
			}
		}

		public override void OnGizmoRender(Camera camera)
		{
			if (MonoSingleton<RTGizmosEngine>.Get.NumRenderCameras > 1)
			{
				_midCap.ApplyZoomFactor(camera);
				_axesSliders.ApplyZoomFactor(camera);
				if (_camLookSlider.IsBorderVisible)
				{
					UpdateCamLookSlider(camera);
				}
			}
			_xSlider.Render(camera);
			_ySlider.Render(camera);
			_zSlider.Render(camera);
			_midCap.Render(camera);
			_camLookSlider.Render(camera);
		}

		public override void OnGizmoAttemptHandleDragBegin(int handleId)
		{
			if (handleId == _midCap.HandleId)
			{
				GizmoDblAxisRotationDrag3D.WorkData workData = new GizmoDblAxisRotationDrag3D.WorkData
				{
					Axis0 = base.Gizmo.FocusCamera.transform.up,
					Axis1 = base.Gizmo.FocusCamera.transform.right,
					ScreenAxis0 = -Vector3.right,
					ScreenAxis1 = Vector3.up,
					SnapMode = Settings3D.SnapMode,
					SnapStep0 = Settings3D.CamUpSnapStep,
					SnapStep1 = Settings3D.CamRightSnapStep
				};
				_camXYRotationDrag.SetWorkData(workData);
			}
		}

		private void UpdateCamLookSlider(Camera camera)
		{
			float zoomFactor = _midCap.GetZoomFactor(camera);
			_camLookSlider.MakePolySphereBorder(base.Gizmo.Transform.Position3D, _midCap.GetRealSphereRadius(zoomFactor) + zoomFactor * LookAndFeel3D.CamLookSliderRadiusOffset, 100, camera);
		}

		private void SetupSharedLookAndFeel()
		{
			LookAndFeel3D.ConnectSliderLookAndFeel(_xSlider, 0);
			LookAndFeel3D.ConnectSliderLookAndFeel(_ySlider, 1);
			LookAndFeel3D.ConnectSliderLookAndFeel(_zSlider, 2);
			LookAndFeel3D.ConnectCamLookSliderLookAndFeel(_camLookSlider);
			LookAndFeel3D.ConnectMidCapLookAndFeel(_midCap);
		}

		private void SetupSharedSettings()
		{
			Settings3D.ConnectSliderSettings(_xSlider, 0);
			Settings3D.ConnectSliderSettings(_ySlider, 1);
			Settings3D.ConnectSliderSettings(_zSlider, 2);
			Settings3D.ConnectCamLookSliderSettings(_camLookSlider);
		}

		private void OnGizmoTransformChanged(GizmoTransform gizmoTransform, GizmoTransform.ChangeData changeData)
		{
			if (changeData.ChangeReason == GizmoTransform.ChangeReason.ParentChange || changeData.TRSDimension == GizmoDimension.Dim3D)
			{
				UpdateCamLookSlider(base.Gizmo.GetWorkCamera());
			}
		}
	}
}
