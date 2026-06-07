using Client;
using Factory;
using FixMath;
using Motorways.Models;
using Motorways.UI;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Actions
{
	public class ToggleCreativeModeEditMenuAction : MotorwaysPlayerAction
	{
		[Dependency]
		private IAudioSystem _audioSystem;

		[Dependency]
		private CameraView _cameraView;

		[Dependency]
		private ViewClient _viewClient;

		[Dependency]
		private IScope _scope;

		private PlayerPositionSource _source;

		private ICreativeModeEditableObject _currentlyEditingCreativeModeObject;

		private ICreativeModeEditableObject _inputDownOverCreativeModeObject;

		protected override PlayerPositionSource _playerPositionSource => _source;

		private bool PointerPositionWithinWindow(Vector2 pointerPosition)
		{
			return _cameraView.GameCamera.UICamera.pixelRect.Contains(pointerPosition);
		}

		public override void OnActionBegin(float timestamp)
		{
			if (_city.GameMode != GameMode.Creative)
			{
				OnActionCancel();
				return;
			}
			EditMenuPanel editMenuPanel = _scope.Get<EditMenuPanel>();
			if (editMenuPanel.isActiveAndEnabled && (editMenuPanel.IsPlayingCloseEditMenuSequence || editMenuPanel.IsPlayingOpenEditMenuSequence))
			{
				OnActionCancel();
				return;
			}
			CarparkView carparkWithEmptySpace = _viewClient.GetCarparkWithEmptySpace(GetPointerWorldPosition());
			if (carparkWithEmptySpace != null)
			{
				MakeExclusive();
				SpawnSecondDestination(carparkWithEmptySpace.Model);
				_gameUI.ConfirmEditMenuEdit();
				OnActionCancel();
				return;
			}
			_inputDownOverCreativeModeObject = null;
			DestinationView destinationView = GetDestinationView();
			HouseView houseView = GetHouseView();
			if (destinationView != null)
			{
				_inputDownOverCreativeModeObject = destinationView.GetComponent<ICreativeModeEditableObject>();
			}
			else if (houseView != null)
			{
				_inputDownOverCreativeModeObject = houseView.GetComponent<ICreativeModeEditableObject>();
			}
			if (_inputDownOverCreativeModeObject == null)
			{
				OnActionCancel();
			}
			if (!editMenuPanel.isActiveAndEnabled)
			{
				return;
			}
			if (editMenuPanel.IsPlayingOpenEditMenuSequence)
			{
				MakeExclusive();
				OnActionCancel();
				return;
			}
			ICreativeModeEditableObject editableObject = editMenuPanel.EditableObject;
			if (!editableObject.GetEditOptions().HasFlag(EditMenuButtonType.Move))
			{
				OnActionCancel();
			}
			else if (editableObject == _inputDownOverCreativeModeObject)
			{
				DragCreativeModeEditableObjectAction.Create(_owningGroup, _scope, Time.time);
				OnActionCancel();
			}
			else if (editableObject is DraftDestination || editableObject is DraftHouse)
			{
				Vector2 pointerWorldPosition = GetPointerWorldPosition();
				if (editableObject.GetBounds().Contains(new Vector3(pointerWorldPosition.x, pointerWorldPosition.y, 0f)))
				{
					DragCreativeModeEditableObjectAction.Create(_owningGroup, _scope, Time.time);
					OnActionCancel();
				}
			}
		}

		public override void Tick(float frameTime)
		{
			base.Tick(frameTime);
			Vector2 pointerWorldPosition = GetPointerWorldPosition();
			if (!_inputDownOverCreativeModeObject.GetBounds().Contains(new Vector3(pointerWorldPosition.x, pointerWorldPosition.y, 0f)))
			{
				OnActionCancel();
			}
		}

		private void ShowEditMenu()
		{
			_gameUI.OpenEditMenu(_currentlyEditingCreativeModeObject);
		}

		private void ConfirmEditMenuEdit()
		{
			ICreativeModeEditableObject editableObject = _scope.Get<EditMenuPanel>().EditableObject;
			if (editableObject is CreativeModeEditableDestination || editableObject is CreativeModeEditableHouse)
			{
				_gameUI.ConfirmEditMenuEdit();
			}
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			base.ObserveInput(timestamp, inputEvent, overUI);
			Vector2 pointerScreenPosition = GetPointerScreenPosition();
			if (_cameraView.HasControlOverriden || !_cameraView.CanChangeFocus || !PointerPositionWithinWindow(pointerScreenPosition))
			{
				OnActionComplete();
				return;
			}
			_currentlyEditingCreativeModeObject = null;
			Vector2 pointerWorldPosition = GetPointerWorldPosition();
			if (_inputDownOverCreativeModeObject.GetBounds().Contains(new Vector3(pointerWorldPosition.x, pointerWorldPosition.y, 0f)))
			{
				MakeExclusive();
				_currentlyEditingCreativeModeObject = _inputDownOverCreativeModeObject;
				if (_gameUI.editMenuPanel.gameObject.activeInHierarchy)
				{
					if (_gameUI.editMenuPanel.EditableObject != _currentlyEditingCreativeModeObject)
					{
						ConfirmEditMenuEdit();
						ShowEditMenu();
					}
				}
				else
				{
					ShowEditMenu();
				}
			}
			else
			{
				ConfirmEditMenuEdit();
			}
			OnActionComplete();
		}

		private DestinationView GetDestinationView()
		{
			Vector2 pointerWorldPosition = GetPointerWorldPosition();
			foreach (DestinationView view in _viewClient.GetViews<DestinationView>())
			{
				if (view.Model != null && view.GetBounds().Contains(new Vector3(pointerWorldPosition.x, pointerWorldPosition.y, view.transform.position.z)))
				{
					return view;
				}
			}
			return null;
		}

		private HouseView GetHouseView()
		{
			Vector2 pointerWorldPosition = GetPointerWorldPosition();
			foreach (HouseView view in _viewClient.GetViews<HouseView>())
			{
				if (view.Model != null && view.GetBounds().Contains(new Vector3(pointerWorldPosition.x, pointerWorldPosition.y, view.transform.position.z)))
				{
					return view;
				}
			}
			return null;
		}

		private void SpawnSecondDestination(CarparkModel carparkModel)
		{
			CityPlanModel cityPlanModel = _scope.Get<CityPlanModel>();
			CityPlanModel.ScheduledBuilding scheduledBuilding = _scope.Get<CityPlanModel.ScheduledBuilding>();
			bool flag = carparkModel.ActiveDestinationCount > 0 && carparkModel.destinations[0].IsTrainStation;
			bool flag2 = carparkModel.ActiveDestinationCount > 0 && carparkModel.destinations[0].IsBoatTerminal;
			scheduledBuilding.type = CityTileType.Demand;
			scheduledBuilding.carparkPreference = (flag2 ? CarparkPreference.JoinBoatTerminal : (flag ? CarparkPreference.Station : CarparkPreference.Double));
			scheduledBuilding.useFixedParameters = true;
			scheduledBuilding.positionOverride = carparkModel.TopLeftWorldCoordinate;
			scheduledBuilding.time = Fix64.Zero;
			scheduledBuilding.demandMultiplier = Fix64.One;
			scheduledBuilding.groupIndex = _scope.Get<ColourWidget>().CurrentColour;
			scheduledBuilding.initialUpgradeLevel = 0;
			cityPlanModel.ScheduleBuilding(scheduledBuilding);
		}

		public static ToggleCreativeModeEditMenuAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ToggleCreativeModeEditMenuAction toggleCreativeModeEditMenuAction = scope.Get<ToggleCreativeModeEditMenuAction>();
			toggleCreativeModeEditMenuAction.InitializeAction(owningGroup, timestamp);
			toggleCreativeModeEditMenuAction._source = ((owningGroup.InstigatingInputEvent.Source == InputEventSource.Any) ? PlayerPositionSource.FocusPoint : PlayerPositionSource.InputEvent);
			toggleCreativeModeEditMenuAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(owningGroup.InstigatingInputEvent.Source, owningGroup.InstigatingInputEvent.InputAction, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
			toggleCreativeModeEditMenuAction.OnActionBegin(timestamp);
			return toggleCreativeModeEditMenuAction;
		}

		public override void OnActionCancel()
		{
			_source = PlayerPositionSource.InputEvent;
			_currentlyEditingCreativeModeObject = null;
			base.OnActionCancel();
		}

		public override void OnActionComplete()
		{
			_source = PlayerPositionSource.InputEvent;
			SetColourWidgetRadialVisible(visible: false);
			base.OnActionComplete();
		}

		public override void Reset()
		{
			base.Reset();
			_currentlyEditingCreativeModeObject = null;
		}
	}
}
