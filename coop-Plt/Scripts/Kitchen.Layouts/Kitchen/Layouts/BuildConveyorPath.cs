using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kitchen.Layouts
{
	public static class BuildConveyorPath
	{
		public static bool BuildExteriorPath(LayoutPosition start, Orientation start_orientation, LayoutPosition end, Orientation end_orientation, Bounds map, int detour, out List<(LayoutPosition, Orientation)> result)
		{
			detour = Math.Max(detour, 1);
			result = new List<(LayoutPosition, Orientation)>();
			LayoutPosition layoutPosition = start_orientation;
			LayoutPosition layoutPosition2 = end_orientation;
			Bounds bounds = map;
			LayoutPosition layoutPosition3 = new LayoutPosition(start.x + layoutPosition.x, start.y + layoutPosition.y);
			LayoutPosition layoutPosition4 = new LayoutPosition(end.x + layoutPosition2.x * detour, end.y + layoutPosition2.y * detour);
			Orientation orientation = start_orientation;
			int num = 100;
			while (num-- > 0)
			{
				if (layoutPosition3 == end)
				{
					return true;
				}
				LayoutPosition layoutPosition5 = layoutPosition3 + (LayoutPosition)orientation.ToOffset();
				if (layoutPosition5 == layoutPosition4)
				{
					result.Add((layoutPosition3, orientation));
					orientation = orientation.RotateCCW();
					layoutPosition3 = layoutPosition5;
				}
				else if (!bounds.Contains((Vector2)layoutPosition5))
				{
					orientation = orientation.RotateCCW();
				}
				else
				{
					result.Add((layoutPosition3, orientation));
					layoutPosition3 = layoutPosition5;
				}
			}
			return false;
		}
	}
}
