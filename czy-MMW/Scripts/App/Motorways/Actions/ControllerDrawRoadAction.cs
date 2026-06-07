using System.Collections.Generic;
using Factory;
using FixMath;
using Motorways.Audio;
using Motorways.Models;
using Motorways.Processes;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Actions
{
	public class ControllerDrawRoadAction : MotorwaysPlayerAction
	{
		public enum TapDrawState
		{
			Initializing = 0,
			Ready = 1,
			DraftingRoad = 2,
			AddingRoad = 3,
			Realigning = 4,
			Completing = 5,
			Cancelling = 6
		}

		public new static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("ControllerDrawRoadAction");

		[Dependency]
		private IAudioSystem _audioSystem;

		private TapDrawState _tapState;

		private Vector2Int _roadStartTileCoordinates;

		private Vector2Int _roadEndTileCoordinates;

		private Vector2Int _latestValidRoadEndTileCoordinates;

		private Vector2Int _cursorTileCoordinates;

		private readonly List<Vector2Int> _path = new List<Vector2Int>();

		private bool _completeOnTraversalEnd;

		private int _editCount;

		[Dependency]
		protected MotorwaysInGameStateToggleController _controllerState;

		[Dependency]
		private NotificationView _notificationView;

		[Dependency]
		private TilePathfinder _pathfinder;

		protected override PlayerPositionSource _playerPositionSource => PlayerPositionSource.FocusPoint;

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			if (_controllerState.ControllerState != MotorwaysInGameStateToggleController.InGameControllerState.EditingTiles)
			{
				Log.Info("Not in the correct control state: (wanted {0}, currently {1})", MotorwaysInGameStateToggleController.InGameControllerState.EditingTiles, _controllerState.ControllerState);
				OnActionCancel();
				return;
			}
			if (_gameUI.CurrentRoadDrawMode != RoadDrawMode.Add)
			{
				SetState(TapDrawState.Cancelling);
				return;
			}
			if (!_city.IsTileInPlayableArea(GetPointerTilePosition(), _clockModel.ExpansionTime))
			{
				SetState(TapDrawState.Cancelling);
				return;
			}
			_cursorTileCoordinates = GetPointerTilePosition();
			if (base.Scope.Get<City>().Rules is TutorialGameRules)
			{
				TutorialProgressionProcess tutorialProgressionProcess = base.Scope.Get<TutorialProgressionProcess>();
				tutorialProgressionProcess.SetControllerIsDrawingRoads(isDrawingRoad: true);
				tutorialProgressionProcess.SetCurrentControllerCursor(_cursorTileCoordinates);
			}
			_roadStartTileCoordinates = _cursorTileCoordinates;
			_latestValidRoadEndTileCoordinates = _cursorTileCoordinates;
			_roadEndTileCoordinates = _cursorTileCoordinates;
			_editCount = 0;
			UpdateCursorPosition();
			SetCursorVisible(visible: true);
			SetState(TapDrawState.Initializing);
			Log.Info("Beginning TapDrawRoadAction from tile coordinates {0}.", _roadStartTileCoordinates);
		}

		public override void Tick(float frameTime)
		{
			base.Tick(frameTime);
			UpdateCursorPosition();
			Vector2Int pointerTilePosition = GetPointerTilePosition();
			if (!(_roadEndTileCoordinates != pointerTilePosition))
			{
				return;
			}
			_roadEndTileCoordinates = pointerTilePosition;
			Tile tile = _tilemapView.GetTile(_roadEndTileCoordinates);
			if (tile != null)
			{
				RoadTileSignature roadTileSignature = tile.CreateSignature(RoadState.VisiblyActive | RoadState.Mothballed);
				if (new List<RoadTileConnection>(roadTileSignature.Connections).Count >= 1)
				{
					_completeOnTraversalEnd = true;
					Log.Info("Targetted another road tile, drawing to it and stopping.");
				}
				else
				{
					_completeOnTraversalEnd = false;
				}
				base.Scope.Release(roadTileSignature);
			}
			Vector2Int end = _latestValidRoadEndTileCoordinates;
			Tile tile2 = _simulation.GetModel<TilemapModel>().GetTile(_roadEndTileCoordinates);
			if ((tile2 == null || tile2.CanDrawRoadsOn() || tile2.ContentType == TileContentType.House) && _city.IsTileInPlayableArea(_roadEndTileCoordinates, _clockModel.ExpansionTime) && _city.Definition.TileIsBuildable(_roadEndTileCoordinates))
			{
				end = _roadEndTileCoordinates;
			}
			IEnumerable<Vector2Int> pathBetweenPoints = _pathfinder.GetPathBetweenPoints(_roadStartTileCoordinates, end, _simulation, _city);
			if (pathBetweenPoints != null)
			{
				_path.Clear();
				_path.AddRange(pathBetweenPoints);
			}
			ClearDraftClientEdits();
			bool flag = true;
			Vector2Int vector2Int = _path[_path.Count - 1];
			for (int i = 1; i < _path.Count; i++)
			{
				if (!DraftRoadBetweenTiles(_path[i - 1], _path[i]))
				{
					flag = false;
					break;
				}
				vector2Int = _path[i];
			}
			flag &= vector2Int == _roadEndTileCoordinates;
			_latestValidRoadEndTileCoordinates = vector2Int;
			if (flag)
			{
				_notificationView.HideNotification();
			}
			_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.BuildRoad, GetPan().x, -1f, flag));
		}

		protected bool DraftRoadBetweenTiles(Vector2Int currentPosition, Vector2Int nextTilePosition)
		{
			TileDirection directionBetweenAdjacentCoordinates = TileUtilities.GetDirectionBetweenAdjacentCoordinates(currentPosition, nextTilePosition);
			Fix64 expansionTime = _clockModel.ExpansionTime;
			if (_city.IsTileInPlayableArea(currentPosition, expansionTime) && _city.IsTileInPlayableArea(nextTilePosition, expansionTime))
			{
				TileEditResult tileEditResult = _tileEditor.AddRoad(_tilemapView, currentPosition, directionBetweenAdjacentCoordinates);
				if (tileEditResult.IsSuccessful)
				{
					AddTileEdit(tileEditResult.edit, EditExecuteTiming.Draft);
					return true;
				}
				_notificationView.AddNotification(tileEditResult.resultCode, tileEditResult.errorPosition);
				return false;
			}
			return true;
		}

		private void SetActionFocusPoint(Vector2Int newFocusCoordinates)
		{
			_roadStartTileCoordinates = newFocusCoordinates;
			_roadEndTileCoordinates = newFocusCoordinates;
			UpdateCursorPosition();
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			if (inputEvent.InputAction == 2 || inputEvent.InputAction == 17)
			{
				ApplyDraftClientEdits();
				_audioSystem.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.Click, UIAudioProfile.Generic));
				bool flag = _roadEndTileCoordinates == _roadStartTileCoordinates;
				_roadStartTileCoordinates = _roadEndTileCoordinates;
				_cursorTileCoordinates = _roadEndTileCoordinates;
				if (base.Scope.Get<City>().Rules is TutorialGameRules)
				{
					base.Scope.Get<TutorialProgressionProcess>().SetCurrentControllerCursor(_cursorTileCoordinates);
				}
				if (_completeOnTraversalEnd || overUI || (_editCount > 0 && _upgradeDatabase.GetAvailableUpgradeCount(UpgradeType.Concrete) <= 0) || _upgradeDatabase.GetAvailableUpgradeCount(UpgradeType.Concrete) == 0 || flag)
				{
					if (overUI)
					{
						Log.Info("Complete Action - Input over the UI");
					}
					SetState(TapDrawState.Completing);
				}
				else
				{
					SetState(TapDrawState.Ready);
					SetActionFocusPoint(_cursorTileCoordinates);
				}
				_editCount++;
			}
			else if (inputEvent.InputAction == 7)
			{
				_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.MothballRoad));
				OnActionComplete();
			}
		}

		public override void OnActionComplete()
		{
			ClearDraftClientEdits();
			SetCursorVisible(visible: false);
			if (base.Scope.Get<City>().Rules is TutorialGameRules)
			{
				base.Scope.Get<TutorialProgressionProcess>().SetControllerIsDrawingRoads(isDrawingRoad: false);
			}
			_notificationView.HideAlertIcon();
			_notificationView.CancelNotification();
			base.OnActionComplete();
		}

		public override void OnActionCancel()
		{
			ClearDraftClientEdits();
			SetCursorVisible(visible: false);
			if (base.Scope.Get<City>().Rules is TutorialGameRules)
			{
				base.Scope.Get<TutorialProgressionProcess>().SetControllerIsDrawingRoads(isDrawingRoad: false);
			}
			_notificationView.HideAlertIcon();
			_notificationView.CancelNotification();
			base.OnActionCancel();
		}

		private void SetState(TapDrawState newState)
		{
			_tapState = newState;
			switch (newState)
			{
			case TapDrawState.Completing:
				OnActionComplete();
				break;
			case TapDrawState.Cancelling:
				OnActionCancel();
				break;
			}
		}

		protected override void SetCursorVisible(bool visible)
		{
			_gameUI.SetRoadCursorActive(visible);
			SetWorldGridVisible(visible);
			_tilemapView.viewMode = (visible ? TilemapView.ViewMode.Edit : TilemapView.ViewMode.Normal);
		}

		protected override void UpdateCursorPosition()
		{
			_gameUI.SetRoadCursorPosition(_gameUI.FocusPointPosition);
		}

		public override void Reset()
		{
			base.Reset();
			_tapState = TapDrawState.Initializing;
			_roadStartTileCoordinates = Vector2Int.zero;
			_roadEndTileCoordinates = Vector2Int.zero;
			_latestValidRoadEndTileCoordinates = Vector2Int.zero;
			_cursorTileCoordinates = Vector2Int.zero;
			_path.Clear();
			_completeOnTraversalEnd = false;
			_editCount = 0;
		}

		public static MotorwaysPlayerAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ControllerDrawRoadAction controllerDrawRoadAction = scope.Get<ControllerDrawRoadAction>();
			TilemapView tilemapView = scope.Get<TilemapView>();
			Tile tile = tilemapView.GetTile(controllerDrawRoadAction.GetPointerTilePosition());
			if (tile != null)
			{
				TileDirectionBitfield.Enumerator enumerator = tile.GetMotorwayRamps(RoadState.Planned | RoadState.Active).GetEnumerator();
				while (enumerator.MoveNext())
				{
					TileDirection current = enumerator.Current;
					if (!tilemapView.GetMotorway(tile.GetMotorwayInDirection(current, RoadState.Planned | RoadState.Active)).IsPermanent)
					{
						return ControllerDragEditMotorwayAction.Create(owningGroup, scope, timestamp);
					}
				}
			}
			controllerDrawRoadAction.InitializeAction(owningGroup, timestamp);
			InputEventSource source = owningGroup.InstigatingInputEvent.Source;
			controllerDrawRoadAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(source, 17, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDrawRoadAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(source, 2, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDrawRoadAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(source, 7, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDrawRoadAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(source, 18, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			ObserverGreediness inputGreediness = ((owningGroup.InstigatingInputEvent.Source == InputEventSource.Remote) ? ObserverGreediness.BlocksNewActions : ObserverGreediness.AllowsNewActions);
			controllerDrawRoadAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(source, 9, InputEventButtonState.JustDown), inputGreediness);
			Log.Info("Creating action.");
			controllerDrawRoadAction.OnActionBegin(timestamp);
			return controllerDrawRoadAction;
		}
	}
}
