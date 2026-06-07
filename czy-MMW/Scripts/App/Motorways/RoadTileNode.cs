using System;
using Factory;

namespace Motorways
{
	public readonly struct RoadTileNode : IComparable
	{
		public class Serializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				if (obj is RoadTileNode roadTileNode)
				{
					bool flag = roadTileNode.motorwayId != -1;
					context.Writer.Write(flag);
					context.Writer.Write((byte)roadTileNode.direction);
					context.Writer.Write((byte)roadTileNode.type);
					if (flag)
					{
						context.Writer.Write(roadTileNode.motorwayId);
					}
					return true;
				}
				return false;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				bool flag = context.Reader.ReadBoolean();
				return new RoadTileNode((TileDirection)context.Reader.ReadByte(), (RoadType)context.Reader.ReadByte(), flag ? context.Reader.ReadInt32() : (-1));
			}
		}

		public readonly TileDirection direction;

		public readonly RoadType type;

		public readonly int motorwayId;

		public RoadTileNode(TileDirection direction, RoadType type = RoadType.TwoLane, int motorwayId = -1)
		{
			this.direction = direction;
			this.type = type;
			this.motorwayId = motorwayId;
		}

		public RoadTileNode GetRotatedNode(RoadTileRotation rotation)
		{
			return new RoadTileNode(TileUtilities.GetRotatedDirection(direction, rotation), type);
		}

		public static bool operator ==(RoadTileNode lhs, RoadTileNode rhs)
		{
			return lhs.Equals(rhs, TreatMotorwaysAs.Motorways);
		}

		public static bool operator !=(RoadTileNode lhs, RoadTileNode rhs)
		{
			return !lhs.Equals(rhs, TreatMotorwaysAs.Motorways);
		}

		public override bool Equals(object obj)
		{
			if (obj is RoadTileNode otherNode)
			{
				return CompareTo(otherNode) == 0;
			}
			return false;
		}

		public bool Equals(RoadTileNode otherNode)
		{
			return CompareTo(otherNode) == 0;
		}

		public bool Equals(RoadTileNode otherNode, TreatMotorwaysAs motorwayTreatment)
		{
			if (direction != otherNode.direction)
			{
				return false;
			}
			if (motorwayTreatment == TreatMotorwaysAs.Motorways)
			{
				if (type == otherNode.type)
				{
					return motorwayId == otherNode.motorwayId;
				}
				return false;
			}
			if (type == RoadType.TwoLane || type == RoadType.Motorway)
			{
				if (otherNode.type != RoadType.TwoLane)
				{
					return otherNode.type == RoadType.Motorway;
				}
				return true;
			}
			return type == otherNode.type;
		}

		public int CompareTo(object obj)
		{
			if (obj is RoadTileNode otherNode)
			{
				return CompareTo(otherNode);
			}
			return 1;
		}

		public int CompareTo(RoadTileNode otherNode)
		{
			if (direction != otherNode.direction)
			{
				return direction - otherNode.direction;
			}
			if (type != otherNode.type)
			{
				return type - otherNode.type;
			}
			if (motorwayId != otherNode.motorwayId)
			{
				return motorwayId - otherNode.motorwayId;
			}
			return 0;
		}

		public override int GetHashCode()
		{
			return GetHashCode(type, direction, motorwayId);
		}

		public int GetHashCode(TreatMotorwaysAs motorwayNodeTreatment)
		{
			if (motorwayNodeTreatment == TreatMotorwaysAs.TwoLaneRoads && type == RoadType.Motorway)
			{
				return GetHashCode(RoadType.TwoLane, direction, -1);
			}
			return GetHashCode(type, direction, motorwayId);
		}

		private static int GetHashCode(RoadType type, TileDirection direction, int motorwayId)
		{
			return ((int)type << 16) | ((int)direction << 8) | (motorwayId + 1);
		}

		public override string ToString()
		{
			string text = direction.ToShortString();
			if (type != RoadType.TwoLane)
			{
				text = text + " " + type;
			}
			if (motorwayId != -1)
			{
				string text2 = text;
				int num = motorwayId;
				text = text2 + " " + num;
			}
			return text;
		}
	}
}
