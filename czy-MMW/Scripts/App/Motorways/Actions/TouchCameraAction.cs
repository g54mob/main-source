using Factory;
using Motorways.Audio;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Actions
{
	public class TouchCameraAction : MotorwaysPlayerAction
	{
		[Dependency]
		private CameraView _cameraView;

		[Dependency]
		protected IAudioSystem _audioSystem;

		[Dependency]
		protected ActivePlayer _player;

		private Vector2 _initialScreenPosition;

		private Vector2 _currentScreenPosition;

		private Vector2 _panOriginCameraPosition;

		private Vector2 _panOriginWorldPosition;

		private bool _isPanning;

		private float _tapTimeThreshold = 1f;

		private float _tapDistanceCoefficient = 0.5f;

		[Dependency]
		private PlayerActionController _playerActionController;

		public override void OnActionBegin(float timestamp)
		{
			_playerActionController.CancelAllActions();
			base.OnActionBegin(timestamp);
			_initialScreenPosition = GetPointerScreenPosition();
			_currentScreenPosition = _initialScreenPosition;
			_isPanning = false;
			PlayerAction.Log.Info("Beginning TouchCameraAction from {0}.", _initialScreenPosition);
		}

		public override void Tick(float frameTime)
		{
			base.Tick(frameTime);
			Vector2 pointerScreenPosition = GetPointerScreenPosition();
			if (_inputState.TouchCount == 2)
			{
				if (!_isPanning)
				{
					_panOriginCameraPosition = _cameraView.DesiredPosition;
					_panOriginWorldPosition = _tilemapView.GetWorldPositionFromScreenPosition(pointerScreenPosition);
					_isPanning = true;
					PlayerAction.Log.Info("Beginning pan from a screen position of {0} touching a world position of {1}.", _initialScreenPosition, _panOriginWorldPosition);
					if (!base.IsExclusive)
					{
						MakeExclusive();
					}
				}
				else
				{
					_cameraView.ApplyPlayerPanPosition(_panOriginWorldPosition, pointerScreenPosition);
				}
			}
			_currentScreenPosition = pointerScreenPosition;
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			if (inputEvent.ButtonState != InputEventButtonState.JustUp)
			{
				return;
			}
			Vector2 pointerPosition = inputEvent.PointerPosition;
			if (!_isPanning && Vector2.Distance(pointerPosition, _initialScreenPosition) < _tilemapView.ScreenDistanceBetweenTiles * _tapDistanceCoefficient && timestamp - timeCreated <= _tapTimeThreshold)
			{
				if (_inputState.TouchCount == 1 && _cameraView.CanChangeFocus)
				{
					if (!_cameraView.IsFocussedIn)
					{
						SetWorldGridVisible(visible: true);
						if (_player.IsZoomEnabled)
						{
							_cameraView.FocusOnWorldPosition(_tilemapView.GetWorldPositionFromScreenPosition(pointerPosition), CameraView.CameraFocusOffsetType.MaintainScreenPosition);
						}
						else
						{
							_cameraView.FocusOnWorldPositionWithoutZoom(_tilemapView.GetWorldPositionFromScreenPosition(pointerPosition), CameraView.CameraFocusOffsetType.MaintainScreenPosition);
						}
						_gameUI.SetDrawButtonsVisible(visible: true);
						_tilemapView.viewMode = TilemapView.ViewMode.Edit;
						_audioSystem.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.FocusZoomIn, UIAudioProfile.None, _cameraView.GetInterpolationSpeed()));
					}
					else
					{
						SetWorldGridVisible(visible: false);
						SetMotorwayGridVisible(visible: false);
						_tilemapView.viewMode = TilemapView.ViewMode.Normal;
						_cameraView.ResetPlayerViewport();
						_gameUI.SetDrawButtonsVisible(visible: false);
						if (_gameUI.CurrentRoadDrawMode == RoadDrawMode.Remove)
						{
							_gameUI.ToggleDrawMode();
						}
						_audioSystem.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.FocusZoomOut, UIAudioProfile.None, _cameraView.GetInterpolationSpeed()));
					}
				}
				OnActionComplete();
			}
			else
			{
				_cameraView.ReleasePlayerPan();
				OnActionComplete();
			}
		}

		public static TouchCameraAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			TouchCameraAction touchCameraAction = scope.Get<TouchCameraAction>();
			touchCameraAction.InitializeAction(owningGroup, timestamp);
			PlayerAction.Log.Info("[TouchCameraAction] Creating new instance of action: {0}", timestamp);
			if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Touch)
			{
				touchCameraAction.RegisterObserveInputEvent(InputEventFilter.CreateTouchEventFilter(0, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
				touchCameraAction.RegisterObserveInputEvent(InputEventFilter.CreateTouchEventFilter(1, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
			}
			touchCameraAction.OnActionBegin(timestamp);
			return touchCameraAction;
		}

		public override void Reset()
		{
			base.Reset();
			_isPanning = false;
			_initialScreenPosition = default(Vector2);
			_currentScreenPosition = default(Vector2);
			_panOriginCameraPosition = default(Vector2);
			_panOriginWorldPosition = default(Vector2);
		}
	}
}
