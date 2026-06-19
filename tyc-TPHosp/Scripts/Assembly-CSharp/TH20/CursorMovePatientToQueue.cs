using UnityEngine;

namespace TH20
{
	public class CursorMovePatientToQueue : CursorMode
	{
		private readonly Patient _patient;

		private readonly Level _level;

		private InspectorRoomQueueRow _dragObject;

		public CursorMovePatientToQueue(Level level, Patient patient)
			: base(level.CursorManager)
		{
			_patient = patient;
			_level = level;
		}

		public override void OnBecomeActive()
		{
			if (_dragObject == null)
			{
				GameObject gameObject = Object.Instantiate(GameAlgorithms.Config.PatientMoveQueueDragPrefab, _level.HUD.MenusTransform, worldPositionStays: false);
				_dragObject = gameObject.GetComponent<InspectorRoomQueueRow>();
			}
			_dragObject.Setup(null, _patient, null);
			_dragObject.EnableRaycast(isEnabled: false);
			_dragObject.Draggable = false;
			_dragObject.Clickable = false;
		}

		public override void OnBecomeInactive()
		{
			if (_dragObject != null)
			{
				Object.Destroy(_dragObject.gameObject);
				_dragObject = null;
			}
		}

		public override void Destroy()
		{
			base.Destroy();
			if (_dragObject != null)
			{
				Object.Destroy(_dragObject.gameObject);
				_dragObject = null;
			}
		}

		public override void CursorUpdate(InputManager inputManager)
		{
			if (_dragObject != null)
			{
				Vector2 vector = Camera.main.WorldToScreenPoint(_cursorManager.WorldPosition);
				vector += new Vector2(0f, -5f);
				_dragObject.transform.position = vector;
			}
			if (_patient == null)
			{
				base.Manager.PopMode<CursorMovePatientToQueue>();
				return;
			}
			if (inputManager.GetMouseQuickOnScene(MouseButton.Right))
			{
				base.Manager.PopMode<CursorMovePatientToQueue>();
				return;
			}
			Room queuingAtRoom = _patient.QueuingAtRoom;
			if (queuingAtRoom == null)
			{
				base.Manager.PopMode<CursorMovePatientToQueue>();
				return;
			}
			Room roomAtWorldCoord = _level.WorldState.GetRoomAtWorldCoord(_cursorManager.GridPosition, includeHospital: true, includeClosedPlots: false);
			if (roomAtWorldCoord != null && roomAtWorldCoord.FloorPlan != null && roomAtWorldCoord.FloorPlan.Doors.Count != 0 && roomAtWorldCoord.Definition._type == queuingAtRoom.Definition._type)
			{
				if (_dragObject != null)
				{
					_dragObject.SetBackingColor(Color.white);
				}
				if (roomAtWorldCoord.CanHighlight())
				{
					_level.HighlightManager.HighlightObject(roomAtWorldCoord);
				}
				if (inputManager.GetMouseDownOnScene(MouseButton.Left))
				{
					queuingAtRoom.RemoveFromQueue(_patient);
					roomAtWorldCoord.AddToQueue(_patient);
					base.Manager.PopMode<CursorMovePatientToQueue>();
				}
			}
			else if (_dragObject != null)
			{
				_dragObject.SetBackingColor(Color.red);
			}
		}
	}
}
