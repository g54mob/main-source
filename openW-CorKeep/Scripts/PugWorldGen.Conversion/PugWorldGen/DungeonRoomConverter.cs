using Pug.Conversion;
using Unity.Mathematics;

namespace PugWorldGen
{
	public class DungeonRoomConverter : SingleAuthoringComponentConverter<DungeonRoomAuthoring>
	{
		protected override void Convert(DungeonRoomAuthoring authoring)
		{
			EnsureHasBuffer<DungeonRoomPlacementBuffer>();
			EnsureHasBuffer<DungeonRoomBuffer>();
			foreach (DungeonRoomAuthoring.RoomConfiguration roomConfiguration in authoring.roomConfigurations)
			{
				int num;
				if (roomConfiguration.canIntersectOtherRooms)
				{
					RoomPlacementAlgorithm placement = roomConfiguration.placement;
					num = ((placement == RoomPlacementAlgorithm.Random || placement == RoomPlacementAlgorithm.FromOtherRooms) ? 1 : 0);
				}
				else
				{
					num = 0;
				}
				bool flag = (byte)num != 0;
				AddToBuffer(new DungeonRoomPlacementBuffer
				{
					Value = new DungeonRoomPlacement
					{
						algorithm = roomConfiguration.placement,
						roomType = roomConfiguration.roomType,
						amount = roomConfiguration.amount,
						size = roomConfiguration.size,
						fromExistingSpacing = roomConfiguration.spacing,
						fromExistingPerpendicular = roomConfiguration.straightPaths,
						canIntersectRooms = (flag ? roomConfiguration.intersectableRooms : RoomFlags.None),
						angleMin = math.radians(roomConfiguration.angle.min),
						angleMax = math.radians(roomConfiguration.angle.max),
						alignAngleWithCoreRadial = roomConfiguration.alignAngleWithCoreRadial
					}
				});
			}
		}
	}
}
