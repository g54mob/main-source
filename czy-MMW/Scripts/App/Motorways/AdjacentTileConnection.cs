using Factory;
using UnityEngine;

namespace Motorways
{
	public class AdjacentTileConnection
	{
		public class Serializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				if (obj is AdjacentTileConnection adjacentTileConnection)
				{
					SerializerLibrary.GetSerializer<Vector2Int>().Serialize(adjacentTileConnection.OriginCoordinates, context);
					context.Writer.Write((byte)adjacentTileConnection.OriginDirection);
					return true;
				}
				return false;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				return new AdjacentTileConnection((Vector2Int)SerializerLibrary.GetSerializer<Vector2Int>().Deserialize(null, context), (TileDirection)context.Reader.ReadByte());
			}
		}

		private readonly Vector2Int _coordinates;

		private readonly TileDirection _direction;

		public Vector2Int OriginCoordinates => _coordinates;

		public TileDirection OriginDirection => _direction;

		public Vector2Int DestinationCoordinates => TileUtilities.GetAdjacentCoordinates(_coordinates, _direction);

		public TileDirection DestinationDirection => TileUtilities.GetOppositeDirection(_direction);

		public AdjacentTileConnection(Vector2Int coordinates, TileDirection direction)
		{
			_coordinates = coordinates;
			_direction = direction;
		}

		public override bool Equals(object obj)
		{
			if (obj is AdjacentTileConnection obj2)
			{
				return Equals(obj2);
			}
			return false;
		}

		private bool Equals(AdjacentTileConnection obj)
		{
			if (!(_coordinates == obj._coordinates) || _direction != obj._direction)
			{
				if (_coordinates == obj.DestinationCoordinates)
				{
					return _direction == obj.DestinationDirection;
				}
				return false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			return OriginCoordinates.GetHashCode() ^ DestinationCoordinates.GetHashCode();
		}
	}
}
