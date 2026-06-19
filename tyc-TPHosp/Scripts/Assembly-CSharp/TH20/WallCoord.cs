using System.Diagnostics;
using UnityEngine;

namespace TH20
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	public class WallCoord
	{
		public RoomWallDefinition.Type _type;

		public GridCoord _position;

		public GridDirection _rotation;

		private string DebuggerDisplay => $"({_position.X}, {_position.Y}), {_rotation}, {_type}";

		public bool IsWall()
		{
			if (_type < RoomWallDefinition.Type.Wall || _type > RoomWallDefinition.Type.WallCornerBoth)
			{
				return _type == RoomWallDefinition.Type.AmbulanceBayEntrance;
			}
			return true;
		}

		public bool IsDoor()
		{
			if (_type < RoomWallDefinition.Type.Door || _type > RoomWallDefinition.Type.DoorCornerBoth)
			{
				if (_type >= RoomWallDefinition.Type.Blank)
				{
					return _type <= RoomWallDefinition.Type.BlankCornerBoth;
				}
				return false;
			}
			return true;
		}

		public bool IsWindow()
		{
			if (_type >= RoomWallDefinition.Type.Window)
			{
				return _type <= RoomWallDefinition.Type.WindowCornerBoth;
			}
			return false;
		}

		public bool IsCorner()
		{
			if (_type != RoomWallDefinition.Type.CornerInner)
			{
				return _type == RoomWallDefinition.Type.CornerOuter;
			}
			return true;
		}

		public bool IsPillar()
		{
			if (_type >= RoomWallDefinition.Type.Pillar)
			{
				return _type <= RoomWallDefinition.Type.PillarCornerBoth;
			}
			return false;
		}

		public bool RequiresBackPiece()
		{
			if (!IsWall() && !IsWindow())
			{
				return IsPillar();
			}
			return true;
		}

		public float DistanceSquared(Vector3 localPos)
		{
			Vector3 vector = _rotation.DirectionVector();
			Vector3 vector2 = _position.ToWorldPosition() + vector;
			Vector3 start = vector2 + new Vector3(vector.z, 0f, vector.x);
			Vector3 end = vector2 - new Vector3(vector.z, 0f, vector.x);
			return MathUtils.NearestPointOnLine(start, end, localPos).SquareDistance2D(localPos);
		}

		public Vector3 ClampPositionToWall(Vector3 localPos)
		{
			Vector3 vector = _rotation.DirectionVector();
			Vector3 vector2 = _position.ToWorldPosition();
			Vector3 vector3 = vector2 + new Vector3(vector.z, 0f, vector.x);
			Vector3 vector4 = vector2 - new Vector3(vector.z, 0f, vector.x);
			Vector3 zero = Vector3.zero;
			switch (_rotation)
			{
			case GridDirection.PosY:
				zero.x = Mathf.Clamp(localPos.x, vector4.x, vector3.x);
				zero.z = vector2.z;
				break;
			case GridDirection.NegY:
				zero.x = Mathf.Clamp(localPos.x, vector3.x, vector4.x);
				zero.z = vector2.z;
				break;
			case GridDirection.PosX:
				zero.x = vector2.x;
				zero.z = Mathf.Clamp(localPos.z, vector4.z, vector3.z);
				break;
			case GridDirection.NegX:
				zero.x = vector2.x;
				zero.z = Mathf.Clamp(localPos.z, vector3.z, vector4.z);
				break;
			}
			return zero;
		}
	}
}
