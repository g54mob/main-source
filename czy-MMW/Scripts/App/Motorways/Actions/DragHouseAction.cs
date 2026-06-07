using System;
using Factory;
using Motorways.Audio;
using Motorways.Models;
using Motorways.UI;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Actions
{
	public class DragHouseAction : MotorwaysPlayerAction
	{
		private new static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("DragHouseAction");

		[Dependency]
		private IAudioSystem _audioSystem;

		[Dependency]
		private CameraView _cameraView;

		[Dependency]
		private GameCamera _gameCamera;

		[Dependency]
		private IScope _scope;

		[Dependency]
		private TilemapModel _tilemapModel;

		private Vector2Int _lastCheckedCoordinates;

		private Vector2Int _lastPlacedCoordinates;

		protected DraftHouse draftHouse;

		private Vector2Int _previousDragCoordinates;

		private Vector2Int _previousHouseCoordinates;

		private int _groupIndex;

		private TileDirection _drivewayDirection;

		protected bool fromUpgradeMenu;

		public override void Reset()
		{
			base.Reset();
			_lastCheckedCoordinates = default(Vector2Int);
			_lastPlacedCoordinates = default(Vector2Int);
			draftHouse = null;
			_previousDragCoordinates = default(Vector2Int);
			_previousHouseCoordinates = default(Vector2Int);
			_groupIndex = 0;
			_drivewayDirection = TileDirection.North;
			fromUpgradeMenu = false;
		}

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			SetColourWidgetRadialVisible(visible: false);
			if (fromUpgradeMenu)
			{
				_gameUI.ConfirmEditMenuEdit();
			}
			_gameUI.SetWorldGridActive(active: true);
			InitializeUpgradeCursor();
			EditMenuPanel editMenuPanel = _scope.Get<EditMenuPanel>();
			if (!fromUpgradeMenu)
			{
				ICreativeModeEditableObject editableObject = editMenuPanel.EditableObject;
				bool isOriginalDeleted = false;
				if (editableObject == null)
				{
					return;
				}
				Vector2Int tilePosition = editableObject.GetTilePosition();
				if (editableObject is CreativeModeEditableHouse creativeModeEditableHouse)
				{
					_groupIndex = creativeModeEditableHouse.GroupIndex;
					_drivewayDirection = creativeModeEditableHouse.DrivewayDirection;
					draftHouse = creativeModeEditableHouse.GetGhostPreview(out isOriginalDeleted) as DraftHouse;
					if (isOriginalDeleted)
					{
						editMenuPanel.CancelEdit();
					}
				}
				else if (editableObject is DraftHouse)
				{
					draftHouse = editMenuPanel.EditableObject as DraftHouse;
				}
				else
				{
					Log.Error("There should always be either a draft house or a creative mode editable house associated with DragHouseAction.");
				}
				_lastCheckedCoordinates = tilePosition;
				PlaceHousePreview(tilePosition, isOriginalDeleted, ref draftHouse);
			}
			else if (editMenuPanel.isActiveAndEnabled && editMenuPanel.EditableObject != null)
			{
				OnActionCancel();
			}
			else if (_upgradeDatabase.GetAvailableOrDraftUpgradeCount(UpgradeType.House) < 1)
			{
				OnActionCancel();
			}
			else
			{
				if (_gameUI.CurrentRoadDrawMode == RoadDrawMode.Remove)
				{
					_gameUI.ToggleDrawMode();
				}
				_gameUI.UpgradeBar.RemoveFromUpgradeButtonStack(UpgradeType.House, fromAnimation: true);
				_lastCheckedCoordinates = _gameUI.GetUpgradeCursorTileCoordinates();
				Log.Info("Beginning DragHouseAction from tile coordinates {0}.", _lastCheckedCoordinates);
				_gameUI.UpgradeBar.CreateAlertOnUpgradeButton(UpgradeType.House);
				_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeDragged, UpgradeType.House));
			}
		}

		public override void Tick(float frameTime)
		{
			base.Tick(frameTime);
			UpdateUpgradeCursorPosition();
			Vector2Int upgradeCursorTileCoordinates = _gameUI.GetUpgradeCursorTileCoordinates();
			bool hasSchedulableClientEdits = base.HasSchedulableClientEdits;
			if (upgradeCursorTileCoordinates != _lastCheckedCoordinates && (!hasSchedulableClientEdits || upgradeCursorTileCoordinates != _lastPlacedCoordinates))
			{
				if (hasSchedulableClientEdits)
				{
					ClearDraftClientEdits();
				}
				Vector2Int houseTileCoordinates = upgradeCursorTileCoordinates;
				if (PlaceHousePreview(houseTileCoordinates, isReplacement: false, ref draftHouse))
				{
					_lastPlacedCoordinates = draftHouse.tilePosition;
					if (fromUpgradeMenu)
					{
						_upgradeDatabase.ConsumeUpgrade(UpgradeType.House);
					}
					if (draftHouse != null && draftHouse.HasUnplaceableView)
					{
						draftHouse.EndUnplaceableView();
					}
					_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeDragSnap, UpgradeType.House, success: true, null, _tilemapView.GetScreenPositionFromTileCoordinates(upgradeCursorTileCoordinates)));
				}
				else if (draftHouse != null && !draftHouse.HasUnplaceableView)
				{
					draftHouse.StartUnplaceableView();
				}
			}
			_lastCheckedCoordinates = upgradeCursorTileCoordinates;
			if (draftHouse != null)
			{
				draftHouse.UpdatePosition(_lastCheckedCoordinates);
				draftHouse.UpdateDrivewayPosition(_drivewayDirection);
				if (draftHouse.IsTicking)
				{
					draftHouse.Tick(frameTime);
				}
			}
		}

		protected virtual void InitializeUpgradeCursor()
		{
			_gameUI.InitializeUpgradeCursor(UpgradeType.House);
			_gameUI.SetUpgradeCursorVisible(visible: false);
		}

		protected virtual void UpdateUpgradeCursorPosition()
		{
			if (_inputState.CurrentDeviceInputType == DeviceInputType.Touch)
			{
				_gameUI.SetUpgradeCursorPosition(GetPointerScreenPosition(), UpgradeCursor.UpgradeCursorOffsetType.TopLeft);
			}
			else
			{
				_gameUI.SetUpgradeCursorPosition(GetPointerScreenPosition(), UpgradeCursor.UpgradeCursorOffsetType.OnPointer);
			}
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			if ((inputEvent.Source == InputEventSource.Mouse && inputEvent.InputAction == 19 && inputEvent.ButtonState == InputEventButtonState.JustUp) || (inputEvent.Source == InputEventSource.Touch && inputEvent.ButtonState == InputEventButtonState.JustUp) || (inputEvent.Source == InputEventSource.Remote && inputEvent.InputAction == 2 && inputEvent.ButtonState == InputEventButtonState.JustDown))
			{
				if (draftHouse == null || draftHouse.CompletelyOutOfPlayArea(_city))
				{
					OnActionCancel();
				}
				else
				{
					OnActionComplete();
				}
			}
			else if (inputEvent.InputAction == 18 || inputEvent.InputAction == 20)
			{
				OnActionCancel();
			}
			else
			{
				Log.Error($"Unexpected input: {inputEvent}!");
				OnActionCancel();
			}
		}

		public override void OnActionCancel()
		{
			base.OnActionCancel();
			if (_gameUI.HasUpgradeCursor)
			{
				if (fromUpgradeMenu)
				{
					_gameUI.UpgradeBar.AddToUpgradeButtonStack(UpgradeType.House, fromAnimation: true);
				}
				_gameUI.CancelUpgradeCursor();
			}
			ClearOutAllDrafts();
			if (!_cameraView.IsFocussedIn)
			{
				_gameUI.SetWorldGridActive(active: false);
			}
			_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeReleased, UpgradeType.House, success: false));
		}

		private void ClearOutAllDrafts()
		{
			if (draftHouse != null)
			{
				if (fromUpgradeMenu)
				{
					base.Scope.Release(draftHouse);
				}
				else if (_gameUI.editMenuPanel.EditableObject != null)
				{
					_gameUI.editMenuPanel.CancelEdit();
				}
				else
				{
					draftHouse.Cancel();
				}
				draftHouse = null;
			}
		}

		public override void OnActionComplete()
		{
			Log.Info("Completing House Add action.");
			_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.UpgradePlaced, _gameCamera.GetPanFromWorld(TilemapView.GetWorldPositionForCoordinates(_lastPlacedCoordinates)).x));
			if (_gameUI.HasUpgradeCursor)
			{
				if (fromUpgradeMenu)
				{
					_gameUI.PlaceUpgradeCursorAssetAtPosition(_lastPlacedCoordinates);
					_gameUI.UpgradeBar.AddToUpgradeButtonStack(UpgradeType.House, fromAnimation: true);
				}
				_gameUI.CancelUpgradeCursor();
			}
			if (!_cameraView.playerZoomedIn)
			{
				_gameUI.SetWorldGridActive(active: false);
				_tilemapView.viewMode = TilemapView.ViewMode.Normal;
			}
			base.Scope.Get<GameUIScreen>().OpenEditMenu(draftHouse, fromUpgradeMenu);
			base.OnActionComplete();
			_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeReleased, UpgradeType.House));
		}

		private bool PlaceHousePreview(Vector2Int houseTileCoordinates, bool isReplacement, ref DraftHouse draftHouse)
		{
			bool result = true;
			_groupIndex = _scope.Get<ColourWidget>().CurrentColour;
			if (!_city.IsTileInPlayableArea(houseTileCoordinates, _clockModel.ExpansionTime))
			{
				Log.Info("House coordinates {0} are outside playable area.");
				result = false;
			}
			Tile tile = _tilemapView.GetTile(houseTileCoordinates);
			if (tile != null && (tile.ContentType != TileContentType.None || tile.GetTwoLaneRoadCount(RoadState.VisiblyActive | RoadState.Mothballed, Tile.MotorwayInclusion.Include) > 0 || tile.HasRailConnection))
			{
				if (tile.ContentType == TileContentType.Tree && _city.Rules.ShouldBuildingsBulldozeTrees)
				{
					Log.Info("Allowing placement over tree at {0} as this will get bulldozed", houseTileCoordinates);
				}
				else if (tile.ContentType == TileContentType.House && isReplacement)
				{
					Log.Info("Allowing placement over house, as that is this ghost previews old self");
				}
				else
				{
					Log.Info("Cannot build house on tile {0} as it already has contents or road", houseTileCoordinates);
					result = false;
				}
			}
			if (tile != null && (tile.IsCenterOfRoundabout || tile.HasRoundabout(RoadState.VisiblyActive | RoadState.Mothballed)))
			{
				Log.Info("Cannot build house on tile {0} as it contains a roundabout", tile.Coordinates);
				result = false;
			}
			if (!_city.Definition.TileIsBuildable(houseTileCoordinates) || _city.Definition.TileIsOverWater(houseTileCoordinates) || _city.Definition.TileIsUnderAMountain(houseTileCoordinates))
			{
				Log.Info("Can't place destination over tile at {0} because it's {1}", houseTileCoordinates, _tilemapModel.IsTileReserved(houseTileCoordinates) ? "Reserved" : "Water or Mountain");
				result = false;
			}
			_drivewayDirection = TileDirection.None;
			foreach (TileDirection value in Enum.GetValues(typeof(TileDirection)))
			{
				if (value == TileDirection.None)
				{
					continue;
				}
				Vector2Int adjacentCoordinates = TileUtilities.GetAdjacentCoordinates(houseTileCoordinates, value);
				if (_city.IsTileInPlayableArea(adjacentCoordinates, _clockModel.ExpansionTime))
				{
					Tile tile2 = _tilemapView.GetTile(adjacentCoordinates);
					bool flag = tile2 == null || (tile2.ContentType == TileContentType.None && !tile2.HasRailConnection);
					if (!_city.Definition.TileIsBuildable(adjacentCoordinates) || _city.Definition.TileIsOverWater(adjacentCoordinates) || _city.Definition.TileIsUnderAMountain(adjacentCoordinates))
					{
						flag = false;
					}
					Vector2Int tileCoordinates = new Vector2Int(houseTileCoordinates.x, adjacentCoordinates.y);
					Vector2Int tileCoordinates2 = new Vector2Int(adjacentCoordinates.x, houseTileCoordinates.y);
					if (tileCoordinates.x != tileCoordinates2.x && tileCoordinates.y != tileCoordinates2.y && _city.Definition.TileIsOverRail(tileCoordinates) && _city.Definition.TileIsOverRail(tileCoordinates2))
					{
						flag = false;
					}
					if (flag)
					{
						_drivewayDirection = value;
						break;
					}
				}
			}
			if (_drivewayDirection == TileDirection.None)
			{
				Log.Warn("Failed to find a valid driveway direction from house coordinates {0}", houseTileCoordinates);
				_drivewayDirection = TileDirection.North;
				result = false;
			}
			if (draftHouse == null)
			{
				draftHouse = _scope.Get<DraftHouse>();
				draftHouse.Initialize(houseTileCoordinates, base.Scope, _groupIndex, _drivewayDirection);
				PlayerAction.Log.Info("Spawned draft house at {0}.", houseTileCoordinates);
			}
			return result;
		}

		public static DragHouseAction CreateFromUpgradeMenu(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			return Create(owningGroup, scope, timestamp, fromUpgradeMenu: true);
		}

		public static DragHouseAction CreateFromEditMenu(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			return Create(owningGroup, scope, timestamp, fromUpgradeMenu: false);
		}

		public static DragHouseAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp, bool fromUpgradeMenu)
		{
			DragHouseAction dragHouseAction = scope.Get<DragHouseAction>();
			dragHouseAction.fromUpgradeMenu = fromUpgradeMenu;
			dragHouseAction.InitializeAction(owningGroup, timestamp);
			if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Mouse)
			{
				dragHouseAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(19, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
				dragHouseAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(20, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
				dragHouseAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(18, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			}
			else if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Touch)
			{
				dragHouseAction.RegisterObserveInputEvent(InputEventFilter.CreateTouchEventFilter(0, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
				dragHouseAction.BlockNewTouchUpgradeActions();
			}
			else if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Remote)
			{
				dragHouseAction.RegisterObserveInputEvent(InputEventFilter.CreateRemoteEventFilter(2, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			}
			dragHouseAction.OnActionBegin(timestamp);
			dragHouseAction.MakeExclusive();
			dragHouseAction.SetWorldGridVisible(visible: true);
			return dragHouseAction;
		}
	}
}
