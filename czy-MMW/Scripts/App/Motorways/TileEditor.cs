using System;
using System.Collections.Generic;
using Factory;
using FixMath;
using Motorways.Models;
using Motorways.Utility;
using UnityEngine;

namespace Motorways
{
	public class TileEditor
	{
		public enum ClearTileOfType
		{
			TrafficLight = 0,
			UnbuiltMotorway = 1,
			BuiltMotorways = 2,
			Roundabout = 3,
			Passages = 4,
			Roads = 5,
			Any = 6
		}

		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("TileEditor");

		[Dependency]
		private IScope _scope;

		[Dependency]
		private GameBehaviourModel _behaviour;

		[Dependency]
		private City _city;

		[Dependency]
		private ClientUpgradeDatabase _upgradeDatabase;

		private GameRules Rules => _city.Rules;

		public TileEditResult AddRoad(ITilemap tilemap, Vector2Int originCoordinates, TileDirection direction)
		{
			Log.Info("Attempting to add road from {0} in direction {1}.", originCoordinates, direction);
			Tile orCreateTile = tilemap.GetOrCreateTile(originCoordinates);
			Vector2Int adjacentCoordinates = TileUtilities.GetAdjacentCoordinates(originCoordinates, direction);
			Tile orCreateTile2 = tilemap.GetOrCreateTile(adjacentCoordinates);
			if (orCreateTile == null || orCreateTile2 == null)
			{
				if (orCreateTile == null)
				{
					Log.Error("Unable to add road, no origin tile with coordinates {0}.", originCoordinates);
				}
				if (orCreateTile2 == null)
				{
					Log.Error("Unable to add road, no destination tile with coordinates {0}.", adjacentCoordinates);
				}
				return TileEditResult.InvalidTileCoordinate(originCoordinates);
			}
			if (!_city.Definition.TileIsBuildable(originCoordinates) || !_city.Definition.TileIsBuildable(adjacentCoordinates))
			{
				Log.Info("Cannot connect an unbuildable tile.");
				return TileEditResult.InvalidTileCoordinate(originCoordinates);
			}
			bool flag = orCreateTile.ContentType == TileContentType.Carpark || orCreateTile.ContentType == TileContentType.Destination;
			bool flag2 = orCreateTile2.ContentType == TileContentType.Carpark || orCreateTile2.ContentType == TileContentType.Destination;
			if (flag || flag2)
			{
				if (flag && flag2)
				{
					return TileEditResult.InvalidTileCoordinate(originCoordinates);
				}
				if ((flag2 && orCreateTile.HasTwoLaneRoadInDirection(direction)) || (flag && orCreateTile2.HasTwoLaneRoadInDirection(TileUtilities.GetOppositeDirection(direction))))
				{
					return TileEditResult.Success;
				}
				Log.Info("Cannot connect directly to a carpark.");
				return TileEditResult.CannotConnectToCarpark(originCoordinates);
			}
			if (_city.Definition.TileIsOverWater(originCoordinates) && _city.Definition.TileIsOverRail(originCoordinates))
			{
				return TileEditResult.CannotCreateBridge(originCoordinates);
			}
			if (_city.Definition.TileIsOverWater(adjacentCoordinates) && _city.Definition.TileIsOverRail(adjacentCoordinates))
			{
				return TileEditResult.CannotCreateBridge(adjacentCoordinates);
			}
			if (_city.Definition.TileIsOverWater(originCoordinates) && _city.Definition.TileIsUnderAMountain(adjacentCoordinates))
			{
				return TileEditResult.CannotCreateTunnel(adjacentCoordinates);
			}
			if (_city.Definition.TileIsUnderAMountain(originCoordinates) && _city.Definition.TileIsOverWater(adjacentCoordinates))
			{
				return TileEditResult.CannotCreateBridge(adjacentCoordinates);
			}
			if (!WouldConnectionPassPassageConstraints(orCreateTile, orCreateTile2, originCoordinates, adjacentCoordinates, direction, tilemap, UpgradeType.Bridge, _city.Definition.TileIsOverWater))
			{
				return TileEditResult.CannotCreateBridge(originCoordinates);
			}
			if (!WouldConnectionPassPassageConstraints(orCreateTile, orCreateTile2, originCoordinates, adjacentCoordinates, direction, tilemap, UpgradeType.Tunnel, _city.Definition.TileIsUnderAMountain))
			{
				return TileEditResult.CannotCreateTunnel(originCoordinates);
			}
			if (orCreateTile.ContentType == TileContentType.House || orCreateTile2.ContentType == TileContentType.House)
			{
				if (orCreateTile.ContentType == TileContentType.House && orCreateTile2.ContentType == TileContentType.House)
				{
					Log.Info("Ignoring edit between two houses.");
					return new TileEditResult
					{
						resultCode = TileEditResultCode.Success,
						edit = null
					};
				}
				Tile tile;
				Tile tile2;
				TileDirection tileDirection;
				if (orCreateTile.ContentType == TileContentType.House)
				{
					tile = orCreateTile;
					tile2 = orCreateTile2;
					tileDirection = direction;
				}
				else
				{
					tile = orCreateTile2;
					tile2 = orCreateTile;
					tileDirection = TileUtilities.GetOppositeDirection(direction);
				}
				if (!WouldDrivewayPassPassageConstraints(tile, tile2, _city.Definition, out var onFailure))
				{
					return onFailure;
				}
				RoadTileNode node = new RoadTileNode(tileDirection, RoadType.Driveway);
				RoadTileNode roadTileNode = new RoadTileNode(TileUtilities.GetOppositeDirection(tileDirection));
				TileEdit edit = null;
				if (tile.CanSetNodeState(node, RoadState.Pending) && tile2.CanSetNodeState(roadTileNode, RoadState.Pending) && tile2.CanDrawRoadsOn())
				{
					if (tile2.HasRoundabout(RoadState.Mothballed) && !Roundabout.CanConnectionAddExitNode(tile2.GetRoundaboutConnection(RoadState.Mothballed), roadTileNode))
					{
						Log.Info("Cannot realign driveway from house at tile {0} to direction {1} because it is blocked by a mothballed roundabouts.", tile.Coordinates, tileDirection);
					}
					else
					{
						Log.Info("Realigning driveway from house at tile {0} to direction {1}.", tile.Coordinates, tileDirection);
						edit = AlignDrivewayEdit.Create(_scope, tilemap, tile.Coordinates, tileDirection);
					}
				}
				return new TileEditResult
				{
					resultCode = TileEditResultCode.Success,
					edit = edit
				};
			}
			if (!_behaviour.CanDrawRoadOn(orCreateTile.ContentType) || !_behaviour.CanDrawRoadOn(orCreateTile2.ContentType))
			{
				Log.Info("Cannot draw onto one of content type {0} or content type {1}", orCreateTile.ContentType, orCreateTile2.ContentType);
				return TileEditResult.InvalidTileCoordinate(originCoordinates);
			}
			if (orCreateTile.ContentType == TileContentType.Destination || orCreateTile2.ContentType == TileContentType.Destination)
			{
				Log.Info("Ignoring attempt to connect directly to destination tile.");
				return new TileEditResult
				{
					resultCode = TileEditResultCode.Success,
					edit = null
				};
			}
			if (Passage.DoesTileHavePassage(_city.Definition, tilemap, originCoordinates, RoadState.Mothballed) && orCreateTile.GetTwoLaneRoads(RoadState.Mothballed)[direction])
			{
				RestoreMothballedPassageEdit restoreMothballedPassageEdit = RestoreMothballedPassageEdit.Create(_scope, tilemap, originCoordinates, direction, _city);
				if (restoreMothballedPassageEdit == null)
				{
					return TileEditResult.InvalidTileCoordinate(originCoordinates);
				}
				return new TileEditResult
				{
					resultCode = TileEditResultCode.Success,
					edit = restoreMothballedPassageEdit
				};
			}
			if (orCreateTile.HasRailConnection && orCreateTile2.HasRailConnection)
			{
				return TileEditResult.CannotCreateCrossing(originCoordinates);
			}
			RoadTileNode node2 = new RoadTileNode(direction);
			RoadTileNode node3 = new RoadTileNode(TileUtilities.GetOppositeDirection(direction));
			TileEdit edit2 = null;
			if (orCreateTile.CanSetNodeState(node2, RoadState.Pending) && orCreateTile2.CanSetNodeState(node3, RoadState.Pending))
			{
				int concreteCostForConnection = _behaviour.GetConcreteCostForConnection(tilemap, originCoordinates, adjacentCoordinates);
				if (concreteCostForConnection == 0 || _upgradeDatabase.HasUpgradeAvailable(UpgradeType.Concrete, concreteCostForConnection) || orCreateTile.GetTwoLaneRoadStateInDirection(direction) == RoadState.Mothballed)
				{
					edit2 = AddRoadEdit.Create(_scope, tilemap, originCoordinates, direction, _city.Definition);
					return new TileEditResult
					{
						resultCode = TileEditResultCode.Success,
						edit = edit2
					};
				}
				Log.Info("Out of concrete.");
				return TileEditResult.NotEnoughConcrete(originCoordinates);
			}
			return new TileEditResult
			{
				resultCode = TileEditResultCode.EditAlreadyExists,
				edit = edit2
			};
		}

		private bool WouldConnectionPassPassageConstraints(Tile originTile, Tile destinationTile, Vector2Int originCoordinates, Vector2Int destinationCoordinates, TileDirection direction, ITilemap tilemap, UpgradeType upgradeType, Func<Vector2Int, bool> isOverObstruction)
		{
			bool flag = isOverObstruction(originCoordinates);
			bool flag2 = isOverObstruction(destinationCoordinates);
			if ((flag || flag2) && originTile.HasTwoLaneRoadInDirection(direction, RoadState.Mothballed))
			{
				return true;
			}
			if ((flag && originTile.GetTwoLaneRoadCount(RoadState.Live | RoadState.Pending) > 1) || (flag2 && destinationTile.GetTwoLaneRoadCount(RoadState.Live | RoadState.Pending) > 1))
			{
				Log.Info("Cannot build a {0} that would create an intersection.", upgradeType);
				return false;
			}
			if ((flag || flag2) && TileUtilities.IsDirectionDiagonal(direction))
			{
				Vector2Int adjacencyOffsetForDirection = TileUtilities.GetAdjacencyOffsetForDirection(direction);
				Vector2Int vector2Int = originCoordinates + Vector2Int.right * adjacencyOffsetForDirection.x;
				Vector2Int vector2Int2 = originCoordinates + Vector2Int.up * adjacencyOffsetForDirection.y;
				Tile tile = tilemap.GetTile(vector2Int);
				Tile tile2 = tilemap.GetTile(vector2Int2);
				TileDirection directionBetweenAdjacentCoordinates = TileUtilities.GetDirectionBetweenAdjacentCoordinates(vector2Int, vector2Int2);
				if (tile != null && tile2 != null && tile.HasTwoLaneRoadInDirection(directionBetweenAdjacentCoordinates, RoadState.ActiveOrPending))
				{
					Log.Info("Cannot build a diagonal {0} that would create a corner intersection.", upgradeType);
					return false;
				}
			}
			if (flag && originTile.GetTwoLaneRoadCount(RoadState.ActiveOrPending) == 0)
			{
				Log.Info("Cannot build a new {0} from an empty obstruction tile.", upgradeType);
				return false;
			}
			if (!flag && flag2 && destinationTile.GetTwoLaneRoadCount() == 0 && !_upgradeDatabase.HasUpgradeAvailable(upgradeType))
			{
				Log.Info("Out of {0}.", upgradeType);
				return false;
			}
			return true;
		}

		private static bool WouldDrivewayPassPassageConstraints(Tile houseTile, Tile drivewayTile, CityDefinition cityDefinition, out TileEditResult onFailure)
		{
			if (cityDefinition.TileIsOverWater(drivewayTile.Coordinates))
			{
				onFailure = TileEditResult.CannotConnectHouseToBridge(drivewayTile.Coordinates);
				return false;
			}
			if (cityDefinition.TileIsUnderAMountain(drivewayTile.Coordinates))
			{
				onFailure = TileEditResult.CannotConnectHouseToTunnel(drivewayTile.Coordinates);
				return false;
			}
			if (cityDefinition.TileIsOverRail(drivewayTile.Coordinates))
			{
				onFailure = TileEditResult.CannotConnectHouseToRail(drivewayTile.Coordinates);
				return false;
			}
			Vector2Int tileCoordinates = new Vector2Int(houseTile.Coordinates.x, drivewayTile.Coordinates.y);
			Vector2Int tileCoordinates2 = new Vector2Int(drivewayTile.Coordinates.x, houseTile.Coordinates.y);
			if (tileCoordinates.x != tileCoordinates2.x && tileCoordinates.y != tileCoordinates2.y && cityDefinition.TileIsOverRail(tileCoordinates) && cityDefinition.TileIsOverRail(tileCoordinates2))
			{
				onFailure = TileEditResult.CannotConnectHouseToRail(drivewayTile.Coordinates);
				return false;
			}
			onFailure = TileEditResult.Success;
			return true;
		}

		public TileEditResult ClearTile(ITilemap tilemap, Vector2Int coordinates, Tile.TileChangePermissions changePermissions = Tile.TileChangePermissions.Full)
		{
			return ClearTileExplicit(tilemap, coordinates, ClearTileOfType.Any, changePermissions);
		}

		private TileEditResultCode ResultCodeForType(ClearTileOfType editType, ClearTileOfType requestedType, TileEditResultCode successCode = TileEditResultCode.Success, TileEditResultCode mismatchedCode = TileEditResultCode.ClearForSpecificTypeNotNeeded)
		{
			if (requestedType != ClearTileOfType.Any && requestedType != editType)
			{
				return mismatchedCode;
			}
			return successCode;
		}

		private bool ShouldAttemptClearingType(ClearTileOfType clearingType, ClearTileOfType requestedType)
		{
			if (requestedType != ClearTileOfType.Any && requestedType != ClearTileOfType.Roads)
			{
				return clearingType == requestedType;
			}
			return true;
		}

		private bool CanClearMotorwayOnTile(Tile tile, ITilemap tilemap, Tile.TileChangePermissions changePermissions)
		{
			if (changePermissions != Tile.TileChangePermissions.RespectPermanence)
			{
				return true;
			}
			TileDirectionBitfield.Enumerator enumerator = tile.GetMotorwayRamps(RoadState.VisiblyActive).GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				int motorwayInDirection = tile.GetMotorwayInDirection(current, RoadState.VisiblyActive);
				if (motorwayInDirection != -1 && tilemap.GetMotorway(motorwayInDirection).IsPermanent)
				{
					return false;
				}
			}
			return true;
		}

		private bool CanClearTrafficLight(Tile tile, Tile.TileChangePermissions changePermissions)
		{
			if (changePermissions != Tile.TileChangePermissions.RespectPermanence)
			{
				return true;
			}
			return !tile.IsTrafficLightPermanent;
		}

		private bool CanClearRoundaboutOnTile(Tile tileToClear, Tile.TileChangePermissions changePermissions)
		{
			if (changePermissions != Tile.TileChangePermissions.RespectPermanence)
			{
				return true;
			}
			return !tileToClear.IsRoundaboutPermanent;
		}

		public TileEditResult ClearTileExplicit(ITilemap tilemap, Vector2Int coordinates, ClearTileOfType typeToClear, Tile.TileChangePermissions changePermissions = Tile.TileChangePermissions.Full)
		{
			Log.Info("Attempting to clear tile at {0} of type {1}.", coordinates, typeToClear);
			Tile tile = tilemap.GetTile(coordinates);
			if (tile == null || tile.IsEmpty())
			{
				Log.Info("No tile to clear.");
				return new TileEditResult
				{
					resultCode = ResultCodeForType(ClearTileOfType.Any, typeToClear)
				};
			}
			if (tile.ContentType == TileContentType.House || tile.ContentType == TileContentType.Destination)
			{
				return new TileEditResult
				{
					resultCode = ResultCodeForType(ClearTileOfType.Any, typeToClear)
				};
			}
			if (tile.HasTrafficLight && ShouldAttemptClearingType(ClearTileOfType.TrafficLight, typeToClear) && CanClearTrafficLight(tile, changePermissions))
			{
				return new TileEditResult
				{
					resultCode = ResultCodeForType(ClearTileOfType.TrafficLight, typeToClear),
					edit = RemoveTrafficLightEdit.Create(_scope, coordinates)
				};
			}
			if (tile.UnbuiltMotorwayId != -1 && ShouldAttemptClearingType(ClearTileOfType.UnbuiltMotorway, typeToClear))
			{
				return new TileEditResult
				{
					resultCode = ResultCodeForType(ClearTileOfType.UnbuiltMotorway, typeToClear),
					edit = RemoveUnbuiltMotorwaysEdit.Create(_scope, coordinates)
				};
			}
			if (tile.GetMotorwayRamps(RoadState.VisiblyActive).Count > 0 && ShouldAttemptClearingType(ClearTileOfType.BuiltMotorways, typeToClear) && CanClearMotorwayOnTile(tile, tilemap, changePermissions))
			{
				return new TileEditResult
				{
					resultCode = ResultCodeForType(ClearTileOfType.BuiltMotorways, typeToClear),
					edit = RemoveMotorwaysEdit.Create(_scope, coordinates)
				};
			}
			if (tile.IsCenterOfRoundabout && ShouldAttemptClearingType(ClearTileOfType.Roundabout, typeToClear) && CanClearRoundaboutOnTile(tile, changePermissions))
			{
				return new TileEditResult
				{
					resultCode = ResultCodeForType(ClearTileOfType.Roundabout, typeToClear),
					edit = RemoveRoundaboutEdit.Create(_scope, coordinates, tilemap, _city.Definition)
				};
			}
			if (Passage.DoesTileHavePassage(_city.Definition, tilemap, coordinates, RoadState.ActiveOrPending) && ShouldAttemptClearingType(ClearTileOfType.Passages, typeToClear) && CanClearAnyOfPassagesOnTile(coordinates, tilemap, changePermissions))
			{
				return new TileEditResult
				{
					resultCode = ResultCodeForType(ClearTileOfType.Passages, typeToClear),
					edit = RemovePassagesEdit.Create(_scope, tilemap, coordinates, _city.Definition, changePermissions)
				};
			}
			if (tile.IsDrivewayOnly)
			{
				return new TileEditResult
				{
					resultCode = TileEditResultCode.CannotClearTile
				};
			}
			bool flag = changePermissions == Tile.TileChangePermissions.RespectPermanence && tile.GetTwoLaneRoadCount() > 0 && !tile.AnyRoadHasPermanenceBelowValue(Fix64.One, RoadState.Active);
			bool flag2 = tile.HasTrafficLight || tile.GetMotorwayRamps(RoadState.VisiblyActive).Count > 0 || IsRoundaboutPermanentWithNoDeletableRoads(tile, tilemap);
			if (flag && !flag2)
			{
				return new TileEditResult
				{
					resultCode = TileEditResultCode.NoDeletableRoads,
					errorPosition = coordinates
				};
			}
			if (flag2 && (tile.GetTwoLaneRoadCount() == 0 || flag))
			{
				return new TileEditResult
				{
					resultCode = TileEditResultCode.NoDeletableUpgrade,
					errorPosition = coordinates
				};
			}
			return new TileEditResult
			{
				resultCode = ResultCodeForType(ClearTileOfType.Roads, typeToClear),
				edit = ClearTileEdit.Create(_scope, coordinates, tilemap, changePermissions)
			};
		}

		private bool IsRoundaboutPermanentWithNoDeletableRoads(Tile tile, ITilemap tilemap)
		{
			if (tile.IsCenterOfRoundabout && tile.IsRoundaboutPermanent)
			{
				TileDirection[] directions = TileUtilities.Directions;
				foreach (TileDirection direction in directions)
				{
					Tile tile2 = tilemap.GetTile(TileUtilities.GetAdjacentCoordinates(tile.Coordinates, direction));
					TileDirection oppositeDirection = TileUtilities.GetOppositeDirection(direction);
					if (tile2 != null && tile2.ContentType != TileContentType.House && tile2.ContentType != TileContentType.Destination && tile2.ContentType != TileContentType.Carpark && tile2.CanSetNodeState(new RoadTileNode(oppositeDirection), RoadState.Mothballed, Tile.TileChangePermissions.RespectPermanence))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		public TileEditResult AddUnbuiltMotorway(ITilemap tilemap, int motorwayId, int motorwayNumber, Vector2Int coordinates)
		{
			TileEdit tileEdit = AddUnbuiltMotorwayEdit.Create(_scope, coordinates, motorwayId, motorwayNumber);
			if (!_city.Definition.TileIsBuildable(coordinates) || _city.Definition.TileIsOverWater(coordinates) || _city.Definition.TileIsUnderAMountain(coordinates) || _city.Definition.TileIsOverRail(coordinates))
			{
				tileEdit.CanApplyToSimulation = false;
				return new TileEditResult
				{
					resultCode = TileEditResultCode.InvalidTileCoordinate,
					edit = tileEdit
				};
			}
			if (_upgradeDatabase.GetAvailableOrDraftUpgradeCount(UpgradeType.Motorway) < 1)
			{
				return TileEditResult.NotEnoughUpgrades;
			}
			Tile tile = tilemap.GetTile(coordinates);
			if (tile != null && !TileSupportsUnbuiltMotorway(tile, motorwayId))
			{
				tileEdit.CanApplyToSimulation = false;
				return new TileEditResult
				{
					resultCode = TileEditResultCode.InvalidTileCoordinate,
					edit = tileEdit
				};
			}
			tileEdit.CanApplyToSimulation = true;
			return new TileEditResult
			{
				resultCode = TileEditResultCode.Success,
				edit = tileEdit
			};
		}

		public TileEditResult AddMotorway(ITilemap tilemap, int motorwayId, int motorwayNumber, Vector2Int startCoordinates, TileDirection startDirection, Vector2Int endCoordinates, TileDirection endDirection, int replacedMotorwayId)
		{
			if (GameRules.GetMotorwayLength(startCoordinates, endCoordinates) < Rules.MinimumMotorwayLength)
			{
				return TileEditResult.MotorwayTooShort;
			}
			Motorway motorway = tilemap.GetMotorway(replacedMotorwayId);
			if (motorway != null && ((motorway.StartCoordinates.Equals(startCoordinates) && motorway.EndCoordinates.Equals(endCoordinates)) || (motorway.StartCoordinates.Equals(endCoordinates) && motorway.EndCoordinates.Equals(startCoordinates))))
			{
				return new TileEditResult
				{
					resultCode = TileEditResultCode.Success
				};
			}
			TileEdit tileEdit = AddMotorwayEdit.Create(_scope, motorwayId, motorwayNumber, startCoordinates, startDirection, endCoordinates, endDirection, replacedMotorwayId);
			CityDefinition definition = _city.Definition;
			if (!definition.TileIsBuildable(startCoordinates) || definition.TileIsOverWater(startCoordinates) || definition.TileIsUnderAMountain(startCoordinates) || definition.TileIsOverRail(startCoordinates) || !definition.TileIsBuildable(endCoordinates) || definition.TileIsOverWater(endCoordinates) || definition.TileIsUnderAMountain(endCoordinates) || definition.TileIsOverRail(endCoordinates))
			{
				tileEdit.CanApplyToSimulation = false;
				return new TileEditResult
				{
					resultCode = TileEditResultCode.InvalidTileCoordinate,
					edit = tileEdit
				};
			}
			foreach (Vector2Int item in Geometry.GetTileCoordinatesUnderLine(startCoordinates, endCoordinates))
			{
				if (definition.TileIsUnderAMountain(item))
				{
					bool flag = false;
					TileDirection[] nonDiagonalDirections = TileUtilities.NonDiagonalDirections;
					foreach (TileDirection direction in nonDiagonalDirections)
					{
						flag |= !definition.TileIsUnderAMountain(TileUtilities.GetAdjacentCoordinates(item, direction));
					}
					if (!flag)
					{
						tileEdit.CanApplyToSimulation = false;
						return new TileEditResult
						{
							resultCode = TileEditResultCode.MotorwayBlockedByMountain,
							edit = tileEdit
						};
					}
				}
			}
			int num = _behaviour.GetConcreteCostForMotorway(startCoordinates, endCoordinates);
			if (replacedMotorwayId != -1 && Diagnostics.Verify(motorway != null, "Non-existent motorway is being replaced."))
			{
				num -= motorway.ConcreteCost;
			}
			if (num > 0 && _upgradeDatabase.GetAvailableOrDraftUpgradeCount(UpgradeType.Concrete) < num && !_behaviour.HasUnlimitedOfUpgrade(UpgradeType.Concrete))
			{
				tileEdit.CanApplyToSimulation = false;
				return new TileEditResult
				{
					resultCode = TileEditResultCode.NotEnoughConcreteForMotorway,
					edit = tileEdit
				};
			}
			Tile tile = tilemap.GetTile(startCoordinates);
			if (tile != null && !TileSupportsMotorwayInDirection(tile, startDirection, motorwayId))
			{
				tileEdit.CanApplyToSimulation = false;
				return new TileEditResult
				{
					resultCode = TileEditResultCode.InvalidTileCoordinate,
					edit = tileEdit
				};
			}
			Tile tile2 = tilemap.GetTile(endCoordinates);
			if (tile2 != null && !TileSupportsMotorwayInDirection(tile2, endDirection, motorwayId))
			{
				tileEdit.CanApplyToSimulation = false;
				return new TileEditResult
				{
					resultCode = TileEditResultCode.InvalidTileCoordinate,
					edit = tileEdit
				};
			}
			return new TileEditResult
			{
				resultCode = TileEditResultCode.Success,
				edit = tileEdit
			};
		}

		public TileEditResult AddTrafficLight(ITilemap tilemap, Vector2Int coordinates)
		{
			Tile tile = tilemap.GetTile(coordinates);
			if (tile == null || !TileSupportsTrafficLight(tile) || tile.HasTrafficLight)
			{
				TileEdit tileEdit = AddTrafficLightEdit.Create(_scope, coordinates);
				tileEdit.CanApplyToSimulation = false;
				return new TileEditResult
				{
					resultCode = TileEditResultCode.InvalidTileCoordinate,
					edit = tileEdit
				};
			}
			if (_upgradeDatabase.GetAvailableOrDraftUpgradeCount(UpgradeType.TrafficLight) < 1)
			{
				return TileEditResult.NotEnoughUpgrades;
			}
			return new TileEditResult
			{
				resultCode = TileEditResultCode.Success,
				edit = AddTrafficLightEdit.Create(_scope, coordinates)
			};
		}

		public TileEditResult AddRoundabout(ITilemap tilemap, Vector2Int coordinates)
		{
			bool flag = true;
			TileEdit tileEdit = AddRoundaboutEdit.Create(_scope, coordinates, tilemap);
			if (_upgradeDatabase.GetAvailableOrDraftUpgradeCount(UpgradeType.Roundabout) < 1)
			{
				return TileEditResult.NotEnoughUpgrades;
			}
			Tile tile = tilemap.GetTile(coordinates);
			if (tile != null && (tile.HasRoundabout(RoadState.VisiblyActive) || tile.HasTrafficLight || tile.HasRailConnection || tile.ContentType == TileContentType.House || tile.UnbuiltMotorwayId != -1 || tile.GetMotorwayRamps(RoadState.VisiblyActive | RoadState.Mothballed).Bits != 0))
			{
				flag = false;
			}
			else
			{
				foreach (Vector2Int coordinatesOffset in Roundabout.GetCoordinatesOffsets())
				{
					RoadTileConnection connectionForCoordinatesOffset = Roundabout.GetConnectionForCoordinatesOffset(coordinatesOffset);
					if (!TileSupportsRoundabout(tilemap, coordinates + coordinatesOffset, connectionForCoordinatesOffset.input.direction, connectionForCoordinatesOffset.output.direction))
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				return new TileEditResult
				{
					resultCode = TileEditResultCode.Success,
					edit = tileEdit
				};
			}
			tileEdit.CanApplyToSimulation = false;
			return new TileEditResult
			{
				resultCode = TileEditResultCode.InvalidTileCoordinate,
				edit = tileEdit
			};
		}

		public static bool TileSupportsTrafficLight(Tile tile)
		{
			if (tile.GetTwoLaneRoadCount(RoadState.Live | RoadState.Pending, Tile.MotorwayInclusion.Include) >= 3 && tile.GetMotorwayRamps(RoadState.Active).Count == 0 && tile.UnbuiltMotorwayId == -1)
			{
				return !tile.HasRailConnection;
			}
			return false;
		}

		private bool CanClearAnyOfPassagesOnTile(Vector2Int clearingPosition, ITilemap tilemap, Tile.TileChangePermissions permissions)
		{
			if (permissions != Tile.TileChangePermissions.RespectPermanence)
			{
				return true;
			}
			List<Passage> passagesOnTile = Passage.GetPassagesOnTile(_scope, _city.Definition, tilemap, clearingPosition, RoadState.Active);
			try
			{
				foreach (Passage item in passagesOnTile)
				{
					if (item.CanBeCleared(tilemap, permissions))
					{
						return true;
					}
				}
				return false;
			}
			finally
			{
				foreach (Passage item2 in passagesOnTile)
				{
					_scope.Release(item2);
				}
			}
		}

		public static bool TileSupportsMotorwayInDirection(Tile tile, TileDirection direction, int motorwayId)
		{
			if (tile.HasRoundabout(RoadState.Live | RoadState.Planned))
			{
				return false;
			}
			if (tile.HasTrafficLight)
			{
				return false;
			}
			return tile.CanSetNodeState(new RoadTileNode(direction, RoadType.Motorway, motorwayId), RoadState.Planned);
		}

		public static bool TileSupportsMotorwayInAnyDirection(Tile tile, int motorwayId)
		{
			for (int i = 0; i < 8; i++)
			{
				if (TileSupportsMotorwayInDirection(tile, (TileDirection)i, motorwayId))
				{
					return true;
				}
			}
			return false;
		}

		public static bool TileSupportsUnbuiltMotorway(Tile tile, int motorwayId)
		{
			if (tile.UnbuiltMotorwayId != -1 && tile.UnbuiltMotorwayId != motorwayId)
			{
				return false;
			}
			for (int i = 0; i < 8; i++)
			{
				if (TileSupportsMotorwayInDirection(tile, (TileDirection)i, motorwayId))
				{
					return true;
				}
			}
			return false;
		}

		private bool TileSupportsRoundabout(ITilemap tilemap, Vector2Int coordinates, TileDirection roundaboutInput, TileDirection roundaboutOutput)
		{
			if (!_city.Definition.TileIsBuildable(coordinates) || _city.Definition.TileIsOverWater(coordinates) || _city.Definition.TileIsUnderAMountain(coordinates) || _city.Definition.TileIsOverRail(coordinates))
			{
				return false;
			}
			Tile tile = tilemap.GetTile(coordinates);
			if (tile != null)
			{
				if (!_behaviour.CanDrawRoadOn(tile.ContentType))
				{
					return false;
				}
				if (tile.UnbuiltMotorwayId != -1)
				{
					return false;
				}
				if (!tile.CanSetRoundaboutState(roundaboutInput, roundaboutOutput, RoadState.Planned))
				{
					return false;
				}
				TileDirectionBitfield invalidExitsForConnection = Roundabout.GetInvalidExitsForConnection(roundaboutInput, roundaboutOutput);
				TileDirectionBitfield.Enumerator enumerator = tile.GetTwoLaneRoads(RoadState.ActiveOrPending).GetEnumerator();
				while (enumerator.MoveNext())
				{
					TileDirection current = enumerator.Current;
					if (invalidExitsForConnection[current])
					{
						Tile tile2 = tilemap.GetTile(TileUtilities.GetAdjacentCoordinates(coordinates, current));
						if (Diagnostics.Verify(tile2 != null, "Somehow {0} is connected to a null tile.", tile) && (tile2.ContentType == TileContentType.House || tile2.ContentType == TileContentType.Carpark))
						{
							return false;
						}
					}
				}
			}
			return true;
		}
	}
}
