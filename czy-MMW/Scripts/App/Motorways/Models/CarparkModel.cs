using System.Collections.Generic;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Processes;
using Motorways.Utility;
using Server;
using UnityEngine;

namespace Motorways.Models
{
	public class CarparkModel : Model<EmptyModelFrame, CarparkModel.IObserver>
	{
		[Serializable(1)]
		public class ParkingSpace : IReusable
		{
			public RoadChunkModel parkRoadChunk;

			public RoadChunkModel innerRoadChunk;

			public RoadChunkModel outerRoadChunk;

			public VehicleModel vehicle;

			public Fix64 timeVehicleParked;

			public void Reset()
			{
				parkRoadChunk = null;
				innerRoadChunk = null;
				outerRoadChunk = null;
				vehicle = null;
				timeVehicleParked = -Fix64.One;
			}
		}

		public interface IObserver
		{
			void OnCarparkRemoved(CarparkModel carparkModel);

			void OnDestinationAdded();
		}

		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("CarparkModel");

		[Dependency]
		private CityPlanModel _cityPlanModel;

		public Vector2Int origin;

		public TileDirection carparkSide;

		public Vector2Int footprint;

		public bool entranceAtTopLeft;

		public bool entranceAtBottomRight;

		public bool supportsBoats;

		public List<Vector2Int> carparkTiles;

		public List<Vector2Int> destinationOffsets;

		public List<LaneModel> entranceLanes = new List<LaneModel>();

		public List<ParkingSpace> spaces = new List<ParkingSpace>();

		public List<VehicleModel> vehiclesEntering = new List<VehicleModel>();

		public List<VehicleModel> vehiclesDrivingThrough = new List<VehicleModel>();

		public List<DestinationModel> destinations = new List<DestinationModel>();

		[Dependency]
		private IScope _scope;

		[Dependency]
		private ISimulation _simulation;

		[Dependency]
		private TilemapModel _tilemap;

		[Serialize(true, null)]
		public List<TileModel> TileModels { get; private set; }

		public Vector2Int TopLeftWorldCoordinate => origin + new Vector2Int(0, footprint.y - 1);

		public Vector2Int TopLeftCarparkTileCoordinate
		{
			get
			{
				if (Alignment == TileAlignment.Horizontal)
				{
					if (carparkTiles[0].y == 0)
					{
						return origin;
					}
					return TopLeftWorldCoordinate;
				}
				if (carparkTiles[0].x == 0)
				{
					return TopLeftWorldCoordinate;
				}
				return TopLeftWorldCoordinate + new Vector2Int(footprint.x - 1, 0);
			}
		}

		public Vector2Int BottomRightCarparkTileCoordinate
		{
			get
			{
				if (Alignment == TileAlignment.Horizontal)
				{
					if (carparkTiles[0].y == 0)
					{
						return origin + new Vector2Int(footprint.x - 1, 0);
					}
					return origin + new Vector2Int(footprint.x - 1, footprint.y - 1);
				}
				if (carparkTiles[0].x == 0)
				{
					return origin;
				}
				return origin + new Vector2Int(footprint.x - 1, 0);
			}
		}

		public TileAlignment Alignment
		{
			get
			{
				if (carparkSide != TileDirection.North && carparkSide != TileDirection.South)
				{
					return TileAlignment.Vertical;
				}
				return TileAlignment.Horizontal;
			}
		}

		public bool SupportsTwoDestinations
		{
			get
			{
				if (!(footprint == BuildingSpawningProcess.VerticalDoubleCarparkFootprint) && !(footprint == BuildingSpawningProcess.HorizontalDoubleCarparkFootprint))
				{
					return footprint == BuildingSpawningProcess.HorizontalDoubleCarparkBoatFootprint;
				}
				return true;
			}
		}

		public int ActiveDestinationCount
		{
			get
			{
				int num = 0;
				foreach (DestinationModel destination in destinations)
				{
					if (destination.isActive)
					{
						num++;
					}
				}
				return num;
			}
		}

		public TileDirection TopLeftDrivewayDirection
		{
			get
			{
				if (Alignment != TileAlignment.Horizontal)
				{
					return TileDirection.North;
				}
				return TileDirection.West;
			}
		}

		public TileDirection BottomRightDrivewayDirection
		{
			get
			{
				if (Alignment != TileAlignment.Horizontal)
				{
					return TileDirection.South;
				}
				return TileDirection.East;
			}
		}

		public Vector2Int TopLeftDrivewayTileCoordinates
		{
			get
			{
				if (Diagnostics.Verify(entranceAtTopLeft, "Trying to get the driveway for a position we don't have!"))
				{
					return TileUtilities.GetAdjacentCoordinates(TopLeftCarparkTileCoordinate, TopLeftDrivewayDirection);
				}
				return Vector2Int.zero;
			}
		}

		public Vector2Int BottomRightDrivewayTileCoordinates
		{
			get
			{
				if (Diagnostics.Verify(entranceAtBottomRight, "Trying to get the driveway for a position we don't have!"))
				{
					Vector2Int adjacencyOffsetForDirection = TileUtilities.GetAdjacencyOffsetForDirection(BottomRightDrivewayDirection);
					if (Alignment == TileAlignment.Horizontal)
					{
						return TopLeftCarparkTileCoordinate + new Vector2Int(footprint.x - 1, 0) + adjacencyOffsetForDirection;
					}
					return TopLeftCarparkTileCoordinate + new Vector2Int(0, -(footprint.y - 1)) + adjacencyOffsetForDirection;
				}
				return Vector2Int.zero;
			}
		}

		public static List<Vector2Int> GenerateCarparkPositions(Vector2Int destinationFootprint, TileDirection carparkSide)
		{
			List<Vector2Int> list = new List<Vector2Int>();
			int num = ((carparkSide == TileDirection.North || carparkSide == TileDirection.South) ? 1 : 2);
			int num2 = ((num == 1) ? destinationFootprint.x : destinationFootprint.y);
			TileDirection direction = ((num == 1) ? TileDirection.East : TileDirection.South);
			Vector2Int vector2Int = default(Vector2Int);
			if (num == 1)
			{
				if (carparkSide == TileDirection.North)
				{
					vector2Int.y = destinationFootprint.y - 1;
				}
			}
			else
			{
				vector2Int.y = destinationFootprint.y - 1;
				if (carparkSide == TileDirection.East)
				{
					vector2Int.x = destinationFootprint.x - 1;
				}
			}
			for (int i = 0; i < num2; i++)
			{
				Vector2Int item = vector2Int + TileUtilities.GetAdjacencyOffsetForDirection(direction) * i;
				list.Add(item);
			}
			return list;
		}

		public static List<Vector2Int> GenerateDestinationPositions(Vector2Int destinationFootprint, TileDirection carparkSide)
		{
			return GenerateDestinationPositions((destinationFootprint.x <= 3 && destinationFootprint.y <= 3) ? 1 : 2, carparkSide);
		}

		public static List<Vector2Int> GenerateDestinationPositions(int destinationCount, TileDirection carparkSide)
		{
			TileAlignment tileAlignment = ((carparkSide == TileDirection.North || carparkSide == TileDirection.South) ? TileAlignment.Horizontal : TileAlignment.Vertical);
			Vector2Int vector2Int = ((tileAlignment == TileAlignment.Horizontal) ? new Vector2Int(2, 0) : new Vector2Int(0, 2));
			Vector2Int vector2Int2 = default(Vector2Int);
			switch (carparkSide)
			{
			case TileDirection.South:
				vector2Int2.y = 1;
				break;
			case TileDirection.West:
				vector2Int2.x = 1;
				break;
			}
			List<Vector2Int> list = new List<Vector2Int>();
			for (int i = 0; i < destinationCount; i++)
			{
				list.Add(vector2Int2 + vector2Int * i);
			}
			if (tileAlignment == TileAlignment.Vertical)
			{
				list.Reverse();
			}
			return list;
		}

		public bool Initialize(CarparkEntrance entrances, CarparkPreference carparkPreference, BuildingPlacer.Placement placement)
		{
			origin = placement.coordinates;
			carparkSide = placement.layout.carparkSide;
			footprint = placement.layout.footprint;
			entranceAtTopLeft = (entrances & CarparkEntrance.TopLeft) == CarparkEntrance.TopLeft;
			entranceAtBottomRight = (entrances & CarparkEntrance.BottomRight) == CarparkEntrance.BottomRight;
			supportsBoats = carparkPreference == CarparkPreference.BoatTerminal || carparkPreference == CarparkPreference.JoinBoatTerminal;
			carparkTiles = GenerateCarparkPositions(footprint, placement.layout.carparkSide);
			destinationOffsets = GenerateDestinationPositions(footprint, placement.layout.carparkSide);
			if (!Diagnostics.Verify(carparkTiles.Count >= 2, $"CarparkModel must have at least 2 tiles, not {carparkTiles.Count}."))
			{
				return false;
			}
			int num = ((Alignment == TileAlignment.Horizontal) ? footprint.x : footprint.y);
			if (!Diagnostics.Verify(num >= 2, "CarparkModel must be at least 2 tiles in length, not {0}.", num))
			{
				return false;
			}
			foreach (Vector2Int destinationOffset in destinationOffsets)
			{
				Vector2Int vector2Int = origin + destinationOffset;
				for (int i = 0; i < 2; i++)
				{
					for (int j = 0; j < 2; j++)
					{
						Vector2Int coordinates = vector2Int + new Vector2Int(i, j);
						TileModel orCreateTileModel = _tilemap.GetOrCreateTileModel(coordinates);
						orCreateTileModel.Tile.SetContentType(TileContentType.Destination, null);
						if (orCreateTileModel.RailTileModel != null)
						{
							orCreateTileModel.RailTileModel.carpark = this;
						}
					}
				}
			}
			foreach (Vector2Int boatTerminalTile in placement.layout.boatTerminalTiles)
			{
				Vector2Int coordinates2 = boatTerminalTile + origin;
				TileModel orCreateTileModel2 = _tilemap.GetOrCreateTileModel(coordinates2);
				orCreateTileModel2.Tile.SetContentType(TileContentType.BoatTerminal, null);
				TileDirection[] diagonalDirections = TileUtilities.DiagonalDirections;
				foreach (TileDirection directionToCheck in diagonalDirections)
				{
					TileModel adjacentTileModelInDirection = orCreateTileModel2.GetAdjacentTileModelInDirection(directionToCheck);
					if (adjacentTileModelInDirection != null)
					{
						Tile tile = adjacentTileModelInDirection.Tile;
						if (tile != null && tile.HasBoatPathConnection)
						{
							adjacentTileModelInDirection.BoatPathTileModel.carpark = this;
						}
					}
				}
			}
			Vector2Int vector2Int2 = new Vector2Int(int.MaxValue, int.MinValue);
			Vector2Int coordinates3 = new Vector2Int(int.MinValue, int.MaxValue);
			List<TileModel> list = new List<TileModel>();
			for (int l = 0; l < carparkTiles.Count; l++)
			{
				Vector2Int vector2Int3 = carparkTiles[l];
				Vector2Int vector2Int4 = origin + vector2Int3;
				TileModel orCreateTileModel3 = _tilemap.GetOrCreateTileModel(vector2Int4);
				Tile tile2 = orCreateTileModel3.Tile;
				if (Diagnostics.Verify(tile2.CanSetContentType(TileContentType.Carpark), $"Unable to set TileContentType.Carpark on one of a carpark's tiles: already set to {tile2.ContentType}."))
				{
					tile2.SetContentType(TileContentType.Carpark, this);
				}
				list.Add(orCreateTileModel3);
				TileDirection tileDirection = TileDirection.None;
				if (l == 0 && entranceAtTopLeft)
				{
					tileDirection = TopLeftDrivewayDirection;
				}
				else if (l == num - 1 && entranceAtBottomRight)
				{
					tileDirection = BottomRightDrivewayDirection;
				}
				if (tileDirection != TileDirection.None)
				{
					tile2.SetNodeState(new RoadTileNode(tileDirection), RoadState.Pending);
					Tile orCreateTile = _tilemap.GetOrCreateTile(TileUtilities.GetAdjacentCoordinates(vector2Int4, tileDirection));
					TileDirection oppositeDirection = TileUtilities.GetOppositeDirection(tileDirection);
					orCreateTile.SetNodeState(new RoadTileNode(oppositeDirection), RoadState.Pending);
					orCreateTile.SetNodeImmutability(oppositeDirection, isImmutable: true);
				}
				if (vector2Int4.x < vector2Int2.x || vector2Int4.y > vector2Int2.y)
				{
					vector2Int2 = vector2Int4;
				}
				if (vector2Int4.x > coordinates3.x || vector2Int4.y < coordinates3.y)
				{
					coordinates3 = vector2Int4;
				}
			}
			TileModels = list;
			Fix64 fix = TilemapModel.TileWidth / (Fix64)3L;
			_ = fix * (Fix64)0.5f;
			Fix64 fix2 = (Fix64)0.25f;
			Vector2Fixed worldPositionForCoordinates = TilemapModel.GetWorldPositionForCoordinates(TopLeftCarparkTileCoordinate);
			TileDirection tileDirection2 = ((Alignment == TileAlignment.Horizontal) ? TileDirection.East : TileDirection.South);
			Vector2Int adjacencyOffsetForDirection = TileUtilities.GetAdjacencyOffsetForDirection(TileUtilities.GetRotatedDirection(tileDirection2, 2));
			Vector2Int adjacencyOffsetForDirection2 = TileUtilities.GetAdjacencyOffsetForDirection(tileDirection2);
			Vector2Int adjacencyOffsetForDirection3 = TileUtilities.GetAdjacencyOffsetForDirection(TileUtilities.GetRotatedDirection(tileDirection2, -1));
			Vector2Fixed vector2Fixed = new Vector2Fixed(adjacencyOffsetForDirection3) * fix;
			Fix64 fix3 = (Fix64)0.3f;
			Vector2Fixed vector2Fixed2 = -new Vector2Fixed(adjacencyOffsetForDirection3) * fix2;
			Vector2Fixed vector2Fixed3 = new Vector2Fixed(adjacencyOffsetForDirection2) * fix * (Fix64)0.2f;
			Vector2Fixed vector2Fixed4 = new Vector2Fixed(adjacencyOffsetForDirection2) * fix * (Fix64)0.8f;
			Fix64 fix4 = fix * Fix64Consts.OneHalf;
			if (carparkSide == TileDirection.North || carparkSide == TileDirection.East)
			{
				fix4 += (Fix64)0.1f;
			}
			else
			{
				fix4 -= (Fix64)0.1f;
			}
			Vector2Fixed vector2Fixed5 = worldPositionForCoordinates + new Vector2Fixed(adjacencyOffsetForDirection) * fix4;
			TileDirection oppositeDirection2 = TileUtilities.GetOppositeDirection(tileDirection2);
			TileDirection rotatedDirection = TileUtilities.GetRotatedDirection(tileDirection2, -1);
			TileDirection oppositeDirection3 = TileUtilities.GetOppositeDirection(rotatedDirection);
			Vector2Fixed normalized = new Vector2Fixed(TileUtilities.DirectionToTileAdjacencyOffset[(int)oppositeDirection3]).normalized;
			Vector2Fixed normalized2 = new Vector2Fixed(TileUtilities.DirectionToTileAdjacencyOffset[(int)TileUtilities.GetRotatedDirection(oppositeDirection3, 2)]).normalized;
			int num2 = (num - 1) * 3;
			Spline.BezierSplineFixed bezierSplineFixed;
			for (int m = 0; m < num2; m++)
			{
				Vector2Fixed vector2Fixed6 = vector2Fixed5 + new Vector2Fixed(adjacencyOffsetForDirection2) * fix * (Fix64)m;
				Vector2Fixed vector2Fixed7 = vector2Fixed6 + vector2Fixed2 - vector2Fixed3;
				Vector2Fixed vector2Fixed8 = vector2Fixed6 + vector2Fixed2 + vector2Fixed4;
				Vector2Fixed vector2Fixed9 = vector2Fixed6 + vector2Fixed;
				Vector2Fixed vector2Fixed10 = vector2Fixed9 - vector2Fixed2 + vector2Fixed3;
				Vector2Fixed vector2Fixed11 = vector2Fixed9 - vector2Fixed2 - vector2Fixed4;
				vector2Fixed6 += vector2Fixed * fix3;
				vector2Fixed9 -= vector2Fixed * fix3;
				bool flag = false;
				bool flag2 = false;
				Vector2Fixed vector2Fixed12 = new Vector2Fixed(adjacencyOffsetForDirection2);
				Vector2Fixed vector2Fixed13 = new Vector2Fixed(adjacencyOffsetForDirection2);
				if (m == 0)
				{
					flag = true;
					vector2Fixed7 -= new Vector2Fixed(adjacencyOffsetForDirection) * fix2;
					vector2Fixed13 = -normalized2;
				}
				else if (m == num2 - 1)
				{
					flag2 = true;
					vector2Fixed10 += new Vector2Fixed(adjacencyOffsetForDirection) * fix2;
					vector2Fixed12 = -normalized2;
				}
				ParkingSpace parkingSpace = _scope.Get<ParkingSpace>();
				parkingSpace.outerRoadChunk = _scope.Get<RoadChunkModel>();
				Fix64 fix5 = (Fix64)0.2;
				Fix64 fix6 = (Fix64)0.2;
				Fix64 fix7 = (Fix64)0.2;
				Fix64 fix8 = (Fix64)0.3;
				bezierSplineFixed = new Spline.BezierSplineFixed(vector2Fixed7, vector2Fixed7 + vector2Fixed13 * fix5, vector2Fixed6 + normalized * fix6, vector2Fixed6);
				LaneModel outboundLane = parkingSpace.outerRoadChunk.AddBespokeLane(new RoadTileConnection(new RoadTileNode(oppositeDirection2, RoadType.Carpark), new RoadTileNode(rotatedDirection, RoadType.ParkingSpace)), bezierSplineFixed.Rasterize(10), RoadState.Active, isCarparkLane: true);
				bezierSplineFixed = new Spline.BezierSplineFixed(vector2Fixed6, vector2Fixed6 + normalized * fix8, vector2Fixed8 - new Vector2Fixed(adjacencyOffsetForDirection2) * fix7, vector2Fixed8);
				parkingSpace.outerRoadChunk.AddBespokeLane(new RoadTileConnection(new RoadTileNode(rotatedDirection, RoadType.ParkingSpace), new RoadTileNode(tileDirection2, RoadType.Carpark)), bezierSplineFixed.Rasterize(10), RoadState.Active, isCarparkLane: true);
				List<Vector2Fixed> path;
				if (!flag)
				{
					path = new List<Vector2Fixed> { vector2Fixed7, vector2Fixed8 };
				}
				else
				{
					bezierSplineFixed = new Spline.BezierSplineFixed(vector2Fixed7, vector2Fixed7 - normalized2 * fix8, vector2Fixed8 - new Vector2Fixed(adjacencyOffsetForDirection2) * fix7, vector2Fixed8);
					path = bezierSplineFixed.Rasterize(10);
				}
				LaneModel outboundLane2 = parkingSpace.outerRoadChunk.AddBespokeLane(new RoadTileConnection(new RoadTileNode(oppositeDirection2, RoadType.Carpark), new RoadTileNode(tileDirection2, RoadType.Carpark)), path, RoadState.Active, isCarparkLane: true);
				parkingSpace.innerRoadChunk = _scope.Get<RoadChunkModel>();
				bezierSplineFixed = new Spline.BezierSplineFixed(vector2Fixed10, vector2Fixed10 - vector2Fixed12 * fix5, vector2Fixed9 - normalized * fix6, vector2Fixed9);
				parkingSpace.innerRoadChunk.AddBespokeLane(new RoadTileConnection(new RoadTileNode(tileDirection2, RoadType.Carpark), new RoadTileNode(oppositeDirection3, RoadType.ParkingSpace)), bezierSplineFixed.Rasterize(10), RoadState.Active, isCarparkLane: true);
				bezierSplineFixed = new Spline.BezierSplineFixed(vector2Fixed9, vector2Fixed9 - normalized * fix8, vector2Fixed11 + new Vector2Fixed(adjacencyOffsetForDirection2) * fix7, vector2Fixed11);
				LaneModel inboundLane = parkingSpace.innerRoadChunk.AddBespokeLane(new RoadTileConnection(new RoadTileNode(oppositeDirection3, RoadType.ParkingSpace), new RoadTileNode(oppositeDirection2, RoadType.Carpark)), bezierSplineFixed.Rasterize(10), RoadState.Active, isCarparkLane: true);
				if (!flag2)
				{
					path = new List<Vector2Fixed> { vector2Fixed10, vector2Fixed11 };
				}
				else
				{
					bezierSplineFixed = new Spline.BezierSplineFixed(vector2Fixed10, vector2Fixed10 + normalized2 * fix8, vector2Fixed11 + new Vector2Fixed(adjacencyOffsetForDirection2) * fix7, vector2Fixed11);
					path = bezierSplineFixed.Rasterize(10);
				}
				LaneModel inboundLane2 = parkingSpace.innerRoadChunk.AddBespokeLane(new RoadTileConnection(new RoadTileNode(tileDirection2, RoadType.Carpark), new RoadTileNode(oppositeDirection2, RoadType.Carpark)), path, RoadState.Active, isCarparkLane: true);
				parkingSpace.parkRoadChunk = _scope.Get<RoadChunkModel>();
				path = new List<Vector2Fixed> { vector2Fixed6, vector2Fixed9 };
				LaneModel laneModel = parkingSpace.parkRoadChunk.AddBespokeLane(new RoadTileConnection(new RoadTileNode(oppositeDirection3, RoadType.ParkingSpace), new RoadTileNode(rotatedDirection, RoadType.ParkingSpace)), path, RoadState.Active, isCarparkLane: true);
				parkingSpace.outerRoadChunk.ConnectOutboundLane(laneModel);
				parkingSpace.innerRoadChunk.ConnectInboundLane(laneModel);
				path = new List<Vector2Fixed> { vector2Fixed9, vector2Fixed6 };
				LaneModel laneModel2 = parkingSpace.parkRoadChunk.AddBespokeLane(new RoadTileConnection(new RoadTileNode(rotatedDirection, RoadType.ParkingSpace), new RoadTileNode(oppositeDirection3, RoadType.ParkingSpace)), path, RoadState.Active, isCarparkLane: true);
				parkingSpace.outerRoadChunk.ConnectInboundLane(laneModel2);
				parkingSpace.innerRoadChunk.ConnectOutboundLane(laneModel2);
				if (m > 0)
				{
					ParkingSpace parkingSpace2 = spaces[m - 1];
					parkingSpace2.innerRoadChunk.ConnectInboundLane(inboundLane);
					parkingSpace2.innerRoadChunk.ConnectInboundLane(inboundLane2);
					parkingSpace2.outerRoadChunk.ConnectOutboundLane(outboundLane);
					parkingSpace2.outerRoadChunk.ConnectOutboundLane(outboundLane2);
				}
				spaces.Add(parkingSpace);
				_simulation.AddModel(parkingSpace.outerRoadChunk);
				_simulation.AddModel(parkingSpace.innerRoadChunk);
				_simulation.AddModel(parkingSpace.parkRoadChunk);
			}
			Fix64 fix9 = (Fix64)0.2;
			Fix64 fix10 = (Fix64)0.2;
			Fix64 fix11 = (Fix64)0.1;
			Fix64 fix12 = (Fix64)1.0;
			Fix64 fix13 = (Fix64)0.75;
			Fix64 fix14 = (Fix64)0.7;
			Fix64 fix15 = (Fix64)0.3;
			TileModel tileModel = _tilemap.GetTileModel(TopLeftCarparkTileCoordinate);
			if (tileModel == null)
			{
				Log.Error("Top left tile is null!! Coordinates: {0}", TopLeftCarparkTileCoordinate);
				return false;
			}
			Vector2Fixed vector2Fixed14 = new Vector2Fixed(TileUtilities.DirectionToTileAdjacencyOffset[(int)oppositeDirection2]);
			Vector2Fixed vector2Fixed15 = new Vector2Fixed(vector2Fixed14.y, -vector2Fixed14.x);
			Vector2Fixed vector2Fixed16 = vector2Fixed14 - vector2Fixed15 * RoadTileAtlas.LaneOffsetScale + tileModel.WorldPosition;
			Vector2Fixed vector2Fixed17 = vector2Fixed14 + vector2Fixed15 * RoadTileAtlas.LaneOffsetScale + tileModel.WorldPosition;
			ParkingSpace parkingSpace3 = spaces[0];
			Vector2Fixed startPosition = parkingSpace3.outerRoadChunk.GetLanesEnteringFromDirection(oppositeDirection2)[0].StartPosition;
			Vector2Fixed endPosition = parkingSpace3.innerRoadChunk.GetLanesExitingInDirection(oppositeDirection2)[0].EndPosition;
			bezierSplineFixed = new Spline.BezierSplineFixed(endPosition, endPosition - new Vector2Fixed(adjacencyOffsetForDirection2) * fix15, startPosition + normalized2 * fix14, startPosition);
			LaneModel laneModel3 = tileModel.roadChunk.AddBespokeLane(new RoadTileConnection(new RoadTileNode(tileDirection2, RoadType.Carpark), new RoadTileNode(tileDirection2, RoadType.Carpark)), bezierSplineFixed.Rasterize(10), RoadState.Active, isCarparkLane: true);
			parkingSpace3.innerRoadChunk.ConnectOutboundLane(laneModel3);
			parkingSpace3.outerRoadChunk.ConnectInboundLane(laneModel3);
			if (entranceAtTopLeft)
			{
				bezierSplineFixed = new Spline.BezierSplineFixed(vector2Fixed16, vector2Fixed16 + new Vector2Fixed(adjacencyOffsetForDirection2) * fix9, startPosition + normalized2 * fix11, startPosition);
				LaneModel laneModel4 = tileModel.roadChunk.AddBespokeLane(new RoadTileConnection(new RoadTileNode(oppositeDirection2), new RoadTileNode(tileDirection2, RoadType.Carpark)), bezierSplineFixed.Rasterize(10), RoadState.Active, isCarparkLane: true, isEndpointLane: true);
				parkingSpace3.outerRoadChunk.ConnectInboundLane(laneModel4);
				entranceLanes.Add(laneModel4);
				_cityPlanModel.destinationLanes.Add(laneModel4);
				bezierSplineFixed = new Spline.BezierSplineFixed(endPosition, endPosition - new Vector2Fixed(adjacencyOffsetForDirection2) * fix12, vector2Fixed17 + new Vector2Fixed(adjacencyOffsetForDirection2) * fix13, vector2Fixed17);
				LaneModel outboundLane3 = tileModel.roadChunk.AddBespokeLane(new RoadTileConnection(new RoadTileNode(tileDirection2, RoadType.Carpark), new RoadTileNode(oppositeDirection2)), bezierSplineFixed.Rasterize(10), RoadState.Active, isCarparkLane: true);
				parkingSpace3.innerRoadChunk.ConnectOutboundLane(outboundLane3);
			}
			TileModel tileModel2 = _tilemap.GetTileModel(coordinates3);
			Vector2Fixed vector2Fixed18 = new Vector2Fixed(TileUtilities.DirectionToTileAdjacencyOffset[(int)tileDirection2]);
			Vector2Fixed vector2Fixed19 = new Vector2Fixed(vector2Fixed18.y, -vector2Fixed18.x);
			Vector2Fixed vector2Fixed20 = vector2Fixed18 - vector2Fixed19 * RoadTileAtlas.LaneOffsetScale + tileModel2.WorldPosition;
			Vector2Fixed vector2Fixed21 = vector2Fixed18 + vector2Fixed19 * RoadTileAtlas.LaneOffsetScale + tileModel2.WorldPosition;
			ParkingSpace parkingSpace4 = spaces[spaces.Count - 1];
			Vector2Fixed startPosition2 = parkingSpace4.innerRoadChunk.GetLanesEnteringFromDirection(tileDirection2)[0].StartPosition;
			Vector2Fixed endPosition2 = parkingSpace4.outerRoadChunk.GetLanesExitingInDirection(tileDirection2)[0].EndPosition;
			bezierSplineFixed = new Spline.BezierSplineFixed(endPosition2, endPosition2 + new Vector2Fixed(adjacencyOffsetForDirection2) * fix15, startPosition2 - normalized2 * fix14, startPosition2);
			LaneModel laneModel5 = tileModel2.roadChunk.AddBespokeLane(new RoadTileConnection(new RoadTileNode(oppositeDirection2, RoadType.Carpark), new RoadTileNode(oppositeDirection2, RoadType.Carpark)), bezierSplineFixed.Rasterize(10), RoadState.Active, isCarparkLane: true);
			parkingSpace4.outerRoadChunk.ConnectOutboundLane(laneModel5);
			parkingSpace4.innerRoadChunk.ConnectInboundLane(laneModel5);
			if (entranceAtBottomRight)
			{
				bezierSplineFixed = new Spline.BezierSplineFixed(vector2Fixed20, vector2Fixed20 - new Vector2Fixed(adjacencyOffsetForDirection2) * fix10, startPosition2 - normalized2 * fix9, startPosition2);
				LaneModel laneModel6 = tileModel2.roadChunk.AddBespokeLane(new RoadTileConnection(new RoadTileNode(tileDirection2), new RoadTileNode(oppositeDirection2, RoadType.Carpark)), bezierSplineFixed.Rasterize(10), RoadState.Active, isCarparkLane: true, isEndpointLane: true);
				parkingSpace4.innerRoadChunk.ConnectInboundLane(laneModel6);
				entranceLanes.Add(laneModel6);
				_cityPlanModel.destinationLanes.Add(laneModel6);
				bezierSplineFixed = new Spline.BezierSplineFixed(endPosition2, endPosition2 + new Vector2Fixed(adjacencyOffsetForDirection2) * fix12, vector2Fixed21 - new Vector2Fixed(adjacencyOffsetForDirection2) * fix13, vector2Fixed21);
				LaneModel outboundLane4 = tileModel2.roadChunk.AddBespokeLane(new RoadTileConnection(new RoadTileNode(oppositeDirection2, RoadType.Carpark), new RoadTileNode(tileDirection2)), bezierSplineFixed.Rasterize(10), RoadState.Active, isCarparkLane: true);
				parkingSpace4.outerRoadChunk.ConnectOutboundLane(outboundLane4);
			}
			return true;
		}

		public void AddDestination(DestinationModel model)
		{
			destinations.Add(model);
			ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnDestinationAdded();
			}
		}

		public LaneModel GetClosestEntranceLane(Vector2Fixed worldPosition)
		{
			if (!Diagnostics.Verify(entranceLanes.Count > 0, "Cannot get distance from a carpark with no entrances."))
			{
				return null;
			}
			LaneModel result = entranceLanes[0];
			Fix64 fix = (entranceLanes[0].StartPosition - worldPosition).sqrMagnitude;
			for (int i = 1; i < entranceLanes.Count; i++)
			{
				Fix64 sqrMagnitude = (entranceLanes[i].StartPosition - worldPosition).sqrMagnitude;
				if (sqrMagnitude < fix)
				{
					result = entranceLanes[i];
					fix = sqrMagnitude;
				}
			}
			return result;
		}

		public Fix64 GetSquaredDistanceToClosestEntrance(Vector2Fixed worldPosition)
		{
			LaneModel closestEntranceLane = GetClosestEntranceLane(worldPosition);
			if (!Diagnostics.Verify(closestEntranceLane != null, "Cannot get distance from a carpark with no entrances."))
			{
				return -Fix64.One;
			}
			return (closestEntranceLane.StartPosition - worldPosition).sqrMagnitude;
		}

		public DestinationModel GetNeighboringDestination(DestinationModel destination)
		{
			foreach (DestinationModel destination2 in destinations)
			{
				if (destination2 != destination)
				{
					return destination2;
				}
			}
			return null;
		}

		public void Remove()
		{
			foreach (DestinationModel destination in destinations)
			{
				if (destination.isActive)
				{
					destination.Remove();
				}
			}
			foreach (Vector2Int destinationOffset in destinationOffsets)
			{
				Vector2Int vector2Int = origin + destinationOffset;
				for (int i = 0; i < 2; i++)
				{
					for (int j = 0; j < 2; j++)
					{
						Vector2Int coordinates = vector2Int + new Vector2Int(i, j);
						TileModel tileModel = _tilemap.GetTileModel(coordinates);
						if (tileModel != null && tileModel.Tile?.ContentType == TileContentType.Destination)
						{
							tileModel.Tile.SetContentType(TileContentType.None, null);
						}
						if (tileModel?.RailTileModel != null)
						{
							tileModel.RailTileModel.carpark = null;
						}
					}
				}
			}
			foreach (LaneModel entranceLane in entranceLanes)
			{
				SendInboundVehiclesHome(entranceLane.roadChunk, entranceLane);
				_cityPlanModel.destinationLanes.Remove(entranceLane);
			}
			int num = ((Alignment == TileAlignment.Horizontal) ? footprint.x : footprint.y);
			Vector2Int vector2Int2 = new Vector2Int(int.MaxValue, int.MinValue);
			Vector2Int coordinates2 = new Vector2Int(int.MinValue, int.MaxValue);
			for (int k = 0; k < carparkTiles.Count; k++)
			{
				TileDirection tileDirection = TileDirection.None;
				if (k == 0 && entranceAtTopLeft)
				{
					tileDirection = TopLeftDrivewayDirection;
				}
				else if (k == num - 1 && entranceAtBottomRight)
				{
					tileDirection = BottomRightDrivewayDirection;
				}
				if (tileDirection != TileDirection.None)
				{
					Vector2Int vector2Int3 = ((tileDirection == TileDirection.South || tileDirection == TileDirection.East) ? BottomRightCarparkTileCoordinate : TopLeftCarparkTileCoordinate);
					TileModel tileModel2 = _tilemap.GetTileModel(vector2Int3);
					TileModel tileModel3 = _tilemap.GetTileModel(TileUtilities.GetAdjacentCoordinates(vector2Int3, tileDirection));
					if (tileModel3 == null || tileModel2 == null)
					{
						Log.Error("connectedTile or drivewayTile were null in CarparkModel.Remove!!");
					}
					else
					{
						TileDirection oppositeDirection = TileUtilities.GetOppositeDirection(tileDirection);
						tileModel3.Tile.SetNodeImmutability(oppositeDirection, isImmutable: false);
						tileModel3.Tile.SetNodeState(new RoadTileNode(oppositeDirection), RoadState.Mothballed);
						tileModel2.Tile.SetNodeState(new RoadTileNode(tileDirection), RoadState.Mothballed);
						tileModel3.Tile.SetNodeState(new RoadTileNode(oppositeDirection), RoadState.None);
						tileModel2.Tile.SetNodeState(new RoadTileNode(tileDirection), RoadState.None);
						List<LaneModel> lanesConnectedToDirection = tileModel3.roadChunk.GetLanesConnectedToDirection(RoadState.Live | RoadState.Pending, oppositeDirection);
						for (int num2 = lanesConnectedToDirection.Count - 1; num2 >= 0; num2--)
						{
							LaneModel laneModel = lanesConnectedToDirection[num2];
							SendInboundVehiclesHome(laneModel.roadChunk, laneModel);
							for (int num3 = laneModel.Vehicles.Count - 1; num3 >= 0; num3--)
							{
								laneModel.Vehicles[num3].ResetToHouse();
							}
							laneModel.roadChunk.RemoveLane(laneModel);
						}
					}
				}
				Vector2Int vector2Int4 = carparkTiles[k];
				Vector2Int vector2Int5 = origin + vector2Int4;
				Tile tile = _tilemap.GetTile(vector2Int5);
				if (Diagnostics.Verify(tile?.CanSetContentType(TileContentType.None) ?? false, "Unable to unset TileContentType on one of a carpark's tiles at {0} (was null: {1})!", TopLeftCarparkTileCoordinate, tile == null))
				{
					tile.SetContentType(TileContentType.None, null);
				}
				if (vector2Int5.x < vector2Int2.x || vector2Int5.y > vector2Int2.y)
				{
					vector2Int2 = vector2Int5;
				}
				if (vector2Int5.x > coordinates2.x || vector2Int5.y < coordinates2.y)
				{
					coordinates2 = vector2Int5;
				}
			}
			foreach (ParkingSpace space in spaces)
			{
				SendInboundVehiclesHome(space.parkRoadChunk);
				space.parkRoadChunk.RemoveAllLanes();
				space.outerRoadChunk.RemoveAllLanes();
				space.innerRoadChunk.RemoveAllLanes();
			}
			spaces.Clear();
			(_tilemap.GetTileModel(TopLeftCarparkTileCoordinate)?.roadChunk)?.RemoveAllLanes();
			(_tilemap.GetTileModel(coordinates2)?.roadChunk)?.RemoveAllLanes();
			ObserverList<IObserver>.Enumerator enumerator5 = base.Observers.GetEnumerator();
			while (enumerator5.MoveNext())
			{
				enumerator5.Current.OnCarparkRemoved(this);
			}
			_simulation.RemoveModel(this);
			static void SendInboundVehiclesHome(RoadChunkModel roadChunk, LaneModel laneModel2 = null)
			{
				SendListedInboundVehiclesHome(roadChunk.inboundVehicles, laneModel2);
				SendListedInboundVehiclesHome(roadChunk.returningInboundVehicles, laneModel2);
			}
			static void SendListedInboundVehiclesHome(List<RoadChunkModel.InboundVehicle> inboundVehicles, LaneModel laneModel2 = null)
			{
				for (int num4 = inboundVehicles.Count - 1; num4 >= 0; num4--)
				{
					if (num4 < inboundVehicles.Count && (laneModel2 == null || inboundVehicles[num4].chosenLane == laneModel2))
					{
						inboundVehicles[num4].vehicle.ResetToHouse();
					}
				}
			}
		}

		public override void Reset()
		{
			base.Reset();
			origin.x = 0;
			origin.y = 0;
			footprint.x = 0;
			footprint.y = 0;
			carparkSide = TileDirection.None;
			entranceAtTopLeft = false;
			entranceAtBottomRight = false;
			destinationOffsets = null;
			carparkTiles = null;
			TileModels = null;
			supportsBoats = false;
		}

		public override void OnReleasedFromScope(IScope scope)
		{
			base.OnReleasedFromScope(scope);
			foreach (ParkingSpace space in spaces)
			{
				scope.Release(space);
			}
			spaces.Clear();
			entranceLanes.Clear();
			vehiclesEntering.Clear();
			vehiclesDrivingThrough.Clear();
			destinations.Clear();
		}

		public CarparkModel()
			: base(1)
		{
		}
	}
}
