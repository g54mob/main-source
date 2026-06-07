using System;
using Factory;

namespace Motorways
{
	public struct RailTileConnection : IComparable
	{
		public class Serializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				if (obj is RailTileConnection railTileConnection)
				{
					context.Writer.Write((byte)railTileConnection.input);
					context.Writer.Write((byte)railTileConnection.output);
					return true;
				}
				return false;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				TileDirection inputDirection = TileUtilities.DeserializeDirection(context.Reader.ReadByte());
				TileDirection outputDirection = TileUtilities.DeserializeDirection(context.Reader.ReadByte());
				return new RailTileConnection(inputDirection, outputDirection);
			}
		}

		public readonly TileDirection input;

		public readonly TileDirection output;

		public static readonly RailTileConnection InvalidConnection = new RailTileConnection(TileDirection.None, TileDirection.None);

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

		public RailTileConnection(TileDirection inputDirection, TileDirection outputDirection)
		{
			input = inputDirection;
			output = outputDirection;
		}

		public RailTileConnection GetRotatedConnection(RoadTileRotation rotation)
		{
			return new RailTileConnection(TileUtilities.GetRotatedDirection(input, rotation), TileUtilities.GetRotatedDirection(output, rotation));
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

		public static bool operator ==(RailTileConnection lhs, RailTileConnection rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(RailTileConnection lhs, RailTileConnection rhs)
		{
			return !lhs.Equals(rhs);
		}

		public override bool Equals(object obj)
		{
			if (obj is RailTileConnection otherConnection)
			{
				return Equals(otherConnection);
			}
			return false;
		}

		public bool Equals(RailTileConnection otherConnection)
		{
			if (input == otherConnection.input)
			{
				return output == otherConnection.output;
			}
			return false;
		}

		public int CompareTo(object obj)
		{
			if (obj is RailTileConnection otherConnection)
			{
				return CompareTo(otherConnection);
			}
			return 1;
		}

		public int CompareTo(RailTileConnection otherConnection)
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
