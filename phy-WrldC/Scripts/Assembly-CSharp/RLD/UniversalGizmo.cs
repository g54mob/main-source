using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class UniversalGizmo : GizmoBehaviour
	{
		public enum MvVertexSnapState
		{
			SelectingPivot = 0,
			Snapping = 1,
			Inactive = 2
		}

		private GizmoLineSlider3D _mvPXSlider;

		private GizmoLineSlider3D _mvPYSlider;

		private GizmoLineSlider3D _mvPZSlider;

		private GizmoLineSlider3D _mvNXSlider;

		private GizmoLineSlider3D _mvNYSlider;

		private GizmoLineSlider3D _mvNZSlider;

		private GizmoLineSlider3DCollection _mvAxesSliders = new GizmoLineSlider3DCollection();

		private GizmoPlaneSlider3D _mvXYSlider;

		private GizmoPlaneSlider3D _mvYZSlider;

		private GizmoPlaneSlider3D _mvZXSlider;

		private GizmoPlaneSlider3DCollection _mvDblSliders = new GizmoPlaneSlider3DCollection();

		private bool _isMvVertexSnapEnabled;

		private GizmoCap2D _mvVertSnapCap;

		private GizmoObjectVertexSnapDrag3D _mvVertexSnapDrag = new GizmoObjectVertexSnapDrag3D();

		private Vector3 _mvPostVSnapPosRestore;

		private GizmoLineSlider2D _mvP2DModeXSlider;

		private GizmoLineSlider2D _mvP2DModeYSlider;

		private GizmoLineSlider2D _mvN2DModeXSlider;

		private GizmoLineSlider2D _mvN2DModeYSlider;

		private GizmoLineSlider2DCollection _mv2DModeSliders = new GizmoLineSlider2DCollection();

		private GizmoPlaneSlider2D _mv2DModeDblSlider;

		private GizmoPlaneSlider3D _rtXSlider;

		private GizmoPlaneSlider3D _rtYSlider;

		private GizmoPlaneSlider3D _rtZSlider;

		private GizmoPlaneSlider3DCollection _rtAxesSliders = new GizmoPlaneSlider3DCollection();

		private GizmoCap3D _rtMidCap;

		private GizmoDblAxisRotationDrag3D _rtCamXYRotationDrag = new GizmoDblAxisRotationDrag3D();

		private GizmoPlaneSlider2D _rtCamLookSlider;

		private GizmoCap3D _scMidCap;

		private GizmoUniformScaleDrag3D _scUnformScaleDrag = new GizmoUniformScaleDrag3D();

		private GizmoScaleGuide _scScaleGuide = new GizmoScaleGuide();

		private IEnumerable<GameObject> _scScaleGuideTargetObjects;

		private bool _is2DModeEnabled;

		[SerializeField]
		private UniversalGizmoSettings2D _settings2D = new UniversalGizmoSettings2D();

		private UniversalGizmoSettings2D _sharedSettings2D;

		[SerializeField]
		private UniversalGizmoSettings3D _settings3D = new UniversalGizmoSettings3D();

		private UniversalGizmoSettings3D _sharedSettings3D;

		[SerializeField]
		private UniversalGizmoLookAndFeel2D _lookAndFeel2D = new UniversalGizmoLookAndFeel2D();

		private UniversalGizmoLookAndFeel2D _sharedLookAndFeel2D;

		[SerializeField]
		private UniversalGizmoLookAndFeel3D _lookAndFeel3D = new UniversalGizmoLookAndFeel3D();

		private UniversalGizmoLookAndFeel3D _sharedLookAndFeel3D;

		[SerializeField]
		private UniversalGizmoHotkeys _hotkeys = new UniversalGizmoHotkeys();

		private UniversalGizmoHotkeys _sharedHotkeys;

		[SerializeField]
		private bool _useSnapEnableHotkey = true;

		[SerializeField]
		private bool _useVertSnapEnableHotkey = true;

		[SerializeField]
		private bool _use2DModeEnableHotkey = true;

		public UniversalGizmoSettings2D Settings2D
		{
			get
			{
				if (_sharedSettings2D != null)
				{
					return _sharedSettings2D;
				}
				return _settings2D;
			}
		}

		public UniversalGizmoSettings2D SharedSettings2D
		{
			get
			{
				return _sharedSettings2D;
			}
			set
			{
				_sharedSettings2D = value;
				SetupSharedSettings();
			}
		}

		public UniversalGizmoSettings3D Settings3D
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

		public UniversalGizmoSettings3D SharedSettings3D
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

		public UniversalGizmoLookAndFeel2D LookAndFeel2D
		{
			get
			{
				if (_sharedLookAndFeel2D != null)
				{
					return _sharedLookAndFeel2D;
				}
				return _lookAndFeel2D;
			}
		}

		public UniversalGizmoLookAndFeel2D SharedLookAndFeel2D
		{
			get
			{
				return _sharedLookAndFeel2D;
			}
			set
			{
				_sharedLookAndFeel2D = value;
				SetupSharedLookAndFeel();
			}
		}

		public UniversalGizmoLookAndFeel3D LookAndFeel3D
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

		public UniversalGizmoLookAndFeel3D SharedLookAndFeel3D
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

		public UniversalGizmoHotkeys Hotkeys
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

		public UniversalGizmoHotkeys SharedHotkeys
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

		public bool UseVertSnapEnableHotkey
		{
			get
			{
				return _useVertSnapEnableHotkey;
			}
			set
			{
				_useVertSnapEnableHotkey = value;
			}
		}

		public bool Use2DModeEnableHotkey
		{
			get
			{
				return _use2DModeEnableHotkey;
			}
			set
			{
				_use2DModeEnableHotkey = value;
			}
		}

		public MvVertexSnapState GetMvVertexSnapState()
		{
			if (!_isMvVertexSnapEnabled)
			{
				return MvVertexSnapState.Inactive;
			}
			if (_mvVertexSnapDrag.IsActive)
			{
				return MvVertexSnapState.Snapping;
			}
			return MvVertexSnapState.SelectingPivot;
		}

		public float GetMvZoomFactor(Vector3 position)
		{
			if (!LookAndFeel3D.MvUseZoomFactor)
			{
				return 1f;
			}
			return base.Gizmo.GetWorkCamera().EstimateZoomFactor(position);
		}

		public float GetMvZoomFactor(Vector3 position, Camera camera)
		{
			if (!LookAndFeel3D.MvUseZoomFactor)
			{
				return 1f;
			}
			return camera.EstimateZoomFactor(position);
		}

		public float GetRtZoomFactor(Vector3 position)
		{
			if (!LookAndFeel3D.RtUseZoomFactor)
			{
				return 1f;
			}
			return base.Gizmo.GetWorkCamera().EstimateZoomFactor(position);
		}

		public float GetRtZoomFactor(Vector3 position, Camera camera)
		{
			if (!LookAndFeel3D.RtUseZoomFactor)
			{
				return 1f;
			}
			return camera.EstimateZoomFactor(position);
		}

		public float GetScZoomFactor(Vector3 position)
		{
			if (!LookAndFeel3D.ScUseZoomFactor)
			{
				return 1f;
			}
			return base.Gizmo.GetWorkCamera().EstimateZoomFactor(position);
		}

		public float GetScZoomFactor(Vector3 position, Camera camera)
		{
			if (!LookAndFeel3D.ScUseZoomFactor)
			{
				return 1f;
			}
			return camera.EstimateZoomFactor(position);
		}

		public bool IsDraggingMoveHandle()
		{
			if (base.Gizmo.IsDragged)
			{
				return IsMoveHandle(base.Gizmo.DragHandleId);
			}
			return false;
		}

		public bool IsDraggingRotationHandle()
		{
			if (base.Gizmo.IsDragged)
			{
				return IsRotationHandle(base.Gizmo.DragHandleId);
			}
			return false;
		}

		public bool IsDraggingScaleHandle()
		{
			if (base.Gizmo.IsDragged)
			{
				return IsScaleHandle(base.Gizmo.DragHandleId);
			}
			return false;
		}

		public bool IsMoveHandle(int handleId)
		{
			if (!_mvAxesSliders.Contains(handleId) && !_mvAxesSliders.ContainsCapId(handleId) && !_mvDblSliders.Contains(handleId) && !_mv2DModeSliders.Contains(handleId) && !_mv2DModeSliders.ContainsCapId(handleId))
			{
				return _mv2DModeDblSlider.HandleId == handleId;
			}
			return true;
		}

		public bool IsRotationHandle(int handleId)
		{
			if (!_rtAxesSliders.Contains(handleId) && _rtMidCap.HandleId != handleId)
			{
				return _rtCamLookSlider.HandleId == handleId;
			}
			return true;
		}

		public bool IsScaleHandle(int handleId)
		{
			return _scMidCap.HandleId == handleId;
		}

		public bool OwnsHandle(int handleId)
		{
			if (!IsMoveHandle(handleId) && !IsRotationHandle(handleId))
			{
				return IsScaleHandle(handleId);
			}
			return true;
		}

		public void SetSnapEnabled(bool isEnabled)
		{
			_mvAxesSliders.SetSnapEnabled(isEnabled);
			_mv2DModeSliders.SetSnapEnabled(isEnabled);
			_mvDblSliders.SetSnapEnabled(isEnabled);
			_mv2DModeDblSlider.SetSnapEnabled(isEnabled);
			_rtAxesSliders.SetSnapEnabled(isEnabled);
			_rtCamXYRotationDrag.IsSnapEnabled = isEnabled;
			_rtCamLookSlider.SetSnapEnabled(isEnabled);
			_scUnformScaleDrag.IsSnapEnabled = isEnabled;
		}

		public void SetMvVertexSnapEnabled(bool isEnabled)
		{
			if (_isMvVertexSnapEnabled != isEnabled && !_is2DModeEnabled && _isEnabled && !base.Gizmo.IsDragged)
			{
				if (isEnabled)
				{
					_mvVertSnapCap.SetVisible(isVisible: true);
					_mvDblSliders.SetVisible(isVisible: false, includeBorder: true);
					SetRotationHandlesVisible(visible: false);
					SetScaleHandlesVisible(visible: false);
				}
				else
				{
					_mvVertSnapCap.SetVisible(isVisible: false);
					SetScaleHandlesVisible(visible: true);
				}
				_isMvVertexSnapEnabled = isEnabled;
			}
		}

		public void Set2DModeEnabled(bool isEnabled)
		{
			if (_is2DModeEnabled != isEnabled && !_isMvVertexSnapEnabled && _isEnabled && !base.Gizmo.IsDragged)
			{
				if (isEnabled)
				{
					_mv2DModeSliders.SetVisible(visible: true);
					_mv2DModeSliders.Set2DCapsVisible(visible: true);
					_mv2DModeDblSlider.SetVisible(isVisible: true);
					_mv2DModeDblSlider.SetBorderVisible(isVisible: true);
					_mv2DModeSliders.SetOffsetDragOrigin(base.Gizmo.Transform.Position3D);
					_mv2DModeDblSlider.OffsetDragOrigin = base.Gizmo.Transform.Position3D;
					SetMoveHandlesVisible(visible: false);
					SetRotationHandlesVisible(visible: false);
					SetScaleHandlesVisible(visible: false);
					Update2DGizmoPosition();
					Update2DModeHandlePositions();
				}
				else
				{
					Hide2DModeHandles();
					SetScaleHandlesVisible(visible: true);
				}
				_is2DModeEnabled = isEnabled;
			}
		}

		public void SetMvVertexSnapTargetObjects(IEnumerable<GameObject> targetObjects)
		{
			_mvVertexSnapDrag.SetTargetObjects(targetObjects);
		}

		public void SetMvAxesLinesHoverable(bool hoverable)
		{
			_mvPXSlider.SetHoverable(hoverable);
			_mvNXSlider.SetHoverable(hoverable);
			_mvPYSlider.SetHoverable(hoverable);
			_mvNYSlider.SetHoverable(hoverable);
			_mvPZSlider.SetHoverable(hoverable);
			_mvNZSlider.SetHoverable(hoverable);
		}

		public void SetRtMidCapHoverable(bool hoverable)
		{
			_rtMidCap.SetHoverable(hoverable);
		}

		public void SetScaleGuideTargetObjects(IEnumerable<GameObject> targetObjects)
		{
			_scScaleGuideTargetObjects = targetObjects;
		}

		public override void OnAttached()
		{
			_mvXYSlider = new GizmoPlaneSlider3D(base.Gizmo, GizmoHandleId.XYDblSlider);
			_mvYZSlider = new GizmoPlaneSlider3D(base.Gizmo, GizmoHandleId.YZDblSlider);
			_mvZXSlider = new GizmoPlaneSlider3D(base.Gizmo, GizmoHandleId.ZXDblSlider);
			_mvDblSliders.Add(_mvXYSlider);
			_mvDblSliders.Add(_mvYZSlider);
			_mvDblSliders.Add(_mvZXSlider);
			_mvPXSlider = new GizmoLineSlider3D(base.Gizmo, GizmoHandleId.PXSlider, GizmoHandleId.PXCap);
			_mvPXSlider.SetDragChannel(GizmoDragChannel.Offset);
			_mvPXSlider.MapDirection(0, AxisSign.Positive);
			_mvNXSlider = new GizmoLineSlider3D(base.Gizmo, GizmoHandleId.NXSlider, GizmoHandleId.NXCap);
			_mvNXSlider.SetDragChannel(GizmoDragChannel.Offset);
			_mvNXSlider.MapDirection(0, AxisSign.Negative);
			_mvPYSlider = new GizmoLineSlider3D(base.Gizmo, GizmoHandleId.PYSlider, GizmoHandleId.PYCap);
			_mvPYSlider.SetDragChannel(GizmoDragChannel.Offset);
			_mvPYSlider.MapDirection(1, AxisSign.Positive);
			_mvNYSlider = new GizmoLineSlider3D(base.Gizmo, GizmoHandleId.NYSlider, GizmoHandleId.NYCap);
			_mvNYSlider.SetDragChannel(GizmoDragChannel.Offset);
			_mvNYSlider.MapDirection(1, AxisSign.Negative);
			_mvPZSlider = new GizmoLineSlider3D(base.Gizmo, GizmoHandleId.PZSlider, GizmoHandleId.PZCap);
			_mvPZSlider.SetDragChannel(GizmoDragChannel.Offset);
			_mvPZSlider.MapDirection(2, AxisSign.Positive);
			_mvNZSlider = new GizmoLineSlider3D(base.Gizmo, GizmoHandleId.NZSlider, GizmoHandleId.NZCap);
			_mvNZSlider.SetDragChannel(GizmoDragChannel.Offset);
			_mvNZSlider.MapDirection(2, AxisSign.Negative);
			_mvAxesSliders.Add(_mvPXSlider);
			_mvAxesSliders.Add(_mvPYSlider);
			_mvAxesSliders.Add(_mvPZSlider);
			_mvAxesSliders.Add(_mvNXSlider);
			_mvAxesSliders.Add(_mvNYSlider);
			_mvAxesSliders.Add(_mvNZSlider);
			_mvAxesSliders.Make3DHoverPriorityLowerThan(_mvXYSlider.HoverPriority3D);
			_mvAxesSliders.Make3DHoverPriorityLowerThan(_mvYZSlider.HoverPriority3D);
			_mvAxesSliders.Make3DHoverPriorityLowerThan(_mvZXSlider.HoverPriority3D);
			_mvVertSnapCap = new GizmoCap2D(base.Gizmo, GizmoHandleId.VertSnap);
			_mvVertSnapCap.SetVisible(isVisible: false);
			_mvVertSnapCap.DragSession = _mvVertexSnapDrag;
			_mvVertexSnapDrag.AddTargetTransform(base.Gizmo.Transform);
			_mv2DModeDblSlider = new GizmoPlaneSlider2D(base.Gizmo, GizmoHandleId.CamXYSlider);
			_mv2DModeDblSlider.SetDragChannel(GizmoDragChannel.Offset);
			_mv2DModeDblSlider.SetVisible(isVisible: false);
			_mvP2DModeXSlider = new GizmoLineSlider2D(base.Gizmo, GizmoHandleId.PCamXSlider, GizmoHandleId.PCamXCap);
			_mvP2DModeXSlider.SetDragChannel(GizmoDragChannel.Offset);
			_mvP2DModeXSlider.MapDirection(0, AxisSign.Positive);
			_mvP2DModeXSlider.HoverPriority2D.MakeLowerThan(_mv2DModeDblSlider.HoverPriority2D);
			_mvP2DModeYSlider = new GizmoLineSlider2D(base.Gizmo, GizmoHandleId.PCamYSlider, GizmoHandleId.PCamYCap);
			_mvP2DModeYSlider.SetDragChannel(GizmoDragChannel.Offset);
			_mvP2DModeYSlider.MapDirection(1, AxisSign.Positive);
			_mvP2DModeYSlider.HoverPriority2D.MakeLowerThan(_mv2DModeDblSlider.HoverPriority2D);
			_mvN2DModeXSlider = new GizmoLineSlider2D(base.Gizmo, GizmoHandleId.NCamXSlider, GizmoHandleId.NCamXCap);
			_mvN2DModeXSlider.SetDragChannel(GizmoDragChannel.Offset);
			_mvN2DModeXSlider.MapDirection(0, AxisSign.Negative);
			_mvN2DModeXSlider.HoverPriority2D.MakeLowerThan(_mv2DModeDblSlider.HoverPriority2D);
			_mvN2DModeYSlider = new GizmoLineSlider2D(base.Gizmo, GizmoHandleId.NCamYSlider, GizmoHandleId.NCamYCap);
			_mvN2DModeYSlider.SetDragChannel(GizmoDragChannel.Offset);
			_mvN2DModeYSlider.MapDirection(1, AxisSign.Negative);
			_mvN2DModeYSlider.HoverPriority2D.MakeLowerThan(_mv2DModeDblSlider.HoverPriority2D);
			_mv2DModeSliders.Add(_mvP2DModeXSlider);
			_mv2DModeSliders.Add(_mvP2DModeYSlider);
			_mv2DModeSliders.Add(_mvN2DModeXSlider);
			_mv2DModeSliders.Add(_mvN2DModeYSlider);
			Hide2DModeHandles();
			_rtMidCap = new GizmoCap3D(base.Gizmo, GizmoHandleId.CamXYRotation);
			_rtMidCap.DragSession = _rtCamXYRotationDrag;
			_rtCamXYRotationDrag.AddTargetTransform(base.Gizmo.Transform);
			_rtXSlider = new GizmoPlaneSlider3D(base.Gizmo, GizmoHandleId.XRotationSlider);
			_rtXSlider.SetDragChannel(GizmoDragChannel.Rotation);
			_rtXSlider.LocalRotation = Quaternion.Euler(0f, 90f, 0f);
			_rtXSlider.SetVisible(isVisible: false);
			_rtAxesSliders.Add(_rtXSlider);
			_rtYSlider = new GizmoPlaneSlider3D(base.Gizmo, GizmoHandleId.YRotationSlider);
			_rtYSlider.SetDragChannel(GizmoDragChannel.Rotation);
			_rtYSlider.LocalRotation = Quaternion.Euler(90f, 0f, 0f);
			_rtYSlider.SetVisible(isVisible: false);
			_rtAxesSliders.Add(_rtYSlider);
			_rtZSlider = new GizmoPlaneSlider3D(base.Gizmo, GizmoHandleId.ZRotationSlider);
			_rtZSlider.SetDragChannel(GizmoDragChannel.Rotation);
			_rtZSlider.SetVisible(isVisible: false);
			_rtAxesSliders.Add(_rtZSlider);
			_rtCamLookSlider = new GizmoPlaneSlider2D(base.Gizmo, GizmoHandleId.CamZRotation);
			_rtCamLookSlider.SetDragChannel(GizmoDragChannel.Rotation);
			_rtCamLookSlider.SetVisible(isVisible: false);
			_scMidCap = new GizmoCap3D(base.Gizmo, GizmoHandleId.MidScaleCap);
			_scMidCap.DragSession = _scUnformScaleDrag;
			_rtAxesSliders.Make3DHoverPriorityHigherThan(_rtMidCap.HoverPriority3D);
			_mvAxesSliders.Make3DHoverPriorityHigherThan(_rtXSlider.HoverPriority3D);
			_mvDblSliders.Make3DHoverPriorityHigherThan(_mvPXSlider.HoverPriority3D);
			_scMidCap.HoverPriority3D.MakeHigherThan(_mvXYSlider.HoverPriority3D);
			SetupSharedLookAndFeel();
			SetupSharedSettings();
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

		public override void OnGizmoEnabled()
		{
			OnGizmoUpdateBegin();
		}

		public override void OnGizmoUpdateBegin()
		{
			if (UseSnapEnableHotkey)
			{
				SetSnapEnabled(!Hotkeys.EnableSnapping.IsActive());
			}
			if (Use2DModeEnableHotkey)
			{
				Set2DModeEnabled(Hotkeys.Enable2DMode.IsActive());
			}
			Update2DGizmoPosition();
			if (!_is2DModeEnabled)
			{
				bool isMvVertexSnapEnabled = _isMvVertexSnapEnabled;
				if (!isMvVertexSnapEnabled)
				{
					_mvPostVSnapPosRestore = base.Gizmo.Transform.Position3D;
				}
				if (UseVertSnapEnableHotkey)
				{
					SetMvVertexSnapEnabled(Hotkeys.EnableVertexSnapping.IsActive());
				}
				if (isMvVertexSnapEnabled && !_isMvVertexSnapEnabled)
				{
					base.Gizmo.Transform.Position3D = _mvPostVSnapPosRestore;
				}
				if (!base.Gizmo.IsDragged || IsDraggingMoveHandle())
				{
					_mvPXSlider.SetVisible(LookAndFeel3D.IsMvPositiveSliderVisible(0));
					_mvPXSlider.Set3DCapVisible(LookAndFeel3D.IsMvPositiveSliderCapVisible(0));
					_mvPYSlider.SetVisible(LookAndFeel3D.IsMvPositiveSliderVisible(1));
					_mvPYSlider.Set3DCapVisible(LookAndFeel3D.IsMvPositiveSliderCapVisible(1));
					_mvPZSlider.SetVisible(LookAndFeel3D.IsMvPositiveSliderVisible(2));
					_mvPZSlider.Set3DCapVisible(LookAndFeel3D.IsMvPositiveSliderCapVisible(2));
					_mvNXSlider.SetVisible(LookAndFeel3D.IsMvNegativeSliderVisible(0));
					_mvNXSlider.Set3DCapVisible(LookAndFeel3D.IsMvNegativeSliderCapVisible(0));
					_mvNYSlider.SetVisible(LookAndFeel3D.IsMvNegativeSliderVisible(1));
					_mvNYSlider.Set3DCapVisible(LookAndFeel3D.IsMvNegativeSliderCapVisible(1));
					_mvNZSlider.SetVisible(LookAndFeel3D.IsMvNegativeSliderVisible(2));
					_mvNZSlider.Set3DCapVisible(LookAndFeel3D.IsMvNegativeSliderCapVisible(2));
				}
			}
			if (!_isMvVertexSnapEnabled && !_is2DModeEnabled)
			{
				if (!base.Gizmo.IsDragged || IsDraggingMoveHandle())
				{
					_mvXYSlider.SetVisible(LookAndFeel3D.IsMvDblSliderVisible(PlaneId.XY));
					_mvXYSlider.SetBorderVisible(_mvXYSlider.IsVisible);
					_mvYZSlider.SetVisible(LookAndFeel3D.IsMvDblSliderVisible(PlaneId.YZ));
					_mvYZSlider.SetBorderVisible(_mvYZSlider.IsVisible);
					_mvZXSlider.SetVisible(LookAndFeel3D.IsMvDblSliderVisible(PlaneId.ZX));
					_mvZXSlider.SetBorderVisible(_mvZXSlider.IsVisible);
					PlaceMvDblSlidersInSliderPlanes(base.Gizmo.FocusCamera);
				}
			}
			else if (_isMvVertexSnapEnabled)
			{
				if (GetMvVertexSnapState() == MvVertexSnapState.SelectingPivot && _mvVertexSnapDrag.SelectSnapPivotPoint(base.Gizmo))
				{
					base.Gizmo.Transform.Position3D = _mvVertexSnapDrag.SnapPivot;
				}
			}
			else if (_is2DModeEnabled && (!base.Gizmo.IsDragged || IsDraggingMoveHandle()))
			{
				_mvP2DModeXSlider.SetVisible(LookAndFeel2D.IsMvPositiveSliderVisible(0));
				_mvP2DModeXSlider.Set2DCapVisible(LookAndFeel2D.IsMvPositiveSliderCapVisible(0));
				_mvP2DModeYSlider.SetVisible(LookAndFeel2D.IsMvPositiveSliderVisible(1));
				_mvP2DModeYSlider.Set2DCapVisible(LookAndFeel2D.IsMvPositiveSliderCapVisible(1));
				_mvN2DModeXSlider.SetVisible(LookAndFeel2D.IsMvNegativeSliderVisible(0));
				_mvN2DModeXSlider.Set2DCapVisible(LookAndFeel2D.IsMvNegativeSliderCapVisible(0));
				_mvN2DModeYSlider.SetVisible(LookAndFeel2D.IsMvNegativeSliderVisible(1));
				_mvN2DModeYSlider.Set2DCapVisible(LookAndFeel2D.IsMvNegativeSliderCapVisible(1));
				bool isVisible = _mv2DModeDblSlider.IsVisible;
				_mv2DModeDblSlider.SetVisible(LookAndFeel2D.IsMvDblSliderVisible);
				_mv2DModeDblSlider.SetBorderVisible(LookAndFeel2D.IsMvDblSliderVisible);
				if (!isVisible && _mv2DModeDblSlider.IsVisible)
				{
					Update2DModeHandlePositions();
				}
			}
			if (!_is2DModeEnabled && !_isMvVertexSnapEnabled && (!base.Gizmo.IsDragged || IsDraggingRotationHandle()))
			{
				_rtMidCap.SetVisible(LookAndFeel3D.IsRtMidCapVisible);
				_rtCamXYRotationDrag.Sensitivity = Settings3D.RtDragSensitivity;
				_rtXSlider.SetBorderVisible(LookAndFeel3D.IsRtAxisVisible(0));
				_rtYSlider.SetBorderVisible(LookAndFeel3D.IsRtAxisVisible(1));
				_rtZSlider.SetBorderVisible(LookAndFeel3D.IsRtAxisVisible(2));
				_rtCamLookSlider.SetBorderVisible(LookAndFeel3D.IsRtCamLookSliderVisible);
				if (_rtCamLookSlider.IsBorderVisible)
				{
					UpdateRtCamLookSlider(base.Gizmo.FocusCamera);
				}
			}
			_scMidCap.SetVisible(LookAndFeel3D.IsScMidCapVisible && !_is2DModeEnabled);
			_scUnformScaleDrag.Sensitivity = Settings3D.ScDragSensitivity;
		}

		public override void OnGizmoRender(Camera camera)
		{
			if (MonoSingleton<RTGizmosEngine>.Get.NumRenderCameras > 1)
			{
				_mvAxesSliders.ApplyZoomFactor(camera);
				if (!_isMvVertexSnapEnabled && !_is2DModeEnabled)
				{
					_mvDblSliders.ApplyZoomFactor(camera);
					PlaceMvDblSlidersInSliderPlanes(camera);
				}
				Update2DGizmoPosition();
				if (_is2DModeEnabled)
				{
					Update2DModeHandlePositions();
				}
				_rtMidCap.ApplyZoomFactor(camera);
				_rtAxesSliders.ApplyZoomFactor(camera);
				if (_rtCamLookSlider.IsBorderVisible)
				{
					UpdateRtCamLookSlider(camera);
				}
				_scMidCap.ApplyZoomFactor(camera);
			}
			_rtXSlider.Render(camera);
			_rtYSlider.Render(camera);
			_rtZSlider.Render(camera);
			_rtMidCap.Render(camera);
			foreach (GizmoLineSlider3D renderSortedSlider in _mvAxesSliders.GetRenderSortedSliders(camera))
			{
				renderSortedSlider.Render(camera);
			}
			_rtCamLookSlider.Render(camera);
			_mvXYSlider.Render(camera);
			_mvYZSlider.Render(camera);
			_mvZXSlider.Render(camera);
			_scMidCap.Render(camera);
			_mvVertSnapCap.Render(camera);
			_mv2DModeSliders.Render(camera);
			_mv2DModeDblSlider.Render(camera);
			if (LookAndFeel3D.IsScScaleGuideVisible && base.Gizmo.IsDragged && IsScaleHandle(base.Gizmo.DragHandleId))
			{
				_scScaleGuide.Render(GameObjectEx.FilterParentsOnly(_scScaleGuideTargetObjects), camera);
			}
		}

		public override void OnGizmoDragUpdate(int handleId)
		{
			if (_isMvVertexSnapEnabled)
			{
				_mvPostVSnapPosRestore += base.Gizmo.RelativeDragOffset;
			}
		}

		public override void OnGizmoDragBegin(int handleId)
		{
			if (IsMoveHandle(handleId))
			{
				SetRotationHandlesVisible(visible: false);
				SetScaleHandlesVisible(visible: false);
			}
			else if (IsRotationHandle(handleId))
			{
				SetMoveHandlesVisible(visible: false);
				SetScaleHandlesVisible(visible: false);
			}
			else if (IsScaleHandle(handleId))
			{
				SetMoveHandlesVisible(visible: false);
				SetRotationHandlesVisible(visible: false);
			}
		}

		public override void OnGizmoDragEnd(int handleId)
		{
			if (!IsScaleHandle(handleId) && !_is2DModeEnabled)
			{
				SetScaleHandlesVisible(visible: true);
			}
		}

		public override void OnGizmoAttemptHandleDragBegin(int handleId)
		{
			if (handleId == _rtMidCap.HandleId)
			{
				GizmoDblAxisRotationDrag3D.WorkData workData = new GizmoDblAxisRotationDrag3D.WorkData
				{
					Axis0 = base.Gizmo.FocusCamera.transform.up,
					Axis1 = base.Gizmo.FocusCamera.transform.right,
					ScreenAxis0 = -Vector3.right,
					ScreenAxis1 = Vector3.up,
					SnapMode = Settings3D.RtSnapMode,
					SnapStep0 = Settings3D.RtCamUpSnapStep,
					SnapStep1 = Settings3D.RtCamRightSnapStep
				};
				_rtCamXYRotationDrag.SetWorkData(workData);
			}
			else if (handleId == _scMidCap.HandleId)
			{
				GizmoUniformScaleDrag3D.WorkData workData2 = new GizmoUniformScaleDrag3D.WorkData
				{
					DragOrigin = _scMidCap.Position,
					CameraRight = base.Gizmo.FocusCamera.transform.right,
					CameraUp = base.Gizmo.FocusCamera.transform.up,
					SnapStep = Settings3D.ScUniformSnapStep
				};
				_scUnformScaleDrag.SetWorkData(workData2);
			}
		}

		private void PlaceMvDblSlidersInSliderPlanes(Camera camera)
		{
			if (_mvXYSlider.IsVisible)
			{
				_mvXYSlider.MakeSliderPlane(base.Gizmo.Transform, PlaneId.XY, _mvPXSlider, _mvPYSlider, camera);
			}
			if (_mvYZSlider.IsVisible)
			{
				_mvYZSlider.MakeSliderPlane(base.Gizmo.Transform, PlaneId.YZ, _mvPYSlider, _mvPZSlider, camera);
			}
			if (_mvZXSlider.IsVisible)
			{
				_mvZXSlider.MakeSliderPlane(base.Gizmo.Transform, PlaneId.ZX, _mvPZSlider, _mvPXSlider, camera);
			}
		}

		private void SetupSharedLookAndFeel()
		{
			LookAndFeel3D.ConnectMvSliderLookAndFeel(_mvPXSlider, 0, AxisSign.Positive);
			LookAndFeel3D.ConnectMvSliderLookAndFeel(_mvPYSlider, 1, AxisSign.Positive);
			LookAndFeel3D.ConnectMvSliderLookAndFeel(_mvPZSlider, 2, AxisSign.Positive);
			LookAndFeel3D.ConnectMvSliderLookAndFeel(_mvNXSlider, 0, AxisSign.Negative);
			LookAndFeel3D.ConnectMvSliderLookAndFeel(_mvNYSlider, 1, AxisSign.Negative);
			LookAndFeel3D.ConnectMvSliderLookAndFeel(_mvNZSlider, 2, AxisSign.Negative);
			LookAndFeel3D.ConnectMvDblSliderLookAndFeel(_mvXYSlider, PlaneId.XY);
			LookAndFeel3D.ConnectMvDblSliderLookAndFeel(_mvYZSlider, PlaneId.YZ);
			LookAndFeel3D.ConnectMvDblSliderLookAndFeel(_mvZXSlider, PlaneId.ZX);
			LookAndFeel3D.ConnectMvVertSnapCapLookAndFeel(_mvVertSnapCap);
			LookAndFeel2D.ConnectMvSliderLookAndFeel(_mvP2DModeXSlider, 0, AxisSign.Positive);
			LookAndFeel2D.ConnectMvSliderLookAndFeel(_mvP2DModeYSlider, 1, AxisSign.Positive);
			LookAndFeel2D.ConnectMvSliderLookAndFeel(_mvN2DModeXSlider, 0, AxisSign.Negative);
			LookAndFeel2D.ConnectMvSliderLookAndFeel(_mvN2DModeYSlider, 1, AxisSign.Negative);
			LookAndFeel2D.ConnectMvDblSliderLookAndFeel(_mv2DModeDblSlider);
			LookAndFeel3D.ConnectRtSliderLookAndFeel(_rtXSlider, 0);
			LookAndFeel3D.ConnectRtSliderLookAndFeel(_rtYSlider, 1);
			LookAndFeel3D.ConnectRtSliderLookAndFeel(_rtZSlider, 2);
			LookAndFeel3D.ConnectRtCamLookSliderLookAndFeel(_rtCamLookSlider);
			LookAndFeel3D.ConnectRtMidCapLookAndFeel(_rtMidCap);
			LookAndFeel3D.ConnectScMidCapLookAndFeel(_scMidCap);
			LookAndFeel3D.ConnectScGizmoScaleGuideLookAndFeel(_scScaleGuide);
		}

		private void SetupSharedSettings()
		{
			Settings3D.ConnectMvSliderSettings(_mvPXSlider, 0, AxisSign.Positive);
			Settings3D.ConnectMvSliderSettings(_mvPYSlider, 1, AxisSign.Positive);
			Settings3D.ConnectMvSliderSettings(_mvPZSlider, 2, AxisSign.Positive);
			Settings3D.ConnectMvSliderSettings(_mvNXSlider, 0, AxisSign.Negative);
			Settings3D.ConnectMvSliderSettings(_mvNYSlider, 1, AxisSign.Negative);
			Settings3D.ConnectMvSliderSettings(_mvNZSlider, 2, AxisSign.Negative);
			Settings3D.ConnectMvDblSliderSettings(_mvXYSlider, PlaneId.XY);
			Settings3D.ConnectMvDblSliderSettings(_mvYZSlider, PlaneId.YZ);
			Settings3D.ConnectMvDblSliderSettings(_mvZXSlider, PlaneId.ZX);
			Settings2D.ConnectMvSliderSettings(_mvP2DModeXSlider, 0, AxisSign.Positive);
			Settings2D.ConnectMvSliderSettings(_mvP2DModeYSlider, 1, AxisSign.Positive);
			Settings2D.ConnectMvSliderSettings(_mvN2DModeXSlider, 0, AxisSign.Negative);
			Settings2D.ConnectMvSliderSettings(_mvN2DModeYSlider, 1, AxisSign.Negative);
			Settings2D.ConnectMvDblSliderSettings(_mv2DModeDblSlider);
			_mvVertexSnapDrag.Settings = Settings3D.VertexSnapSettings;
			Settings3D.ConnectRtSliderSettings(_rtXSlider, 0);
			Settings3D.ConnectRtSliderSettings(_rtYSlider, 1);
			Settings3D.ConnectRtSliderSettings(_rtZSlider, 2);
			Settings3D.ConnectRtCamLookSliderSettings(_rtCamLookSlider);
		}

		private void Update2DGizmoPosition()
		{
			base.Gizmo.Transform.Position2D = base.Gizmo.GetWorkCamera().WorldToScreenPoint(base.Gizmo.Transform.Position3D);
		}

		private void Update2DModeHandlePositions()
		{
			if (LookAndFeel2D.IsMvDblSliderVisible)
			{
				_mvP2DModeXSlider.StartPosition = _mv2DModeDblSlider.GetRealExtentPoint(Shape2DExtentPoint.Right);
				_mvP2DModeYSlider.StartPosition = _mv2DModeDblSlider.GetRealExtentPoint(Shape2DExtentPoint.Top);
				_mvN2DModeXSlider.StartPosition = _mv2DModeDblSlider.GetRealExtentPoint(Shape2DExtentPoint.Left);
				_mvN2DModeYSlider.StartPosition = _mv2DModeDblSlider.GetRealExtentPoint(Shape2DExtentPoint.Bottom);
			}
			else
			{
				Vector2 position2D = base.Gizmo.Transform.Position2D;
				_mvP2DModeXSlider.StartPosition = position2D;
				_mvP2DModeYSlider.StartPosition = position2D;
				_mvN2DModeXSlider.StartPosition = position2D;
				_mvN2DModeYSlider.StartPosition = position2D;
			}
		}

		private void OnGizmoTransformChanged(GizmoTransform transform, GizmoTransform.ChangeData changeData)
		{
			Update2DGizmoPosition();
			if (changeData.ChangeReason == GizmoTransform.ChangeReason.ParentChange || changeData.TRSDimension == GizmoDimension.Dim3D)
			{
				UpdateRtCamLookSlider(base.Gizmo.GetWorkCamera());
			}
		}

		private void Hide2DModeHandles()
		{
			_mv2DModeSliders.SetVisible(visible: false);
			_mv2DModeSliders.Set2DCapsVisible(visible: false);
			_mv2DModeDblSlider.SetVisible(isVisible: false);
			_mv2DModeDblSlider.SetBorderVisible(isVisible: false);
		}

		private void UpdateRtCamLookSlider(Camera camera)
		{
			float zoomFactor = _rtMidCap.GetZoomFactor(camera);
			_rtCamLookSlider.MakePolySphereBorder(base.Gizmo.Transform.Position3D, _rtMidCap.GetRealSphereRadius(zoomFactor) + zoomFactor * LookAndFeel3D.RtCamLookSliderRadiusOffset, 100, camera);
		}

		private void SetMoveHandlesVisible(bool visible)
		{
			_mvDblSliders.SetVisible(visible, includeBorder: true);
			_mvAxesSliders.SetVisible(visible);
			_mvAxesSliders.Set3DCapsVisible(visible);
		}

		private void SetRotationHandlesVisible(bool visible)
		{
			_rtAxesSliders.SetBorderVisible(visible);
			_rtMidCap.SetVisible(visible);
			_rtCamLookSlider.SetBorderVisible(visible);
		}

		private void SetScaleHandlesVisible(bool visible)
		{
			_scMidCap.SetVisible(visible);
		}
	}
}
