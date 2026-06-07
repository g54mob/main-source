using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class GizmoPlaneSlider2D : GizmoSlider
	{
		private int _quadIndex;

		private int _circleIndex;

		private int _polygonIndex;

		private QuadShape2D _quad = new QuadShape2D();

		private CircleShape2D _circle = new CircleShape2D();

		private PolygonShape2D _polygon = new PolygonShape2D();

		private GizmoQuad2DBorder _quadBorder;

		private GizmoCircle2DBorder _circleBorder;

		private GizmoPolygon2DBorder _polygonBorder;

		private bool _isBorderVisible = true;

		private bool _isBorderHoverable = true;

		private GizmoTransform _transform = new GizmoTransform();

		private GizmoDragChannel _dragChannel = GizmoDragChannel.Offset;

		private IGizmoDragSession _selectedDragSession;

		private GizmoDblAxisOffsetDrag3D _offsetDrag = new GizmoDblAxisOffsetDrag3D();

		private Vector3 _offsetDragOrigin;

		private GizmoSglAxisRotationDrag3D _rotationDrag = new GizmoSglAxisRotationDrag3D();

		private GizmoRotationArc2D _rotationArc = new GizmoRotationArc2D();

		private GizmoDblAxisScaleDrag3D _scaleDrag = new GizmoDblAxisScaleDrag3D();

		private Vector3 _scaleDragOrigin;

		private Vector3 _scaleAxisRight;

		private Vector3 _scaleAxisUp;

		private int _scaleDragAxisIndexRight;

		private int _scaleDragAxisIndexUp = 1;

		private GizmoPlaneSlider2DControllerData _controllerData = new GizmoPlaneSlider2DControllerData();

		private IGizmoPlaneSlider2DController[] _controllers = new IGizmoPlaneSlider2DController[Enum.GetValues(typeof(GizmoPlane2DType)).Length];

		private GizmoPlaneSlider2DSettings _settings = new GizmoPlaneSlider2DSettings();

		private GizmoPlaneSlider2DSettings _sharedSettings;

		private GizmoPlaneSlider2DLookAndFeel _lookAndFeel = new GizmoPlaneSlider2DLookAndFeel();

		private GizmoPlaneSlider2DLookAndFeel _sharedLookAndFeel;

		public GizmoPlaneSlider2DSettings Settings
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

		public GizmoPlaneSlider2DSettings SharedSettings
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

		public GizmoPlaneSlider2DLookAndFeel LookAndFeel
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

		public GizmoPlaneSlider2DLookAndFeel SharedLookAndFeel
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

		public Vector2 Position
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

		public Vector2 PolyCenter => _polygon.GetEncapsulatingRect().center;

		public Quaternion Rotation => _transform.Rotation2D;

		public float RotationDegrees
		{
			get
			{
				return _transform.Rotation2DDegrees;
			}
			set
			{
				_transform.Rotation2DDegrees = value;
			}
		}

		public Vector2 Right => _transform.GetAxis2D(0, AxisSign.Positive);

		public Vector2 Up => _transform.GetAxis2D(1, AxisSign.Positive);

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

		public GizmoDragChannel DragChannel => _dragChannel;

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

		public Vector3 TotalDragOffset => _offsetDrag.TotalDragOffset;

		public Vector3 RelativeDragOffset => _offsetDrag.RelativeDragOffset;

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

		public bool IsMoving => _offsetDrag.IsActive;

		public bool IsRotating => _rotationDrag.IsActive;

		public bool IsScaling => _scaleDrag.IsActive;

		public GizmoPlaneSlider2D(Gizmo gizmo, int handleId)
			: base(gizmo, handleId)
		{
			_quadIndex = base.Handle.Add2DShape(_quad);
			_circleIndex = base.Handle.Add2DShape(_circle);
			_polygonIndex = base.Handle.Add2DShape(_polygon);
			_quadBorder = new GizmoQuad2DBorder(this, base.Handle, _quad);
			_circleBorder = new GizmoCircle2DBorder(this, base.Handle, _circle);
			_polygonBorder = new GizmoPolygon2DBorder(this, base.Handle, _polygon);
			_controllerData.Gizmo = base.Gizmo;
			_controllerData.Slider = this;
			_controllerData.SliderHandle = base.Handle;
			_controllerData.QuadBorder = _quadBorder;
			_controllerData.Quad = _quad;
			_controllerData.QuadIndex = _quadIndex;
			_controllerData.CircleBorder = _circleBorder;
			_controllerData.Circle = _circle;
			_controllerData.CircleIndex = _circleIndex;
			_controllerData.PolygonBorder = _polygonBorder;
			_controllerData.Polygon = _polygon;
			_controllerData.PolygonIndex = _polygonIndex;
			_controllers[0] = new GizmoQuadPlaneSlider2DController(_controllerData);
			_controllers[1] = new GizmoCirclePlaneSlider2DController(_controllerData);
			_controllers[2] = new GizmoPolygonPlaneSlider2DController(_controllerData);
			_transform.Changed += OnTransformChanged;
			base.Gizmo.PreUpdateBegin += OnGizmoPreUpdateBegin;
			base.Gizmo.PreDragBeginAttempt += OnGizmoAttemptHandleDragBegin;
			base.Gizmo.PreDragUpdate += OnGizmoHandleDragUpdate;
			base.Gizmo.PostEnabled += OnGizmoPostEnabled;
			AddTargetTransform(_transform);
			AddTargetTransform(base.Gizmo.Transform);
			_transform.SetParent(base.Gizmo.Transform);
			SetDragChannel(GizmoDragChannel.Offset);
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
			_circleBorder.SetHoverable(isHoverable);
			_polygonBorder.SetHoverable(isHoverable);
		}

		public override void SetSnapEnabled(bool isEnabled)
		{
			_offsetDrag.IsSnapEnabled = isEnabled;
			_rotationDrag.IsSnapEnabled = isEnabled;
			_scaleDrag.IsSnapEnabled = isEnabled;
		}

		public void SetPolyCwPoints(List<Vector2> cwPoints, bool isClosed)
		{
			if (LookAndFeel.PlaneType == GizmoPlane2DType.Polygon)
			{
				_polygon.SetClockwisePoints(cwPoints, isClosed);
				_controllers[2].UpdateTransforms();
			}
		}

		public void MakePolySphereBorder(Vector3 sphereCenter, float sphereRadius, int numPoints, Camera camera)
		{
			if (LookAndFeel.PlaneType == GizmoPlane2DType.Polygon)
			{
				_polygon.MakeSphereBorder(sphereCenter, sphereRadius, numPoints, camera);
				_controllers[2].UpdateTransforms();
			}
		}

		public float GetRealQuadWidth()
		{
			float num = 1f;
			if (IsScaling)
			{
				Vector3 vector = _scaleAxisRight * TotalDragScaleRight;
				num = Vector3Ex.ConvertDirTo2D(ScaleDragOrigin, ScaleDragOrigin + vector, base.Gizmo.GetWorkCamera()).magnitude / (LookAndFeel.QuadWidth * LookAndFeel.Scale * 0.5f) * Mathf.Sign(TotalDragScaleRight);
			}
			return LookAndFeel.QuadWidth * LookAndFeel.Scale * num;
		}

		public float GetRealQuadHeight()
		{
			float num = 1f;
			if (IsScaling)
			{
				Vector3 vector = _scaleAxisUp * TotalDragScaleUp;
				num = Vector3Ex.ConvertDirTo2D(ScaleDragOrigin, ScaleDragOrigin + vector, base.Gizmo.GetWorkCamera()).magnitude / (LookAndFeel.QuadHeight * LookAndFeel.Scale * 0.5f) * Mathf.Sign(TotalDragScaleUp);
			}
			return LookAndFeel.QuadHeight * LookAndFeel.Scale * num;
		}

		public Vector2 GetRealQuadSize()
		{
			return new Vector2(GetRealQuadWidth(), GetRealQuadHeight());
		}

		public float GetRealCircleRadius()
		{
			float num = 1f;
			if (IsScaling)
			{
				float num2 = TotalDragScaleRight;
				if (Mathf.Abs(TotalDragScaleRight) < Mathf.Abs(TotalDragScaleUp))
				{
					num2 = TotalDragScaleUp;
				}
				Vector3 vector = _scaleAxisUp * num2;
				num = Vector3Ex.ConvertDirTo2D(ScaleDragOrigin, ScaleDragOrigin + vector, base.Gizmo.GetWorkCamera()).magnitude / (LookAndFeel.CircleRadius * LookAndFeel.Scale) * Mathf.Sign(num2);
			}
			return LookAndFeel.CircleRadius * LookAndFeel.Scale * num;
		}

		public Vector2 GetRealExtentPoint(Shape2DExtentPoint extentPt)
		{
			return _controllers[(int)LookAndFeel.PlaneType].GetRealExtentPoint(extentPt);
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

		public override void Render(Camera camera)
		{
			if (!base.IsVisible && !IsBorderVisible)
			{
				return;
			}
			if (IsRotating && LookAndFeel.IsRotationArcVisible && (LookAndFeel.PlaneType == GizmoPlane2DType.Circle || LookAndFeel.PlaneType == GizmoPlane2DType.Polygon) && camera == base.Gizmo.FocusCamera)
			{
				_rotationArc.RotationAngle = TotalDragRotation;
				_rotationArc.Render(LookAndFeel.RotationArcLookAndFeel, camera);
			}
			if (base.IsVisible && (LookAndFeel.FillMode == GizmoFillMode2D.Filled || LookAndFeel.FillMode == GizmoFillMode2D.FilledAndBorder))
			{
				Color color = LookAndFeel.Color;
				if (base.Gizmo.HoverHandleId == base.HandleId)
				{
					color = LookAndFeel.HoveredColor;
				}
				GizmoSolidMaterial get = Singleton<GizmoSolidMaterial>.Get;
				get.ResetValuesToSensibleDefaults();
				get.SetLit(isLit: false);
				get.SetColor(color);
				get.SetPass(0);
				base.Handle.Render2DSolid(camera);
			}
			if (IsBorderVisible && (LookAndFeel.FillMode == GizmoFillMode2D.Border || LookAndFeel.FillMode == GizmoFillMode2D.FilledAndBorder))
			{
				if (LookAndFeel.PlaneType == GizmoPlane2DType.Quad)
				{
					_quadBorder.Render(camera);
				}
				else if (LookAndFeel.PlaneType == GizmoPlane2DType.Circle)
				{
					_circleBorder.Render(camera);
				}
				else if (LookAndFeel.PlaneType == GizmoPlane2DType.Polygon)
				{
					_polygonBorder.Render(camera);
				}
			}
		}

		public void Refresh()
		{
			_controllers[(int)LookAndFeel.PlaneType].UpdateHandles();
			_controllers[(int)LookAndFeel.PlaneType].UpdateEpsilons();
			_controllers[(int)LookAndFeel.PlaneType].UpdateTransforms();
		}

		protected override void OnVisibilityStateChanged()
		{
			_controllers[(int)LookAndFeel.PlaneType].UpdateHandles();
			_controllers[(int)LookAndFeel.PlaneType].UpdateEpsilons();
			_controllers[(int)LookAndFeel.PlaneType].UpdateTransforms();
		}

		protected override void OnHoverableStateChanged()
		{
			base.Handle.Set2DShapeHoverable(_quadIndex, base.IsHoverable);
			base.Handle.Set2DShapeHoverable(_circleIndex, base.IsHoverable);
		}

		private void OnGizmoPreUpdateBegin(Gizmo gizmo)
		{
			int planeType = (int)LookAndFeel.PlaneType;
			_controllers[planeType].UpdateHandles();
			_offsetDrag.Sensitivity = Settings.OffsetSensitivity;
			_rotationDrag.Sensitivity = Settings.RotationSensitivity;
			_scaleDrag.Sensitivity = Settings.ScaleSensitivity;
			_controllers[planeType].UpdateTransforms();
			_controllers[planeType].UpdateEpsilons();
		}

		private void OnTransformChanged(GizmoTransform transform, GizmoTransform.ChangeData changeData)
		{
			if (changeData.TRSDimension == GizmoDimension.Dim2D || changeData.ChangeReason == GizmoTransform.ChangeReason.ParentChange)
			{
				_controllers[(int)LookAndFeel.PlaneType].UpdateTransforms();
			}
		}

		private void OnGizmoAttemptHandleDragBegin(Gizmo gizmo, int handleId)
		{
			if (handleId != base.HandleId)
			{
				return;
			}
			if (_dragChannel == GizmoDragChannel.Offset)
			{
				GizmoDblAxisOffsetDrag3D.WorkData workData = new GizmoDblAxisOffsetDrag3D.WorkData
				{
					Axis0 = Vector2Ex.ConvertDirTo3D(_transform.Right2D, OffsetDragOrigin, base.Gizmo.FocusCamera).normalized,
					Axis1 = Vector2Ex.ConvertDirTo3D(_transform.Up2D, OffsetDragOrigin, base.Gizmo.FocusCamera).normalized,
					DragOrigin = OffsetDragOrigin,
					SnapStep0 = Settings.OffsetSnapStepRight,
					SnapStep1 = Settings.OffsetSnapStepUp
				};
				_offsetDrag.SetWorkData(workData);
			}
			else if (_dragChannel == GizmoDragChannel.Rotation)
			{
				GizmoSglAxisRotationDrag3D.WorkData workData2 = new GizmoSglAxisRotationDrag3D.WorkData
				{
					Axis = base.Gizmo.FocusCamera.transform.forward,
					SnapMode = Settings.RotationSnapMode,
					SnapStep = Settings.RotationSnapStep
				};
				if (LookAndFeel.PlaneType != GizmoPlane2DType.Polygon)
				{
					workData2.RotationPlanePos = base.Gizmo.FocusCamera.ScreenToWorldPoint(new Vector3(Position.x, Position.y, base.Gizmo.FocusCamera.nearClipPlane));
				}
				if (LookAndFeel.PlaneType == GizmoPlane2DType.Circle)
				{
					_rotationArc.SetArcData(Position, base.Gizmo.HoverInfo.HoverPoint, GetRealCircleRadius());
					_rotationArc.Type = GizmoRotationArc2D.ArcType.Standard;
				}
				else if (LookAndFeel.PlaneType == GizmoPlane2DType.Polygon)
				{
					Vector3 vector = PolyCenter;
					workData2.RotationPlanePos = base.Gizmo.FocusCamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, base.Gizmo.FocusCamera.nearClipPlane));
					_rotationArc.SetArcData(PolyCenter, base.Gizmo.HoverInfo.HoverPoint, 1f);
					_rotationArc.Type = GizmoRotationArc2D.ArcType.PolyProjected;
					_rotationArc.ProjectionPoly = _polygon;
					_rotationArc.NumProjectedPoints = 100;
				}
				_rotationDrag.SetWorkData(workData2);
			}
			else if (_dragChannel == GizmoDragChannel.Scale)
			{
				_scaleAxisRight = Vector2Ex.ConvertDirTo3D(Position, GetRealExtentPoint(Shape2DExtentPoint.Right), ScaleDragOrigin, base.Gizmo.FocusCamera);
				_scaleAxisUp = Vector2Ex.ConvertDirTo3D(Position, GetRealExtentPoint(Shape2DExtentPoint.Top), ScaleDragOrigin, base.Gizmo.FocusCamera);
				GizmoDblAxisScaleDrag3D.WorkData workData3 = new GizmoDblAxisScaleDrag3D.WorkData
				{
					Axis0 = _scaleAxisRight.normalized,
					Axis1 = _scaleAxisUp.normalized,
					AxisIndex0 = _scaleDragAxisIndexRight,
					AxisIndex1 = _scaleDragAxisIndexUp,
					DragOrigin = ScaleDragOrigin,
					SnapStep = Settings.ProportionalScaleSnapStep
				};
				_scaleDrag.SetWorkData(workData3);
			}
		}

		private void OnGizmoHandleDragUpdate(Gizmo gizmo, int handleId)
		{
			if (handleId == base.HandleId && DragChannel == GizmoDragChannel.Rotation)
			{
				_transform.Rotate2D(RelativeDragRotation);
			}
		}

		private void OnGizmoPostEnabled(Gizmo gizmo)
		{
			Refresh();
		}
	}
}
