using System;
using System.Collections.Generic;
using Factory;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Actions
{
	public abstract class AddMotorwayAction : MotorwaysPlayerAction
	{
		protected enum MotorwayActionResult
		{
			Success = 0,
			TileDoesNotSupportMotorway = 1,
			TooShort = 2,
			NoAvailableRampDirection = 3,
			NoAvailableRampPairing = 4,
			CollidesWithMountain = 5
		}

		[Dependency]
		protected IAudioSystem _audioSystem;

		[Dependency]
		private NotificationView _notificationView;

		protected int _newMotorwayId = -1;

		protected int _newMotorwayNumber;

		protected Vector2Int _anchorCoordinates;

		protected TileDirection _anchorDirection;

		protected Vector2Int _danglingCoordinates;

		protected TileDirection _danglingDirection;

		protected MotorwayView MotorwayBeingEdited
		{
			get
			{
				if (_newMotorwayId != -1)
				{
					return _tilemapView.GetMotorwayView(_newMotorwayId);
				}
				return null;
			}
		}

		public override void Reset()
		{
			base.Reset();
			_newMotorwayId = -1;
			_newMotorwayNumber = 0;
			_anchorCoordinates = default(Vector2Int);
			_anchorDirection = TileDirection.North;
			_danglingCoordinates = default(Vector2Int);
			_danglingDirection = TileDirection.North;
		}

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			SetColourWidgetRadialVisible(visible: false);
			_newMotorwayId = -1;
			_newMotorwayNumber = 0;
		}

		public override void OnActionComplete()
		{
			if (MotorwayBeingEdited != null)
			{
				MotorwayBeingEdited.IsBeingEdited = false;
			}
			base.OnActionComplete();
		}

		public override void OnActionCancel()
		{
			if (MotorwayBeingEdited != null)
			{
				MotorwayBeingEdited.IsBeingEdited = false;
			}
			base.OnActionCancel();
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			if (inputEvent.Source == InputEventSource.Mouse)
			{
				if (inputEvent.InputAction == 19 && inputEvent.ButtonState == InputEventButtonState.JustUp)
				{
					OnActionComplete();
					return;
				}
				if (inputEvent.InputAction == 20 && inputEvent.ButtonState == InputEventButtonState.JustDown)
				{
					OnActionCancel();
					return;
				}
				PlayerAction.Log.Error($"Unexpected mouse button index {inputEvent.InputAction} with state {inputEvent.ButtonState} from input {inputEvent}!");
				OnActionCancel();
			}
			else
			{
				OnActionComplete();
			}
		}

		protected MotorwayActionResult SetAnchorTile(Vector2Int anchorCoordinates, TileDirection anchorDirection)
		{
			if (!DoesTileSupportMotorway(anchorCoordinates))
			{
				PlayerAction.Log.Info("AddMotorwayAction cannot anchor at tile {0} (over water or not buildable).", anchorCoordinates);
				return MotorwayActionResult.TileDoesNotSupportMotorway;
			}
			if (anchorDirection == TileDirection.None && !DoesTileHaveAvailableDirection(anchorCoordinates))
			{
				PlayerAction.Log.Info("AddMotorwayAction cannot find a valid direction on anchor tile {0}.", anchorCoordinates);
				return MotorwayActionResult.NoAvailableRampDirection;
			}
			if (_newMotorwayId == -1)
			{
				_newMotorwayId = _city.GetNextMotorwayIdAndIncrement();
				PlayerAction.Log.Info("AddMotorwayAction creating motorway {0}, beginning from anchor coordinates {1} in direction {2}.", _newMotorwayId, _anchorCoordinates, _anchorDirection);
			}
			_anchorCoordinates = anchorCoordinates;
			_anchorDirection = anchorDirection;
			return MotorwayActionResult.Success;
		}

		private bool CrossesRailDiagonal(Vector2Int start, TileDirection direction)
		{
			Vector2Int adjacencyOffsetForDirection = TileUtilities.GetAdjacencyOffsetForDirection(direction);
			Vector2Int vector2Int = new Vector2Int(adjacencyOffsetForDirection.x, 0);
			Vector2Int vector2Int2 = new Vector2Int(0, adjacencyOffsetForDirection.y);
			Tile tile = _tilemapView.GetTile(start + vector2Int);
			Tile tile2 = _tilemapView.GetTile(start + vector2Int2);
			if (tile != null && tile.HasRailConnection && tile2 != null && tile2.HasRailConnection)
			{
				return true;
			}
			return false;
		}

		protected MotorwayActionResult SetDanglingTile(Vector2Int danglingCoordinates)
		{
			if (!DoesTileSupportMotorway(danglingCoordinates))
			{
				return MotorwayActionResult.TileDoesNotSupportMotorway;
			}
			if (HasMotorwayOnTile(danglingCoordinates))
			{
				return MotorwayActionResult.TileDoesNotSupportMotorway;
			}
			if (Mathf.Abs(danglingCoordinates.x - _anchorCoordinates.x) <= 1 && Mathf.Abs(danglingCoordinates.y - _anchorCoordinates.y) <= 1)
			{
				return MotorwayActionResult.TooShort;
			}
			TileDirectionBitfield tileDirectionBitfield = GetAvailableMotorwayDirections(_anchorCoordinates);
			TileDirectionBitfield availableMotorwayDirections = GetAvailableMotorwayDirections(danglingCoordinates);
			if (tileDirectionBitfield.Count * availableMotorwayDirections.Count == 0)
			{
				return MotorwayActionResult.NoAvailableRampDirection;
			}
			Vector2 normalized = ((Vector2)(danglingCoordinates - _anchorCoordinates)).normalized;
			TileDirection closestDirection = TileUtilities.GetClosestDirection(normalized);
			if (Mathf.Abs(TileUtilities.GetDistanceBetweenDirections(_anchorDirection, closestDirection)) <= 1)
			{
				TileDirection tileDirection = TileDirection.None;
				tileDirection = ((!(Vector2.Dot(TileUtilities.GetVectorForDirection(_anchorDirection), normalized) <= Mathf.Cos((float)Math.PI / 4f)) || CrossesRailDiagonal(_anchorCoordinates, closestDirection)) ? _anchorDirection : closestDirection);
				if (tileDirection != TileDirection.None && tileDirectionBitfield[tileDirection])
				{
					tileDirectionBitfield = new TileDirectionBitfield(tileDirection);
				}
			}
			Vector2 tangent = normalized.GetTangent();
			List<Tuple<TileDirection, TileDirection, float>> list = new List<Tuple<TileDirection, TileDirection, float>>();
			TileDirectionBitfield.Enumerator enumerator = tileDirectionBitfield.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				Vector2 vectorForDirection = TileUtilities.GetVectorForDirection(current);
				float num = Vector2.Dot(vectorForDirection, normalized) * 0.5f + 0.5f;
				float num2 = Vector2.Dot(vectorForDirection, tangent);
				bool flag = CrossesRailDiagonal(_anchorCoordinates, current);
				TileDirectionBitfield.Enumerator enumerator2 = availableMotorwayDirections.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					TileDirection current2 = enumerator2.Current;
					Vector2 vectorForDirection2 = TileUtilities.GetVectorForDirection(current2);
					float num3 = Vector2.Dot(vectorForDirection2, -normalized) * 0.5f + 0.5f;
					float num4 = Vector2.Dot(vectorForDirection2, tangent);
					float num5 = num * num3;
					if (num2 * num4 > 0f)
					{
						num5 += 0.1f;
					}
					if (flag)
					{
						num5 -= 0.5f;
					}
					if (CrossesRailDiagonal(danglingCoordinates, current2))
					{
						num5 -= 0.5f;
					}
					int num6 = 0;
					foreach (Tuple<TileDirection, TileDirection, float> item in list)
					{
						if (num5 > item.Item3)
						{
							break;
						}
						num6++;
					}
					list.Insert(num6, new Tuple<TileDirection, TileDirection, float>(current, current2, num5));
				}
			}
			if (list.Count == 0 || (list[0].Item1 == TileDirection.None && list[0].Item2 == TileDirection.None))
			{
				return MotorwayActionResult.NoAvailableRampPairing;
			}
			_anchorDirection = list[0].Item1;
			_danglingDirection = list[0].Item2;
			_danglingCoordinates = danglingCoordinates;
			return MotorwayActionResult.Success;
		}

		protected bool HasMotorwayOnTile(Vector2Int position, int editedMotorwayId = -1)
		{
			Tile tile = _tilemapView.GetTile(position);
			if (tile != null)
			{
				if (tile.UnbuiltMotorwayId != -1 && tile.UnbuiltMotorwayId != editedMotorwayId)
				{
					return true;
				}
				TileDirectionBitfield.Enumerator enumerator = tile.GetMotorwayRamps(RoadState.VisiblyActive).GetEnumerator();
				while (enumerator.MoveNext())
				{
					TileDirection current = enumerator.Current;
					if (tile.GetMotorwayInDirection(current, RoadState.VisiblyActive) != editedMotorwayId)
					{
						return true;
					}
				}
			}
			return false;
		}

		protected void DisplayError(MotorwayActionResult errorCode, bool errorPertainsToAnchor)
		{
			StringId stringId = StringId.None;
			float delay = 0f;
			switch (errorCode)
			{
			case MotorwayActionResult.TileDoesNotSupportMotorway:
				stringId = StringId.Error_TileDoesntSupportMotorway;
				delay = 0.5f;
				break;
			case MotorwayActionResult.TooShort:
				stringId = StringId.Error_MotorwayTooShort;
				delay = 1f;
				break;
			case MotorwayActionResult.NoAvailableRampDirection:
				stringId = StringId.Error_MotorwayNoAvailableRampDirection;
				delay = 0.5f;
				break;
			case MotorwayActionResult.NoAvailableRampPairing:
				stringId = StringId.Error_MotorwayNoAvailableRampDirection;
				delay = 0.5f;
				break;
			case MotorwayActionResult.CollidesWithMountain:
				stringId = StringId.Error_MotorwayCollidesWithMountain;
				delay = 0.5f;
				break;
			}
			if (stringId != StringId.None)
			{
				_notificationView.AddNotification(stringId, delay);
			}
		}

		protected bool UpdateTileEdit()
		{
			TileEditResult tileEditResult = CreateTileEdit(_newMotorwayId, _newMotorwayNumber, _anchorCoordinates, _anchorDirection, _danglingCoordinates, _danglingDirection);
			if (tileEditResult.IsSuccessful)
			{
				ClearDraftClientEdits();
				AddTileEdit(tileEditResult.edit, EditExecuteTiming.Draft);
				if (MotorwayBeingEdited != null)
				{
					MotorwayBeingEdited.IsBeingEdited = true;
				}
				_feedbackGenerator.GenerateFeedback(HapticFeedbackType.LightImpact);
			}
			return tileEditResult.IsSuccessful;
		}

		protected abstract TileEditResult CreateTileEdit(int newMotorwayId, int motorwayNumber, Vector2Int anchorCoordinates, TileDirection anchorDirection, Vector2Int danglingCoordinates, TileDirection danglingDirection);

		protected bool DoesTileSupportMotorway(Vector2Int coordinates)
		{
			if (!_city.Definition.TileIsBuildable(coordinates) || _city.Definition.TileIsOverWater(coordinates) || _city.Definition.TileIsUnderAMountain(coordinates) || _city.Definition.TileIsOverRail(coordinates))
			{
				return false;
			}
			if (!_city.IsTileInPlayableArea(coordinates, _clockModel.ExpansionTime))
			{
				return false;
			}
			Tile tile = _tilemapView.GetTile(coordinates);
			if (tile == null)
			{
				return true;
			}
			return tile.ContentType == TileContentType.None;
		}

		private bool DoesTileHaveAvailableDirection(Vector2Int coordinates)
		{
			Tile tile = _tilemapView.GetTile(coordinates);
			if (tile == null)
			{
				return true;
			}
			for (int i = 0; i < 8; i++)
			{
				if (TileEditor.TileSupportsMotorwayInDirection(tile, (TileDirection)i, _city.NextMotorwayId))
				{
					return true;
				}
			}
			return false;
		}

		private TileDirectionBitfield GetAvailableMotorwayDirections(Vector2Int coordinates)
		{
			Tile tile = _tilemapView.GetTile(coordinates);
			if (tile == null)
			{
				return TileDirectionBitfield.All;
			}
			TileDirectionBitfield result = default(TileDirectionBitfield);
			for (int i = 0; i < 8; i++)
			{
				TileDirection direction = (TileDirection)i;
				result[direction] = tile.CanSetNodeState(new RoadTileNode(direction, RoadType.Motorway, (_newMotorwayId != -1) ? _newMotorwayId : _city.NextMotorwayId), RoadState.Planned);
			}
			return result;
		}

		protected TileDirection ValidTileDirectionFor(Vector2Int start, Vector2Int end)
		{
			Vector2 normalized = ((Vector2)(end - start)).normalized;
			TileDirection closestDirection = TileUtilities.GetClosestDirection(normalized);
			bool preferClockwise = Vector2.Dot(TileUtilities.DirectionToTileAdjacencyOffset[(int)TileUtilities.GetRotatedDirection(closestDirection, 2)], normalized) > 0f;
			Tile tile = _tilemapView.GetTile(start);
			if (tile == null)
			{
				return closestDirection;
			}
			foreach (TileDirection radiatedDirection in TileUtilities.GetRadiatedDirections(closestDirection, preferClockwise))
			{
				if (TileEditor.TileSupportsMotorwayInDirection(tile, radiatedDirection, (_newMotorwayId != -1) ? _newMotorwayId : _city.NextMotorwayId))
				{
					return radiatedDirection;
				}
			}
			return TileDirection.None;
		}
	}
}
