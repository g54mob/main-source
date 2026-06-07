using System;
using UnityEngine;

namespace RLD
{
	public class GizmoCap2D : GizmoCap
	{
		private int _quadIndex;

		private QuadShape2D _quad = new QuadShape2D();

		private int _circleIndex;

		private CircleShape2D _circle = new CircleShape2D();

		private int _arrowIndex;

		private ConeShape2D _arrow = new ConeShape2D();

		private GizmoTransform _transform = new GizmoTransform();

		private GizmoOverrideColor _overrideFillColor = new GizmoOverrideColor();

		private GizmoOverrideColor _overrideBorderColor = new GizmoOverrideColor();

		private GizmoCap2DControllerData _controllerData;

		private IGizmoCap2DController[] _controllers = new IGizmoCap2DController[Enum.GetValues(typeof(GizmoCap2DType)).Length];

		private GizmoCap2DLookAndFeel _lookAndFeel = new GizmoCap2DLookAndFeel();

		private GizmoCap2DLookAndFeel _sharedLookAndFeel;

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

		public GizmoOverrideColor OverrideFillColor => _overrideFillColor;

		public GizmoOverrideColor OverrideBorderColor => _overrideBorderColor;

		public IGizmoDragSession DragSession
		{
			get
			{
				return base.Handle.DragSession;
			}
			set
			{
				base.Handle.DragSession = value;
			}
		}

		public GizmoCap2DLookAndFeel LookAndFeel
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

		public GizmoCap2DLookAndFeel SharedLookAndFeel
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

		public GizmoCap2D(Gizmo gizmo, int handleId)
			: base(gizmo, handleId)
		{
			_quadIndex = base.Handle.Add2DShape(_quad);
			_circleIndex = base.Handle.Add2DShape(_circle);
			_arrowIndex = base.Handle.Add2DShape(_arrow);
			_controllerData = new GizmoCap2DControllerData();
			_controllerData.Cap = this;
			_controllerData.CapHandle = base.Handle;
			_controllerData.Gizmo = base.Gizmo;
			_controllerData.Quad = _quad;
			_controllerData.QuadIndex = _quadIndex;
			_controllerData.Circle = _circle;
			_controllerData.CircleIndex = _circleIndex;
			_controllerData.Arrow = _arrow;
			_controllerData.ArrowIndex = _arrowIndex;
			_controllers[0] = new GizmoQuadCap2DController(_controllerData);
			_controllers[1] = new GizmoCircleCap2DController(_controllerData);
			_controllers[2] = new GizmoArrowCap2DController(_controllerData);
			_transform.SetParent(gizmo.Transform);
			_transform.Changed += OnTransformChanged;
			base.Gizmo.PreUpdateBegin += OnGizmoPreUpdateBegin;
			base.Gizmo.PostEnabled += OnGizmoPostEnabled;
		}

		public void RegisterTransformAsDragTarget(IGizmoDragSession dragSession)
		{
			dragSession.AddTargetTransform(_transform);
		}

		public void UnregisterTransformAsDragTarget(IGizmoDragSession dragSession)
		{
			dragSession.RemoveTargetTransform(_transform);
		}

		public void AlignTransformAxis(int axisIndex, AxisSign axisSign, Vector2 axis)
		{
			_transform.AlignAxis2D(axisIndex, axisSign, axis);
		}

		public float GetRealQuadWidth()
		{
			return LookAndFeel.QuadWidth * LookAndFeel.Scale;
		}

		public float GetRealQuadHeight()
		{
			return LookAndFeel.QuadHeight * LookAndFeel.Scale;
		}

		public float GetRealCircleRadius()
		{
			return LookAndFeel.CircleRadius * LookAndFeel.Scale;
		}

		public float GetRealArrowHeight()
		{
			return LookAndFeel.ArrowHeight * LookAndFeel.Scale;
		}

		public float GetRealArrowBaseRadius()
		{
			return LookAndFeel.ArrowBaseRadius * LookAndFeel.Scale;
		}

		public void CapSlider2D(Vector2 sliderDirection, Vector2 sliderEndPt)
		{
			_controllers[(int)LookAndFeel.CapType].CapSlider2D(sliderDirection, sliderEndPt);
		}

		public void CapSlider2DInvert(Vector2 sliderDirection, Vector2 sliderEndPt)
		{
			_controllers[(int)LookAndFeel.CapType].CapSlider2DInvert(sliderDirection, sliderEndPt);
		}

		public override void Render(Camera camera)
		{
			if (!base.IsVisible)
			{
				return;
			}
			if (LookAndFeel.FillMode == GizmoFillMode2D.FilledAndBorder || LookAndFeel.FillMode == GizmoFillMode2D.Filled)
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
			if (LookAndFeel.FillMode != GizmoFillMode2D.FilledAndBorder && LookAndFeel.FillMode != GizmoFillMode2D.Border)
			{
				return;
			}
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

		public void Refresh()
		{
			_controllers[(int)LookAndFeel.CapType].UpdateHandles();
			_controllers[(int)LookAndFeel.CapType].UpdateTransforms();
		}

		protected override void OnVisibilityStateChanged()
		{
			_controllers[(int)LookAndFeel.CapType].UpdateHandles();
			_controllers[(int)LookAndFeel.CapType].UpdateTransforms();
		}

		protected override void OnHoverableStateChanged()
		{
			base.Handle.SetHoverable(base.IsHoverable);
		}

		private void OnGizmoPreUpdateBegin(Gizmo gizmo)
		{
			int capType = (int)LookAndFeel.CapType;
			_controllers[capType].UpdateHandles();
			_controllers[capType].UpdateTransforms();
		}

		private void OnTransformChanged(GizmoTransform transform, GizmoTransform.ChangeData changeData)
		{
			if (changeData.TRSDimension == GizmoDimension.Dim2D || changeData.ChangeReason == GizmoTransform.ChangeReason.ParentChange)
			{
				_controllers[(int)LookAndFeel.CapType].UpdateTransforms();
			}
		}

		private void OnGizmoPostEnabled(Gizmo gizmo)
		{
			Refresh();
		}
	}
}
