using Pug.Conversion;

namespace PugWorldGen
{
	public class DungeonPathConverter : SingleAuthoringComponentConverter<DungeonPathAuthoring>
	{
		protected override void Convert(DungeonPathAuthoring authoring)
		{
			EnsureHasBuffer<DungeonPathPlacementBuffer>();
			EnsureHasBuffer<DungeonPathBuffer>();
			foreach (DungeonPathAuthoring.PathConfiguration pathConfiguration in authoring.pathConfigurations)
			{
				AddToBuffer(new DungeonPathPlacementBuffer
				{
					Value = new DungeonPathPlacement
					{
						placement = pathConfiguration.placement,
						roomType = (pathConfiguration.roomType & ~RoomFlags.Fill),
						amount = pathConfiguration.amount,
						canIntersectPaths = (pathConfiguration.canIntersectPaths ? pathConfiguration.intersectablePaths : RoomFlags.None),
						canIntersectRooms = (pathConfiguration.canIntersectRooms ? pathConfiguration.intersectableRooms : RoomFlags.None),
						straightPaths = pathConfiguration.straightPaths,
						pathStartRoomType = pathConfiguration.pathStartRoomType,
						pathEndRoomType = pathConfiguration.pathEndRoomType,
						width = pathConfiguration.width
					}
				});
			}
		}
	}
}
