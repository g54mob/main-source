using System;
using UnityEngine;

namespace RLD
{
	public class GizmoLineSlider2D : GizmoSlider
	{
		private SegmentShape2D _segment = new SegmentShape2D();

		private QuadShape2D _quad = new QuadShape2D();

		private int _segmentIndex;

		private int _quadIndex;

		private GizmoDragChannel _dragChannel;

		private GizmoSglAxisOffsetDrag3D _offsetDrag = new GizmoSglAxisOffsetDrag3D();

		private Vector3 _offsetDragOrigin;

		private GizmoSglAxisRotationDrag3D _rotationDrag = new GizmoSglAxisRotationDrag3D();

		private GizmoRotationArc2D _rotationArc = new GizmoRotationArc2D();

		private GizmoSglAxisScaleDrag3D _scaleDrag = new GizmoSglAxisScaleDrag3D();

		private Vector3 _scaleDragOrigin;

		private Vector3 _scaleAxis;

		private int _scaleDragAxisIndex;

		private IGizmoDragSession _selectedDragSession;

		private GizmoCap2D _cap2D;

		private GizmoTransform _transform = new GizmoTransform();

		private GizmoTransformAxisMap2D _directionAxisMap = new GizmoTransformAxisMap2D();

		private GizmoOverrideColor _overrideFillColor = new GizmoOverrideColor();

		private GizmoOverrideColor _overrideBorderColor = new GizmoOverrideColor();

		private GizmoLineSlider2DControllerData _controllerData = new GizmoLineSlider2DControllerData();

		private IGizmoLineSlider2DController[] _controllers = new IGizmoLineSlider2DController[Enum.GetValues(typeof(GizmoLine2DType)).Length];

		private GizmoLineSlider2DSettings _settings = new GizmoLineSlider2DSettings();

		private GizmoLineSlider2DSettings _sharedSettings;

		private GizmoLineSlider2DLookAndFeel _lookAndFeel = new GizmoLineSlider2DLookAndFeel();

		private GizmoLineSlider2DLookAndFeel _sharedLookAndFeel;

		public Quaternion Rotation => _transform.Rotation2D;

		public float RotationDegrees => _transform.Rotation2DDegrees;

		public Vector2 StartPosition
		{
			get
			{
				return _transform.Position2D;
			}
			set
			{
				_transform.Position2D = value;
			}
		}

		public Vector2 Direction => _directionAxisMap.Axis;

		public Vector3 OffsetDragOrigin
		{
			get
			{
				return _offsetDragOrigin;
			}
			set
			{
				_offsetDragOrigin = value;
			}
		}

		public Vector3 ScaleDragOrigin
		{
			get
			{
				return _scaleDragOrigin;
			}
			set
			{
				_scaleDragOrigin = value;
			}
		}

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

		public int Cap2DHandleId => _cap2D.HandleId;

		public bool IsDragged
		{
			get
			{
				if (base.Gizmo.IsDragged)
				{
					if (base.Gizmo.DragHandleId != base.HandleId)
					{
						return base.Gizmo.DragHandleId == _cap2D.HandleId;
					}
					return true;
				}
				return false;
			}
		}

		public bool IsMoving => _offsetDrag.IsActive;

		public bool IsRotating => _rotationDrag.IsActive;

		public bool IsScaling => _scaleDrag.IsActive;

		public bool Is2DCapVisible => _cap2D.IsVisible;

		public bool Is2DCapHoverable => _cap2D.IsHoverable;

		public Vector3 TotalDragOffset => _offsetDrag.TotalDragOffset;

		public Vector3 RelativeDragOffset => _offsetDrag.RelativeDragOffset;

		public float TotalDragRotation => _rotationDrag.TotalRotation;

		public float RelativeDragRotation => _rotationDrag.RelativeRotation;

		public float TotalDragScale => _scaleDrag.TotalScale;

		public float RelativeDragScale => _scaleDrag.RelativeScale;

		public GizmoOverrideColor OverrideFillColor => _overrideFillColor;

		public GizmoOverrideColor OverrideBorderColor => _overrideBorderColor;

		public GizmoLineSlider2DSettings Settings
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

		public GizmoLineSlider2DSettings SharedSettings
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

		public GizmoLineSlider2DLookAndFeel LookAndFeel
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

		public GizmoLineSlider2DLookAndFeel SharedLookAndFeel
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

		public GizmoLineSlider2D(Gizmo gizmo, int handleId, int capHandleId)
			: base(gizmo, handleId)
		{
			_segmentIndex = base.Handle.Add2DShape(_segment);
			_quadIndex = base.Handle.Add2DShape(_quad);
			_controllerData.Gizmo = base.Gizmo;
			_controllerData.Slider = this;
			_controllerData.SliderHandle = base.Handle;
			_controllerData.Segment = _segment;
			_controllerData.SegmentIndex = _segmentIndex;
			_controllerData.Quad = _quad;
			_controllerData.QuadIndex = _quadIndex;
			_controllers[0] = new GizmoThinLineSlider2DController(_controllerData);
			_controllers[1] = new GizmoBoxLineSlider2DController(_controllerData);
			_cap2D = new GizmoCap2D(gizmo, capHandleId);
			SetupSharedLookAndFeel();
			SetDragChannel(GizmoDragChannel.Offset);
			AddTargetTransform(base.Gizmo.Transform);
			AddTargetTransform(_transform);
			_cap2D.RegisterTransformAsDragTarget(_offsetDrag);
			_cap2D.RegisterTransformAsDragTarget(_rotationDrag);
			_transform.Changed += OnTransformChanged;
			_transform.SetParent(gizmo.Transform);
			base.Gizmo.PreUpdateBegin += OnGizmoPreUpdateBegin;
			base.Gizmo.PreDragUpdate += OnGizmoHandleDragUpdate;
			base.Gizmo.PreDragBeginAttempt += OnGizmoAttemptHandleDragBegin;
			base.Gizmo.PreHoverEnter += OnGizmoHandleHoverEnter;
			base.Gizmo.PreHoverExit += OnGizmoHandleHoverExit;
			base.Gizmo.PostEnabled += OnGizmoPostEnabled;
		}

		public override void SetSnapEnabled(bool isEnabled)
		{
			_offsetDrag.IsSnapEnabled = isEnabled;
			_rotationDrag.IsSnapEnabled = isEnabled;
			_scaleDrag.IsSnapEnabled = isEnabled;
		}

		public void Set2DCapVisible(bool isVisible)
		{
			_cap2D.SetVisible(isVisible);
		}

		public void Set2DCapHoverable(bool isHoverable)
		{
			_cap2D.SetHoverable(isHoverable);
		}

		public Vector2 GetRealDirection()
		{
			float num = (IsScaling ? Mathf.Sign(TotalDragScale) : 1f);
			return Direction * num;
		}

		public float GetRealLength()
		{
			float num = 1f;
			if (IsScaling)
			{
				Vector3 vector = _scaleAxis * TotalDragScale;
				num = Vector3Ex.ConvertDirTo2D(ScaleDragOrigin, ScaleDragOrigin + vector, base.Gizmo.GetWorkCamera()).magnitude / (LookAndFeel.Length * LookAndFeel.Scale) * Mathf.Sign(TotalDragScale);
			}
			return LookAndFeel.Length * LookAndFeel.Scale * num;
		}

		public Vector2 GetRealEndPosition()
		{
			return StartPosition + Direction * GetRealLength();
		}

		public float GetRealBoxThickness()
		{
			return LookAndFeel.BoxThickness * LookAndFeel.Scale;
		}

		public void MapDirection(int axisIndex, AxisSign axisSign)
		{
			if (!IsDragged && axisIndex <= 1)
			{
				_directionAxisMap.Map(_transform, axisIndex, axisSign);
			}
		}

		public void SetDirection(Vector2 directionAxis)
		{
			if (!IsDragged)
			{
				_directionAxisMap.SetAxis(directionAxis);
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
				break;
			case GizmoDragChannel.Rotation:
				_rotationDrag.AddTargetTransform(transform);
				break;
			case GizmoDragChannel.Scale:
				_scaleDrag.AddTargetTransform(transform);
				break;
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
				break;
			case GizmoDragChannel.Rotation:
				_rotationDrag.RemoveTargetTransform(transform);
				break;
			case GizmoDragChannel.Scale:
				_scaleDrag.RemoveTargetTransform(transform);
				break;
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
			_cap2D.DragSession = _selectedDragSession;
		}

		public override void Render(Camera camera)
		{
			if (!base.IsVisible && !Is2DCapVisible)
			{
				return;
			}
			if (LookAndFeel.IsRotationArcVisible && IsRotating)
			{
				_rotationArc.RotationAngle = _rotationDrag.TotalRotation;
				_rotationArc.Render(LookAndFeel.RotationArcLookAndFeel, camera);
			}
			if (base.IsVisible)
			{
				if (LookAndFeel.LineType == GizmoLine2DType.Thin || LookAndFeel.FillMode == GizmoFillMode2D.FilledAndBorder || LookAndFeel.FillMode == GizmoFillMode2D.Filled)
				{
					Color color = default(Color);
					if (!_overrideFillColor.IsActive)
					{
						color = LookAndFeel.Color;
						if (base.Gizmo.HoverHandleId == base.HandleId)
						{
							color = LookAndFeel.HoveredColor;
						}
					}
					else
					{
						color = _overrideFillColor.Color;
					}
					GizmoSolidMaterial get = Singleton<GizmoSolidMaterial>.Get;
					get.ResetValuesToSensibleDefaults();
					get.SetLit(isLit: false);
					get.SetColor(color);
					get.SetPass(0);
					base.Handle.Render2DSolid(camera);
				}
				if (LookAndFeel.LineType != GizmoLine2DType.Thin && (LookAndFeel.FillMode == GizmoFillMode2D.FilledAndBorder || LookAndFeel.FillMode == GizmoFillMode2D.Border))
				{
					Color color2 = default(Color);
					if (!_overrideFillColor.IsActive)
					{
						color2 = LookAndFeel.BorderColor;
						if (base.Gizmo.HoverHandleId == base.HandleId)
						{
							color2 = LookAndFeel.HoveredBorderColor;
						}
					}
					else
					{
						color2 = _overrideBorderColor.Color;
					}
					GizmoLineMaterial get2 = Singleton<GizmoLineMaterial>.Get;
					get2.ResetValuesToSensibleDefaults();
					get2.SetColor(color2);
					get2.SetPass(0);
					base.Handle.Render2DWire(camera);
				}
			}
			_cap2D.Render(camera);
		}

		public void Refresh()
		{
			_controllers[(int)LookAndFeel.LineType].UpdateHandles();
			_controllers[(int)LookAndFeel.LineType].UpdateEpsilons();
			_controllers[(int)LookAndFeel.LineType].UpdateTransforms();
			_cap2D.CapSlider2D(GetRealDirection(), GetRealEndPosition());
		}

		protected override void OnVisibilityStateChanged()
		{
			_controllers[(int)LookAndFeel.LineType].UpdateHandles();
			_controllers[(int)LookAndFeel.LineType].UpdateEpsilons();
			_controllers[(int)LookAndFeel.LineType].UpdateTransforms();
			_cap2D.CapSlider2D(GetRealDirection(), GetRealEndPosition());
		}

		protected override void OnHoverableStateChanged()
		{
			base.Handle.SetHoverable(base.IsHoverable);
		}

		private void OnGizmoPreUpdateBegin(Gizmo gizmo)
		{
			int lineType = (int)LookAndFeel.LineType;
			_controllers[lineType].UpdateHandles();
			_offsetDrag.Sensitivity = Settings.OffsetSensitivity;
			_rotationDrag.Sensitivity = Settings.RotationSensitivity;
			_controllers[lineType].UpdateTransforms();
			_controllers[lineType].UpdateEpsilons();
			_cap2D.GenericHoverPriority.Value = base.GenericHoverPriority.Value;
			_cap2D.HoverPriority2D.Value = base.HoverPriority2D.Value;
			_cap2D.HoverPriority3D.Value = base.HoverPriority3D.Value;
			_cap2D.CapSlider2D(GetRealDirection(), GetRealEndPosition());
		}

		private void OnGizmoAttemptHandleDragBegin(Gizmo gizmo, int handleId)
		{
			if (handleId == base.Handle.Id || handleId == _cap2D.HandleId)
			{
				if (_dragChannel == GizmoDragChannel.Offset)
				{
					GizmoSglAxisOffsetDrag3D.WorkData workData = new GizmoSglAxisOffsetDrag3D.WorkData
					{
						Axis = Vector2Ex.ConvertDirTo3D(StartPosition, GetRealEndPosition(), OffsetDragOrigin, base.Gizmo.FocusCamera).normalized,
						DragOrigin = OffsetDragOrigin,
						SnapStep = Settings.OffsetSnapStep
					};
					_offsetDrag.SetWorkData(workData);
				}
				else if (_dragChannel == GizmoDragChannel.Rotation)
				{
					GizmoSglAxisRotationDrag3D.WorkData workData2 = new GizmoSglAxisRotationDrag3D.WorkData
					{
						Axis = base.Gizmo.FocusCamera.transform.forward,
						SnapMode = Settings.RotationSnapMode,
						SnapStep = Settings.RotationSnapStep,
						RotationPlanePos = base.Gizmo.FocusCamera.ScreenToWorldPoint(new Vector3(_transform.Position2D.x, _transform.Position2D.y, base.Gizmo.FocusCamera.nearClipPlane))
					};
					_rotationArc.SetArcData(StartPosition, GetRealEndPosition(), GetRealLength());
					_rotationDrag.SetWorkData(workData2);
				}
				else if (_dragChannel == GizmoDragChannel.Scale)
				{
					_scaleAxis = Vector2Ex.ConvertDirTo3D(StartPosition, GetRealEndPosition(), ScaleDragOrigin, base.Gizmo.FocusCamera);
					GizmoSglAxisScaleDrag3D.WorkData workData3 = new GizmoSglAxisScaleDrag3D.WorkData
					{
						Axis = _scaleAxis.normalized,
						AxisIndex = _scaleDragAxisIndex,
						DragOrigin = ScaleDragOrigin,
						SnapStep = Settings.ScaleSnapStep,
						EntityScale = 1f
					};
					_scaleDrag.SetWorkData(workData3);
				}
			}
		}

		private void OnTransformChanged(GizmoTransform transform, GizmoTransform.ChangeData changeData)
		{
			if (changeData.TRSDimension == GizmoDimension.Dim2D || changeData.ChangeReason == GizmoTransform.ChangeReason.ParentChange)
			{
				_controllers[(int)LookAndFeel.LineType].UpdateTransforms();
				_cap2D.CapSlider2D(GetRealDirection(), GetRealEndPosition());
			}
		}

		private void OnGizmoHandleHoverEnter(Gizmo gizmo, int handleId)
		{
			if (handleId == base.HandleId)
			{
				_cap2D.OverrideFillColor.IsActive = true;
				_cap2D.OverrideFillColor.Color = LookAndFeel.CapLookAndFeel.HoveredColor;
				_cap2D.OverrideBorderColor.IsActive = true;
				_cap2D.OverrideBorderColor.Color = LookAndFeel.CapLookAndFeel.HoveredBorderColor;
			}
			else if (handleId == _cap2D.HandleId)
			{
				OverrideFillColor.IsActive = true;
				OverrideFillColor.Color = LookAndFeel.HoveredColor;
				OverrideBorderColor.IsActive = true;
				OverrideBorderColor.Color = LookAndFeel.HoveredBorderColor;
			}
		}

		private void OnGizmoHandleHoverExit(Gizmo gizmo, int handleId)
		{
			if (handleId == base.HandleId)
			{
				_cap2D.OverrideFillColor.IsActive = false;
				_cap2D.OverrideBorderColor.IsActive = false;
			}
			else if (handleId == _cap2D.HandleId)
			{
				OverrideFillColor.IsActive = false;
				OverrideBorderColor.IsActive = false;
			}
		}

		private void OnGizmoHandleDragUpdate(Gizmo gizmo, int handleId)
		{
			if (handleId == base.HandleId || handleId == _cap2D.HandleId)
			{
				_transform.Rotate2D(gizmo.RelativeDragRotation);
			}
		}

		private void SetupSharedLookAndFeel()
		{
			_cap2D.SharedLookAndFeel = LookAndFeel.CapLookAndFeel;
		}

		private void OnGizmoPostEnabled(Gizmo gizmo)
		{
			Refresh();
		}
	}
}
