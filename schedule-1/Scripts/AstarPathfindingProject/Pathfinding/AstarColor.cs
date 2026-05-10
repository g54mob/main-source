using System;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	public class AstarColor
	{
		public Color _SolidColor;

		public Color _UnwalkableNode;

		public Color _BoundsHandles;

		public Color _ConnectionLowLerp;

		public Color _ConnectionHighLerp;

		public Color _MeshEdgeColor;

		public Color[] _AreaColors;

		public static Color SolidColor;

		public static Color UnwalkableNode;

		public static Color BoundsHandles;

		public static Color ConnectionLowLerp;

		public static Color ConnectionHighLerp;

		public static Color MeshEdgeColor;

		private static Color[] AreaColors;

		public static int ColorHash()
		{
			return 0;
		}

		public static Color GetAreaColor(uint area)
		{
			return default(Color);
		}

		public static Color GetTagColor(uint tag)
		{
			return default(Color);
		}

		public void PushToStatic(AstarPath astar)
		{
		}
	}
}
