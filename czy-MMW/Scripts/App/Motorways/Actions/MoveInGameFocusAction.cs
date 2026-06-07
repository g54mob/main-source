using System.Collections.Generic;
using Factory;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Actions
{
	public class MoveInGameFocusAction : MotorwaysPlayerAction
	{
		[Dependency]
		private PlayerActionController _playerActionController;

		[Dependency]
		private ActivePlayer _player;

		public new static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("MoveInGameFocusAction");

		protected Vector2 _touchStartingPosition;

		protected Vector2 _focusUIStartingPosition;

		protected Vector2 _focusMovementDelta;

		protected float _timeSpentAtMaxSpeed;

		[Dependency]
		protected MotorwaysInGameStateToggleController _controllerState;

		[Dependency]
		protected CameraView _cameraView;

		[Dependency]
		protected VisualConstantsData _visualConstants;

		public override bool IsInterruptible => true;

		protected override PlayerPositionSource _playerPositionSource => PlayerPositionSource.FocusPoint;

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			_timeSpentAtMaxSpeed = 0f;
			if (_controllerState.ControllerState != MotorwaysInGameStateToggleController.InGameControllerState.EditingTiles && (_controllerState.ControllerState != MotorwaysInGameStateToggleController.InGameControllerState.EditMenu || _inputState.CurrentDeviceInputType != DeviceInputType.Remote))
			{
				_gameUI.SetFocusPointActive(active: false);
				OnActionCancel();
				return;
			}
			_touchStartingPosition = GetPointerScreenPosition();
			_focusUIStartingPosition = _gameUI.FocusPointPosition;
			_focusMovementDelta = Vector2.zero;
			Log.Info("Starting MoveInGameFocusAction. Touch at {0}, UI at {1}", _touchStartingPosition, _focusUIStartingPosition);
			_gameUI.SetFocusPointActive(active: true);
		}

		public override void Tick(float frameTime)
		{
			base.Tick(frameTime);
			_focusMovementDelta = GetMoveFocusJoystickInputValue();
			if (_focusMovementDelta.sqrMagnitude < 0.001f)
			{
				OnActionComplete();
				return;
			}
			if (_focusMovementDelta.sqrMagnitude >= 1f)
			{
				_timeSpentAtMaxSpeed += frameTime;
			}
			Vector2 vector = new Vector2(Mathf.Abs(_focusMovementDelta.x), Mathf.Abs(_focusMovementDelta.y));
			float baseControllerSpeed = _visualConstants.BaseControllerSpeed;
			baseControllerSpeed *= _visualConstants.ControllerSpeedSensitivityOptions[_player.ControllerSensitivity];
			bool flag = false;
			foreach (PlayerActionGroup activeGroup in _playerActionController.ActiveGroups)
			{
				using IEnumerator<PlayerAction> enumerator2 = activeGroup.Actions.GetEnumerator();
				if (enumerator2.MoveNext() && enumerator2.Current is MotorwaysPlayerAction { PreventsCursorAcceleration: not false })
				{
					flag = true;
				}
			}
			if (!flag)
			{
				baseControllerSpeed *= _visualConstants.BaseControllerSpeedOverZoom.Evaluate(_cameraView.DesiredZoom) * _visualConstants.ControllerAccelerationCurve.Evaluate(_timeSpentAtMaxSpeed);
			}
			else
			{
				_timeSpentAtMaxSpeed = 0f;
				TileDirection closestDirection = TileUtilities.GetClosestDirection(_focusMovementDelta.normalized);
				float magnitude = _focusMovementDelta.magnitude;
				if (closestDirection != TileDirection.None)
				{
					_focusMovementDelta = TileUtilities.GetVectorForDirection(closestDirection) * magnitude;
				}
			}
			Vector2 focusMovementDelta = _focusMovementDelta * vector * (baseControllerSpeed * _tilemapView.ScreenDistanceBetweenTiles) * frameTime;
			_focusMovementDelta = focusMovementDelta;
			if (_focusMovementDelta != Vector2.zero)
			{
				_gameUI.SetFocusPointPosition(_gameUI.FocusPointPosition + _focusMovementDelta);
			}
		}

		public override void OnActionCancel()
		{
			_gameUI.SetFocusPointActive(active: false);
			base.OnActionCancel();
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			base.ObserveInput(timestamp, inputEvent, overUI);
			if (inputEvent.ButtonState == InputEventButtonState.Axis && inputEvent is AxisInputEvent && Mathf.Approximately(GetMoveFocusJoystickInputValue().sqrMagnitude, 0f))
			{
				OnActionComplete();
			}
		}

		public override void Reset()
		{
			base.Reset();
			_touchStartingPosition = default(Vector2);
			_focusUIStartingPosition = default(Vector2);
			_focusMovementDelta = default(Vector2);
			_timeSpentAtMaxSpeed = 0f;
		}

		public static MoveInGameFocusAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			Log.Info("Creating MoveInGameFocus action!");
			MoveInGameFocusAction moveInGameFocusAction = scope.Get<MoveInGameFocusAction>();
			moveInGameFocusAction.InitializeAction(owningGroup, timestamp);
			moveInGameFocusAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(owningGroup.InstigatingInputEvent.Source, 0, InputEventButtonState.Axis), ObserverGreediness.BlocksNewActions);
			moveInGameFocusAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(owningGroup.InstigatingInputEvent.Source, 1, InputEventButtonState.Axis), ObserverGreediness.BlocksNewActions);
			moveInGameFocusAction.OnActionBegin(timestamp);
			return moveInGameFocusAction;
		}
	}
}
