using System.Collections.Generic;
using Factory;
using FixMath;
using JetBrains.Annotations;
using Server;
using UnityEngine;

namespace Motorways.Models
{
	public class RailTileModel : Model<EmptyModelFrame, RailTileModel.IObserver>, IDeserializedHandler
	{
		public interface IObserver
		{
		}

		public static readonly Fix64 InvalidDistance = -Fix64.One;

		private TrainLineModel _line;

		private DestinationModel _attachedTrainStation;

		public CarparkModel carpark;

		[Dependency]
		private RailTileAtlas _railTileAtlas;

		[Serialize(false, null)]
		public TrainSignalState SignalState { get; set; } = TrainSignalState.Open;

		[Serialize(false, null)]
		public Fix64 Length { get; private set; }

		public TrainLineModel Line
		{
			get
			{
				return _line;
			}
			set
			{
				_line = value;
			}
		}

		public Vector2Int Coordinates => TileModel.Coordinates;

		[Serialize(true, null)]
		public TileModel TileModel { get; private set; }

		[CanBeNull]
		public RailTileModel PreviousRailModel
		{
			get
			{
				TileDirection input = TileModel.Tile.RailConnection.input;
				if (input == TileDirection.None)
				{
					return null;
				}
				return TileModel.GetAdjacentTileModelInDirection(input)?.RailTileModel;
			}
		}

		[CanBeNull]
		public RailTileModel NextRailModel
		{
			get
			{
				TileDirection output = TileModel.Tile.RailConnection.output;
				if (output == TileDirection.None)
				{
					return null;
				}
				return TileModel.GetAdjacentTileModelInDirection(output)?.RailTileModel;
			}
		}

		public DestinationModel Station => _attachedTrainStation;

		[CanBeNull]
		public RailTileModel GetNextRailModelInDirection(RailDirection direction)
		{
			if (direction != RailDirection.Forwards)
			{
				return PreviousRailModel;
			}
			return NextRailModel;
		}

		[CanBeNull]
		public RailTileModel GetPreviousRailModelInDirection(RailDirection direction)
		{
			if (direction != RailDirection.Forwards)
			{
				return NextRailModel;
			}
			return PreviousRailModel;
		}

		public (RailTileModel destination, Fix64 distanceAlongDestination, Fix64 totalDistanceTraversed) Traverse(Fix64 originDistance, Fix64 distanceToTraverse, RailDirection traversalDirection)
		{
			Fix64 zero = Fix64.Zero;
			RailTileModel railTileModel = this;
			Fix64 fix = originDistance;
			while (distanceToTraverse > Fix64.Zero)
			{
				if (traversalDirection == RailDirection.Forwards)
				{
					Fix64 fix2 = railTileModel.Length - fix;
					if (fix2 > distanceToTraverse)
					{
						zero += distanceToTraverse;
						fix += distanceToTraverse;
						return (destination: railTileModel, distanceAlongDestination: fix, totalDistanceTraversed: zero);
					}
					RailTileModel nextRailModel = railTileModel.NextRailModel;
					if (nextRailModel == null)
					{
						return (destination: railTileModel, distanceAlongDestination: railTileModel.Length, totalDistanceTraversed: zero + fix2);
					}
					distanceToTraverse -= fix2;
					zero += fix2;
					railTileModel = nextRailModel;
					fix = Fix64.Zero;
				}
				else
				{
					Fix64 fix3 = fix;
					if (fix3 > distanceToTraverse)
					{
						zero += distanceToTraverse;
						fix -= distanceToTraverse;
						return (destination: railTileModel, distanceAlongDestination: fix, totalDistanceTraversed: zero);
					}
					RailTileModel previousRailModel = railTileModel.PreviousRailModel;
					if (previousRailModel == null)
					{
						return (destination: railTileModel, distanceAlongDestination: Fix64.Zero, totalDistanceTraversed: zero + fix3);
					}
					distanceToTraverse -= fix3;
					zero += fix3;
					railTileModel = previousRailModel;
					fix = railTileModel.Length;
				}
			}
			Diagnostics.FailAssert("RailTileModel.Traverse failed to complete its traversal. This should never happen!");
			return (destination: this, distanceAlongDestination: originDistance, totalDistanceTraversed: Fix64.Zero);
		}

		public Fix64 DistanceTo(Fix64 originPosition, [NotNull] RailTileModel targetRail, Fix64 positionOnTargetRail, RailDirection direction)
		{
			RailTileModel railTileModel = this;
			if (railTileModel == targetRail)
			{
				Fix64 fix = positionOnTargetRail - originPosition;
				if (direction == RailDirection.Backwards)
				{
					fix = -fix;
				}
				if (fix >= Fix64.Zero)
				{
					return fix;
				}
				if (!_line.IsLoop)
				{
					return InvalidDistance;
				}
			}
			Fix64 fix2 = ((direction == RailDirection.Forwards) ? (railTileModel.Length - originPosition) : originPosition);
			for (railTileModel = railTileModel.GetNextRailModelInDirection(direction); railTileModel != null; railTileModel = railTileModel.GetNextRailModelInDirection(direction))
			{
				if (railTileModel == targetRail)
				{
					return fix2 + ((direction == RailDirection.Forwards) ? positionOnTargetRail : (targetRail.Length - positionOnTargetRail));
				}
				if (railTileModel == this)
				{
					return InvalidDistance;
				}
				fix2 += railTileModel.Length;
			}
			return InvalidDistance;
		}

		public IEnumerable<RoadChunkModel> GetRoadChunksInDirection(RailDirection direction)
		{
			yield return TileModel.roadChunk;
			RailTileConnection railConnection = TileModel.Tile.RailConnection;
			TileDirection tileDirection = ((direction == RailDirection.Forwards) ? railConnection.output : railConnection.input);
			if (TileUtilities.IsDirectionDiagonal(tileDirection))
			{
				TileCornerModel adjacentTileCornerModelInDirection = TileModel.GetAdjacentTileCornerModelInDirection(tileDirection);
				if (adjacentTileCornerModelInDirection != null)
				{
					yield return adjacentTileCornerModelInDirection.roadChunk;
				}
			}
		}

		public void Initialize(TileModel tileModel)
		{
			TileModel = tileModel;
			RailTileDefinition definition = _railTileAtlas.GetDefinition(tileModel.Tile.RailConnection);
			if (Diagnostics.Verify(definition != null))
			{
				Length = definition.path.Length;
			}
		}

		public void SetTrainStation(DestinationModel trainStation)
		{
			Diagnostics.Log.Info("RailTileModel", "Adding station {0} to rail {1}", trainStation, this);
			_attachedTrainStation = trainStation;
		}

		public void RemoveTrainStation()
		{
			Diagnostics.Log.Info("RailTileModel", "Removing station {0} from rail {1}", _attachedTrainStation, this);
			_attachedTrainStation = null;
		}

		public override void Reset()
		{
			base.Reset();
			SignalState = TrainSignalState.Open;
			Length = Fix64.Zero;
			_line = null;
			TileModel = null;
			_attachedTrainStation = null;
			carpark = null;
		}

		public override string ToString()
		{
			return $"[RailTileModel Coordinates={Coordinates} Length={Length}]";
		}

		public void OnDeserialized(IScope context)
		{
			RailTileDefinition definition = _railTileAtlas.GetDefinition(TileModel.Tile.RailConnection);
			if (Diagnostics.Verify(definition != null))
			{
				Length = definition.path.Length;
			}
		}

		public RailTileModel()
			: base(1)
		{
		}
	}
}
