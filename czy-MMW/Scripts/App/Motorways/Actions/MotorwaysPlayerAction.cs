using System.Collections.Generic;
using Factory;
using Motorways.Commands;
using Motorways.Models;
using Motorways.Views;
using Server;
using UnityEngine;

namespace Motorways.Actions
{
	public abstract class MotorwaysPlayerAction : PlayerAction
	{
		public enum PlayerPositionSource
		{
			InputEvent = 0,
			FocusPoint = 1
		}

		protected enum EditExecuteTiming
		{
			Immediate = 0,
			OnComplete = 1,
			Draft = 2,
			Manual = 3
		}

		[Dependency]
		protected TileEditor _tileEditor;

		[Dependency]
		protected TilemapView _tilemapView;

		[Dependency]
		protected ClientUpgradeDatabase _upgradeDatabase;

		[Dependency]
		protected GameUIScreen _gameUI;

		[Dependency]
		protected ISimulation _simulation;

		[Dependency]
		protected City _city;

		[Dependency]
		protected ClockModel _clockModel;

		[Dependency]
		protected HapticFeedbackGenerator _feedbackGenerator;

		protected List<ClientTileEdit> _unscheduledClientTileEdits = new List<ClientTileEdit>();

		protected List<ClientTileEdit> _draftClientTileEdits = new List<ClientTileEdit>();

		protected HashSet<Vector2Int> _reservedTiles = new HashSet<Vector2Int>();

		protected IPointerState _inputPointer;

		protected ButtonState _inputButton;

		protected virtual bool ManuallyHandlesReservations => false;

		public virtual bool PreventsCursorAcceleration => false;

		protected virtual PlayerPositionSource _playerPositionSource { get; set; }

		protected bool HasSchedulableClientEdits
		{
			get
			{
				if (_unscheduledClientTileEdits.Count > 0)
				{
					return true;
				}
				foreach (ClientTileEdit draftClientTileEdit in _draftClientTileEdits)
				{
					if (draftClientTileEdit.edit.CanApplyToSimulation)
					{
						return true;
					}
				}
				return false;
			}
		}

		public override void InitializeAction(PlayerActionGroup owningGroup, float timestamp)
		{
			base.InitializeAction(owningGroup, timestamp);
			_inputPointer = _inputState.GetPointerFromInputEvent(owningGroup.InstigatingInputEvent);
			_inputButton = _inputState.GetButtonFromInputEvent(owningGroup.InstigatingInputEvent);
		}

		public override void OnActionBegin(float timestamp)
		{
			_gameUI.SetFocusPointActive(DoesInputTypeUseFocusPoint(_owningGroup.InstigatingInputEvent.Source));
			base.OnActionBegin(timestamp);
		}

		public static bool DoesInputTypeUseFocusPoint(InputEventSource source)
		{
			if (source != InputEventSource.Generic)
			{
				return source == InputEventSource.Remote;
			}
			return true;
		}

		public override void OnActionCancel()
		{
			base.OnActionCancel();
			foreach (ClientTileEdit unscheduledClientTileEdit in _unscheduledClientTileEdits)
			{
				ReleaseClientTileEdit(unscheduledClientTileEdit);
			}
			_unscheduledClientTileEdits.Clear();
			ClearDraftClientEdits();
			_upgradeDatabase.OnDraftEditsScheduled();
			ClearTileReservations();
		}

		public override void OnActionComplete()
		{
			base.OnActionComplete();
			ApplyDraftClientEdits();
			foreach (ClientTileEdit unscheduledClientTileEdit in _unscheduledClientTileEdits)
			{
				ScheduleClientTileEdit(unscheduledClientTileEdit);
			}
			_unscheduledClientTileEdits.Clear();
			ClearTileReservations();
		}

		protected virtual void SetCursorVisible(bool visible)
		{
			_gameUI.SetRoadCursorActive(visible);
		}

		protected virtual void SetWorldGridVisible(bool visible)
		{
			_gameUI.SetWorldGridActive(visible);
		}

		protected virtual void SetMotorwayGridVisible(bool visible)
		{
			_gameUI.SetMotorwayGridActive(visible);
		}

		protected virtual void UpdateCursorPosition()
		{
			_gameUI.SetRoadCursorPosition(GetPointerScreenPosition());
		}

		protected virtual void SetColourWidgetRadialVisible(bool visible)
		{
			if (_city.Rules.ShowColourWidget)
			{
				_gameUI.ColourWidget.SetRadialColourWidgetVisible(visible);
			}
		}

		protected ClientTileEdit AddTileEdit(TileEdit edit, EditExecuteTiming executeTiming)
		{
			if (edit == null)
			{
				return null;
			}
			ClientTileEdit clientTileEdit = _tilemapView.GenerateClientTileEditAndAddEditToViews(edit, executeTiming == EditExecuteTiming.Draft);
			clientTileEdit.action = this;
			switch (executeTiming)
			{
			case EditExecuteTiming.Immediate:
				ScheduleClientTileEdit(clientTileEdit);
				break;
			case EditExecuteTiming.OnComplete:
				ReserveTiles(clientTileEdit.edit.GetAffectedTiles(_tilemapView));
				_unscheduledClientTileEdits.Add(clientTileEdit);
				break;
			case EditExecuteTiming.Draft:
				ReserveTiles(clientTileEdit.edit.GetAffectedTiles(_tilemapView));
				_draftClientTileEdits.Add(clientTileEdit);
				break;
			default:
				_ = 3;
				break;
			}
			_upgradeDatabase.AddTileEdit(clientTileEdit);
			return clientTileEdit;
		}

		protected void ClearDraftClientEdits()
		{
			if (_draftClientTileEdits.Count == 0)
			{
				return;
			}
			foreach (ClientTileEdit draftClientTileEdit in _draftClientTileEdits)
			{
				ReleaseClientTileEdit(draftClientTileEdit);
			}
			_draftClientTileEdits.Clear();
			ClearTileReservations();
			foreach (ClientTileEdit unscheduledClientTileEdit in _unscheduledClientTileEdits)
			{
				ReserveTiles(unscheduledClientTileEdit.edit.GetAffectedTiles(_tilemapView));
			}
		}

		protected void ApplyDraftClientEdits()
		{
			foreach (ClientTileEdit draftClientTileEdit in _draftClientTileEdits)
			{
				if (draftClientTileEdit.edit.CanApplyToSimulation)
				{
					draftClientTileEdit.isDraft = false;
					_unscheduledClientTileEdits.Add(draftClientTileEdit);
				}
				else
				{
					base.Scope.Release(draftClientTileEdit.edit);
				}
			}
			_draftClientTileEdits.Clear();
			_upgradeDatabase.OnDraftEditsScheduled();
		}

		private void ReserveTile(Tile tile)
		{
			Vector2Int coordinates = tile.Coordinates;
			if (!_reservedTiles.Contains(coordinates))
			{
				_reservedTiles.Add(coordinates);
				_simulation.ScheduleCommand(ReserveTileCommand.Create(base.Scope, coordinates));
			}
		}

		private void ReserveTiles(IEnumerable<Tile> tiles)
		{
			foreach (Tile tile in tiles)
			{
				ReserveTile(tile);
			}
		}

		private void ClearTileReservations()
		{
			if (_reservedTiles.Count > 0 && !ManuallyHandlesReservations)
			{
				_simulation.ScheduleCommand(ClearTileReservationsCommand.Create(base.Scope));
				_reservedTiles.Clear();
			}
		}

		private void ScheduleClientTileEdit(ClientTileEdit clientTileEdit)
		{
			EditTileCommand command = EditTileCommand.Create(base.Scope, clientTileEdit.edit);
			_simulation.ScheduleCommand(command);
			clientTileEdit.isScheduledOnSimulation = true;
		}

		private void ReleaseClientTileEdit(ClientTileEdit clientEdit)
		{
			if (!Diagnostics.Verify(clientEdit != null))
			{
				return;
			}
			TileEdit edit = clientEdit.edit;
			if (!Diagnostics.Verify(edit != null))
			{
				return;
			}
			foreach (Motorway affectedMotorway in edit.GetAffectedMotorways(_tilemapView))
			{
				if (Diagnostics.Verify(affectedMotorway != null))
				{
					MotorwayView motorwayView = _tilemapView.GetMotorwayView(affectedMotorway.Id);
					if (Diagnostics.Verify(motorwayView != null))
					{
						motorwayView.RemoveEdit(clientEdit);
					}
				}
			}
			foreach (Tile affectedTile in edit.GetAffectedTiles(_tilemapView))
			{
				if (Diagnostics.Verify(affectedTile != null))
				{
					TileView tileView = _tilemapView.GetTileView(affectedTile.Coordinates);
					if (Diagnostics.Verify(tileView != null))
					{
						tileView.RemoveEdit(clientEdit);
					}
				}
			}
			_upgradeDatabase.RemoveTileEdit(clientEdit);
			base.Scope.Release(edit);
		}

		public Vector2Int GetPointerTilePosition()
		{
			return _tilemapView.GetTileCoordinatesFromScreenPosition(GetPointerScreenPosition());
		}

		protected Vector2 GetPointerWorldPosition()
		{
			return _tilemapView.GetWorldPositionFromScreenPosition(GetPointerScreenPosition());
		}

		protected Vector2 GetPointerScreenPosition()
		{
			if (_playerPositionSource == PlayerPositionSource.InputEvent && _inputPointer != null)
			{
				return _inputPointer.Position;
			}
			return _gameUI.FocusPointPosition;
		}

		protected Vector2 GetPan()
		{
			Vector2 screenPositionFromTileCoordinates = _tilemapView.GetScreenPositionFromTileCoordinates(GetPointerTilePosition());
			return new Vector2(Mathf.Clamp01(screenPositionFromTileCoordinates.x / (float)Screen.width), Mathf.Clamp01(screenPositionFromTileCoordinates.y / (float)Screen.height));
		}

		protected virtual Vector2 GetMoveFocusJoystickInputValue()
		{
			return new Vector2(_inputState.GetAxis(0), _inputState.GetAxis(1));
		}

		protected virtual Vector2 GetPanFocusJoystickInputValue()
		{
			return new Vector2(_inputState.GetAxis(34), _inputState.GetAxis(33));
		}

		protected void BlockNewTouchUpgradeActions()
		{
			RegisterObserveInputEvent(MotorwaysUIInputEventFilter.CreateTouchUIEventFilter(InputEventFilter.AnySourceIndex, GameUIButtonType.Motorway, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			RegisterObserveInputEvent(MotorwaysUIInputEventFilter.CreateTouchUIEventFilter(InputEventFilter.AnySourceIndex, GameUIButtonType.TrafficLight, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			RegisterObserveInputEvent(MotorwaysUIInputEventFilter.CreateTouchUIEventFilter(InputEventFilter.AnySourceIndex, GameUIButtonType.Roundabout, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			RegisterObserveInputEvent(MotorwaysUIInputEventFilter.CreateTouchUIEventFilter(InputEventFilter.AnySourceIndex, GameUIButtonType.MotorwayHandle, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			RegisterObserveInputEvent(MotorwaysUIInputEventFilter.CreateTouchUIEventFilter(InputEventFilter.AnySourceIndex, GameUIButtonType.House, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			RegisterObserveInputEvent(MotorwaysUIInputEventFilter.CreateTouchUIEventFilter(InputEventFilter.AnySourceIndex, GameUIButtonType.Destination, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			RegisterObserveInputEvent(MotorwaysUIInputEventFilter.CreateTouchUIEventFilter(InputEventFilter.AnySourceIndex, GameUIButtonType.DoubleDestination, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
		}
	}
}
