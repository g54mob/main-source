using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Kitchen.Layouts;
using Kitchen.Layouts.Features;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class ConveyorDecorator : Decorator
	{
		[UsedImplicitly]
		public class DecorationsConfiguration : IDecorationConfiguration
		{
			public Appliance Grabber;

			public Appliance Belt;

			public Appliance ShedInputPlaceholder;

			public Appliance ShedOutputPlaceholder;

			public IDecorator Decorator => new ConveyorDecorator();
		}

		public override bool Decorate(Room _)
		{
			if (!(Configuration is DecorationsConfiguration config))
			{
				return false;
			}
			for (int i = 0; i < Blueprint.Features.Count; i++)
			{
				if (Blueprint.Features[i].Type == FeatureType.Door)
				{
					Blueprint.Features[i].Type = FeatureType.EmployeesOnlyDoor;
				}
			}
			Bounds bounds = Blueprint.GetBounds();
			Room outside_room = Blueprint[(int)bounds.min.x, 0];
			Room outside_room2 = Blueprint[(int)bounds.max.x, 0];
			HashSet<LayoutPosition> reserved = new HashSet<LayoutPosition>();
			ConnectRooms(outside_room, config, reserved);
			bool is_output = true;
			AddSheds(outside_room, config, reserved, ref is_output);
			AddSheds(outside_room2, config, reserved, ref is_output);
			return true;
		}

		private void AddSheds(Room outside_room, DecorationsConfiguration config, HashSet<LayoutPosition> reserved, ref bool is_output)
		{
			List<Feature> featuresBetweenRoomAndType = Blueprint.GetFeaturesBetweenRoomAndType(outside_room, RoomType.Kitchen, FeatureType.Hatch);
			featuresBetweenRoomAndType.AddRange(Blueprint.GetFeaturesBetweenRoomAndType(outside_room, RoomType.Dining, FeatureType.Hatch));
			foreach (var item in from h in featuresBetweenRoomAndType
				where !reserved.Contains(h.Tile1) && !reserved.Contains(h.Tile2)
				select Blueprint.GetOrderedTiles(h, outside_room) into r
				orderby Random.value
				select r)
			{
				Orientation relativeOrientation = OrientationHelpers.GetRelativeOrientation(item.Item2, item.Item1);
				NewPiece(config.Grabber, item.Item1, is_output ? relativeOrientation.Flip() : relativeOrientation);
				NewPiece(is_output ? config.ShedOutputPlaceholder : config.ShedInputPlaceholder, item.Item1 + (LayoutPosition)relativeOrientation.ToOffset(), relativeOrientation);
				is_output = !is_output;
			}
		}

		private void ConnectRooms(Room outside_room, DecorationsConfiguration config, HashSet<LayoutPosition> reserved)
		{
			Feature feature = Blueprint.GetFeaturesBetweenRoomAndType(outside_room, RoomType.Kitchen, FeatureType.Hatch).First();
			Feature feature2 = Blueprint.GetFeaturesBetweenRoomAndType(outside_room, RoomType.Dining, FeatureType.Hatch).First();
			reserved.Add(feature.Tile1);
			reserved.Add(feature.Tile2);
			reserved.Add(feature2.Tile1);
			reserved.Add(feature2.Tile2);
			(LayoutPosition, LayoutPosition) orderedTiles = Blueprint.GetOrderedTiles(feature, RoomType.Kitchen);
			(LayoutPosition, LayoutPosition) orderedTiles2 = Blueprint.GetOrderedTiles(feature2, RoomType.Dining);
			Orientation relativeOrientation = OrientationHelpers.GetRelativeOrientation(orderedTiles.Item1, orderedTiles.Item2);
			Orientation relativeOrientation2 = OrientationHelpers.GetRelativeOrientation(orderedTiles2.Item1, orderedTiles2.Item2);
			CreateCounterClockwiseBeltPath(config, orderedTiles.Item1, relativeOrientation, orderedTiles2.Item1, relativeOrientation2, 3);
		}

		private void CreateCounterClockwiseBeltPath(DecorationsConfiguration config, LayoutPosition start, Orientation start_orientation, LayoutPosition end, Orientation end_orientation, int detour)
		{
			Bounds bounds = Blueprint.GetBounds();
			BuildConveyorPath.BuildExteriorPath(start, start_orientation, end, end_orientation, bounds, detour, out var result);
			bool flag = true;
			foreach (var item in result)
			{
				NewPiece(flag ? config.Grabber : config.Belt, item.Item1, item.Item2);
				flag = false;
			}
		}

		private Orientation FindOpenAdjacentTileOrientation(LayoutPosition pos)
		{
			Orientation[] all = OrientationHelpers.All;
			foreach (Orientation orientation in all)
			{
				LayoutPosition layoutPosition = orientation;
				LayoutPosition key = new LayoutPosition(pos.x + layoutPosition.x, pos.y + layoutPosition.y);
				if (!Blueprint.Tiles.TryGetValue(key, out var value) || value.Type == RoomType.Garden || value.Type == RoomType.NoRoom)
				{
					return orientation;
				}
			}
			return Orientation.Null;
		}
	}
}
