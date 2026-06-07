using Factory;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Actions
{
	public class ControllerCameraAction : MotorwaysPlayerAction
	{
		[Dependency]
		private CameraView _cameraView;

		[Dependency]
		protected VisualConstantsData _visualConstants;

		[Dependency]
		private PlayerActionController _playerActionController;

		[Dependency]
		private ActivePlayer _player;

		private Vector2 _initialScreenPosition;

		private Vector2 _panOriginWorldPosition;

		private Vector2 _focusPanDelta;

		public override void OnActionBegin(float timestamp)
		{
			if (!_cameraView.IsFocussedIn)
			{
				OnActionCancel();
				return;
			}
			base.OnActionBegin(timestamp);
			_gameUI.SetFocusPointActive(active: false);
			_initialScreenPosition = GetPointerScreenPosition();
			PlayerAction.Log.Info("Beginning MouseCameraAction from {0}.", _initialScreenPosition);
		}

		public override void Tick(float frameTime)
		{
			base.Tick(frameTime);
			_focusPanDelta = GetPanFocusJoystickInputValue();
			if (_focusPanDelta.sqrMagnitude < 0.001f)
			{
				OnActionComplete();
				return;
			}
			Vector2 vector = new Vector2(Mathf.Abs(_focusPanDelta.x), Mathf.Abs(_focusPanDelta.y));
			Vector2 focusPanDelta = _focusPanDelta * vector * (_visualConstants.BaseControllerSpeed * _tilemapView.ScreenDistanceBetweenTiles) * frameTime;
			_focusPanDelta = focusPanDelta;
			Vector2 pointerScreenPosition = GetPointerScreenPosition();
			_panOriginWorldPosition = _tilemapView.GetWorldPositionFromScreenPosition(pointerScreenPosition);
			if (!Diagnostics.Verify(_visualConstants.PanningSpeedPerZoomLevel.Count > 0 && _player.ZoomLevel < 0))
			{
				int index = Mathf.Clamp(_player.ZoomLevel, 0, _visualConstants.PanningSpeedPerZoomLevel.Count - 1);
				_focusPanDelta *= _visualConstants.PanningSpeedPerZoomLevel[index];
			}
			if (_focusPanDelta != Vector2.zero)
			{
				_cameraView.ApplyPlayerPanPosition(_panOriginWorldPosition, pointerScreenPosition - _focusPanDelta);
			}
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			base.ObserveInput(timestamp, inputEvent, overUI);
			if (inputEvent.ButtonState == InputEventButtonState.Axis && inputEvent is AxisInputEvent && Mathf.Approximately(GetPanFocusJoystickInputValue().sqrMagnitude, 0f))
			{
				OnActionComplete();
			}
		}

		public static ControllerCameraAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ControllerCameraAction controllerCameraAction = scope.Get<ControllerCameraAction>();
			controllerCameraAction.InitializeAction(owningGroup, timestamp);
			PlayerAction.Log.Info("[ControllerCameraAction] Creating new instance of action: {0}", timestamp);
			controllerCameraAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(owningGroup.InstigatingInputEvent.Source, 34, InputEventButtonState.Axis), ObserverGreediness.BlocksNewActions);
			controllerCameraAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(owningGroup.InstigatingInputEvent.Source, 33, InputEventButtonState.Axis), ObserverGreediness.BlocksNewActions);
			controllerCameraAction.OnActionBegin(timestamp);
			return controllerCameraAction;
		}

		public override void Reset()
		{
			base.Reset();
			_initialScreenPosition = default(Vector2);
			_panOriginWorldPosition = default(Vector2);
			_focusPanDelta = default(Vector2);
		}
	}
}
