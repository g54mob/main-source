using System;
using UnityEngine;

namespace RLD
{
	public class GizmoCap3D : GizmoCap
	{
		private int _coneIndex;

		private ConeShape3D _cone = new ConeShape3D();

		private int _pyramidIndex;

		private PyramidShape3D _pyramid = new PyramidShape3D();

		private int _boxIndex;

		private BoxShape3D _box = new BoxShape3D();

		private int _sphereIndex;

		private SphereShape3D _sphere = new SphereShape3D();

		private int _trPrismIndex;

		private TriangPrismShape3D _trPrism = new TriangPrismShape3D();

		private GizmoCap3DControllerData _controllerData = new GizmoCap3DControllerData();

		private IGizmoCap3DController[] _controllers = new IGizmoCap3DController[Enum.GetValues(typeof(GizmoCap3DType)).Length];

		private GizmoTransform _transform = new GizmoTransform();

		private GizmoOverrideColor _overrideColor = new GizmoOverrideColor();

		private GizmoCap3DLookAndFeel _lookAndFeel = new GizmoCap3DLookAndFeel();

		private GizmoCap3DLookAndFeel _sharedLookAndFeel;

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

		public GizmoOverrideColor OverrideColor => _overrideColor;

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

		public GizmoCap3DLookAndFeel LookAndFeel
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

		public GizmoCap3DLookAndFeel SharedLookAndFeel
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

		public GizmoCap3D(Gizmo gizmo, int handleId)
			: base(gizmo, handleId)
		{
			_coneIndex = base.Handle.Add3DShape(_cone);
			_pyramidIndex = base.Handle.Add3DShape(_pyramid);
			_boxIndex = base.Handle.Add3DShape(_box);
			_sphereIndex = base.Handle.Add3DShape(_sphere);
			_trPrismIndex = base.Handle.Add3DShape(_trPrism);
			SetZoomFactorTransform(_transform);
			_controllerData.Gizmo = base.Gizmo;
			_controllerData.Cap = this;
			_controllerData.CapHandle = base.Handle;
			_controllerData.Cone = _cone;
			_controllerData.ConeIndex = _coneIndex;
			_controllerData.Pyramid = _pyramid;
			_controllerData.PyramidIndex = _pyramidIndex;
			_controllerData.Box = _box;
			_controllerData.BoxIndex = _boxIndex;
			_controllerData.Sphere = _sphere;
			_controllerData.SphereIndex = _sphereIndex;
			_controllerData.TrPrism = _trPrism;
			_controllerData.TrPrismIndex = _trPrismIndex;
			_controllers[0] = new GizmoConeCap3DController(_controllerData);
			_controllers[1] = new GizmoPyramidCap3DController(_controllerData);
			_controllers[2] = new GizmoBoxCap3DController(_controllerData);
			_controllers[3] = new GizmoSphereCap3DController(_controllerData);
			_controllers[4] = new GizmoTriPrismCap3DController(_controllerData);
			_transform.Changed += OnTransformChanged;
			_transform.SetParent(base.Gizmo.Transform);
			base.Gizmo.PreUpdateBegin += OnGizmoPreUpdateBegin;
			base.Gizmo.PostEnabled += OnGizmoPostEnabled;
			base.Gizmo.PostDisabled += OnGizmoPostDisabled;
		}

		public void RegisterTransformAsDragTarget(IGizmoDragSession dragSession)
		{
			dragSession.AddTargetTransform(_transform);
		}

		public void UnregisterTransformAsDragTarget(IGizmoDragSession dragSession)
		{
			dragSession.RemoveTargetTransform(_transform);
		}

		public void AlignTransformAxis(int axisIndex, AxisSign axisSign, Vector3 axis)
		{
			_transform.AlignAxis3D(axisIndex, axisSign, axis);
		}

		public void SetZoomFactorTransform(GizmoTransform transform)
		{
			base.Handle.SetZoomFactorTransform(transform);
		}

		public void CapSlider3D(Vector3 sliderDirection, Vector3 sliderEndPt)
		{
			_controllers[(int)LookAndFeel.CapType].CapSlider3D(sliderDirection, sliderEndPt, GetZoomFactor(base.Gizmo.GetWorkCamera()));
		}

		public void CapSlider3DInvert(Vector3 sliderDirection, Vector3 sliderEndPt)
		{
			_controllers[(int)LookAndFeel.CapType].CapSlider3DInvert(sliderDirection, sliderEndPt, GetZoomFactor(base.Gizmo.GetWorkCamera()));
		}

		public float GetSliderAlignedRealLength(float zoomFactor)
		{
			return _controllers[(int)LookAndFeel.CapType].GetSliderAlignedRealLength(zoomFactor);
		}

		public float GetZoomFactor(Camera camera)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				return 1f;
			}
			return base.Handle.GetZoomFactor(camera);
		}

		public float GetRealConeHeight(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			return LookAndFeel.ConeHeight * LookAndFeel.Scale * zoomFactor;
		}

		public float GetRealConeRadius(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			return LookAndFeel.ConeRadius * LookAndFeel.Scale * zoomFactor;
		}

		public float GetRealPyramidWidth(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			return LookAndFeel.PyramidWidth * LookAndFeel.Scale * zoomFactor;
		}

		public float GetRealPyramidDepth(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			return LookAndFeel.PyramidDepth * LookAndFeel.Scale * zoomFactor;
		}

		public float GetRealPyramidHeight(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			return LookAndFeel.PyramidHeight * LookAndFeel.Scale * zoomFactor;
		}

		public float GetRealBoxWidth(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			return LookAndFeel.BoxWidth * LookAndFeel.Scale * zoomFactor;
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

		public Vector3 GetRealBoxSize(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			return new Vector3(LookAndFeel.BoxWidth, LookAndFeel.BoxHeight, LookAndFeel.BoxDepth) * LookAndFeel.Scale * zoomFactor;
		}

		public float GetRealSphereRadius(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			return LookAndFeel.SphereRadius * LookAndFeel.Scale * zoomFactor;
		}

		public float GetRealTriPrismWidth(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			return LookAndFeel.TrPrismWidth * LookAndFeel.Scale * zoomFactor;
		}

		public float GetRealTriPrismHeight(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			return LookAndFeel.TrPrismHeight * LookAndFeel.Scale * zoomFactor;
		}

		public float GetRealTriPrismDepth(float zoomFactor)
		{
			if (!LookAndFeel.UseZoomFactor)
			{
				zoomFactor = 1f;
			}
			return LookAndFeel.TrPrismDepth * LookAndFeel.Scale * zoomFactor;
		}

		public void ApplyZoomFactor(Camera camera)
		{
			if (LookAndFeel.UseZoomFactor)
			{
				_controllers[(int)LookAndFeel.CapType].UpdateTransforms(GetZoomFactor(camera));
			}
		}

		public override void Render(Camera camera)
		{
			if (!base.IsVisible)
			{
				return;
			}
			Color color = default(Color);
			color = (OverrideColor.IsActive ? OverrideColor.Color : ((!base.Gizmo.IsHovered || base.Gizmo.HoverInfo.HandleId != base.HandleId) ? LookAndFeel.Color : LookAndFeel.HoveredColor));
			if (LookAndFeel.FillMode == GizmoFillMode3D.Filled)
			{
				bool flag = LookAndFeel.ShadeMode == GizmoShadeMode.Lit;
				GizmoSolidMaterial get = Singleton<GizmoSolidMaterial>.Get;
				get.ResetValuesToSensibleDefaults();
				get.SetLit(flag);
				if (flag)
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
			if (LookAndFeel.CapType == GizmoCap3DType.Sphere && LookAndFeel.IsSphereBorderVisible)
			{
				GizmoLineMaterial get3 = Singleton<GizmoLineMaterial>.Get;
				get3.ResetValuesToSensibleDefaults();
				get3.SetColor(LookAndFeel.SphereBorderColor);
				get3.SetPass(0);
				GLRenderer.DrawSphereBorder(camera, Position, GetRealSphereRadius(GetZoomFactor(camera)), LookAndFeel.NumSphereBorderPoints);
			}
		}

		public void Refresh()
		{
			Camera workCamera = base.Gizmo.GetWorkCamera();
			float zoomFactor = GetZoomFactor(workCamera);
			_controllers[(int)LookAndFeel.CapType].UpdateHandles();
			_controllers[(int)LookAndFeel.CapType].UpdateTransforms(zoomFactor);
		}

		protected override void OnVisibilityStateChanged()
		{
			_controllers[(int)LookAndFeel.CapType].UpdateHandles();
			Camera workCamera = base.Gizmo.GetWorkCamera();
			_controllers[(int)LookAndFeel.CapType].UpdateTransforms(GetZoomFactor(workCamera));
		}

		protected override void OnHoverableStateChanged()
		{
			base.Handle.SetHoverable(base.IsHoverable);
		}

		private void OnGizmoPreUpdateBegin(Gizmo gizmo)
		{
			int capType = (int)LookAndFeel.CapType;
			_controllers[capType].UpdateHandles();
			_controllers[capType].UpdateTransforms(GetZoomFactor(base.Gizmo.FocusCamera));
		}

		private void OnTransformChanged(GizmoTransform transform, GizmoTransform.ChangeData changeData)
		{
			if (changeData.ChangeReason == GizmoTransform.ChangeReason.ParentChange || changeData.TRSDimension == GizmoDimension.Dim3D)
			{
				_controllers[(int)LookAndFeel.CapType].UpdateTransforms(GetZoomFactor(base.Gizmo.GetWorkCamera()));
			}
		}

		private void OnGizmoPostEnabled(Gizmo gizmo)
		{
			Refresh();
		}

		private void OnGizmoPostDisabled(Gizmo gizmo)
		{
			OverrideColor.IsActive = false;
		}
	}
}
