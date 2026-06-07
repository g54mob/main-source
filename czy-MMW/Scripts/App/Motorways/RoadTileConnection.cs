using System;
using System.Collections.Generic;
using Factory;

namespace Motorways
{
	public readonly struct RoadTileConnection : IComparable
	{
		public class MotorwayAgnosticEqualityComparer : IEqualityComparer<RoadTileConnection>
		{
			public bool Equals(RoadTileConnection x, RoadTileConnection y)
			{
				if (x.input.Equals(y.input, TreatMotorwaysAs.TwoLaneRoads))
				{
					return x.output.Equals(y.output, TreatMotorwaysAs.TwoLaneRoads);
				}
				return false;
			}

			public int GetHashCode(RoadTileConnection obj)
			{
				return (obj.input.GetHashCode(TreatMotorwaysAs.TwoLaneRoads) * 397) ^ obj.output.GetHashCode(TreatMotorwaysAs.TwoLaneRoads);
			}
		}

		public class Serializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				if (obj is RoadTileConnection roadTileConnection)
				{
					bool flag = roadTileConnection.input.motorwayId != -1 || roadTileConnection.output.motorwayId != -1;
					context.Writer.Write(flag);
					context.Writer.Write((byte)roadTileConnection.input.direction);
					context.Writer.Write((byte)roadTileConnection.input.type);
					if (flag)
					{
						context.Writer.Write(roadTileConnection.input.motorwayId);
					}
					context.Writer.Write((byte)roadTileConnection.output.direction);
					context.Writer.Write((byte)roadTileConnection.output.type);
					if (flag)
					{
						context.Writer.Write(roadTileConnection.output.motorwayId);
					}
					return true;
				}
				return false;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				bool flag = context.Reader.ReadBoolean();
				RoadTileNode inputNode = new RoadTileNode(TileUtilities.DeserializeDirection(context.Reader.ReadByte()), (RoadType)context.Reader.ReadByte(), flag ? context.Reader.ReadInt32() : (-1));
				RoadTileNode outputNode = new RoadTileNode(TileUtilities.DeserializeDirection(context.Reader.ReadByte()), (RoadType)context.Reader.ReadByte(), flag ? context.Reader.ReadInt32() : (-1));
				return new RoadTileConnection(inputNode, outputNode);
			}
		}

		public readonly RoadTileNode input;

		public readonly RoadTileNode output;

		public static readonly RoadTileConnection InvalidConnection = new RoadTileConnection(new RoadTileNode(TileDirection.None), new RoadTileNode(TileDirection.None));

		public bool IsUTurn => input.direction == output.direction;

		public bool IsRoundabout
		{
			get
			{
				if (input.type == RoadType.Roundabout)
				{
					return output.type == RoadType.Roundabout;
				}
				return false;
			}
		}

		public bool IsMotorway
		{
			get
			{
				if (input.type == RoadType.Motorway)
				{
					return output.type == RoadType.Motorway;
				}
				return false;
			}
		}

		public RoadTileConnection(TileDirection inputDirection, TileDirection outputDirection)
		{
			input = new RoadTileNode(inputDirection);
			output = new RoadTileNode(outputDirection);
		}

		public RoadTileConnection(RoadTileNode inputNode, RoadTileNode outputNode)
		{
			input = inputNode;
			output = outputNode;
		}

		public RoadTileConnection GetRotatedConnection(RoadTileRotation rotation)
		{
			return new RoadTileConnection(input.GetRotatedNode(rotation), output.GetRotatedNode(rotation));
		}

		public RoadTileConnection GetReflectedConnection()
		{
			return new RoadTileConnection(output, input);
		}

		public RoadTileNode GetOtherNode(TileDirection direction)
		{
			if (input.direction == direction)
			{
				return output;
			}
			if (output.direction == direction)
			{
				return input;
			}
			return new RoadTileNode(TileDirection.None);
		}

		public bool IntersectsOtherConnection(RoadTileConnection other, bool leftSideTraffic = false, bool smallIntersection = false, bool allowCrossingInFrontOfOther = false)
		{
			if (output.direction == other.output.direction && (!allowCrossingInFrontOfOther || input.direction == other.input.direction))
			{
				return true;
			}
			if (input.direction == other.input.direction)
			{
				return false;
			}
			if (CompareTo(other) == 0)
			{
				return true;
			}
			if (input.direction == other.output.direction && output.direction == other.input.direction)
			{
				return false;
			}
			if (smallIntersection && other.input.type != RoadType.Motorway && other.output.type != RoadType.Motorway)
			{
				RoadTileConnection rotatedConnection = other.GetRotatedConnection(RoadTileRotation.HalfTurn);
				if (CompareTo(rotatedConnection) == 0)
				{
					return true;
				}
			}
			if (allowCrossingInFrontOfOther)
			{
				return false;
			}
			int num = 0;
			int num2 = (int)(input.direction + (leftSideTraffic ? 1 : 0)) % 8;
			int num3 = ((int)output.direction + ((!leftSideTraffic) ? 1 : 0)) % 8;
			for (int num4 = num2; num4 != num3; num4 = (num4 + 1) % 8)
			{
				if (other.input.direction == (TileDirection)num4 || other.output.direction == (TileDirection)num4)
				{
					num++;
				}
			}
			return num == 1;
		}

		public static bool operator ==(RoadTileConnection lhs, RoadTileConnection rhs)
		{
			return lhs.Equals(rhs, TreatMotorwaysAs.Motorways);
		}

		public static bool operator !=(RoadTileConnection lhs, RoadTileConnection rhs)
		{
			return !lhs.Equals(rhs, TreatMotorwaysAs.Motorways);
		}

		public override bool Equals(object obj)
		{
			if (obj is RoadTileConnection otherConnection)
			{
				return Equals(otherConnection, TreatMotorwaysAs.Motorways);
			}
			return false;
		}

		public bool Equals(RoadTileConnection otherConnection)
		{
			return Equals(otherConnection, TreatMotorwaysAs.Motorways);
		}

		public bool Equals(RoadTileConnection otherConnection, TreatMotorwaysAs motorwayNodeTreatment)
		{
			if (input.Equals(otherConnection.input, motorwayNodeTreatment))
			{
				return output.Equals(otherConnection.output, motorwayNodeTreatment);
			}
			return false;
		}

		public int CompareTo(object obj)
		{
			if (obj is RoadTileConnection otherConnection)
			{
				return CompareTo(otherConnection);
			}
			return 1;
		}

		public int CompareTo(RoadTileConnection otherConnection)
		{
			int num = input.CompareTo(otherConnection.input);
			if (num != 0)
			{
				return num;
			}
			num = output.CompareTo(otherConnection.output);
			if (num != 0)
			{
				return num;
			}
			return 0;
		}

		public override int GetHashCode()
		{
			return GetHashCode(TreatMotorwaysAs.Motorways);
		}

		public int GetHashCode(TreatMotorwaysAs motorwayNodeTreatment)
		{
			int hashCode = input.GetHashCode(motorwayNodeTreatment);
			int hashCode2 = output.GetHashCode(motorwayNodeTreatment);
			return (hashCode << 16) | hashCode2;
		}

		public override string ToString()
		{
			return $"{input} to {output}";
		}
	}
}
