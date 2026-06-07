using Factory;
using Motorways.Audio;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Actions
{
	public class DragEditMotorwayAction : AddMotorwayAction
	{
		[Dependency]
		private CameraView _cameraView;

		[Dependency]
		private NotificationView _notificationView;

		[Dependency]
		private IScope _scope;

		private int _editedMotorwayId = -1;

		private bool _hasReplacedMothballEdit;

		private bool _didShowGrid;

		private bool _hasScheduledOverEvent;

		private Vector2Int _previousTilePosition;

		public override void Reset()
		{
			_editedMotorwayId = -1;
			_hasReplacedMothballEdit = false;
			_didShowGrid = false;
			_hasScheduledOverEvent = false;
			_previousTilePosition = default(Vector2Int);
			base.Reset();
		}

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			_didShowGrid = false;
			if (_gameUI.CurrentRoadDrawMode == RoadDrawMode.Remove && ((base.OwningGroup.InstigatingInputEvent.Source == InputEventSource.Touch && _cameraView.IsFocussedIn) || base.OwningGroup.InstigatingInputEvent.Source != InputEventSource.Touch))
			{
				OnActionCancel();
				return;
			}
			if (_inputState.TouchCount > 1)
			{
				OnActionCancel();
				return;
			}
			SetColourWidgetRadialVisible(visible: false);
			_editedMotorwayId = -1;
			_hasReplacedMothballEdit = false;
			Vector2Int pointerTilePosition = GetPointerTilePosition();
			Tile tile = _tilemapView.GetTile(pointerTilePosition);
			if (tile != null)
			{
				if (tile.UnbuiltMotorwayId != -1)
				{
					_newMotorwayId = tile.UnbuiltMotorwayId;
					_newMotorwayNumber = tile.UnbuiltMotorwayNumber;
					PlayerAction.Log.Info("Extending the unbuilt motorway {0}", _newMotorwayId);
					MotorwayActionResult motorwayActionResult = SetAnchorTile(pointerTilePosition, TileDirection.None);
					if (motorwayActionResult != MotorwayActionResult.Success)
					{
						DisplayError(motorwayActionResult, errorPertainsToAnchor: true);
						OnActionCancel();
						return;
					}
				}
				else
				{
					TileDirectionBitfield motorwayRamps = tile.GetMotorwayRamps(RoadState.Planned | RoadState.Active);
					if (motorwayRamps.Count > 0)
					{
						int num = -1;
						TileDirectionBitfield.Enumerator enumerator = motorwayRamps.GetEnumerator();
						while (enumerator.MoveNext())
						{
							TileDirection current = enumerator.Current;
							int motorwayInDirection = tile.GetMotorwayInDirection(current, RoadState.Planned | RoadState.Active);
							if (motorwayInDirection != -1 && (!_tilemapView.GetMotorway(motorwayInDirection).IsPermanent || !_city.Rules.RoadsBecomePermanentOverTime))
							{
								num = motorwayInDirection;
								break;
							}
						}
						if (num != -1)
						{
							Motorway motorway = _tilemapView.GetMotorway(num);
							if (Diagnostics.Verify(motorway != null, "Tile {0} has a reference to missing motorway {1}.", tile.Coordinates, num))
							{
								bool flag = false;
								MotorwayActionResult motorwayActionResult2 = MotorwayActionResult.Success;
								if (motorway.StartCoordinates == tile.Coordinates)
								{
									motorwayActionResult2 = SetAnchorTile(motorway.EndCoordinates, motorway.EndDirection);
									flag = motorwayActionResult2 == MotorwayActionResult.Success;
								}
								else if (motorway.EndCoordinates == tile.Coordinates)
								{
									motorwayActionResult2 = SetAnchorTile(motorway.StartCoordinates, motorway.StartDirection);
									flag = motorwayActionResult2 == MotorwayActionResult.Success;
								}
								else
								{
									Diagnostics.FailAssert("Expected motorway {0} to connect to tile at {1}, but ends are at {2} and {3}.", motorway.Id, tile.Coordinates, motorway.StartCoordinates, motorway.EndCoordinates);
								}
								if (flag)
								{
									_editedMotorwayId = motorway.Id;
									_newMotorwayNumber = motorway.Number;
									TileEdit edit = MothballMotorwayEdit.Create(base.Scope, _editedMotorwayId);
									AddTileEdit(edit, EditExecuteTiming.Draft);
								}
								else
								{
									DisplayError(motorwayActionResult2, errorPertainsToAnchor: true);
								}
							}
						}
					}
				}
			}
			if ((tile != null && tile.UnbuiltMotorwayId != -1) || _editedMotorwayId != -1)
			{
				MakeExclusive();
				SetGridVisible(visible: true);
			}
			else
			{
				OnActionCancel();
			}
		}

		public override void OnActionComplete()
		{
			if (!_hasReplacedMothballEdit)
			{
				ClearDraftClientEdits();
			}
			_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeReleased, UpgradeType.Motorway, success: true, base.MotorwayBeingEdited));
			if (!_cameraView.IsFocussedIn)
			{
				SetGridVisible(visible: false);
			}
			SetMotorwayGridVisible(visible: false);
			base.OnActionComplete();
		}

		public override void OnActionCancel()
		{
			base.OnActionCancel();
			ClearDraftClientEdits();
			SetGridVisible(visible: false);
			SetMotorwayGridVisible(visible: false);
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
			_gameUI.SetMotorwayGridActive(visible);
		}

		public override void Tick(float frameTime)
		{
			base.Tick(frameTime);
			if (_inputState.TouchCount > 1)
			{
				TouchCameraAction.Create(base.OwningGroup, _scope, _inputState.LastInputTimestamp);
				OnActionCancel();
				return;
			}
			Vector2Int pointerTilePosition = GetPointerTilePosition();
			if (pointerTilePosition != _danglingCoordinates && pointerTilePosition != _previousTilePosition)
			{
				MotorwayActionResult motorwayActionResult = SetDanglingTile(pointerTilePosition);
				if (HasMotorwayOnTile(pointerTilePosition, _editedMotorwayId))
				{
					motorwayActionResult = MotorwayActionResult.TileDoesNotSupportMotorway;
				}
				if (motorwayActionResult == MotorwayActionResult.Success)
				{
					UpdateTileEdit();
					_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeDragSnap, UpgradeType.Motorway, success: true, null, _tilemapView.GetScreenPositionFromTileCoordinates(pointerTilePosition)));
				}
				else
				{
					DisplayError(motorwayActionResult, errorPertainsToAnchor: false);
				}
			}
			_previousTilePosition = pointerTilePosition;
		}

		protected override TileEditResult CreateTileEdit(int newMotorwayId, int motorwayNumber, Vector2Int anchorCoordinates, TileDirection anchorDirection, Vector2Int danglingCoordinates, TileDirection danglingDirection)
		{
			TileEditResult result = _tileEditor.AddMotorway(_tilemapView, newMotorwayId, motorwayNumber, anchorCoordinates, anchorDirection, danglingCoordinates, danglingDirection, _editedMotorwayId);
			if (result.IsSuccessful)
			{
				if (result.edit != null)
				{
					_notificationView.HideNotification();
					_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeOver, UpgradeType.Motorway, success: true, base.MotorwayBeingEdited));
					_hasScheduledOverEvent = true;
					_hasReplacedMothballEdit = true;
					return result;
				}
			}
			else
			{
				if (result.edit != null)
				{
					_scope.Release(result.edit);
				}
				_notificationView.AddNotification(result.resultCode, result.errorPosition);
			}
			if (_hasScheduledOverEvent)
			{
				_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeOut, UpgradeType.Motorway, success: true, base.MotorwayBeingEdited));
				_hasScheduledOverEvent = false;
			}
			return result;
		}

		public static DragEditMotorwayAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			DragEditMotorwayAction dragEditMotorwayAction = scope.Get<DragEditMotorwayAction>();
			dragEditMotorwayAction.InitializeAction(owningGroup, timestamp);
			if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Mouse)
			{
				dragEditMotorwayAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(19, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
				dragEditMotorwayAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(20, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			}
			else if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Touch)
			{
				dragEditMotorwayAction.RegisterObserveInputEvent(InputEventFilter.CreateTouchEventFilter(0, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
				dragEditMotorwayAction.BlockNewTouchUpgradeActions();
			}
			dragEditMotorwayAction.OnActionBegin(timestamp);
			return dragEditMotorwayAction;
		}
	}
}
