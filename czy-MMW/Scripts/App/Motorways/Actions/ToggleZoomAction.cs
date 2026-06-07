using Factory;
using Motorways.Audio;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Actions
{
	public class ToggleZoomAction : MotorwaysPlayerAction
	{
		[Dependency]
		private IAudioSystem _audioSystem;

		[Dependency]
		private CameraView _cameraView;

		[Dependency]
		private VisualConstantsData _visualConstants;

		private bool _hasDirection;

		private bool _zoomIn;

		private PlayerPositionSource _source;

		protected override PlayerPositionSource _playerPositionSource => _source;

		private bool PointerPositionWithinWindow(Vector2 pointerPosition)
		{
			return _cameraView.GameCamera.UICamera.pixelRect.Contains(pointerPosition);
		}

		public override void OnActionBegin(float timestamp)
		{
			Vector2 pointerScreenPosition = GetPointerScreenPosition();
			SetColourWidgetRadialVisible(visible: false);
			if (_cameraView.HasControlOverriden || !_cameraView.CanChangeFocus || !PointerPositionWithinWindow(pointerScreenPosition))
			{
				OnActionComplete();
			}
			else if ((!_cameraView.IsFocussedIn && !_hasDirection) || (!_cameraView.IsFocussedIn && _hasDirection && _zoomIn))
			{
				SetWorldGridVisible(_visualConstants.ShowGridOnZoom);
				_cameraView.FocusOnWorldPosition(_tilemapView.GetWorldPositionFromScreenPosition(pointerScreenPosition), CameraView.CameraFocusOffsetType.MaintainScreenPosition);
				_tilemapView.viewMode = TilemapView.ViewMode.Edit;
				_audioSystem.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.FocusZoomIn, UIAudioProfile.None, _cameraView.GetInterpolationSpeed()));
			}
			else if ((_cameraView.IsFocussedIn && !_hasDirection) || (_cameraView.IsFocussedIn && _hasDirection && !_zoomIn))
			{
				SetWorldGridVisible(visible: false);
				SetMotorwayGridVisible(visible: false);
				_tilemapView.viewMode = TilemapView.ViewMode.Normal;
				_cameraView.ResetPlayerViewport();
				if (_gameUI.CurrentRoadDrawMode == RoadDrawMode.Remove)
				{
					_gameUI.ToggleDrawMode();
				}
				_audioSystem.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.FocusZoomOut, UIAudioProfile.None, _cameraView.GetInterpolationSpeed()));
			}
		}

		public override void Tick(float frameTime)
		{
			OnActionComplete();
		}

		public static ToggleZoomAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ToggleZoomAction toggleZoomAction = scope.Get<ToggleZoomAction>();
			toggleZoomAction.InitializeAction(owningGroup, timestamp);
			toggleZoomAction._source = ((owningGroup.InstigatingInputEvent.Source == InputEventSource.Any) ? PlayerPositionSource.FocusPoint : PlayerPositionSource.InputEvent);
			toggleZoomAction.OnActionBegin(timestamp);
			return toggleZoomAction;
		}

		public static ToggleZoomAction CreateZoomIn(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ToggleZoomAction toggleZoomAction = scope.Get<ToggleZoomAction>();
			toggleZoomAction._hasDirection = true;
			toggleZoomAction._zoomIn = true;
			toggleZoomAction.InitializeAction(owningGroup, timestamp);
			toggleZoomAction._source = ((owningGroup.InstigatingInputEvent.Source == InputEventSource.Any) ? PlayerPositionSource.FocusPoint : PlayerPositionSource.InputEvent);
			toggleZoomAction.OnActionBegin(timestamp);
			return toggleZoomAction;
		}

		public static ToggleZoomAction CreateZoomOut(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ToggleZoomAction toggleZoomAction = scope.Get<ToggleZoomAction>();
			toggleZoomAction._hasDirection = true;
			toggleZoomAction._zoomIn = false;
			toggleZoomAction.InitializeAction(owningGroup, timestamp);
			toggleZoomAction._source = ((owningGroup.InstigatingInputEvent.Source == InputEventSource.Any) ? PlayerPositionSource.FocusPoint : PlayerPositionSource.InputEvent);
			toggleZoomAction.OnActionBegin(timestamp);
			return toggleZoomAction;
		}

		public override void OnActionCancel()
		{
			_hasDirection = false;
			_zoomIn = false;
			_source = PlayerPositionSource.InputEvent;
		}

		public override void OnActionComplete()
		{
			_hasDirection = false;
			_zoomIn = false;
			_source = PlayerPositionSource.InputEvent;
			base.OnActionComplete();
		}
	}
}
