using Factory;
using FixMath;
using JetBrains.Annotations;
using Server;
using UnityEngine;

namespace Motorways.Models
{
	public class BoatPathTileModel : Model<EmptyModelFrame, BoatPathTileModel.IObserver>, IDeserializedHandler
	{
		public interface IObserver
		{
		}

		public static readonly Fix64 InvalidDistance = -Fix64.One;

		private BoatPathModel _boatPath;

		public CarparkModel carpark;

		[Dependency]
		private BoatPathTileAtlas _boatTileAtlas;

		[Serialize(false, null)]
		public Fix64 Length { get; private set; }

		public BoatPathModel BoatPath
		{
			get
			{
				return _boatPath;
			}
			set
			{
				_boatPath = value;
			}
		}

		public Vector2Int Coordinates => TileModel.Coordinates;

		[Serialize(true, null)]
		public TileModel TileModel { get; private set; }

		[CanBeNull]
		public BoatPathTileModel PreviousBoatPathModel
		{
			get
			{
				TileDirection input = TileModel.Tile.BoatPathConnection.input;
				if (input == TileDirection.None)
				{
					return null;
				}
				return TileModel.GetAdjacentTileModelInDirection(input)?.BoatPathTileModel;
			}
		}

		[CanBeNull]
		public BoatPathTileModel NextBoatPathModel
		{
			get
			{
				TileDirection output = TileModel.Tile.BoatPathConnection.output;
				if (output == TileDirection.None)
				{
					return null;
				}
				return TileModel.GetAdjacentTileModelInDirection(output)?.BoatPathTileModel;
			}
		}

		[CanBeNull]
		public BoatPathTileModel GetNextBoatPathModelInDirection(BoatModel.BoatDirection direction)
		{
			if (direction != BoatModel.BoatDirection.Forwards)
			{
				return PreviousBoatPathModel;
			}
			return NextBoatPathModel;
		}

		public (BoatPathTileModel destination, Fix64 distanceAlongDestination) Traverse(Fix64 originDistance, Fix64 distanceToTraverse)
		{
			BoatPathTileModel boatPathTileModel = this;
			Fix64 fix = originDistance;
			while (distanceToTraverse > Fix64.Zero)
			{
				Fix64 fix2 = boatPathTileModel.Length - fix;
				if (fix2 > distanceToTraverse)
				{
					fix += distanceToTraverse;
					return (destination: boatPathTileModel, distanceAlongDestination: fix);
				}
				BoatPathTileModel nextBoatPathModel = boatPathTileModel.NextBoatPathModel;
				if (nextBoatPathModel == null)
				{
					return (destination: boatPathTileModel, distanceAlongDestination: boatPathTileModel.Length);
				}
				distanceToTraverse -= fix2;
				boatPathTileModel = nextBoatPathModel;
				fix = Fix64.Zero;
			}
			Diagnostics.FailAssert("BoatPathTileModel.Traverse failed to complete its traversal. This should never happen!");
			return (destination: this, distanceAlongDestination: originDistance);
		}

		public Fix64 DistanceTo(Fix64 originPosition, [NotNull] BoatPathTileModel targetBoatPath, Fix64 positionOnTargetBoatPath, BoatModel.BoatDirection direction)
		{
			BoatPathTileModel boatPathTileModel = this;
			if (boatPathTileModel == targetBoatPath)
			{
				Fix64 fix = positionOnTargetBoatPath - originPosition;
				if (fix >= Fix64.Zero)
				{
					return fix;
				}
				if (!_boatPath.IsLoop)
				{
					return InvalidDistance;
				}
			}
			Fix64 fix2 = boatPathTileModel.Length - originPosition;
			for (boatPathTileModel = boatPathTileModel.GetNextBoatPathModelInDirection(direction); boatPathTileModel != null; boatPathTileModel = boatPathTileModel.GetNextBoatPathModelInDirection(direction))
			{
				if (boatPathTileModel == targetBoatPath)
				{
					return fix2 + positionOnTargetBoatPath;
				}
				if (boatPathTileModel == this)
				{
					return InvalidDistance;
				}
				fix2 += boatPathTileModel.Length;
			}
			return InvalidDistance;
		}

		public CarparkModel GetFirstTerminal(Fix64 currentBoatTraversal, Fix64 boatCenterToBowDistance, BoatModel.BoatDirection boatDirection, out Fix64 distanceToTerminal)
		{
			BoatPathTileModel boatPathTileModel = this;
			distanceToTerminal = default(Fix64);
			do
			{
				if (boatPathTileModel.carpark != null)
				{
					distanceToTerminal = DistanceTo(currentBoatTraversal, boatPathTileModel, Traverse(Length / Fix64Consts.Two, boatCenterToBowDistance).distanceAlongDestination, boatDirection);
					return boatPathTileModel.carpark;
				}
				boatPathTileModel = boatPathTileModel.NextBoatPathModel;
			}
			while (boatPathTileModel != null && boatPathTileModel != this);
			boatPathTileModel = this;
			do
			{
				if (boatPathTileModel.carpark != null)
				{
					distanceToTerminal = DistanceTo(currentBoatTraversal, boatPathTileModel, Traverse(Length / Fix64Consts.Two, boatCenterToBowDistance).distanceAlongDestination, boatDirection);
					return boatPathTileModel.carpark;
				}
				boatPathTileModel = boatPathTileModel.PreviousBoatPathModel;
			}
			while (boatPathTileModel != null && boatPathTileModel != this);
			return null;
		}

		public void Initialize(TileModel tileModel)
		{
			TileModel = tileModel;
			BoatPathTileDefinition definition = _boatTileAtlas.GetDefinition(tileModel.Tile.BoatPathConnection);
			if (Diagnostics.Verify(definition != null))
			{
				Length = definition.path.Length;
			}
		}

		public override void Reset()
		{
			base.Reset();
			Length = Fix64.Zero;
			_boatPath = null;
			TileModel = null;
			carpark = null;
		}

		public override string ToString()
		{
			return $"[BoatPathTileModel Coordinates={Coordinates} Length={Length}]";
		}

		public void OnDeserialized(IScope context)
		{
			BoatPathTileDefinition definition = _boatTileAtlas.GetDefinition(TileModel.Tile.BoatPathConnection);
			if (Diagnostics.Verify(definition != null))
			{
				Length = definition.path.Length;
			}
		}

		public BoatPathTileModel()
			: base(1)
		{
		}
	}
}
