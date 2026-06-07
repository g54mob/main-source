using System.Collections.Generic;
using Factory;
using FixMath;
using Server;

namespace Motorways.Models
{
	public class TileCornerModel : Model<EmptyModelFrame, IEmptyModelObserver>
	{
		[Dependency]
		private IScope _scope;

		[Dependency]
		private ISimulation _simulation;

		[Dependency]
		private TilemapModel _tilemap;

		private List<CornerAdjacencyReference> _adjacencyReferences = new List<CornerAdjacencyReference>();

		private Vector2Fixed _worldPosition;

		public RoadChunkModel roadChunk;

		public void Initialize(Vector2Fixed worldPosition, List<CornerAdjacencyReference> adjacencyReferences)
		{
			roadChunk = _scope.Get<RoadChunkModel>();
			roadChunk.isTileCorner = true;
			_simulation.AddModel(roadChunk);
			_worldPosition = worldPosition;
			_adjacencyReferences.AddRange(adjacencyReferences);
		}

		public LaneModel AddLane(RoadTileConnection connection, RoadTileDefinition tileDefinition, RoadState initialState)
		{
			LaneModel laneModel = roadChunk.AddLane(connection, tileDefinition, initialState, _worldPosition, isEndpointLane: false);
			GetAdjacentRoadChunkModelInDirection(connection.input.direction)?.ConnectOutboundLane(laneModel);
			GetAdjacentRoadChunkModelInDirection(connection.output.direction)?.ConnectInboundLane(laneModel);
			return laneModel;
		}

		public RoadTileSignature CreateTileSignature()
		{
			RoadTileSignature roadTileSignature = _scope.Get<RoadTileSignature>();
			TileDirection tileDirection = TileDirection.None;
			foreach (CornerAdjacencyReference adjacencyReference in _adjacencyReferences)
			{
				Tile tile = _tilemap.GetTile(adjacencyReference.tileCoordinate);
				if (tile != null && tile.HasRoundabout(RoadState.Active))
				{
					RoadTileConnection roundaboutConnection = tile.GetRoundaboutConnection(RoadState.Active);
					if (roundaboutConnection.output.direction == adjacencyReference.cornerDirection)
					{
						tileDirection = TileUtilities.GetOppositeDirection(roundaboutConnection.output.direction);
					}
				}
			}
			if (tileDirection != TileDirection.None)
			{
				roadTileSignature.AddConnection(new RoadTileConnection(new RoadTileNode(tileDirection, RoadType.Roundabout), new RoadTileNode(TileUtilities.GetOppositeDirection(tileDirection), RoadType.Roundabout)));
			}
			foreach (CornerAdjacencyReference adjacencyReference2 in _adjacencyReferences)
			{
				Tile tile2 = _tilemap.GetTile(adjacencyReference2.tileCoordinate);
				if (tile2 != null && tile2.GetTwoLaneRoads()[adjacencyReference2.cornerDirection] && (tileDirection == TileDirection.None || adjacencyReference2.cornerDirection != TileUtilities.GetRotatedDirection(tileDirection, -2)))
				{
					roadTileSignature.AddNode(new RoadTileNode(TileUtilities.GetOppositeDirection(adjacencyReference2.cornerDirection)));
				}
			}
			return roadTileSignature;
		}

		private TileModel GetAdjacentTileModelInDirection(TileDirection direction)
		{
			if (!TileUtilities.IsDirectionDiagonal(direction))
			{
				return null;
			}
			foreach (CornerAdjacencyReference adjacencyReference in _adjacencyReferences)
			{
				if (TileUtilities.GetOppositeDirection(adjacencyReference.cornerDirection) == direction)
				{
					return _tilemap.GetTileModel(adjacencyReference.tileCoordinate);
				}
			}
			return null;
		}

		private RoadChunkModel GetAdjacentRoadChunkModelInDirection(TileDirection direction)
		{
			return GetAdjacentTileModelInDirection(direction)?.roadChunk;
		}

		public override void Reset()
		{
			base.Reset();
			_tilemap = null;
			_adjacencyReferences.Clear();
			roadChunk = null;
			_worldPosition = default(Vector2Fixed);
		}

		public override void OnReleasedFromScope(IScope scope)
		{
			base.OnReleasedFromScope(scope);
			if (roadChunk != null)
			{
				scope.Release(roadChunk);
				roadChunk = null;
			}
		}

		public TileCornerModel()
			: base(1)
		{
		}
	}
}
