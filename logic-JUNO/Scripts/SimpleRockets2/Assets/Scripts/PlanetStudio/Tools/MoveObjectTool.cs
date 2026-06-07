using System;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.PlanetStudio.PlanetObjects;
using Assets.Scripts.Tools.ObjectTransform;
using ModApi;
using ModApi.Input.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.PlanetStudio.Tools
{
	public class MoveObjectTool
	{
		private Camera _camera;

		private TranslateGizmoWrapper _gizmo;

		private InputResponder _inputResponder = new InputResponder("MoveObjectTool");

		private IPlanetObject _planetObject;

		private PlanetStudioUIScript _planetStudioUI;

		private Transform _transform;

		private Vector3d _transformPosition;

		private CelestialBodyViewerScript _viewer;

		public bool IsActive { get; private set; }

		public event EventHandler OnEndDrag;

		public MoveObjectTool(GameObject gameObject, CelestialBodyViewerScript viewer)
		{
			_viewer = viewer;
			_gizmo = new TranslateGizmoWrapper(viewer.GizmoCamera, gameObject);
			_gizmo.Gizmo.RaycastDistance = 100000000f;
			_camera = viewer.GizmoCamera;
			_inputResponder.Priority = 10;
			_inputResponder.IsResponding = () => IsActive;
			_inputResponder.OnBeginDrag = OnInputResponderBeginDrag;
			_inputResponder.OnEndDrag = OnInputResponderEndDrag;
			_inputResponder.OnDrag = OnInputResponderDrag;
		}

		public void Recenter()
		{
			_transform.position = _viewer.ReferenceFrame.PlanetToFramePosition(_transformPosition);
			_transform.rotation = _planetObject.GetMoveToolRotation(_viewer.ReferenceFrame, _viewer.PlanetScript.PlanetNode);
		}

		public void ResetGizmoPosition()
		{
			_transformPosition = _planetObject.PlanetPosition;
			Recenter();
			if (_planetStudioUI == null)
			{
				_planetStudioUI = PlanetStudioScript.Instance.PlanetStudioUI as PlanetStudioUIScript;
			}
		}

		public void Start(Transform transform, IPlanetObject planetObject)
		{
			_transform = transform;
			_planetObject = planetObject;
			ResetGizmoPosition();
			_gizmo.Start(transform, showAdjustmentGizmo: true);
			if (!IsActive)
			{
				IsActive = true;
				_planetStudioUI.InputHandler.AddInputResponder(_inputResponder);
			}
		}

		public void Stop()
		{
			if (IsActive)
			{
				IsActive = false;
				_gizmo.Stop();
				_planetStudioUI.InputHandler.RemoveInputResponder(_inputResponder);
			}
		}

		private ClickEventArgs CreateInputEvent(PointerEventData eventData)
		{
			ClickEventArgs e = new ClickEventArgs();
			e.PointerId = eventData.pointerId;
			e.Position = eventData.position;
			e.InputButton = InputButton.Primary;
			e.Ray = Utilities.ScreenPointToRay(_camera, e.Position);
			e.FingerToolMode = FingerToolMode.None;
			e.DeltaPosition = eventData.delta;
			e.DragDistanceSinceBegin = 0f;
			return e;
		}

		private bool OnInputResponderBeginDrag(PointerEventData eventData)
		{
			ClickEventArgs e = CreateInputEvent(eventData);
			e.InputState = InputState.Begin;
			return _gizmo.HandleClick(e);
		}

		private bool OnInputResponderDrag(PointerEventData eventData)
		{
			ClickEventArgs e = CreateInputEvent(eventData);
			e.InputState = InputState.Updated;
			if (_gizmo.HandleClick(e))
			{
				bool adjustElevation = _gizmo.Gizmo.GizmoBeingDragged.AxisType == TranslateGizmoAxisScript.GizmoAxisType.Up;
				_transformPosition = _viewer.ReferenceFrame.FrameToPlanetPosition(_transform.position);
				_planetObject.SetPlanetPosition(_transformPosition, adjustElevation);
				_planetObject.UpdateGameViewObject(_viewer);
				Recenter();
				return true;
			}
			return false;
		}

		private bool OnInputResponderEndDrag(PointerEventData eventData)
		{
			ClickEventArgs e = CreateInputEvent(eventData);
			e.InputState = InputState.End;
			Recenter();
			ResetGizmoPosition();
			this.OnEndDrag?.Invoke(this, new EventArgs());
			return _gizmo.HandleClick(e);
		}
	}
}
