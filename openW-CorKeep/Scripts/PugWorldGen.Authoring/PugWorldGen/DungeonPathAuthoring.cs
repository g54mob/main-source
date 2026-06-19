using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

namespace PugWorldGen
{
	[DisallowMultipleComponent]
	public class DungeonPathAuthoring : MonoBehaviour
	{
		[Serializable]
		public struct PathConfiguration
		{
			public PathPlacementAlgorithm placement;

			public RoomFlags roomType;

			[MinMax(0f, 100f)]
			public Pug.UnityExtensions.RangeInt amount;

			[Header("\"Can intersect rooms/paths\" means that the path can go through\nother rooms/paths to reach the target start and end rooms.\nIt does not affect how it intersects with the start and end rooms.")]
			public bool canIntersectPaths;

			public RoomFlags intersectablePaths;

			public bool canIntersectRooms;

			public RoomFlags intersectableRooms;

			public bool straightPaths;

			public RoomFlags pathStartRoomType;

			public RoomFlags pathEndRoomType;

			[Range(1f, 20f)]
			public float width;

			public string helpNotes;
		}

		public List<PathConfiguration> pathConfigurations = new List<PathConfiguration>();
	}
}
