using Pug.UnityExtensions;
using Unity.Entities;

namespace PugWorldGen
{
	public struct DungeonPathPlacement : IComponentData, IQueryTypeParameter
	{
		public PathPlacementAlgorithm placement;

		public RoomFlags roomType;

		public RangeInt amount;

		public RoomFlags canIntersectPaths;

		public RoomFlags canIntersectRooms;

		public bool straightPaths;

		public RoomFlags pathStartRoomType;

		public RoomFlags pathEndRoomType;

		public float width;
	}
}
