using Factory;
using Motorways.Audio;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Actions
{
	public class MouseCameraAction : MotorwaysPlayerAction
	{
		[Dependency]
		private CameraView _cameraView;

		[Dependency]
		protected IAudioSystem _audioSystem;

		[Dependency]
		protected ActivePlayer _player;

		private Vector2 _initialScreenPosition;

		private Vector2 _panOriginWorldPosition;

		private bool _isPanning;

		private const float _tapTimeThreshold = 1f;

		private const float _tapDistanceCoefficient = 0.5f;

		public override void OnActionBegin(float timestamp)
		{
			if (!_cameraView.IsFocussedIn)
			{
				OnActionCancel();
				return;
			}
			base.OnActionBegin(timestamp);
			_initialScreenPosition = GetPointerScreenPosition();
			_isPanning = false;
			PlayerAction.Log.Info("Beginning MouseCameraAction from {0}.", _initialScreenPosition);
		}

		public override void Tick(float frameTime)
		{
			base.Tick(frameTime);
			Vector2 pointerScreenPosition = GetPointerScreenPosition();
			if (!_inputState.Mouse.GetButtonState(3).IsUp)
			{
				return;
			}
			if (!_isPanning)
			{
				_panOriginWorldPosition = _tilemapView.GetWorldPositionFromScreenPosition(pointerScreenPosition);
				_isPanning = true;
				PlayerAction.Log.Info("Beginning pan from a screen position of {0} holding a world position of {1}.", _initialScreenPosition, _panOriginWorldPosition);
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

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			if (inputEvent.ButtonState != InputEventButtonState.JustUp)
			{
				return;
			}
			Vector2 pointerPosition = inputEvent.PointerPosition;
			if (!_isPanning && Vector2.Distance(pointerPosition, _initialScreenPosition) < _tilemapView.ScreenDistanceBetweenTiles * 0.5f && timestamp - timeCreated <= 1f)
			{
				if (_inputState.Mouse.GetButtonState(3).IsUp && _cameraView.CanChangeFocus)
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

		public static MouseCameraAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			MouseCameraAction mouseCameraAction = scope.Get<MouseCameraAction>();
			mouseCameraAction.InitializeAction(owningGroup, timestamp);
			PlayerAction.Log.Info("[MouseCameraAction] Creating new instance of action: {0}", timestamp);
			if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Mouse)
			{
				mouseCameraAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(30, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
			}
			mouseCameraAction.OnActionBegin(timestamp);
			return mouseCameraAction;
		}

		public override void Reset()
		{
			base.Reset();
			_isPanning = false;
			_initialScreenPosition = default(Vector2);
			_panOriginWorldPosition = default(Vector2);
		}
	}
}
