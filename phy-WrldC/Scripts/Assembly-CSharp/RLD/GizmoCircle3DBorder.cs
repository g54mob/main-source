using System;
using UnityEngine;

namespace RLD
{
	public class GizmoCircle3DBorder
	{
		private GizmoPlaneSlider3D _planeSlider;

		private GizmoHandle _targetHandle;

		private CircleShape3D _targetCircle;

		private bool _isVisible = true;

		private bool _isHoverable = true;

		private int _borderCircleIndex;

		private int _borderTorusIndex;

		private int _borderCylTorusIndex;

		private CircleShape3D _borderCircle = new CircleShape3D();

		private TorusShape3D _borderTorus = new TorusShape3D();

		private CylTorusShape3D _borderCylTorus = new CylTorusShape3D();

		private GizmoCircle3DBorderControllerData _controllerData = new GizmoCircle3DBorderControllerData();

		private IGizmoCircle3DBorderController[] _controllers = new IGizmoCircle3DBorderController[Enum.GetValues(typeof(GizmoCircle3DBorderType)).Length];

		public bool IsVisible => _isVisible;

		public bool IsHoverable => _isHoverable;

		public Gizmo Gizmo => _targetHandle.Gizmo;

		public GizmoCircle3DBorder(GizmoPlaneSlider3D planeSlider, GizmoHandle targetHandle, CircleShape3D targetCircle)
		{
			_planeSlider = planeSlider;
			_targetHandle = targetHandle;
			_targetCircle = targetCircle;
			_borderCircleIndex = _targetHandle.Add3DShape(_borderCircle);
			_borderCircle.RaycastMode = Shape3DRaycastMode.Wire;
			_borderTorusIndex = _targetHandle.Add3DShape(_borderTorus);
			_borderTorus.WireRenderDesc.NumTubeSlices = 0;
			_borderCylTorusIndex = _targetHandle.Add3DShape(_borderCylTorus);
			_controllerData.Border = this;
			_controllerData.PlaneSlider = _planeSlider;
			_controllerData.Gizmo = Gizmo;
			_controllerData.TargetHandle = _targetHandle;
			_controllerData.TargetCircle = targetCircle;
			_controllerData.BorderCircle = _borderCircle;
			_controllerData.BorderTorus = _borderTorus;
			_controllerData.BorderCylTorus = _borderCylTorus;
			_controllerData.BorderCircleIndex = _borderCircleIndex;
			_controllerData.BorderTorusIndex = _borderTorusIndex;
			_controllerData.BorderCylTorusIndex = _borderCylTorusIndex;
			_controllers[0] = new GizmoThinCircle3DBorderController(_controllerData);
			_controllers[1] = new GizmoTorusCircle3DBorderController(_controllerData);
			_controllers[2] = new GizmoCylindricalTorusCircle3DBorderController(_controllerData);
			Gizmo.PreUpdateBegin += OnGizmoPreUpdateBegin;
		}

		public void SetVisible(bool isVisible)
		{
			_isVisible = isVisible;
			_controllers[(int)_planeSlider.LookAndFeel.CircleBorderType].UpdateHandles();
			if (_isVisible)
			{
				Camera workCamera = Gizmo.GetWorkCamera();
				float zoomFactor = GetZoomFactor(workCamera);
				_controllers[(int)_planeSlider.LookAndFeel.CircleBorderType].UpdateEpsilons(zoomFactor);
				OnCircleShapeChanged();
			}
		}

		public void SetHoverable(bool isHoverable)
		{
			_isHoverable = isHoverable;
			_targetHandle.Set3DShapeHoverable(_borderCircleIndex, isHoverable);
			_targetHandle.Set3DShapeHoverable(_borderTorusIndex, isHoverable);
			_targetHandle.Set3DShapeHoverable(_borderCylTorusIndex, isHoverable);
		}

		public float GetZoomFactor(Camera camera)
		{
			return _planeSlider.GetZoomFactor(camera);
		}

		public float GetRealTorusThickness(float zoomFactor)
		{
			return _planeSlider.LookAndFeel.BorderTorusThickness * zoomFactor * _planeSlider.LookAndFeel.Scale;
		}

		public float GetRealCylTorusWidth(float zoomFactor)
		{
			return _planeSlider.LookAndFeel.BorderCylTorusWidth * zoomFactor * _planeSlider.LookAndFeel.Scale;
		}

		public float GetRealCylTorusHeight(float zoomFactor)
		{
			return _planeSlider.LookAndFeel.BorderCylTorusHeight * zoomFactor * _planeSlider.LookAndFeel.Scale;
		}

		public void OnCircleShapeChanged()
		{
			float zoomFactor = GetZoomFactor(Gizmo.GetWorkCamera());
			_controllers[(int)_planeSlider.LookAndFeel.CircleBorderType].UpdateTransforms(zoomFactor);
		}

		public void Render(Camera camera)
		{
			if (!IsVisible)
			{
				return;
			}
			Color color = _planeSlider.LookAndFeel.BorderColor;
			if (_targetHandle.Gizmo.HoverHandleId == _targetHandle.Id)
			{
				color = _planeSlider.LookAndFeel.HoveredBorderColor;
			}
			if (_planeSlider.LookAndFeel.CircleBorderType == GizmoCircle3DBorderType.Thin)
			{
				GizmoCircularMaterial get = Singleton<GizmoCircularMaterial>.Get;
				get.CircularType = GizmoCircularMaterial.Type.Circle;
				get.ResetValuesToSensibleDefaults();
				get.SetCamera(camera);
				get.SetShapeCenter(_targetCircle.Center);
				get.SetCullAlphaScale(_planeSlider.LookAndFeel.BorderCircleCullAlphaScale);
				get.SetColor(color);
				get.SetPass(0);
				_targetHandle.Render3DWire(_borderCircleIndex);
			}
			else if (_planeSlider.LookAndFeel.CircleBorderType == GizmoCircle3DBorderType.Torus)
			{
				float zoomFactor = GetZoomFactor(camera);
				float realTorusThickness = GetRealTorusThickness(zoomFactor);
				bool flag = _planeSlider.LookAndFeel.BorderFillMode == GizmoFillMode3D.Filled;
				GizmoCircularMaterial get2 = Singleton<GizmoCircularMaterial>.Get;
				get2.CircularType = (flag ? GizmoCircularMaterial.Type.Torus : GizmoCircularMaterial.Type.Circle);
				get2.ResetValuesToSensibleDefaults();
				get2.SetCamera(camera);
				get2.SetShapeCenter(_targetCircle.Center);
				get2.SetCullAlphaScale(_planeSlider.LookAndFeel.BorderCircleCullAlphaScale);
				get2.SetColor(color);
				get2.SetTorusCoreRadius((_controllers[1] as GizmoTorusCircle3DBorderController).GetTorusCoreRadius(zoomFactor));
				get2.SetTorusTubeRadius(realTorusThickness * 0.5f);
				get2.SetLit(_planeSlider.LookAndFeel.BorderShadeMode == GizmoShadeMode.Lit);
				if (get2.IsLit)
				{
					get2.SetLightDirection(camera.transform.forward);
				}
				get2.SetPass(0);
				if (flag)
				{
					_targetHandle.Render3DSolid(_borderTorusIndex);
					return;
				}
				_borderTorus.WireRenderDesc.NumAxialSlices = _planeSlider.LookAndFeel.NumBorderTorusWireAxialSlices;
				_targetHandle.Render3DWire(_borderTorusIndex);
			}
			else if (_planeSlider.LookAndFeel.CircleBorderType == GizmoCircle3DBorderType.CylindricalTorus)
			{
				float zoomFactor2 = GetZoomFactor(camera);
				float realCylTorusWidth = GetRealCylTorusWidth(zoomFactor2);
				float realCylTorusHeight = GetRealCylTorusHeight(zoomFactor2);
				bool flag2 = _planeSlider.LookAndFeel.BorderFillMode == GizmoFillMode3D.Filled;
				GizmoCircularMaterial get3 = Singleton<GizmoCircularMaterial>.Get;
				get3.CircularType = (flag2 ? GizmoCircularMaterial.Type.CylindricalTorus : GizmoCircularMaterial.Type.Circle);
				get3.ResetValuesToSensibleDefaults();
				get3.SetCamera(camera);
				get3.SetShapeCenter(_targetCircle.Center);
				get3.SetCullAlphaScale(_planeSlider.LookAndFeel.BorderCircleCullAlphaScale);
				get3.SetColor(color);
				get3.SetTorusCoreRadius((_controllers[2] as GizmoCylindricalTorusCircle3DBorderController).GetTorusCoreRadius(zoomFactor2));
				get3.SetCylindricalTorusRadii(realCylTorusWidth * 0.5f, realCylTorusHeight * 0.5f);
				get3.SetLit(_planeSlider.LookAndFeel.BorderShadeMode == GizmoShadeMode.Lit);
				if (get3.IsLit)
				{
					get3.SetLightDirection(camera.transform.forward);
				}
				get3.SetPass(0);
				if (flag2)
				{
					_targetHandle.Render3DSolid(_borderCylTorusIndex);
				}
				else
				{
					_targetHandle.Render3DWire(_borderCylTorusIndex);
				}
			}
		}

		private void OnGizmoPreUpdateBegin(Gizmo gizmo)
		{
			float zoomFactor = GetZoomFactor(Gizmo.FocusCamera);
			_controllers[(int)_planeSlider.LookAndFeel.CircleBorderType].UpdateHandles();
			_controllers[(int)_planeSlider.LookAndFeel.CircleBorderType].UpdateEpsilons(zoomFactor);
		}
	}
}
