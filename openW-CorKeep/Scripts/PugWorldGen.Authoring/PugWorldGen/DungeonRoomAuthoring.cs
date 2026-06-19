using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

namespace PugWorldGen
{
	public class DungeonRoomAuthoring : MonoBehaviour
	{
		[Serializable]
		public class RoomConfiguration
		{
			public RoomPlacementAlgorithm placement;

			public RoomFlags roomType;

			[MinMax(0f, 100f)]
			public Pug.UnityExtensions.RangeInt amount;

			[MinMax(1f, 300f)]
			public Pug.UnityExtensions.RangeInt size;

			[MinMax(1f, 100f)]
			public Pug.UnityExtensions.RangeInt spacing;

			[MinMax(0f, 360f)]
			public Pug.UnityExtensions.RangeInt angle = new Pug.UnityExtensions.RangeInt
			{
				min = 0,
				max = 360
			};

			[Tooltip("If true, angle 0 points towards the radial from the core to the center of the dungeon. Otherwise, angle 0 points towards the positive x-axis.")]
			public bool alignAngleWithCoreRadial;

			public bool straightPaths;

			public bool canIntersectOtherRooms;

			public RoomFlags intersectableRooms;

			public string helpNotes;
		}

		public List<RoomConfiguration> roomConfigurations = new List<RoomConfiguration>();
	}
}
