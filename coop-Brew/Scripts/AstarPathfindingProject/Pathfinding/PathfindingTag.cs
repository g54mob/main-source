using System;

namespace Pathfinding
{
	[Serializable]
	public struct PathfindingTag
	{
		public uint value;

		public PathfindingTag(uint value)
		{
			this.value = 0u;
		}

		public static implicit operator uint(PathfindingTag tag)
		{
			return 0u;
		}

		public static implicit operator PathfindingTag(uint tag)
		{
			return default(PathfindingTag);
		}

		public static PathfindingTag FromName(string tagName)
		{
			return default(PathfindingTag);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
