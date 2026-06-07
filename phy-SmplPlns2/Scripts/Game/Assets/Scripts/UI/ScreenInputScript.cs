using System.Collections.Generic;
using Assets.Scripts.Input.Events;
using Jundroo.Common.Platform;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI
{
	public class ScreenInputScript : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, IScrollHandler
	{
		protected class TrackedInput
		{
			public Vector2 DragDelta { get; set; }

			public int Id { get; set; }

			public InputButton InputButton { get; set; }

			public Vector2 Position { get; set; }

			public Vector2 StartPosition { get; set; }

			public Vector2 TotalDragDelta { get; set; }

			public float TotalDragDistance => TotalDragDelta.magnitude;
		}

		private bool _allowPinch;

		[SerializeField]
		private Camera _camera;

		private PinchEvent _lastPinchEvent;

		public Camera Camera
		{
			get
			{
				return _camera;
			}
			set
			{
				_camera = value;
			}
		}

		public FingerToolMode FingerToolMode { get; set; }

		public IInputHandler InputHandler { get; set; }

		protected List<TrackedInput> TrackedInputs { get; private set; }

		public ScreenInputScript()
		{
			TrackedInputs = new List<TrackedInput>();
		}

		public virtual void OnDrag(PointerEventData eventData)
		{
			TrackedInput trackedInput = GetTrackedInput(eventData.pointerId);
			if (trackedInput != null)
			{
				trackedInput.Position = GetPointerPosition(eventData);
				trackedInput.TotalDragDelta += eventData.delta;
				trackedInput.DragDelta = eventData.delta;
				if (TrackedInputs.Count > 1 && _allowPinch)
				{
					CreatePinchEvent(InputState.Updated);
				}
				else
				{
					CreateInputEvent(InputState.Updated, trackedInput);
				}
			}
		}

		public virtual void OnPointerDown(PointerEventData eventData)
		{
			TrackedInput trackedInput = GetTrackedInput(eventData.pointerId);
			if (trackedInput == null)
			{
				trackedInput = new TrackedInput();
				trackedInput.Id = eventData.pointerId;
				trackedInput.Position = GetPointerPosition(eventData);
				trackedInput.StartPosition = trackedInput.StartPosition;
				if (eventData.button == PointerEventData.InputButton.Left)
				{
					trackedInput.InputButton = InputButton.Primary;
				}
				else if (eventData.button == PointerEventData.InputButton.Middle)
				{
					trackedInput.InputButton = InputButton.Middle;
				}
				else
				{
					trackedInput.InputButton = InputButton.Secondary;
				}
				TrackedInputs.Add(trackedInput);
				if (TrackedInputs.Count > 1 && _allowPinch)
				{
					CreatePinchEvent(InputState.Begin);
				}
				else
				{
					CreateInputEvent(InputState.Begin, trackedInput);
				}
			}
		}

		public virtual void OnPointerUp(PointerEventData eventData)
		{
			TrackedInput trackedInput = GetTrackedInput(eventData.pointerId);
			if (trackedInput != null)
			{
				trackedInput.Position = GetPointerPosition(eventData);
				trackedInput.TotalDragDelta += eventData.delta;
				trackedInput.DragDelta = eventData.delta;
				int count = TrackedInputs.Count;
				TrackedInputs.Remove(trackedInput);
				if (count > 1 && _allowPinch)
				{
					CreatePinchEvent(InputState.End);
				}
				else
				{
					CreateInputEvent(InputState.End, trackedInput);
				}
			}
		}

		public virtual void OnScroll(PointerEventData eventData)
		{
			MouseScrollEvent mouseScrollEvent = new MouseScrollEvent();
			mouseScrollEvent.Delta = eventData.scrollDelta.y;
			InputHandler.HandleScroll(mouseScrollEvent);
		}

		protected Vector2 GetPointerPosition(PointerEventData eventData)
		{
			return eventData.position;
		}

		protected virtual void Start()
		{
			_allowPinch = Device.IsMultiTouchEnabled;
		}

		private void CreateInputEvent(InputState inputState, TrackedInput input)
		{
			InputEvent inputEvent = new InputEvent();
			inputEvent.PointerId = input.Id;
			inputEvent.Position = input.Position;
			inputEvent.InputState = inputState;
			inputEvent.InputButton = input.InputButton;
			inputEvent.Ray = _camera.ScreenPointToRay(inputEvent.Position);
			inputEvent.FingerToolMode = FingerToolMode;
			inputEvent.DeltaPosition = input.DragDelta;
			inputEvent.DragDistanceSinceBegin = input.TotalDragDistance;
			inputEvent.DeltaPositionSinceBegin = input.TotalDragDelta;
			if (InputHandler != null)
			{
				InputHandler.HandleInput(inputEvent);
			}
		}

		private void CreatePinchEvent(InputState inputState)
		{
			PinchEvent pinchEvent = new PinchEvent();
			pinchEvent.InputState = inputState;
			pinchEvent.Midpoint = (TrackedInputs[0].Position + TrackedInputs[1].Position) / 2f;
			pinchEvent.Distance = (TrackedInputs[0].Position - TrackedInputs[1].Position).magnitude;
			if (inputState == InputState.Begin)
			{
				pinchEvent.StartDistance = pinchEvent.Distance;
				pinchEvent.StartMidpoint = pinchEvent.Midpoint;
				pinchEvent.DistanceDelta = 0f;
				pinchEvent.MidpointDelta = Vector2.zero;
			}
			else if (_lastPinchEvent != null)
			{
				pinchEvent.StartDistance = _lastPinchEvent.StartDistance;
				pinchEvent.StartMidpoint = _lastPinchEvent.StartMidpoint;
				pinchEvent.DistanceDelta = pinchEvent.Distance - _lastPinchEvent.Distance;
				pinchEvent.MidpointDelta = pinchEvent.Midpoint - _lastPinchEvent.Midpoint;
			}
			if (inputState != InputState.End)
			{
				_lastPinchEvent = pinchEvent;
			}
			else
			{
				_lastPinchEvent = null;
			}
			InputHandler.HandlePinch(pinchEvent);
		}

		private TrackedInput GetTrackedInput(int pointerId)
		{
			for (int i = 0; i < TrackedInputs.Count; i++)
			{
				if (TrackedInputs[i].Id == pointerId)
				{
					return TrackedInputs[i];
				}
			}
			return null;
		}
	}
}
