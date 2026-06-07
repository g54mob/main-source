using System;
using Factory;

namespace Motorways
{
	public struct BoatPathTileConnection : IComparable
	{
		public class Serializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				if (obj is BoatPathTileConnection boatPathTileConnection)
				{
					context.Writer.Write((byte)boatPathTileConnection.input);
					context.Writer.Write((byte)boatPathTileConnection.output);
					return true;
				}
				return false;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				TileDirection inputDirection = TileUtilities.DeserializeDirection(context.Reader.ReadByte());
				TileDirection outputDirection = TileUtilities.DeserializeDirection(context.Reader.ReadByte());
				return new BoatPathTileConnection(inputDirection, outputDirection);
			}
		}

		public readonly TileDirection input;

		public readonly TileDirection output;

		public static readonly BoatPathTileConnection InvalidConnection = new BoatPathTileConnection(TileDirection.None, TileDirection.None);

		public bool IsDeadEnd
		{
			get
			{
				if (input == output || input != TileDirection.None)
				{
					return output == TileDirection.None;
				}
				return true;
			}
		}

		public BoatPathTileConnection(TileDirection inputDirection, TileDirection outputDirection)
		{
			input = inputDirection;
			output = outputDirection;
		}

		public BoatPathTileConnection GetRotatedConnection(RoadTileRotation rotation)
		{
			return new BoatPathTileConnection(TileUtilities.GetRotatedDirection(input, rotation), TileUtilities.GetRotatedDirection(output, rotation));
		}

		public TileDirection GetOtherDirection(TileDirection direction)
		{
			if (input == direction)
			{
				return output;
			}
			if (output == direction)
			{
				return input;
			}
			return TileDirection.None;
		}

		public static bool operator ==(BoatPathTileConnection lhs, BoatPathTileConnection rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(BoatPathTileConnection lhs, BoatPathTileConnection rhs)
		{
			return !lhs.Equals(rhs);
		}

		public override bool Equals(object obj)
		{
			if (obj is BoatPathTileConnection otherConnection)
			{
				return Equals(otherConnection);
			}
			return false;
		}

		public bool Equals(BoatPathTileConnection otherConnection)
		{
			if (input == otherConnection.input)
			{
				return output == otherConnection.output;
			}
			return false;
		}

		public int CompareTo(object obj)
		{
			if (obj is BoatPathTileConnection otherConnection)
			{
				return CompareTo(otherConnection);
			}
			return 1;
		}

		public int CompareTo(BoatPathTileConnection otherConnection)
		{
			int num = input - otherConnection.input;
			if (num != 0)
			{
				return num;
			}
			num = output - otherConnection.output;
			if (num != 0)
			{
				return num;
			}
			return 0;
		}

		public override int GetHashCode()
		{
			return (int)(input + 100) + (int)(output + 1);
		}

		public override string ToString()
		{
			return $"{input} to {output}";
		}
	}
}
