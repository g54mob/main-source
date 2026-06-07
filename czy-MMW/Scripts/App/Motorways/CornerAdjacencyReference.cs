using System;
using Factory;
using UnityEngine;

namespace Motorways
{
	public readonly struct CornerAdjacencyReference : IComparable
	{
		public class Serializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				if (obj is CornerAdjacencyReference)
				{
					Vector2Int tileCoordinate = ((CornerAdjacencyReference)obj).tileCoordinate;
					TileDirection cornerDirection = ((CornerAdjacencyReference)obj).cornerDirection;
					context.Writer.Write(tileCoordinate.x);
					context.Writer.Write(tileCoordinate.y);
					context.Writer.Write((int)cornerDirection);
					return true;
				}
				return false;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				Vector2Int tileCoordinate = new Vector2Int(context.Reader.ReadInt32(), context.Reader.ReadInt32());
				TileDirection cornerDirection = (TileDirection)context.Reader.ReadInt32();
				return new CornerAdjacencyReference(tileCoordinate, cornerDirection);
			}
		}

		public readonly Vector2Int tileCoordinate;

		public readonly TileDirection cornerDirection;

		public CornerAdjacencyReference(Vector2Int tileCoordinate, TileDirection cornerDirection)
		{
			this.tileCoordinate = tileCoordinate;
			this.cornerDirection = cornerDirection;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is CornerAdjacencyReference))
			{
				return false;
			}
			return CompareTo(obj) == 0;
		}

		public override int GetHashCode()
		{
			return tileCoordinate.GetHashCode() ^ cornerDirection.GetHashCode();
		}

		public int CompareTo(object obj)
		{
			if (obj == null || !(obj is CornerAdjacencyReference { tileCoordinate: { x: var x } } cornerAdjacencyReference))
			{
				return 1;
			}
			if (x != tileCoordinate.x)
			{
				return tileCoordinate.x - cornerAdjacencyReference.tileCoordinate.x;
			}
			if (cornerAdjacencyReference.tileCoordinate.y != tileCoordinate.y)
			{
				return tileCoordinate.y - cornerAdjacencyReference.tileCoordinate.y;
			}
			if (cornerDirection != cornerAdjacencyReference.cornerDirection)
			{
				return cornerDirection - cornerAdjacencyReference.cornerDirection;
			}
			return 0;
		}
	}
}
