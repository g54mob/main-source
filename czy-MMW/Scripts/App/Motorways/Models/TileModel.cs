using Factory;
using FixMath;
using Server;
using UnityEngine;

namespace Motorways.Models
{
	public class TileModel : Model<EmptyModelFrame, TileModel.IObserver>, Tile.IObserver, IDeserializedHandler
	{
		public interface IObserver
		{
			void OnTileModelChanged(TileModel model);
		}

		[Dependency]
		private IScope _scope;

		[Dependency]
		private ISimulation _simulation;

		[Dependency]
		private TilemapModel _tilemap;

		[Dependency]
		private GameBehaviourModel _behaviour;

		private Tile _tile;

		private Vector2Fixed _worldPosition;

		public RoadChunkModel roadChunk;

		private RailTileModel _railTileModel;

		private BoatPathTileModel _boatPathTileModel;

		public Vector2Int Coordinates => _tile.Coordinates;

		public Tile Tile => _tile;

		public RailTileModel RailTileModel => _railTileModel;

		public BoatPathTileModel BoatPathTileModel => _boatPathTileModel;

		public Vector2Fixed WorldPosition => _worldPosition;

		public void Initialize(Vector2Int coordinates)
		{
			roadChunk = _scope.Get<RoadChunkModel>();
			_simulation.AddModel(roadChunk);
			_tile = _scope.Get<Tile>();
			_tile.Initialize(_tilemap, coordinates, TileContentType.None);
			_tile.Subscribe(this);
			Subscribe(_behaviour);
			_worldPosition = TilemapModel.GetWorldPositionForCoordinates(coordinates);
		}

		public void OnTileChanged(Tile changedTile)
		{
			ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnTileModelChanged(this);
			}
			if (changedTile.HasRailConnection)
			{
				if (_railTileModel == null)
				{
					_railTileModel = _scope.Get<RailTileModel>();
					_railTileModel.Initialize(this);
					_simulation.AddModel(_railTileModel);
				}
			}
			else
			{
				_ = _railTileModel;
			}
			if (changedTile.HasBoatPathConnection)
			{
				if (_boatPathTileModel == null)
				{
					_boatPathTileModel = _scope.Get<BoatPathTileModel>();
					_boatPathTileModel.Initialize(this);
					_simulation.AddModel(_boatPathTileModel);
				}
			}
			else
			{
				_ = _boatPathTileModel;
			}
			if (changedTile.HasTrafficLight)
			{
				if (roadChunk.TrafficLight == null)
				{
					roadChunk.TrafficLight = _simulation.Scope.Get<TrafficLightModel>();
					roadChunk.TrafficLight.Initialize(roadChunk);
					_simulation.AddModel(roadChunk.TrafficLight);
				}
			}
			else if (roadChunk.TrafficLight != null)
			{
				_simulation.RemoveModel(roadChunk.TrafficLight);
				roadChunk.TrafficLight = null;
			}
		}

		public void RemoveTrainCrossing()
		{
			if (roadChunk.TrainCrossingModel != null)
			{
				_simulation.RemoveModel(roadChunk.TrainCrossingModel);
				roadChunk.TrainCrossingModel = null;
			}
		}

		public LaneModel AddLane(RoadTileConnection connection, RoadTileDefinition tileDefinition, RoadState initialState, bool isEndpointLane)
		{
			LaneModel laneModel = roadChunk.AddLane(connection, tileDefinition, initialState, WorldPosition, isEndpointLane);
			if (connection.input.type != RoadType.Motorway)
			{
				GetAdjacentRoadChunkModelInDirection(connection.input.direction)?.ConnectOutboundLane(laneModel);
			}
			if (connection.output.type != RoadType.Motorway)
			{
				GetAdjacentRoadChunkModelInDirection(connection.output.direction)?.ConnectInboundLane(laneModel);
			}
			return laneModel;
		}

		public TileModel GetAdjacentTileModelInDirection(TileDirection directionToCheck)
		{
			Vector2Int adjacentCoordinates = TileUtilities.GetAdjacentCoordinates(Coordinates, directionToCheck);
			return _tilemap.GetTileModel(adjacentCoordinates);
		}

		public TileCornerModel GetAdjacentTileCornerModelInDirection(TileDirection directionToCheck)
		{
			CornerAdjacencyReference cornerDefinition = new CornerAdjacencyReference(Coordinates, directionToCheck);
			return _tilemap.GetTileCornerModel(cornerDefinition);
		}

		public override void Reset()
		{
			base.Reset();
			_worldPosition = Vector2Fixed.zero;
			_railTileModel = null;
			_boatPathTileModel = null;
			roadChunk = null;
		}

		public override void OnReleasedFromScope(IScope scope)
		{
			base.OnReleasedFromScope(scope);
			if (_tile != null)
			{
				scope.Release(_tile);
				_tile = null;
			}
			if (roadChunk != null)
			{
				scope.Release(roadChunk);
				roadChunk = null;
			}
			if (_behaviour != null)
			{
				Unsubscribe(_behaviour);
			}
		}

		public void OnDeserialized(IScope context)
		{
			if (Diagnostics.Verify(_tile != null))
			{
				_tile.Subscribe(this);
			}
			if (_behaviour != null)
			{
				Subscribe(_behaviour);
			}
		}

		public override string ToString()
		{
			if (_tile == null)
			{
				return "[TileModel]";
			}
			return $"[TileModel Coordinates={_tile.Coordinates}]";
		}

		public bool AreAllLanesInDirectionUnused(TileDirection direction, RoadState state = RoadState.Active)
		{
			foreach (LaneModel item in roadChunk.GetLanesConnectedToDirection(state, direction))
			{
				if (item.hasBeenUsed)
				{
					return false;
				}
			}
			return true;
		}

		private RoadChunkModel GetAdjacentRoadChunkModelInDirection(TileDirection directionToCheck)
		{
			if (TileUtilities.IsDirectionDiagonal(directionToCheck))
			{
				return GetAdjacentTileCornerModelInDirection(directionToCheck)?.roadChunk;
			}
			return GetAdjacentTileModelInDirection(directionToCheck)?.roadChunk;
		}

		public TileModel()
			: base(1)
		{
		}
	}
}
