using System;
using UnityEngine;

namespace RLD
{
	public class GizmoPlaneSlider3D : GizmoSlider
	{
		private int _quadIndex;

		private int _raTriangleIndex;

		private int _circleIndex;

		private QuadShape3D _quad = new QuadShape3D();

		private RightAngTriangle3D _raTriangle = new RightAngTriangle3D();

		private CircleShape3D _circle = new CircleShape3D();

		private GizmoQuad3DBorder _quadBorder;

		private GizmoRATriangle3DBorder _raTriangleBorder;

		private GizmoCircle3DBorder _circleBorder;

		private bool _isBorderHoverable = true;

		private bool _isBorderVisible = true;

		private GizmoTransform _transform = new GizmoTransform();

		private GizmoDragChannel _dragChannel = GizmoDragChannel.Offset;

		private IGizmoDragSession _selectedDragSession;

		private GizmoDblAxisOffsetDrag3D _dblAxisOffsetDrag = new GizmoDblAxisOffsetDrag3D();

		private GizmoSglAxisRotationDrag3D _rotationDrag = new GizmoSglAxisRotationDrag3D();

		private GizmoRotationArc3D _rotationArc = new GizmoRotationArc3D();

		private GizmoDblAxisScaleDrag3D _scaleDrag = new GizmoDblAxisScaleDrag3D();

		private int _scaleDragAxisIndexRight;

		private int _scaleDragAxisIndexUp = 1;

		private GizmoPlaneSlider3DControllerData _controllerData = new GizmoPlaneSlider3DControllerData();

		private IGizmoPlaneSlider3DController[] _controllers = new IGizmoPlaneSlider3DController[Enum.GetValues(typeof(GizmoPlane3DType)).Length];

		private GizmoPlaneSlider3DSettings _settings = new GizmoPlaneSlider3DSettings();

		private GizmoPlaneSlider3DSettings _sharedSettings;

		private GizmoPlaneSlider3DLookAndFeel _lookAndFeel = new GizmoPlaneSlider3DLookAndFeel();

		private GizmoPlaneSlider3DLookAndFeel _sharedLookAndFeel;

		public GizmoPlaneSlider3DSettings Settings
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

		public GizmoPlaneSlider3DSettings SharedSettings
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

		public GizmoPlaneSlider3DLookAndFeel LookAndFeel
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

		public GizmoPlaneSlider3DLookAndFeel SharedLookAndFeel
		{
			get
			{
				return _sharedLookAndFeel;
			}
			set
			{
				_sharedLookAndFeel = value;
			}
		}

		public Plane Plane => new Plane(Normal, Position);

		public Vector3 Position
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

		public Quaternion Rotation
		{
			get
			{
				return _transform.Rotation3D;
			}
			set
			{
				_transform.Rotation3D = value;
			}
		}

		public Quaternion LocalRotation
		{
			get
			{
				return _transform.LocalRotation3D;
			}
			set
			{
				_transform.LocalRotation3D = value;
			}
		}

		public Vector3 Right => _transform.GetAxis3D(0, AxisSign.Positive);

		public Vector3 Up => _transform.GetAxis3D(1, AxisSign.Positive);

		public Vector3 Look => _transform.GetAxis3D(2, AxisSign.Positive);

		public Vector3 Normal => Look;

		public GizmoDragChannel DragChannel => _dragChannel;

		public int ScaleDragAxisIndexRight
		{
			get
			{
				return _scaleDragAxisIndexRight;
			}
			set
			{
				_scaleDragAxisIndexRight = Mathf.Clamp(value, 0, 2);
			}
		}

		public int ScaleDragAxisIndexUp
		{
			get
			{
				return _scaleDragAxisIndexUp;
			}
			set
			{
				_scaleDragAxisIndexUp = Mathf.Clamp(value, 0, 2);
			}
		}

		public Vector3 TotalDragOffset => _dblAxisOffsetDrag.TotalDragOffset;

		public Vector3 RelativeDragOffset => _dblAxisOffsetDrag.RelativeDragOffset;

		public float TotalDragRotation => _rotationDrag.TotalRotation;

		public float RelativeDragRotation => _rotationDrag.RelativeRotation;

		public float TotalDragScaleRight => _scaleDrag.TotalScale0;

		public float RelativeDragScaleRight => _scaleDrag.RelativeScale0;

		public float TotalDragScaleUp => _scaleDrag.TotalScale1;

		public float RelativeDragScaleUp => _scaleDrag.RelativeScale1;

		public bool IsBorderVisible => _isBorderVisible;

		public bool IsBorderHoverable => _isBorderHoverable;

		public bool IsDragged
		{
			get
			{
				if (base.Gizmo.IsDragged)
				{
					return base.Gizmo.DragHandleId == base.HandleId;
				}
				return false;
			}
		}

		public bool IsMoving => _dblAxisOffsetDrag.IsActive;

		public bool IsRotating => _rotationDrag.IsActive;

		public bool IsScaling => _scaleDrag.IsActive;

		public GizmoPlaneSlider3D(Gizmo gizmo, int handleId)
			: base(gizmo, handleId)
		{
			_quadIndex = base.Handle.Add3DShape(_quad);
			_raTriangleIndex = base.Handle.Add3DShape(_raTriangle);
			_circleIndex = base.Handle.Add3DShape(_circle);
			_quadBorder = new GizmoQuad3DBorder(this, base.Handle, _quad);
			_raTriangleBorder = new GizmoRATriangle3DBorder(this, base.Handle, _raTriangle);
			_circleBorder = new GizmoCircle3DBorder(this, base.Handle, _circle);
			_controllerData.Gizmo = base.Gizmo;
			_controllerData.Slider = this;
			_controllerData.SliderHandle = base.Handle;
			_controllerData.QuadBorder = _quadBorder;
			_controllerData.Quad = _quad;
			_controllerData.QuadIndex = _quadIndex;
			_controllerData.RATriangleBorder = _raTriangleBorder;
			_controllerData.RATriangle = _raTriangle;
			_controllerData.RATriangleIndex = _raTriangleIndex;
			_controllerData.CircleBorder = _circleBorder;
			_controllerData.Circle = _circle;
			_controllerData.CircleIndex = _circleIndex;
			_controllers[0] = new GizmoQuadPlaneSlider3DController(_controllerData);
			_controllers[1] = new GizmoRATrianglePlaneSlider3DController(_controllerData);
			_controllers[2] = new GizmoCirclePlaneSlider3DController(_controllerData);
			_transform.Changed += OnTransformChanged;
			base.Gizmo.PreUpdateBegin += OnGizmoPreUpdateBegin;
			base.Gizmo.PreDragBeginAttempt += OnGizmoAttemptHandleDragBegin;
			base.Gizmo.PostEnabled += OnGizmoPostEnabled;
			GizmoHandle handle = base.Handle;
			handle.CanHover = (GizmoHandleCanHoverHandler)Delegate.Combine(handle.CanHover, new GizmoHandleCanHoverHandler(OnCanHoverHandle));
			SetDragChannel(GizmoDragChannel.Offset);
			AddTargetTransform(_transform);
			AddTargetTransform(base.Gizmo.Transform);
			_transform.SetParent(base.Gizmo.Transform);
		}

		public void SetBorderVisible(bool isVisible)
		{
			if (isVisible != _isBorderVisible)
			{
				_isBorderVisible = isVisible;
				_controllers[(int)LookAndFeel.PlaneType].UpdateHandles();
			}
		}

		public void SetBorderHoverable(bool isHoverable)
		{
			_isBorderHoverable = isHoverable;
			_quadBorder.SetHoverable(isHoverable);
			_raTriangleBorder.SetHoverable(isHoverable);
			_circleBorder.SetHoverable(isHoverable);
		}

		public override void SetSnapEnabled(bool isEnabled)
		{
			_dblAxisOffsetDrag.IsSnapEnabled = isEnabled;
			_rotationDrag.IsSnapEnabled = isEnabled;
			_scaleDrag.IsSnapEnabled = isEnabled;
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

		public float GetRealQuadWidth(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			float num = 1f;
			if (_scaleDrag.IsActive)
			{
				num = Mathf.Abs(_scaleDrag.TotalScale0);
			}
			return LookAndFeel.QuadWidth * LookAndFeel.Scale * zoomFactor * num;
		}

		public float GetRealQuadHeight(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			float num = 1f;
			if (_scaleDrag.IsActive)
			{
				num = Mathf.Abs(_scaleDrag.TotalScale1);
			}
			return LookAndFeel.QuadHeight * LookAndFeel.Scale * zoomFactor * num;
		}

		public Vector2 GetRealQuadSize(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			float num = 1f;
			float num2 = 1f;
			if (_scaleDrag.IsActive)
			{
				num = _scaleDrag.TotalScale0;
				num2 = _scaleDrag.TotalScale1;
			}
			return new Vector2(LookAndFeel.QuadWidth * LookAndFeel.Scale * zoomFactor * num, LookAndFeel.QuadHeight * LookAndFeel.Scale * zoomFactor * num2);
		}

		public float GetRealCircleRadius(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			float num = 1f;
			if (IsScaling)
			{
				num = TotalDragScaleRight;
				if (Mathf.Abs(TotalDragScaleRight) < Mathf.Abs(TotalDragScaleUp))
				{
					num = TotalDragScaleUp;
				}
			}
			return LookAndFeel.CircleRadius * LookAndFeel.Scale * zoomFactor * num;
		}

		public float GetRealRATriXLength(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			float num = 1f;
			if (_scaleDrag.IsActive)
			{
				num = Mathf.Abs(_scaleDrag.TotalScale0);
			}
			return LookAndFeel.RATriangleXLength * LookAndFeel.Scale * zoomFactor * num;
		}

		public float GetRealRATriYLength(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			float num = 1f;
			if (_scaleDrag.IsActive)
			{
				num = Mathf.Abs(_scaleDrag.TotalScale1);
			}
			return LookAndFeel.RATriangleYLength * LookAndFeel.Scale * zoomFactor * num;
		}

		public Vector2 GetRealRATriSize(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			float num = 1f;
			float num2 = 1f;
			if (_scaleDrag.IsActive)
			{
				num = _scaleDrag.TotalScale0;
				num2 = _scaleDrag.TotalScale1;
			}
			return new Vector2(LookAndFeel.RATriangleXLength * LookAndFeel.Scale * zoomFactor * num, LookAndFeel.RATriangleYLength * LookAndFeel.Scale * zoomFactor * num2);
		}

		public void AlignToQuadrant(GizmoTransform transform, PlaneId planeId, PlaneQuadrantId quadrantId, bool alignXToFirstAxis)
		{
			Plane plane3D = transform.GetPlane3D(planeId, quadrantId);
			if (alignXToFirstAxis)
			{
				AxisDescriptor secondAxisDescriptor = PlaneIdHelper.GetSecondAxisDescriptor(planeId, quadrantId);
				Vector3 axis3D = base.Gizmo.Transform.GetAxis3D(secondAxisDescriptor);
				_transform.Rotation3D = Quaternion.LookRotation(plane3D.normal, axis3D);
			}
			else
			{
				AxisDescriptor firstAxisDescriptor = PlaneIdHelper.GetFirstAxisDescriptor(planeId, quadrantId);
				Vector3 axis3D2 = base.Gizmo.Transform.GetAxis3D(firstAxisDescriptor);
				_transform.Rotation3D = Quaternion.LookRotation(plane3D.normal, axis3D2);
			}
		}

		public void MakeSliderPlane(GizmoTransform sliderPlaneTransform, PlaneId planeId, GizmoLineSlider3D firstAxisSlider, GizmoLineSlider3D secondAxisSlider, Camera camera)
		{
			PlaneQuadrantId planeQuadrantId = sliderPlaneTransform.Get3DQuadrantFacingCamera(planeId, camera);
			AlignToQuadrant(sliderPlaneTransform, planeId, planeQuadrantId, alignXToFirstAxis: true);
			Vector3 axis3D = sliderPlaneTransform.GetAxis3D(PlaneIdHelper.GetFirstAxisDescriptor(planeId, planeQuadrantId));
			Vector3 axis3D2 = sliderPlaneTransform.GetAxis3D(PlaneIdHelper.GetSecondAxisDescriptor(planeId, planeQuadrantId));
			Vector3 vector = axis3D * secondAxisSlider.GetRealSizeAlongDirection(camera, axis3D) * 0.5f + axis3D2 * firstAxisSlider.GetRealSizeAlongDirection(camera, axis3D2) * 0.5f;
			if (LookAndFeel.PlaneType == GizmoPlane3DType.Quad)
			{
				SetQuadCornerPosition(QuadCorner.BottomLeft, sliderPlaneTransform.Position3D + vector);
			}
		}

		public Vector3 GetQuadCornerPosition(QuadCorner corner)
		{
			return _quad.GetCornerPosition(corner);
		}

		public void SetQuadCornerPosition(QuadCorner corner, Vector3 cornerPosition)
		{
			Vector3 vector = Position - GetQuadCornerPosition(corner);
			Position = cornerPosition + vector;
		}

		public void ApplyZoomFactor(Camera camera)
		{
			if (LookAndFeel.UseZoomFactor)
			{
				float zoomFactor = GetZoomFactor(camera);
				_controllers[(int)LookAndFeel.PlaneType].UpdateTransforms(zoomFactor);
			}
		}

		public void SetDragChannel(GizmoDragChannel dragChannel)
		{
			_dragChannel = dragChannel;
			if (_dragChannel == GizmoDragChannel.Offset)
			{
				_selectedDragSession = _dblAxisOffsetDrag;
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
		}

		public void AddTargetTransform(GizmoTransform transform)
		{
			_dblAxisOffsetDrag.AddTargetTransform(transform);
			_rotationDrag.AddTargetTransform(transform);
			_scaleDrag.AddTargetTransform(transform);
		}

		public void AddTargetTransform(GizmoTransform transform, GizmoDragChannel dragChannel)
		{
			switch (dragChannel)
			{
			case GizmoDragChannel.Offset:
				_dblAxisOffsetDrag.AddTargetTransform(transform);
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
			_dblAxisOffsetDrag.RemoveTargetTransform(transform);
			_rotationDrag.RemoveTargetTransform(transform);
			_scaleDrag.RemoveTargetTransform(transform);
		}

		public void RemoveTargetTransform(GizmoTransform transform, GizmoDragChannel dragChannel)
		{
			switch (dragChannel)
			{
			case GizmoDragChannel.Offset:
				_dblAxisOffsetDrag.RemoveTargetTransform(transform);
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

		public override void Render(Camera camera)
		{
			if (IsRotating && LookAndFeel.PlaneType == GizmoPlane3DType.Circle && LookAndFeel.IsRotationArcVisible)
			{
				_rotationArc.RotationAngle = TotalDragRotation;
				_rotationArc.Radius = GetRealCircleRadius(GetZoomFactor(camera));
				_rotationArc.Render(LookAndFeel.RotationArcLookAndFeel);
			}
			if (base.IsVisible)
			{
				Color color = default(Color);
				color = (base.IsHovered ? LookAndFeel.HoveredColor : LookAndFeel.Color);
				GizmoSolidMaterial get = Singleton<GizmoSolidMaterial>.Get;
				get.ResetValuesToSensibleDefaults();
				get.SetCullModeOff();
				get.SetLit(LookAndFeel.ShadeMode == GizmoShadeMode.Lit);
				if (get.IsLit)
				{
					get.SetLightDirection(camera.transform.forward);
				}
				get.SetColor(color);
				get.SetPass(0);
				if (LookAndFeel.PlaneType == GizmoPlane3DType.Quad)
				{
					base.Handle.Render3DSolid(_quadIndex);
				}
				else if (LookAndFeel.PlaneType == GizmoPlane3DType.RATriangle)
				{
					base.Handle.Render3DSolid(_raTriangleIndex);
				}
				else if (LookAndFeel.PlaneType == GizmoPlane3DType.Circle)
				{
					base.Handle.Render3DSolid(_circleIndex);
				}
			}
			if (LookAndFeel.PlaneType == GizmoPlane3DType.Quad)
			{
				_quadBorder.Render(camera);
			}
			else if (LookAndFeel.PlaneType == GizmoPlane3DType.RATriangle)
			{
				_raTriangleBorder.Render(camera);
			}
			else if (LookAndFeel.PlaneType == GizmoPlane3DType.Circle)
			{
				_circleBorder.Render(camera);
			}
		}

		public void Refresh()
		{
			Camera workCamera = base.Gizmo.GetWorkCamera();
			float zoomFactor = GetZoomFactor(workCamera);
			_controllers[(int)LookAndFeel.PlaneType].UpdateHandles();
			_controllers[(int)LookAndFeel.PlaneType].UpdateEpsilons(zoomFactor);
			_controllers[(int)LookAndFeel.PlaneType].UpdateTransforms(zoomFactor);
		}

		protected override void OnVisibilityStateChanged()
		{
			_controllers[(int)LookAndFeel.PlaneType].UpdateHandles();
			Camera workCamera = base.Gizmo.GetWorkCamera();
			float zoomFactor = GetZoomFactor(workCamera);
			_controllers[(int)LookAndFeel.PlaneType].UpdateEpsilons(zoomFactor);
			_controllers[(int)LookAndFeel.PlaneType].UpdateTransforms(zoomFactor);
		}

		protected override void OnHoverableStateChanged()
		{
			base.Handle.Set3DShapeHoverable(_quadIndex, base.IsHoverable);
			base.Handle.Set3DShapeHoverable(_raTriangleIndex, base.IsHoverable);
			base.Handle.Set3DShapeHoverable(_circleIndex, base.IsHoverable);
		}

		private void OnGizmoPreUpdateBegin(Gizmo gizmo)
		{
			int planeType = (int)LookAndFeel.PlaneType;
			_controllers[planeType].UpdateHandles();
			_dblAxisOffsetDrag.Sensitivity = Settings.OffsetSensitivity;
			_rotationDrag.Sensitivity = Settings.RotationSensitivity;
			_scaleDrag.Sensitivity = Settings.ScaleSensitivity;
			float zoomFactor = GetZoomFactor(base.Gizmo.FocusCamera);
			_controllers[planeType].UpdateTransforms(zoomFactor);
			_controllers[planeType].UpdateEpsilons(zoomFactor);
		}

		private void OnTransformChanged(GizmoTransform transform, GizmoTransform.ChangeData changeData)
		{
			if (changeData.ChangeReason == GizmoTransform.ChangeReason.ParentChange || changeData.TRSDimension == GizmoDimension.Dim3D)
			{
				float zoomFactor = GetZoomFactor(base.Gizmo.GetWorkCamera());
				_controllers[(int)LookAndFeel.PlaneType].UpdateTransforms(zoomFactor);
			}
		}

		private void OnGizmoAttemptHandleDragBegin(Gizmo gizmo, int handleId)
		{
			if (handleId == base.HandleId)
			{
				if (_dragChannel == GizmoDragChannel.Offset)
				{
					GizmoDblAxisOffsetDrag3D.WorkData workData = new GizmoDblAxisOffsetDrag3D.WorkData
					{
						Axis0 = Right,
						Axis1 = Up,
						DragOrigin = Position,
						SnapStep0 = Settings.OffsetSnapStepRight,
						SnapStep1 = Settings.OffsetSnapStepUp
					};
					_dblAxisOffsetDrag.SetWorkData(workData);
				}
				else if (_dragChannel == GizmoDragChannel.Rotation)
				{
					GizmoSglAxisRotationDrag3D.WorkData workData2 = new GizmoSglAxisRotationDrag3D.WorkData
					{
						Axis = Normal,
						RotationPlanePos = Position,
						SnapMode = Settings.RotationSnapMode,
						SnapStep = Settings.RotationSnapStep
					};
					_rotationDrag.SetWorkData(workData2);
					Vector3 arcStart = Plane.ProjectPoint(base.Gizmo.HoverInfo.HoverPoint);
					_rotationArc.SetArcData(Normal, Position, arcStart, GetRealCircleRadius(GetZoomFactor(base.Gizmo.FocusCamera)));
				}
				else if (_dragChannel == GizmoDragChannel.Scale)
				{
					GizmoDblAxisScaleDrag3D.WorkData workData3 = new GizmoDblAxisScaleDrag3D.WorkData
					{
						Axis0 = Right,
						Axis1 = Up,
						DragOrigin = Position,
						AxisIndex0 = _scaleDragAxisIndexRight,
						AxisIndex1 = _scaleDragAxisIndexUp,
						SnapStep = Settings.ProportionalScaleSnapStep
					};
					_scaleDrag.SetWorkData(workData3);
				}
			}
		}

		private void OnCanHoverHandle(int handleId, Gizmo gizmo, GizmoHandleHoverData hoverData, YesNoAnswer answer)
		{
			if (handleId == base.HandleId && gizmo == base.Gizmo && LookAndFeel.PlaneType == GizmoPlane3DType.Circle && Settings.IsCircleHoverCullEnabled)
			{
				Vector3 normalized = (hoverData.HoverPoint - Position).normalized;
				if (base.Gizmo.FocusCamera.IsPointFacingCamera(hoverData.HoverPoint, normalized))
				{
					answer.Yes();
				}
				else
				{
					answer.No();
				}
			}
			else
			{
				answer.Yes();
			}
		}

		private void OnGizmoPostEnabled(Gizmo gizmo)
		{
			Refresh();
		}
	}
}
