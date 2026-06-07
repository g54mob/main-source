using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class GizmoLineSlider3D : GizmoSlider
	{
		private SegmentShape3D _segment = new SegmentShape3D();

		private BoxShape3D _box = new BoxShape3D();

		private CylinderShape3D _cylinder = new CylinderShape3D();

		private int _segmentIndex;

		private int _boxIndex;

		private int _cylinderIndex;

		private IGizmoLineSlider3DController[] _controllers = new IGizmoLineSlider3DController[Enum.GetValues(typeof(GizmoLine3DType)).Length];

		private GizmoLineSlider3DControllerData _controllerData = new GizmoLineSlider3DControllerData();

		private GizmoDragChannel _dragChannel = GizmoDragChannel.Scale;

		private GizmoSglAxisOffsetDrag3D _offsetDrag = new GizmoSglAxisOffsetDrag3D();

		private GizmoSglAxisRotationDrag3D _rotationDrag = new GizmoSglAxisRotationDrag3D();

		private GizmoRotationArc3D _rotationArc = new GizmoRotationArc3D();

		private GizmoSglAxisScaleDrag3D _scaleDrag = new GizmoSglAxisScaleDrag3D();

		private int _scaleDragAxisIndex;

		private List<GizmoScalerHandle> _scalerHandles = new List<GizmoScalerHandle>();

		private IGizmoDragSession _selectedDragSession;

		private GizmoCap3D _cap3D;

		private GizmoTransform _transform = new GizmoTransform();

		private GizmoTransformAxisMap3D _directionAxisMap = new GizmoTransformAxisMap3D();

		private GizmoTransformAxisMap3D _dragRotationAxisMap = new GizmoTransformAxisMap3D();

		private GizmoOverrideColor _overrideColor = new GizmoOverrideColor();

		private GizmoLineSlider3DSettings _settings = new GizmoLineSlider3DSettings();

		private GizmoLineSlider3DSettings _sharedSettings;

		private GizmoLineSlider3DLookAndFeel _lookAndFeel = new GizmoLineSlider3DLookAndFeel();

		private GizmoLineSlider3DLookAndFeel _sharedLookAndFeel;

		public Vector3 Direction => _directionAxisMap.Axis;

		public Vector3 DragRotationAxis => _dragRotationAxisMap.Axis;

		public int ScaleDragAxisIndex
		{
			get
			{
				return _scaleDragAxisIndex;
			}
			set
			{
				_scaleDragAxisIndex = Mathf.Clamp(value, 0, 2);
			}
		}

		public Vector3 StartPosition
		{
			get
			{
				return _transform.Position3D;
			}
			set
			{
				_transform.Position3D = value;
			}
		}

		public GizmoDragChannel DragChannel => _dragChannel;

		public bool IsDragged
		{
			get
			{
				if (base.Gizmo.IsDragged)
				{
					if (base.Gizmo.DragHandleId != base.HandleId)
					{
						return base.Gizmo.DragHandleId == _cap3D.HandleId;
					}
					return true;
				}
				return false;
			}
		}

		public bool IsMoving => _offsetDrag.IsActive;

		public bool IsRotating => _rotationDrag.IsActive;

		public bool IsScaling => _scaleDrag.IsActive;

		public bool Is3DCapVisible => _cap3D.IsVisible;

		public bool Is3DCapHoverable => _cap3D.IsHoverable;

		public int Cap3DHandleId => _cap3D.HandleId;

		public Vector3 TotalDragOffset => _offsetDrag.TotalDragOffset;

		public Vector3 RelativeDragOffset => _offsetDrag.RelativeDragOffset;

		public float TotalDragRotation => _rotationDrag.TotalRotation;

		public float RelativeDragRotation => _rotationDrag.RelativeRotation;

		public float TotalDragScale => _scaleDrag.TotalScale;

		public float RelativeDragScale => _scaleDrag.RelativeScale;

		public GizmoOverrideColor OverrideColor => _overrideColor;

		public GizmoOverrideColor Cap3DOverrideColor => _cap3D.OverrideColor;

		public GizmoLineSlider3DSettings Settings
		{
			get
			{
				if (_sharedSettings == null)
				{
					return _settings;
				}
				return _sharedSettings;
			}
		}

		public GizmoLineSlider3DSettings SharedSettings
		{
			get
			{
				return _sharedSettings;
			}
			set
			{
				_sharedSettings = value;
			}
		}

		public GizmoLineSlider3DLookAndFeel LookAndFeel
		{
			get
			{
				if (_sharedLookAndFeel == null)
				{
					return _lookAndFeel;
				}
				return _sharedLookAndFeel;
			}
		}

		public GizmoLineSlider3DLookAndFeel SharedLookAndFeel
		{
			get
			{
				return _sharedLookAndFeel;
			}
			set
			{
				_sharedLookAndFeel = value;
				SetupSharedLookAndFeel();
			}
		}

		public GizmoLineSlider3D(Gizmo gizmo, int handleId, int capHandleId)
			: base(gizmo, handleId)
		{
			_segmentIndex = base.Handle.Add3DShape(_segment);
			_boxIndex = base.Handle.Add3DShape(_box);
			_cylinderIndex = base.Handle.Add3DShape(_cylinder);
			_cap3D = new GizmoCap3D(base.Gizmo, capHandleId);
			SetupSharedLookAndFeel();
			MapDirection(0, AxisSign.Positive);
			SetDragChannel(GizmoDragChannel.Offset);
			_controllerData.Gizmo = base.Gizmo;
			_controllerData.Slider = this;
			_controllerData.SliderHandle = base.Handle;
			_controllerData.Segment = _segment;
			_controllerData.Box = _box;
			_controllerData.Cylinder = _cylinder;
			_controllerData.SegmentIndex = _segmentIndex;
			_controllerData.BoxIndex = _boxIndex;
			_controllerData.CylinderIndex = _cylinderIndex;
			_controllers[0] = new GizmoThinLineSlider3DController(_controllerData);
			_controllers[1] = new GizmoBoxLineSlider3DController(_controllerData);
			_controllers[2] = new GizmoCylinderLineSlider3DController(_controllerData);
			_transform.Changed += OnTransformChanged;
			base.Gizmo.PreUpdateBegin += OnGizmoPreUpdateBegin;
			base.Gizmo.PreDragBeginAttempt += OnGizmoAttemptHandleDragBegin;
			base.Gizmo.PreHoverEnter += OnGizmoHandleHoverEnter;
			base.Gizmo.PreHoverExit += OnGizmoHandleHoverExit;
			base.Gizmo.PostEnabled += OnGizmoPostEnabled;
			base.Gizmo.PostDisabled += OnGizmoPostDisabled;
			AddTargetTransform(_transform);
			AddTargetTransform(base.Gizmo.Transform);
			_cap3D.RegisterTransformAsDragTarget(_offsetDrag);
			_cap3D.RegisterTransformAsDragTarget(_rotationDrag);
			_cap3D.RegisterTransformAsDragTarget(_scaleDrag);
			_transform.SetParent(base.Gizmo.Transform);
		}

		public bool IsScalerHandleRegistered(int handleId)
		{
			return _scalerHandles.FindAll((GizmoScalerHandle item) => item.HandleId == handleId).Count != 0;
		}

		public bool IsScalerHandleRegistered(int handleId, int scaleDragAxisIndex)
		{
			List<GizmoScalerHandle> list = _scalerHandles.FindAll((GizmoScalerHandle item) => item.HandleId == handleId);
			if (list.Count == 0)
			{
				return false;
			}
			return list[0].ContainsScaleDragAxisIndex(scaleDragAxisIndex);
		}

		public void RegisterScalerHandle(int handleId, IEnumerable<int> scaleDragAxisIndices)
		{
			if (!IsScalerHandleRegistered(handleId))
			{
				_scalerHandles.Add(new GizmoScalerHandle(handleId, scaleDragAxisIndices));
			}
		}

		public void UnregisterScalerHandle(int handleId)
		{
			_scalerHandles.RemoveAll((GizmoScalerHandle item) => item.HandleId == handleId);
		}

		public override void SetSnapEnabled(bool isEnabled)
		{
			_offsetDrag.IsSnapEnabled = isEnabled;
			_rotationDrag.IsSnapEnabled = isEnabled;
			_scaleDrag.IsSnapEnabled = isEnabled;
		}

		public void Set3DCapVisible(bool isVisible)
		{
			_cap3D.SetVisible(isVisible);
		}

		public void Set3DCapHoverable(bool isHoverable)
		{
			_cap3D.SetHoverable(isHoverable);
		}

		public void SetZoomFactorTransform(GizmoTransform transform)
		{
			base.Handle.SetZoomFactorTransform(transform);
		}

		public float GetZoomFactor(Camera camera)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				return 1f;
			}
			return base.Handle.GetZoomFactor(camera);
		}

		public Vector3 GetRealDirection()
		{
			float num = 1f;
			if (_scaleDrag.IsActive)
			{
				num = Mathf.Sign(TotalDragScale);
			}
			else if (base.Gizmo.IsDragged && IsScalerHandleRegistered(base.Gizmo.DragHandleId, ScaleDragAxisIndex))
			{
				num = Mathf.Sign(base.Gizmo.TotalDragScale[ScaleDragAxisIndex]);
			}
			return Direction * num;
		}

		public float GetRealSizeAlongDirection(Camera camera, Vector3 direction)
		{
			return _controllers[(int)LookAndFeel.LineType].GetRealSizeAlongDirection(direction, GetZoomFactor(base.Gizmo.GetWorkCamera()));
		}

		public float GetRealLength(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			float num = LookAndFeel.Length * LookAndFeel.Scale * zoomFactor;
			if (_scaleDrag.IsActive)
			{
				num *= _scaleDrag.TotalScale;
			}
			else if (base.Gizmo.IsDragged && IsScalerHandleRegistered(base.Gizmo.DragHandleId, ScaleDragAxisIndex))
			{
				num *= base.Gizmo.TotalDragScale[ScaleDragAxisIndex];
			}
			return num;
		}

		public float GetRealLengthWith3DCap(float zoomFactor)
		{
			return _cap3D.GetSliderAlignedRealLength(zoomFactor) + GetRealLength(zoomFactor);
		}

		public Vector3 GetRealEndPosition(float zoomFactor)
		{
			return StartPosition + Direction * GetRealLength(zoomFactor);
		}

		public Vector3 GetRealEndPositionWith3DCap(float zoomFactor)
		{
			return StartPosition + Direction * GetRealLengthWith3DCap(zoomFactor);
		}

		public float GetRealBoxHeight(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			return LookAndFeel.BoxHeight * LookAndFeel.Scale * zoomFactor;
		}

		public float GetRealBoxDepth(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			return LookAndFeel.BoxDepth * LookAndFeel.Scale * zoomFactor;
		}

		public float GetRealCylinderRadius(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			return LookAndFeel.CylinderRadius * LookAndFeel.Scale * zoomFactor;
		}

		public void MapDirection(int axisIndex, AxisSign axisSign)
		{
			if (!IsDragged)
			{
				_directionAxisMap.Map(_transform, axisIndex, axisSign);
			}
		}

		public void MapDragRotationAxis(GizmoTransform mapTransform, int axisIndex, AxisSign axisSign)
		{
			if (!IsDragged)
			{
				_dragRotationAxisMap.Map(mapTransform, axisIndex, axisSign);
			}
		}

		public void UnmapDragRotationAxis()
		{
			if (!IsDragged)
			{
				_dragRotationAxisMap.Unmap();
			}
		}

		public void SetDirection(Vector3 directionAxis)
		{
			if (!IsDragged)
			{
				_directionAxisMap.SetAxis(directionAxis);
			}
		}

		public void SetDragRotationAxis(Vector3 rotationAxis)
		{
			if (!IsDragged)
			{
				_dragRotationAxisMap.Unmap();
				_dragRotationAxisMap.SetAxis(rotationAxis);
			}
		}

		public void AddTargetTransform(GizmoTransform transform)
		{
			_offsetDrag.AddTargetTransform(transform);
			_rotationDrag.AddTargetTransform(transform);
			_scaleDrag.AddTargetTransform(transform);
		}

		public void AddTargetTransform(GizmoTransform transform, GizmoDragChannel dragChannel)
		{
			switch (dragChannel)
			{
			case GizmoDragChannel.Offset:
				_offsetDrag.AddTargetTransform(transform);
				return;
			case GizmoDragChannel.Rotation:
				_rotationDrag.AddTargetTransform(transform);
				return;
			}
			if (_dragChannel == GizmoDragChannel.Scale)
			{
				_scaleDrag.AddTargetTransform(transform);
			}
		}

		public void RemoveTargetTransform(GizmoTransform transform)
		{
			_offsetDrag.RemoveTargetTransform(transform);
			_rotationDrag.RemoveTargetTransform(transform);
			_scaleDrag.RemoveTargetTransform(transform);
		}

		public void RemoveTargetTransform(GizmoTransform transform, GizmoDragChannel dragChannel)
		{
			switch (dragChannel)
			{
			case GizmoDragChannel.Offset:
				_offsetDrag.RemoveTargetTransform(transform);
				return;
			case GizmoDragChannel.Rotation:
				_rotationDrag.RemoveTargetTransform(transform);
				return;
			}
			if (_dragChannel == GizmoDragChannel.Scale)
			{
				_scaleDrag.RemoveTargetTransform(transform);
			}
		}

		public void SetDragChannel(GizmoDragChannel dragChannel)
		{
			_dragChannel = dragChannel;
			if (_dragChannel == GizmoDragChannel.Offset)
			{
				_selectedDragSession = _offsetDrag;
			}
			else if (_dragChannel == GizmoDragChannel.Rotation)
			{
				_selectedDragSession = _rotationDrag;
			}
			else if (_dragChannel == GizmoDragChannel.Scale)
			{
				_selectedDragSession = _scaleDrag;
			}
			base.Handle.DragSession = _selectedDragSession;
			_cap3D.DragSession = _selectedDragSession;
		}

		public void ApplyZoomFactor(Camera camera)
		{
			if (LookAndFeel.UseZoomFactor)
			{
				float zoomFactor = GetZoomFactor(camera);
				_controllers[(int)LookAndFeel.LineType].UpdateTransforms(zoomFactor);
				_cap3D.ApplyZoomFactor(camera);
				_cap3D.CapSlider3D(GetRealDirection(), GetRealEndPosition(zoomFactor));
			}
		}

		public override void Render(Camera camera)
		{
			if (!base.IsVisible && !Is3DCapVisible)
			{
				return;
			}
			Color color = default(Color);
			color = (OverrideColor.IsActive ? OverrideColor.Color : ((base.Gizmo.HoverHandleId != base.HandleId) ? LookAndFeel.Color : LookAndFeel.HoveredColor));
			if (LookAndFeel.IsRotationArcVisible && IsRotating)
			{
				_rotationArc.RotationAngle = _rotationDrag.TotalRotation;
				_rotationArc.Radius = GetRealLength(GetZoomFactor(camera));
				_rotationArc.Render(LookAndFeel.RotationArcLookAndFeel);
			}
			bool flag = !camera.IsPointFacingCamera(GetRealEndPosition(GetZoomFactor(camera)), GetRealDirection());
			if (Is3DCapVisible && flag)
			{
				_cap3D.Render(camera);
			}
			if (base.IsVisible)
			{
				if (LookAndFeel.FillMode == GizmoFillMode3D.Filled)
				{
					bool flag2 = LookAndFeel.ShadeMode == GizmoShadeMode.Lit && LookAndFeel.LineType != GizmoLine3DType.Thin;
					GizmoSolidMaterial get = Singleton<GizmoSolidMaterial>.Get;
					get.ResetValuesToSensibleDefaults();
					get.SetLit(flag2);
					if (flag2)
					{
						get.SetLightDirection(camera.transform.forward);
					}
					get.SetColor(color);
					get.SetPass(0);
					base.Handle.Render3DSolid();
				}
				else
				{
					GizmoLineMaterial get2 = Singleton<GizmoLineMaterial>.Get;
					get2.ResetValuesToSensibleDefaults();
					get2.SetColor(color);
					get2.SetPass(0);
					base.Handle.Render3DWire();
				}
			}
			if (Is3DCapVisible && !flag)
			{
				_cap3D.Render(camera);
			}
		}

		public void Refresh()
		{
			Camera workCamera = base.Gizmo.GetWorkCamera();
			float zoomFactor = GetZoomFactor(workCamera);
			_controllers[(int)LookAndFeel.LineType].UpdateHandles();
			_controllers[(int)LookAndFeel.LineType].UpdateEpsilons(zoomFactor);
			_controllers[(int)LookAndFeel.LineType].UpdateTransforms(zoomFactor);
			_cap3D.CapSlider3D(GetRealDirection(), GetRealEndPosition(zoomFactor));
		}

		protected override void OnVisibilityStateChanged()
		{
			_controllers[(int)LookAndFeel.LineType].UpdateHandles();
			Camera workCamera = base.Gizmo.GetWorkCamera();
			float zoomFactor = GetZoomFactor(workCamera);
			_controllers[(int)LookAndFeel.LineType].UpdateEpsilons(zoomFactor);
			_controllers[(int)LookAndFeel.LineType].UpdateTransforms(zoomFactor);
			_cap3D.CapSlider3D(GetRealDirection(), GetRealEndPosition(zoomFactor));
		}

		protected override void OnHoverableStateChanged()
		{
			base.Handle.SetHoverable(base.IsHoverable);
		}

		private void OnGizmoPreUpdateBegin(Gizmo gizmo)
		{
			int lineType = (int)LookAndFeel.LineType;
			_controllers[lineType].UpdateHandles();
			float zoomFactor = GetZoomFactor(gizmo.FocusCamera);
			_offsetDrag.Sensitivity = Settings.OffsetSensitivity;
			_rotationDrag.Sensitivity = Settings.RotationSensitivity;
			_scaleDrag.Sensitivity = Settings.ScaleSensitivity;
			_controllers[lineType].UpdateTransforms(zoomFactor);
			_controllers[lineType].UpdateEpsilons(zoomFactor);
			_cap3D.GenericHoverPriority.Value = base.GenericHoverPriority.Value;
			_cap3D.HoverPriority2D.Value = base.HoverPriority2D.Value;
			_cap3D.HoverPriority3D.Value = base.HoverPriority3D.Value;
			_cap3D.CapSlider3D(GetRealDirection(), GetRealEndPosition(zoomFactor));
		}

		private void OnGizmoAttemptHandleDragBegin(Gizmo gizmo, int handleId)
		{
			if (handleId == base.Handle.Id || handleId == _cap3D.HandleId)
			{
				if (_dragChannel == GizmoDragChannel.Offset)
				{
					GizmoSglAxisOffsetDrag3D.WorkData workData = new GizmoSglAxisOffsetDrag3D.WorkData
					{
						Axis = Direction,
						DragOrigin = StartPosition,
						SnapStep = Settings.OffsetSnapStep
					};
					_offsetDrag.SetWorkData(workData);
				}
				else if (_dragChannel == GizmoDragChannel.Rotation)
				{
					GizmoSglAxisRotationDrag3D.WorkData workData2 = new GizmoSglAxisRotationDrag3D.WorkData
					{
						Axis = DragRotationAxis,
						RotationPlanePos = StartPosition,
						SnapStep = Settings.RotationSnapStep,
						SnapMode = Settings.RotationSnapMode
					};
					_rotationDrag.SetWorkData(workData2);
					_rotationArc.SetArcData(DragRotationAxis, StartPosition, StartPosition + Direction, GetRealLength(GetZoomFactor(base.Gizmo.FocusCamera)));
				}
				else if (_dragChannel == GizmoDragChannel.Scale)
				{
					GizmoSglAxisScaleDrag3D.WorkData workData3 = new GizmoSglAxisScaleDrag3D.WorkData
					{
						Axis = Direction,
						DragOrigin = StartPosition,
						SnapStep = Settings.ScaleSnapStep,
						AxisIndex = ScaleDragAxisIndex,
						EntityScale = 1f
					};
					_scaleDrag.SetWorkData(workData3);
				}
			}
		}

		private void OnTransformChanged(GizmoTransform transform, GizmoTransform.ChangeData changeData)
		{
			if (changeData.ChangeReason == GizmoTransform.ChangeReason.ParentChange || changeData.TRSDimension == GizmoDimension.Dim3D)
			{
				Camera workCamera = base.Gizmo.GetWorkCamera();
				float zoomFactor = GetZoomFactor(workCamera);
				_controllers[(int)LookAndFeel.LineType].UpdateTransforms(zoomFactor);
				_cap3D.CapSlider3D(GetRealDirection(), GetRealEndPosition(zoomFactor));
			}
		}

		private void OnGizmoHandleHoverEnter(Gizmo gizmo, int handleId)
		{
			if (handleId == base.HandleId)
			{
				_cap3D.OverrideColor.IsActive = true;
				_cap3D.OverrideColor.Color = LookAndFeel.CapLookAndFeel.HoveredColor;
			}
			else if (handleId == _cap3D.HandleId)
			{
				OverrideColor.IsActive = true;
				OverrideColor.Color = LookAndFeel.HoveredColor;
			}
		}

		private void OnGizmoPostEnabled(Gizmo gizmo)
		{
			Refresh();
		}

		private void OnGizmoPostDisabled(Gizmo gizmo)
		{
			OverrideColor.IsActive = false;
			_cap3D.OverrideColor.IsActive = false;
		}

		private void OnGizmoHandleHoverExit(Gizmo gizmo, int handleId)
		{
			if (handleId == base.HandleId)
			{
				_cap3D.OverrideColor.IsActive = false;
			}
			else if (handleId == _cap3D.HandleId)
			{
				OverrideColor.IsActive = false;
			}
		}

		private void SetupSharedLookAndFeel()
		{
			_cap3D.SharedLookAndFeel = LookAndFeel.CapLookAndFeel;
		}
	}
}
