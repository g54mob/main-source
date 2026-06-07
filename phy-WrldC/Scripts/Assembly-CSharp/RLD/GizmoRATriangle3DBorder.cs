using System;
using UnityEngine;

namespace RLD
{
	public class GizmoRATriangle3DBorder
	{
		private GizmoPlaneSlider3D _planeSlider;

		private GizmoHandle _targetHandle;

		private RightAngTriangle3D _targetTriangle;

		private bool _isVisible = true;

		private bool _isHoverable = true;

		private int _borderTriangleIndex;

		private RightAngTriangle3D _borderTriangle = new RightAngTriangle3D();

		private GizmoRATriangle3DBorderControllerData _controllerData = new GizmoRATriangle3DBorderControllerData();

		private IGizmoRATriangle3DBorderController[] _controllers = new IGizmoRATriangle3DBorderController[Enum.GetValues(typeof(GizmoRATriangle3DBorderType)).Length];

		public bool IsVisible => _isVisible;

		public bool IsHoverable => _isHoverable;

		public Gizmo Gizmo => _targetHandle.Gizmo;

		public GizmoRATriangle3DBorder(GizmoPlaneSlider3D planeSlider, GizmoHandle targetHandle, RightAngTriangle3D targetRiangle)
		{
			_planeSlider = planeSlider;
			_targetHandle = targetHandle;
			_targetTriangle = targetRiangle;
			_borderTriangleIndex = _targetHandle.Add3DShape(_borderTriangle);
			_borderTriangle.RaycastMode = Shape3DRaycastMode.Wire;
			_controllerData.Border = this;
			_controllerData.PlaneSlider = _planeSlider;
			_controllerData.Gizmo = _targetHandle.Gizmo;
			_controllerData.TargetHandle = _targetHandle;
			_controllerData.TargetTriangle = _targetTriangle;
			_controllerData.BorderTriangle = _borderTriangle;
			_controllerData.BorderTriangleIndex = _borderTriangleIndex;
			_controllers[0] = new GizmoThinRATriangle3DBorderController(_controllerData);
			_targetHandle.Gizmo.PreUpdateBegin += OnGizmoPreUpdateBegin;
		}

		public void SetVisible(bool isVisible)
		{
			_isVisible = isVisible;
			_controllers[(int)_planeSlider.LookAndFeel.RATriangleBorderType].UpdateHandles();
			if (_isVisible)
			{
				float zoomFactor = GetZoomFactor(Gizmo.GetWorkCamera());
				_controllers[(int)_planeSlider.LookAndFeel.RATriangleBorderType].UpdateEpsilons(zoomFactor);
				OnTriangleShapeChanged();
			}
		}

		public void SetHoverable(bool isHoverable)
		{
			_isHoverable = isHoverable;
			_targetHandle.Set3DShapeHoverable(_borderTriangleIndex, isHoverable);
		}

		public float GetZoomFactor(Camera camera)
		{
			return _planeSlider.GetZoomFactor(camera);
		}

		public void OnTriangleShapeChanged()
		{
			float zoomFactor = GetZoomFactor(Gizmo.GetWorkCamera());
			_controllers[(int)_planeSlider.LookAndFeel.RATriangleBorderType].UpdateTransforms(zoomFactor);
		}

		public void Render(Camera camera)
		{
			if (IsVisible)
			{
				Color color = _planeSlider.LookAndFeel.BorderColor;
				if (_targetHandle.Gizmo.HoverHandleId == _targetHandle.Id)
				{
					color = _planeSlider.LookAndFeel.HoveredBorderColor;
				}
				if (_planeSlider.LookAndFeel.RATriangleBorderType == GizmoRATriangle3DBorderType.Thin)
				{
					GizmoLineMaterial get = Singleton<GizmoLineMaterial>.Get;
					get.ResetValuesToSensibleDefaults();
					get.SetColor(color);
					get.SetPass(0);
					_targetHandle.Render3DWire(_borderTriangleIndex);
				}
			}
		}

		private void OnGizmoPreUpdateBegin(Gizmo gizmo)
		{
			float zoomFactor = GetZoomFactor(Gizmo.FocusCamera);
			_controllers[(int)_planeSlider.LookAndFeel.RATriangleBorderType].UpdateHandles();
			_controllers[(int)_planeSlider.LookAndFeel.RATriangleBorderType].UpdateEpsilons(zoomFactor);
		}
	}
}
