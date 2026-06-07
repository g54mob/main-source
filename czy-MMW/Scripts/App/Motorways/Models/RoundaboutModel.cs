using System.Collections.Generic;
using Factory;
using Factory.Pools;
using Server;
using UnityEngine;

namespace Motorways.Models
{
	public class RoundaboutModel : IModel, IReusable, Tile.IObserver, IReleasedFromScopeHandler, IDeserializedHandler
	{
		public enum ConcreteRestoreType
		{
			Unmothball = 0,
			Release = 1
		}

		private Vector2Int _originCoordinates;

		private TileModel _centerTileModel;

		private Tile _referenceTile;

		private RoadTileConnection _referenceConnection;

		private RoadState _lastKnownState;

		private readonly List<AdjacentTileConnection> _replacedConnections = new List<AdjacentTileConnection>();

		[Dependency]
		private TilemapModel _tilemap;

		[Dependency]
		private ISimulation _simulation;

		public IEnumerable<AdjacentTileConnection> ReplacedConnections => _replacedConnections;

		public Vector2Int OriginCoordinates => _originCoordinates;

		public TileModel CenterTileModel => _centerTileModel;

		public Vector2Int CenterCoordinates => _centerTileModel.Coordinates;

		public RoadState State => _referenceTile.GetRoundaboutState(_referenceConnection);

		private bool CanActivate
		{
			get
			{
				foreach (Tile item in Roundabout.GetTilesInRoundabout(_referenceTile, RoadState.Planned))
				{
					if (item.IsPlannedRoundaboutBlocked)
					{
						return false;
					}
				}
				return !_centerTileModel.Tile.IsPlannedRoundaboutBlocked;
			}
		}

		public void Initialize(Vector2Int originCoordinates, List<AdjacentTileConnection> replacedConnections)
		{
			_originCoordinates = originCoordinates;
			_replacedConnections.AddRange(replacedConnections);
			_centerTileModel = _tilemap.GetOrCreateTileModel(_originCoordinates + Roundabout.GetCenterOffset());
			_centerTileModel.Tile.Subscribe(this);
			Vector2Int vector2Int = Roundabout.GetCoordinatesOffsets()[0];
			_referenceConnection = Roundabout.GetConnectionForCoordinatesOffset(vector2Int);
			_referenceTile = _tilemap.GetOrCreateTile(_originCoordinates + vector2Int);
			_referenceTile.Subscribe(this);
			_lastKnownState = State;
		}

		public bool Activate()
		{
			if (CanActivate)
			{
				foreach (Tile item in Roundabout.GetTilesInRoundabout(_referenceTile, RoadState.Planned))
				{
					RoadTileConnection roundaboutConnection = item.GetRoundaboutConnection(RoadState.Planned);
					item.SetRoundaboutState(roundaboutConnection, RoadState.Active);
				}
				return true;
			}
			return false;
		}

		public void Reset()
		{
			_originCoordinates = default(Vector2Int);
			_centerTileModel = null;
			_referenceTile = null;
			_referenceConnection = default(RoadTileConnection);
			_lastKnownState = RoadState.None;
			_replacedConnections.Clear();
		}

		public void OnReleasedFromScope(IScope scope)
		{
			_referenceTile?.Unsubscribe(this);
			_referenceTile = null;
			_centerTileModel?.Tile?.Unsubscribe(this);
			_centerTileModel = null;
		}

		public void OnDeserialized(IScope context)
		{
			if (Diagnostics.Verify(_referenceTile != null))
			{
				_referenceTile.Subscribe(this);
			}
			if (Diagnostics.Verify(_centerTileModel != null))
			{
				_centerTileModel.Tile?.Subscribe(this);
			}
		}

		public void ClearReplacedConnections()
		{
			_replacedConnections.Clear();
		}

		public void OnTileChanged(Tile changedTile)
		{
			if (_centerTileModel == null || _referenceTile == null)
			{
				Diagnostics.FailAssert($"We somehow subscribed to a tile at {changedTile.Coordinates} without initializing the roundabout!");
				return;
			}
			if (changedTile == _centerTileModel.Tile)
			{
				if (changedTile.IsCenterOfRoundabout && changedTile.IsRoundaboutPermanent)
				{
					_centerTileModel.Tile.Unsubscribe(this);
					RestoreConcreteFromStoredReplacedConnections(ConcreteRestoreType.Release);
				}
				return;
			}
			RoadState state = State;
			if (state == _lastKnownState)
			{
				return;
			}
			switch (state)
			{
			case RoadState.None:
				if (_lastKnownState == RoadState.Planned)
				{
					foreach (Tile item in Roundabout.GetTilesInRoundabout(_referenceTile, _referenceConnection))
					{
						TileModel tileModel2 = _tilemap.GetTileModel(item.Coordinates);
						if (Diagnostics.Verify(tileModel2 != null))
						{
							ClearHotswappingLanes(tileModel2);
						}
					}
					ClearHotswappingLanes(_centerTileModel);
				}
				_centerTileModel.Tile.ResetRoundaboutPermanence();
				_simulation.RemoveModel(this);
				break;
			case RoadState.Active:
				if (_lastKnownState != RoadState.Mothballed)
				{
					break;
				}
				foreach (Tile item2 in Roundabout.GetTilesInRoundabout(_referenceTile, _referenceConnection))
				{
					TileModel tileModel = _tilemap.GetTileModel(item2.Coordinates);
					if (!Diagnostics.Verify(tileModel != null, "A roundabout had a non-existent tile."))
					{
						continue;
					}
					foreach (LaneModel lane in tileModel.roadChunk.lanes)
					{
						if (lane.connection.input.type != RoadType.Roundabout && lane.connection.output.type != RoadType.Roundabout)
						{
							continue;
						}
						lane.IsAboutToHotswap = false;
						if (!lane.connection.IsRoundabout)
						{
							continue;
						}
						foreach (LaneModel inboundLane in lane.InboundLanes)
						{
							inboundLane.IsAboutToHotswap = false;
						}
						foreach (LaneModel outboundLane in lane.OutboundLanes)
						{
							if (!outboundLane.connection.IsRoundabout)
							{
								outboundLane.IsAboutToHotswap = false;
							}
						}
					}
				}
				break;
			}
			_lastKnownState = state;
		}

		public void RestoreConcreteFromStoredReplacedConnections(ConcreteRestoreType restoreType)
		{
			GameBehaviourModel gameBehaviourModel = _simulation.Scope.Get<GameBehaviourModel>();
			ITilemap tilemap = _simulation.Scope.Get<TilemapModel>();
			int num = 0;
			foreach (AdjacentTileConnection replacedConnection in _replacedConnections)
			{
				if ((!(replacedConnection.OriginCoordinates == _originCoordinates) && !(replacedConnection.DestinationCoordinates == _originCoordinates)) || !TileUtilities.IsDirectionDiagonal(replacedConnection.DestinationDirection))
				{
					num += gameBehaviourModel.GetConcreteCostForConnection(tilemap.GetTile(replacedConnection.OriginCoordinates), tilemap.GetTile(replacedConnection.DestinationCoordinates));
				}
			}
			if (restoreType == ConcreteRestoreType.Release)
			{
				_simulation.GetModel<UpgradeDatabaseModel>().ReleaseMothballedUpgrade(UpgradeType.Concrete, num);
			}
			else
			{
				_simulation.GetModel<UpgradeDatabaseModel>().UnmothballUpgrade(UpgradeType.Concrete, num);
			}
		}

		private static void ClearHotswappingLanes(TileModel tile)
		{
			foreach (LaneModel lane in tile.roadChunk.lanes)
			{
				if (lane.connection.IsRoundabout)
				{
					continue;
				}
				lane.IsAboutToHotswap = false;
				foreach (LaneModel inboundLane in lane.InboundLanes)
				{
					if (inboundLane.connection.input.type != RoadType.Roundabout && inboundLane.connection.output.type != RoadType.Roundabout && TileUtilities.IsDirectionDiagonal(inboundLane.connection.output.direction))
					{
						inboundLane.IsAboutToHotswap = false;
					}
				}
				foreach (LaneModel outboundLane in lane.OutboundLanes)
				{
					if (outboundLane.connection.input.type != RoadType.Roundabout && outboundLane.connection.output.type != RoadType.Roundabout && TileUtilities.IsDirectionDiagonal(outboundLane.connection.output.direction))
					{
						outboundLane.IsAboutToHotswap = false;
					}
				}
			}
		}
	}
}
