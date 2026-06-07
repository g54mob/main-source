using System.Collections.Generic;
using ModApi;
using ModApi.Input.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui
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

			public float TotalDragDistance { get; set; }
		}

		private bool _allowPinch;

		[SerializeField]
		private Camera _camera;

		private IInputHandler _inputHandler;

		[SerializeField]
		private GameObject _inputHandlerGameObject;

		private PinchEventArgs _lastPinchEvent;

		public FingerToolMode FingerToolMode { get; set; }

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
				trackedInput.TotalDragDistance += eventData.delta.magnitude;
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
				trackedInput.TotalDragDistance += eventData.delta.magnitude;
				trackedInput.DragDelta = eventData.delta;
				if (TrackedInputs.Count > 1 && _allowPinch)
				{
					CreatePinchEvent(InputState.End);
				}
				else
				{
					CreateInputEvent(InputState.End, trackedInput);
				}
				TrackedInputs.Remove(trackedInput);
			}
		}

		public virtual void OnScroll(PointerEventData eventData)
		{
			ScrollEventArgs e = new ScrollEventArgs();
			e.Delta = eventData.scrollDelta;
			if (Device.IsOsxRuntime)
			{
				e.Delta = new Vector2(Mathf.Clamp(e.Delta.x / 2f, -8f, 8f), Mathf.Clamp(e.Delta.y / 2f, -8f, 8f));
			}
			_inputHandler.HandleScroll(e);
		}

		public void Start()
		{
			_allowPinch = Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer;
		}

		protected virtual void Awake()
		{
			MonoBehaviour[] components = _inputHandlerGameObject.GetComponents<MonoBehaviour>();
			for (int i = 0; i < components.Length; i++)
			{
				if (components[i] is IInputHandler inputHandler)
				{
					if (_inputHandler != null)
					{
						Debug.LogErrorFormat("Multiple Input Handlers on game object '{0}'", base.name);
					}
					else
					{
						_inputHandler = inputHandler;
					}
				}
			}
			if (_inputHandler == null)
			{
				Debug.LogErrorFormat("Input Handler not set on '{0}' game object", base.name);
			}
		}

		protected Vector2 GetPointerPosition(PointerEventData eventData)
		{
			return eventData.position;
		}

		private void CreateInputEvent(InputState inputState, TrackedInput input)
		{
			ClickEventArgs e = new ClickEventArgs();
			e.PointerId = input.Id;
			e.Position = input.Position;
			e.InputState = inputState;
			e.InputButton = input.InputButton;
			e.Ray = Utilities.ScreenPointToRay(_camera, e.Position);
			e.FingerToolMode = FingerToolMode;
			e.DeltaPosition = input.DragDelta;
			e.DragDistanceSinceBegin = input.TotalDragDistance;
			if (_inputHandler != null)
			{
				_inputHandler.HandleInput(e);
			}
		}

		private void CreatePinchEvent(InputState inputState)
		{
			PinchEventArgs e = new PinchEventArgs();
			e.InputState = inputState;
			e.Midpoint = (TrackedInputs[0].Position + TrackedInputs[1].Position) / 2f;
			e.Distance = (TrackedInputs[0].Position - TrackedInputs[1].Position).magnitude;
			if (inputState == InputState.Begin)
			{
				e.StartDistance = e.Distance;
				e.StartMidpoint = e.Midpoint;
				e.DistanceDelta = 0f;
				e.MidpointDelta = Vector2.zero;
			}
			else if (_lastPinchEvent != null)
			{
				e.StartDistance = _lastPinchEvent.StartDistance;
				e.StartMidpoint = _lastPinchEvent.StartMidpoint;
				e.DistanceDelta = e.Distance - _lastPinchEvent.Distance;
				e.MidpointDelta = e.Midpoint - _lastPinchEvent.Midpoint;
			}
			if (inputState != InputState.End)
			{
				_lastPinchEvent = e;
			}
			else
			{
				_lastPinchEvent = null;
			}
			_inputHandler.HandlePinch(e);
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
