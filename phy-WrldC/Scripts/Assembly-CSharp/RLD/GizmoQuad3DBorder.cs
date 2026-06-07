using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class GizmoQuad3DBorder
	{
		private GizmoPlaneSlider3D _planeSlider;

		private GizmoHandle _targetHandle;

		private QuadShape3D _targetQuad;

		private bool _isVisible = true;

		private bool _isHoverable = true;

		private int _borderQuadIndex;

		private QuadShape3D _borderQuad = new QuadShape3D();

		private int _topBoxIndex;

		private BoxShape3D _topBox = new BoxShape3D();

		private int _rightBoxIndex;

		private BoxShape3D _rightBox = new BoxShape3D();

		private int _bottomBoxIndex;

		private BoxShape3D _bottomBox = new BoxShape3D();

		private int _leftBoxIndex;

		private BoxShape3D _leftBox = new BoxShape3D();

		private int _topLeftBoxIndex;

		private BoxShape3D _topLeftBox = new BoxShape3D();

		private int _topRightBoxIndex;

		private BoxShape3D _topRightBox = new BoxShape3D();

		private int _bottomRightBoxIndex;

		private BoxShape3D _bottomRightBox = new BoxShape3D();

		private int _bottomLeftBoxIndex;

		private BoxShape3D _bottomLeftBox = new BoxShape3D();

		private List<int> _sortedBoxIndices = new List<int>();

		private GizmoQuad3DBorderControllerData _controllerData = new GizmoQuad3DBorderControllerData();

		private IGizmoQuad3DBorderController[] _controllers = new IGizmoQuad3DBorderController[Enum.GetValues(typeof(GizmoQuad3DBorderType)).Length];

		public bool IsVisible => _isVisible;

		public bool IsHoverable => _isHoverable;

		public Gizmo Gizmo => _targetHandle.Gizmo;

		public GizmoQuad3DBorder(GizmoPlaneSlider3D planeSlider, GizmoHandle targetHandle, QuadShape3D targetQuad)
		{
			_planeSlider = planeSlider;
			_targetHandle = targetHandle;
			_targetQuad = targetQuad;
			_borderQuadIndex = _targetHandle.Add3DShape(_borderQuad);
			_borderQuad.RaycastMode = Shape3DRaycastMode.Wire;
			_topBoxIndex = _targetHandle.Add3DShape(_topBox);
			_rightBoxIndex = _targetHandle.Add3DShape(_rightBox);
			_bottomBoxIndex = _targetHandle.Add3DShape(_bottomBox);
			_leftBoxIndex = _targetHandle.Add3DShape(_leftBox);
			_topLeftBoxIndex = _targetHandle.Add3DShape(_topLeftBox);
			_topRightBoxIndex = _targetHandle.Add3DShape(_topRightBox);
			_bottomRightBoxIndex = _targetHandle.Add3DShape(_bottomRightBox);
			_bottomLeftBoxIndex = _targetHandle.Add3DShape(_bottomLeftBox);
			_sortedBoxIndices.Add(_topBoxIndex);
			_sortedBoxIndices.Add(_rightBoxIndex);
			_sortedBoxIndices.Add(_bottomBoxIndex);
			_sortedBoxIndices.Add(_leftBoxIndex);
			_sortedBoxIndices.Add(_topLeftBoxIndex);
			_sortedBoxIndices.Add(_topRightBoxIndex);
			_sortedBoxIndices.Add(_bottomRightBoxIndex);
			_sortedBoxIndices.Add(_bottomLeftBoxIndex);
			_controllerData.Border = this;
			_controllerData.PlaneSlider = _planeSlider;
			_controllerData.Gizmo = Gizmo;
			_controllerData.TargetHandle = _targetHandle;
			_controllerData.TargetQuad = _targetQuad;
			_controllerData.BorderQuad = _borderQuad;
			_controllerData.TopBox = _topBox;
			_controllerData.RightBox = _rightBox;
			_controllerData.BottomBox = _bottomBox;
			_controllerData.LeftBox = _leftBox;
			_controllerData.TopLeftBox = _topLeftBox;
			_controllerData.TopRightBox = _topRightBox;
			_controllerData.BottomRightBox = _bottomRightBox;
			_controllerData.BottomLeftBox = _bottomLeftBox;
			_controllerData.BorderQuadIndex = _borderQuadIndex;
			_controllerData.TopBoxIndex = _topBoxIndex;
			_controllerData.RightBoxIndex = _rightBoxIndex;
			_controllerData.BottomBoxIndex = _bottomBoxIndex;
			_controllerData.LeftBoxIndex = _leftBoxIndex;
			_controllerData.TopLeftBoxIndex = _topLeftBoxIndex;
			_controllerData.TopRightBoxIndex = _topRightBoxIndex;
			_controllerData.BottomRightBoxIndex = _bottomRightBoxIndex;
			_controllerData.BottomLeftBoxIndex = _bottomLeftBoxIndex;
			_controllers[0] = new GizmoThinQuad3DBorderController(_controllerData);
			_controllers[1] = new GizmoBoxQuad3DBorderController(_controllerData);
			Gizmo.PreUpdateBegin += OnGizmoPreUpdateBegin;
		}

		public void SetVisible(bool isVisible)
		{
			_isVisible = isVisible;
			_controllers[(int)_planeSlider.LookAndFeel.QuadBorderType].UpdateHandles();
			if (_isVisible)
			{
				Camera workCamera = Gizmo.GetWorkCamera();
				float zoomFactor = GetZoomFactor(workCamera);
				_controllers[(int)_planeSlider.LookAndFeel.QuadBorderType].UpdateEpsilons(zoomFactor);
				OnQuadShapeChanged();
			}
		}

		public void SetHoverable(bool isHoverable)
		{
			_isHoverable = isHoverable;
			_targetHandle.Set3DShapeHoverable(_borderQuadIndex, isHoverable);
			foreach (int sortedBoxIndex in _sortedBoxIndices)
			{
				_targetHandle.Set3DShapeHoverable(sortedBoxIndex, isHoverable);
			}
		}

		public float GetZoomFactor(Camera camera)
		{
			return _planeSlider.GetZoomFactor(camera);
		}

		public float GetRealBoxHeight(float zoomFactor)
		{
			return _planeSlider.LookAndFeel.BorderBoxHeight * zoomFactor * _planeSlider.LookAndFeel.Scale;
		}

		public float GetRealBoxDepth(float zoomFactor)
		{
			return _planeSlider.LookAndFeel.BorderBoxDepth * zoomFactor * _planeSlider.LookAndFeel.Scale;
		}

		public void OnQuadShapeChanged()
		{
			float zoomFactor = GetZoomFactor(Gizmo.GetWorkCamera());
			_controllers[(int)_planeSlider.LookAndFeel.QuadBorderType].UpdateTransforms(zoomFactor);
		}

		public void Render(Camera camera)
		{
			if (!IsVisible)
			{
				return;
			}
			GizmoPlaneSlider3DLookAndFeel lookAndFeel = _planeSlider.LookAndFeel;
			Color color = lookAndFeel.BorderColor;
			if (Gizmo.HoverHandleId == _targetHandle.Id)
			{
				color = lookAndFeel.HoveredBorderColor;
			}
			if (lookAndFeel.QuadBorderType == GizmoQuad3DBorderType.Thin)
			{
				GizmoLineMaterial get = Singleton<GizmoLineMaterial>.Get;
				get.ResetValuesToSensibleDefaults();
				get.SetColor(color);
				get.SetPass(0);
				_targetHandle.Render3DWire(_borderQuadIndex);
				return;
			}
			GizmoSolidMaterial get2 = Singleton<GizmoSolidMaterial>.Get;
			get2.ResetValuesToSensibleDefaults();
			get2.SetColor(color);
			get2.SetLit(lookAndFeel.BorderShadeMode == GizmoShadeMode.Lit);
			if (get2.IsLit)
			{
				get2.SetLightDirection(camera.transform.forward);
			}
			get2.SetPass(0);
			Vector3 camPos = camera.transform.position;
			_sortedBoxIndices.Sort(delegate(int i0, int i1)
			{
				BoxShape3D boxShape3D = _targetHandle.Get3DShape(i0) as BoxShape3D;
				BoxShape3D obj = _targetHandle.Get3DShape(i1) as BoxShape3D;
				float sqrMagnitude = (boxShape3D.Center - camPos).sqrMagnitude;
				return (obj.Center - camPos).sqrMagnitude.CompareTo(sqrMagnitude);
			});
			if (lookAndFeel.BorderFillMode == GizmoFillMode3D.Filled)
			{
				foreach (int sortedBoxIndex in _sortedBoxIndices)
				{
					_targetHandle.Render3DSolid(sortedBoxIndex);
				}
				return;
			}
			foreach (int sortedBoxIndex2 in _sortedBoxIndices)
			{
				_targetHandle.Render3DWire(sortedBoxIndex2);
			}
		}

		private void OnGizmoPreUpdateBegin(Gizmo gizmo)
		{
			float zoomFactor = GetZoomFactor(Gizmo.FocusCamera);
			_controllers[(int)_planeSlider.LookAndFeel.QuadBorderType].UpdateHandles();
			_controllers[(int)_planeSlider.LookAndFeel.QuadBorderType].UpdateEpsilons(zoomFactor);
		}
	}
}
