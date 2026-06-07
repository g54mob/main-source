using Factory;
using Motorways.Audio;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Actions
{
	public class DragMotorwayHandleAction : MotorwaysPlayerAction
	{
		protected int _editedMotorwayId = -1;

		protected MotorwayView _motorwayView;

		protected Vector2 _offset;

		[Dependency]
		private IAudioSystem _audioSystem;

		[Dependency]
		private GameCamera _gameCamera;

		public float Attenuation => _gameCamera.GetAttenuationFromWorld(_motorwayView.RawHandlePosition);

		public float Pan => _gameCamera.GetPanFromWorld(_motorwayView.RawHandlePosition).x;

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			SetColourWidgetRadialVisible(visible: false);
			_motorwayView = _tilemapView.GetMotorwayView(_editedMotorwayId);
			_motorwayView.IsDraggingHandle = true;
			_offset = _motorwayView.RawHandlePosition - GetPointerWorldPosition();
			_audioSystem.ScheduleEvent(AudioEvent.CreateMotorwayEvent(AudioEventType.MotorwayHandlePulled, _motorwayView, Pan, Attenuation));
		}

		public override void Tick(float frameTime)
		{
			base.Tick(frameTime);
			if (_editedMotorwayId != -1 && _motorwayView != null)
			{
				Vector2 pointerWorldPosition = GetPointerWorldPosition();
				_motorwayView.RawHandlePosition = pointerWorldPosition + _offset;
			}
		}

		public override void OnActionComplete()
		{
			base.OnActionComplete();
			_motorwayView.IsDraggingHandle = false;
			_audioSystem.ScheduleEvent(AudioEvent.CreateMotorwayEvent(AudioEventType.MotorwayHandleReleased, _motorwayView, Pan, Attenuation, _motorwayView.HandleTension));
		}

		public override void OnActionCancel()
		{
			base.OnActionCancel();
			_motorwayView.IsDraggingHandle = false;
			_audioSystem.ScheduleEvent(AudioEvent.CreateMotorwayEvent(AudioEventType.MotorwayHandleReleased, _motorwayView, Pan, Attenuation, _motorwayView.HandleTension));
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			base.ObserveInput(timestamp, inputEvent, overUI);
			OnActionComplete();
		}

		public override void Reset()
		{
			base.Reset();
			_editedMotorwayId = -1;
			_motorwayView = null;
			_offset = default(Vector2);
		}

		public static DragMotorwayHandleAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			DragMotorwayHandleAction dragMotorwayHandleAction = scope.Get<DragMotorwayHandleAction>();
			dragMotorwayHandleAction.InitializeAction(owningGroup, timestamp);
			MotorwaysUIInputEvent motorwaysUIInputEvent = owningGroup.InstigatingInputEvent as MotorwaysUIInputEvent;
			dragMotorwayHandleAction._editedMotorwayId = motorwaysUIInputEvent.UIButtonIndex;
			if (motorwaysUIInputEvent.Source == InputEventSource.Mouse)
			{
				dragMotorwayHandleAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(19, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
			}
			else if (motorwaysUIInputEvent.Source == InputEventSource.Touch)
			{
				dragMotorwayHandleAction.RegisterObserveInputEvent(InputEventFilter.CreateTouchEventFilter(0, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
				dragMotorwayHandleAction.BlockNewTouchUpgradeActions();
			}
			dragMotorwayHandleAction.OnActionBegin(timestamp);
			return dragMotorwayHandleAction;
		}
	}
}
