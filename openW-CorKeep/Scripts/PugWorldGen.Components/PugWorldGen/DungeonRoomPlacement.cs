using Pug.UnityExtensions;

namespace PugWorldGen
{
	public struct DungeonRoomPlacement
	{
		public RoomPlacementAlgorithm algorithm;

		public RangeInt amount;

		public RangeInt size;

		public RoomFlags roomType;

		public RoomFlags canIntersectRooms;

		public RangeInt fromExistingSpacing;

		public bool fromExistingPerpendicular;

		public float angleMin;

		public float angleMax;

		public bool alignAngleWithCoreRadial;
	}
}
