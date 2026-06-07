using Factory;
using Motorways.Audio;
using Motorways.Models;
using Motorways.UI;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Actions
{
	public class DragCreativeModeEditableObjectAction : MotorwaysPlayerAction
	{
		[Dependency]
		private CameraView _cameraView;

		[Dependency]
		private NotificationView _notificationView;

		[Dependency]
		private IScope _scope;

		[Dependency]
		private TilemapModel _tilemapModel;

		[Dependency]
		private IAudioSystem _audioSystem;

		private int _editedMotorwayId = -1;

		private bool _hasReplacedMothballEdit;

		private bool _didShowGrid;

		private Vector2Int _previousTilePosition;

		private DraftHouse _draftHouse;

		private DraftDestination _draftDestination;

		private EditMenuPanel _editMenuPanel;

		public override void Reset()
		{
			_editedMotorwayId = -1;
			_hasReplacedMothballEdit = false;
			_didShowGrid = false;
			_previousTilePosition = default(Vector2Int);
			_draftHouse = null;
			_draftDestination = null;
			_editMenuPanel = null;
			base.Reset();
		}

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			_didShowGrid = false;
			if (_inputState.TouchCount > 1)
			{
				OnActionCancel();
				return;
			}
			_editMenuPanel = _scope.Get<EditMenuPanel>();
			ICreativeModeEditableObject editableObject = _editMenuPanel.EditableObject;
			if (editableObject == null)
			{
				return;
			}
			_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.UpgradeDragged));
			_editMenuPanel.ShowHideEditMenu(show: false);
			if (editableObject is CreativeModeEditableHouse || editableObject is DraftHouse)
			{
				if (InputState.DeviceInputTypeRequiresFocus(_inputState.CurrentDeviceInputType))
				{
					ControllerDragHouseAction.CreateFromEditMenu(_owningGroup, _scope, timestamp);
				}
				else
				{
					DragHouseAction.CreateFromEditMenu(_owningGroup, _scope, timestamp);
				}
				OnActionComplete();
			}
			else if (editableObject is CreativeModeEditableDestination)
			{
				if ((editableObject as CreativeModeEditableDestination).IsDouble)
				{
					if (InputState.DeviceInputTypeRequiresFocus(_inputState.CurrentDeviceInputType))
					{
						ControllerDragDestinationAction.CreateDoubleFromEditMenu(_owningGroup, _scope, timestamp);
					}
					else
					{
						DragDestinationAction.CreateDoubleFromEditMenu(_owningGroup, _scope, timestamp);
					}
				}
				else if (InputState.DeviceInputTypeRequiresFocus(_inputState.CurrentDeviceInputType))
				{
					ControllerDragDestinationAction.CreateSingleFromEditMenu(_owningGroup, _scope, timestamp);
				}
				else
				{
					DragDestinationAction.CreateSingleFromEditMenu(_owningGroup, _scope, timestamp);
				}
				OnActionComplete();
			}
			else
			{
				if (!(editableObject is DraftDestination))
				{
					return;
				}
				if (!(editableObject as DraftDestination).IsDouble)
				{
					if (InputState.DeviceInputTypeRequiresFocus(_inputState.CurrentDeviceInputType))
					{
						ControllerDragDestinationAction.CreateSingleFromEditMenu(_owningGroup, _scope, timestamp);
					}
					else
					{
						DragDestinationAction.CreateSingleFromEditMenu(_owningGroup, _scope, timestamp);
					}
				}
				else if (InputState.DeviceInputTypeRequiresFocus(_inputState.CurrentDeviceInputType))
				{
					ControllerDragDestinationAction.CreateDoubleFromEditMenu(_owningGroup, _scope, timestamp);
				}
				else
				{
					DragDestinationAction.CreateDoubleFromEditMenu(_owningGroup, _scope, timestamp);
				}
				OnActionComplete();
			}
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			OnActionComplete();
		}

		public override void OnActionComplete()
		{
			if (!_cameraView.IsFocussedIn)
			{
				SetGridVisible(visible: false);
			}
			GameUIScreen gameUIScreen = base.Scope.Get<GameUIScreen>();
			if ((bool)_draftHouse)
			{
				gameUIScreen.OpenEditMenu(_draftHouse);
			}
			else if ((bool)_draftDestination)
			{
				gameUIScreen.OpenEditMenu(_draftDestination);
			}
			base.OnActionComplete();
		}

		public override void OnActionCancel()
		{
			base.OnActionCancel();
			ClearDraftClientEdits();
			SetGridVisible(visible: false);
		}

		private void SetGridVisible(bool visible)
		{
			if (visible)
			{
				_didShowGrid = true;
			}
			else if (!_didShowGrid)
			{
				return;
			}
			if (!_cameraView.IsFocussedIn)
			{
				_gameUI.SetWorldGridActive(visible);
				_tilemapView.viewMode = (visible ? TilemapView.ViewMode.Edit : TilemapView.ViewMode.Normal);
			}
		}

		public static DragCreativeModeEditableObjectAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			DragCreativeModeEditableObjectAction dragCreativeModeEditableObjectAction = scope.Get<DragCreativeModeEditableObjectAction>();
			dragCreativeModeEditableObjectAction.InitializeAction(owningGroup, timestamp);
			if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Mouse)
			{
				dragCreativeModeEditableObjectAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(19, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
				dragCreativeModeEditableObjectAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(20, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			}
			else if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Touch)
			{
				dragCreativeModeEditableObjectAction.RegisterObserveInputEvent(InputEventFilter.CreateTouchEventFilter(0, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
				dragCreativeModeEditableObjectAction.BlockNewTouchUpgradeActions();
			}
			dragCreativeModeEditableObjectAction.OnActionBegin(timestamp);
			return dragCreativeModeEditableObjectAction;
		}
	}
}
